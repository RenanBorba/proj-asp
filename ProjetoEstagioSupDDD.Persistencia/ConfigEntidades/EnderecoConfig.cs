using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Endereço: Codificação de Entidade na camada de Persistência (ConfigEntidades) ● Herança
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.IdEndereco);

            /*
            HasRequired(e => e.IdPessoa).WithMany().HasForeignKey(e => e.IdPessoa).WillCascadeOnDelete(false);
            */

            Property(e => e.Cep).IsOptional().HasMaxLength(8);
            Property(e => e.Rua).IsRequired().HasMaxLength(40);
            Property(e => e.Bairro).IsRequired().HasMaxLength(25);
            Property(e => e.Numero).IsRequired().HasMaxLength(7);
            Property(e => e.Cidade).IsRequired().HasMaxLength(25);
            Property(e => e.Complemento).IsOptional().HasMaxLength(100);
        }
    }
}
