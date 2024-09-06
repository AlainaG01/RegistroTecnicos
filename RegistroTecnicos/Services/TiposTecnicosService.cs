using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TiposTecnicosService(Contexto contexto)
{
    private readonly Contexto _contexto = contexto;

    private async Task<bool> Existe(int tiposTecnicosId)
    {
        return await _contexto.TiposTecnicos.AnyAsync(e => e.TiposTecnicosId == tiposTecnicosId);
    }

    private async Task<bool> Insertar(TiposTecnicos tiposTecnicos)
    {
        _contexto.TiposTecnicos.Add(tiposTecnicos);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(TiposTecnicos tiposTecnicos)
    {
        _contexto.Update(tiposTecnicos);
        var modificado = await _contexto.SaveChangesAsync() > 0;
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
        return await _contexto.TiposTecnicos.Where(e => e.TiposTecnicosId == tipoTecnicoId).ExecuteDeleteAsync() > 0;
    }

    public async Task<TiposTecnicos> Buscar(int id)
    {
        return await _contexto.TiposTecnicos.AsNoTracking().FirstOrDefaultAsync(e => e.TiposTecnicosId == id);
    }

    public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
    {
        return await _contexto.TiposTecnicos.AsNoTracking().Where(criterio).ToListAsync();
    }

    public async Task<bool> ExisteTipo(int id, string descripcion)
    {
        return await _contexto.TiposTecnicos.AnyAsync(e => e.TiposTecnicosId != id && e.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }
}
