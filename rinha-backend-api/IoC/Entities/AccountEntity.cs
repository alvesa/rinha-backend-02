using rinha_backend_api.Controllers.Request;

namespace rinha_backend_api.IoC.Entities
{
    public class AccountEntity
    {
        public int UserId { get; set; }
        public long Limite { get; set; }
        public long Saldo { get; set; }
        public virtual List<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();

        public AccountEntity(int userId, long limit) {
            UserId = userId;
            Limite = limit;
            Saldo = 0;
        }
    }

}