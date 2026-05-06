# 📈 Stock Price Tracker (.NET)

A lightweight command-line C# application built with .NET that tracks real-time stock prices over the past 30 days.

---

## ✨ Features

- 🔎 Get real-time stock prices by ticker symbol  
- 📊 View detailed stock data and trends (close, high, low, upward, downward, flat)  
- 📉 Generate price history graphs saved as JPG images  
- 🖥️ Simple and fast CLI built with .NET  

---

## 🔌 API Configuration

This project uses stock market data from Alpha Vantage.

You must provide an API key using one of the following methods:

---

### 🧪 Option 1: Environment Variable (Recommended)

Set your API key in your system environment variables:

#### Windows (PowerShell)
```bash ```
setx ALPHAVANTAGE_API_KEY "your_api_key_here"
Set your API key in your system environment variables:

### 🧪 Option 2: Local Hardcoding (Development Only)

For local testing, you may hardcode the API key in `Program.cs`:

```csharp ```
var apiKey = "your_api_key_here";

⚠️ Do not commit hardcoded API keys to source control. This is for local development only.  
⚠️ Important  
   The application will not run without the ALPHAVANTAGE_API_KEY environment variable set.

#### ⚙️ Installation

Clone the repository:  
git clone https://github.com/yourusername/stock-price-tracker.git  
cd stock-price-tracker  

Build the project:  
dotnet build  

#### 🖥️ How It Works
This application runs in interactive CLI mode.
After starting the program, you will be prompted to enter a stock symbol
  
#### ▶️ Running the Application  
dotnet run  
Then you will see:  
Enter stock symbol: (example AAPL)  

#### 📊 Output   
Enter stock symbol: AAPL  
--- Stock Summary last month ---  
Highest Price: $287.51  
Lowest Price: $253.50  
Latest Close: $287.51  
Trend: Upward  
Chart saved as AAPL_LastMonth.jpg in project folder.  
    
#### 📌 Notes
This is an interactive CLI tool  
No command-line arguments are required  
Input is handled via Console.ReadLine()  
Graphs are saved as .jpg files in the project directory  


