using ApiXStation.Presentation.Models.Endereco;
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
    public class EnderecoFuncionarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(EnderecoCadastroModel model,
            [FromServices] IEnderecoRepository enderecoRepository,
            [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var funcionario = funcionarioRepository.GetByEmail(email);

                var endereco = new Endereco();

                endereco.Cep = model.Cep;
                endereco.Logradouro = model.Logradouro;
                endereco.Bairro = model.Bairro;
                endereco.Cidade = model.Cidade;
                endereco.Estado = model.Estado;
                endereco.Estado = model.Estado;
                endereco.IdFuncionario = model.IdFuncionario;

                enderecoRepository.Insert(endereco);

                return Ok("Endereco Cadastrado com sucesso ");

            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro" + e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(EnderecoEdicaoModel model,
            [FromServices] IEnderecoRepository enderecoRepository,
            [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var funcionario = funcionarioRepository.GetByEmail(email);

                var endereco = enderecoRepository.GetByIdFuncionario(model.Id , funcionario.IdFuncionario);
                if (endereco != null)
                {
                    endereco.IdEndereco = model.Id;
                    endereco.Cep = model.Cep;
                    endereco.Logradouro = model.Logradouro;
                    endereco.Bairro = model.Bairro;
                    endereco.Cidade = model.Cidade;
                    endereco.Estado = model.Estado;
                    endereco.Estado = model.Estado;
                    endereco.IdFuncionario = model.IdFuncionario;

                    enderecoRepository.Update(endereco);


                    return Ok("Endereco Atualizado com sucesso.");
                }
                else
                {
                    return StatusCode(500, "Endereco não encontrada.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro" + e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete( 
            [FromServices] IEnderecoRepository enderecoRepository,
            [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var funcionario = funcionarioRepository.GetByEmail(email);

                var endereco = enderecoRepository.GetByIdFuncionario(funcionario.IdEndereco, funcionario.IdFuncionario);

                return Ok("Endereco Excluido com sucesso ");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro" + e.Message);
            }
        }


        [HttpGet]
        public IActionResult Get(
            [FromServices] IEnderecoRepository enderecoRepository,
            [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var funcionario = funcionarioRepository.GetByEmail(email);
                var lista = new List<EnderecoConsultaModel>();

                foreach (var item in enderecoRepository.GetAllFuncionario(funcionario.IdFuncionario))
                {
                    var model = new EnderecoConsultaModel();

                    model.Id = item.IdEndereco;
                    model.Cep = item.Cep;
                    model.Logradouro = item.Logradouro;
                    model.Bairro = item.Bairro;
                    model.Cidade = item.Cidade;
                    model.Estado = item.Estado;
                    model.IdFuncionario = item.IdFuncionario;

                    lista.Add(model);
                }
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices] IEnderecoRepository enderecoRepository,
            [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var funcionario = funcionarioRepository.GetByEmail(email);
                var endereco = enderecoRepository.GetByIdFuncionario(funcionario.IdEndereco , funcionario.IdFuncionario);

                if (funcionario != null)
                {
                    var model = new EnderecoConsultaModel();

                    model.Id = endereco.IdEndereco;
                    model.Cep = endereco.Cep;
                    model.Logradouro = endereco.Logradouro;
                    model.Logradouro = endereco.Logradouro;
                    model.Bairro = endereco.Bairro;
                    model.Cidade = endereco.Cidade;
                    model.Estado = endereco.Estado;
                    model.IdFuncionario = endereco.IdFuncionario;

                    return Ok(model);
                }
                else
                {
                    return StatusCode(500, "Endereco não encontrada.");
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}
