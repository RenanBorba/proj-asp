using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Pedido: Codificação de Entidade na camada de Persistência (ConfigEntidades) 
    public class PedidoConfig : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfig()
        {
            HasKey(e => e.IdPedido);

            /*
            HasRequired(e => e.IdFuncionario).WithMany().HasForeignKey(e => e.IdFuncionario).WillCascadeOnDelete(false);
            HasRequired(e => e.IdCliente).WithMany().HasForeignKey(e => e.IdCliente).WillCascadeOnDelete(false);
            HasRequired(e => e.IdPagamento).WithMany().HasForeignKey(e => e.IdPagamento).WillCascadeOnDelete(false);
            */

            Property(e => e.DataVenda).IsRequired().HasColumnType("datetime2");
            Property(e => e.Cliente).IsOptional().HasMaxLength(50);

            Property(e => e.QtdParcela).IsRequired().HasColumnType("int");
            Property(e => e.DescricaoPagamento).IsOptional().HasMaxLength(20);

            //Cheque
            Property(e => e.NumeroCheque).IsOptional().HasMaxLength(20);
            Property(e => e.CpfCnpjCheque).IsOptional().HasMaxLength(14);
            Property(e => e.NomeEmitente).IsOptional().HasMaxLength(35);
            Property(e => e.ContaCheque).IsOptional().HasMaxLength(40);
            Property(e => e.ValidadeCheque).IsOptional().HasColumnType("datetime2");

            //Cartão
            Property(e => e.NumeroCartao).IsOptional().HasMaxLength(20);
            Property(e => e.ContaCartao).IsOptional().HasMaxLength(40);
            Property(e => e.NomeImpresso).IsOptional().HasMaxLength(20);
            Property(e => e.ValidadeCartao).IsOptional().HasColumnType("datetime2");
            Property(e => e.CartaoAtivo).IsOptional();//.HasColumnType("bit"); //bool
        }
    }
}
