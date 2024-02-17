using System.Net;
using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Dtos;
using rinha_backend_api.IoC.Entities;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.Repositories;

namespace Repositories;

public class ClientRepositorio : IClienteRepositorio {

    private readonly RinhaContexto _contexto;
    // private readonly ITransacaoRespositorio _transacaoRespositorio;

    public ClientRepositorio(RinhaContexto contexto/*, ITransacaoRespositorio transacaoRespositorio*/)
    {
        _contexto = contexto;
        // _transacaoRespositorio = transacaoRespositorio;
    }

    public async Task<ClientesEntidade> FazerTransacao(int clienteId, TipoTransacao tipoTransacao, long valor) {
        
        var conta = _contexto.Clientes.Find(clienteId);

        if(conta == null)
            throw new RinhaError(HttpStatusCode.NotFound, "Cliente nao existente");
        
        switch (tipoTransacao)
        {
            case TipoTransacao.d:
                if(!TransacaoValida((conta.Saldo - valor), conta.Limite))
                    throw new RinhaError(HttpStatusCode.UnprocessableEntity, "Transacao nao valida");
                conta.Saldo -= valor;
                break;
            case TipoTransacao.c:
                conta.Saldo += valor;
                break;
        }

        _contexto.Clientes.Update(conta);

        await _contexto.SaveChangesAsync();

        return conta;
    }

    public bool TransacaoValida(long saldo, long limit) {
        return !((limit * -1) > saldo);
    }

    public ClientesEntidade List(int clienteId)
    {
        return _contexto.Clientes.FirstOrDefault(x => x.ClienteId == clienteId);
    }
}