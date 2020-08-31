using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer.Dac;
using NUnit.Framework;
using System;

namespace Veiculos.Testes.Integracao
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

        private void CreateDatabase(string connectionString, string dacPac)
        {
            var connectionBuilder = new SqlConnectionStringBuilder(connectionString);
            var dataBaseName = connectionBuilder.InitialCatalog;

            connectionBuilder.InitialCatalog = string.Empty;
            var dacService = new DacServices(connectionBuilder.ConnectionString);

            var options = new DacDeployOptions() { CreateNewDatabase = true };

            var dacPacFile = $@"{AppDomain.CurrentDomain.BaseDirectory}\{dacPac}";

            using (var dacPackage = DacPackage.Load(dacPacFile))
            {
                dacService.Deploy(dacPackage, dataBaseName, true, options);
            }
        }

        private void DropDatabase(string connectionString)
        {
            var connectionBuilder = new SqlConnectionStringBuilder(connectionString);
            var dataBaseName = connectionBuilder.InitialCatalog;

            connectionBuilder.InitialCatalog = "master";

            var sqlConnection = new SqlConnection(connectionBuilder.ConnectionString);
            var sqlKill = $@"DECLARE @kill varchar(50);
                            SELECT @kill = 'kill ' + CONVERT(varchar(5), session_id) + ';'
                                FROM sys.dm_exec_sessions
                                WHERE database_id = db_id('{dataBaseName}')
                            EXEC(@kill);";
            var sqlDrop = $"DROP DATABASE {dataBaseName}";

            var command = sqlConnection.CreateCommand();
            command.CommandText = sqlKill;

            sqlConnection.Open();
            command.ExecuteNonQuery();

            command.CommandText = sqlDrop;

            command.ExecuteNonQuery();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
    }
}
