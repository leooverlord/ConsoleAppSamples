using System;

namespace Veiculos.Infra.Interfaces
{
    public interface ITransactionManager : IDisposable
    {
        IDisposable BeginTransaction();
        void Commit();
        void RollBack();
    }
}
