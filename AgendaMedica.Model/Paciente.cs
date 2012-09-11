using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMedica.Model
{
    [Serializable]
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Int64 Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public Int32 Cep { get; set; }
        public Int16 Numero { get; set; }
        public string Complemento { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
