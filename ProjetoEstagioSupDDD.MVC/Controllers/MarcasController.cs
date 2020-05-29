using AutoMapper;
using ProjetoEstagioSupDDD.Dominio.Entidades;
using ProjetoEstagioSupDDD.MVC.Models;
using ProjetoEstagioSupDDD.Persistencia.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoEstagioSupDDD.MVC.Controllers
{
    public class MarcasController : Controller
    {
        public readonly MarcaRepositorio _marcaRep =
            new MarcaRepositorio();

        // GET
        public ActionResult Index(string Pesquisa = "")
        {
            //Consultar Todos na Lista
            var marcaViewModel = Mapper.Map<IEnumerable<Marca>,
                IEnumerable<MarcaViewModel>>
                    (_marcaRep.ConsultarTodos());

            if (!string.IsNullOrEmpty(Pesquisa))
                marcaViewModel = marcaViewModel.Where(c => c.DescricaoMarca.Contains(Pesquisa));
                marcaViewModel = marcaViewModel.OrderBy(c => c.DescricaoMarca);

            return View(marcaViewModel);
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
        public ActionResult Inserir(MarcaViewModel marca)
        {
            if (ModelState.IsValid)
            {
                var marc = Mapper.Map<MarcaViewModel, Marca>(marca);
                _marcaRep.Inserir(marc);

                return RedirectToAction("Index");
            }

            return View(marca);
        }


        //Alterar
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult Alterar(int id)
        {
            var marca = _marcaRep.ConsultarPorId(id);
            var marcaViewModel = Mapper.Map<Marca, MarcaViewModel>(marca);

            return View(marcaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(MarcaViewModel marca)
        {
            if (ModelState.IsValid)
            {
                var marc = Mapper.Map<MarcaViewModel, Marca>(marca);
                _marcaRep.Alterar(marc);
            }

            return RedirectToAction("Index");
        }


        //Excluir
        [Authorize(Roles = "Administrador")]
        public ActionResult Excluir(int id)
        {
            var marca = _marcaRep.ConsultarPorId(id);
            var marcaViewModel = Mapper.Map<Marca, MarcaViewModel>(marca);

            return View(marcaViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            var marc = _marcaRep.ConsultarPorId(id);
            _marcaRep.Excluir(marc);

            return RedirectToAction("Index");
        }
    }
}