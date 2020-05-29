using AutoMapper;
using ProjetoEstagioSupDDD.Dominio.Entidades;
using ProjetoEstagioSupDDD.MVC.Models;
using ProjetoEstagioSupDDD.Persistencia.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoEstagioSupDDD.MVC.Controllers
{
    public class FuncionariosController : Controller
    {
        public readonly FuncionarioRepositorio _funcionarioRep =
            new FuncionarioRepositorio();

        // GET
        public ActionResult Index(string Pesquisa = "")
        {
            //Consultar Todos na Lista
            var funcionarioViewModel = Mapper.Map<IEnumerable<Funcionario>,
                IEnumerable<FuncionarioViewModel>>
                    (_funcionarioRep.ConsultarTodos());

            if (!string.IsNullOrEmpty(Pesquisa))
                funcionarioViewModel = funcionarioViewModel.Where(c => c.Nome.Contains(Pesquisa));
            funcionarioViewModel = funcionarioViewModel.OrderBy(c => c.Nome);

            return View(funcionarioViewModel);
        }


        //Inserir
        [Authorize(Roles = "Administrador")]
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inserir(FuncionarioViewModel funcionario)
        {
            if (ModelState.IsValid)
            {
                var fun = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionario);
                _funcionarioRep.Inserir(fun);

                return RedirectToAction("Index");
            }

            return View(funcionario);
        }


        //Alterar
        [Authorize(Roles = "Administrador")]
        public ActionResult Alterar(int id)
        {
            var funcionario = _funcionarioRep.ConsultarPorId(id);
            var funcionarioViewModel = Mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);

            return View(funcionarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(FuncionarioViewModel funcionario)
        {
            if (ModelState.IsValid)
            {
                var fun = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionario);
                _funcionarioRep.Alterar(fun);
            }

            return RedirectToAction("Index");
        }


        //Excluir
        [Authorize(Roles = "Administrador")]
        public ActionResult Excluir(int id)
        {
            var funcionario = _funcionarioRep.ConsultarPorId(id);
            var funcionarioViewModel = Mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);

            return PartialView(funcionarioViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            var fun = _funcionarioRep.ConsultarPorId(id);
            _funcionarioRep.Excluir(fun);

            return RedirectToAction("Index");
        }
    }
}