using Coldmart.BFF.Services.Interfaces;
using Coldmart.BFF.ViewModels;
using Coldmart.Core.Controllers;
using Coldmart.Core.Notificacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coldmart.BFF.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class CursosController : CustomControllerBase
{
    private readonly ICursoService _cursoService;

    public CursosController(ICursoService cursoService, INotificador notificador) : base(notificador)
    {
        _cursoService = cursoService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CriarCursoAsync([FromBody] CursoViewModel viewModel)
    {
        var response = await _cursoService.CriarCursoAsync(viewModel);
        return CustomResponse(response);
    }

    [HttpPost("aulas")]
    public async Task<IActionResult> AdicionarAulaAsync([FromBody] AulaViewModel viewModel)
    {
        var response = await _cursoService.AdicionarAulaAsync(viewModel);
        return CustomResponse(response);
    }
}
