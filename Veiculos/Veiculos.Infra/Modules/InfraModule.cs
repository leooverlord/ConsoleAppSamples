using Autofac;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Veiculos.Infra.Interfaces;
using Veiculos.Infra.UnitOfWorkConfig;

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
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.Register<IDbConnection>(x => new SqlConnection(_configuration.GetConnectionString("DefaultConnectionSql"))).InstancePerLifetimeScope();
        }
    }
}
