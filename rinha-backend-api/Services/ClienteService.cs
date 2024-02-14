using Controllers.Request;
using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Dtos;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.IoC.Services;

namespace Services;
public class ClienteService : IAccountService {

    private readonly IClienteRepositorio _clienteRepositorio;
    private readonly ITransacaoRespositorio _transacaoRespositorio;

    public ClienteService(IClienteRepositorio clienteRepositorio, ITransacaoRespositorio transacaoRespositorio)
    {
        _clienteRepositorio = clienteRepositorio;
        _transacaoRespositorio = transacaoRespositorio;
    }
    public ContaDTO FazerTransacao(int usuarioId, TransacaoRequisicao requisicao) {


        if(Enum.TryParse(requisicao.TipoTransacao, out TipoTransacao tipoTransacao)) {
            var resultadoConta = _clienteRepositorio.FazerTransacao(usuarioId, tipoTransacao, requisicao.Valor);

            return new ContaDTO {
                Limite = resultadoConta.Limite,
                Saldo = resultadoConta.Saldo
            };
        }

        return null;

    }
}