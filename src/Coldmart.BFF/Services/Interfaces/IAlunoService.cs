using Coldmart.BFF.ViewModels;
using Coldmart.Core.Communication;

namespace Coldmart.BFF.Services.Interfaces;

public interface IAlunoService
{
    Task<ResponseResult?> MatricularAoCurso(MatriculaViewModel viewModel);
    Task<ResponseResult?> RealizarAula(RealizarAulaViewModel viewModel);
}
