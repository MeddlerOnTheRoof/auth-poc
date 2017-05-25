using System.Collections.Generic;
using System.Threading.Tasks;
using auth_poc.data.Models;

namespace auth_poc.data.Interfaces
{
    public interface ILookupsRepository
    {
        Task<IEnumerable<UnitType>> GetUnitTypes();
    }
}
