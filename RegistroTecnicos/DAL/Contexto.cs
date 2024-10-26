using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Tecnicos> Tecnicos { get; set; }
    public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Trabajos> Trabajos { get; set; }
    public DbSet<Prioridades> Prioridades { get; set; }
    public DbSet<Articulos> Articulos { get; set; }
    public DbSet<TrabajosDetalle> TrabajosDetalle { get; set; }
    public DbSet<Cotizaciones> Cotizaciones { get; set; }
    public DbSet<CotizacionesDetalle> CotizacionesDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
        {
            new Articulos(){ArticuloId=1, Descripcion= "Pasta Termica", Costo= 100, Precio= 165, Existencia= 50},
            new Articulos(){ArticuloId=2, Descripcion="Cable de par trenzado", Costo= 225, Precio= 275, Existencia= 50},
            new Articulos(){ArticuloId=3, Descripcion="Conector RJ45", Costo= 25, Precio= 35, Existencia= 50},
            new Articulos(){ArticuloId=4, Descripcion="MiniJack RJ45", Costo= 30, Precio= 38, Existencia= 50 }
        });
    }
}
