using AutoMapper;
using ProjetoEstagioSupDDD.Dominio.Entidades;
using ProjetoEstagioSupDDD.MVC.Models;
using ProjetoEstagioSupDDD.Persistencia.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoEstagioSupDDD.MVC.Controllers
{
    public class TipoProdutosController : Controller
    {
        public readonly TipoProdutoRepositorio _tipoProdutoRep =
            new TipoProdutoRepositorio();

        // GET
        public ActionResult Index(string Pesquisa = "")
        {
            /*
             *Consultar Todos na Lista */
            var tipoProdutoViewModel = Mapper.Map<IEnumerable<TipoProduto>,
                IEnumerable<TipoProdutoViewModel>>
                    (_tipoProdutoRep.ConsultarTodos());

            if (!string.IsNullOrEmpty(Pesquisa))
                tipoProdutoViewModel = tipoProdutoViewModel.Where(c => c.DescricaoTipo.Contains(Pesquisa));
                tipoProdutoViewModel = tipoProdutoViewModel.OrderBy(c => c.DescricaoTipo);

            return View(tipoProdutoViewModel);
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
        public ActionResult Inserir(TipoProdutoViewModel tipoProduto)
        {
            if (ModelState.IsValid)
            {
                var tip = Mapper.Map<TipoProdutoViewModel, TipoProduto>(tipoProduto);
                _tipoProdutoRep.Inserir(tip);

                return RedirectToAction("Index");
            }

            return View(tipoProduto);
        }


        //Alterar
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult Alterar(int id)
        {
            var tipoProduto = _tipoProdutoRep.ConsultarPorId(id);
            var tipoProdutoViewModel = Mapper.Map<TipoProduto, TipoProdutoViewModel>(tipoProduto);

            return View(tipoProdutoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(TipoProdutoViewModel tipoProduto)
        {
            if (ModelState.IsValid)
            {
                var tip = Mapper.Map<TipoProdutoViewModel, TipoProduto>(tipoProduto);
                _tipoProdutoRep.Alterar(tip);
            }

            return RedirectToAction("Index");
        }


        //Excluir
        [Authorize(Roles = "Administrador")]
        public ActionResult Excluir(int id)
        {
            var tipoProduto = _tipoProdutoRep.ConsultarPorId(id);
            var tipoProdutoViewModel = Mapper.Map<TipoProduto, TipoProdutoViewModel>(tipoProduto);

            return View(tipoProdutoViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            var tip = _tipoProdutoRep.ConsultarPorId(id);
            _tipoProdutoRep.Excluir(tip);

            return RedirectToAction("Index");
        }
    }
}