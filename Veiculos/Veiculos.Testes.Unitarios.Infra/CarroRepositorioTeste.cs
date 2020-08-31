using Dapper;
using Moq;
using Moq.Dapper;
using NUnit.Framework;
using System.Data;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Interfaces.Repositorios;
using Veiculos.Infra.Repositorios;
using Veiculos.Testes.Unitarios.Infra.Fakes;

namespace Veiculos.Testes.Unitarios.Infra
{
    [TestFixture]
    public class CarroRepositorioTeste
    {
        private ICarroRepositorio repositorio;
        //private Mock<IDbConnection> connection;
        private Mock<IDbTransaction> transaction;
        private CarroRepositorioFake carroFake;

        [OneTimeSetUp]
        public void Setup()
        {
            //connection = new Mock<IDbConnection>();
            transaction = new Mock<IDbTransaction>();

            //connection.SetupDapperAsync(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<int>(), It.IsAny<CommandType>())).ReturnsAsync(1);

            carroFake = new CarroRepositorioFake();

            repositorio = new CarroRepositorio(carroFake, transaction.Object);
        }

        [Test, Order(1)]
        public void DeveSerPossivelCriarCarro()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                await repositorio.Salvar(new Carro("Fusca", 1980));
                await repositorio.Salvar(new Carro("Uno", 2000));
                await repositorio.Salvar(new Carro("Monza", 1995));
            });
        }

        [Test, Order(2)]
        public async Task DeveSerPossivelObterTodosCarro()
        {
            var result = await repositorio.ObterTodos();
            CollectionAssert.IsNotEmpty(result);
        }


    }
}
