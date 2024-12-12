using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TaskLists
{
    public partial class Form2 : Form
    {
        public static string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = WorksList.accdb";
        private OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string desc=textBox1.Text;
            string query = "INSERT INTO worksTable ([description]) VALUES " + "('" + desc + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            this.Close();

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "worksListDataSet.worksTable". При необходимости она может быть перемещена или удалена.
            this.worksTableTableAdapter.Fill(this.worksListDataSet.worksTable);

        }
    }
}
