
using System.ComponentModel.DataAnnotations;
using rinha_backend_api.Controllers.Helper;
using rinha_backend_api.Controllers.Request;

namespace Controllers.Request;

public record TransacaoRequisicao {

    [Required(ErrorMessage = "Campo obrigatorio")]
    // [CustomValue("Valor invalido")]
    public long Valor { get; set; }

    [EnumDataType(typeof(TipoTransacao), ErrorMessage = "Tipo de trasacao nao valida")]
    [Required(ErrorMessage = "Campo obrigatorio")]
    public string? Tipo{ get; set; }

    [CustomMinLength(1,"Tamanho minimo e de 1 caracter")]
    [CustomMaxLength(10,"Tamanho maximo e de 10 caracteres")]
    [Required(ErrorMessage = "Campo obrigatorio")]
    public string? Descricao { get; set; }
}