using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Marca: Codificação de Entidade na camada de Persistência (ConfigEntidades) ● Herança
    public class MarcaConfig : EntityTypeConfiguration<Marca>
    {
        public MarcaConfig()
        {
            HasKey(e => e.IdMarca);
            Property(e => e.DescricaoMarca).IsRequired().HasMaxLength(35);
        }
    }
}