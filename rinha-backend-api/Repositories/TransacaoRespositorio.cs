using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Entities;
using rinha_backend_api.IoC.Repositories;

namespace rinha_backend_api.Repositories
{
    public class TransacaoRespositorio : ITransacaoRespositorio
    {
        private readonly RinhaContexto _contexto;
        private readonly IClienteRepositorio _clienteRepositorio;

        public TransacaoRespositorio(RinhaContexto contexto, IClienteRepositorio clienteRepositorio)
        {
            _contexto = contexto;
            _clienteRepositorio = clienteRepositorio;
        }

        public IEnumerable<TransacoesEntitidade> Lista(int clienteId)
        {
            return _contexto.Transacoes.Where(x => x.ClienteId == clienteId).OrderByDescending(x => x.RealizadaEm);
        }

        public async Task FazerTransacao(int clienteId, TipoTransacao tipoTransacao, string descricao, long valor)
        {
            var cliente = this._clienteRepositorio.Lista(clienteId);

            var transaction = new TransacoesEntitidade {
                Descricao = descricao,
                Tipo = tipoTransacao,
                Valor = valor,
                ClienteId = clienteId,
                RealizadaEm = DateTime.UtcNow,
                Cliente = cliente
            };

            await _contexto.Transacoes.AddAsync(transaction);

            await _contexto.SaveChangesAsync();
        }
    }
}