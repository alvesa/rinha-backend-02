using System.Net;
using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Entities;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.Middlewares;
using rinha_backend_api.Repositories;

namespace Repositories;

public class ClientRepositorio : IClienteRepositorio {

    private readonly RinhaContexto _contexto;
    
    public ClientRepositorio(RinhaContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<ClientesEntidade> FazerTransacao(int clienteId, TipoTransacao tipoTransacao, long valor) {
        
        var conta = Lista(clienteId);

        switch (tipoTransacao)
        {
            case TipoTransacao.d:
                if(!TransacaoValida((conta.Saldo - valor), conta.Limite))
                    throw new RinhaError(HttpStatusCode.UnprocessableEntity, "Transacao nao valida devido ao limite.");
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

    public ClientesEntidade Lista(int clienteId)
    {
        var cliente = _contexto.Clientes.FirstOrDefault(x => x.ClienteId == clienteId);

        if(cliente == null)
            throw new RinhaError(HttpStatusCode.NotFound, "Cliente nao encontrado");

        return cliente;
    }
}