using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMedica.Model
{
    [Serializable]
    public class SituacaoAgenda
    {
        public int Id { get; set; }
        public string Situacao { get; set; }

    }
}
