using Coldmart.BFF.Services.Interfaces;
using Coldmart.BFF.ViewModels;
using Coldmart.Core.Constants;
using Coldmart.Core.Controllers;
using Coldmart.Core.Notificacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coldmart.BFF.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class PagamentosController : CustomControllerBase
{
    private readonly IPagamentoService _pagamentoService;

    public PagamentosController(IPagamentoService pagamentoService, INotificador notificador) : base(notificador)
    {
        _pagamentoService = pagamentoService;
    }

    [HttpPost("")]
    [Authorize(Roles = RolesConstants.Usuario)]
    public async Task<IActionResult> CriarPagamentoAsync([FromBody] PagamentoViewModel pagamento)
    {
        var response = await _pagamentoService.CriarPagamentoAsync(pagamento);
        return CustomResponse(response);
    }

    [HttpPut("{id:guid}/aprovar")]
    [Authorize(Roles = RolesConstants.Admin)]
    public async Task<IActionResult> AprovarPagamentoAsync([FromRoute] Guid id)
    {
        var response = await _pagamentoService.AprovarPagamentoAsync(id);
        return CustomResponse(response);
    }

    [HttpPut("{id:guid}/cancelar")]
    [Authorize(Roles = RolesConstants.Admin)]
    public async Task<IActionResult> CancelarPagamentoAsync([FromRoute] Guid id)
    {
        var response = await _pagamentoService.CancelarPagamentoAsync(id);
        return CustomResponse(response);
    }
}
