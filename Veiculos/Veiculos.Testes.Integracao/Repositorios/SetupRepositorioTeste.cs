using Autofac;
using AutoFixture;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Veiculos.WinService.IocConfig;

namespace Veiculos.Testes.Integracao.Repositorios
{
    public class SetupRepositorioTeste
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
