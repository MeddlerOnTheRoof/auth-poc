using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_poc.data.Interfaces;
using EF = auth_poc.data.DAL;
using auth_poc.data.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_poc.data.Repositories
{
    public class UserAccountsRepository : IUserAccountsRepository
    {
        private readonly EF.AuthPocContext _db;

        public UserAccountsRepository()
        {
            _db = new EF.AuthPocContext();
        }

        public async Task<IEnumerable<UserAccount>> GetUserAccountsAsync()
        {
            return (await _db.UserAccount
                .Include(ua => ua.UserRole)
                .ToListAsync())
                .Select(ToDomainModel);
        }

        public async Task<UserAccount> GetUserAccountAsync(int userAccountId)
        {
            return ToDomainModel(await _db.UserAccount
                .Include(ua => ua.UserRole)
                .FirstOrDefaultAsync(ua => ua.UserAccountId == userAccountId));
        }

        public async Task<int> AddUserAccountAsync(UserAccount userAccount)
        {
            var model = ToDatabaseModel(userAccount);

            model.CreatedByUser = userAccount.CreatedByUser;
            model.CreatedByDate = userAccount.CreatedByDate;

            _db.UserAccount.Add(model);

            await _db.SaveChangesAsync();

            return model.UserAccountId;
        }

        public async Task<int> UpdateUserAccountAsync(UserAccount userAccount)
        {
            var model = await _db.UserAccount.FirstOrDefaultAsync(ua => ua.UserAccountId == userAccount.UserAccountId);

            if (model == null)
                return 0;

            model = ToDatabaseModel(userAccount);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteUserAccountAsync(int userAccountId)
        {
            var model = await _db.UserAccount.FirstOrDefaultAsync(ua => ua.UserAccountId == userAccountId);

            if (model == null)
                return 0;

            _db.UserAccount.Remove(model);

            return await _db.SaveChangesAsync();
        }

        public async Task<bool> IsExistingUserAccountAsync(int userAccountId)
        {
            return await _db.UserAccount.AnyAsync(ua => ua.UserAccountId == userAccountId);
        }

        private UserAccount ToDomainModel(EF.UserAccount userAccount)
        {
            return userAccount != null ? new UserAccount()
            {
                UserAccountId = userAccount.UserAccountId,
                UserAccountName = userAccount.UserAccountName,
                UserAccountPassword = userAccount.UserAccountPassword,
                UserRoleId = userAccount.UserRoleId,
                UserRoleName = userAccount.UserRole.UserRoleName,
                CreatedByDate = userAccount.CreatedByDate,
                CreatedByUser = userAccount.CreatedByUser,
                ModifiedByDate = userAccount.ModifiedByDate,
                ModifiedByUser = userAccount.ModifiedByUser
            } : null;
        }

        private EF.UserAccount ToDatabaseModel(UserAccount userAccount)
        {
            return userAccount != null ? new EF.UserAccount()
            {
                UserAccountId = userAccount.UserAccountId,
                UserAccountName = userAccount.UserAccountName,
                UserAccountPassword = userAccount.UserAccountPassword,
                UserRoleId = userAccount.UserRoleId,
                ModifiedByDate = userAccount.ModifiedByDate,
                ModifiedByUser = userAccount.ModifiedByUser
            } : null;
        }
    }
}
