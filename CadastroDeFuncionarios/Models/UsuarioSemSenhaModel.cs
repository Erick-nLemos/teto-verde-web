using CadastroDeFuncionarios.Enunns;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeFuncionarios.Models
{
    public class UsuarioSemSenhaModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login do Usuário")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Digite o E-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Selecione o Perfil do Usuário")]
        public PerfilEnum? Perfil { get; set; }


    }
}
