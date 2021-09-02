using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ClienteModule
{
    public class Condutor : EntidadeBase, IEquatable<Condutor>
    {
        public string Nome { get; }
        public string Endereco { get; }
        public string Telefone { get; }
        public string RG { get; }
        public string CPF { get; }
        public string CNH { get; }
        public DateTime DataValidadeCNH { get; }
        public Cliente Cliente { get; }

        public Condutor(string nome, string endereco, string telefone, string rg, string cpf,
            string numeroCNH, DateTime validadeCNH, Cliente cliente)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            RG = rg;
            CPF = cpf;
            CNH = numeroCNH;
            DataValidadeCNH = validadeCNH;
            Cliente = cliente;
        }

        public override string ToString()
        {
            return Nome;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O atributo nome é obrigatório e não pode ser vazio.";

            if (string.IsNullOrEmpty(Endereco))
                resultadoValidacao = "O atributo endereço é obrigatório e não pode ser vazio.";

            if (Telefone.Length < 9)
                resultadoValidacao = "O atributo Telefone está invalido.";

            if (string.IsNullOrEmpty(RG))
                resultadoValidacao = "O atributo Numero do Rg é obrigatório e não pode ser vazio.";

            if (string.IsNullOrEmpty(CPF))
                resultadoValidacao = "O atributo Numero do Cpf é obrigatório e não pode ser vazio.";

            if (string.IsNullOrEmpty(CNH))
                resultadoValidacao = "O atributo Numero da CNH é obrigatório e não pode ser vazio.";

            if (DataValidadeCNH == DateTime.MinValue)
                resultadoValidacao = "O campo Validade da CNH é obrigatório";

            if (DataValidadeCNH < DateTime.Now)
                resultadoValidacao = "A validade da cnh inserida está expirada, tente novamente";

            if (string.IsNullOrEmpty(Cliente.ToString()))
                resultadoValidacao = "O campo Cliente é obrigatório e não pode ser Vazio";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Condutor);
        }

        public bool Equals(Condutor other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Nome.Equals(other.Nome) &&
                   Endereco.Equals(other.Endereco) &&
                   Telefone.Equals(other.Telefone) &&
                   RG.Equals(other.RG) &&
                   CPF.Equals(other.CPF) &&
                   CNH.Equals(other.CNH) &&
                   DataValidadeCNH.Equals(other.DataValidadeCNH) &&
                   Cliente.Equals(other.Cliente);
                   //EqualityComparer<Cliente>.Default.Equals(Cliente, other.Cliente);
        }

        public override int GetHashCode()
        {
            int hashCode = 1641945510;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RG);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CPF);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CNH);
            hashCode = hashCode * -1521134295 + DataValidadeCNH.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Cliente>.Default.GetHashCode(Cliente);
            return hashCode;
        }
    }
}