using Autofac;
using AutoFixture;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Veiculos.WinService.IocConfig;

namespace Veiculos.Testes.Integracao.Setup
{
    public class SetupBaseTeste
    {
        protected IFixture Fixture;
        protected IContainer Container;


        [OneTimeSetUp]
        public void SetupBase()
        {
            Fixture = new Fixture();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Container = new IocContainer(configuration).GetContainer();
        }
    }
}
