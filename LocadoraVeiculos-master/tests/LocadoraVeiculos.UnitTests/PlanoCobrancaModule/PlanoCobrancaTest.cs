using FluentAssertions;
using LocadoraVeiculos.Dominio.GrupoVeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Tests.PlanoCobrancaModule
{
    [TestClass]
    public class PlanoCobrancaTest
    {
        [TestMethod]
        public void DeveCalcular_PlanoDiario()
        {
            PlanoCobranca planoCobranca = PlanoCobranca.Diario(valorDia: 50, valorKMRodado: 10);

            var resultado = planoCobranca.CalcularValor(quantidadeDias: 10, quilometragemPercorrida: 0);

            resultado.Should().Be(500);
        }

        [TestMethod]
        public void DeveCalcular_PlanoDiario_ComQuilometragemPercorrida()
        {
            PlanoCobranca planoCobranca = PlanoCobranca.Diario(100, 10);

            var resultado = planoCobranca.CalcularValor(quantidadeDias: 10, quilometragemPercorrida: 10);

            resultado.Should().Be(1100);
        }

        [TestMethod]
        public void DeveCalcular_PlanoKMControlado()
        {
            PlanoCobranca planoCobranca = PlanoCobranca.KmControlado(200, 100, 20);

            var resultado = planoCobranca.CalcularValor(quantidadeDias: 10, quilometragemPercorrida: 0);

            resultado.Should().Be(2000);
        }

        [TestMethod]
        public void DeveCalcular_PlanoKMControlado_ComQuilometragemPercorrida_DentroDoPlano()
        {
            PlanoCobranca planoCobranca = PlanoCobranca.KmControlado(200, 100, 20);

            var resultado = planoCobranca.CalcularValor(quantidadeDias: 10, quilometragemPercorrida: 90);

            resultado.Should().Be(2000);
        }

        [TestMethod]
        public void DeveCalcular_PlanoKMControlado_ComQuilometragemPercorrida_AcimaDoPlano()
        {
            PlanoCobranca planoCobranca = PlanoCobranca.KmControlado(200, 100, 20);

            var resultado = planoCobranca.CalcularValor(quantidadeDias: 10, quilometragemPercorrida: 110);

            resultado.Should().Be(2200);
        }

        [TestMethod]
        public void DeveCalcular_PlanoKMLivre()
        {
            PlanoCobranca planoCobranca = PlanoCobranca.KmLivre(300);

            var resultado = planoCobranca.CalcularValor(quantidadeDias: 10, quilometragemPercorrida:100);

            resultado.Should().Be(3000);
        }
    }  
}
