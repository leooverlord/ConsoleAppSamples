using AutoFixture;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veiculos.Aplicacao.Interfaces.Servicos;
using Veiculos.Aplicacao.Servicos;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Interfaces.Repositorios;

namespace Veiculos.Testes.Unitarios.Aplicacao
{
    [TestFixture]
    public class CarroServicoTeste
    {
        ICarroServico servico;
        Mock<ICarroRepositorio> repositorio;
        IFixture fixture;
        IEnumerable<Carro> carros;

        [OneTimeSetUp]
        public void Setup()
        {
            fixture = new Fixture { RepeatCount = 20 };
            carros = fixture.CreateMany<Carro>();

            repositorio = new Mock<ICarroRepositorio>();
            repositorio.Setup(x => x.ObterTodos()).Returns(Task.FromResult(carros));

            servico = new CarroServico(repositorio.Object);
        }

        [Test]
        public void DeveSerPossivelCriarCarro()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                await servico.Salvar(new Carro("Fusca", 1980));
                await servico.Salvar(new Carro("Uno", 2000));
                await servico.Salvar(new Carro("Monza", 1995));
            });

            repositorio.Verify(x => x.Salvar(It.IsAny<Carro>()), Times.AtLeastOnce);
        }

        [Test]
        public async Task DeveSerPossivelObterTodosCarro()
        {
            var result = await servico.ObterTodos();
            Assert.NotNull(result);
            CollectionAssert.IsNotEmpty(result);
            Assert.AreEqual(result, carros);
        }

    }
}
