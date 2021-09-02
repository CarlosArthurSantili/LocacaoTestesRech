using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores
{
    public class ControladorTaxa : Controlador<Taxa>
    {

        private const string sqlInserirTaxa =
            @"INSERT INTO TBTAXA
	                (	
		                [NOME]
                       ,[VALOR]
                       ,[TIPOTAXA]
	                )
	                VALUES
	                (
                        @NOME, 
		                @VALOR, 
		                @TIPOTAXA
	                )";

        public override string InserirNovo(Taxa registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirTaxa, ObtemParametrosTaxa(registro));
            }

            return resultadoValidacao;
        }

        private Dictionary<string, object> ObtemParametrosTaxa(Taxa registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro.Id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("VALOR", registro.Valor);
            parametros.Add("TIPOTAXA", (int)registro.TipoTaxa);

            return parametros;
        }

        public override string Editar(int id, Taxa registro)
        {
            throw new NotImplementedException();
        }

        public override bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }



        public override Taxa SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Taxa> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
