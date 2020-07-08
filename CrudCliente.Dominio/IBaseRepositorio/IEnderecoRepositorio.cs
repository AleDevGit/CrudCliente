using System.Collections.Generic;
using System.Threading.Tasks;
using CrudCliente.Dominio.Entidade;

namespace CrudCliente.Dominio.IBaseRepositorio
{
    public interface IEnderecoRepositorio
    {
        void Adicionar(Endereco entity);        
        Task<IEnumerable<Endereco>> Obter(Endereco entity);
        void Atualizar(Endereco entity);
        void Remover(Endereco entity);
    }
}