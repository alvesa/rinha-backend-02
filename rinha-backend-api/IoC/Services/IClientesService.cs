using Controllers.Request;
using rinha_backend_api.IoC.Dtos;

namespace rinha_backend_api.IoC.Services
{
    public interface IClientesServico
    {
        public Task<ContaDTO> FazerTransacao(int clienteId, TransacaoRequisicao requisicao);
    }

    public class RinhaError
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string ErrorType { get; set; }
    }
}