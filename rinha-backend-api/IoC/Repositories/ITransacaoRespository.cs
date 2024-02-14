using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rinha_backend_api.Controllers.Request;
using rinha_backend_api.IoC.Entities;

namespace rinha_backend_api.IoC.Repositories
{
    public interface ITransacaoRespositorio
    {
        public Task<TransacoesEntitidade> FazerTransacao(int usuarioId, TipoTransacao tipoTransacao, long valor);
        public IEnumerable<TransacoesEntitidade> Lista(int userId);
    }
}