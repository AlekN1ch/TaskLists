using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskLists
{
    public partial class Form1 : Form
    {
        public static string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = WorksList.accdb";
        private OleDbConnection myConnection;

        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "worksListDataSet.worksTable". При необходимости она может быть перемещена или удалена.
            this.worksTableTableAdapter.Fill(this.worksListDataSet.worksTable);
            timer1.Start();
            Filler();
            listBox1.Visible = true;
            listBox2.Visible = false;
            label2.BackColor = Color.Khaki;
            label3.BackColor = Color.Transparent;
        }
        public void Filler()
        {
            string query = "SELECT description FROM worksTable ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString());
            }
            reader.Close();
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Filler();
            this.worksTableTableAdapter.Fill(this.worksListDataSet.worksTable);
            Filler();
        }
        public void Now()
        {
            Filler();
            this.worksTableTableAdapter.Fill(this.worksListDataSet.worksTable);
            Filler();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void Del()
        {
            if (listBox1.SelectedIndex != -1)
            {
                string value = listBox1.SelectedItem.ToString();
                string quare = " DELETE FROM worksTable WHERE[description] = " + "('" + value + "')";
                OleDbCommand command = new OleDbCommand(quare, myConnection);
                command.ExecuteNonQuery();
                Now();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox2.Visible = false;
            label2.BackColor = Color.Khaki;
            label3.BackColor = Color.Transparent;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            listBox2.Visible = true;
            listBox1.Visible = false;
            label3.BackColor = Color.Khaki;
            label2.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Now();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
            Del();
        }
    }
}
