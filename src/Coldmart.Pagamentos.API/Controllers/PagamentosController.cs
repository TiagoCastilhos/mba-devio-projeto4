using Coldmart.Core.Constants;
using Coldmart.Core.Contracts;
using Coldmart.Core.Controllers;
using Coldmart.Core.Notificacao;
using Coldmart.Pagamentos.Business.Requests;
using Coldmart.Pagamentos.Business.ViewModels;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coldmart.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagamentosController : CustomControllerBase
{
    private readonly IMediator _mediator;
    private readonly IPublishEndpoint _publishEndpoint;

    public PagamentosController(IMediator mediator, IPublishEndpoint publishEndpoint, INotificador notificador)
        : base(notificador)
    {
        _mediator = mediator;
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost("")]
    [Authorize(Roles = RolesConstants.Usuario)]
    public async Task<IActionResult> CriarPagamentoAsync([FromBody] PagamentoViewModel pagamento)
    {
        await _mediator.Send(new CriarPagamentoRequest()
        {
            Pagamento = pagamento
        }, HttpContext.RequestAborted);

        return CustomResponse();
    }

    [HttpPut("{id:guid}/aprovar")]
    [Authorize(Roles = RolesConstants.Admin)]
    public async Task<IActionResult> AprovarPagamentoAsync([FromRoute] Guid id)
    {
        await _mediator.Send(new AprovarPagamentoRequest
        {
            Pagamento = new AlterarStatusPagamentoViewModel { PagamentoId = id }
        }, HttpContext.RequestAborted);

        return CustomResponse();
    }

    [HttpPut("{id:guid}/cancelar")]
    [Authorize(Roles = RolesConstants.Admin)]
    public async Task<IActionResult> CancelarPagamentoAsync([FromRoute] Guid id)
    {
        await _mediator.Send(new CancelarPagamentoRequest
        {
            Pagamento = new AlterarStatusPagamentoViewModel { PagamentoId = id }
        }, HttpContext.RequestAborted);

        return CustomResponse();
    }
}
