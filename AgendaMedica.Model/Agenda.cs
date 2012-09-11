using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMedica.Model
{
    [Serializable]
    public class Agenda
    {
        public int Id { get; set; }
        public Especialidade Especialidade { get; set; }
        public Medico Medico { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public LocalAtendimento LocalAtendimento { get; set; }
        public SituacaoAgenda Situacao { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataAtulizacao { get; set; }

    }
}
