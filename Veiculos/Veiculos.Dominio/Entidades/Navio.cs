using Veiculos.Dominio.Enums;

namespace Veiculos.Dominio.Entidades
{
    public class Navio : Veiculo
    {
        public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Navio;
        protected Navio() { }
    }
}
