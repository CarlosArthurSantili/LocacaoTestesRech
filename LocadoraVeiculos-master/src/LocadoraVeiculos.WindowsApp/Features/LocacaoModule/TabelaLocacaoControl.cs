using LocadoraVeiculos.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
        {
            InitializeComponent();
        }

        internal void AtualizarRegistros(List<Locacao> registros)
        {
            throw new NotImplementedException();
        }

        internal int ObterIdSelecionado()
        {
            throw new NotImplementedException();
        }
    }
}
