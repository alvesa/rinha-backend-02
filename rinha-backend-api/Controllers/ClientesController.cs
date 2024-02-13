using Microsoft.AspNetCore.Mvc;
using Controllers.Request;
using Response;
using Services;
using rinha_backend_api.IoC.Services;
using rinha_backend_api.Controllers.Response;

namespace rinha_backend_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{

    private readonly IAccountService _accountService;
    private readonly IExtratoService _extratoService;

    public ClientesController(IAccountService accountService, IExtratoService extratoService)
    {
        _accountService = accountService;
        _extratoService = extratoService;
    }

    [HttpPost("{id}/transacoes")]
    public ActionResult Crebito([FromRoute] int id, [FromBody] TransacaoRequest body)
    {

        if(!ModelState.IsValid) {
            return BadRequest();
        }

        return Ok(_accountService.MakeTransacao(id, body));
    }

    [HttpGet("{id}/extrato")]
    public ActionResult<ExtratoResponse> Extrato([FromRoute] int Id)
    {
        return Ok(_extratoService.List(Id));
    }
}
