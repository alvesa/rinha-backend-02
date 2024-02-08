
using Models;

namespace Response;

public class ExtratoResponse
{
    public Saldo Saldo { get; set; }
    public IEnumerable<Transacao> Ultimas_Transacoes { get; set; }
}

public class Saldo
{
    public long Total { get; set; }
    public DateTime Data_Extrato { get; set; }
    public long Limite { get; set; }
}