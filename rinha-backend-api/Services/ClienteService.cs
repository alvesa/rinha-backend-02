using Repositories;

namespace Services;
public class ClienteService {
    public IEnumerable<TransacaoDTO> GetTransacoes() {
        var clientesLs = new ClienteRepository();

        var clientes = new List<TransacaoDTO>();

        foreach (var item in clientesLs.GetTransacoes())
        {
            clientes.Add(new TransacaoDTO(item.Valor, item.Tipo, item.Descricao, new DateTime()));
        }

        return clientes;
    }
}