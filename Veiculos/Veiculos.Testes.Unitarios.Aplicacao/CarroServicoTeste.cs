using AutoFixture;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veiculos.Aplicacao.Interfaces.Servicos;
using Veiculos.Aplicacao.Servicos;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Interfaces;
using Veiculos.Infra.Interfaces.Repositorios;

namespace Veiculos.Testes.Unitarios.Aplicacao
{
    [TestFixture]
    public class CarroServicoTeste
    {
        ICarroServico servico;
        IFixture fixture;
        IEnumerable<Carro> carros;
        Mock<IUnitOfWork> unitOfWork;

        [OneTimeSetUp]
        public void Setup()
        {
            fixture = new Fixture { RepeatCount = 20 };
            carros = fixture.CreateMany<Carro>();

            unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.CarroRepositorio).Returns(new Mock<ICarroRepositorio>().Object);
            unitOfWork.Setup(x => x.CarroRepositorio.ObterTodos()).Returns(Task.FromResult(carros));

            servico = new CarroServico(unitOfWork.Object);
        }

        [Test]
        public void DeveSerPossivelCriarCarro()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                foreach (var c in carros)
                    await servico.Salvar(c);
            });

            unitOfWork.Verify(x => x.CarroRepositorio.Salvar(It.IsAny<Carro>()), Times.AtLeastOnce);
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
