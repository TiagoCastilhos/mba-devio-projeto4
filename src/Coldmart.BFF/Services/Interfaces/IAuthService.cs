using Coldmart.BFF.ViewModels;
using static Coldmart.BFF.Services.AuthService;

namespace Coldmart.BFF.Services.Interfaces;

public interface IAuthService
{
    Task<LogarResponseViewModel?> Logar(LogarViewModel viewModel);
}
