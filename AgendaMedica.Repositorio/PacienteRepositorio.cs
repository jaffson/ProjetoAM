using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgendaMedica.Model;
namespace AgendaMedica.Repositorio
{
    public class PacienteRepositorio : Repositorio.Repositorio<Paciente>
    {
        private IList<Paciente> pacientes;
        public PacienteRepositorio()
        {
            this.pacientes = new List<Paciente>
                                 {
                                     new Paciente
                                         {
                                             Id = 1,
                                             Nome = "Alberto Roberto",
                                             Cpf = 30315587822,
                                             DataNascimento = new DateTime(1980, 3, 30),
                                             Cep = 04274040,
                                             Numero = 228,
                                             Complemento = "Bloco 2 ap 64",
                                             Email = "albertoroberto@gmail.com",
                                             DataCadastro = DateTime.Now
                                         },

                                     new Paciente
                                         {
                                             Id = 2,
                                             Nome = "Maria da Silva",
                                             Cpf = 30315539912,
                                             DataNascimento = new DateTime(1950, 6, 30),
                                             Cep = 04296050,
                                             Numero = 300,
                                             Complemento = "casa 20",
                                             Email = "mariadasilva@uol.com",
                                             DataCadastro = DateTime.Now
                                         },

                                     new Paciente
                                         {
                                             Id = 3,
                                             Nome = "Carlos da Silva Sauro",
                                             Cpf = 240020202020,
                                             DataNascimento = new DateTime(1990, 7, 15),
                                             Cep = 04296050,
                                             Numero = 400,
                                             Complemento = "beco 7",
                                             Email = "sauro@uol.com",
                                             DataCadastro = DateTime.Now
                                         }
                                 };



        }

        public override void Inserir(Paciente Entity)
        {
            var novoId = pacientes.Max(m => m.Id) + 1;
            Entity.Id = novoId;

            if (pacientes.Where(m => m.Id == Entity.Id).Count() > 0)
                throw new InvalidOperationException("Já existe um paciente cadastrado com o mesmo ID");

            this.pacientes.Add(Entity);
        }

        public override void Atualizar(Paciente Entity)
        {
            if (pacientes.Where(m => m.Id == Entity.Id).Count() <= 0)
                throw new InvalidOperationException("Não existe um paciente cadastrado com o ID: " + Entity.Id);

            this.pacientes.Where(m => m.Id == Entity.Id).FirstOrDefault().Id = Entity.Id;
            this.pacientes.Where(m => m.Id == Entity.Id).FirstOrDefault().Nome = Entity.Nome;
            this.pacientes.Where(m => m.Id == Entity.Id).FirstOrDefault().Cpf = Entity.Cpf;
            this.pacientes.Where(m => m.Id == Entity.Id).FirstOrDefault().DataNascimento = Entity.DataNascimento;
            this.pacientes.Where(m => m.Id == Entity.Id).FirstOrDefault().Cep = Entity.Cep;
            this.pacientes.Where(m => m.Id == Entity.Id).FirstOrDefault().Numero = Entity.Numero;
            this.pacientes.Where(m => m.Id == Entity.Id).FirstOrDefault().Complemento = Entity.Complemento;
            this.pacientes.Where(m => m.Id == Entity.Id).FirstOrDefault().Email = Entity.Email;
            this.pacientes.Where(m => m.Id == Entity.Id).FirstOrDefault().DataCadastro = Entity.DataCadastro;

        }



        public override Paciente SelecionarPorId(int Id)
        {
            return pacientes.Where(m => m.Id == Id).FirstOrDefault();
        }

        public override IList<Paciente> SelecionarTodos()
        {
            return pacientes;
        }

        public override void Excluir(Paciente Entity)
        {
            var pacienteExcluir = pacientes.Where(m => m.Id == Entity.Id).FirstOrDefault();

            if (pacienteExcluir == null)
                throw new InvalidOperationException("Não existe este paciente cadastrado no banco de dados");

            pacientes.Remove(pacienteExcluir);
        }
    }
}
