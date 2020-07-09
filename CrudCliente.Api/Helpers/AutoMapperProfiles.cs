using AutoMapper;
using CrudCliente.Api.Dtos;
using CrudCliente.Dominio.Entidade;

namespace CrudCliente.Api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
             CreateMap<Cliente, ClienteDto>().ReverseMap();
             CreateMap<Endereco, EnderecoDto>().ReverseMap();
        }
       

    }
}