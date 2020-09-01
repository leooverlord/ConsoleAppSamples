using System.Collections.Generic;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Enums;
using Veiculos.Infra.Interfaces;

namespace Veiculos.Aplicacao.Servicos
{
    public class VeiculosServico
    {
        private readonly IUnitOfWork _unitOfWork;
        public VeiculosServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Veiculo>> ObterTodos(TipoVeiculoEnum tipoVeiculo)
        {
            IEnumerable<Veiculo> veiculos = null;
            switch (tipoVeiculo)
            {
                case TipoVeiculoEnum.Carro:
                    veiculos = await _unitOfWork.CarroRepositorio.ObterTodos();
                    break;

                case TipoVeiculoEnum.Moto:
                    veiculos = await _unitOfWork.MotoRepositorio.ObterTodos();
                    break;

                case TipoVeiculoEnum.Aviao:
                    veiculos = await _unitOfWork.AviaoRepositorio.ObterTodos();
                    break;

                case TipoVeiculoEnum.Navio:
                    veiculos = await _unitOfWork.NavioRepositorio.ObterTodos();
                    break;

                case TipoVeiculoEnum.Helicoptero:
                    veiculos = await _unitOfWork.HelicopteroRepositorio.ObterTodos();
                    break;
            }
            return veiculos;
        }

        public async Task Salvar(Veiculo veiculo)
        {
            using (_unitOfWork.BeginTransaction())
            {
                switch (veiculo.TipoVeiculo)
                {
                    case TipoVeiculoEnum.Carro:
                        await _unitOfWork.CarroRepositorio.Salvar((Carro)veiculo);
                        break;

                    case TipoVeiculoEnum.Moto:
                        await _unitOfWork.MotoRepositorio.Salvar((Moto)veiculo);
                        break;

                    case TipoVeiculoEnum.Aviao:
                        await _unitOfWork.AviaoRepositorio.Salvar((Aviao)veiculo);
                        break;

                    case TipoVeiculoEnum.Navio:
                        await _unitOfWork.NavioRepositorio.Salvar((Navio)veiculo);
                        break;

                    case TipoVeiculoEnum.Helicoptero:
                        await _unitOfWork.HelicopteroRepositorio.Salvar((Helicoptero)veiculo);
                        break;
                }
                _unitOfWork.Commit();
            }
        }


    }
}
