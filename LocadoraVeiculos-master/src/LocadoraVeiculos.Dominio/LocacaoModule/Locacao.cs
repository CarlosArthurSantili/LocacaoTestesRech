using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Dominio.LocacaoModule
{

    public class Locacao : EntidadeBase, IEquatable<Locacao>
    {
        private const decimal DezPorcento = (10m / 100m);

        public List<Taxa> TaxasSelecionadas { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime DataDevolucaoRealizada { get; set; }
        public Funcionario Funcionario { get; set; }
        public Veiculo Veiculo { get; set; }
        public Condutor Condutor { get; set; }
        public PlanoCobranca PlanoSelecionado { get; set; }
        public bool EmAberto { get; set; }
        public int QuilometragemPercorrida { get; set; }
        public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }
        public Cupom Cupom { get; set; }

        public Locacao()
        {
            TaxasSelecionadas = new List<Taxa>();
            
        }
        private int QuantidadeDeDias
        {
            get
            {
                int qtdDiasLocacao;

                if (DataDevolucaoRealizada == DateTime.MinValue)
                    qtdDiasLocacao = (DataDevolucaoPrevista - DataLocacao).Days;
                else
                    qtdDiasLocacao = (DataDevolucaoRealizada - DataLocacao).Days;

                return qtdDiasLocacao;
            }
        }

        public decimal CalcularValorLocacao(decimal precoCombustivel = 0)
        {
            if (PlanoSelecionado == null)
                return 0;

            decimal valorPlano = PlanoSelecionado.CalcularValor(QuantidadeDeDias, QuilometragemPercorrida);

            decimal valorTaxas = 0;

            if (TaxasSelecionadas != null && TaxasSelecionadas.Any())
                valorTaxas = TaxasSelecionadas.Sum(tx => tx.CalcularValor(QuantidadeDeDias));

            decimal valorCombustivel = 0;
            
            if (Veiculo != null)
                valorCombustivel = Veiculo.QuantidadeDeListrosParaAbastecer(MarcadorCombustivel) * precoCombustivel;

            decimal valorTotal = valorPlano + valorCombustivel + valorTaxas;

            if (TemMulta())
                valorTotal += valorTotal * DezPorcento;

            if (TemCupom())
                valorTotal -= Cupom.CalcularDesconto(valorTotal);

            return valorTotal;
        }

        public void AlugarVeiculo(Veiculo veiculo)
        {
            Veiculo = veiculo;

            Veiculo.RegistrarLocacao(this);
        }

        private bool TemCupom()
        {
            return Cupom != null;
        }

        private bool TemMulta()
        {
            return (DataDevolucaoRealizada - DataDevolucaoPrevista).Days > 0;
        }        

        public void FinalizarLocacao()
        {
            EmAberto = false;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (Funcionario == null)
                resultadoValidacao = "Selecione um funcionário";

            if (Condutor == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um condutor";

            if (Veiculo == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um veículo";

            if (PlanoSelecionado == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione o plano de cobrança";

            if (DataLocacao == DateTime.MinValue)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione a data da locação";

            if (DataDevolucaoPrevista == DateTime.MinValue)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione a data prevista da entrega";

            if (DataDevolucaoPrevista < DataLocacao)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "A data prevista da entrega não pode ser menor que data da locação";

            if (Veiculo != null && Veiculo.EstaAlugado())
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O Veículo já está alugado";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

     

        public void AdicionarTaxa(Taxa taxa)
        {
            TaxasSelecionadas.Add(taxa);
            taxa.RegistrarAlocacao(this);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Locacao);
        }

        public bool Equals(Locacao other)
        {
            return other != null &&
                   Id == other.Id &&
                   EqualsTaxasSelecionadas(other.TaxasSelecionadas) &&
                   DataLocacao.Equals(other.DataLocacao) &&
                   DataDevolucaoPrevista.Equals(other.DataDevolucaoPrevista) &&
                   DataDevolucaoRealizada.Equals(other.DataDevolucaoRealizada) &&
                   Funcionario.Equals(other.Funcionario) &&
                   Veiculo.Equals(other.Veiculo) &&
                   Condutor.Equals(other.Condutor) &&
                   PlanoSelecionado.Equals(other.PlanoSelecionado) &&
                   EmAberto.Equals(other.EmAberto) &&
                   QuilometragemPercorrida.Equals(other.QuilometragemPercorrida) &&
                   MarcadorCombustivel.Equals(other.MarcadorCombustivel) &&
                   Cupom.Equals(other.Cupom) &&
                   QuantidadeDeDias.Equals(other.QuantidadeDeDias);
        }

        //Comparação de listas de objetos. Não sabia exatamente onde utilizar ela se não aqui em Locação
        public bool EqualsTaxasSelecionadas(List<Taxa> TaxasSelecionadas2) 
        {
            return (TaxasSelecionadas.All(item => TaxasSelecionadas2.Contains(item)) &&
                    TaxasSelecionadas.Distinct().Count() == TaxasSelecionadas.Count &&
                    TaxasSelecionadas.Count == TaxasSelecionadas2.Count);
        }
    }
}
