using CadastroDeFuncionarios.Data;
using CadastroDeFuncionarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CadastroDeFuncionarios.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoContent _context;

        public UsuarioRepositorio(BancoContent bancoContext)
        {
            this._context = bancoContext;
        }


        public UsuarioModel ListarPorId(int id)
        {
            Console.WriteLine($"ID no método ListarPorId: {id}");
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado.");
            }
            return usuario;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id);

            if (usuarioDb == null) throw new Exception("Houve um erro na deleção do usuario!");

            _context.Usuarios.Remove(usuarioDb);
            _context.SaveChanges();

            return true;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());

        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }



        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }


        public UsuarioModel Adiconar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;


        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);

            if (usuarioDb == null) throw new Exception("Houve um erro na atualização do usuario!");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.Now;


            _context.Usuarios.Update(usuarioDb);
            _context.SaveChanges();
            return usuarioDb;

        }

       
    }
}
