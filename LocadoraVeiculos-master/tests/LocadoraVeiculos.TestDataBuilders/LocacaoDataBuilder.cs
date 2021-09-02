using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.TestDataBuilders
{
    public class LocacaoDataBuilder
    {
        private Locacao locacao;

        public LocacaoDataBuilder()
        {
            locacao = new Locacao();
        }

        public LocacaoDataBuilder ComPlanoDeCobranca(PlanoCobranca planoCobranca)
        {
            locacao.PlanoSelecionado = planoCobranca;
            return this;
        }

        public LocacaoDataBuilder NaData(DateTime data)
        {
            locacao.DataLocacao = data;
            return this;
        }

        public LocacaoDataBuilder ComDataDeDevolucaoPrevista(DateTime data)
        {
            locacao.DataDevolucaoPrevista = data;
            return this;
        }

        public LocacaoDataBuilder ComQuilometragemPercorrida(int quilometragemPercorrida)
        {
            locacao.QuilometragemPercorrida = quilometragemPercorrida;
            return this;
        }

        public LocacaoDataBuilder ComAhTaxa(Taxa taxa)
        {
            locacao.AdicionarTaxa(taxa);

            return this;
        }

        public LocacaoDataBuilder ComCupom(Cupom cupom)
        {
            locacao.Cupom = cupom;
            return this;
        }

        public LocacaoDataBuilder ComMarcadorCombustivel(MarcadorCombustivelEnum nivelMarcador)
        {
            locacao.MarcadorCombustivel = nivelMarcador;
            return this;
        }

        public LocacaoDataBuilder ComDataDeDevolucaoRealizada(DateTime data)
        {
            locacao.DataDevolucaoRealizada = data;
            return this;
        }

        public LocacaoDataBuilder DoVeiculo(Veiculo veiculo)
        {
            locacao.AlugarVeiculo(veiculo);

            return this;
        }

        public Locacao Build()
        {
            return locacao;
        }

        public LocacaoDataBuilder DoFuncionario(Funcionario funcionario)
        {
            locacao.Funcionario = funcionario;
            return this;
        }

        public LocacaoDataBuilder ParaCondutor(Condutor condutor)
        {
            locacao.Condutor = condutor;
            return this;
        }
    }
}
