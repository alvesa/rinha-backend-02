
using System.ComponentModel.DataAnnotations;
using rinha_backend_api.Controllers.Request;

namespace Controllers.Request;

public record TransacaoRequest {

    [Required(ErrorMessage = "Campo obrigatorio")]
    public long Valor { get; set; }

    [EnumDataType(typeof(TipoTransacao), ErrorMessage = "Tipo de trasacao nao valida")]
    [Required(ErrorMessage = "Campo obrigatorio")]
    public string? TipoTransacao{ get; set; }

    [MinLength(1, ErrorMessage = "Tamanho maximo e 1")]
    [MaxLength(10, ErrorMessage = "Tamanho maximo e 10")]
    [Required(ErrorMessage = "Campo obrigatorio")]
    public string? Descricao { get; set; }
}