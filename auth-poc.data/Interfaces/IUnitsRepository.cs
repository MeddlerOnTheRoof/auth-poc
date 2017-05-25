using System.Collections.Generic;
using System.Threading.Tasks;
using auth_poc.data.Models;

namespace auth_poc.data.Interfaces
{
    public interface IUnitsRepository
    {
        Task<IEnumerable<Unit>> GetUnitsAsync();
        Task<Unit> GetUnitAsync(int unitId);
        Task<int> AddUnitAsync(Unit unit);
        Task<int> UpdateUnitAsync(Unit unit);
        Task<int> DeleteUnitAsync(int unitId);
        Task<bool> IsExistingUnitAsync(int unitId);
    }
}
