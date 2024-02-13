using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Entities;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.Repositories;

namespace Repositories;

public class ClientRepository : IClienteRepository {

    private readonly AccountContext _context;
    private readonly ITransacaoRespository _transacaoRespository;

    public ClientRepository(AccountContext context, ITransacaoRespository transacaoRespository)
    {
        _context = context;
        _transacaoRespository = transacaoRespository;
    }

    public AccountEntity MakeTransacao(int clientId, TipoTransacao tipoTransacao, long valor) {
        
        var account = _context.accounts.FirstOrDefault(x => x.UserId == clientId);
        
        switch (tipoTransacao)
        {
            case TipoTransacao.d:
                if(!IsValidTransaction((account.Saldo - valor), account.Limite))
                    throw new BadHttpRequestException("Nao valido");
                account.Saldo -= valor;
                break;
            case TipoTransacao.c:
                account.Saldo += valor;
                break;
        }

        var transaction = _transacaoRespository.MakeTransacao(clientId, tipoTransacao, valor);

        account.Transactions.Add(transaction);


        return account;
    }

    public bool IsValidTransaction(long saldo, long limit) {
        return !((limit * -1) > saldo);
    }

    public AccountEntity List(int clientId)
    {
        return _context.accounts.FirstOrDefault(x => x.UserId == clientId);
    }
}