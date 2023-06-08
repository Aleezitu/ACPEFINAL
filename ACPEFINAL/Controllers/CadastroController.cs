using Microsoft.AspNetCore.Mvc;

namespace ACPEFINAL.Controllers
{
    public class CadastroController : Controller
    {
        private readonly Repositories.ADO.SQLServer.Cadastro repository;
        private readonly Services.ISessao sessao;

        public CadastroController(IConfiguration configuration, Services.ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.Cadastro(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastroAdm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroAdm(Models.Admin admin)
        {
            //return View(this.repository.cadastrar(usuario));
            try
            {
                this.repository.cadastrar(admin);
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return View();
            }
        }
    }
}
