using System.ComponentModel.DataAnnotations;

namespace CadastroDeFuncionarios.Models
{
    public class RedefinirSenhaModel
    {


        [Required(ErrorMessage = "Digite o Login ")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }

    }
}
