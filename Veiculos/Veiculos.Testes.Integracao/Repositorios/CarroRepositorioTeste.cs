using Autofac;
using AutoFixture;
using NUnit.Framework;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Interfaces.Repositorios;
using Veiculos.WinService.IocConfig;

namespace Veiculos.Testes.Integracao.Repositorios
{
    [TestFixture]
    public class CarroRepositorioTeste : SetupRepositorioTeste
    {
        ICarroRepositorio repositorio;

        [OneTimeSetUp]
        public void Setup()
        {
            repositorio = Container.Resolve<ICarroRepositorio>();
        }

        [Test]
        public void SalvarCarro()
        {
            var carro = Fixture.Create<Carro>();
            Assert.DoesNotThrowAsync(async () => await repositorio.Salvar(carro));
        }
    }
}
