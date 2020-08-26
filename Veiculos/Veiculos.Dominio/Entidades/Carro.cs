using Veiculos.Dominio.Enums;

namespace Veiculos.Dominio.Entidades
{
    public class Carro : Veiculo
    {
        public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Carro;

        public Carro(string nome, int ano)
        {
            Nome = nome;
            Ano = ano;
        }

        public override string ToString()
        {
            return $"Carro: Nome: {Nome}, Ano: {Ano}";
        }
    }
}
