using Autofac;
using Veiculos.Aplicacao.Interfaces.Servicos;
using Veiculos.Aplicacao.Servicos;

namespace Veiculos.Aplicacao.Modules
{
    public class AplicacaoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarroServico>().As<ICarroServico>();
        }
    }
}
