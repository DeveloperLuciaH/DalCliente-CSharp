using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Prj_DALCliente
{
    class Conexao
    {

        // armazena a string de conexão
        private string _stringConexao;

        // armazena a conexão realizada
        private SqlConnection _conexao;

        public Conexao(string dadosConexao)
        {
            this._conexao = new SqlConnection();
            this._stringConexao = dadosConexao;
            this._conexao.ConnectionString = dadosConexao;
        }

        public string StringConexao { get => _stringConexao; set => _stringConexao = value; }
        public SqlConnection ObjetoConexao { get => _conexao; set => _conexao = value; }

        public void Conectar()
        {
            this._conexao.Open();
        }

        public void Desconectar()
        {
            this._conexao.Close();
        }

    }
}
