using Veiculos.Dominio.Enums;

namespace Veiculos.Dominio.Entidades
{
    public class Aviao : Veiculo
    {
        public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Aviao;
        protected Aviao() { }
    }
}
