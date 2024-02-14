using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rinha_backend_api.IoC.Entities
{
    [Table("clientes")]
    public class ClientesEntidade
    {
        [Key]
        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public long Limite { get; set; }
        [Required]
        public long Saldo { get; set; }
        public virtual IEnumerable<TransacoesEntitidade> Transacoes { get; set; }
    }

}