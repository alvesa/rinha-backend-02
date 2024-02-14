using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rinha_backend_api.Controllers.Response;

namespace rinha_backend_api.IoC.Services
{
    public interface IExtratoServico
    {
        public ExtratoResposta List(int userId);
    }
}