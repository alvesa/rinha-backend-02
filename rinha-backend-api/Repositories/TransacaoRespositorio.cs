using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Entities;
using rinha_backend_api.IoC.Repositories;

namespace rinha_backend_api.Repositories
{
    public class TransacaoRespositorio : ITransacaoRespositorio
    {
        private readonly RinhaContexto _contexto;

        public TransacaoRespositorio(RinhaContexto contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<TransacoesEntitidade> Lista(int userId)
        {
            return _contexto.Transacoes.Where(x => x.ClienteId == userId);
        }

        public async Task FazerTransacao(int userId, TipoTransacao tipoTransacao, string descricao, long valor)
        {
            var transaction = new TransacoesEntitidade {
                Descricao = descricao,
                Tipo = tipoTransacao,
                Valor = valor,
                ClienteId = userId
            };

            await _contexto.Transacoes.AddAsync(transaction);

            await _contexto.SaveChangesAsync();
        }
    }
}