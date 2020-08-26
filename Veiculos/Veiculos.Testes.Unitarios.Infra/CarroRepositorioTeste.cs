using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Interfaces;
using Veiculos.Infra.Repositorios;

namespace Veiculos.Testes.Unitarios.Infra
{
    [TestFixture]
    public class CarroRepositorioTeste
    {
        private ICarroRepositorio repositorio;
        
        [OneTimeSetUp]
        public void Setup()
        {
            repositorio = new CarroRepositorio();
        }

        [Test, Order(1)]
        public void DeveSerPossivelCriarCarro()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                await repositorio.Salvar(new Carro("Fusca", 1980));
                await repositorio.Salvar(new Carro("Uno", 2000));
                await repositorio.Salvar(new Carro("Monza", 1995));
            });            
        }

        [Test, Order(2)]
        public async Task DeveSerPossivelObterTodosCarro()
        {
            var result = await repositorio.ObterTodos();
            CollectionAssert.IsNotEmpty(result);
        }

 
    }
}
