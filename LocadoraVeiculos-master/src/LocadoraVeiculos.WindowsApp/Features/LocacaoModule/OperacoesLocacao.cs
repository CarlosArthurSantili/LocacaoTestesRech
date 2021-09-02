using LocacaoVeiculos.WindowsApp.Shared;
using LocadoraVeiculos.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public class OperacoesLocacao : ICadastravel
    {
        private readonly ControladorLocacao controladorLocacao = null;

        private readonly TabelaLocacaoControl tabelaLocacoes = null;

        public OperacoesLocacao(ControladorLocacao controlador)
        {
            controladorLocacao = controlador;
            tabelaLocacoes = new TabelaLocacaoControl();
        }

        public void InserirNovoRegistro()
        {
            var tela = new TelaRegistroLocacaoForm();
            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorLocacao.RegistrarNovaLocacao(tela.Locacao);

                var registros = controladorLocacao.SelecionarTodos();

                tabelaLocacoes.AtualizarRegistros(registros);
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaLocacoes.ObterIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma locacao para poder editar!", "Edição de Tarefas",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var locacaoSelecionada = controladorLocacao.SelecionarPorId(id);

            if (locacaoSelecionada != null)
            {
                MessageBox.Show("Não é permitido a edição de locacaos já concluídas!", "Edição de Tarefas",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaRegistroLocacaoForm();

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorLocacao.Editar(id, tela.Locacao);

                var registros = controladorLocacao.SelecionarTodos();

                tabelaLocacoes.AtualizarRegistros(registros);
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaLocacoes.ObterIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma locacao para poder exluir!", "Exclusão de Tarefas",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var locacaoSelecionada = controladorLocacao.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a locacao: [{locacaoSelecionada.Id}] ?", "Exclusão de Tarefas",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controladorLocacao.Excluir(id);

                var registros = controladorLocacao.SelecionarTodos();

                tabelaLocacoes.AtualizarRegistros(registros);
            }
        }

        public UserControl ObterTabela()
        {
            if (tabelaLocacoes != null)
            {
                var registros = controladorLocacao.SelecionarTodos();

                tabelaLocacoes.AtualizarRegistros(registros);
            }

            return tabelaLocacoes;
        }      
    }
}
