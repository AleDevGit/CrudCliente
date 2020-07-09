using System.ComponentModel.DataAnnotations;

namespace CrudCliente.Api.Dtos
{
    public class EnderecoDto
    {
        [Required(ErrorMessage="Logradouro obrigatória")]
        [StringLength(50, ErrorMessage="Logradouro, máximo de 50 caracteres")]
        public string Logradouro { get; set; } 

        [Required(ErrorMessage="Bairro obrigatória")]
        [StringLength(40, ErrorMessage="Bairro, máximo de 40 caracteres")]
        public string Bairro { get; set; } 

        [Required(ErrorMessage="Cidade obrigatória")]
        [StringLength(40, ErrorMessage="Cidade, máximo de 40 caracteres")]
        public string Cidade { get; set; } 

        [Required(ErrorMessage="Estado obrigatória")]
        [StringLength(40, ErrorMessage="Estado, máximo de 40 caracteres")]
        public string Estado { get; set; } 
    }
}