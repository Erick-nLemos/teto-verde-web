using CadastroDeFuncionarios.Models;
using CadastroDeFuncionarios.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeFuncionarios.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adiconar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Registrado com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não Conseguimos Realizar o Cadastro, Tente Novamente, Erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }


         public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário Apagado com sucesso!";
                }
                else
                {

                    TempData["MensagemErro"] = $"Não Conseguimos Apagar o Usuário";
                }

                return RedirectToAction("Index");

            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não Conseguimos Apagar o Usuário, Tente Novamente, Erro:{erro.Message}";
                return RedirectToAction("Index");

            }

        }

        public IActionResult Editar( int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }


        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };

                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário Alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);

            }

            catch (Exception erro)

            {
                TempData["MensagemErro"] = $"Não Conseguimos Realizar a Alteração, Tente Novamente, Erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }





    }
}
