using LocadoraVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Dominio.VeiculoModule
{

    public class Veiculo : EntidadeBase, IEquatable<Veiculo>
    {
        public Veiculo(string placa, string modelo, string fabricante, double quilometragem, int qtdlitros,
            TipoCombustivelEnum combustivel, GrupoVeiculo grupo)
        {
            Placa = placa;
            Modelo = modelo;
            Fabricante = fabricante;
            Quilometragem = quilometragem;
            QtdLitrosTanque = qtdlitros;
            TipoCombustivel = combustivel;
            Grupo = grupo;
            Locacoes = new List<Locacao>();
        }

        public string Placa { get; }
        public TipoCombustivelEnum TipoCombustivel { get; }
        public string Modelo { get; }
        public string Fabricante { get; }
        public double Quilometragem { get; }
        public int QtdLitrosTanque { get; }
        public GrupoVeiculo Grupo { get; }

        public int QtdPortas { get; set; }
        public string NumeroChassi { get; set; }
        public string Cor { get; set; }
        public int CapacidadeOcupantes { get; set; }
        public int AnoFabricacao { get; set; }
        public string TamanhoPortaMalas { get; set; }
        public byte[] Imagem { get; set; }

        public List<Locacao> Locacoes { get; set; }


        public override string ToString()
        {
            return "Modelo: " + Modelo;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Placa))
                resultadoValidacao = "O campo Placa é obrigatório";

            if (string.IsNullOrEmpty(Modelo))
                resultadoValidacao = "O campo Modelo é obrigatório";

            if (string.IsNullOrEmpty(Fabricante))
                resultadoValidacao = "O campo Fabricante é obrigatório";

            if (Quilometragem < 0)
                resultadoValidacao = "O campo Quilometragem não pode ser menor que zero";

            if (QtdLitrosTanque <= 0)
                resultadoValidacao = "O campo do Tanque de Combustivel não pode ser menor que zero";

            if (string.IsNullOrEmpty(TipoCombustivel.ToString()))
                resultadoValidacao = "O campo Tipo de combustivel é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public int QuantidadeDeListrosParaAbastecer(MarcadorCombustivelEnum marcadorCombustivel)
        {
            switch (marcadorCombustivel)
            {
                case MarcadorCombustivelEnum.Vazio: return QtdLitrosTanque;

                case MarcadorCombustivelEnum.UmQuarto: return (QtdLitrosTanque - (QtdLitrosTanque * 1 / 4));

                case MarcadorCombustivelEnum.MeioTanque: return (QtdLitrosTanque - (QtdLitrosTanque * 1 / 2));

                case MarcadorCombustivelEnum.TresQuartos: return (QtdLitrosTanque - (QtdLitrosTanque * 3 / 4));

                default:
                    return 0;
            }
        }

        public void RegistrarLocacao(Locacao locacao)
        {
            Locacoes.Add(locacao);
        }

        public bool EstaAlugado()
        {
            return Locacoes.Exists(x => x.EmAberto);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Veiculo);
        }

        public bool Equals(Veiculo other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Placa.Equals(other.Placa) &&
                   TipoCombustivel.Equals(other.TipoCombustivel) &&
                   Modelo.Equals(other.Modelo) &&
                   Fabricante.Equals(other.Fabricante) &&
                   Quilometragem.Equals(other.Quilometragem) &&
                   QtdLitrosTanque.Equals(other.QtdLitrosTanque) &&
                   Grupo.Equals(other.Grupo) &&

                   //Esses atributos de veículo estão de fora do construtor, ocasionando erros na hora da comparação
                   //EqualityComparer<GrupoVeiculo>.Default.Equals(Grupo, other.Grupo)  &&
                   //QtdPortas.Equals(other.QtdPortas) &&
                   //NumeroChassi.Equals(other.NumeroChassi) &&
                   //Cor.Equals(other.Cor) &&
                   //CapacidadeOcupantes.Equals(other.CapacidadeOcupantes) &&
                   //AnoFabricacao.Equals(other.AnoFabricacao) &&
                   //TamanhoPortaMalas.Equals(other.TamanhoPortaMalas);
                   Imagem.SequenceEqual(other.Imagem);
        }
    }
}
