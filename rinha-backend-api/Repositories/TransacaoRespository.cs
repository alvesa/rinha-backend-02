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

        public IEnumerable<TransactionEntity> List(int userId)
        {
            return _context.transactions.Where(x => x.UserId == userId);
        }

        public TransactionEntity MakeTransacao(int userId, TipoTransacao tipoTransacao, long valor)
        {

            if(_context.transactions == null) {
                _context.transactions = new List<TransactionEntity>(); 
            }

            var transaction = _context.transactions.FirstOrDefault(x => x.UserId == userId);

            transaction = new TransactionEntity {
                Descricao = "",
                RealizadaEm = new DateTime(),
                Tipo = tipoTransacao,
                Valor = valor,
                UserId = userId,
            };

            var transactions = new List<TransactionEntity>();

            transactions.AddRange(_context.transactions);
            transactions.Add(transaction);
            
            _context.transactions = transactions;

            return transaction;
        }
    }
}