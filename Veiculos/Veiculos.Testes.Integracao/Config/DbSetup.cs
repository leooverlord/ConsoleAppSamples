using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculos.Testes.Integracao.Config
{
    [SetUpFixture]
    public class DbSetup
    {
        private IConfiguration configuration;
        private string connectionString = string.Empty;
        public DbSetup()
        {
            configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

            connectionString = configuration.GetConnectionString("DefaultConnectionSql");
        }

        [OneTimeSetUp]
        public virtual void SetUpAmbiente()
        {
            CreateDatabase(connectionString, "Veiculos.Infra.Sql.dacpac");
        }

        [OneTimeTearDown]
        public virtual void TearDownAmbiente()
        {
            DropDatabase(connectionString);
        }

        private void CreateDatabase(string connection, string dacpac)
        {

        }

        private void DropDatabase(string connection)
        {

        }
    }
}
