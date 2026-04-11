using System.ComponentModel.DataAnnotations;

namespace Coldmart.BFF.ViewModels;

public sealed class CursoViewModel
{
    [Required]
    [Length(2, 60)]
    public string Nome { get; set; }

    [Required]
    [MinLength(1)]
    public List<ConteudoProgramaticoViewModel> ConteudosProgramaticos { get; set; }
}
