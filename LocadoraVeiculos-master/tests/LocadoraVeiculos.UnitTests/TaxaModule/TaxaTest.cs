using FluentAssertions;
using LocadoraVeiculos.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Tests.TaxaModule
{
    [TestClass]
    public class TaxaTest
    {
        [TestMethod]
        public void DeveCalcular_TaxaPorDia()
        {
            Taxa taxa = new Taxa("Cadeirinha de Bebê", 30, TipoTaxaEnum.CobradoPorDia);

            var resultado = taxa.CalcularValor(quantidadeDias: 10);

            resultado.Should().Be(300);
        }

        [TestMethod]
        public void DeveCalcular_TaxaUnica()
        {
            Taxa taxa = new Taxa("Lavação de Carro", 30, TipoTaxaEnum.CobradoUmaVez);

            var resultado = taxa.CalcularValor(quantidadeDias: 10);

            resultado.Should().Be(30);
        }        
    }
}
