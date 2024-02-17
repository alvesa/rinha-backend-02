using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Entities;

namespace rinha_backend_api.IoC.Repositories
{
    public interface ITransacaoRespositorio
    {
        public Task FazerTransacao(int clienteId, TipoTransacao tipoTransacao, string descricao, long valor);
        public IEnumerable<TransacoesEntitidade> Lista(int userId);
    }
}