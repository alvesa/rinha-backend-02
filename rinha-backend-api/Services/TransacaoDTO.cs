using Models;

namespace Services;
public class TransacaoDTO {
    public TransacaoDTO(long valor, TransacaoTipoEnum tipo, string descricao, DateTime realizada_Em)
    {
        Valor = valor;
        Tipo = tipo;
        Descricao = descricao;
        Realizada_Em = realizada_Em;
    }

    public long Valor { get; set; }
    public TransacaoTipoEnum Tipo { get; set; }
    public string Descricao { get; set; }
    public DateTime Realizada_Em { get; set; }
}