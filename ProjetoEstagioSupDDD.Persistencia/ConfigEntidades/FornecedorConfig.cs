using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Fornecedor: Codificação de Entidade na camada de Persistência (ConfigEntidades) 
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            HasKey(e => e.IdFornecedor);

            Property(e => e.NomeResponsavel).IsOptional().HasMaxLength(30);
            Property(e => e.InscricaoEstadual).IsOptional().HasMaxLength(13);
            Property(e => e.FornecedorAtivo).IsOptional();//.HasColumnType("bit"); //bool

            //Pessoa
            Property(e => e.TipoPessoa).IsRequired().HasMaxLength(9);//.HasColumnType("char");
            Property(e => e.DescricaoFornecedor).IsRequired().HasMaxLength(50);
            Property(e => e.Cnpj).IsOptional().HasMaxLength(14);
            Property(e => e.Cpf).IsOptional().HasMaxLength(11);
            Property(e => e.Email).IsOptional().HasMaxLength(40);
            Property(e => e.DataCadastro).IsRequired();//.HasColumnType("datetime2");

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