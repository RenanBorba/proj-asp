using AutoMapper;
using ProjetoEstagioSupDDD.Dominio.Entidades;
using ProjetoEstagioSupDDD.MVC.Models;
using ProjetoEstagioSupDDD.Persistencia.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoEstagioSupDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        public readonly ClienteRepositorio _clienteRep =
            new ClienteRepositorio();

        //GET            
        public ActionResult Index(string Pesquisa = "")
        {
            //Consultar Todos na Lista
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>,
                IEnumerable<ClienteViewModel>>
                    (_clienteRep.ConsultarTodos());

            /*
             * Consultar por Nome */
            if (!string.IsNullOrEmpty(Pesquisa))
            clienteViewModel = clienteViewModel.Where(c => c.Nome.Contains(Pesquisa));
            clienteViewModel = clienteViewModel.OrderBy(c => c.Nome);

            return View(clienteViewModel);
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
        public ActionResult Inserir(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var cli = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteRep.Inserir(cli);
            }

            return RedirectToAction("Index");
        }


        //Alterar
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult Alterar(int id)
        {
            var cliente = _clienteRep.ConsultarPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var cli = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteRep.Alterar(cli);
            }

            return RedirectToAction("Index");
        }


        //Excluir
        [Authorize(Roles = "Administrador")]
        public ActionResult Excluir(int id)
        {
            var cliente = _clienteRep.ConsultarPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            var cli = _clienteRep.ConsultarPorId(id);
            _clienteRep.Excluir(cli);

            return RedirectToAction("Index");
        }
    }
}