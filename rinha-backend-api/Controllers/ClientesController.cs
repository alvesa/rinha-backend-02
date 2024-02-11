using Microsoft.AspNetCore.Mvc;
using Controllers.Request;
using Response;
using Services;
using rinha_backend_api.IoC.Services;

namespace rinha_backend_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{

    private readonly IAccountService _accountService;

    public ClientesController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("{id}/transacoes")]
    public ActionResult Crebito([FromRoute] int id, [FromBody] TransacaoRequest body)
    {

        if(!ModelState.IsValid) {
            return BadRequest();
        }

        return Ok(_accountService.MakeTransacao(id, body));
    }

    // [HttpGet("{id}/extrato")]
    // public ActionResult<ExtratoResponse> Extrato([FromQuery] string Id)
    // {
    //     var extrato = new ExtratoResponse();
    //     return Ok(extrato);
    // }
}
