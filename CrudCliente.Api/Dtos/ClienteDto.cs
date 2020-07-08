using System.ComponentModel.DataAnnotations;

namespace CrudCliente.Api.Dtos
{
    public class ClienteDto
    {
        [Required(ErrorMessage="Descrição obrigatória")]
        [StringLength(30, ErrorMessage="Descrição, máximo de 30 caracteres")]
        public string Nome { get; set; } 
    }
}