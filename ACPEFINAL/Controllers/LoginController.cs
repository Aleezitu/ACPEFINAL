using Microsoft.AspNetCore.Mvc;

namespace ACPEFINAL.Controllers
{

    public class LoginController : Controller
    {
        private readonly Repositories.ADO.SQLServer.Login repository;
        private readonly Services.ISessao sessao;

        public LoginController(IConfiguration configuration, Services.ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.Login(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        //GET NA TELA DE LOGIN
        public IActionResult Index()
        {
            return this.sessao.get() == null ? View() : RedirectToAction("Index", "Home");
        }

        //FAZENDO O LOGIN
        [HttpPost]
        public ActionResult Index(Models.Login login)
        {
            if (repository.check(login))
            {

                var loginResult = repository.getType(login);
                this.sessao.add(login);

                Console.WriteLine(this.sessao.get().TipoUsuario);

                switch (loginResult)
                {
                    case 1:
                        //administrador
                        return RedirectToAction("Index", "Home");
                    case 2:
                        //professor
                        return RedirectToAction("Index", "Professor");
                    case 3:
                        //aluno
                        return RedirectToAction("Index", "Home");
                    default:
                        break;
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            this.sessao.delete();
            return RedirectToAction("Index", "Home");
        }
    }
}
