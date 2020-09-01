using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Enums;
using Veiculos.Dominio.Interfaces.Repositorios;
using Veiculos.Infra.Data.Querys.Consulta;
using Veiculos.Infra.Data.Querys.Peristencia;

namespace Veiculos.Infra.Data.Repositorios
{
    public abstract class VeiculosRepositorio<T> : IVeiculosRepositorio<T> where T : Veiculo
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        private VeiculosConsulta<T> _consulta;
        private VeiculosPersistencia<T> _persistencia;

        public VeiculosRepositorio(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;

            _consulta = new VeiculosConsulta<T>(_connection);
            _persistencia = new VeiculosPersistencia<T>(_connection, _transaction);
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            TipoVeiculoEnum tipoVeiculo = 0;

            var tipo = typeof(T).Name;

            switch (tipo)
            {
                case nameof(Carro):
                    tipoVeiculo = TipoVeiculoEnum.Carro;
                    break;

                case nameof(Moto):
                    tipoVeiculo = TipoVeiculoEnum.Moto;
                    break;

                case nameof(Aviao):
                    tipoVeiculo = TipoVeiculoEnum.Aviao;
                    break;

                case nameof(Navio):
                    tipoVeiculo = TipoVeiculoEnum.Navio;
                    break;

                case nameof(Helicoptero):
                    tipoVeiculo = TipoVeiculoEnum.Helicoptero;
                    break;

                default:
                    throw new Exception("Tipo de veiculo não encontrado!");
            }

            return await _consulta.ObterTodos(tipoVeiculo);
        }

        public async Task Salvar(T veiculo)
        {
            await _persistencia.Salvar(veiculo);
        }
    }
}
