using Microsoft.AspNetCore.Mvc;

namespace ACPEFINAL.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly Repositories.ADO.SQLServer.Administrador repository;
        private readonly Services.ISessao sessao;

        public AdministradorController(IConfiguration configuration, Services.ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.Administrador(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Aluno(Models.ProfessorAluno proAl)
        {
            try
            {
                this.repository.cadastrarAluno(proAl);
                return RedirectToAction("Index", "Administrador");
            }
            catch
            {
                return RedirectToAction("Index", "Administrador");
            }
        }

        [HttpPost]
        public IActionResult Professor(Models.ProfessorAluno proAl)
        {
            try
            {
                this.repository.cadastrarProfessor(proAl);
                return RedirectToAction("Index", "Administrador");
            }
            catch
            {
                return RedirectToAction("Index", "Administrador");
            }
        }

        [HttpPost]
        public IActionResult Admin(Models.ProfessorAluno proAl)
        {
            try
            {
                this.repository.cadastrarAdmin(proAl);
                return RedirectToAction("Index", "Administrador");
            }
            catch
            {
                return RedirectToAction("Index", "Administrador");
            }
        }

        public IActionResult ListarAlunos()
        {
            return View(this.repository.listarAlunos());
        }

        public IActionResult ListarProfessor()
        {
            return View(this.repository.listarProfessor());
        }
    }
}
