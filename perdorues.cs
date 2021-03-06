using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class perdorues : Form
    {
        public perdorues()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=NCS-PC;Initial Catalog=cprojekt;Integrated Security=True");
        void populate()
        {
            Con.Open();
            string Myqyery = "select * from perdoruesit";
            SqlDataAdapter da = new SqlDataAdapter(Myqyery, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=NCS-PC;Initial Catalog=cprojekt;Integrated Security=True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("Insert into perdoruesit values(@ID,@Emri,@Username,@Password)", Con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Emri", textBox2.Text);
            cmd.Parameters.AddWithValue("@Username", textBox3.Text);
            cmd.Parameters.AddWithValue("@Password", textBox4.Text);
            cmd.ExecuteNonQuery();

            Con.Close();
            MessageBox.Show("Perdoruesi eshte shtuar me sukses!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=NCS-PC;Initial Catalog=cprojekt;Integrated Security=True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("Update perdoruesit set Emri=@Emri, Username=@Username, Password=@Password where ID=@ID", Con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Emri", textBox2.Text);
            cmd.Parameters.AddWithValue("@Username", textBox3.Text);
            cmd.Parameters.AddWithValue("@Password", textBox4.Text);

            cmd.ExecuteNonQuery();
            Con.Close();

            MessageBox.Show("Te dhenat e perdoruesit jane modifikuar me sukses!");
        }

        private void perdorues_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=NCS-PC;Initial Catalog=cprojekt;Integrated Security=True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("Delete perdoruesit where ID=@ID", Con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Te dhenat e perdoruesit jane fshire me sukses");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ID"].Value.ToString();
                textBox2.Text = row.Cells["Emri"].Value.ToString();
                textBox3.Text = row.Cells["Username"].Value.ToString();
                textBox4.Text = row.Cells["Password"].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            home hm = new home();
            hm.Show();
            this.Hide();
        }
    }
}
