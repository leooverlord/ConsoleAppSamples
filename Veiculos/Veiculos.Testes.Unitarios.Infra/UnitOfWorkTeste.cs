using Moq;
using NUnit.Framework;
using System.Data;
using Veiculos.Infra.Interfaces;
using Veiculos.Infra.UnitOfWorkConfig;

namespace Veiculos.Testes.Unitarios.Infra
{
    [TestFixture]
    public class UnitOfWorkTeste
    {
        private IUnitOfWork unitOfWork;
        private Mock<IDbConnection> connection;

        [OneTimeSetUp]
        public void Setup()
        {
            connection = new Mock<IDbConnection>();
            unitOfWork = new UnitOfWork(connection.Object);
        }

        [Test]
        public void DeveIniciarTransacao()
        {
            unitOfWork.BeginTransaction();

            connection.Verify(x => x.Open());
            connection.Verify(x => x.BeginTransaction(IsolationLevel.ReadCommitted));
        }

        [Test]
        public void DeveCommitarTransacao()
        {
            unitOfWork.BeginTransaction();
            unitOfWork.Commit();

            connection.Verify(x => x.Open());
            connection.Verify(x => x.BeginTransaction(IsolationLevel.ReadCommitted));
        }

        [Test]
        public void DeveDesfazerTransaction()
        {
            unitOfWork.BeginTransaction();
            unitOfWork.RollBack();

            connection.Verify(x => x.Open());
            connection.Verify(x => x.BeginTransaction(IsolationLevel.ReadCommitted));
        }

        [Test]
        public void DeveObterRepositorios()
        {
            Assert.NotNull(unitOfWork.CarroRepositorio);
        }
    }
}
