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
    public class ServicosController : Controller
    {
        public readonly ServicoRepositorio _servicoRep =
            new ServicoRepositorio();

        private ProjetoEstagioSupContexto db = new ProjetoEstagioSupContexto();

        // GET  
        public ActionResult Index(string Pesquisa = "")
        {
            //Consultar Todos na Lista
            var servicoViewModel = Mapper.Map<IEnumerable<Servico>,
                IEnumerable<ServicoViewModel>>
                    (_servicoRep.ConsultarTodos());

            if (!string.IsNullOrEmpty(Pesquisa))
                servicoViewModel = servicoViewModel.Where(c => c.DescricaoServico.Contains(Pesquisa));
                servicoViewModel = servicoViewModel.OrderBy(c => c.DescricaoServico);

            return View(servicoViewModel);
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
        public ActionResult Inserir(ServicoViewModel servico)
        {
            if (ModelState.IsValid)
            {
                var serv = Mapper.Map<ServicoViewModel, Servico>(servico);
                _servicoRep.Inserir(serv);

                return RedirectToAction("Index");
            }

            return View(servico);
        }


        //Alterar
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult Alterar(int id)
        {
            var servico = _servicoRep.ConsultarPorId(id);
            var servicoViewModel = Mapper.Map<Servico, ServicoViewModel>(servico);

            return View(servicoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(ServicoViewModel servico)
        {
            if (ModelState.IsValid)
            {
                var serv = Mapper.Map<ServicoViewModel, Servico>(servico);
                _servicoRep.Alterar(serv);
            }

            return RedirectToAction("Index");
        }


        //Excluir
        [Authorize(Roles = "Administrador")]
        public ActionResult Excluir(int id)
        {
            var servico = _servicoRep.ConsultarPorId(id);
            var servicoViewModel = Mapper.Map<Servico, ServicoViewModel>(servico);

            return View(servicoViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            var serv = _servicoRep.ConsultarPorId(id);
            _servicoRep.Excluir(serv);

            return RedirectToAction("Index");
        }



        /*
        public ActionResult ListarServicos(int id)
        {      
            var lista = db.Servicos.Where(m => m.Pedido. == id);
            ViewBag.Servico = id;
            return PartialView(lista);
        }
        */
    }
}
 