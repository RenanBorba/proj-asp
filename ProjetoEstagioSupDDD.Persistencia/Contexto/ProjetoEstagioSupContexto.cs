using ProjetoEstagioSupDDD.Dominio.Entidades;
using ProjetoEstagioSupDDD.Persistencia.ConfigEntidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetoEstagioSupDDD.Persistencia.Contexto
{
    public class ProjetoEstagioSupContexto : DbContext
    {
        //Codificação da String de Conexão na camada de Persistência (Contexto)
        public ProjetoEstagioSupContexto()
            : base("ProjetoEstagioSupDDD")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AdicionarProduto>()
                //.HasForeignKey(p => p.IdProdutoFK);

            //Remover Pluralizar -> Nome-Tabela
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Remover Deletar -> Tabela-Relacionamento 
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
           
            //Definir string -> varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Definir -> Tamanho 
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            /*
             * Definir -> Mask Decimal-Double
            modelBuilder.Properties<double>().Configure(p => p.HasColumnType("decimal")
                .HasPrecision(9, 4)); */

           //Incluir classes -> ConfigEntidades
            modelBuilder.Configurations.Add(new FuncionarioConfig());
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new ServicoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            modelBuilder.Configurations.Add(new TipoProdutoConfig());
            modelBuilder.Configurations.Add(new MarcaConfig());
            modelBuilder.Configurations.Add(new PedidoConfig());

            base.OnModelCreating(modelBuilder);
        }
   
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TiposProduto { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }     
    }
}
