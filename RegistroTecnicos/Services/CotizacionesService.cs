using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class CotizacionesService(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int cotizacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Cotizaciones.AnyAsync(c => c.CotizacionId == cotizacionId);
    }

    private async Task<bool> Insertar(Cotizaciones cotizacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Cotizaciones.Add(cotizacion);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Cotizaciones cotizacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Cotizaciones.Update(cotizacion);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    public async Task<bool> Guardar(Cotizaciones cotizacion)
    {
        if (!await Existe(cotizacion.CotizacionId))
            return await Insertar(cotizacion);
        else
            return await Modificar(cotizacion);
    }

    public async Task<bool> Eliminar(int cotizacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Cotizaciones
            .Where(c => c.CotizacionId == cotizacionId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Cotizaciones> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Cotizaciones
            .FirstOrDefaultAsync(c => c.CotizacionId == id);
    }

    public async Task<List<Cotizaciones>> Listar(Expression<Func<Cotizaciones, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Cotizaciones
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
