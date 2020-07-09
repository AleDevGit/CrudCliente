using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCliente.Dominio.Entidade;
using CrudCliente.Dominio.IRepositorios;
using CrudCliente.Repositorio.Context;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace CrudCliente.Repositorio.Repositorios
{
    public class ClienteRepositorio : BaseQueryRepository, IClienteRepositorio 
    {
      
        public async Task<Cliente[]> ObterTodos()
        {
            var selectQuery = "SELECT * FROM CLIENTES";

            SqliteConnection open = OpenDB();
            var result = await open.QueryAsync<Cliente>(selectQuery.Replace("''","NULL"));
            
            return result.ToArray();  
        }
         

       public async Task<Cliente[]> ObterPorNome(string nome){
            var selectQuery = $"SELECT * FROM CLIENTES WHERE NOME LIKE '{nome}%'";

            SqliteConnection open = OpenDB();
            var result = await open.QueryAsync<Cliente>(selectQuery.Replace("''","NULL"));
            
            return result.ToArray();
       }
       public async Task<Cliente> ObterPorId(int id)
       {
           var selectQuery = $"SELECT * FROM CLIENTES WHERE ID = {id}";

            SqliteConnection open = OpenDB();
            var result = await open.QueryAsync<Cliente>(selectQuery.Replace("''","NULL"));

            return result.FirstOrDefault();     
       }

       public async Task<Cliente> ObterPorCPF(string cpf)
       {
            var selectQuery = $"SELECT * FROM CLIENTES WHERE CPF = '{cpf}'";

            SqliteConnection open = OpenDB();
            var result = await open.QueryAsync<Cliente>(selectQuery.Replace("''","NULL"));

            return result.FirstOrDefault();  
        }

        public void Adicionar(Cliente cliente)
        {
            var insertQuery = $@"INSERT INTO CLIENTES 
                                    (NOME, CPF, DATANASCIMENTO) 
                                VALUES 
                                    ('{cliente.Nome}', '{cliente.CPF}', '{cliente.DataNascimento}')";
            
            ExecutarComando(insertQuery);                 
        }

        public void Atualizar(Cliente cliente)
        {
            string updateQuery = $@"
                UPDATE CLIENTES
                   SET 
                      Nome = '{cliente.Nome}', CPF = '{cliente.CPF}'
                      , DataNascimento = '{cliente.DataNascimento}' 
                 WHERE Id = {cliente.Id}";

			ExecutarComando(updateQuery);
        }

        public void Remover(Cliente cliente)
        {
             string deleteQuery = $@"
                DELETE FROM CLIENTES
                    WHERE Id = {cliente.Id}";

			ExecutarComando(deleteQuery);
        }
    }
}