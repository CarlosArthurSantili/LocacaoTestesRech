using LocacaoVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public class ConfiguracaoLocacaoToolbox : IConfiguracaoToolbox
    {
        public string ObtemDescricao()
        {
            return "Controle de Tarefas";
        }

        public ConfiguracaoEstadoBotoes ObtemEstadoBotoes()
        {
            return new ConfiguracaoEstadoBotoes()
            {
                Adicionar = true,
                Editar = true,
                Excluir = true,
                Filtrar = true,
                Agrupar = false
            };
        }

        public ConfiguracaoTooltips ObtemToolTips()
        {
            return new ConfiguracaoTooltips();
        }
    }
}
