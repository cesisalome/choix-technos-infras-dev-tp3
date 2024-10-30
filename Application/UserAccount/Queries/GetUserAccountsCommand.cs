using Choix_des_technos_et_infras_de_développement___TP3.Application.Models;
using Choix_des_technos_et_infras_de_développement___TP3.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Choix_des_technos_et_infras_de_développement___TP3.Application.UserAccount.Queries
{
    public class GetUserAccountsCommand : UseCaseBase
    {
        public GetUserAccountsCommand(TP3Context dbContext) : base(dbContext) { }

        public async Task<List<UserAccountModel>> GetUserAccountsByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            try
            {
                var userAccounts = await _dbContext.Accounts
                    .Where(account => account.UserId == userId)
                    .Select(account => new UserAccountModel
                    {
                        AccountBalance = account.AccountBalance
                    })
                    .ToListAsync(cancellationToken);

                if (userAccounts == null)
                {
                    throw new Exception(string.Format("Accounts not found for user id : {0}", userId));
                }

                return userAccounts;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
