using AutoMapper;
using ProjetoEstagioSupDDD.Dominio.Entidades;
using ProjetoEstagioSupDDD.MVC.Models;
using ProjetoEstagioSupDDD.Persistencia.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoEstagioSupDDD.MVC.Controllers
{
    public class FornecedoresController : Controller
    {
        public readonly FornecedorRepositorio _fornecedorRep =
            new FornecedorRepositorio();

        // GET
        public ActionResult Index(string Pesquisa = "")
        {
            //Consultar Todos na Lista
            var fornecedorViewModel = Mapper.Map<IEnumerable<Fornecedor>,
                IEnumerable<FornecedorViewModel>>
                    (_fornecedorRep.ConsultarTodos());

            if (!string.IsNullOrEmpty(Pesquisa))
                fornecedorViewModel = fornecedorViewModel.Where(c => c.DescricaoFornecedor.Contains(Pesquisa));
            fornecedorViewModel = fornecedorViewModel.OrderBy(c => c.DescricaoFornecedor);

            return View(fornecedorViewModel);
        }


        //Inserir
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inserir(FornecedorViewModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                var forn = Mapper.Map<FornecedorViewModel, Fornecedor>(fornecedor);
                _fornecedorRep.Inserir(forn);

                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }


        //Alterar
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult Alterar(int id)
        {
            var fornecedor = _fornecedorRep.ConsultarPorId(id);
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(fornecedor);

            return View(fornecedorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(FornecedorViewModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                var forn = Mapper.Map<FornecedorViewModel, Fornecedor>(fornecedor);
                _fornecedorRep.Alterar(forn);
            }

            return RedirectToAction("Index");
        }


        //Excluir
        [Authorize(Roles = "Administrador")]
        public ActionResult Excluir(int id)
        {
            var fornecedor = _fornecedorRep.ConsultarPorId(id);
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(fornecedor);

            return View(fornecedorViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            var forn = _fornecedorRep.ConsultarPorId(id);
            _fornecedorRep.Excluir(forn);

            return RedirectToAction("Index");
        }
    }
}