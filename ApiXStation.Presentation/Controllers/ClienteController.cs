using ApiXStation.Presentation.Models.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XStation.Repository.Contracts;
using XStation.Repository.Entities;

namespace ApiXStation.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model,
            [FromServices] IClienteRepository clienteRepository)
        {
            try  
            {
                if (clienteRepository.GetByCpf(model.Cpf) != null)
                {
                    return StatusCode(500, "Erro, o  Cpf ja esta cadastrado. Tente outro.");
                }
                else
                {
                    var cliente = new Cliente();
                    cliente.Nome = model.Nome;
                    cliente.Cpf = model.Cpf;
                    cliente.Senha = model.Senha;
                    cliente.Email = model.Email;
                    cliente.Telefone1 = model.Telefone1;
                    cliente.Telefone2 = model.Telefone2;
                    cliente.DataNascimento = model.DataNascimento;
                    cliente.DataCriacao = DateTime.Now;
                    cliente.IdPerfil = 2;

                    clienteRepository.Insert(cliente);

                    return Ok("Cliente cadastrado com sucesso");

                }
            }
            catch (Exception e)
            {

                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model,
            [FromServices] IClienteRepository clienteRepository)
        {
            var cliente = clienteRepository.GetById(model.Id);
            try
            {
                if (cliente != null)
                {

                    cliente.Nome = model.Nome;
                    cliente.Cpf = model.Cpf;
                    cliente.Email = model.Email;
                    cliente.Senha = model.Senha;
                    cliente.Telefone1 = model.Telefone1;
                    cliente.Telefone2 = model.Telefone2;
                    cliente.DataNascimento = model.DataNascimento;
                    cliente.DataCriacao = DateTime.Now;
                    cliente.IdPerfil = model.IdPerfil;

                    clienteRepository.Update(cliente);

                    return Ok("Cliente Atualidado com sucesso");
                }
                else
                {
                    return StatusCode(400, "Cliente nao cadastrada no sistema");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IClienteRepository clienteRepository)
        {
            try
            {
                var cliente = clienteRepository.GetById(id);
                if (cliente != null)
                {
                    clienteRepository.Excluir(cliente);
                    return Ok("Cliente Excluido com sucesso");
                }
                else
                {
                    return StatusCode(400, "Pessoa nao cadastrada no sistema");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro" + e.Message);
            }
        }
  
        
        [ProducesResponseType(typeof(List<ClienteConsultaModel>), 200)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id
            ,[FromServices] IClienteRepository clienteRepository)
        {
            try
            {
                var cliente = clienteRepository.GetById(id);

                if (cliente != null)
                {
                    var model = new ClienteConsultaModel();

                    model.Id = cliente.IdCliente;
                    model.Nome = cliente.Nome;
                    model.Cpf = cliente.Cpf;
                    model.Email = cliente.Email;
                    model.Senha = cliente.Senha;
                    model.Telefone1 = cliente.Telefone1;
                    model.Telefone2 = cliente.Telefone2;
                    model.DataNascimento = cliente.DataNascimento;
                    model.IdPerfil = cliente.IdPerfil;

                    return Ok(model);
                }
                else
                {
                    return StatusCode(400, "Pessoa nao cadastrada no sistema");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro" + e.Message);
            }      
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetCliente([FromServices] IClienteRepository clienteRepository)
        {
            try
            {
                var email = User.Identity.Name;

                var cliente = clienteRepository.GetByEmail(email);

                return Ok(new
                {
                    cliente.IdCliente,
                    cliente.Nome,
                    cliente.Cpf,
                    cliente.Telefone1,
                    cliente.Telefone2,
                    cliente.DataNascimento,
                    cliente.DataCriacao,
                    cliente.IdPerfil
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro: " + e.Message); 
            }
        }
    }
}
