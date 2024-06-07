using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GS.Models.Comum;

namespace GS.Models;

[Table("GS_Cidade")]
public class Cidade: IModel
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string? Nome { get; set; }
    [ForeignKey("Estado"), DisplayName("Estado")]
    public int EstadoId { get; set; }
    
    public virtual Estado? Estado { get; set; }
    public virtual ICollection<Endereco>? Enderecos { get; set; }
}