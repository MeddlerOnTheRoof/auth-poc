using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_poc.data.Interfaces;
using auth_poc.data.Models;
using EF = auth_poc.data.DAL;
using Microsoft.EntityFrameworkCore;

namespace auth_poc.data.Repositories
{
    public class LookupsRepository : ILookupsRepository
    {
        private readonly EF.AuthPocContext _db;

        public LookupsRepository()
        {
            _db = new EF.AuthPocContext();
        }

        public async Task<IEnumerable<UnitType>> GetUnitTypesAsync()
        {
            return await _db.UnitType.Select(ut => new UnitType()
            {
                UnitTypeId = ut.UnitTypeId,
                UnitTypeName = ut.UnitTypeName,
                CreatedByUser = ut.CreatedByUser,
                CreatedByDate = ut.CreatedByDate,
                ModifiedByUser = ut.ModifiedByUser,
                ModifiedByDate = ut.ModifiedByDate
            }).ToListAsync();
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesAsync()
        {
            return await _db.UserRole.Select(ur => new UserRole()
            {
                UserRoleId = ur.UserRoleId,
                UserRoleName = ur.UserRoleName,
                CreatedByUser = ur.CreatedByUser,
                CreatedByDate = ur.CreatedByDate,
                ModifiedByDate = ur.ModifiedByDate,
                ModifiedByUser = ur.ModifiedByUser
            }).ToListAsync();
        }
    }
}
