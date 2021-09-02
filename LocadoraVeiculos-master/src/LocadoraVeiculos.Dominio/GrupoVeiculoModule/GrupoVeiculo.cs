using LocadoraVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Dominio.GrupoVeiculoModule
{
    public class GrupoVeiculo : EntidadeBase, IEquatable<GrupoVeiculo>
    {
        public GrupoVeiculo(string nome)
        {
            Nome = nome;
            Veiculos = new List<Veiculo>();
            PlanosCobranca = new List<PlanoCobranca>();
        }

        public string Nome { get; set; }

        public List<Veiculo> Veiculos
        {
            get;
            set;
        }

        public List<PlanoCobranca> PlanosCobranca
        {
            get;
            set;
        }

        public void AdicionarPlanos(PlanoCobranca plano)
        {
            PlanosCobranca.Add(plano);
            plano.Grupo = this;
        }


        public override string Validar()
        {
            return "ESTA_VALIDO";
        }

        public PlanoCobranca ObtemPlano(TipoPlanoCobrancaEnum plano)
        {
            var planoCobranca = PlanosCobranca.First(p => p.TipoPlano == plano).Clone();

            return (PlanoCobranca)planoCobranca;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GrupoVeiculo);
        }

        public bool Equals(GrupoVeiculo other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Nome.Equals(other.Nome);
                   //&&                   EqualityComparer<List<Veiculo>>.Default.Equals(Veiculos, other.Veiculos) &&
                   //EqualityComparer<List<PlanoCobranca>>.Default.Equals(PlanosCobranca, other.PlanosCobranca);
        }

        public override int GetHashCode()
        {
            int hashCode = 983721824;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            return hashCode;
        }
    }
}
