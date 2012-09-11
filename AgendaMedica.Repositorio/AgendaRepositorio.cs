using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgendaMedica.Model;
namespace AgendaMedica.Repositorio
{
    public class AgendaRepositorio:Repositorio<Agenda>
    {
        private IList<Agenda> agendas;
        public AgendaRepositorio()
        {
           
              
            this.agendas=new List<Agenda>
                             {
                                 new Agenda{
                                     Id=1,
                                     Especialidade = new MedicoRepositorio().SelecionarPorId(1).Especialidades.FirstOrDefault() ,
                                     Medico = new MedicoRepositorio().SelecionarPorId(1),
                                     DataInicio = new DateTime(2012,9,3,9,30,00 ),
                                     DataFim = new DateTime(2012,9,3,10,00,00 ),
                                     LocalAtendimento = new MedicoRepositorio().SelecionarPorId(1).LocaisAtendimento.FirstOrDefault(),
                                     Situacao = new SituacaoAgenda{Id =1,Situacao ="Cosnulta Agendada"},
                                     Paciente = new PacienteRepositorio().SelecionarPorId(1),
                                     DataAtulizacao = DateTime.Now
                                     
                                 },
                                  new Agenda{
                                     Id=2,
                                     Especialidade =  new MedicoRepositorio().SelecionarPorId(1).Especialidades.FirstOrDefault(),
                                     Medico = new MedicoRepositorio().SelecionarPorId(1),
                                     DataInicio = new DateTime(2012,9,3,10,00,00 ),
                                     DataFim = new DateTime(2012,9,3,10,30,00 ),
                                     LocalAtendimento = new MedicoRepositorio().SelecionarPorId(1).LocaisAtendimento.FirstOrDefault(),
                                     Situacao = new SituacaoAgenda{Id =1,Situacao ="Aguardando Aprovacao"},
                                     Paciente = new PacienteRepositorio().SelecionarPorId(2),
                                     DataAtulizacao = DateTime.Now
                                     
                                 },

                             }; 
        }

        public override void Inserir(Agenda Entity)
        {
            var novoId = agendas.Max(m => m.Id) + 1;
            Entity.Id = novoId;

            if (agendas.Where(m => m.Id == Entity.Id).Count() > 0)
                throw new InvalidOperationException("Já existe um agendamento cadastrado com o mesmo ID");

            this.agendas.Add(Entity); ;
        }

        public override void Atualizar(Agenda Entity)
        {
            if (agendas.Where(m => m.Id == Entity.Id).Count() <= 0)
                throw new InvalidOperationException("Não existe um agendamento cadastrado com o ID: " + Entity.Id);

            this.agendas.Where(m => m.Id == Entity.Id).FirstOrDefault().Id = Entity.Id;
            this.agendas.Where(m => m.Id == Entity.Id).FirstOrDefault().Especialidade = Entity.Especialidade;
            this.agendas.Where(m => m.Id == Entity.Id).FirstOrDefault().Medico= Entity.Medico;
            this.agendas.Where(m => m.Id == Entity.Id).FirstOrDefault().DataInicio= Entity.DataInicio;
            this.agendas.Where(m => m.Id == Entity.Id).FirstOrDefault().DataFim = Entity.DataFim;
            this.agendas.Where(m => m.Id == Entity.Id).FirstOrDefault().LocalAtendimento= Entity.LocalAtendimento;
            this.agendas.Where(m => m.Id == Entity.Id).FirstOrDefault().Situacao= Entity.Situacao;
            this.agendas.Where(m => m.Id == Entity.Id).FirstOrDefault().Paciente = Entity.Paciente;
            this.agendas.Where(m => m.Id == Entity.Id).FirstOrDefault().DataAtulizacao = Entity.DataAtulizacao;
                       
        }

        public override Agenda SelecionarPorId(int Id)
        {
            return agendas.Where(m => m.Id == Id).FirstOrDefault();
        }

        public override IList<Agenda> SelecionarTodos()
        {
            return agendas; 
        }

        public override void Excluir(Agenda Entity)
        {
            var agendaExcluir = agendas.Where(m => m.Id == Entity.Id).FirstOrDefault();

            if (agendaExcluir == null)
                throw new InvalidOperationException("Não existe este agendamento cadastrado no banco de dados");

            agendas.Remove(agendaExcluir);
        }
    }
}
