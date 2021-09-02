using FluentAssertions;
using LocadoraVeiculos.Dominio.CupomModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Tests.CupomModule
{
    [TestClass]
    public class CupomTest
    {
        [TestMethod]
        public void DeveCalcular_DescontoValorFixo()
        {
            Cupom cupom = new Cupom("Dez conto de desconto", 10, new DateTime(2021, 12, 31), new Parceiro("Desconto do Deko"), 100, TipoCupomEnum.ValorFixo);

            var desconto = cupom.CalcularDesconto(1000);

            desconto.Should().Be(10);
        }

        [TestMethod]
        public void DeveCalcular_DescontoValorPercentual()
        {
            Cupom cupom = new Cupom("Dez conto de desconto", 10, new DateTime(2021, 12, 31), new Parceiro("Desconto do Deko"), 100, TipoCupomEnum.Percentual);

            var desconto = cupom.CalcularDesconto(1000);

            desconto.Should().Be(100);
        }

        [TestMethod]
        public void NaoDeve_DescontarValor()
        {
            Cupom cupom = new Cupom("Dez conto de desconto", 10, new DateTime(2021, 12, 31), new Parceiro("Desconto do Deko"), 100, TipoCupomEnum.Percentual);

            var resultado = cupom.CalcularDesconto(100);

            resultado.Should().Be(0);
        }   
    }
}
