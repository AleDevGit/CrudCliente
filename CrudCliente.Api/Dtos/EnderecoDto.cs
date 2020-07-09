using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudCliente.Api.Dtos
{
    public class EnderecoDto
    {
        public int Id { get; set; } 

        [Required(ErrorMessage="Logradouro obrigatório")]
        [StringLength(50, ErrorMessage="Logradouro, máximo de 50 caracteres")]
        public string Logradouro { get; set; } 

        [Required(ErrorMessage="Bairro obrigatório")]
        [StringLength(40, ErrorMessage="Bairro, máximo de 40 caracteres")]
        public string Bairro { get; set; } 

        [Required(ErrorMessage="Cidade obrigatório")]
        [StringLength(40, ErrorMessage="Cidade, máximo de 40 caracteres")]
        public string Cidade { get; set; } 

        [Required(ErrorMessage="Estado obrigatório")]
        [StringLength(40, ErrorMessage="Estado, máximo de 40 caracteres")]
        public string Estado { get; set; } 

        [Required(ErrorMessage="Id do Cliente é obrigatório")]
        [Range(1,double.PositiveInfinity, ErrorMessage="Cliente deve ser válido")]
        public int ClienteId { get; set; }
    }
}