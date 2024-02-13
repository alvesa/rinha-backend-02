using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rinha_backend_api.Controllers.Request;

namespace rinha_backend_api.IoC.Entities
{
    public class TransactionEntity
    {
        public long Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime RealizadaEm { get; set; }
        public int UserId { get; set; }
        public virtual AccountEntity Account { get; set; }
    }
}