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
    public partial class ViewVendaCadastro : Form
    {
        public ViewVendaCadastro()
        {
            InitializeComponent();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            VendaController.Cadastrar
               (
                   
                   int.Parse(textBoxCliente.Text),
                   DateTime.Parse(maskedTextBoxData.Text),
                   int.Parse(textBoxCodigo.Text)     
               );
            
        }
    }
}
