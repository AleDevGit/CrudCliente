using System;
using System.Configuration;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CrudCliente.Repositorio.Repositorios
{
    public class BaseQueryRepository
    {
         const string myConnectString = "Data Source=CrudCliente.db;";

        protected void ExecutarComando(string comando, DynamicParameters parameters = null, bool interromperProcessamentoEmCasoDeErro = false)
        {
                try
                {
                    SqliteConnection conn = OpenDB();
                    var result = conn.Execute(comando, parameters);
                }
                catch (SqliteException  ex)
                {
                   throw ex;
                }
        }
        public static SqliteConnection OpenDB()
        {
            try
            {
                var conn = new SqliteConnection(myConnectString);
                conn.Open();
                return conn;
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }
    }
}