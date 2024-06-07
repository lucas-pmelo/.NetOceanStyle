using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GS.Models.Comum;

namespace GS.Models;

[Table("GS_Inspetor")]
public class Inspetor: IModel
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(11)]
    public string? Rg { get; set; }
    [Required, MaxLength(50)]
    public string? Nome { get; set; }
    [Required, MaxLength(50)]
    public string? Especializacao { get; set; }
    [MaxLength(11)]
    public string? Telefone { get; set; }
    
    public virtual ICollection<InspetoresVistorias>? InspetoresVistorias { get; set; }
}