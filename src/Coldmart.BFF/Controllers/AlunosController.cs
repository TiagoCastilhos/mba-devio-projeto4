using Coldmart.BFF.Services.Interfaces;
using Coldmart.BFF.ViewModels;
using Coldmart.Core.Controllers;
using Coldmart.Core.Notificacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coldmart.BFF.Controllers;


[ApiController, Authorize]
[Route("api/[controller]")]
public class AlunosController : CustomControllerBase
{
    private readonly IAlunoService _alunoService;

    public AlunosController(IAlunoService alunoService, INotificador notificador) : base(notificador)
    {
        _alunoService = alunoService;
    }

    [HttpPost("cursos")]
    public async Task<IActionResult> MatricularAoCurso([FromBody] MatriculaViewModel viewModel)
    {
        var response = await _alunoService.MatricularAoCurso(viewModel);
        return CustomResponse(response);
    }

    [HttpPut("cursos/aulas")]
    public async Task<IActionResult> RealizarAula([FromBody] RealizarAulaViewModel viewModel)
    {
        var response = await _alunoService.RealizarAula(viewModel);
        return CustomResponse(response);
    }
}
