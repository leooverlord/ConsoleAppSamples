using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Veiculos.Aplicacao.Interfaces.Servicos;
using Veiculos.Dominio.Entidades;
using Veiculos.WinService.IocConfig;

namespace Veiculos.WinService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            var container = new IocContainer(configuration).GetContainer();

            var servico = container.Resolve<ICarroServico>();

            await servico.Salvar(new Carro("Fusca", 1980));
            await servico.Salvar(new Carro("Uno", 2000));
            await servico.Salvar(new Carro("Monza", 1995));

            Console.WriteLine("Carro Salvo com sucesso");

            var carros = await servico.ObterTodos();

            foreach (var c in carros)
            {
                Console.WriteLine(c.ToString());
            }

            Console.ReadKey();
        }
    }
}
