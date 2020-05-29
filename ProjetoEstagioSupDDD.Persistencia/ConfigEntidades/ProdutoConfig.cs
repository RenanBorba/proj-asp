using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Produto: Codificação de Entidade na camada de Persistência (ConfigEntidades) 
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(e => e.IdProduto);

            /*
            HasRequired(e => e.IdFornecedor).WithMany().HasForeignKey(e => e.IdFornecedor).WillCascadeOnDelete(false);
            HasRequired(e => e.IdTipoProduto).WithMany().HasForeignKey(e => e.IdTipoProduto).WillCascadeOnDelete(false);
            HasRequired(e => e.IdMarca).WithMany().HasForeignKey(e => e.IdMarca).WillCascadeOnDelete(false);
            */

            Property(e => e.DescricaoProduto).IsRequired().HasMaxLength(35);
            Property(e => e.ValorCusto).IsRequired();//.HasColumnType("decimal(8, 2)"); //double
            Property(e => e.ValorVenda).IsRequired();//.HasColumnType("decimal(18, 2)"); //double

            Property(e => e.DataCadastroProduto).IsRequired().HasColumnType("datetime2");
            Property(e => e.DataValidade).IsRequired().HasColumnType("datetime2");


        }
    }
}