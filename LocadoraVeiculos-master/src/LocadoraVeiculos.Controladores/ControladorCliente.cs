using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.ClienteModule;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores
{
    public class ControladorCliente : Controlador<Cliente>
    {
        private const string sqlInserirCliente =
         @"INSERT INTO [TBCLIENTE]
                (
                    [NOME]
                   ,[ENDERECO]
                   ,[TELEFONE]
                   ,[RG]
                   ,[CPF]
                   ,[CNPJ]
                   ,[TIPOPESSOA]
                )
             VALUES
                (
                    @NOME,
                    @ENDERECO,
                    @TELEFONE,
                    @RG, 
                    @CPF,
                    @CNPJ,
                    @TIPOPESSOA
	            )";


        public override string InserirNovo(Cliente registro)
        {
            string resultadoValidacaoDominio = registro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirCliente, ObtemParametrosCliente(registro));               
            }

            return resultadoValidacaoDominio;
        }

        private Dictionary<string, object> ObtemParametrosCliente(Cliente registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro.Id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("ENDERECO", registro.Endereco);
            parametros.Add("TELEFONE", registro.Telefone);
            parametros.Add("RG", registro.RG);
            parametros.Add("CPF", registro.CPF);
            parametros.Add("CNPJ", registro.CNPJ);
            parametros.Add("TIPOPESSOA", (int)registro.TipoPessoa);

            return parametros;

        }

        public override string Editar(int id, Cliente registro)
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

        public override Cliente SelecionarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public override List<Cliente> SelecionarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}