using Models;

namespace Repositories;

public class TransacaoEntity
{
    public int Id { get; set; }
    public long Valor { get; set; }
    public TransacaoTipoEnum Tipo { get; set; }
    public string Descricao { get; set; }

    public IEnumerable<TransacaoEntity> GetTransaction()
    {
        IEnumerable<TransacaoEntity> transacoes = new List<TransacaoEntity>() {
        new TransacaoEntity() { Id = 1, Valor = 1000, Descricao= "Descricao", Tipo = TransacaoTipoEnum.CREDITO},
        new TransacaoEntity() { Id = 1, Valor = 1000, Descricao= "Descricao", Tipo = TransacaoTipoEnum.DEBITO},
        new TransacaoEntity() { Id = 2, Valor = 1000, Descricao= "Descricao", Tipo = TransacaoTipoEnum.DEBITO},
        new TransacaoEntity() { Id = 2, Valor = 2000, Descricao= "Descricao", Tipo = TransacaoTipoEnum.DEBITO},
        new TransacaoEntity() { Id = 3, Valor = 1000, Descricao= "Descricao", Tipo = TransacaoTipoEnum.CREDITO},
    };
        return transacoes;
    }
}