namespace Models;
public class Transacao {
    // TODO: Include validation
    public long Valor { get; set; }
    public TransacaoTipoEnum Tipo { get; set; }
    public string Descricao { get; set; }
    public DateTime Realizada_Em { get; set; }
}