using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rinha_backend_api.Controllers.Request;

namespace rinha_backend_api.IoC.Entities
{
    [Table("transacoes")]
    public class TransacoesEntitidade
    {
        [Key]
        [Column("transacao_id")]
        public int TransacaoId { get; set; }

        [Column("valor")]
        public long Valor { get; set; }

        [Column("tipo")]
        public TipoTransacao Tipo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("realizada_em")]
        public DateTime RealizadaEm { get; set; } = new DateTime();

        [ForeignKey("cliente_id")]
        [Column("cliente_id")]
        public int ClienteId { get; set; }
        public virtual ClientesEntidade Cliente { get; set; }
    }
}