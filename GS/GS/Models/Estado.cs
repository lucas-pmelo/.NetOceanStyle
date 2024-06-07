using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GS.Models.Comum;

namespace GS.Models;

[Table("GS_Estado")]
public class Estado: IModel
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string? Nome { get; set; }
    [MaxLength(2)]
    public string? Sigla { get; set; }
    
    public virtual ICollection<Cidade>? Cidades { get; set; }
}