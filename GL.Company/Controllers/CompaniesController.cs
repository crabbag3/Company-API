using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GL.Core.Binding;
using GL.Data;
using GL.Services.Interfaces;
using GL.Core.Response;
using System.Collections.Generic;

namespace GL.Company.Api
{
    [Route("Company")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        /// <summary>
        /// Gets a list of all companies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await companyService.GetAllAsync();
            if (result.Any())
                return Ok(
                result.Select(m => new CompanyResponseModel
                {
                    Name = m.Name,
                    Exchange = m.Exchange,
                    ISIN = m.ISIN,
                    Ticker = m.Ticker,
                    Website = m.Website
                }));

            return NotFound();
        }

        /// <summary>
        /// Gets an existing company by their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var result = await companyService.GetAsync(id);
            if (result != null)
                return Ok(new CompanyResponseModel
                {
                    Name = result.Name,
                    Exchange = result.Exchange,
                    ISIN = result.ISIN,
                    Ticker = result.Ticker,
                    Website = result.Website
                });
            return NotFound();
        }

        /// <summary>
        /// Gets an existing company by their ISIN
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ISIN/{ISIN}")]
        public async Task<IActionResult> GetbyIsin(string ISIN)
        {
            var result = await companyService.GetByIsinAsync(ISIN);

            if (result != null)
                return Ok(new CompanyResponseModel
                {
                    Name = result.Name,
                    Exchange = result.Exchange,
                    ISIN = result.ISIN,
                    Ticker = result.Ticker,
                    Website = result.Website
                });
            return NotFound();
        }

        /// <summary>
        /// Creates a new company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CompanyBindingModel company)
        {
            await companyService.AddAsync(new Core.Models.Company
            {
                Name = company.Name,
                Exchange = company.Exchange,
                Ticker = company.Ticker,
                ISIN = company.ISIN,
                Website = company?.Website
            });

            // TODO: Return id ??
            return Ok();
        }

        /// <summary>
        /// Updates an exisiting company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CompanyBindingModel company)
        {
            await companyService.UpdateAsync(new Core.Models.Company
            {
                Name = company.Name,
                Exchange = company.Exchange,
                Ticker = company.Ticker,
                ISIN = company.ISIN,
                Website = company?.Website
            });
            return Ok();
        }

        /// <summary>
        /// Deletes a company based on the ISIN passed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            // TODO: Not implemented - not apart of requirments
            return Ok();
        }
    }
}