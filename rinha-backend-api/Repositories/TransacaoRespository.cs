using System.Data.Entity;
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
            return _contexto.Transacao.Where(x => x.UsuarioId == userId);
        }

        public async Task<TransacoesEntitidade> FazerTransacao(int userId, TipoTransacao tipoTransacao, long valor)
        {
            var transaction = await _contexto.Transacao.FirstOrDefaultAsync(x => x.UsuarioId == userId);

            transaction = new TransacoesEntitidade {
                Descricao = "",
                RealizadaEm = new DateTime(),
                Tipo = tipoTransacao,
                Valor = valor,
                UsuarioId = userId,
            };

            _contexto.Transacao.Add(transaction);

            return transaction;
        }
    }
}