using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.CupomModule
{

    public class Cupom : EntidadeBase, IEquatable<Cupom>
    {
        public string Nome { get; }

        public decimal Valor { get; }

        public DateTime DataValidade { get; }

        public Parceiro Parceiro { get; }

        public decimal ValorMinimo { get; }

        public TipoCupomEnum Tipo { get; set; }

        public Cupom(string nome, decimal valor, DateTime dataValidade, Parceiro parceiro, decimal valorMinimo, TipoCupomEnum tipo)
        {
            Nome = nome;
            Valor = valor;
            DataValidade = dataValidade;
            Parceiro = parceiro;
            ValorMinimo = valorMinimo;
            Tipo = tipo;
        }
             

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao += "O campo nome é obrigatório e não pode ser vazio.";

            if (DataValidade == DateTime.MinValue || DataValidade == DateTime.MaxValue)
                resultadoValidacao += "A data Invalida, Insira uma data valida";

            if (Parceiro == null)
                resultadoValidacao += "O campo Parceiro é obrigatório e não pode ser vazio.";

            if (ValorMinimo < 0)
                resultadoValidacao += "O campo Valor Minimo não pode ser menor que Zero.";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;

        }

        public decimal CalcularDesconto(decimal valorTotal)
        {
            decimal valor = 0;

            if (valorTotal <= ValorMinimo)
                valor = 0;

            else if (Tipo == TipoCupomEnum.ValorFixo)
                valor = Valor;

            else if (Tipo == TipoCupomEnum.Percentual)
                valor =  (Valor / 100) * valorTotal;

            return valor;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cupom);
        }

        public bool Equals(Cupom other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Nome.Equals(other.Nome) &&
                   Valor.Equals(other.Valor) &&
                   DataValidade.Equals(other.DataValidade) &&
                   Parceiro.Equals(other.Parceiro) &&
                   //EqualityComparer<Parceiro>.Default.Equals(Parceiro, other.Parceiro) &&
                   ValorMinimo.Equals(other.ValorMinimo) &&
                   Tipo.Equals(other.Tipo);
        }

        public override int GetHashCode()
        {
            int hashCode = 1067899557;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + Valor.GetHashCode();
            hashCode = hashCode * -1521134295 + DataValidade.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Parceiro>.Default.GetHashCode(Parceiro);
            hashCode = hashCode * -1521134295 + ValorMinimo.GetHashCode();
            hashCode = hashCode * -1521134295 + Tipo.GetHashCode();
            return hashCode;
        }
    }
}
