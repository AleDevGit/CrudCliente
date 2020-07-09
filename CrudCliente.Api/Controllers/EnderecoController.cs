using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCliente.Dominio.IRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudCliente.Api.Dtos;
using AutoMapper;
using CrudCliente.Dominio.Entidade;

namespace CrudCliente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        public  readonly IMapper _mapper;
        public EnderecoController(IEnderecoRepositorio enderecoRepositorio, IMapper mapper,
         IClienteRepositorio clienteRepositorio)
        {
            _mapper = mapper;
            _enderecoRepositorio = enderecoRepositorio;
            _clienteRepositorio = clienteRepositorio;
            
        }

        [Route("v1/obtertodos")]
        [HttpGet]
        public  async Task<ActionResult> Obtertodos()
        {
            try
            {
                var enderecos = await _enderecoRepositorio.ObterTodos();
                var results = _mapper.Map<EnderecoDto[]>(enderecos);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou {ex.Message}");
            }
        }

        [Route("v1/obterporid/{EnderecoId}")]
        [HttpGet]
        public  async Task<ActionResult> ObterPorId(int EnderecoId)
        {
            try
            {
                var enderecos = await _enderecoRepositorio.ObterPorId(EnderecoId);
                var results = _mapper.Map<EnderecoDto>(enderecos);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou {ex.Message}");
            }
        }

        [Route("v1/cadastrar")]
        [HttpPost]
        public async Task<IActionResult> CadastrarAsync(EnderecoDto enderecoModel)
        {
            try
            {
                var endereco = _mapper.Map<Endereco>(enderecoModel);
                var existe = await _clienteRepositorio.ObterPorId(endereco.ClienteId);
                if (existe == null){
                    BadRequest("Cliente não encontrado");
                } 
                _enderecoRepositorio.Adicionar(endereco);

                return Created($"api/obterporid/{endereco.Id}", _mapper.Map<EnderecoDto>(endereco));
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou {ex.Message}");
            }
        }

        [Route("v1/alterar/{EnderecoId}")]
        [HttpPut]
        public async Task<IActionResult> AlterarAsync(int enderecoId, EnderecoDto enderecoModel)
        {
            try
            {
                var endereco = await _enderecoRepositorio.ObterPorId(enderecoId);
                
                if (endereco == null) return NotFound();

                _mapper.Map(enderecoModel, endereco);
                _enderecoRepositorio.Atualizar(endereco);
                
                return Created($"api/obterporid/{endereco.Id}", _mapper.Map<EnderecoDto>(endereco));
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou{ ex.Message }" );
            }
        }

        [Route("v1/excluir/{EnderecoId}")]
        [HttpDelete]
        public async Task<IActionResult> Excluir(int EnderecoId)
        {
            try
            {
                var endereco = await _enderecoRepositorio.ObterPorId(EnderecoId);
                
                if (endereco == null) return NotFound();

                 _enderecoRepositorio.Remover(endereco);
                
                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou{ ex.Message }" );
            }
        }

    }
}
