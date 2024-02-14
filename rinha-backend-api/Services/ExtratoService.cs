using rinha_backend_api.Controllers.Response;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.IoC.Services;

namespace rinha_backend_api.Services
{
    public class ExtratoServico : IExtratoServico
    {
        private readonly ITransacaoRespositorio _transacaoRespository;

        private readonly IClienteRepositorio _clienteRepository;

        public ExtratoServico(ITransacaoRespositorio transacaoRespositorio, IClienteRepositorio clienteRepositorio)
        {
            _transacaoRespository = transacaoRespositorio;
            _clienteRepository = clienteRepositorio;
        }

        public ExtratoResposta List(int usuarioId)
        {
            var list = _transacaoRespository.Lista(usuarioId);

            var ultimasTransacoes = new List<UltimasTransacoesResposta>();

            foreach (var transaction in list)
            {
                ultimasTransacoes.Add(
                    new UltimasTransacoesResposta {
                        Descricao = transaction.Descricao,
                        Realizada_Em = transaction.RealizadaEm,
                        TipoTransacao = transaction.Tipo,
                        Valor = transaction.Valor
                    }
                );
            }

            var account = _clienteRepository.List(usuarioId);

            var result =  new ExtratoResposta {
                UltimasTransacoes = new List<UltimasTransacoesResposta>(),
                Saldo = new SaldoResponse {
                    Data_Extrato = new DateTime(),
                    Limite = account.Limite,
                    Total = account.Saldo
                }
            };

            result.UltimasTransacoes = ultimasTransacoes;

            return result;
        }
    }
}