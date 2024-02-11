namespace Repositories;

public class ClienteRepository {

    public IEnumerable<TransacaoEntity> GetTransacoes() {
        return new TransacaoEntity().GetTransaction();
    }
}