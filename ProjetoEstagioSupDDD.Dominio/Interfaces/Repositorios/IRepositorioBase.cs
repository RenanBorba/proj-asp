using System;
using System.Collections.Generic;

namespace ProjetoEstagioSupDDD.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Inserir(TEntity objeto);

        TEntity ConsultarPorId(int Id);
        //Descrição/Nome/Número
        TEntity ConsultarPorDescricao(string Descricao);
        //Data Cadastro/Data Pedido
        TEntity ConsultarPorData(DateTime Data);
        //Data Cadastro/Data Validade
        TEntity ConsultarEstoque(DateTime PrimeiraData, DateTime SegundaData);
        IEnumerable<TEntity> ConsultarTodos();

        void Alterar(TEntity objeto);

        void Excluir(TEntity objeto);

        //Liberar Conexão
        void Dispose();

    }
}
