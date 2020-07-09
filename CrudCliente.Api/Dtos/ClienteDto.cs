using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CrudCliente.Api.Validation;


namespace CrudCliente.Api.Dtos
{
    public class ClienteDto
    {

        public int Id { get; set; } 

        [Required(ErrorMessage="Nome obrigatório")]
        [StringLength(30, ErrorMessage="Descrição, máximo de 30 caracteres")]
        public string Nome { get; set; } 

        [StringLength(15, ErrorMessage="CPF, máximo de 15 caracteres")]
        [Required(ErrorMessage="CPF obrigatório")]
        [ValidCPFDomain(ErrorMessage="CPF inválido")]
        public string CPF { get; set; } 
        
        [StringLength(10, ErrorMessage="CPF, máximo de 10 caracteres")]
        [Required(ErrorMessage="Data de Nascimento obrigatório")]
        public string DataNascimento { get; set; }

    }
}