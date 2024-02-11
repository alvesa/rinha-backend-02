using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Entities;
using rinha_backend_api.IoC.Repositories;

namespace rinha_backend_api.Repositories
{
    public class TransacaoRespository : ITransacaoRespository
    {
        private readonly AccountContext _context;

        public TransacaoRespository(AccountContext context)
        {
            _context = context;
        }

        public AccountEntity MakeTransacao(int userId, TipoTransacao tipoTransacao, long valor)
        {
            var account = _context.accounts.FirstOrDefault(x => x.UserId == userId);

            account.MakeTransacao(tipoTransacao, valor);

            return account;
        }
    }
}