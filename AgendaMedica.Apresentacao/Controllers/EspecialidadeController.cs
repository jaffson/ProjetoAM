using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgendaMedica.Repositorio;
using AgendaMedica.Model;

namespace AgendaMedica.Apresentacao.Controllers
{
    public class EspecialidadeController : Controller
    {
        private EspecialidadeRepositorio especialidadeRepositorio;

        #region Construtor
        public EspecialidadeController()
        {
            ViewBag.Title = "Agenda - Cadastro de Especialidades Médicas";
            especialidadeRepositorio = (EspecialidadeRepositorio)System.Web.HttpContext.Current.Application["especialidadeRepositorio"];
        }
        #endregion

        public ActionResult Index()
        {
            if(Request.IsAuthenticated)
                return View(especialidadeRepositorio.SelecionarTodos());

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }

        public ActionResult Adicionar()
        {
            if(Request.IsAuthenticated)
                return View();
            
            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidade Especialidade)
        {
            if (Request.IsAuthenticated)
            {
                especialidadeRepositorio.Inserir(Especialidade);
                return RedirectToAction("Index", "Especialidade");
            }

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }

        public ActionResult Editar(int Id)
        {
            if(Request.IsAuthenticated)
                return View(especialidadeRepositorio.SelecionarPorId(Id));

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }

        [HttpPost]
        public ActionResult Editar(Especialidade Especialidade)
        {
            if (Request.IsAuthenticated)
            {
                especialidadeRepositorio.Atualizar(Especialidade);
                return RedirectToAction("Index", "Especialidade");
            }

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }

        public ActionResult Excluir(int Id)
        {
            if(Request.IsAuthenticated)
                return View(especialidadeRepositorio.SelecionarPorId(Id));

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }

        [HttpPost]
        public ActionResult Excluir(Especialidade Especialidade)
        {
            if (Request.IsAuthenticated)
            {
                especialidadeRepositorio.Excluir(Especialidade);
                return RedirectToAction("Index", "Especialidade");
            }

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }
    }
}
