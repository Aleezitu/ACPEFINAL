﻿using ACPEFINAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACPEFINAL.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly Repositories.ADO.SQLServer.Professor repository;
        private readonly Services.ISessao sessao;

        public ProfessorController(IConfiguration configuration, Services.ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.Professor(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        public IActionResult Index ()
        {
            return View();
        }

        public IActionResult Perfil()
        {

            int idProfessor = this.sessao.get().Id;
            return View(this.repository.perfilProfessor(idProfessor));
        }

        public IActionResult Recados()
        {
            int idProfessor = this.sessao.get().Id;
            return View(this.repository.pegarIdAlunosRecados(idProfessor));
        }

        [HttpPost]
        public IActionResult Recados(Models.RecadosAlunos recadosAlunos)
        {
            int idProfessor = this.sessao.get().Id;

            repository.cadastrarRecado(recadosAlunos, idProfessor);
            return RedirectToAction("Index", "Professor");
        }

        public IActionResult Tarefas()
        {
            int idProfessor = this.sessao.get().Id;
            return View(this.repository.pegarIdAlunosTarefas(idProfessor));
            
        }

        [HttpPost]
        public IActionResult Tarefas(Models.TarefasAlunos tarefasAlunos)
        {
            int idProfessor = this.sessao.get().Id;

            repository.cadastrarTarefas(tarefasAlunos, idProfessor);
            return RedirectToAction("Index", "Professor");
        }

        public IActionResult Ajuda()
        {
            return View();
        }
    }
}
