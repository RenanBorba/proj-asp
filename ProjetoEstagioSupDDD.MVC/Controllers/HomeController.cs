using System.Web.Mvc;

namespace ProjetoEstagioSupDDD.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult About()
        {
            ViewBag.Message = "Adriano Luiz - Prestação de Serviços Químicos.";

            return View();
        }

 
        public ActionResult Contact()
        {
            ViewBag.Message = "Fale conosco.";

            return View();
        }
    }
}