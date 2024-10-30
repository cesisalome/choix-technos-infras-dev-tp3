using Choix_des_technos_et_infras_de_développement___TP3.Application.Models;
using Choix_des_technos_et_infras_de_développement___TP3.Persistence;

namespace Choix_des_technos_et_infras_de_développement___TP3.Application.UserAccount.Commands
{
    public class UpdateUserAccountCommand : UseCaseBase
    {
        public UpdateUserAccountCommand(TP3Context dbContext) : base(dbContext) { }

        public async Task UpdateUserAccountAsync(int id, UserAccountModel account, CancellationToken cancellationToken)
        {
            try
            {
                var accountToUpdate = await _dbContext.Accounts.FindAsync(id, cancellationToken);

                if (accountToUpdate == null)
                {
                    throw new Exception(string.Format("Account not found : {0}", account));
                }

                accountToUpdate.UserId = account.UserId;
                accountToUpdate.AccountBalance = account.AccountBalance;

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
