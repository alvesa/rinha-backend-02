using rinha_backend_api.Controllers.Response;

namespace rinha_backend_api.IoC.Services
{
    public interface IExtratoServico
    {
        public ExtratoResposta List(int clienteId);
    }
}