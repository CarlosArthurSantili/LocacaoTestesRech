using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.CupomModule;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores
{
    public class ControladorParceiro : Controlador<Parceiro>
    {
        private const string sqlInserirParceiro =
               @"INSERT INTO TBPARCEIRO
	                        (	
		                        [NOME]
	                        )
	                        VALUES
	                        (
                                @NOME
	                        )";

        public override string InserirNovo(Parceiro registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirParceiro, ObtemParametrosParceiros(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Parceiro registro)
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



        public override Parceiro SelecionarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public override List<Parceiro> SelecionarTodos()
        {
            throw new System.NotImplementedException();
        }

        private Dictionary<string, object> ObtemParametrosParceiros(Parceiro parceiro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", parceiro.Id);
            parametros.Add("NOME", parceiro.Nome);
            ;

            return parametros;
        }
    }
}