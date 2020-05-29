using AutoMapper;
using ProjetoEstagioSupDDD.Dominio.Entidades;
using ProjetoEstagioSupDDD.MVC.Models;
using ProjetoEstagioSupDDD.Persistencia.Contexto;
using ProjetoEstagioSupDDD.Persistencia.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoEstagioSupDDD.MVC.Controllers
{
    public class PedidosController : Controller
    {
        public readonly PedidoRepositorio _pedidoRep =
           new PedidoRepositorio();

        public readonly ClienteRepositorio _clienteRep =
           new ClienteRepositorio();

        public readonly ServicoRepositorio _servicoRep =
           new ServicoRepositorio();

        public readonly ProdutoRepositorio _produtoRep =
           new ProdutoRepositorio();

        private ProjetoEstagioSupContexto db = new ProjetoEstagioSupContexto();


        public PedidosController()
        {
            ViewBag.IdCliente = new SelectList(
            _clienteRep.ConsultarTodos(),
           "IdCliente",
           "Nome"
            );

            ViewBag.IdServico = new SelectList(
            _servicoRep.ConsultarTodos(),
           "IdServico",
           "DescricaoServico"
            );

            
            ViewBag.IdProduto = new SelectList(
            _produtoRep.ConsultarTodos(),
           "IdProduto",
           "DescricaoProduto"
            );           
        }


        // GET
        public ActionResult Index(string Pesquisa = "")
        {
            //Consultar Todos na Lista
            var pedidoViewModel = Mapper.Map<IEnumerable<Pedido>,
                IEnumerable<PedidoViewModel>>
                    (_pedidoRep.ConsultarTodos());

            if (!string.IsNullOrEmpty(Pesquisa))
                pedidoViewModel = pedidoViewModel.Where(c => c.Clientes.Nome.Contains(Pesquisa));
            pedidoViewModel = pedidoViewModel.OrderBy(c => c.Clientes.Nome);

            return View(pedidoViewModel);
        }


        //Inserir
        [Authorize(Roles = "Administrador")]
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inserir(PedidoViewModel pedido)
        {
            if (ModelState.IsValid)
            {
                var ped = Mapper.Map<PedidoViewModel, Pedido>(pedido);
                _pedidoRep.Inserir(ped);

                return RedirectToAction("Index");
            }

            return Json(new {Resultado = pedido.IdPedido},JsonRequestBehavior.AllowGet);
        }


        //Alterar
        [Authorize(Roles = "Administrador")]
        public ActionResult Alterar(int id)
        {
            var pedido = _pedidoRep.ConsultarPorId(id);
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);

            return View(pedidoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(PedidoViewModel pedido)
        {
            if (ModelState.IsValid)
            {
                var ped = Mapper.Map<PedidoViewModel, Pedido>(pedido);
                _pedidoRep.Alterar(ped);
            }

            return RedirectToAction("Index");
        }


        //Excluir
        [Authorize(Roles = "Administrador")]
        public ActionResult Excluir(int id)
        {
            var pedido = _pedidoRep.ConsultarPorId(id);
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);

            return View(pedidoViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            var ped = _pedidoRep.ConsultarPorId(id);
            _pedidoRep.Excluir(ped);

            return RedirectToAction("Index");
        }


        //Partial View
        [HttpGet]
        public ActionResult _ListaClientes()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>,
                IEnumerable<ClienteViewModel>>
                    (_clienteRep.ConsultarTodos());

            return PartialView(clienteViewModel);
        }


        [HttpGet]
        public ActionResult _ListaServicos()
        {
            var servicoViewModel = Mapper.Map<IEnumerable<Servico>,
                IEnumerable<ServicoViewModel>>
                    (_servicoRep.ConsultarTodos());

            return PartialView(servicoViewModel);
        }


        [HttpGet]
        public ActionResult _ListaProdutos()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>,
                IEnumerable<ProdutoViewModel>>
                    (_produtoRep.ConsultarTodos());

            return PartialView(produtoViewModel);
        }
       
    }
}
