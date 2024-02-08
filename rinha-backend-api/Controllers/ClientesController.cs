using Microsoft.AspNetCore.Mvc;
using Request;
using Response;

namespace rinha_backend_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    [HttpPost("{id}/transacoes")]
    public ActionResult Crebito([FromRoute] long Id, [FromBody] TransacaoRequest body)
    {
        return Ok();
    }

    [HttpGet("{id}/extrato")]
    public ActionResult<ExtratoResponse> Extrato([FromQuery] string Id)
    {
        var extrato = new ExtratoResponse();
        return Ok(extrato);
    }
}
