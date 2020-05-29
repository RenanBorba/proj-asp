using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Tipo Produto: Codificação de Entidade na camada de Persistência (ConfigEntidades) ● Herança
    public class TipoProdutoConfig : EntityTypeConfiguration<TipoProduto>
    {
        public TipoProdutoConfig()
        {
            HasKey(e => e.IdTipoProduto);
            Property(e => e.DescricaoTipo).IsRequired().HasMaxLength(35);
        }
    }
}