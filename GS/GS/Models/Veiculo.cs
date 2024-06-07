using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GS.Models.Comum;

namespace GS.Models;

[Table("GS_Veiculo")]
public class Veiculo: IModel
{
    [Key]
    public int Tie { get; set; }
    [Required, MaxLength(50)]
    public string? Nome { get; set; }
    [Required, MaxLength(50)]
    public string? Tipo { get; set; }
    [Required, MaxLength(50), DisplayName("Tipo do Motor")]
    public string? TipoMotor { get; set; }
    public int Sonar { get; set; }
    [ForeignKey("Empresa"), DisplayName("Empresa")]
    public int EmpresaId { get; set; }
    [MaxLength(100), DisplayName("Link da Imagem")]
    public string? LinkImagem { get; set; }
    
    public virtual Empresa? Empresa { get; set; }
    public virtual ICollection<Vistoria>? Vistorias { get; set; }
}