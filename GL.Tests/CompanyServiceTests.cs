using GL.Company.Api;
using GL.Core.Models;
using GL.Core.Response;
using GL.Data;
using GL.Services;
using GL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GL.Tests
{
    public class CompanyServiceTests
    {
        [Fact]
        public async Task PostCompayWithDuplicateISIN_ReturnsException()
        {
            // Arrange
            var isin = "US0378331005";

            var mockSet = new Mock<DbSet<Core.Models.Company>>();

            var mockContext = new Mock<CompanyContext>();
            mockContext.Setup(m => m.Companies).Returns(mockSet.Object);

            var service = new CompanyService(mockContext.Object);

            // Act

            await Assert.ThrowsAsync<Exception>(() => service.AddAsync(new Core.Models.Company()
            {
                Name = "Test",
                Exchange = "NASDAQ",
                ISIN = isin,
                Ticker = "TST",
            }));
        }

        private List<Core.Models.Company> GetTestCompanies()
        {
            var sessions = new List<Core.Models.Company>();
            sessions.Add(new Core.Models.Company()
            {
                Name = "Apple Inc.",
                Exchange = "NASDAQ",
                Ticker = "AAPL",
                ISIN = "US0378331005",
                Website = "http://www.apple.com"
            });
            sessions.Add(new Core.Models.Company()
            {
                Name = "British Airways Plc",
                Exchange = "Pink Sheets",
                Ticker = "BAIRY",
                ISIN = "US1104193065"
            });
            return sessions;
        }
    }
}