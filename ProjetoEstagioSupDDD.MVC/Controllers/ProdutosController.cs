using AutoMapper;
using ProjetoEstagioSupDDD.Dominio.Entidades;
using ProjetoEstagioSupDDD.MVC.Models;
using ProjetoEstagioSupDDD.Persistencia.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoEstagioSupDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        public readonly ProdutoRepositorio _produtoRep =
            new ProdutoRepositorio();

        private readonly TipoProdutoRepositorio _tipoRep =            new TipoProdutoRepositorio();

        private readonly MarcaRepositorio _marcaRep =
           new MarcaRepositorio();

        private readonly FornecedorRepositorio _fornRep =
          new FornecedorRepositorio();        public ProdutosController()
        {
            ViewBag.IdTipoProduto = new SelectList(
            _tipoRep.ConsultarTodos(),
           "IdTipoProduto",
           "DescricaoTipo"
            );

            ViewBag.IdMarca = new SelectList(
            _marcaRep.ConsultarTodos(),
           "IdMarca",
           "DescricaoMarca"
            );

            ViewBag.IdFornecedor = new SelectList(
            _fornRep.ConsultarTodos(),
           "IdFornecedor",
           "DescricaoFornecedor"
            );
        }


        // GET
        public ActionResult Index(string Pesquisa = "")
        {
            //Consultar Todos na Lista
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>,
                IEnumerable<ProdutoViewModel>>
                    (_produtoRep.ConsultarTodos());

            if (!string.IsNullOrEmpty(Pesquisa))
                produtoViewModel = produtoViewModel.Where(c => c.DescricaoProduto.Contains(Pesquisa));
                produtoViewModel = produtoViewModel.OrderBy(c => c.DescricaoProduto);

            return View(produtoViewModel);
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
        public ActionResult Inserir(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var pro = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoRep.Inserir(pro);

                return RedirectToAction("Index");
            }

            return View(produto);
        }


        //Alterar
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult Alterar(int id)
        {
            //Consultar Por Id p/ Alteração
            var produto = _produtoRep.ConsultarPorId(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var pro = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoRep.Alterar(pro);
            }

            return RedirectToAction("Index");
        }


        //Excluir
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult Excluir(int id)
        {
            //Consultar Por Id p/ Exclusão
            var produto = _produtoRep.ConsultarPorId(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            var pro = _produtoRep.ConsultarPorId(id);
            _produtoRep.Excluir(pro);

            return RedirectToAction("Index");
        }
    }
}