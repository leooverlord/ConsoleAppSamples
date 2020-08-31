using Autofac;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Veiculos.Infra.Interfaces.Repositorios;
using Veiculos.Infra.Repositorios;

namespace Veiculos.Infra.Modules
{
    public class InfraModule : Module
    {
        private readonly IConfiguration _configuration;
        public InfraModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarroRepositorio>().As<ICarroRepositorio>().InstancePerLifetimeScope();

            //Dapper
            builder.Register<IDbConnection>(x => new SqlConnection(_configuration.GetConnectionString("DefaultConnectionSql"))).InstancePerLifetimeScope();
            builder.Register<IDbTransaction>(x => 
            {
                var connection = x.Resolve<IDbConnection>();

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return connection.BeginTransaction(IsolationLevel.ReadCommitted);
            }).InstancePerLifetimeScope();
        }
    }
}
