using Veiculos.Dominio.Enums;

namespace Veiculos.Dominio.Entidades
{
    public class Helicoptero : Veiculo
    {
        public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Helicoptero;
        protected Helicoptero() { }
    }
}
