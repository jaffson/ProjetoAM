using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgendaMedica.Model;
using AgendaMedica.Repositorio;
using AgendaMedica.Apresentacao.Models;

namespace AgendaMedica.Apresentacao.Controllers
{
    public class AgendaController : Controller
    {
        
        AgendaRepositorio agendaRepositorio;
        MedicoRepositorio medicoRepositorio;
        public AgendaController()
        {
            ViewBag.Title = "Agenda";
            agendaRepositorio = (AgendaRepositorio)System.Web.HttpContext.Current.Application["agendaRepositorio"];
            medicoRepositorio = (MedicoRepositorio)System.Web.HttpContext.Current.Application["medicoRepositorio"];

        }
        
        public ActionResult Index()
        {
            //ViewBag.Profissionais = ObterProfissionais(1, 2);
            return View();
        }

        public JsonResult ObterEventos(double start, double end)
        {
            IList<CalendarEvent> eventos =  new List<CalendarEvent>();
            CalendarEvent evento ;           

       
            foreach (Agenda agenda in agendaRepositorio.SelecionarTodos())
            {
                evento = new CalendarEvent();
                evento.id = agenda.Id;
                evento.title = agenda.Paciente.Nome;
                evento.description = agenda.Paciente.Nome + " - " + agenda.Especialidade.Nome;
                evento.start = ToUnixTimespan(agenda.DataInicio).ToString();
                evento.end = ToUnixTimespan(agenda.DataFim).ToString()  ;
                evento.allDay = false;
                evento.resourceId = agenda.Medico.Id;
                //evento.url = "";
                eventos.Add(evento);
            }


            return Json(eventos.ToArray(),JsonRequestBehavior.AllowGet); 

        }
        
        public JsonResult ObterProfissionais() {
            IList<CalendarResource> profissionais = new List<CalendarResource>();
            CalendarResource profissional;
            string[] cores = { "#c0c0c0", "#FFFFAA", "#D9D9F3", "#0066CC", "#90EE90", "#B22222","#483D8B","#CD5C5C" };

            foreach (Medico medico in medicoRepositorio.SelecionarTodos())
            {
                profissional = new CalendarResource();
                profissional.id = medico.Id;
                profissional.name = medico.Nome;
                profissional.color = cores[medico.Id] ;
            }

            return Json(profissionais.ToArray(), JsonRequestBehavior.AllowGet); 

        }

        private long ToUnixTimespan(DateTime date)
        {
            TimeSpan tspan = date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0));

            return (long)Math.Truncate(tspan.TotalSeconds);
        }

        [HttpPost]
        public ActionResult AtualizarAgendamento(CalendarEvent evento)
        {
            Agenda agendaAtualizar = agendaRepositorio.SelecionarPorId(evento.id);
            agendaAtualizar.Paciente.Nome = evento.title;

            agendaRepositorio.Atualizar(agendaAtualizar);
            return View("Index", agendaRepositorio.SelecionarTodos());
        }
         [HttpPost]
        public ActionResult ExcluirAgendamento(CalendarEvent evento)
        {

            agendaRepositorio.Excluir(agendaRepositorio.SelecionarPorId(evento.id));
            return View("Index", agendaRepositorio.SelecionarTodos());
        }
         [HttpPost]
         public ActionResult InserirAgendamento(CalendarEvent evento)
         {

             agendaRepositorio.Inserir(agendaRepositorio.SelecionarPorId(evento.id));
             return View("Index", agendaRepositorio.SelecionarTodos());
         }
    }
}
