using Choix_des_technos_et_infras_de_développement___TP3.Application.Models;
using Choix_des_technos_et_infras_de_développement___TP3.Domain;
using Choix_des_technos_et_infras_de_développement___TP3.Persistence;

namespace Choix_des_technos_et_infras_de_développement___TP3.Application.UserAccount.Commands
{
    public class AddUserAccountCommand : UseCaseBase
    {
        public AddUserAccountCommand(TP3Context dbContext) : base(dbContext) { }

        public async Task AddUserAccountAsync(UserAccountModel account, CancellationToken cancellationToken)
        {
            try
            {
                var accountToAdd = new UserAccountEntity
                {
                    UserId = account.UserId,
                    AccountBalance = account.AccountBalance
                };

                await _dbContext.Accounts.AddAsync(accountToAdd, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
