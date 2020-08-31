using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Veiculos.Testes.Unitarios.Infra.Fakes
{
    public class CarroRepositorioFake : IDbConnection
    {        
        public async Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await SqlMapper.QueryAsync(this, sql, param, transaction, commandTimeout, commandType);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await SqlMapper.ExecuteAsync(this, sql, param, transaction, commandTimeout, commandType);
        }

        public string ConnectionString { get; set; }

        public int ConnectionTimeout => 30;

        public string Database => "DbTeste";

        public ConnectionState State => ConnectionState.Open;

        public IDbTransaction BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return this.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void ChangeDatabase(string databaseName)
        {
        }

        public void Close()
        {
            
        }

        public IDbCommand CreateCommand()
        {
            return this.CreateCommand();
        }

        public void Open()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
