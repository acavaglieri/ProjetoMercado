using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoMercado.Model;
using ProjetoMercado.View;

namespace ProjetoMercado.Controller
{
    class VendaController
    {
        private static ViewVendaCadastro janelaCadastroVenda;
        public static void IniciarCadastro()
        {
            janelaCadastroVenda = new ViewVendaCadastro();
            janelaCadastroVenda.ShowDialog();
        }
        public static void FecharCadastro()
        {
            janelaCadastroVenda.Close();
        }
        public static void Cadastrar(int cliente, DateTime data, int codigo)
        {
            VendaModel novoVenda = new VendaModel();
            novoVenda.Data = data;
            novoVenda.Cliente = cliente;
            novoVenda.Codigo = codigo;

            bool sucesso = VendaModel.Salvar(novoVenda);

            if (sucesso)
            {
                FecharCadastro();
                System.Windows.Forms.MessageBox.Show
                    (
                        "Venda cadastrado com sucesso!", "Sucesso"
                    );
            }
            else
            {
                System.Windows.Forms.MessageBox.Show
                    (
                        "Erro ao cadastrar!", "Erro"
                    );

            }
        }
        //Atualização
        public static void IniciarAtualizacao() { }
        public static void FecharAtualizacao() { }
        public static void Atualizar() { }

        //Remoção - apagar ***estoque***
        public static void IniciarRemocao() { }
        public static void FecharRemocao() { }
        public static void Remover() { }

        //Listar
        public static void Listar(System.Windows.Forms.DataGridView elementoVisual)
        {
            elementoVisual.DataSource = VendaModel.Buscar();
        }
    }
}
