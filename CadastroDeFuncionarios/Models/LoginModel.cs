using System.ComponentModel.DataAnnotations;

namespace CadastroDeFuncionarios.Models
{
    public class LoginModel
    {


        [Required(ErrorMessage = "Digite o Login do Usuário")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Digite a Senha do Usuário")]
        public string Senha { get; set; }



    }
}
