using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Entities;

namespace rinha_backend_api.IoC.Repositories
{
    public interface IClienteRepositorio
    {
        public Task<ClientesEntidade> FazerTransacao(int clienteId, TipoTransacao tipoTransacao, long valor);
        public ClientesEntidade Lista(int clienteId);
    }
}