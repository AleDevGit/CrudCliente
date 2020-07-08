using System;

namespace CrudCliente.Dominio.IBaseRepositorio
{
    public interface IBaseRepositorio<TEntity>:IDisposable where TEntity : class
    {
        
    }
}