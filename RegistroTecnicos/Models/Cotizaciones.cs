using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Cotizaciones
{
    [Key]
    public int CotizacionId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }
    public Clientes Cliente { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten letras")]
    public string? Observacion { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Monto { get; set; }

    [ForeignKey("CotizacionId")]
    public ICollection<CotizacionesDetalle> cotizacionesDetalle { get; set; } = new List<CotizacionesDetalle>();

}
