using Microsoft.AspNetCore.Http;

namespace Coldmart.Core.Contexts;

public interface IUsuarioContext
{
    Guid? ObterIdUsuario();
    HttpContext ObterHttpContext();
    string ObterUserToken();
}
