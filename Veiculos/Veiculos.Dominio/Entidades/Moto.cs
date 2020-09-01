using Veiculos.Dominio.Enums;

namespace Veiculos.Dominio.Entidades
{
    public class Moto : Veiculo
    {
        public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Moto;
        protected Moto() { }
    }
}
