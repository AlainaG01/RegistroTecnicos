using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class PrioridadesService
{
    private readonly Contexto _contexto;

    public PrioridadesService(Contexto contexto)
    {
        _contexto = contexto;
    }

    private async Task<bool> Existe(int prioridadId)
    {
        return await _contexto.Prioridades.AnyAsync(e => e.PrioridadesId == prioridadId);
    }

    private async Task<bool> Insertar(Prioridades prioridad)
    {
        _contexto.Prioridades.Add(prioridad);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prioridades prioridad)
    {
        _contexto.Update(prioridad);
        var modificado = await _contexto.SaveChangesAsync() > 0;
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
        return await _contexto.Prioridades
            .Where(e => e.PrioridadesId == prioridadId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Prioridades> Buscar(int id)
    {
        return await _contexto.Prioridades.FirstOrDefaultAsync(e => e.PrioridadesId == id);
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
    {
        return await _contexto.Prioridades.AsNoTracking().Where(criterio).ToListAsync();
    }

    public async Task<bool> ExistePrioridad(int id, int tiempo, string descripcion)
    {
        return await _contexto.Prioridades
            .AnyAsync(e => e.PrioridadesId != id && e.Tiempo == tiempo && e.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }
}
