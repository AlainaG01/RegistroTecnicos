using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class CotizacionesDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("Cotizaciones")]
    public int CotizacionId { get; set; }
    public Cotizaciones? Cotizacion { get; set; }

    [ForeignKey("Articulos")]
    public int ArticuloId { get; set; }
    public Articulos? Articulo { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Precio {  get; set; }
}
