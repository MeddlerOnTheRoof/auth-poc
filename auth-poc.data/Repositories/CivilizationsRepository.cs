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
    public class CivilizationsRepository : ICivilizationsRepository
    {
        private readonly EF.AuthPocContext _db;

        public CivilizationsRepository()
        {
            _db = new EF.AuthPocContext();
        }

        public async Task<IEnumerable<Civilization>> GetCivilizationsAsync()
        {
            return (await _db.Civilization.ToListAsync()).Select(ToDomainModel);
        }

        public async Task<Civilization> GetCivilizationAsync(int civilizationId)
        {
            return ToDomainModel(await _db.Civilization.FirstOrDefaultAsync(c => c.CivilizationId == civilizationId));
        }

        public async Task<int> AddCivilizationAsync(Civilization civilization)
        {
            var model = ToDatabaseModel(civilization);

            model.CreatedByUser = civilization.CreatedByUser;
            model.CreatedByDate = DateTime.Now;

            _db.Civilization.Add(model);

            await _db.SaveChangesAsync();

            return model.CivilizationId;
        }

        public async Task<int> UpdateCivilization(Civilization civilization)
        {
            var model = await _db.Civilization.FirstOrDefaultAsync(c => c.CivilizationId == civilization.CivilizationId);

            if (model == null)
                return 0;

            model = ToDatabaseModel(civilization);

            return await _db.SaveChangesAsync();
        }

        public async Task<bool> IsExistingCivilization(int civilizationId)
        {
            return await _db.Civilization.AnyAsync(c => c.CivilizationId == civilizationId);
        }

        private Civilization ToDomainModel(EF.Civilization civ)
        {
            return civ != null ? new Civilization() {
                CivilizationName = civ.CivilizationName,
                CivilizationDescription = civ.CivilizationDescription,
                CreatedByUser = civ.CreatedByUser,
                CreatedByDate = civ.CreatedByDate,
                ModifiedByUser = civ.ModifiedByUser,
                ModifiedByDate = civ.ModifiedByDate
            } : null;
        }

        private EF.Civilization ToDatabaseModel(Civilization civ)
        {
            return civ != null ? new EF.Civilization() {
                CivilizationName = civ.CivilizationName,
                CivilizationDescription = civ.CivilizationDescription,
                ModifiedByUser = civ.ModifiedByUser,
                ModifiedByDate = DateTime.Now
            } : null;
        }
    }
}
