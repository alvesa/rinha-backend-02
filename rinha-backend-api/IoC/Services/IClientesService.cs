using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controllers.Request;
using Response;
using rinha_backend_api.IoC.Dtos;
using Services;

namespace rinha_backend_api.IoC.Services
{
    public interface IAccountService
    {
        public ContaDTO FazerTransacao(int userId, TransacaoRequisicao request);
    }
}