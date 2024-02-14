using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using rinha_backend_api.Controllers.Request;

namespace rinha_backend_api.IoC.Entities
{
    [Table("transacoes")]
    public class TransacoesEntitidade
    {
        [Key]
        [Column("transacao_id")]
        public int TransacaoId { get; set; }
        public long Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime RealizadaEm { get; set; }
        [ForeignKey("usuario_id")]
        public int UsuarioId { get; set; }
        public virtual ClientesEntidade Account { get; set; }
    }
}