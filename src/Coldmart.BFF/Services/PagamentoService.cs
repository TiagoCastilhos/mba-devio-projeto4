using Coldmart.BFF.Models;
using Coldmart.BFF.Services.Interfaces;
using Coldmart.BFF.ViewModels;
using Coldmart.Core.Communication;
using Microsoft.Extensions.Options;

namespace Coldmart.BFF.Services;

public class PagamentoService : Service, IPagamentoService
{
    private readonly HttpClient _httpClient;

    public PagamentoService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(settings.Value.PagamentosServiceUrl);
    }

    public async Task<ResponseResult?> CriarPagamentoAsync(PagamentoViewModel pagamento)
    {
        var pagamentoContent = ObterConteudo(pagamento);
        var response = await _httpClient.PostAsync("api/pagamentos", pagamentoContent);
        return await DeserializarObjetoResponse<ResponseResult>(response);
    }

    public async Task<ResponseResult?> AprovarPagamentoAsync(Guid id)
    {
        var pagamentoContent = ObterConteudo(id);
        var response = await _httpClient.PostAsync($"api/pagamentos/{id}/aprovar", pagamentoContent);
        return await DeserializarObjetoResponse<ResponseResult>(response);
    }

    public async Task<ResponseResult?> CancelarPagamentoAsync(Guid id)
    {
        var pagamentoContent = ObterConteudo(id);
        var response = await _httpClient.PostAsync($"api/pagamentos/{id}/cancelar", pagamentoContent);
        return await DeserializarObjetoResponse<ResponseResult>(response);
    }

    public async Task<ResponseResult?> ObterPorIdAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/pagamentos/{id}");
        return await DeserializarObjetoResponse<ResponseResult>(response);
    }
}
