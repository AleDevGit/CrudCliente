using System;
using CrudCliente.Dominio.IBaseRepositorio;
using CrudCliente.Repositorio.Context;

namespace CrudCliente.Repositorio.Repositorios
{
     public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly DataContext DataContext;

        public BaseRepositorio(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        void IDisposable.Dispose()
        {
             DataContext.Dispose();
        }
    }
}