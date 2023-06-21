using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_lab_4
{
    public partial class AddSubject : Form
    {
        Form1 Form1;
        public AddSubject(Form1 f)
        {
            Form1 = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var SubName = textBox1.Text;

            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nevermage\\Desktop\\CS\\C_sharp_lab_4\\C_sharp_lab_4\\university.mdf;Integrated Security=True";

            string sqlExpression = ($"INSERT INTO Subjects (Name) VALUES ('{SubName}')");

            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine(number);
            }
            Form1.View();
            this.Close();
        }
    }
}
