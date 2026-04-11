using System.ComponentModel.DataAnnotations;

namespace Coldmart.BFF.ViewModels;

public class AlterarStatusPagamentoViewModel
{
    [Required]
    public Guid PagamentoId { get; set; }
}