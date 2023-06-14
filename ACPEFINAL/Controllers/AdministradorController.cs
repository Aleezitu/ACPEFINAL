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

        public IActionResult EditarAlunos(int id)
        {
            return View(this.repository.listarAluno(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAlunos(Models.AlunoEndereco alunoEndereco)
        {
            try
            {
                this.repository.atualizarAlunos(alunoEndereco);
                return RedirectToAction("ListarAlunos","Administrador");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult EditarProfessores(int id)
        {
            return View(this.repository.listarProf(id));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProfessores(Models.ProfessorEnderecos profEndereco)
        {
            try
            {
                this.repository.atualizarProfessores(profEndereco);
                return RedirectToAction("ListarProfessor", "Administrador");
            }
            catch
            {
                return View();
            }
        }


        public IActionResult ListarProfessor()
        {
            return View(this.repository.listarProfessor());
        }


        public IActionResult Duvidas()
        {
            return View(this.repository.listarDuvidas());
        }

        [HttpPost]
        public IActionResult ResponderDuvida(int id, string resposta)
        {
            this.repository.responderPergunta(id, resposta, this.sessao.get().Email);

            return RedirectToAction("Duvidas", "Administrador");
        }

        public IActionResult Delete(int id)
        {
            this.repository.deletarDuvida(id);

            return RedirectToAction("Duvidas", "Administrador");
        }

        public IActionResult DeleteAluno(int id)
        {
            this.repository.deletarAluno(id);

            return RedirectToAction("ListarAlunos", "Administrador");
        }

        public IActionResult DeleteProfessor(int id)
        {
            this.repository.deletarProfessor(id);

            return RedirectToAction("ListarProfessor", "Administrador");
        }

    }
}
