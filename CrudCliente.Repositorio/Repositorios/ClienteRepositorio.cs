using System.Collections.Generic;
using System.Threading.Tasks;
using CrudCliente.Dominio.Entidade;
using CrudCliente.Dominio.IBaseRepositorio;
using CrudCliente.Repositorio.Context;

namespace CrudCliente.Repositorio.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
       
        void IClienteRepositorio.Adicionar(Cliente entity)
        {
            throw new System.NotImplementedException();
        }

        void IClienteRepositorio.Atualizar(Cliente entity)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Cliente>> IClienteRepositorio.Obter(Cliente entity)
        {
           var sql = "SELECT * FROM DBO.CLIENTE";
           if (entity != null){
                sql +=" Where";
                if (entity.Id > 0){
                    sql +=" Id = " + entity.Id.ToString() + " AND "; 
                }
                if (!string.IsNullOrEmpty(entity.CPF )){
                    sql +=" CPF = " + entity.CPF + " AND "; 
                }
                if (!string.IsNullOrEmpty(entity.Nome)){
                    sql +=" Nome = " + entity.Nome + " AND "; 
                }
                

                
           }
           

            throw new System.NotImplementedException();
        }

        void IClienteRepositorio.Remover(Cliente entity)
        {
            throw new System.NotImplementedException();
        }
    }
}