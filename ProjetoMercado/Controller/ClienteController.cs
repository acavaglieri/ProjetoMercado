using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoMercado.Model;
using ProjetoMercado.View;

namespace ProjetoMercado.Controller
{
    class ClienteController
    {
        private static ViewClienteCadastro janelaCadastroCliente;
        public static void IniciarCadastro()
        {
            janelaCadastroCliente = new ViewClienteCadastro();
            janelaCadastroCliente.ShowDialog();
        }
        public static void FecharCadastro()
        {
            janelaCadastroCliente.Close();
        }
        public static void Cadastrar(string nome, string endereco, string bairro, string cidade, string estado, string cep, string telefone, string cpf, string rg)
        {
            ClienteModel novoCliente = new ClienteModel();
            novoCliente.Nome = nome;
            novoCliente.Endereco = endereco;
            novoCliente.Bairro = bairro;
            novoCliente.Cidade = cidade;
            novoCliente.Estado = estado;
            novoCliente.Cep = cep;
            novoCliente.Telefone = telefone;
            novoCliente.Cpf = cpf;
            novoCliente.Rg = rg;

            bool sucesso = ClienteModel.Salvar(novoCliente);

            if(sucesso)
            {
                FecharCadastro();
                System.Windows.Forms.MessageBox.Show
                    (
                        "Cliente cadastrado com sucesso!", "Sucesso"
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
            elementoVisual.DataSource = ClienteModel.Buscar();
        }

    }
}
