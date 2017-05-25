using System.Collections.Generic;
using System.Threading.Tasks;
using auth_poc.data.Models;

namespace auth_poc.data.Interfaces
{
    public interface ICivilizationsRepository
    {
        Task<IEnumerable<Civilization>> GetCivilizationsAsync();
        Task<Civilization> GetCivilizationAsync(int civilizationId);
        Task<int> AddCivilizationAsync(Civilization civilization);
        Task<int> UpdateCivilization(Civilization civilization);
        Task<bool> IsExistingCivilization(int civilizationId);
    }
}
