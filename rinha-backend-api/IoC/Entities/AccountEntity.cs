using rinha_backend_api.Controllers.Request;

namespace rinha_backend_api.IoC.Entities
{
    public class AccountEntity
    {
        public int UserId { get; set; }
        public long Limite { get; set; }
        public long Saldo { get; set; }

        public AccountEntity(int userId, long limit) {
            UserId = userId;
            Limite = limit;
            Saldo = 0;
        }

        public AccountEntity MakeTransacao(TipoTransacao tipoTransacao, long valor) {
            switch (tipoTransacao)
            {
                case TipoTransacao.d: 
                    Saldo -= valor;
                    break;
                case TipoTransacao.c: 
                    Saldo += valor;
                    break;
            }

            return this;
        }
    }

}