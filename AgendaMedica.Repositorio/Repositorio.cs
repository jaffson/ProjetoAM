using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaMedica.Repositorio
{
    public abstract class Repositorio<T>
    {
        public abstract void Inserir(T Entity);
        public abstract void Atualizar(T Entity);
        public abstract T SelecionarPorId(int Id);
        public abstract IList<T> SelecionarTodos();
        public abstract void Excluir(T Entity);
    }
}
