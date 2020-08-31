using Autofac;
using Microsoft.Extensions.Configuration;
using Veiculos.Aplicacao.Modules;
using Veiculos.Infra.Modules;

namespace Veiculos.WinService.IocConfig
{
    public class IocContainer
    {
        private readonly IConfiguration _configuration;
        public IocContainer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AplicacaoModule());
            builder.RegisterModule(new InfraModule(_configuration));

            return builder.Build();
        }
    }
}
