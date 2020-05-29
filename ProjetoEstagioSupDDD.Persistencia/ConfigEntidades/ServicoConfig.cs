using ProjetoEstagioSupDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoEstagioSupDDD.Persistencia.ConfigEntidades
{
    //Serviço: Codificação de Entidade na camada de Persistência (ConfigEntidades) 
    public class ServicoConfig : EntityTypeConfiguration<Servico>
    {
        public ServicoConfig()
        {
            HasKey(e => e.IdServico);
            Property(e => e.DescricaoServico).IsRequired().HasMaxLength(35);
            Property(e => e.ObservacaoServico).IsOptional().HasMaxLength(100);
            Property(e => e.ValorServico).IsRequired();//.HasColumnType("decimal(18, 2)"); //double
        }

    }
}
