using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Telefone: Codificação de Entidade na camada de Persistência (ConfigEntidades) ● Herança
    public class TelefoneConfig : EntityTypeConfiguration<Telefone>
    {
        public TelefoneConfig()
        {
            HasKey(e => e.IdTelefone);
            Property(e => e.TipoTelefone).IsRequired().HasMaxLength(15);
            Property(e => e.DDD).IsRequired().HasMaxLength(3);
            Property(e => e.Numero).IsRequired().HasMaxLength(9);
            Property(e => e.AcessoWpp).IsOptional();//.HasColumnType("bit"); //bool

        }

    }
}
