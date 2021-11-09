using ApiXStation.Presentation.Models.Funcionario;
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
    public class FuncionarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(FuncionarioCadastroModel model,
            [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                if (funcionarioRepository.GetByCpf(model.Cpf) != null)
                {
                    return StatusCode(500, "Erro, o  Cpf ja esta cadastrado. Tente outro.");
                }
                else
                {
                    var funcionario = new Funcionario();
                    funcionario.Nome = model.Nome;
                    funcionario.Cpf = model.Cpf;
                    funcionario.Email = model.Email;
                    funcionario.Senha = model.Senha;
                    funcionario.Telefone1 = model.Telefone1;
                    funcionario.Telefone2 = model.Telefone2;
                    funcionario.DataNascimento = model.DataNascimento;
                    funcionario.DataCriacao = DateTime.Now;
                    funcionario.IdPerfil = model.IdPerfil;

                    funcionarioRepository.Insert(funcionario);

                    return Ok("Funcionario cadastrado com sucesso");

                }
            }
            catch (Exception e)
            {

                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionarioEdicaoModel model,
            [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            var funcionario = funcionarioRepository.GetById(model.Id);
            try
            {
                if (funcionario != null)
                {

                    funcionario.Nome = model.Nome;
                    funcionario.Cpf = model.Cpf;
                    funcionario.Email = model.Email;
                    funcionario.Senha = model.Senha;
                    funcionario.Telefone1 = model.Telefone1;
                    funcionario.Telefone2 = model.Telefone2;
                    funcionario.DataNascimento = model.DataNascimento;
                    funcionario.IdPerfil = model.IdPerfil;
                    funcionario.DataCriacao = DateTime.Now;

                    funcionarioRepository.Update(funcionario);

                    return Ok("Funcionario Atualidado com sucesso");
                }
                else
                {
                    return StatusCode(400, "Funcionario nao cadastrada no sistema");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                var funcionario = funcionarioRepository.GetById(id);
                if (funcionario != null)
                {
                    funcionarioRepository.Excluir(funcionario);
                    return Ok("Funcionario Excluido com sucesso");
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
  
        [ProducesResponseType(typeof(List<FuncionarioConsultaModel>), 200)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id
            ,[FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                var Funcionario = funcionarioRepository.GetById(id);

                if (Funcionario != null)
                {
                    var model = new FuncionarioConsultaModel();

                    model.Id = Funcionario.IdFuncionario;
                    model.Nome = Funcionario.Nome;
                    model.Cpf = Funcionario.Cpf;
                    model.Email = Funcionario.Email;
                    model.Senha = Funcionario.Senha;
                    model.Telefone1 = Funcionario.Telefone1;
                    model.Telefone2 = Funcionario.Telefone2;
                    model.DataNascimento = Funcionario.DataNascimento;
                    model.IdPerfil = Funcionario.IdPerfil;

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
        public IActionResult GetFuncionario([FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                var email = User.Identity.Name;

                var funcionario = funcionarioRepository.GetByEmail(email);

                return Ok(new
                {
                    funcionario.IdFuncionario,
                    funcionario.Nome,
                    funcionario.Cpf,
                    funcionario.Telefone1,
                    funcionario.Telefone2,
                    funcionario.DataNascimento,
                    funcionario.DataCriacao,
                    funcionario.IdPerfil
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }
    }
}
