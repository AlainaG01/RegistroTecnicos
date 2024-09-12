using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Trabajos
{
    [Key]
    public int TrabajoId { get; set; }

    [Required(ErrorMessage ="Campo obligatorio")]
    public DateTime Fecha {  get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten letras")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se permiten numeros enteros o decimales")]
    public double Monto { get; set; }

    [ForeignKey("Clientes")]
    public int ClienteId { get; set; }
    public Clientes Cliente { get; set; }

    [ForeignKey("Tecnicos")]
    public int TecnicoId { get; set; }
    public Tecnicos Tecnico { get; set; }
}
