using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TiposTecnicosService(IDbContextFactory<Contexto> DbFactory)
{

    private async Task<bool> Existe(int tiposTecnicosId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposTecnicos.AnyAsync(e => e.TiposTecnicosId == tiposTecnicosId);
    }

    private async Task<bool> Insertar(TiposTecnicos tiposTecnicos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposTecnicos.Add(tiposTecnicos);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(TiposTecnicos tiposTecnicos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(tiposTecnicos);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    public async Task<bool> Guardar(TiposTecnicos tiposTecnicos)
    {
        if (!await Existe(tiposTecnicos.TiposTecnicosId))
            return await Insertar(tiposTecnicos);
        else
            return await Modificar(tiposTecnicos);
    }

    public async Task<bool> Eliminar(int tipoTecnicoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposTecnicos
            .Where(e => e.TiposTecnicosId == tipoTecnicoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<TiposTecnicos> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposTecnicos
            .FirstOrDefaultAsync(e => e.TiposTecnicosId == id);
    }

    public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposTecnicos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> ExisteTipo(int id, string descripcion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposTecnicos
            .AnyAsync(e => e.TiposTecnicosId != id 
            && e.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }
}
