using CadastroDeFuncionarios.Models;
using CadastroDeFuncionarios.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CadastroDeFuncionarios.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }


        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }



        [HttpGet("editar/{id}")]
        public IActionResult Editar(int id)
        {
            Console.WriteLine($"ID recebido na URL: {id}");
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            if (contato == null)
            {
                Console.WriteLine("Contato não encontrado");
                return NotFound();
            }
            return View(contato);
        }

        [HttpGet("apagar/{id}")]
        public IActionResult ApagarConfirmacao(int id)
        {
            Console.WriteLine($"ID recebido para apagar: {id}");
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            if (contato == null)
            {
                Console.WriteLine("Contato não encontrado");
                return NotFound();
            }
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cadastro Apagado com sucesso!";
                }
                else
                {

                    TempData["MensagemErro"] = $"Não Conseguimos Apagar seu Cadastro";
                }

                return RedirectToAction("Index");

            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não Conseguimos Apagar seu Cadastro, Tente Novamente, Erro:{erro.Message}";
                return RedirectToAction("Index");

            }

        }


            [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adiconar(contato);
                    TempData["MensagemSucesso"] = "Cadastro de Funcionario Registrado com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não Conseguimos Realizar o Cadastro, Tente Novamente, Erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Cadastro Alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);

            }

            catch (System.Exception erro)

            {
                TempData["MensagemErro"] = $"Não Conseguimos Realizar a Alteração, Tente Novamente, Erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }


    }
}
