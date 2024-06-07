using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GS.Models.Comum;

namespace GS.Models;

[Table("GS_Inspetores_Vistorias")]
public class InspetoresVistorias: IModel
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Inspetor"), DisplayName("Inspetor")]
    public int InspetorId { get; set; }
    [ForeignKey("Vistoria"), DisplayName("Id da vistoria")]
    public int VistoriaId { get; set; }
    
    public virtual Inspetor? Inspetor { get; set; }
    public virtual Vistoria? Vistoria { get; set; }
}