using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ProjetoMercado.Model
{
    class FornecedorModel
    {
        private string codigo;
        public string Codigo
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
        private string endereco;
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        private string bairro;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }
        private string cidade;
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private string cep;
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }
        private string telefone;
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        private string cnpj;
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        public static bool Salvar(FornecedorModel novoFornecedor)
        {
            Utils.DB banco = new Utils.DB();
            string query = "INSERT INTO fornecedor(nome, endereco, bairro, cidade, uf, telefone, cnpj, codigo) VALUES(@nome, @endereco, @bairro, @cidade, @uf, @telefone, @cnpj, @codigo)";

            List<MySqlParameter> conteudo = new List<MySqlParameter>();
            conteudo.Add(new MySqlParameter("@nome", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@endereco", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@bairro", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@cidade", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@uf", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@telefone", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@cnpj", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@codigo", MySqlDbType.String));

            conteudo[0].Value = novoFornecedor.nome;
            conteudo[1].Value = novoFornecedor.endereco;
            conteudo[2].Value = novoFornecedor.bairro;
            conteudo[3].Value = novoFornecedor.cidade;
            conteudo[4].Value = novoFornecedor.estado;
            conteudo[5].Value = novoFornecedor.telefone;
            conteudo[6].Value = novoFornecedor.cnpj;
            conteudo[7].Value = novoFornecedor.codigo;

            return banco.Inserir(query, conteudo);
        }
        public static bool Editar(FornecedorModel qualFornecedor)
        {
            return false;
        }
        public static bool Remover(FornecedorModel qualFornecedor)
        {
            Utils.DB banco = new Utils.DB();
            string query = "DELETE FROM fornecedor(nome, endereco, bairro, cidade, uf, telefone, cnpj, codigo) VALUES(@nome, @endereco, @bairro, @cidade, @uf, @telefone, @cnpj, @codigo)";

            List<MySqlParameter> conteudo = new List<MySqlParameter>();

            return banco.Remover(query, conteudo);
            
        }
        public static System.Data.DataTable Buscar()
        {
            Utils.DB banco = new Utils.DB();
            string query = "SELECT * FROM fornecedor;";
            return banco.Buscar(query, null);
        }


    }
}
