using System.Collections.Generic;
using System.Threading.Tasks;
using CrudCliente.Dominio.Entidade;
using CrudCliente.Dominio.IBaseRepositorio;
using CrudCliente.Repositorio.Context;

namespace CrudCliente.Repositorio.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
     
        void IEnderecoRepositorio.Adicionar(Endereco entity)
        {
            throw new System.NotImplementedException();
        }

        void IEnderecoRepositorio.Atualizar(Endereco entity)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Endereco>> IEnderecoRepositorio.Obter(Endereco entity)
        {
            throw new System.NotImplementedException();
        }

        void IEnderecoRepositorio.Remover(Endereco entity)
        {
            throw new System.NotImplementedException();
        }
    }
}