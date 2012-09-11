using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgendaMedica.Repositorio;
using AgendaMedica.Model;

namespace AgendaMedica.Apresentacao.Controllers
{
    public class MedicoController : Controller
    {
        private MedicoRepositorio medicoRepositorio;

        #region Construtor
        public MedicoController()
        {
            ViewBag.Title = "Agenda - Cadastro de Médicos";
            medicoRepositorio = (MedicoRepositorio)System.Web.HttpContext.Current.Application["medicoRepositorio"];
        }
        #endregion

        public ActionResult Index()
        {
            if(Request.IsAuthenticated)
                return View(medicoRepositorio.SelecionarTodos());

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
        public ActionResult Adicionar(Medico Medico)
        {
            if (Request.IsAuthenticated)
            {
                medicoRepositorio.Inserir(Medico);
                return View("Index", medicoRepositorio.SelecionarTodos());
            }

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }

        public ActionResult Editar(int Id)
        { 
            if(Request.IsAuthenticated)
                return View(medicoRepositorio.SelecionarPorId(Id));

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }

        [HttpPost]
        public ActionResult Editar(Medico Medico)
        {
            if (Request.IsAuthenticated)
            {
                medicoRepositorio.Atualizar(Medico);
                return View("Index", medicoRepositorio.SelecionarTodos());
            }

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }

        public ActionResult Excluir(int Id)
        {
            if(Request.IsAuthenticated)
                return View(medicoRepositorio.SelecionarPorId(Id));

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }

        [HttpPost]
        public ActionResult Excluir(Medico Medico)
        {
            if (Request.IsAuthenticated)
            {
                medicoRepositorio.Excluir(Medico);
                return View("Index", medicoRepositorio.SelecionarTodos());
            }

            ViewBag.MensagemErro = "Desculpe, você não está autenticado no sistema. Página restrita.";
            return View("Error");
        }
    }
}
