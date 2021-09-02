using System.Windows.Forms;

namespace LocacaoVeiculos.WindowsApp.Shared
{
    public interface ICadastravel
    {
        void InserirNovoRegistro();

        void EditarRegistro();

        void ExcluirRegistro();

        UserControl ObterTabela();
    }
}
