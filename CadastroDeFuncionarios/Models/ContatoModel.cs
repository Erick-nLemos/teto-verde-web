using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace CadastroDeFuncionarios.Models
{
    public class ContatoModel
    {
       
        public int Id { get; set; }

        [Required (ErrorMessage = "Digite o nome do Funcionário")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do Funcionário")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Celular do Funcionário")]
        [Phone(ErrorMessage = "O celular informado não é valido!")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Digite o Documento do Funcionário")]
        
        public string CpfCnpj { get; set; }
    }
}

