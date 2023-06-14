using ACPEFINAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ACPEFINAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repositories.ADO.SQLServer.Home repository;
        private readonly Services.ISessao sessao;

        public HomeController(IConfiguration configuration, Services.ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.Home(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AreaAjuda()
        {
            return View();
        }

        public IActionResult Pergunte()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pergunte(Models.Duvida duvida)
        {
            try
            {
                this.repository.enviarPergunta(duvida);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

    }
}