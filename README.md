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
```bash
setx ALPHAVANTAGE_API_KEY "your_api_key_here"


