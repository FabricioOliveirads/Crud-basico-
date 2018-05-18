using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Data.Mappings;
using Teste.Negocio;

namespace Teste.Data
{
   public class TesteContext: DbContext

    {
        public TesteContext()
            : base("BancoTesteConnectionString")
        {
            DbConfiguration.SetConfiguration(new ConfigurationInstance());
            Configuration.AutoDetectChangesEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Aqui seta o mapeamento da classe feito pelo Fluent api
            modelBuilder.Configurations.Add(new ClienteMap());


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }

    }

    public class ConfigurationInstance: DbConfiguration
    {
        public ConfigurationInstance()
        {
            SetProviderServices(System.Data.Entity.SqlServer.SqlProviderServices.ProviderInvariantName,
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
}
