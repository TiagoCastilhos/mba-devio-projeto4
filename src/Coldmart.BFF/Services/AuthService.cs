using Coldmart.BFF.Models;
using Coldmart.BFF.Services.Interfaces;
using Coldmart.BFF.ViewModels;
using Microsoft.Extensions.Options;

namespace Coldmart.BFF.Services;

public partial class AuthService : Service, IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(settings.Value.AuthServiceUrl);
    }

    public async Task<LogarResponseViewModel?> Logar(LogarViewModel viewModel)
    {
        var authContent = ObterConteudo(viewModel);
        var response = await _httpClient.PostAsync("api/auth/login", authContent);
        var result = await DeserializarObjetoResponse<LogarResponseViewModel>(response);
        return result;
    }
}
