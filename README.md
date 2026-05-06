
# 📈 Stock Price Tracker (.NET)
A lightweight command-line C# application built with .NET that tracks real-time stock prices for the past 30 days 

✨ Features
🔎 Get real-time stock prices by ticker symbol
📊 View detailed stock data and trend (close, high, low, upward, downward, flat)
📉 Generate price history graph saved as JPG images
🖥️ Simple and fast CLI built with .NET

🔌 API Configuration
This project uses stock market data from AlphaVantage
🧪 Option 1: To run the application, you must provide an API key via an environment variable.
setx ALPHAVANTAGE_API_KEY "your_api_key_here"
🧪 Option 2: Local Hardcoding (Development Only)
For local testing, you may also hardcode the API key in your project: (Program.cs)
var apiKey = "your_api_key_here";

⚠️ Do not commit hardcoded API keys to source control. This option is for local development only.
⚠️ Important The app will not run without ALPHAVANTAGE_API_KEY set

⚙️ Installation
Clone the repository:
git clone https://github.com/yourusername/stock-price-tracker.git
cd stock-price-tracker

Build the project:
dotnet build

🖥️ How It Works
This application runs in an interactive CLI mode. After starting the program, you will be prompted to enter stock symbol
Run the app and type inputs interactively

▶️ Running the Application
dotnet run
Then you will be prompted:
Enter stock symbol: AAPL


