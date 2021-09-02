using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.GrupoVeiculoModule;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores
{
    public class ControladorGrupoVeiculo : Controlador<GrupoVeiculo>
    {
        private const string sqlInserirGrupoVeiculo =
           @"INSERT INTO [TBGRUPOVEICULO] 
	                (
		                [NOME]
	                ) 
	                VALUES
	                (
                        @NOME
	                )";


        private const string sqlInserirPlanosDoGrupoVeiculo =
           @"INSERT INTO [TBPLANOCOBRANCA]
                (
                   [VALORDIA]
                  ,[KILOMETRAGEMLIVREINCLUSA]
                  ,[VALORKMRODADO]
                  ,[TIPOPLANO]
                  ,[GRUPOVEICULO_ID]
                )
              VALUES
                (
                   @VALORDIA, 
                   @KILOMETRAGEMLIVREINCLUSA,
                   @VALORKMRODADO, 
                   @TIPOPLANO, 
                   @GRUPOVEICULO_ID
                )";

        public override string InserirNovo(GrupoVeiculo registro)
        {
            string resultadoValidacaoDominio = registro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                var parametros = new Dictionary<string, object>
                {
                    { "NOME", registro.Nome }
                };

                registro.Id = Db.Insert(sqlInserirGrupoVeiculo, parametros);

                foreach (var plano in registro.PlanosCobranca)
                {
                    var parametrosPlanos = new Dictionary<string, object>
                    {
                        { "VALORDIA", plano.ValorDia },
                        { "KILOMETRAGEMLIVREINCLUSA", plano.KilometragemLivreInclusa },
                        { "VALORKMRODADO", plano.ValorKMRodado },
                        { "TIPOPLANO", plano.TipoPlano },
                        { "GRUPOVEICULO_ID", plano.Grupo.Id }
                    };

                    plano.Id = Db.Insert(sqlInserirPlanosDoGrupoVeiculo, parametrosPlanos);
                }

            }

            return resultadoValidacaoDominio;
        }

        public override string Editar(int id, GrupoVeiculo registro)
        {
            throw new System.NotImplementedException();
        }

        public override bool Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new System.NotImplementedException();
        }



        public override GrupoVeiculo SelecionarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public override List<GrupoVeiculo> SelecionarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}