using Choix_des_technos_et_infras_de_développement___TP3.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Choix_des_technos_et_infras_de_développement___TP3.Application.UserAccount.Commands
{
    public class DeleteUserAccountsCommand : UseCaseBase
    {
        public DeleteUserAccountsCommand(TP3Context dbContext) : base(dbContext) { }

        public async Task DeleteUserAccountsByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            try
            {
                var accountsToDelete = await _dbContext.Accounts
                    .Where(account => account.UserId == userId)
                    .ToListAsync(cancellationToken);

                if (accountsToDelete == null)
                {
                    throw new Exception(string.Format("Accounts not found for user id : {0}", userId));
                }

                foreach (var account in accountsToDelete) {
                    _dbContext.Accounts.Remove(account);
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
