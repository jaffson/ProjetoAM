using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMedica.Model
{
    [Serializable]
    public class Medico
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public Int64 Cpf { get; set; }
        public Int64 Crm { get; set; }
        public DateTime DataNascimento { get; set; }
        public IList<Especialidade> Especialidades { get; set; }
        public IList<LocalAtendimento> LocaisAtendimento { get; set; }
    }
}
