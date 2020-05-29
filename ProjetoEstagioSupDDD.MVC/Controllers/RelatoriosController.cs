using PagedList;
using ProjetoEstagioSupDDD.Persistencia.Contexto;
using Rotativa;
using Rotativa.Options;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Relatorios_ASPNET_MVC.Controllers
{
    public class RelatoriosController : Controller
        {
            private ProjetoEstagioSupContexto db = new ProjetoEstagioSupContexto();


        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult FormClientePorPeriodo()
        {
            return View();
        }


        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult FormClientePorNome()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult FormServico()
        {
            return View();
        }


        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult ListagemClientePorPeriodo(DateTime dataInicial, DateTime dataFinal, int? pagina, bool? gerarPDF)
        {
            //var listagemClientes = db.Clientes.OrderBy(n => n.IdCliente).ToList();
            var listagemCliente = db.Clientes.Where(i => i.DataCadastro >= dataInicial && 
                i.DataCadastro <= dataFinal).OrderBy(i => i.IdCliente).ToList();

            ViewBag.dataInicial = dataInicial;
            ViewBag.dataFinal = dataFinal;

            if (gerarPDF != true)
                {
                    //Definindo a paginação              
                    int paginaQdteRegistros = 10;
                    int paginaNumeroNavegacao = (pagina ?? 1);

                    return View(listagemCliente.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
                }
                else
                {
                    int paginaNumero = 1;
                
                    var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemClientePorPeriodo",
                    PageSize = Size.A4,
                    PageOrientation = Orientation.Landscape,
                    IsGrayScale = true,
                    Model = listagemCliente.ToPagedList(paginaNumero, listagemCliente.Count)
                };
                return pdf;
            }
        }


        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult ListagemClientePorNome(string nome, int? pagina, bool? gerarPDF)
        {
            //var listagemClientes = db.Clientes.OrderBy(n => n.IdCliente).ToList();
            var listagemCliente = db.Clientes.Where(i => i.Nome == nome).OrderBy(i => i.IdCliente).ToList();

            ViewBag.nome = nome;

            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemCliente.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemClientePorNome",
                    PageSize = Size.A4,
                    PageOrientation = Orientation.Landscape,
                    IsGrayScale = true,
                    Model = listagemCliente.ToPagedList(paginaNumero, listagemCliente.Count)
                };
                return pdf;
            }
        }


        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult ListagemFornecedor(int? pagina, bool? gerarPDF)
        {
            var listagemFornecedor = db.Fornecedores.OrderBy(n => n.IdFornecedor).ToList();

            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemFornecedor.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemFornecedor",
                    PageSize = Size.A4,
                    PageOrientation = Orientation.Landscape,
                    IsGrayScale = true,
                    Model = listagemFornecedor.ToPagedList(paginaNumero, listagemFornecedor.Count)
                };
                return pdf;
            }
        }


        [Authorize(Roles = "Administrador")]
        public ActionResult ListagemFuncionario(int? pagina, bool? gerarPDF)
        {
            var listagemFuncionario = db.Funcionarios.OrderBy(n => n.IdFuncionario).ToList();

            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemFuncionario.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemFuncionario",
                    PageSize = Size.A4,
                    PageOrientation = Orientation.Landscape,
                    IsGrayScale = true,
                    Model = listagemFuncionario.ToPagedList(paginaNumero, listagemFuncionario.Count)
                };
                return pdf;
            }
        }


        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult ListagemServico(string nome, int? pagina, bool? gerarPDF)
        {
            //var listagemServicos = db.Servicos.OrderBy(n => n.IdServico).ToList();
            var listagemServico = db.Servicos.Where(i => i.DescricaoServico == nome).OrderBy(i => i.IdServico).ToList();

            ViewBag.nome = nome;

            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemServico.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemServico",
                    PageSize = Size.A4,
                    PageOrientation = Orientation.Landscape,
                    IsGrayScale = true,
                    Model = listagemServico.ToPagedList(paginaNumero, listagemServico.Count)
                };
                return pdf;
            }
        }


        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult ListagemProduto(int? pagina, bool? gerarPDF)
        {
            var listagemProduto = db.Produtos.OrderBy(n => n.IdProduto).ToList();
            
            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemProduto.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemProduto",
                    PageSize = Size.A4,
                    PageOrientation = Orientation.Landscape,
                    IsGrayScale = true,
                    Model = listagemProduto.ToPagedList(paginaNumero, listagemProduto.Count)
                };
                return pdf;
            }
        }


        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult ListagemTipo(int? pagina, bool? gerarPDF)
        {
            var listagemTipo = db.TiposProduto.OrderBy(n => n.IdTipoProduto).ToList();

            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemTipo.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemTipo",
                    PageSize = Size.A4,
                    PageOrientation = Orientation.Landscape,
                    IsGrayScale = true,
                    Model = listagemTipo.ToPagedList(paginaNumero, listagemTipo.Count)
                };
                return pdf;
            }
        }


        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Funcionario")]
        public ActionResult ListagemMarca(int? pagina, bool? gerarPDF)
        {
            var listagemMarca = db.Marcas.OrderBy(n => n.IdMarca).ToList();

            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemMarca.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemMarca",
                    PageSize = Size.A4,
                    PageOrientation = Orientation.Landscape,
                    IsGrayScale = true,
                    Model = listagemMarca.ToPagedList(paginaNumero, listagemMarca.Count)
                };
                return pdf;
            }
        }


        [Authorize(Roles = "Administrador")]
        public ActionResult ListagemPedido(int? pagina, bool? gerarPDF)
        {
            var listagemPedido = db.Pedidos.OrderBy(n => n.IdPedido).ToList();

            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemPedido.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemPedido",
                    PageSize = Size.A4,
                    PageOrientation = Orientation.Landscape,
                    IsGrayScale = true,
                    Model = listagemPedido.ToPagedList(paginaNumero, listagemPedido.Count)
                };
                return pdf;
            }
        }
    }
 }