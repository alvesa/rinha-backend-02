using rinha_backend_api.Controllers.Request;

namespace rinha_backend_api.Controllers.Response
{
    public class ExtratoResposta
    {
        public SaldoResponse Saldo { get; set; }
        public IEnumerable<UltimasTransacoesResposta> UltimasTransacoes { get; set; }
    }

    public class SaldoResponse {
        public long Total { get; set; }
        public DateTime Data_Extrato { get; set; }
        public long Limite { get; set; }
    }

    public class UltimasTransacoesResposta {
        public long Valor { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public string Descricao { get; set; }
        public DateTime Realizada_Em { get; set; }
    }
}