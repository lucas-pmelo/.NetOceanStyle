using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GS.Models.Comum;

namespace GS.Models;

[Table("GS_Endereco")]
public class Endereco: IModel
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string? Rua { get; set; }
    [Required]
    public int Numero { get; set; }
    [Required, MaxLength(11)]
    public string? Cep { get; set; }
    [ForeignKey("Cidade"), DisplayName("Cidade")]
    public int CidadeId { get; set; }
    [ForeignKey("Empresa"), DisplayName("Empresa")]
    public int EmpresaId { get; set; }
    
    public virtual Cidade? Cidade { get; set; }
    public virtual Empresa? Empresa { get; set; }
}