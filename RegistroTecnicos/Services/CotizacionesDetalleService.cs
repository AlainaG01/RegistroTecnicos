using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class CotizacionesDetalleService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<Articulos> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Articulos.AsNoTracking().FirstOrDefaultAsync(p => p.ArticuloId == id);
    }
    public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Articulos.Where(criterio).ToListAsync();
    }
}
