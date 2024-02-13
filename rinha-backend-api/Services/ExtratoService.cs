using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rinha_backend_api.Controllers.Response;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.IoC.Services;

namespace rinha_backend_api.Services
{
    public class ExtratoService : IExtratoService
    {
        private readonly ITransacaoRespository _transacaoRespository;

        private readonly IClienteRepository _clienteRepository;

        public ExtratoService(ITransacaoRespository transacaoRespository, IClienteRepository clienteRepository)
        {
            _transacaoRespository = transacaoRespository;
            _clienteRepository = clienteRepository;
        }

        public ExtratoResponse List(int userId)
        {
            var list = _transacaoRespository.List(userId);

            var ultimasTransacoes = new List<UltimasTransacoesResponse>();

            foreach (var transaction in list)
            {
                ultimasTransacoes.Add(
                    new UltimasTransacoesResponse {
                        Descricao = transaction.Descricao,
                        Realizada_Em = transaction.RealizadaEm,
                        TipoTransacao = transaction.Tipo,
                        Valor = transaction.Valor
                    }
                );
            }

            var account = _clienteRepository.List(userId);

            var result =  new ExtratoResponse {
                UltimasTransacoes = new List<UltimasTransacoesResponse>(),
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