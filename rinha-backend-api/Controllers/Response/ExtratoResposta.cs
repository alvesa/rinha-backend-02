using System.Text.Json.Serialization;
using rinha_backend_api.Controllers.Request;

namespace rinha_backend_api.Controllers.Response
{
    public class ExtratoResposta
    {
        public SaldoResponse Saldo { get; set; }
        [JsonPropertyName("ultimas_transacoes")]

        public IEnumerable<UltimasTransacoesResposta> UltimasTransacoes { get; set; }
    }

    public class SaldoResponse {
        public long Total { get; set; }
        [JsonPropertyName("data_extrato")]
        public DateTime Data_Extrato { get; set; }
        public long Limite { get; set; }
    }

    public class UltimasTransacoesResposta {
        public long Valor { get; set; }
        [JsonPropertyName("tipo")]
        public char TipoTransacao { get; set; }
        public string Descricao { get; set; }
        [JsonPropertyName("realizada_em")]
        public DateTime? Realizada_Em { get; set; }
    }
}