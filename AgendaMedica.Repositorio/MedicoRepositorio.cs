using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgendaMedica.Model;

namespace AgendaMedica.Repositorio
{
    public class MedicoRepositorio: Repositorio.Repositorio<Medico>
    {
        private IList<Medico> medicos;

        #region Construtor
        public MedicoRepositorio()
        {
            this.medicos = new List<Medico> {
                new Medico{ Id = 1, Nome = "Dr. Adão da Silva", 
                            Cpf = 34456199948, 
                            Crm = 123456789, 
                            DataNascimento = new DateTime(1970, 5, 3), 
                            Especialidades = new List<Especialidade>{ 
                                new Especialidade{ Id = 1, Nome = "Cardiologia"}
                            }, 
                            LocaisAtendimento = new List<LocalAtendimento>{
                                new LocalAtendimento{ 
                                Cep = 07131379, 
                                Numero = 1009
                                }
                            }
                },
                new Medico{ Id = 2, Nome = "Dra. Eva Moraes da Silva", 
                            Cpf = 78965190876, 
                            Crm = 589320987, 
                            DataNascimento = new DateTime(1975, 10, 2), 
                            Especialidades = new List<Especialidade>{ 
                                new Especialidade{ Id = 1, Nome = "Pediatria"}
                            }, 
                            LocaisAtendimento = new List<LocalAtendimento>{
                                new LocalAtendimento{ 
                                Cep = 0578000, 
                                Numero = 298
                                }
                            }
                },
                new Medico{ Id = 3, Nome = "Dr. Fernando Fernandez", 
                            Cpf = 89765191736, 
                            Crm = 908659475, 
                            DataNascimento = new DateTime(1960, 12, 15), 
                            Especialidades = new List<Especialidade>{ 
                                new Especialidade{ Id = 1, Nome = "Urologia"}
                            }, 
                            LocaisAtendimento = new List<LocalAtendimento>{
                                new LocalAtendimento{ 
                                Cep = 9087654, 
                                Numero = 1902
                                }
                            }
                },
                new Medico{ Id = 4, Nome = "Dra. Franciscônia Circuncizânia", 
                            Cpf = 54678199948, 
                            Crm = 154976789, 
                            DataNascimento = new DateTime(1965, 8, 27), 
                            Especialidades = new List<Especialidade>{ 
                                new Especialidade{ Id = 1, Nome = "Neurologia"}
                            }, 
                            LocaisAtendimento = new List<LocalAtendimento>{
                                new LocalAtendimento{ 
                                Cep = 09876123, 
                                Numero = 15243
                                }
                            }
                }
            };
        }
        #endregion

        #region Inserir
        public override void Inserir(Medico Entity)
        {
            var novoId = medicos.Max(m => m.Id) + 1;
            Entity.Id = novoId;

            if (medicos.Where(m => m.Id == Entity.Id).Count() > 0)
                throw new InvalidOperationException("O médico " + Entity.Nome + " já está cadastrado");
            
            this.medicos.Add(Entity);
        }
        #endregion

        #region Atualizar
        public override void Atualizar(Medico Entity)
        {
            if (medicos.Where(m => m.Id == Entity.Id).Count() <= 0)
                throw new InvalidOperationException("O médico " + Entity.Nome +" não está cadastrado");

            this.medicos.Where(m => m.Id == Entity.Id).FirstOrDefault().Id = Entity.Id;
            this.medicos.Where(m => m.Id == Entity.Id).FirstOrDefault().Nome = Entity.Nome;
            this.medicos.Where(m => m.Id == Entity.Id).FirstOrDefault().Cpf = Entity.Cpf;
            this.medicos.Where(m => m.Id == Entity.Id).FirstOrDefault().Crm = Entity.Crm;
            this.medicos.Where(m => m.Id == Entity.Id).FirstOrDefault().DataNascimento = Entity.DataNascimento;
            this.medicos.Where(m => m.Id == Entity.Id).FirstOrDefault().Especialidades = Entity.Especialidades;
            this.medicos.Where(m => m.Id == Entity.Id).FirstOrDefault().LocaisAtendimento = Entity.LocaisAtendimento;
        }
        #endregion

        #region SelecionarPorId
        public override Medico SelecionarPorId(int Id)
        {
            return medicos.Where(m => m.Id == Id).FirstOrDefault();
        }
        #endregion

        #region SelecionarTodos
        public override IList<Medico> SelecionarTodos()
        {
            return medicos;
        }
        #endregion

        #region Excluir
        public override void Excluir(Medico Entity)
        {
            var medicoExcluir = medicos.Where(m => m.Id == Entity.Id).FirstOrDefault();

            if (medicoExcluir == null)
                throw new InvalidOperationException("O médico " + Entity.Nome + " não está cadastrado no banco de dados.");
                
            medicos.Remove(medicoExcluir);
        }
        #endregion
    }
}
