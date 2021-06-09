using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_DALCliente
{
    class DALCliente
    {
        private Conexao objConexao;

        public DALCliente(Conexao conexao)
        {
            objConexao = conexao;
        }

        public void Incluir(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO cliente (NOME,CPF,RG,EMAIL) values(@nome, @cpf, @rg, @email); Select @@IDENTITY;";
            // cmd.CommandText = "insert into cliente values(0, @nome,@cpf,@rg,@email);Select @@IDENTITY;";
            // cmd.CommandText = "insert into cliente values('', @nome,@cpf,@rg,@email);Select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.CPF);
            cmd.Parameters.AddWithValue("@rg", cliente.RG);
            cmd.Parameters.AddWithValue("@email", cliente.Email);

            objConexao.Conectar();
            cliente.Id = Convert.ToInt32(cmd.ExecuteScalar());
            objConexao.Desconectar();
        }

        public void Alterar(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            cmd.CommandText = "update cliente set NOME=@nome,CPF=@cpf,RG=@rg,EMAIL=@email where id=@id";
            cmd.Parameters.AddWithValue("@id", cliente.Id);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.CPF);
            cmd.Parameters.AddWithValue("@rg", cliente.RG);
            cmd.Parameters.AddWithValue("@email", cliente.Email);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();
        }

        public void Excluir (int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            cmd.CommandText = "delete from cliente where id=@id";
            cmd.Parameters.AddWithValue("@id", codigo);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

        }

        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from cliente where nome like'%" + valor + "%'", objConexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public Cliente carregaCliente (int codigo)
        {
            Cliente c = new Cliente();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            cmd.CommandText = "select * from cliente WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", codigo);

            objConexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();
                c.Id = Convert.ToInt32(registro["id"]);
                c.Nome = Convert.ToString(registro["nome"]);
                c.CPF = Convert.ToString(registro["cpf"]);
                c.RG = Convert.ToString(registro["rg"]);
                c.Email = Convert.ToString(registro["email"]);
            }

            objConexao.Desconectar();
            return c;
        }
    }
}