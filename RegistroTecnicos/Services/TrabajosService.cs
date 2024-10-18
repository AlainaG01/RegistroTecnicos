using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Runtime.InteropServices;

namespace RegistroTecnicos.Services;

public class TrabajosService
{
    private readonly Contexto _contexto;

    public TrabajosService(Contexto contexto)
    {
        _contexto = contexto;
    }

    private async Task<bool> Existe(int trabajoId)
    {
        return await _contexto.Trabajos.AnyAsync(e => e.TrabajoId == trabajoId);
    }

    private async Task<bool> Insertar(Trabajos trabajo)
    {
        _contexto.Trabajos.Add(trabajo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Trabajos trabajo)
    {
        _contexto.Update(trabajo);
        var modificado = await _contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    public async Task<bool> Guardar(Trabajos trabajo)
    {
        if (!await Existe(trabajo.TrabajoId))
            return await Insertar(trabajo);
        else
            return await Modificar(trabajo);
    }

    public async Task<bool> Eliminar(int trabajoId)
    {
        return await _contexto.Trabajos
            .Include(t => t.TrabajosDetalle)
            .Where(e => e.TrabajoId == trabajoId)
            .ExecuteDeleteAsync() > 0;
    }
    public async Task<Trabajos> Buscar(int id)
    {
        return await _contexto.Trabajos
            .Include(e => e.Tecnico).Include(e => e.Cliente)
            .Include(e => e.Prioridad)
            .Include(t => t.TrabajosDetalle)
            .AsNoTracking()
           .FirstOrDefaultAsync(e => e.TrabajoId == id);
    }

    public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
    {
        return await _contexto.Trabajos.Include(e => e.Tecnico)
            .Include(e => e.Cliente)
            .Include(e => e.Prioridad)
            .Include(t => t.TrabajosDetalle)
            .AsNoTracking().Where(criterio).ToListAsync();
    }

    public async Task<bool> ExisteTrabajo(int trabajoId)
    {
        return await _contexto.Trabajos
            .AnyAsync(e => e.TrabajoId == trabajoId);
    }
    

}