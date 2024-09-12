using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace RegistroTecnicos.Services;

public class ClientesService(Contexto contexto)
{
    private readonly Contexto _contexto = contexto;

    private async Task<bool> Existe(int clienteId)
    {
        return await _contexto.Clientes.AnyAsync(e => e.ClienteId == clienteId);
    }

    private async Task<bool> Insertar(Clientes cliente)
    {
        _contexto.Clientes.Add(cliente);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Clientes cliente)
    {
        _contexto.Clientes.Update(cliente);
        var modificado = await _contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    public async Task<bool> Guardar(Clientes cliente)
    {
        if (!await Existe(cliente.ClienteId))
            return await Insertar(cliente);
        else
            return await Modificar(cliente);
    }

    public async Task<bool> Eliminar(int clienteId)
    {
        return await _contexto.Clientes
            .Where(e => e.ClienteId == clienteId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Clientes> Buscar(int id)
    {
        return await _contexto.Clientes
            .FirstOrDefaultAsync(e => e.ClienteId == id);
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        return await _contexto.Clientes
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> ExisteCliente(int clienteId, string nombres)
    {
        return await _contexto.Clientes
            .AnyAsync(e => e.ClienteId != clienteId 
            && e.Nombres.ToLower().Equals(nombres.ToLower()));
    }
}
