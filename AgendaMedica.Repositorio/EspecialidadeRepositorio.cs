using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgendaMedica.Model;

namespace AgendaMedica.Repositorio
{
    public class EspecialidadeRepositorio: Repositorio<Especialidade>
    {
        public IList<Especialidade> especialidades;

        #region Contrutor
        public EspecialidadeRepositorio()
        {
            especialidades = new List<Especialidade> {
                new Especialidade{ Id = 1, Nome = "Cardiologia"},
                new Especialidade{ Id = 2, Nome = "Neurologia"},
                new Especialidade{ Id = 3, Nome = "Dermatologia"},
                new Especialidade{ Id = 4, Nome = "Urologia"},
                new Especialidade{ Id = 5, Nome = "Pediatria"},
                new Especialidade{ Id = 6, Nome = "Otorrinolaringologia"},
                new Especialidade{ Id = 7, Nome = "Homeopatia"}
            };
        }
        #endregion

        #region Inserir
        public override void Inserir(Especialidade Entity)
        {
            var novoId = especialidades.Max(e => e.Id) + 1;
            Entity.Id = novoId;

            if (especialidades.Where(e => e.Id == Entity.Id).Count() > 0)
                throw new InvalidOperationException("A especialidade " + Entity.Nome + " já está cadastrada no banco de daos.");

            especialidades.Add(Entity);
        }
        #endregion

        #region Atualizar
        public override void Atualizar(Especialidade Entity)
        {
            if (especialidades.Where(e => e.Id == Entity.Id).Count() <= 0)
                throw new InvalidOperationException("A especialidade " + Entity.Nome + " não está cadastrada no banco de dados.");

            especialidades.Where(e => e.Id == Entity.Id).FirstOrDefault().Id = Entity.Id;
            especialidades.Where(e => e.Id == Entity.Id).FirstOrDefault().Nome = Entity.Nome;
        }
        #endregion

        #region SelecionarPorId
        public override Especialidade SelecionarPorId(int Id)
        {
            return especialidades.Where(e => e.Id == Id).FirstOrDefault();
        }
        #endregion

        #region SelecionarTodos
        public override IList<Especialidade> SelecionarTodos()
        {
            return especialidades;
        }
        #endregion

        #region Excluir
        public override void Excluir(Especialidade Entity)
        {
            var especialidadeExcluir = especialidades.Where(e => e.Id == Entity.Id).FirstOrDefault();

            if (especialidadeExcluir == null)
                throw new InvalidOperationException("Não existe a especialidade " + Entity.Nome + "cadastrada no banco de dados");

            especialidades.Remove(especialidadeExcluir);
        }
        #endregion
    }
}
