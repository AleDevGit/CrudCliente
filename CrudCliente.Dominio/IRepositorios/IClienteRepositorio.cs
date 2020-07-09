using System.Collections.Generic;
using System.Threading.Tasks;
using CrudCliente.Dominio.Entidade;

namespace CrudCliente.Dominio.IRepositorios
{
    public interface IClienteRepositorio 
    {  
        Task<Cliente[]> ObterTodos();
        Task<Cliente[]> ObterPorNome(string nome);
        Task<Cliente> ObterPorId(int id);
        Task<Cliente> ObterPorCPF(string cpf);

        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(Cliente cliente);
     
     
    }
}