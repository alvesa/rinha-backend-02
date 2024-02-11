using Models;

namespace Request;
public class TransacaoRequest {
    public long Valor { get; set; }
    public TransacaoTipoEnum Tipo { get; set; }
    public string Descricao { get; set; }
}