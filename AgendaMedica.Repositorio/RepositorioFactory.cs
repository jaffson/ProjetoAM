using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMedica.Repositorio
{
    public class RepositorioFactory
    {
        private static MedicoRepositorio medicoRepositorio;
        private static EspecialidadeRepositorio especialidadeRepositorio;
        private static PacienteRepositorio pacienteRepositorio;
        private static AgendaRepositorio agendaRepositorio;

        public static MedicoRepositorio InstanciarRepositorioDeMedicos()
        {
            if (medicoRepositorio == null)
                medicoRepositorio = new MedicoRepositorio();

            return medicoRepositorio;
        }

        public static EspecialidadeRepositorio InstaciarRepositorioDeEspecialidades()
        {
            if (especialidadeRepositorio == null)
                especialidadeRepositorio = new EspecialidadeRepositorio();

            return especialidadeRepositorio;
        }

        public static PacienteRepositorio InstanciarRepositorioDePacientes()
        {
            if (pacienteRepositorio == null)
                pacienteRepositorio = new PacienteRepositorio();

            return pacienteRepositorio;
        }

        public static AgendaRepositorio InstanciarRepositorioDeAgendas()
        {
            if (agendaRepositorio == null)
                agendaRepositorio = new AgendaRepositorio();

            return agendaRepositorio;
        }
    }
}
