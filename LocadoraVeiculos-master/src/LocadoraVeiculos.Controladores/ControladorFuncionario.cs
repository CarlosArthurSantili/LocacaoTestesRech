using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Controladores
{
    public class ControladorFuncionario : Controlador<Funcionario>
    {
		private const string sqlInserirFuncionario =
		   @"INSERT INTO [TBFUNCIONARIO]
	                (
		                [NOME],                        
		                [USUARIO], 
		                [SENHA],
                        [DATAADMISSAO], 
		                [SALARIO]
	                ) 
	                VALUES
	                (
                        @NOME,                         
		                @USUARIO, 
		                @SENHA,
                        @DATAADMISSAO, 
		                @SALARIO
	                )";

        public override string InserirNovo(Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();
            
            if (resultadoValidacao == "ESTA_VALIDO" )
            {
                registro.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosFuncionario(registro));
            }

            return resultadoValidacao;
        }

        private Dictionary<string, object> ObtemParametrosFuncionario(Funcionario registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro.Id);
            parametros.Add("NOME", registro.Nome);            
            parametros.Add("USUARIO", registro.Usuario);
            parametros.Add("SENHA", registro.Senha);
            parametros.Add("DATAADMISSAO", registro.DataAdmissao);
            parametros.Add("SALARIO", registro.Salario);

            return parametros; ;
        }

        public override string Editar(int id, Funcionario registro)
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

       
        public override Funcionario SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Funcionario> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
