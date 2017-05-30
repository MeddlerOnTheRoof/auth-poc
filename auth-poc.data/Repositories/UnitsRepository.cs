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

        //private async Task<List<Unit>> GetDomainModels()
        //{
        //    return await (from u in _db.Unit
        //                  join att in _db.AttackType on u.AttackTypeId equals att.AttackTypeId
        //                  join ut in _db.UnitType on u.UnitTypeId equals ut.UnitTypeId
        //                  join ua in _db.UnitArmor on u.UnitId equals ua.UnitId
        //                  select new Unit()
        //                  {
        //                      UnitName = u.UnitName,
        //                      UnitTypeId = u.UnitTypeId,
        //                      UnitTypeName = ut.UnitTypeName,

        //                      Food = u.Food,
        //                      Gold = u.Gold,
        //                      Stone = u.Stone,
        //                      Wood = u.Wood,

        //                      MoveSpeed = u.MoveSpeed,
        //                      LineOfSight = u.LineOfSight,
        //                      Health = u.Health,

        //                      AttackRange = u.AttackRange,
        //                      Attack = u.Attack,
        //                      AttackTypeId = u.AttackTypeId,
        //                      AttackTypeName = att.AttackTypeName,
        //                      AttackSpeed = u.AttackSpeed,

        //                      UnitArmor = u.UnitArmor.Select(armr => new UnitArmor()
        //                      {
        //                          UnitArmorId = armr.UnitArmorId,
        //                          UnitId = armr.UnitId,
        //                          ArmorTypeId = armr.ArmorTypeId,
        //                          ArmorTypeName = armr.ArmorType.ArmorTypeName,
        //                          UnitArmorValue = armr.UnitArmorValue,
        //                          CreatedByDate = armr.CreatedByDate,
        //                          CreatedByUser = armr.CreatedByUser,
        //                          ModifiedByDate = armr.ModifiedByDate,
        //                          ModifiedByUser = armr.ModifiedByUser
        //                      }).ToList(),

        //                      // todo: maybe move this to a separate api call and repo method
        //                      //Builders = u.BuildBuilder
        //                      //.Where(b => b.UnitId == u.UnitId)
        //                      //.Select(ToDomainModelLite)
        //                      //.ToList(),

        //                      //Constructs = u.BuildUnit
        //                      //.Where(b => b.BuilderId == u.UnitId)
        //                      //.Select(ToDomainModelLite)
        //                      //.ToList(),

        //                      CreatedByUser = u.CreatedByUser,
        //                      CreatedByDate = u.CreatedByDate,
        //                      ModifiedByUser = u.ModifiedByUser,
        //                      ModifiedByDate = u.ModifiedByDate
        //                  }).ToListAsync();
        //}

        //private UnitLite ToDomainModelLite(EF.Build build)
        //{
        //    return build != null ? new UnitLite()
        //    {
        //        UnitId = build.UnitId,
        //        UnitName = build.Unit.UnitName,
        //        UnitTypeId = build.Unit.UnitTypeId,
        //        UnitTypeName = build.Unit.UnitType.UnitTypeName,
        //        CreatedByUser = build.Unit.CreatedByUser,
        //        CreatedByDate = build.Unit.CreatedByDate,
        //        ModifiedByUser = build.Unit.ModifiedByUser,
        //    } : null;
        //}

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
