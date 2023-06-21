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
    public partial class AddTeacher : Form
    {
        Form1 f;
        public AddTeacher(Form1 f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var FirstName = textBox1.Text;
            var SecondName = textBox2.Text;

            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nevermage\\Desktop\\CS\\C_sharp_lab_4\\C_sharp_lab_4\\university.mdf;Integrated Security=True";

            string sqlExpression = ($"INSERT INTO Teachers (FirstName,SecondName) VALUES ('{FirstName}','{SecondName}')");

            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine(number);
            }
            f.View();
            this.Close();
            

        }
    }
}
