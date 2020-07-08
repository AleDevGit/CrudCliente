using System.Collections.Generic;
using System.Threading.Tasks;
using CrudCliente.Dominio.Entidade;

namespace CrudCliente.Dominio.IBaseRepositorio
{
    public interface IClienteRepositorio 
    {
        void Adicionar(Cliente entity);        
        Task<IEnumerable<Cliente>> Obter(Cliente entity);
        void Atualizar(Cliente entity);
        void Remover(Cliente entity);
    }
}