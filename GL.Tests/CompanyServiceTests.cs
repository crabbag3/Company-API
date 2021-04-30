using Gl.ExceptionHandler;
using GlassLewis.Data;
using GlassLewis.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GlassLewis.Tests
{
    public class CompanyServiceTests
    {
        [Fact]
        public async Task PostCompayWithDuplicateISIN_ReturnsException()
        {
            var isin = "US0378331005";
            var context = GetContextWithData();
            var service = new CompanyService(context);

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.AddAsync(new Core.Models.Company()
            {
                Name = "Test",
                Exchange = "NASDAQ",
                ISIN = isin,
                Ticker = "TST",
            }));
        }

        [Fact]
        public async Task DeleteCompayThatDoesntExist_ReturnsException()
        {
            var isinThatDoesntExist = "azzz";

            var context = GetContextWithData();
            var service = new CompanyService(context);

            await Assert.ThrowsAsync<NoRecordFoundException>(() => service.Remove(isinThatDoesntExist));
        }

        [Fact]
        public async Task UpdateCompayThatDoesntExist_ReturnsException()
        {
            var isinThatDoesntExist = "azzz";

            var context = GetContextWithData();
            var service = new CompanyService(context);

            await Assert.ThrowsAsync<NoRecordFoundException>(() => service.UpdateAsync(new Core.Models.Company()
            {
                Name = "Test",
                Exchange = "NASDAQ",
                ISIN = isinThatDoesntExist,
                Ticker = "TST",
            }));
        }

        [Fact]
        public async Task UpdateCompayThatDoesExist_ReturnsVoid()
        {
            var context = GetContextWithData();
            var service = new CompanyService(context);

            await service.UpdateAsync(new Core.Models.Company()
            {
                Name = "Test",
                Exchange = "NASDAQ",
                ISIN = "US1104193065",
                Ticker = "TST",
            });
        }

        /// <summary>
        /// Setup test data and seed our in memory database
        /// </summary>
        /// <returns></returns>
        private CompanyContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<CompanyContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString()) // GUID - every test has unique DB
                              .Options;
            var context = new CompanyContext(options);

            context.Add(new Core.Models.Company()
            {
                Name = "Apple Inc.",
                Exchange = "NASDAQ",
                Ticker = "AAPL",
                ISIN = "US0378331005",
                Website = "http://www.apple.com"
            });

            context.Add(new Core.Models.Company()
            {
                Name = "British Airways Plc",
                Exchange = "Pink Sheets",
                Ticker = "BAIRY",
                ISIN = "US1104193065"
            });

            context.SaveChanges();

            return context;
        }
    }
}