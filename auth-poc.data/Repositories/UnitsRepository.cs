using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_poc.data.Interfaces;
using auth_poc.data.Models;
using EF = auth_poc.data.DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace auth_poc.data.Repositories
{
    public class UnitsRepository : IUnitsRepository
    {
        private readonly EF.AuthPocContext _db;

        public UnitsRepository()
        {
            _db = new EF.AuthPocContext();
        }

        public async Task<IEnumerable<Unit>> GetUnitsAsync()
        {
            return (await _db.Unit
                .Include(u => u.AttackType)
                .Include(u => u.UnitType)
                .ToListAsync())
                .Select(ToDomainModel);
        }

        public async Task<Unit> GetUnitAsync(int unitId)
        {
            return ToDomainModel(await _db.Unit
                .Include(u => u.AttackType)
                .Include(u => u.UnitType)
                .FirstOrDefaultAsync(u => u.UnitId == unitId));
        }

        public async Task<int> AddUnitAsync(Unit unit)
        {
            var model = ToDatabaseModel(unit);

            model.CreatedByUser = unit.CreatedByUser;
            model.CreatedByDate = DateTime.Now;

            _db.Unit.Add(model);

            await _db.SaveChangesAsync();

            return model.UnitId;
        }

        public async Task<int> UpdateUnitAsync(Unit unit)
        {
            var model = await _db.Unit.FirstOrDefaultAsync(u => u.UnitId == unit.UnitId);

            if (model == null)
                return 0;

            model = ToDatabaseModel(unit);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteUnitAsync(int unitId)
        {
            var model = await _db.Unit.FirstOrDefaultAsync(u => u.UnitId == unitId);

            if (model == null)
                return 0;

            _db.Unit.Remove(model);

            return await _db.SaveChangesAsync();
        }

        public async Task<bool> IsExistingUnitAsync(int unitId)
        {
            return await _db.Unit.AnyAsync(u => u.UnitId == unitId);
        }

        private Unit ToDomainModel(EF.Unit unit)
        {
            return unit != null ? new Unit()
            {
                UnitName = unit.UnitName,
                UnitTypeId = unit.UnitTypeId,
                UnitTypeName = unit.UnitType.UnitTypeName,
                Food = unit.Food,
                Gold = unit.Gold,
                Stone = unit.Stone,
                Wood = unit.Wood,
                MoveSpeed = unit.MoveSpeed,
                LineOfSight = unit.LineOfSight,
                Health = unit.Health,
                AttackRange = unit.AttackRange,
                Attack = unit.Attack,
                AttackTypeId = unit.AttackTypeId,
                AttackTypeName = unit.AttackType.AttackTypeName,
                AttackSpeed = unit.AttackSpeed,
                CreatedByUser = unit.CreatedByUser,
                CreatedByDate = unit.CreatedByDate,
                ModifiedByUser = unit.ModifiedByUser,
                ModifiedByDate = unit.ModifiedByDate
            } : null;
        }

        private EF.Unit ToDatabaseModel(Unit unit)
        {
            return unit != null ? new EF.Unit()
            {
                UnitName = unit.UnitName,
                UnitTypeId = unit.UnitTypeId,
                Food = unit.Food,
                Gold = unit.Gold,
                Stone = unit.Stone,
                Wood = unit.Wood,
                MoveSpeed = unit.MoveSpeed,
                LineOfSight = unit.LineOfSight,
                Health = unit.Health,
                AttackRange = unit.AttackRange,
                Attack = unit.Attack,
                AttackTypeId = unit.AttackTypeId,
                AttackSpeed = unit.AttackSpeed,
                ModifiedByUser = unit.ModifiedByUser,
                ModifiedByDate = DateTime.Now
            } : null;
        }
    }
}
