using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.CupomModule
{
    public class Parceiro : EntidadeBase, IEquatable<Parceiro>
    {
        public string Nome { get; }

        public Parceiro(string nome)
        {
            Nome = nome;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";
            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O Nome do Parceiro é obrigatório .";
            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Parceiro);
        }

        public bool Equals(Parceiro other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Nome.Equals(other.Nome);
        }

        public override int GetHashCode()
        {
            int hashCode = -1643562096;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            return hashCode;
        }
    }
}
