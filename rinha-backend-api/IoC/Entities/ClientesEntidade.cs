using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rinha_backend_api.IoC.Entities
{
    [Table("clientes")]
    public class ClientesEntidade
    {
        [Key]
        [Required]
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("limite")]
        public long Limite { get; set; }

        [Required]
        [Column("saldo")]
        public long Saldo { get; set; }

        public virtual ICollection<TransacoesEntitidade> Transacoes { get; set; } = new List<TransacoesEntitidade>();
    }

}