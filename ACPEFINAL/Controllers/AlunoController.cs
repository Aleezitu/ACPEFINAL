using Microsoft.AspNetCore.Mvc;

namespace ACPEFINAL.Controllers
{
    public class AlunoController : Controller
    {
        private readonly Repositories.ADO.SQLServer.Aluno repository;
        private readonly Services.ISessao sessao;

        public AlunoController(IConfiguration configuration, Services.ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.Aluno(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Perfil()
        {

            int idAluno = this.sessao.get().Id;
            return View(this.repository.perfilAluno(idAluno));
        }

        public IActionResult Recados()
        {
            int idAluno = this.sessao.get().Id;
            return View(this.repository.mostrarRecados(idAluno));
        }

        public IActionResult ConfirmarRecado(int IdRecado)
        {
            this.repository.confirmarRecado(IdRecado);
            return RedirectToAction("Recados", "Aluno");
        }

        public IActionResult Tarefas()
        {
            int idAluno = this.sessao.get().Id;
            return View(this.repository.mostrarTarefas(idAluno));
        }
    }
}
