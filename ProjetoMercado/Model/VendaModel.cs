using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ProjetoMercado.Model
{
    class VendaModel
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
       
        private int cliente;
        public int Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        private DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        
        public static bool Salvar(VendaModel novoVenda)
        {
            Utils.DB banco = new Utils.DB();
            string query = "INSERT INTO venda(cliente, data, codigo) VALUES(@cliente, @data, @codigo)";

            List<MySqlParameter> conteudo = new List<MySqlParameter>();
            conteudo.Add(new MySqlParameter("@cliente", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@data", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@codigo", MySqlDbType.String));

            conteudo[0].Value = novoVenda.cliente;
            conteudo[1].Value = novoVenda.data;
            conteudo[2].Value = novoVenda.codigo;

            return banco.Inserir(query, conteudo);
        }
        public static bool Editar(VendaModel qualVenda)
        {
            return false;
        }
        public static bool Remover(VendaModel qualvenda)
        {
            Utils.DB banco = new Utils.DB();
            string query = "DELETE FROM venda(cliente, data, codigo) VALUES(cliente, @data, @codigo)";

            List<MySqlParameter> conteudo = new List<MySqlParameter>();

            return banco.Remover(query, conteudo);
            
        }
        public static System.Data.DataTable Buscar()
        {
            Utils.DB banco = new Utils.DB();
            string query = "SELECT * FROM venda;";
            return banco.Buscar(query, null);
        }
    }
}
