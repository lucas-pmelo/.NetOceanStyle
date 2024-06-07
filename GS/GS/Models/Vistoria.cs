using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GS.Models.Comum;
using Microsoft.EntityFrameworkCore;

namespace GS.Models;

[Table("GS_Vistoria")]
public class Vistoria: IModel
{
    [Key, DisplayName("Id da Vistoria")]
    public int Id { get; set; }
    [Required, DisplayName("Data da Vistoria")]
    public DateOnly Data { get; set; }
    [Required, DisplayName("Nivel do Ruido")]
    public int NivelRuido { get; set; }
    [Required, MaxLength(30)]
    public string? Resultado { get; set; }
    [MaxLength(100)]
    public string? Observacoes { get; set; }
    
    [ForeignKey("Veiculo"), DisplayName("TIE do Veiculo")]
    public int VeiculoId { get; set; }
    
    public virtual Veiculo? Veiculo { get; set; }
    public virtual ICollection<InspetoresVistorias>? InspetoresVistorias { get; set; }
}