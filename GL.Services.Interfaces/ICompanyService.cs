using GL.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GL.Services.Interfaces
{
    public interface ICompanyService
    {
        Task AddAsync(Company company);

        Task<IEnumerable<Company>> GetAllAsync();

        Task<Company> GetAsync(int id);

        Task<Company> GetByIsinAsync(string ISIN);

        Task UpdateAsync(Company company);
    }
}