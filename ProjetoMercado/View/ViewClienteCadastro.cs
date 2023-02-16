using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProjetoMercado.Controller;

namespace ProjetoMercado.View
{
    public partial class ViewClienteCadastro : Form
    {
        public ViewClienteCadastro()
        {
            InitializeComponent();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            ClienteController.Cadastrar
                (
                    textBoxNome.Text,
                    textBoxEndereco.Text,
                    textBoxBairro.Text,
                    textBoxCidade.Text,
                    textBoxEstado.Text,
                    maskedTextBoxCep.Text,
                    maskedTextBoxTelefone.Text,
                    maskedTextBoxCpf.Text,
                    textBoxRg.Text
                );
        }

    }
}
