using Microsoft.AspNetCore.Mvc;
using Request;
using Response;
using Services;

namespace rinha_backend_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    [HttpPost("{id}/transacoes")]
    public ActionResult Crebito([FromRoute] long id, [FromBody] TransacaoRequest body)
    {
        var transacoes = new ClienteService();


        return Ok(new { transacoes = transacoes.GetTransacoes()});
    }

    // [HttpGet("{id}/extrato")]
    // public ActionResult<ExtratoResponse> Extrato([FromQuery] string Id)
    // {
    //     var extrato = new ExtratoResponse();
    //     return Ok(extrato);
    // }
}
