using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiXStation.Presentation.Models.Login
{
    public class LoginModel
    {
        //[EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        //[Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string Email { get; set; }

        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string Senha { get; set; }
    }
}
