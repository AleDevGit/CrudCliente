using System.Collections.Generic;

namespace CrudCliente.Dominio.Entidade
{
    public class Endereco
    {
         public int Id { get; set; }
         public string Logradouro{ get; set;}
         public string Bairro{ get; set;}
         public string Cidade{ get; set;} 
         public string Estado{ get; set;}
         
         public int ClienteId { get; set; }
         public Cliente Cliente { get; set; }

    }
}