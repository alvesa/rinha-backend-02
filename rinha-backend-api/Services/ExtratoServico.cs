using rinha_backend_api.Controllers.Response;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.IoC.Services;

namespace rinha_backend_api.Services
{
    public class ExtratoServico : IExtratoServico
    {
        private readonly ITransacaoRespositorio _transacaoRespositorio;

        private readonly IClienteRepositorio _clienteRepositorio;

        public ExtratoServico(ITransacaoRespositorio transacaoRespositorio, IClienteRepositorio clienteRepositorio)
        {
            _transacaoRespositorio = transacaoRespositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        public ExtratoResposta List(int clienteId)
        {
            var list = _transacaoRespositorio.Lista(clienteId);

            var ultimasTransacoes = new List<UltimasTransacoesResposta>();

            foreach (var transaction in list)
            {
                ultimasTransacoes.Add(
                    new UltimasTransacoesResposta {
                        Descricao = transaction.Descricao,
                        Realizada_Em = transaction.RealizadaEm,
                        TipoTransacao = char.Parse(transaction.Tipo.ToString()),
                        Valor = transaction.Valor
                    }
                );
            }

            var conta = _clienteRepositorio.Lista(clienteId);

            var result =  new ExtratoResposta {
                UltimasTransacoes = new List<UltimasTransacoesResposta>(),
                Saldo = new SaldoResponse {
                    Data_Extrato = DateTime.UtcNow,
                    Limite = conta.Limite,
                    Total = conta.Saldo
                }
            };

            result.UltimasTransacoes = ultimasTransacoes;

            return result;
        }
    }
}