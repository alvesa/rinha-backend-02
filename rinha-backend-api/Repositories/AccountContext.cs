using rinha_backend_api.IoC.Entities;

namespace rinha_backend_api.Repositories
{
    public class AccountContext
    {
        public IEnumerable<AccountEntity> accounts { get; set; }

        public AccountContext()
        {
            initAccount();
        }

        public void initAccount() {
            accounts = new List<AccountEntity>(){
                new AccountEntity(1, 100000),
                new AccountEntity(2, 80000),
                new AccountEntity(3, 1000000),
                new AccountEntity(4, 10000000),
                new AccountEntity(5, 500000),
            };
        }
    }
}