using GL.Core.Models;
using GL.Data;
using GL.Services.Interfaces;
using GL.Services.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyContext _context; // TODO: Add interface
        private readonly CompanyValidator validator;

        public CompanyService(CompanyContext context, CompanyValidator validator)
        {
            _context = context;
            this.validator = validator;
        }

        public async Task AddAsync(Company company)
        {
            validator.Validate(company);
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

        public async Task UpdateAsync(Company company)
        {
            validator.Validate(company);
            try
            {
                _context.Update(company);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(company.ISIN))
                {
                    // TODO: Add global execpetion handler
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