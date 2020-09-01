using Autofac;
using AutoFixture;
using NUnit.Framework;
using System.Threading.Tasks;
using Veiculos.Aplicacao.Interfaces.Servicos;
using Veiculos.Dominio.Entidades;
using Veiculos.Testes.Integracao.Setup;

namespace Veiculos.Testes.Integracao.Servicos
{
    public class CarroServicoTeste : SetupBaseTeste
    {
        ICarroServico servico;

        [OneTimeSetUp]
        public void Setup()
        {
            servico = Container.Resolve<ICarroServico>();
        }

        [Test]
        public async Task ObterCarros()
        {
            var carros = await servico.ObterTodos();
            CollectionAssert.IsNotEmpty(carros);
        }

        [Test]
        public void SalvarCarro()
        {
            var carro = Fixture.Create<Carro>();
            Assert.DoesNotThrowAsync(async () => await servico.Salvar(carro));
        }
    }
}
