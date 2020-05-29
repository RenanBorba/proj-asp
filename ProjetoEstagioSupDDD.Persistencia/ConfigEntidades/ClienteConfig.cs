using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Cliente: Codificação de Entidade na camada de Persistência (ConfigEntidades) 
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(e => e.IdCliente);

            /*
            HasRequired(e => e.IdPessoa).WithMany().HasForeignKey(e => e.IdPessoa).WillCascadeOnDelete(false);
            */

            Property(e => e.DataNascimento).IsOptional().HasColumnType("datetime2");
            Property(e => e.Sexo).IsOptional().HasMaxLength(10);//.HasColumnType("char");
            Property(e => e.ClienteAtivo).IsOptional();//.HasColumnType("bit"); //bool

            //Pessoa
            Property(e => e.TipoPessoa).IsRequired().HasMaxLength(9);//.HasColumnType("char");
            Property(e => e.Nome).IsRequired().HasMaxLength(50);
            Property(e => e.Cnpj).IsOptional().HasMaxLength(14);
            Property(e => e.Cpf).IsOptional().HasMaxLength(11);
            Property(e => e.Email).IsOptional().HasMaxLength(40);
            Property(e => e.DataCadastro).IsOptional();//.HasColumnType("datetime2");

            //Endereço
            Property(e => e.Cep).IsOptional().HasMaxLength(8);
            Property(e => e.Endereco).IsRequired().HasMaxLength(70);
            Property(e => e.Cidade).IsRequired().HasMaxLength(30);
            Property(e => e.Complemento).IsOptional().HasMaxLength(100);

            //Telefone
            Property(e => e.TipoTelefone).IsRequired().HasMaxLength(15);
            Property(e => e.NumeroTelefone).IsRequired().HasMaxLength(11);
            Property(e => e.AcessoWpp).IsOptional();//.HasColumnType("bit"); //bool
        }
    }
}
