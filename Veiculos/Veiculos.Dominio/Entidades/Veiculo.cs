using System;
using Veiculos.Dominio.Enums;

namespace Veiculos.Dominio.Entidades
{
    public abstract class Veiculo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public abstract TipoVeiculoEnum TipoVeiculo { get; }

        public Veiculo()
        {
            Id = Guid.NewGuid();
        }
    }
}
