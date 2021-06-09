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
    public partial class FrmLocalizar : Form
    {
        public int codigo = 0;
        public FrmLocalizar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Conexao cx = new Conexao("Data Source=LUCIAH\\SQLEXPRESS;Initial Catalog=DAL;Integrated Security=True");
            DALCliente dal = new DALCliente(cx);
            dataGridView1.DataSource = dal.Localizar(textBox1.Text);           

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        } 
    }
}
