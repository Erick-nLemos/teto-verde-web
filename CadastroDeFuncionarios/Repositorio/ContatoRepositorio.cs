using CadastroDeFuncionarios.Data;
using CadastroDeFuncionarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CadastroDeFuncionarios.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {

        private readonly BancoContent _context;

        public ContatoRepositorio(BancoContent bancoContext)
        {
            this._context = bancoContext;
        }


        public ContatoModel ListarPorId(int id)
        {
            Console.WriteLine($"ID no método ListarPorId: {id}");
            var contato = _context.Contatos.FirstOrDefault(x => x.Id == id);
            if (contato == null)
            {
                throw new Exception("Contato não encontrado.");
            }
            return contato;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);

            if (contatoDb == null) throw new Exception("Houve um erro na deleção do cadastro!");

            _context.Contatos.Remove(contatoDb);
            _context.SaveChanges();

            return true;
        }





        public List<ContatoModel> BuscarTodos()
        {
            return _context.Contatos.ToList();
        }


        public ContatoModel Adiconar(ContatoModel contato)
        {
            
            _context.Contatos.Add(contato);
            _context.SaveChanges();

            return contato;


        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);

            if (contatoDb == null) throw new Exception("Houve um erro na atualização do cadastro!");

            contatoDb.Name = contato.Name;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;
            contatoDb.CpfCnpj = contato.CpfCnpj;

            _context.Contatos.Update(contatoDb);
            _context.SaveChanges();
            return contatoDb;

        }

      
    }
}
