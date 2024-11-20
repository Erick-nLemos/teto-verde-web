using CadastroDeFuncionarios.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CadastroDeFuncionarios.Repositorio
{

   
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel ListarPorId(int id);

        ContatoModel Adiconar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);

    }
}
