using Coldmart.Pagamentos.Business.ViewModels;

namespace Coldmart.Pagamentos.Business.Services;

public interface IPagamentoQueries
{
    Task<IEnumerable<PagamentoViewModel>> ObterTodos();
    Task<PagamentoViewModel> ObterPorId(Guid id);
}