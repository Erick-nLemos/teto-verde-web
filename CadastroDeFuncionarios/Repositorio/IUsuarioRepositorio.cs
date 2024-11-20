using CadastroDeFuncionarios.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CadastroDeFuncionarios.Repositorio
{

   
    public interface IUsuarioRepositorio
    {


        UsuarioModel BuscarPorLogin(string login);

        UsuarioModel BuscarPorEmailELogin(string email, string login);

        List<UsuarioModel> BuscarTodos();

        UsuarioModel ListarPorId(int id);


        UsuarioModel Adiconar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);

       
    }
}
