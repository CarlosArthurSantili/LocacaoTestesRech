using FluentAssertions;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculos.TestDataBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace LocadoraVeiculos.Tests.LocacaoModule
{
    [TestClass]
    public class LocacaoTest
    {
        private Locacao locacao;
        private Funcionario beto;
        private Cliente flamengo;
        private Condutor brunoHenrique;
        private Veiculo kicksBranco;
        private DateTime hoje;
        private DateTime daquiSeteDias;
        private DateTime ontem;
        private DateTime amanha;

        public LocacaoTest()
        {
            beto = new Funcionario("Alberto", "beto", "123456", DateTime.Now.Date, 600.0);
            flamengo = new Cliente("Flamengo", "Gávea", "9524282242", "", "", "1234567891234", Dominio.TipoPessoaEnum.Juridica);
            brunoHenrique = new Condutor("Bruno Henrique", "Gávea", "999292107", "3717158", "04791277945", "123456789", new DateTime(2022, 05, 26), flamengo);
            kicksBranco = new Veiculo("QYV9630", "Kicks", "Nissam", 50.000, 50, TipoCombustivelEnum.Gasolina, null);
            hoje = DateTime.Now.Date;
            daquiSeteDias = DateTime.Now.Date.AddDays(7);
            ontem = DateTime.Now.Date.AddDays(-1);
            amanha = DateTime.Now.Date.AddDays(1);
        }

        [TestMethod]
        public void DeveValidar_CamposObrigatorios_Locacao()
        {
            locacao = new LocacaoDataBuilder().Build();

            string resultado = locacao.Validar();

            resultado.Should().Be(
                "Selecione um funcionário" + Environment.NewLine +
                "Selecione um condutor" + Environment.NewLine +
                "Selecione um veículo" + Environment.NewLine +
                "Selecione o plano de cobrança" + Environment.NewLine +
                "Selecione a data da locação" + Environment.NewLine +
                "Selecione a data prevista da entrega"
                );
        }

        [TestMethod]
        public void DataPrevista_NaoPodeSerMenor_DataLocacao()
        {
            locacao = new LocacaoDataBuilder()
                .DoFuncionario(beto)                
                .NaData(hoje)
                .ParaCondutor(brunoHenrique)
                .DoVeiculo(kicksBranco)
                .ComPlanoDeCobranca(PlanoCobranca.Diario(100, 10))
                .NaData(hoje)
                .ComDataDeDevolucaoPrevista(ontem)
                .Build();

            string resultado = locacao.Validar();

            resultado.Should().Be("A data prevista da entrega não pode ser menor que data da locação");
        }

        [TestMethod]
        public void NaoDeve_RegistrarLocacao_ParaVeiculoAlugado()
        {
            //arrange
            kicksBranco.RegistrarLocacao(new Locacao() { EmAberto = true });

            locacao = new LocacaoDataBuilder()
                 .DoFuncionario(beto)
                 .NaData(hoje)
                 .ComDataDeDevolucaoPrevista(daquiSeteDias)
                 .ParaCondutor(brunoHenrique)                 
                 .ComPlanoDeCobranca(PlanoCobranca.Diario(100, 10))
                 .DoVeiculo(kicksBranco)
                 .Build();

            //action
            string resultado = locacao.Validar();

            //assert
            resultado.Should().Be("O Veículo já está alugado");
        }

        [TestMethod]
        public void DeveCalcular_ValorLocacao_CasoNaoTenhaPlanoConfigurado()
        {
            locacao = new LocacaoDataBuilder()
                .ComPlanoDeCobranca(null)
                .Build();

            var valorLocacao = locacao.CalcularValorLocacao();

            valorLocacao.Should().Be(0);
        }

        [TestMethod]
        public void DeveCalcular_ValorLocacao_ComPlanoDiario()
        {
            locacao = new LocacaoDataBuilder()
                  .ComPlanoDeCobranca(PlanoCobranca.Diario(100, 0))
                  .NaData(hoje)
                  .ComDataDeDevolucaoPrevista(daquiSeteDias)
                  .Build();

            var valorLocacao = locacao.CalcularValorLocacao();

            valorLocacao.Should().Be(700);
        }

        [TestMethod]
        public void DeveCalcular_ValorLocacao_ComQuilometragemRegistrada()
        {
            locacao = new LocacaoDataBuilder()
                  .ComPlanoDeCobranca(PlanoCobranca.Diario(100, 10))
                  .NaData(hoje)
                  .ComDataDeDevolucaoPrevista(daquiSeteDias)
                  .ComQuilometragemPercorrida(10)
                  .Build();

            var valorLocacao = locacao.CalcularValorLocacao();

            valorLocacao.Should().Be(800);
        }

        [TestMethod]
        public void DeveCalcular_ValorLocacao_PlanoKmControlado_ComQuilometragemRegistrado_NaoExtrapolandoKmLivre()
        {
            locacao = new LocacaoDataBuilder()
                  .ComPlanoDeCobranca(PlanoCobranca.KmControlado(200, 100, 10))
                  .NaData(hoje)
                  .ComDataDeDevolucaoPrevista(daquiSeteDias)
                  .ComQuilometragemPercorrida(90)
                  .Build();

            var valorLocacao = locacao.CalcularValorLocacao();

            valorLocacao.Should().Be(1400);
        }

        [TestMethod]
        public void DeveCalcular_ValorLocacao_PlanoKmControlado_ComQuilometragemRegistrado_ExtrapolandoKmLivre()
        {
            locacao = new LocacaoDataBuilder()
                  .ComPlanoDeCobranca(PlanoCobranca.KmControlado(200, 100, 20))
                  .NaData(hoje)
                  .ComDataDeDevolucaoPrevista(daquiSeteDias)
                  .ComQuilometragemPercorrida(110)
                  .Build();

            var valorLocacao = locacao.CalcularValorLocacao();

            valorLocacao.Should().Be(1600);
        }

        [TestMethod]
        public void DeveCalcular_ValorLocacao_PlanoKmLivre()
        {
            locacao = new LocacaoDataBuilder()
                  .ComPlanoDeCobranca(PlanoCobranca.KmLivre(300))
                  .NaData(hoje)
                  .ComDataDeDevolucaoPrevista(daquiSeteDias)
                  .Build();

            var valorLocacao = locacao.CalcularValorLocacao();

            valorLocacao.Should().Be(2100);
        }

        [TestMethod]
        public void DeveCalcular_ValorLocacao_ComTaxas()
        {
            locacao = new LocacaoDataBuilder()
                  .ComPlanoDeCobranca(PlanoCobranca.KmLivre(300))
                  .NaData(hoje)
                  .ComDataDeDevolucaoPrevista(daquiSeteDias)
                  .ComAhTaxa(new Taxa("Caderinha de Bebê", 30, TipoTaxaEnum.CobradoPorDia))
                  .Build();

            var valorLocacao = locacao.CalcularValorLocacao();

            valorLocacao.Should().Be(2310);
        }

        [TestMethod]
        public void DeveCalcular_ValorLocacao_ComUmCupom()
        {
            locacao = new LocacaoDataBuilder()
                   .ComPlanoDeCobranca(PlanoCobranca.KmLivre(250))
                   .NaData(hoje)
                   .ComDataDeDevolucaoPrevista(DateTime.Now.Date.AddDays(8))
                   .ComCupom(new Cupom("Natal 10%", 10, DateTime.Now, null, 10, TipoCupomEnum.Percentual))
                   .Build();

            var valorLocacao = locacao.CalcularValorLocacao();

            valorLocacao.Should().Be(1800);
        }

        [TestMethod]
        public void DeveCalcular_ValorLocacao_ComConsumoDeCombustivel()
        {
            locacao = new LocacaoDataBuilder()
                   .ComPlanoDeCobranca(PlanoCobranca.KmLivre(300))
                   .NaData(hoje)
                   .ComDataDeDevolucaoPrevista(amanha)
                   .DoVeiculo(kicksBranco)
                   .ComMarcadorCombustivel(MarcadorCombustivelEnum.UmQuarto)
                   .Build();

            var valorLocacao = locacao.CalcularValorLocacao(precoCombustivel: 5.0m);

            valorLocacao.Should().Be(490);
        }

        [TestMethod]
        public void DeveCalcular_ValorLocacao_ComMulta()
        {
            locacao = new LocacaoDataBuilder()
                   .ComPlanoDeCobranca(PlanoCobranca.KmLivre(300))
                   .NaData(hoje)
                   .ComDataDeDevolucaoPrevista(daquiSeteDias)
                   .ComDataDeDevolucaoRealizada(DateTime.Now.Date.AddDays(10))
                   .Build();

            var valorLocacao = locacao.CalcularValorLocacao();

            valorLocacao.Should().Be(3300);
        }


    }
}
