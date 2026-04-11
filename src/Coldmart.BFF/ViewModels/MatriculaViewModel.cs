using System.ComponentModel.DataAnnotations;

namespace Coldmart.BFF.ViewModels;

public class MatriculaViewModel
{
    [Required]
    public Guid CursoId { get; set; }
}
