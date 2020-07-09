using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCliente.Dominio.Entidade;
using CrudCliente.Dominio.IRepositorios;
using CrudCliente.Repositorio.Context;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CrudCliente.Repositorio.Repositorios
{
    public class EnderecoRepositorio : BaseQueryRepository, IEnderecoRepositorio
    {
     
       public async Task<Endereco[]> ObterTodos()
        {
            var selectQuery = $@"SELECT ID, LOGRADOURO, BAIRRO, CIDADE, ESTADO, CLIENTEID FROM ENDERECOS";
            SqliteConnection open = OpenDB();
            var result = await open.QueryAsync<Endereco>(selectQuery);
            
            return result.ToArray();  
        }

        public async Task<Endereco> ObterPorId(int id)
        {
           var selectQuery = $"SELECT * FROM ENDERECOS WHERE ID = {id}";

            SqliteConnection open = OpenDB();
            var result = await open.QueryAsync<Endereco>(selectQuery.Replace("''","NULL"));

            return result.FirstOrDefault();     
        }

        public void Adicionar(Endereco endereco)
        {
             var insertQuery = $@"INSERT INTO ENDERECOS 
                                    (LOGRADOURO, BAIRRO, CIDADE, ESTADO, CLIENTEID) 
                                VALUES 
                                    ('{endereco.Logradouro}', '{endereco.Bairro}', 
                                    '{endereco.Cidade}', '{endereco.Estado}', {endereco.ClienteId})";
            
            ExecutarComando(insertQuery);      
        }



        public void Atualizar(Endereco endereco)
        {
             string updateQuery = $@"
                UPDATE ENDERECOS
                   SET 
                      LOGRADOURO = '{endereco.Logradouro}', BAIRRO = '{endereco.Bairro}'
                      , CIDADE = '{endereco.Cidade}', ESTADO = '{endereco.Estado}' 
                 WHERE Id = {endereco.Id}";

			ExecutarComando(updateQuery);
        }



        public void Remover(Endereco endereco)
        {
            string deleteQuery = $@"
                DELETE FROM ENDERECOS
                    WHERE Id = {endereco.Id}";

			ExecutarComando(deleteQuery);
        }


    }
}