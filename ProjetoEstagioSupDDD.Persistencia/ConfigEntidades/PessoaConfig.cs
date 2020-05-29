using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Pessoa: Codificação de Entidade na camada de Persistência (ConfigEntidades)  
    public class PessoaConfig : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfig()
        {
            HasKey(e => e.IdPessoa);

            Property(e => e.TipoPessoa).IsRequired().HasMaxLength(9);//.HasColumnType("char");
            Property(e => e.Nome).IsRequired().HasMaxLength(50);
            Property(e => e.Cnpj).IsOptional().HasMaxLength(14);
            Property(e => e.Cpf).IsOptional().HasMaxLength(11);
            Property(e => e.Email).IsOptional().HasMaxLength(40);
            Property(e => e.DataCadastro).IsOptional();//.HasColumnType("datetime2");
        }
    }
}
