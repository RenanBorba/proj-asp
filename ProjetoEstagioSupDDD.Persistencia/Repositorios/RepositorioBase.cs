using ProjetoEstagioSupDDD.Dominio.Interfaces.Repositorios;
using ProjetoEstagioSupDDD.Persistencia.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEstagioSupDDD.Persistencia.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity>
        where TEntity : class
    {
        protected ProjetoEstagioSupContexto bd = new ProjetoEstagioSupContexto();


        public void Inserir(TEntity objeto)
        {
            bd.Set<TEntity>().Add(objeto);
            bd.SaveChanges();
        }

        public TEntity ConsultarPorId(int Id)
        {
            return bd.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> ConsultarTodos()
        {
            return bd.Set<TEntity>().ToList();
        }

        public TEntity ConsultarPorDescricao(string Descricao)
        {
            return bd.Set<TEntity>().Find(Descricao);
        }

        public TEntity ConsultarPorData(DateTime Data)
        {
            return bd.Set<TEntity>().Find(Data);
        }

        public TEntity ConsultarEstoque(DateTime DataCadastro, DateTime DataValidade)
        {
            return bd.Set<TEntity>().Find(DataCadastro, DataValidade);
        }  
    

        public void Alterar(TEntity objeto)
        {
            bd.Entry(objeto).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();
        }


        public void Excluir(TEntity objeto)
        {
            bd.Set<TEntity>().Remove(objeto);
            bd.SaveChanges();
        }

        public void Dispose()
        {
            bd.Dispose();
        }

    }
}
