using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMedica.Model
{
    [Serializable]
    public class LocalAtendimento
    {
        public Int32 Cep { get; set; }
        public Int16 Numero { get; set; }
        public String Complemento { get; set; }
    }
}
