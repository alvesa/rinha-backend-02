using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Entities;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.Repositories;

namespace Repositories;

public class ClientRepositorio : IClienteRepositorio {

    private readonly RinhaContexto _contexto;
    private readonly ITransacaoRespositorio _transacaoRespositorio;

    public ClientRepositorio(RinhaContexto contexto, ITransacaoRespositorio transacaoRespositorio)
    {
        _contexto = contexto;
        _transacaoRespositorio = transacaoRespositorio;
    }

    public ClientesEntidade FazerTransacao(int usuarioId, TipoTransacao tipoTransacao, long valor) {
        
        var conta = _contexto.Clientes.Find(usuarioId);
        
        switch (tipoTransacao)
        {
            case TipoTransacao.d:
                if(!TransacaoValida((conta.Saldo - valor), conta.Limite))
                    throw new BadHttpRequestException("Nao valido");
                conta.Saldo -= valor;
                break;
            case TipoTransacao.c:
                conta.Saldo += valor;
                break;
        }

        // var transaction = _transacaoRespositorio.FazerTransacao(usuarioId, tipoTransacao, valor);

        // conta.Transacoes.Add(transaction);


        return conta;
    }

    public bool TransacaoValida(long saldo, long limit) {
        return !((limit * -1) > saldo);
    }

    public ClientesEntidade List(int usuarioId)
    {
        return _contexto.Clientes.FirstOrDefault(x => x.UsuarioId == usuarioId);
    }
}