using Gl.ExceptionHandler;
using GlassLewis.Core.Models;
using GlassLewis.Data;
using GlassLewis.Services.Interfaces;
using GlassLewis.Services.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassLewis.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyContext _context;

        public CompanyService(CompanyContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Company company)
        {
            // check is dupliacte ISIN
            if (_context.Companies.Any(m => m.ISIN == company.ISIN))
                throw new InvalidOperationException("Cannot have two companies with the same ISIN");

            _context.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetAsync(int id)
        {
            return await _context.Companies
                .FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<Company> GetByIsinAsync(string isin)
        {
            return await _context.Companies
                .FirstOrDefaultAsync(m => m.ISIN == isin);
        }

        public async Task Remove(string isin)
        {
            var companyToDelete = await _context.Companies
              .FirstOrDefaultAsync(m => m.ISIN == isin);
            if (companyToDelete is null)
                throw new NoRecordFoundException($"Company with {isin} does not exist.");

            _context.Remove(companyToDelete);
        }

        public async Task UpdateAsync(Company company)
        {
            var oldCompany = await _context.Companies.FirstOrDefaultAsync(
                m => m.ISIN == company.ISIN);
            if (oldCompany is null)
                throw new NoRecordFoundException($"Company with {company.ISIN} does not exist.");

            oldCompany.Name = company.Name;
            oldCompany.Exchange = company.Exchange;
            oldCompany.Ticker = company.Ticker;
            oldCompany.Website = company.Website;

            _context.Entry(oldCompany).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(company.ISIN))
                {
                    // TODO: Add global exception handler
                    // return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool CompanyExists(string id)
        {
            return _context.Companies.Any(e => e.ISIN == id);
        }
    }
}