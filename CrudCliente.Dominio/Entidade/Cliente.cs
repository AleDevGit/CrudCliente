using System;
using System.Collections.Generic;

namespace CrudCliente.Dominio.Entidade
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public string CPF { get; set; }
         public DateTime DataNascimento { get; set; }
         public List<Endereco> Enderecos  { get; set; }


    }
}