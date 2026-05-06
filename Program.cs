using System.Globalization;
using Newtonsoft.Json.Linq;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using System.Drawing;

Console.Write("Enter stock symbol: ");
string symbol = Console.ReadLine().ToUpper();

// Replace with your Alpha Vantage API key
string apiKey = Environment.GetEnvironmentVariable("ALPHAVANTAGE_API_KEY");

if (string.IsNullOrEmpty(apiKey))
{
    Console.WriteLine("API key not found. Please set ALPHAVANTAGE_API_KEY.");
    return;
}

var prices = await GetDailyPrices(symbol, apiKey);

if (prices.Count == 0)
{
    Console.WriteLine($"No data found for symbol: {symbol}");
    return;
}

string pngFile = $"{symbol}_LastMonth.png";
string jpgFile = $"{symbol}_LastMonth.jpg";

// Generate graph as PNG
GenerateChart(symbol, prices, pngFile);

// Convert PNG to JPG
using (var img = Image.FromFile(pngFile))
{
    img.Save(jpgFile, System.Drawing.Imaging.ImageFormat.Jpeg);
}

Console.WriteLine($"Chart saved as {jpgFile} in project folder.");

// Automatically open the JPG
System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
{
    FileName = jpgFile,
    UseShellExecute = true
});

async Task<SortedDictionary<DateTime, double>> GetDailyPrices(string symbol, string apiKey)
{
    var prices = new SortedDictionary<DateTime, double>();

    using (var client = new HttpClient())
    {
        string url = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={apiKey}&outputsize=compact";
        var response = await client.GetStringAsync(url);
        var json = JObject.Parse(response);

        if (!json.ContainsKey("Time Series (Daily)"))
            return prices;

        var timeSeries = json["Time Series (Daily)"];
        foreach (var item in timeSeries.Children<JProperty>())
        {
            DateTime date = DateTime.Parse(item.Name);
            double close = double.Parse(item.Value["4. close"].ToString(), CultureInfo.InvariantCulture);

            // Keep only last 30 days
            if (date >= DateTime.Now.AddMonths(-1))
                prices[date] = close;
        }
    }

    return prices;
}

void GenerateChart(string symbol, SortedDictionary<DateTime, double> prices, string outputFile)
{
    var plotModel = new PlotModel { Title = $"{symbol} - Last Month Prices" };

    plotModel.Background = OxyColors.White;
    plotModel.DefaultFontSize = 14;


    var series = new LineSeries
    {
        MarkerType = MarkerType.Circle,
        MarkerSize = 3
    };

    var dateAxis = new CategoryAxis
    {
        Position = AxisPosition.Bottom,
        Title = "Date",
        GapWidth = 0,
        Angle = -45
    };

    var dates = new List<DateTime>();

    int index = 0;
    foreach (var kvp in prices)
    {
        dates.Add(kvp.Key);
        series.Points.Add(new DataPoint(index, kvp.Value));

        if (index % 3 == 0)
            dateAxis.Labels.Add(kvp.Key.ToString("MMM dd"));
        else
            dateAxis.Labels.Add(string.Empty);

        index++;
    }

    plotModel.Series.Add(series);
    plotModel.Axes.Add(dateAxis);

    plotModel.Axes.Add(new LinearAxis
    {
        Position = AxisPosition.Left,
        Title = "Price ($)"
    });

    plotModel.TrackerChanged += (s, e) =>
    {
        if (e.HitResult != null)
        {
            int i = (int)e.HitResult.Index;

            DateTime date = dates[i];
            double price = prices.Values.ElementAt(i);

            e.HitResult.Text =
                $"{date:MMM dd, yyyy}\n" +
                $"Price: ${price:0.00}";
        }
    };



    var exporter = new PngExporter
    {
        Width = 900,
        Height = 600
    };

    exporter.ExportToFile(plotModel, outputFile);
}
