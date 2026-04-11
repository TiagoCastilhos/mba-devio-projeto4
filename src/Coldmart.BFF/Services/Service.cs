using Coldmart.Core.Communication;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Coldmart.BFF.Services;

public abstract class Service
{
    protected StringContent ObterConteudo(object dado)
    {
        return new StringContent(
            JsonSerializer.Serialize(dado),
            Encoding.UTF8,
            "application/json");
    }

    protected bool TratarErrosResponse(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.BadRequest) return false;

        response.EnsureSuccessStatusCode();
        return true;
    }

    protected async Task<T?> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var content = await responseMessage.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(content))
        {
            return default(T);
        }

        var response = JsonSerializer.Deserialize<T>(content, options);

        return response;
    }

    protected ResponseResult RetornoOk()
    {
        return new ResponseResult();
    }
}
