using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.CupomModule;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores
{
    public class ControladorCupom : Controlador<Cupom>
    {
        private const string sqlInserirCupom =
            @"INSERT INTO TBCUPOM
	                (	
		                [NOME], 
		                [VALOR], 		                
                        [DATAVALIDADE],
                        [PARCEIRO_ID],
                        [VALORMINIMO],
                        [TIPO]
	                )
	                VALUES
	                (
                        @NOME, 
		                @VALOR, 		                
                        @DATAVALIDADE,
                        @PARCEIRO_ID,
                        @VALORMINIMO,
                        @TIPO
	                )";

        public ControladorCupom()
        {
        }

        public override string Editar(int id, Cupom registro)
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

        public override string InserirNovo(Cupom registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirCupom, ObtemParametrosCupom(registro));
            }

            return resultadoValidacao;
        }

        private Dictionary<string, object> ObtemParametrosCupom(Cupom cupons)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", cupons.Id);
            parametros.Add("NOME", cupons.Nome);
            parametros.Add("VALOR", cupons.Valor);
            parametros.Add("TIPO", (int)cupons.Tipo);
            parametros.Add("DATAVALIDADE", cupons.DataValidade);            
            parametros.Add("VALORMINIMO", cupons.ValorMinimo);
            parametros.Add("PARCEIRO_ID", cupons.Parceiro.Id);
            return parametros;
        }

        public override Cupom SelecionarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public override List<Cupom> SelecionarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}