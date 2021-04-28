﻿using GL.Core;
using GL.Enumerations;
using System.Linq;

namespace GL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CompanyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Companies.Any())
            {
                return;   // DB has been seeded
            }
            var companies = new Company[]
            {
                new Company { Name = "Apple Inc.", Exchange = Exchange.NASDAQ, Ticker = "AAPL", ISIN = "US0378331005", Website = "http://www.apple.com"},
                new Company { Name = "British Airways Plc", Exchange = Exchange.PinkSheets, Ticker = "BAIRY", ISIN = "US1104193065"},
                new Company { Name = "British Airways Plc", Exchange = Exchange.EuronextAmsterdam, Ticker = "HEIA", ISIN = "NL0000009165"},
                new Company { Name = "Apple Inc.", Exchange = Exchange.TokyoStockExchange, Ticker = "6752", ISIN = "JP3866800000", Website = "http://www.panasonic.co.jp"},
                new Company { Name = "Porsche Automobil", Exchange = Exchange.DeuthscheBorse, Ticker = "PAH3", ISIN = "DE000PAH0038", Website = "https://www.porsche.com/"},
            };
            foreach (Company company in companies)
            {
                context.Companies.Add(company);
            }
            context.SaveChanges();
        }
    }
}