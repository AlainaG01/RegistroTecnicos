using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TecnicosService
{
    private readonly Contexto _contexto;

    public TecnicosService(Contexto contexto)
    {
        _contexto = contexto;
    }

    private async Task<bool> Existe(int tecnicoId)
    {
        return await _contexto.Tecnicos.AnyAsync(e => e.TecnicoId ==  tecnicoId);
    }

    private async Task<bool> Insertar(Tecnicos tecnico)
    {
        _contexto.Tecnicos.Add(tecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Tecnicos tecnico)
    {
        _contexto.Update(tecnico);
        var modificado = await _contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        if (!await Existe(tecnico.TecnicoId))
            return await Insertar(tecnico);
        else
            return await Modificar(tecnico);
    }

    public async Task<bool> Eliminar(int tecnicoId)
    {
        return await _contexto.Tecnicos.
            Where(e => e.TecnicoId == tecnicoId).ExecuteDeleteAsync() > 0;
    }

    public async Task<Tecnicos> Buscar(int id)
    {
        return await _contexto.Tecnicos
            .FirstOrDefaultAsync(e => e.TecnicoId == id);
    }

    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        return await _contexto.Tecnicos.AsNoTracking().Where(criterio).ToListAsync();
    }

    public async Task<bool> ExisteTecnico(int tecnicoId, string nombres)
    {
        return await _contexto.Tecnicos.AnyAsync(e => e.TecnicoId != tecnicoId
        && e.Nombres.ToLower().Equals(nombres.ToLower()));
    }
}
 