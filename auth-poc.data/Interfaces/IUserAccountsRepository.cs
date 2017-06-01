using System.Collections.Generic;
using System.Threading.Tasks;
using auth_poc.data.Models;

namespace auth_poc.data.Interfaces
{
    public interface IUserAccountsRepository
    {
        Task<IEnumerable<UserAccount>> GetUserAccountsAsync();
        Task<UserAccount> GetUserAccountAsync(int userAccountId);
        Task<int> AddUserAccountAsync(UserAccount userAccount);
        Task<int> UpdateUserAccountAsync(UserAccount userAccount);
        Task<int> DeleteUserAccountAsync(int userAccountId);
        Task<bool> IsExistingUserAccountAsync(int userAccountId);
    }
}
