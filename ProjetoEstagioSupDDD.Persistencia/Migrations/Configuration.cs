namespace ProjetoEstagioSupDDD.Persistencia.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoEstagioSupDDD.Persistencia.Contexto.ProjetoEstagioSupContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjetoEstagioSupDDD.Persistencia.Contexto.ProjetoEstagioSupContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
