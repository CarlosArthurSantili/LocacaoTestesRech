using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Controladores
{
    public class ControladorVeiculo : Controlador<Veiculo>
    {
        private const string sqlInserirVeiculo =
         @"INSERT INTO [TBVEICULO]
	                (
                        [PLACA]
                       ,[FABRICANTE]
                       ,[QTDLITROSTANQUE]
                       ,[QTDPORTAS]
                       ,[NUMEROCHASSI]
                       ,[COR]
                       ,[CAPACIDADEOCUPANTES]
                       ,[ANOFABRICACAO]
                       ,[TAMANHOPORTAMALAS]
                       ,[TIPOCOMBUSTIVEL]
                       ,[GRUPOVEICULO_ID]
                       ,[IMAGEM]
                       ,[MODELO]
                       ,[QUILOMETRAGEM]
	                ) 
	                VALUES
	                (
                        @PLACA,                        
		                @FABRICANTE,
                        @QTDLITROSTANQUE,
		                @QTDPORTAS,                        
                        @NUMEROCHASSI,
                        @COR, 
		                @CAPACIDADEOCUPANTES,
                        @ANOFABRICACAO,
                        @TAMANHOPORTAMALAS,
                        @TIPOCOMBUSTIVEL,
                        @GRUPOVEICULO_ID,
                        @IMAGEM,
                        @MODELO,
                        @QUILOMETRAGEM
	                )";

        public override string InserirNovo(Veiculo registro)
        {
            string resultadoValidacaoDominio = registro.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirVeiculo, ObtemParametrosVeiculo(registro));
            }

            return resultadoValidacaoDominio;
        }

        public override string Editar(int id, Veiculo registro)
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

        public override Veiculo SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Veiculo> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, object> ObtemParametrosVeiculo(Veiculo veiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", veiculo.Id);
            parametros.Add("PLACA", veiculo.Placa);
            parametros.Add("MODELO", veiculo.Modelo);
            parametros.Add("FABRICANTE", veiculo.Fabricante);
            parametros.Add("QUILOMETRAGEM", veiculo.Quilometragem);
            parametros.Add("QTDLITROSTANQUE", veiculo.QtdLitrosTanque);
            parametros.Add("QTDPORTAS", veiculo.QtdPortas);
            parametros.Add("NUMEROCHASSI", veiculo.NumeroChassi);
            parametros.Add("COR", veiculo.Cor);
            parametros.Add("CAPACIDADEOCUPANTES", veiculo.CapacidadeOcupantes);
            parametros.Add("ANOFABRICACAO", veiculo.AnoFabricacao);
            parametros.Add("TAMANHOPORTAMALAS", veiculo.TamanhoPortaMalas);
            parametros.Add("TIPOCOMBUSTIVEL", (int)veiculo.TipoCombustivel);
            parametros.Add("GRUPOVEICULO_ID", veiculo.Grupo.Id);
            parametros.Add("IMAGEM", veiculo.Imagem);


            return parametros;
        }
    }
}
