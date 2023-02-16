using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetoMercado.Utils
{
    class DB
    {
        private string host = "localhost";
        private string username = "root";
        private string password = " ";
        private string database = "fhomercado";
        private MySqlConnection conexao;

        //Construtor
        public DB()
        {
            string chamadaConexao = "SERVER=" + host + ";"+ "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            conexao = new MySqlConnection(chamadaConexao);
        }
        // Abrie e fechar conexão

        private bool AbrirConexao()
        {
            try
            {
                conexao.Open();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show
                    (
                        "Erro ao abrir conexão: " + ex.Message, "Erro"
                    );
                return false;
            }
        }
        private bool FecharConexao()
        {
            try
            {
                conexao.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show
                    (
                        "Erro ao fechar conexão: " + ex.Message, "Erro"
                    );
                return false;
            }
        }
        public bool Inserir(string query, List<MySqlParameter>parametros)
        {

            if(AbrirConexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                if (parametros != null)
                    for (int i = 0; i < parametros.Count; i++)
                        cmd.Parameters.Add(parametros[i]);
                int resposta = cmd.ExecuteNonQuery();
                Console.WriteLine("Resposta insert: " + resposta);

                FecharConexao();

                if (resposta != 0)
                    return true;
                return false;
            }
            return false;
        }

        public bool Atualizar(string query, List<MySqlParameter> parametros)
        {
            return Inserir(query, parametros);
        }
        public bool Remover(string query, List<MySqlParameter> parametros)
        {
            return Inserir(query, parametros);
        }

        public DataTable Buscar(string query, List<MySqlParameter> parametros)
        {
            try
            {
                if(AbrirConexao())
                {
                    DataTable tabelaResposta = null;

                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    if (parametros != null)
                        for (int i = 0; i < parametros.Count; i++)
                            cmd.Parameters.Add(parametros[i]);

                    MySqlDataReader data = cmd.ExecuteReader();
                    List<string> registros = new List<string>();

                    DataTable esquemaBanco = data.GetSchemaTable();
                    tabelaResposta = new DataTable(); 

                    if (data != null && esquemaBanco != null)
                    {
                        foreach(DataRow linha in esquemaBanco.Rows)
                        {
                            
                            if(!tabelaResposta.Columns.Contains(linha["ColumnName"].ToString()))
                            {
                                DataColumn col = new DataColumn()
                                {
                                    ColumnName = linha["ColumnName"].ToString(),
                                    Unique = Convert.ToBoolean(linha["IsUnique"]),
                                    AllowDBNull = Convert.ToBoolean(linha["AllowDBNull"]),
                                    ReadOnly = Convert.ToBoolean(linha["IsReadOnly"])
                                };
                                tabelaResposta.Columns.Add(col);
                            }

                        }
                        while(data.Read())
                        {
                            DataRow novoRegistro = tabelaResposta.NewRow();
                            for (int i = 0; i < tabelaResposta.Columns.Count; i++)
                                novoRegistro[i] = data.GetValue(i);
                            tabelaResposta.Rows.Add(novoRegistro);
                        }
                        data.Close();
                    }

                    return tabelaResposta;
                }
                else
                    return null;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro MySQL: " + ex.Message, "Erro");
                return null;
            }
        }
    }
}
