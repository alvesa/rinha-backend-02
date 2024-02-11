using Controllers.Request;
using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Dtos;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.IoC.Services;

namespace Services;
public class ClienteService : IAccountService {

    private readonly IExtratoRepository _clienteRepository;
    private readonly ITransacaoRespository _transacaoRespository;

    public ClienteService(IExtratoRepository clienteRepository, ITransacaoRespository transacaoRespository)
    {
        _clienteRepository = clienteRepository;
        _transacaoRespository = transacaoRespository;
    }

    public AccountDTO MakeTransacao(int userId, TransacaoRequest request) {


        if(Enum.TryParse(request.TipoTransacao, out TipoTransacao tipoTransacao)) {
            var accountResult = _transacaoRespository.MakeTransacao(userId, tipoTransacao, request.Valor);

            return new AccountDTO {
                Limite = accountResult.Limite,
                Saldo = accountResult.Saldo
            };
        }

        return null;

    }
}