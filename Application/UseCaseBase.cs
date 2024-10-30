using Choix_des_technos_et_infras_de_développement___TP3.Persistence;

namespace Choix_des_technos_et_infras_de_développement___TP3.Application
{
    public class UseCaseBase
    {
        public TP3Context _dbContext { get; set; }

        public UseCaseBase(TP3Context dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
