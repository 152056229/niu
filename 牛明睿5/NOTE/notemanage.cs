using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using JKLibrary;
using MySql.Data.MySqlClient;

namespace NOTE
{
    public partial class notemanage : Form
    {
        public notemanage()
        {
            InitializeComponent();
        }

        //private void notemanage_Load(object sender, EventArgs e)
        //{
        //    // TODO: 这行代码将数据加载到表“noteDataSet1.NoteInfo”中。您可以根据需要移动或删除它。
        //    this.noteInfoTableAdapter.Fill(this.noteDataSet1.NoteInfo);

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dt = SQLHelper.GetDataSet("select * from NoteInfo ", null);
            string conn = "server=.;database=NOTE;uid=sa;pwd=root";
            SqlConnection mycon = new SqlConnection(conn);
            mycon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mycon;
            cmd.CommandText = "UPDATE NoteInfo SET note = '" + textBox3.Text + "'WHERE Classify='" + textBox1.Text + "' and Title='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            if (dt.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("修改成功！");
                return;
            }
            else
            {
                MessageBox.Show("修改失败！");
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {}

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = SQLHelper.GetDataSet("select * from NoteInfo ", null);
            string conn = "server=.;uid=sa;password=root;Database=NOTE";
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM NoteInfo", conn);
            da.Fill(ds, "NoteInfo");
            SqlConnection mycon = new SqlConnection(conn);
            mycon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mycon;
            cmd.CommandText = "UPDATE NoteInfo SET note = '" + textBox3.Text + "'WHERE Classify='" + textBox1.Text + "' and Title='" + textBox2.Text + "'";
            
            int n=0;
            for (int i = 0; i < ds.Tables.Count;i++ )
            {
                System.Data.DataTable dt = ds.Tables[i];
                if (dt.Rows.Count > 0)
                    n += dt.Rows.Count;
            }
            for (int i = 0; i < n; i++)
            { 
                if(ds.Tables["NoteInfo"].Rows[i]["Title"].ToString().Equals(textBox1.Text) ){
                    textBox1.Text = ds.Tables["NoteInfo"].Rows[i]["Title"].ToString();
                    textBox2.Text = ds.Tables["NoteInfo"].Rows[i]["Classify"].ToString();
                    textBox3.Text = ds.Tables["NoteInfo"].Rows[i]["note"].ToString();

                }
            }
           
        }
    }
}
