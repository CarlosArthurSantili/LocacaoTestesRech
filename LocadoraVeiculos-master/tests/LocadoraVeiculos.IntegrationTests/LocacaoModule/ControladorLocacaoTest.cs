using FluentAssertions;
using LocadoraVeiculos.Controladores;
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

namespace LocadoraVeiculos.Tests.LocacaoModule
{
    [TestClass]
    public class ControladorLocacaoTest
    {
        private ControladorLocacao controladorLocacao;

        private Locacao locacaoBase;
        private static GrupoVeiculo suv;
        private static Veiculo kicks;
        private static Funcionario beto;
        private static Condutor bruno;
        private static Taxa caderinhaBebe;
        private static Taxa lavacaoCarro;
        private static Cupom dezReaisDeDesconto;
        private static Parceiro deko;

        private static DateTime hoje;
        private static DateTime daquiDezDias;
        private static DateTime daquiSeteDias;

        public ControladorLocacaoTest()
        {
            controladorLocacao = new ControladorLocacao();
        }

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            ConfigurarDatas();

            InserirGruposEhPlanos();

            InserirVeiculo();

            InserirClienteEhCondutor();

            InserirFuncionario();

            InserirTaxas();

            InserirParceiroEhDesconto();
        }

        [TestMethod]
        public void Deve_RegistrarNovaLocacao()
        {
            locacaoBase = new LocacaoDataBuilder()
                .NaData(hoje)
                .ComDataDeDevolucaoPrevista(daquiSeteDias)
                .ComDataDeDevolucaoRealizada(daquiSeteDias)
                .DoFuncionario(beto)
                .ComPlanoDeCobranca(
                    suv.ObtemPlano(TipoPlanoCobrancaEnum.PlanoDiario))
                .DoVeiculo(kicks)
                .ParaCondutor(bruno)
                .ComAhTaxa(caderinhaBebe)
                .ComAhTaxa(lavacaoCarro)
                .ComCupom(dezReaisDeDesconto)
                .ComMarcadorCombustivel(MarcadorCombustivelEnum.MeioTanque)
                .Build();

            controladorLocacao.RegistrarNovaLocacao(locacaoBase);

            var locacaoSelecionada = controladorLocacao.SelecionarPorId(locacaoBase.Id);

            locacaoSelecionada.Should().Be(locacaoBase);            
        }

        #region Métodos Privados
        private static void InserirParceiroEhDesconto()
        {
            deko = new Parceiro("Desconto do Deko");

            new ControladorParceiro().InserirNovo(deko);

            dezReaisDeDesconto = new Cupom("Dez conto de desconto", 10, new DateTime(2021, 12, 31), deko, 100, TipoCupomEnum.ValorFixo);

            new ControladorCupom().InserirNovo(dezReaisDeDesconto);
        }

        private static void InserirTaxas()
        {
            caderinhaBebe = new Taxa("Cadeirinha de Bebê", 30, TipoTaxaEnum.CobradoPorDia);
            lavacaoCarro = new Taxa("Lavação de Carro", 30, TipoTaxaEnum.CobradoUmaVez);

            new ControladorTaxa().InserirNovo(caderinhaBebe);
            new ControladorTaxa().InserirNovo(lavacaoCarro);
        }

        private static void InserirFuncionario()
        {
            beto = new Funcionario("Alberto", "beto", "123456", DateTime.Now.Date, 600.0);

            new ControladorFuncionario().InserirNovo(beto);
        }

        private static void InserirClienteEhCondutor()
        {
            var flamengo = new Cliente("Flamengo", "Gávea", "9524282242", "", "", "1234567891234", TipoPessoaEnum.Juridica);

            new ControladorCliente().InserirNovo(flamengo);

            bruno = new Condutor("Bruno Henrique", "Gávea", "999292107", "3717158", "04791277945", "123456789", new DateTime(2022, 05, 26), flamengo);

            new ControladorCondutor().InserirNovo(bruno);
        }

        private static void InserirVeiculo()
        {           
            kicks = new Veiculo("QYV9630", "Kicks", "Nissam", 50.000, 50, TipoCombustivelEnum.Gasolina, suv);
            kicks.Imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
                
            new ControladorVeiculo().InserirNovo(kicks);
        }

        private static void InserirGruposEhPlanos()
        {
            suv = new GrupoVeiculo("SUV");

            suv.AdicionarPlanos(PlanoCobranca.Diario(100, 10));
            suv.AdicionarPlanos(PlanoCobranca.KmControlado(200, 100, 20));
            suv.AdicionarPlanos(PlanoCobranca.KmLivre(300));

            new ControladorGrupoVeiculo().InserirNovo(suv);
        }

        private static void ConfigurarDatas()
        {
            hoje = DateTime.Now.Date;
            daquiSeteDias = DateTime.Now.Date.AddDays(7);
            daquiDezDias = DateTime.Now.Date.AddDays(10);
        }

        #endregion

    }
}
