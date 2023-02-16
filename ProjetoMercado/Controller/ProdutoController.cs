using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoMercado.Model;
using ProjetoMercado.View;

namespace ProjetoMercado.Controller
{
    class ProdutoController //: FornecedorController
    {
        private static ViewProdutoCadastro janelaCadastroProduto;
        public static void IniciarCadastro()
        {
            janelaCadastroProduto = new ViewProdutoCadastro();
            janelaCadastroProduto.ShowDialog();
        }
        public static void FecharCadastro()
        {
            janelaCadastroProduto.Close();
        }
        public static void Cadastrar(string nome, int fornecedor, double valor, int estoque, int codigo)
        {
            ProdutoModel novoProduto = new ProdutoModel();
            novoProduto.Nome = nome;
            novoProduto.Fornecedor = fornecedor;
            novoProduto.Valor = valor;
            novoProduto.Estoque = estoque;
            novoProduto.Codigo = codigo;

            bool sucesso = ProdutoModel.Salvar(novoProduto);

            if (sucesso)
            {
                FecharCadastro();
                System.Windows.Forms.MessageBox.Show
                    (
                        "Produto cadastrado com sucesso!", "Sucesso"
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
            elementoVisual.DataSource = ProdutoModel.Buscar();
        }
    }
}
