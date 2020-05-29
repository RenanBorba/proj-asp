using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Funcionário: Codificação de Entidade na camada de Persistência (ConfigEntidades) 
    public class FuncionarioConfig : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfig()
        {
            HasKey(e => e.IdFuncionario);

            Property(e => e.Nome).IsRequired().HasMaxLength(40);
            Property(e => e.Email).IsOptional().HasMaxLength(40);
            Property(e => e.Login).IsRequired().HasMaxLength(15);
            Property(e => e.Senha).IsRequired().HasMaxLength(10);
            Property(e => e.Administrador).IsRequired();//.HasColumnType("bit"); //bool

            Property(e => e.TipoTelefone).IsRequired().HasMaxLength(15);
            Property(e => e.NumeroTelefone).IsRequired().HasMaxLength(11);
            Property(e => e.AcessoWpp).IsOptional();//.HasColumnType("bit"); //bool
        }
    }
}