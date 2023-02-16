using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoMercado.Model;
using ProjetoMercado.View;


namespace ProjetoMercado.Controller
{
    class FornecedorController
    {
        private static ViewFornecedorCadastro janelaCadastroFornecedor;
        public static void IniciarCadastro()
        {
            janelaCadastroFornecedor = new ViewFornecedorCadastro();
            janelaCadastroFornecedor.ShowDialog();
        }
        public static void FecharCadastro()
        {
            janelaCadastroFornecedor.Close();
        }
        public static void Cadastrar(string nome, string endereco, string bairro, string cidade, string estado, string cep, string telefone, string cnpj, string codigo)
        {
            FornecedorModel novoFornecedor = new FornecedorModel();
            novoFornecedor.Nome = nome;
            novoFornecedor.Endereco = endereco;
            novoFornecedor.Bairro = bairro;
            novoFornecedor.Cidade = cidade;
            novoFornecedor.Estado = estado;
            novoFornecedor.Cep = cep;
            novoFornecedor.Telefone = telefone;
            novoFornecedor.Cnpj = cnpj;
            novoFornecedor.Codigo = codigo;

            bool sucesso = FornecedorModel.Salvar(novoFornecedor);

            if (sucesso)
            {
                FecharCadastro();
                System.Windows.Forms.MessageBox.Show
                    (
                        "Fornecedor cadastrado com sucesso!", "Sucesso"
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

        //Remoção
        public static void IniciarRemocao() { }
        public static void FecharRemocao() { }
        public static void Remover() { }

        //Listar
        public static void Listar(System.Windows.Forms.DataGridView elementoVisual)
        {
            elementoVisual.DataSource = FornecedorModel.Buscar();
        }
    }
}
