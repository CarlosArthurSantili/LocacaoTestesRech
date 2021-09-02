using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.ClienteModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Controladores
{
    public class ControladorCondutor : Controlador<Condutor>
    {
        private const string sqlInserirCliente =
        @"INSERT INTO [TBCondutor]
                (
                     [Nome]
                    ,[Endereco]
                    ,[Telefone]
                    ,[RG]
                    ,[CPF]
                    ,[CNH]
                    ,[DataValidadeCNH]
                    ,[Cliente_Id]
                )
             VALUES
                (
                    @Nome,
                    @Endereco,
                    @Telefone,
                    @RG, 
                    @CPF,
                    @CNH,
                    @DataValidadeCNH,
                    @Cliente_Id
                )";
        
        public override string InserirNovo(Condutor registro)
        {
            string resultadoValidacaoDominio = registro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirCliente, ObtemParametrosCondutor(registro));
            }

            return resultadoValidacaoDominio;
        }

        public override string Editar(int id, Condutor registro)
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

        public override Condutor SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Condutor> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, object> ObtemParametrosCondutor(Condutor registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro.Id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("ENDERECO", registro.Endereco);
            parametros.Add("TELEFONE", registro.Telefone);
            parametros.Add("RG", registro.RG);
            parametros.Add("CPF", registro.CPF);
            parametros.Add("CNH", registro.CNH);
            parametros.Add("DataValidadeCNH", registro.DataValidadeCNH);
            parametros.Add("Cliente_Id", registro.Cliente.Id);

            return parametros;

        }
    }
}
