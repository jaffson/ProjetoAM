using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMedica.Model
{
    [Serializable]
    public class PlanoSaude
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public Convenio Convenio { get; set; }

    }
}
