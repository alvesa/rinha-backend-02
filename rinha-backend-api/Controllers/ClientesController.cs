using Microsoft.AspNetCore.Mvc;
using Controllers.Request;
using rinha_backend_api.IoC.Services;
using rinha_backend_api.Controllers.Response;

namespace rinha_backend_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{

    private readonly IClientesServico _accountService;
    private readonly IExtratoServico _extratoService;

    public ClientesController(IClientesServico accountService, IExtratoServico extratoService)
    {
        _accountService = accountService;
        _extratoService = extratoService;
    }

    [HttpPost("{id}/transacoes")]
    public async Task<IActionResult> Crebito([FromRoute] int id, [FromBody] TransacaoRequisicao body)
    {

        if(!ModelState.IsValid) {
            return BadRequest();
        }

        var transacao = await _accountService.FazerTransacao(id, body);

        return Ok(transacao);
    }

    [HttpGet("{id}/extrato")]
    public ActionResult<ExtratoResposta> Extrato([FromRoute] int Id)
    {
        return Ok(_extratoService.List(Id));
    }
}
