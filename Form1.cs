using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj_DALCliente
{
    public partial class FrmDalCliente : Form
    {
        public string operacao = "";

        public FrmDalCliente()
        {
            InitializeComponent();
        }

        public void AlteraBotoes(int op)
        {
            gbDados.Enabled = false;
            btnInserir.Enabled = false;
            btnLocalizar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;

            if (op == 1)
            {
                btnInserir.Enabled = true;
                btnLocalizar.Enabled = true;
            }

            if (op == 2)
            {
                gbDados.Enabled = true;
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
            }

            if (op == 3)
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        public void LimpaCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCPF.Clear();
            txtRG.Clear();
            txtEmail.Clear();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

       private void button1_Click(object sender, EventArgs e)
       {
           this.operacao = "inserir";
           this.AlteraBotoes(2);
       }

        private void FrmDalCliente_Load(object sender, EventArgs e)
        {
            this.AlteraBotoes(1);
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            FrmLocalizar f = new FrmLocalizar();
            f.ShowDialog();

            if (f.codigo != 0)
            {
                
                string strConexao = "Data Source=LUCIAH\\SQLEXPRESS;Initial Catalog=DAL;Integrated Security=True";
                Conexao con = new Conexao(strConexao);
                DALCliente dal = new DALCliente(con);

                Cliente c = dal.carregaCliente(f.codigo);
                txtId.Text = Convert.ToString(c.Id);
                txtNome.Text = (c.Nome);
                txtCPF.Text = (c.CPF);
                txtRG.Text = (c.RG);
                txtEmail.Text = (c.Email);
                AlteraBotoes(3);
            }

            // fecha o formulário de busca que foi aberto pelo "Dispose"
            f.Dispose();

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.AlteraBotoes(2);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.AlteraBotoes(1);
            this.LimpaCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente(0, txtNome.Text, txtCPF.Text, txtRG.Text, txtEmail.Text);

                if (txtNome.Text.Length <= 0)
                {
                    MessageBox.Show("Informe o Nome");
                    return;
                }

                if (txtCPF.Text.Length <= 0)
                {
                    MessageBox.Show("Informe o CPF");
                    return;
                }

                if (txtRG.Text.Length <= 0)
                {
                    MessageBox.Show("Informe o RG");
                    return;
                }

                if (txtEmail.Text.Length <= 0)
                {
                    MessageBox.Show("Informe o Email");
                    return;
                }
                
                String strConexao = "Data Source=LUCIAH\\SQLEXPRESS;Initial Catalog=DAL;Integrated Security=True";
                Conexao con = new Conexao(strConexao);
                DALCliente dal = new DALCliente(con);

                if (this.operacao == "inserir")
                {
                    dal.Incluir(c);
                    MessageBox.Show("Código Id salvo: " + c.Id.ToString(), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtId.Text = c.Id.ToString();
                }

                else
                {
                    c.Id = Convert.ToInt32(txtId.Text);
                    MessageBox.Show("Registro salvo com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.AlteraBotoes(1);
                this.LimpaCampos();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja realmente excluir o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d.ToString() == "Yes")
            {
                
                string strConexao = "Data Source=LUCIAH\\SQLEXPRESS;Initial Catalog=DAL;Integrated Security=True";
                Conexao con = new Conexao(strConexao);
                DALCliente dal = new DALCliente(con);

                try
                {
                    dal.Excluir(Convert.ToInt32(txtId.Text));
                    MessageBox.Show("Registro excluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.AlteraBotoes(1);
                this.LimpaCampos();

            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

