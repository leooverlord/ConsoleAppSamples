using System.Collections.Generic;
using System.Threading.Tasks;
using Veiculos.Aplicacao.Interfaces.Servicos;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Interfaces;

namespace Veiculos.Aplicacao.Servicos
{
    public class CarroServico : ICarroServico
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarroServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Carro>> ObterTodos()
        {
            return await _unitOfWork.CarroRepositorio.ObterTodos();
        }

        public async Task Salvar(Carro carro)
        {
            using (_unitOfWork.BeginTransaction())
            {
                await _unitOfWork.CarroRepositorio.Salvar(carro);
                _unitOfWork.Commit();
            }
        }
    }
}
