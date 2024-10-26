using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class PrioridadesService(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int prioridadId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prioridades.AnyAsync(e => e.PrioridadesId == prioridadId);
    }

    private async Task<bool> Insertar(Prioridades prioridad)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Prioridades.Add(prioridad);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prioridades prioridad)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(prioridad);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    public async Task<bool> Guardar(Prioridades prioridad)
    {
        if (!await Existe(prioridad.PrioridadesId))
        {
            return await Insertar(prioridad);
        }
        else
        {
            return await Modificar(prioridad);
        }
    }

    public async Task<bool> Eliminar(int prioridadId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prioridades
            .Where(e => e.PrioridadesId == prioridadId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Prioridades> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prioridades
            .FirstOrDefaultAsync(e => e.PrioridadesId == id);
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prioridades
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> ExistePrioridad(int id, int tiempo, string descripcion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prioridades
            .AnyAsync(e => e.PrioridadesId != id
            && e.Tiempo == tiempo 
            || e.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }
}
