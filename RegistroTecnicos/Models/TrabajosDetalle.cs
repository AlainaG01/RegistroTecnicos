using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class TrabajosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("TrabajoId")]
    public int TrabajoId { get; set; }
    public Trabajos? Trabajo { get; set; }

    [ForeignKey("ArticuloId")]
    public int ArticuloId { get; set; }
    public Articulos? Articulo { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Precio { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Costo { get; set; }
}
