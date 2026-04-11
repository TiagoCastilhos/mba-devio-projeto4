using System.ComponentModel.DataAnnotations;

namespace Coldmart.BFF.ViewModels;

public class RealizarAulaViewModel
{
    [Required]
    public Guid AulaId { get; set; }
}
