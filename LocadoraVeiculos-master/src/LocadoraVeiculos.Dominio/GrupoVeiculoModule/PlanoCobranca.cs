using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.GrupoVeiculoModule
{

    public class PlanoCobranca : EntidadeBase, ICloneable, IEquatable<PlanoCobranca>
    {
        private PlanoCobranca(decimal valorDia, decimal valorKMRodado)
        {
            TipoPlano = TipoPlanoCobrancaEnum.PlanoDiario;
            ValorDia = valorDia;            
            ValorKMRodado = valorKMRodado;
        }

        private PlanoCobranca(decimal valorDia, int kilometragemLivreInclusa, decimal valorKMRodado)
        {
            TipoPlano = TipoPlanoCobrancaEnum.PlanoKmControlado;
            ValorDia = valorDia;
            KilometragemLivreInclusa = kilometragemLivreInclusa;
            ValorKMRodado = valorKMRodado;
        }

        private PlanoCobranca(decimal valorDia)
        {
            TipoPlano = TipoPlanoCobrancaEnum.PlanoKmLivre;
            ValorDia = valorDia;            
        }

        public static PlanoCobranca Diario(decimal valorDia, decimal valorKMRodado)
        {
            return new PlanoCobranca(valorDia, valorKMRodado);
        }

        public static PlanoCobranca KmControlado(decimal valorDia, int kilometragemLivreInclusa, decimal valorKMRodado)
        {
            return new PlanoCobranca(valorDia, kilometragemLivreInclusa, valorKMRodado);
        }

        public static PlanoCobranca KmLivre(decimal valorDia)
        {
            return new PlanoCobranca(valorDia);
        }

        public decimal ValorDia { get; private set; }

        public int KilometragemLivreInclusa { get; private set; }

        public decimal ValorKMRodado { get; private set; }

        public TipoPlanoCobrancaEnum TipoPlano { get; private set; }

        public GrupoVeiculo Grupo { get; set; }

        public decimal CalcularValor(int quantidadeDias, int quilometragemPercorrida)
        {
            decimal valorPlano = quantidadeDias * ValorDia;

            if (quilometragemPercorrida > 0)
            {
                if (TipoPlano == TipoPlanoCobrancaEnum.PlanoDiario)
                    valorPlano += quilometragemPercorrida * ValorKMRodado;

                else if (TipoPlano == TipoPlanoCobrancaEnum.PlanoKmControlado && quilometragemPercorrida > KilometragemLivreInclusa)
                {
                    int diferencaQuilometragemRodada = quilometragemPercorrida - KilometragemLivreInclusa;
                    valorPlano += diferencaQuilometragemRodada * ValorKMRodado;
                }
            }

            return valorPlano;
        }

        public override string Validar()
        {
            throw new System.NotImplementedException();
        }

        public object Clone()
        {
            PlanoCobranca planoSemGrupo = MemberwiseClone() as PlanoCobranca;

            planoSemGrupo.Grupo = null;

            return planoSemGrupo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PlanoCobranca);
        }

        public bool Equals(PlanoCobranca other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   ValorDia.Equals(other.ValorDia) &&
                   KilometragemLivreInclusa.Equals(other.KilometragemLivreInclusa) &&
                   ValorKMRodado.Equals(other.ValorKMRodado) &&
                   TipoPlano.Equals(other.TipoPlano);
                //Grupo não está sendo atribuido ao plano cobranca?
                   //Grupo.Equals(other.Grupo);
                   //EqualityComparer<GrupoVeiculo>.Default.Equals(Grupo, other.Grupo);
        }
    }
}
