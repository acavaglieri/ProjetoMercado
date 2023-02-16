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
    public partial class ViewProdutoCadastro : Form
    {
        public ViewProdutoCadastro()
        {
            InitializeComponent();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            ProdutoController.Cadastrar
                (
                    textBoxNome.Text,
                    int.Parse(textBoxFornecedor.Text),
                    double.Parse(textBoxValor.Text),
                    int.Parse(textBoxEstoque.Text),
                    int.Parse(textBoxCodigo.Text)
                );
        }

    }
}
