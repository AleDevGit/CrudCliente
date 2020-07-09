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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public  readonly IMapper _mapper;
        public ClienteController(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
        }

        [Route("v1/obtertodos")]
        [HttpGet]
        public  async Task<ActionResult> Obtertodos()
        {
            try
            {
                var clientes = await _clienteRepositorio.ObterTodos();
                var results = _mapper.Map<ClienteDto[]>(clientes);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou {ex.Message}");
            }
        }

        [Route("v1/obterpornome/{Nome}")]
        [HttpGet]
        public  async Task<ActionResult> ObterPorNome(string Nome)
        {
            try
            {
                var clientes = await _clienteRepositorio.ObterPorNome(Nome);
                var results = _mapper.Map<ClienteDto[]>(clientes);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou {ex.Message}");
            }
        }

        [Route("v1/obterporcpf/{CPF}")]
        [HttpGet]
        public  async Task<ActionResult> ObterPorCPF(string CPF)
        {
            try
            {
                var clientes = await _clienteRepositorio.ObterPorCPF(CPF);
                var results = _mapper.Map<ClienteDto>(clientes);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou {ex.Message}");
            }
        }

        [Route("v1/obterporid/{ClienteId}")]
        [HttpGet]
        public  async Task<ActionResult> ObterPorId(int ClienteId)
        {
            try
            {
                var clientes = await _clienteRepositorio.ObterPorId(ClienteId);
                var results = _mapper.Map<ClienteDto>(clientes);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou {ex.Message}");
            }
        }

        [Route("v1/cadastrar")]
        [HttpPost]
        public async Task<IActionResult> CadastrarAsync(ClienteDto clienteModel)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteModel);
                var existe = await _clienteRepositorio.ObterPorCPF(clienteModel.CPF);
                if (existe == null){
                    _clienteRepositorio.Adicionar(cliente);
                }else{
                    return BadRequest("Cliente já Cadastrado com esse CPF.");
                }
                return Created($"api/obterporid/{cliente.Id}", _mapper.Map<ClienteDto>(cliente));
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou{ ex.Message }" );
            }
        }

        [Route("v1/alterar/{ClienteId}")]
        [HttpPut]
        public async Task<IActionResult> AlterarAsync(int ClienteId, ClienteDto clienteModel)
        {
            try
            {
                var cliente = await _clienteRepositorio.ObterPorId(ClienteId);
                
                if (cliente == null) return NotFound();

                _mapper.Map(clienteModel, cliente);
                _clienteRepositorio.Atualizar(cliente);
                
                return Created($"api/obterporid/{cliente.Id}", _mapper.Map<ClienteDto>(cliente));
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou{ ex.Message }" );
            }
        }

        [Route("v1/excluir/{ClienteId}")]
        [HttpDelete]
        public async Task<IActionResult> Excluir(int ClienteId)
        {
            try
            {
                var cliente = await _clienteRepositorio.ObterPorId(ClienteId);
                
                if (cliente == null) return NotFound();

                 _clienteRepositorio.Remover(cliente);
                
                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falou{ ex.Message }" );
            }
        }

    }
}
