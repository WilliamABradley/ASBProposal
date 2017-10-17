using ASBDemo.Models;
using ASBDemo.Models.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASBDemo.Services
{
    public interface IASBService
    {
        Task<string> GetUserToken(string Username, string Password);

        Task<AccountHolder> GetUser(string Token);

        Task<IReadOnlyList<BankAccount>> GetAccounts(AccountHolder Holder);

        Task<IReadOnlyList<InvestScheme>> GetInvestments(AccountHolder Holder);

        Task<IReadOnlyList<AccountHistoryItem>> GetAccountHistory(IAccount Account);
    }
}