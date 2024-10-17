using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TrabajosDetalleService
{
    private readonly Contexto _contexto;

    public TrabajosDetalleService(Contexto contexto)
    {
        _contexto = contexto;
    }

    
}
