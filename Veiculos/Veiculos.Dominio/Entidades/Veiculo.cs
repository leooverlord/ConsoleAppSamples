using Veiculos.Dominio.Enums;

namespace Veiculos.Dominio.Entidades
{
    public abstract class Veiculo
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
        public abstract TipoVeiculoEnum TipoVeiculo { get; }
    }
}
