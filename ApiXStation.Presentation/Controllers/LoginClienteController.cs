using ApiXStation.Presentation.Authorization;
using ApiXStation.Presentation.Models.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XStation.Repository.Contracts;

namespace ApiXStation.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginClienteController : ControllerBase
    {
        [HttpPost]
        
        public IActionResult Post(LoginModel model,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] JwtConfiguration jwtConfiguration)
        {
            try
            {
                if (clienteRepository.GetByEmailAndSenha(model.Email, model.Senha) != null)
                {
                    return Ok(new { accessToken = jwtConfiguration.GenerateToken(model.Email) });
                }
                else
                {
                    return StatusCode(500, "Acesso negado. Usuário não encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }     
    }
}
