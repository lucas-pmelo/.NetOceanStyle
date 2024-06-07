using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GS.Models.Comum;

namespace GS.Models;

[Table("GS_Empresa")]
public class Empresa: IModel
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(11)]
    public string? Cnpj { get; set; }
    [Required, MaxLength(50)]
    public string? Nome { get; set; }
    [MaxLength(11)]
    public string? Telefone { get; set; }
    [MaxLength(50)]
    public string? Email { get; set; }
    
    public virtual ICollection<Veiculo>? Veiculos { get; set; }
    public virtual ICollection<Endereco>? Enderecos { get; set; }
}