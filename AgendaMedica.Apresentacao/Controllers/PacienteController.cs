using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgendaMedica.Model;
using AgendaMedica.Repositorio;

namespace AgendaMedica.Apresentacao.Controllers
{
    public class PacienteController : Controller
    {
        private PacienteRepositorio pacienteRepositorio;
 
        public PacienteController()
        {
            ViewBag.Title = "Agenda - Cadastro de Pacientes";
            pacienteRepositorio = (PacienteRepositorio)System.Web.HttpContext.Current.Application["pacienteRepositorio"];
        }

        public ActionResult Index()
        {
            return View(pacienteRepositorio.SelecionarTodos());
        }


        public ActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(Paciente paciente)
        {
            pacienteRepositorio.Inserir(paciente);
            return View("Index", pacienteRepositorio.SelecionarTodos());
        }

        public ActionResult Editar(int Id)
        {
            return View(pacienteRepositorio.SelecionarPorId(Id));
        }

        [HttpPost]
        public ActionResult Editar(Paciente paciente)
        {
            pacienteRepositorio.Atualizar(paciente);
            return View("Index", pacienteRepositorio.SelecionarTodos());
        }

        public ActionResult Excluir(int Id)
        {
            return View(pacienteRepositorio.SelecionarPorId(Id));
        }

        [HttpPost]
        public ActionResult Excluir(Paciente paciente)
        {
            pacienteRepositorio.Excluir(paciente);
            return View("Index", pacienteRepositorio.SelecionarTodos());
        }

    }
}
