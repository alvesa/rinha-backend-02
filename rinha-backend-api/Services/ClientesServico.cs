using Controllers.Request;
using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Dtos;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.IoC.Services;

namespace Services;
public class ClientesServico : IClientesServico {

    private readonly IClienteRepositorio _clienteRepositorio;
    private readonly ITransacaoRespositorio _transacaoRespositorio;

    public ClientesServico(IClienteRepositorio clienteRepositorio, ITransacaoRespositorio transacaoRespositorio)
    {
        _clienteRepositorio = clienteRepositorio;
        _transacaoRespositorio = transacaoRespositorio;
    }
    public async Task<ContaDTO> FazerTransacao(int clienteId, TransacaoRequisicao requisicao) {


        if(Enum.TryParse(requisicao.Tipo, out TipoTransacao tipoTransacao)) {
            await _transacaoRespositorio.FazerTransacao(clienteId, tipoTransacao, requisicao.Descricao, requisicao.Valor);
            
            var resultadoConta = await _clienteRepositorio.FazerTransacao(clienteId, tipoTransacao, requisicao.Valor);

            return new ContaDTO {
                Limite = resultadoConta.Limite,
                Saldo = resultadoConta.Saldo
            };
        }

        return null;

    }
}