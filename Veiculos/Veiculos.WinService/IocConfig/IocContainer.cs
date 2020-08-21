using Autofac;
using Veiculos.Aplicacao.Interfaces;
using Veiculos.Aplicacao.Servicos;
using Veiculos.Infra.Interfaces;
using Veiculos.Infra.Repositorios;

namespace Veiculos.WinService.IocConfig
{
    public class IocContainer
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CarroServico>().As<ICarroServico>();
            builder.RegisterType<CarroRepositorio>().As<ICarroRepositorio>();

            return builder.Build();
        }
    }
}
