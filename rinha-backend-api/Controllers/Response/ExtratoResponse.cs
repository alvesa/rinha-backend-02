using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rinha_backend_api.Controllers.Request;

namespace rinha_backend_api.Controllers.Response
{
    public class ExtratoResponse
    {
        public SaldoResponse Saldo { get; set; }
        public IEnumerable<UltimasTransacoesResponse> UltimasTransacoes { get; set; }
    }

    public class SaldoResponse {
        public long Total { get; set; }
        public DateTime Data_Extrato { get; set; }
        public long Limite { get; set; }
    }

    public class UltimasTransacoesResponse {
        public long Valor { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public string Descricao { get; set; }
        public DateTime Realizada_Em { get; set; }
    }
}