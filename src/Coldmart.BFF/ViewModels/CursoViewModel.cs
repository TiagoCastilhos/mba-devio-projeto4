using System.ComponentModel.DataAnnotations;

namespace Coldmart.BFF.ViewModels;

public sealed class CursoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public List<ConteudoProgramaticoViewModel> ConteudosProgramaticos { get; set; }
}
