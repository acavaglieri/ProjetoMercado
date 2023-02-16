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

namespace ProjetoMercado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteController.IniciarCadastro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteController.Listar(dataGridView1);
        }
        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteController.Remover();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FornecedorController.IniciarCadastro();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FornecedorController.Listar(dataGridView1);
        }

        private void removerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FornecedorController.Remover();
        }

        private void cadastrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ProdutoController.IniciarCadastro();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProdutoController.Listar(dataGridView1);
        }

        private void excluirEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdutoController.Remover();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VendaController.Listar(dataGridView1);
        }

        private void cadastrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            VendaController.IniciarCadastro();
        }

        //Plus
        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendaController.Listar(dataGridView1);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdutoController.Listar(dataGridView1);
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteController.Listar(dataGridView1);
        }

        private void atualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProdutoController.Listar(dataGridView1);
        }
    }
}
