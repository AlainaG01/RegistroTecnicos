using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    public string? Nombre { get; set; }
    public double? SueldoHora { get; set; }
}
