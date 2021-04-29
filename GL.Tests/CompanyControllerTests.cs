using GL.Company.Api;
using GL.Core.Models;
using GL.Core.Response;
using GL.Data;
using GL.Services;
using GL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GL.Tests
{
    public class CompanyControllerTests
    {
        [Fact]
        public async Task GetListOfCompanies_ReturnsOk()
        {
            // Arrange
            var mockRepo = new Mock<ICompanyService>();
            mockRepo.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(GetTestCompanies());
            var controller = new CompaniesController(mockRepo.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CompanyResponseModel>>(
                viewResult.Value);
            Assert.Equal(2, model.ToList().Count);
        }

        [Fact]
        public async Task GetCompayByIsin_ReturnsOk()
        {
            // Arrange
            var isin = "US0378331005";
            var mockRepo = new Mock<ICompanyService>();
            mockRepo.Setup(repo => repo.GetByIsinAsync(isin))
            .ReturnsAsync(GetTestCompanies().FirstOrDefault());
            var controller = new CompaniesController(mockRepo.Object);

            // Act
            var result = await controller.GetbyIsin(isin);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CompanyResponseModel>(okResult.Value);

            Assert.Equal("Apple Inc.", returnValue.Name);
        }

        [Fact]
        public async Task GetCompayByInvalidIsin_ReturnsObjectNotFound()
        {
            // Arrange
            var isin = "US0378331005";
            var mockRepo = new Mock<ICompanyService>();
            mockRepo.Setup(repo => repo.GetByIsinAsync(isin))
            .ReturnsAsync((Core.Models.Company)null);
            var controller = new CompaniesController(mockRepo.Object);

            // Act
            var result = await controller.GetbyIsin(isin);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundResult>(result);
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