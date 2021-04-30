using GlassLewis.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlassLewis.Services.Interfaces
{
    public interface ICompanyService
    {
        Task AddAsync(Company company);

        Task<IEnumerable<Company>> GetAllAsync();

        Task<Company> GetAsync(int id);

        Task<Company> GetByIsinAsync(string ISIN);

        Task UpdateAsync(Company company);

        Task Remove(string isin);
    }
}