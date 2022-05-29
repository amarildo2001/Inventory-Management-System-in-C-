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
    public partial class porosi : Form
    {
        public porosi()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=NCS-PC;Initial Catalog=cprojekt;Integrated Security=True");
        void populate()
        {
            Con.Open();
            string Myqyery = "select * from klientat";
            SqlDataAdapter da = new SqlDataAdapter(Myqyery, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        void populate1()
        {
            Con.Open();
            string Myqyery = "select * from produktet";
            SqlDataAdapter da = new SqlDataAdapter(Myqyery, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox3.Text = row.Cells["Emri"].Value.ToString();
                textBox5.Text = row.Cells["Cmimi"].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["Emri"].Value.ToString();
                
            }
            
        }
        
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id, qty;
            int row = 0;
            dataGridView3.Rows.Add();
            row = dataGridView3.Rows.Count - 2;
            float price, total;
            string namek, namep,data;
            id = int.Parse(textBox5.Text);
            namek = (textBox2.Text);
            namep = (textBox3.Text);
            qty = int.Parse(textBox4.Text);
            price = float.Parse(textBox5.Text);
            total = qty * price;
            textBox6.Text = " " + total;
            data = (dateTimePicker2.Text);

            dataGridView3["id", row].Value = textBox1.Text;
            dataGridView3["namek", row].Value = textBox2.Text;
            dataGridView3["namep", row].Value = textBox3.Text;
            dataGridView3["qty", row].Value = textBox4.Text;
            dataGridView3["price", row].Value = textBox5.Text;
            dataGridView3["total", row].Value = textBox6.Text;
            dataGridView3["data", row].Value = dateTimePicker2.Text;

            float sum = 0;
            sum = sum + total;
            label13.Text = sum.ToString() + "  LEK";
        }

        private void porosi_Load(object sender, EventArgs e)
        {
            populate();
            populate1();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home hm = new home();
            hm.Show();
            this.Hide();
        }
    }
}
