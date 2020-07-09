using System.Collections.Generic;
using System.Threading.Tasks;
using CrudCliente.Dominio.Entidade;

namespace CrudCliente.Dominio.IRepositorios
{
    public interface IEnderecoRepositorio
    {
        Task<Endereco[]> ObterTodos();
        Task<Endereco> ObterPorId(int id);
        void Adicionar(Endereco endereco);
        void Atualizar(Endereco endereco);
        void Remover(Endereco endereco);
    }
}