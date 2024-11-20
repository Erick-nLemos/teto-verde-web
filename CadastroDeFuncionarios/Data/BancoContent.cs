using CadastroDeFuncionarios.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeFuncionarios.Data

{

    public class BancoContent : DbContext
    {

        public BancoContent(DbContextOptions<BancoContent> options) : base(options)
        { }
        public DbSet<ContatoModel> Contatos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; } 

     
        }
    }
