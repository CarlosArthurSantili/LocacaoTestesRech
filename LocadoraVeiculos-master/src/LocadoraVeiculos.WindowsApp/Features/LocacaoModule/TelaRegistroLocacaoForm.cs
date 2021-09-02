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
    public partial class TelaRegistroLocacaoForm : Form
    {
        public TelaRegistroLocacaoForm()
        {
            InitializeComponent();
        }

        public Locacao Locacao { get; internal set; }

        private void TelaRegistroLocacaoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
