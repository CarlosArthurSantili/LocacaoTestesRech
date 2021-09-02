using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ClienteModule
{
    public class Cliente : EntidadeBase, IEquatable<Cliente>
    {
        public List<Condutor> Condutores
        {
            get => default;
            set
            {
            }
        }


        public string Nome { get; }
        public string Endereco { get; }
        public string Telefone { get; }
        public string CNPJ { get; }
        public string RG { get; }
        public string CPF { get; }
        public TipoPessoaEnum TipoPessoa { get; }        

        public Cliente(string nome, string endereco, string telefone, string RG, string CPF, string CNPJ, TipoPessoaEnum tipoPessoa)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            this.RG = RG;
            this.CPF = CPF;
            this.CNPJ = CNPJ;
            TipoPessoa = tipoPessoa;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O nome é obrigatório e não pode ser vazio.";

            if (string.IsNullOrEmpty(Endereco))
                resultadoValidacao = "O endereço é obrigatório e não pode ser vazio.";

            if (Telefone.Length < 9)
                resultadoValidacao = "O Telefone está invalido.";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cliente);
        }

        public bool Equals(Cliente other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   //EqualityComparer<List<Condutor>>.Default.Equals(Condutores, other.Condutores) &&
                   Nome.Equals(other.Nome) &&
                   Endereco.Equals(other.Endereco) &&
                   Telefone.Equals(other.Telefone) &&
                   CNPJ.Equals(other.CNPJ) &&
                   RG.Equals(other.RG) &&
                   CPF.Equals(other.CPF) &&
                   TipoPessoa.Equals(other.TipoPessoa);
        }

        public override int GetHashCode()
        {
            int hashCode = -966624200;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            //hashCode = hashCode * -1521134295 + EqualityComparer<List<Condutor>>.Default.GetHashCode(Condutores);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CNPJ);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RG);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CPF);
            hashCode = hashCode * -1521134295 + TipoPessoa.GetHashCode();
            return hashCode;
        }
    }
}