using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ProjetoMercado.Model
{
    class ProdutoModel
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private int fornecedor;
        public int Fornecedor
        {
            get { return fornecedor; }
            set { fornecedor = value; }
        }
        private double valor;
        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private int estoque;
        public int Estoque
        {
            get { return estoque; }
            set { estoque = value; }
        }
       
        public static bool Salvar(ProdutoModel novoProduto)
        {
            Utils.DB banco = new Utils.DB();
            string query = "INSERT INTO produto(nome, fornecedor, valor, estoque, codigo) VALUES(@nome, @fornecedor, @valor, @estoque, @codigo)";

            List<MySqlParameter> conteudo = new List<MySqlParameter>();
            conteudo.Add(new MySqlParameter("@nome", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@fornecedor", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@valor", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@estoque", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@codigo", MySqlDbType.String));

            conteudo[0].Value = novoProduto.nome;
            conteudo[1].Value = novoProduto.fornecedor;
            conteudo[2].Value = novoProduto.valor;
            conteudo[3].Value = novoProduto.estoque;
            conteudo[4].Value = novoProduto.codigo;

            return banco.Inserir(query, conteudo);
        }
        public static bool Editar(ProdutoModel qualProduto)
        {
            return false;
        }
        public static bool Remover(ProdutoModel qualproduto)
        {
            Utils.DB banco = new Utils.DB();
            string query = "DELETE FROM produto(nome, fornecedor, valor, estoque, codigo) VALUES(@nome, @fornecedor, @valor, @estoque, @codigo)";

            List<MySqlParameter> conteudo = new List<MySqlParameter>();

            return banco.Remover(query, conteudo);
        }
        public static System.Data.DataTable Buscar()
        {
            Utils.DB banco = new Utils.DB();
            string query = "SELECT * FROM produto;";
            return banco.Buscar(query, null);
        }


    }
}
