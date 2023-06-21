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
    public partial class UpdateForm : Form
    {
        Form1 f;
        Dictionary<string,int> teachers = new Dictionary<string, int>();
        Dictionary<string,int> subjects = new Dictionary<string, int>();
        public UpdateForm(Form1 f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateT(textBox2.Text, textBox3.Text);
        }


        public void UpdateT(string FirstName, string SecondName)
        {
            string sqlExpression="";
            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nevermage\\Desktop\\CS\\C_sharp_lab_4\\C_sharp_lab_4\\university.mdf;Integrated Security=True";
            teachers.TryGetValue(comboBox2.SelectedItem.ToString(), out int id);
            if (FirstName == "" && SecondName=="")
            {
                MessageBox.Show("Incorrect data");
            }
            else if (FirstName == "" && SecondName != "")
            {
                
                sqlExpression = ($"UPDATE Teachers SET SecondName = '{SecondName}' WHERE Id='{id}'");
            }
            else if (FirstName != "" && SecondName == "")
            {
                sqlExpression = ($"UPDATE Teachers SET FirstName = '{FirstName}' WHERE Id='{id}'");
            }
            else
            {
                sqlExpression = ($"UPDATE Teachers SET FirstName = '{FirstName}', SecondName = '{SecondName}' WHERE Id='{id}'");
            }

            if (sqlExpression!="")
            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine(number);
                f.View();
                this.Close();
            }
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            
            

            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nevermage\\Desktop\\CS\\C_sharp_lab_4\\C_sharp_lab_4\\university.mdf;Integrated Security=True";

            string sqlExpression = ("SELECT * FROM Teachers");
            string sqlExpression2 = ("SELECT * FROM Subjects");


            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    int id = result.GetInt32(0);
                    string FN = result.GetString(1);
                    string SN = result.GetString(2);


                    teachers.Add(FN + " " + SN,id);


                }
                result.Close();
                command = new SqlCommand(sqlExpression2, connection);
                result = command.ExecuteReader();
                while (result.Read())
                {
                    subjects.Add(result.GetString(1),result.GetInt32(0));


                }
                result.Close();

            }

            foreach (var t in teachers)
            {
                comboBox2.Items.Add(t.Key);
            }
            foreach (var s in subjects)
            {
                comboBox1.Items.Add(s.Key);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlExpression = "";
            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nevermage\\Desktop\\CS\\C_sharp_lab_4\\C_sharp_lab_4\\university.mdf;Integrated Security=True";
            subjects.TryGetValue(comboBox1.SelectedItem.ToString(), out int id);

            if (textBox1.Text == "")
                MessageBox.Show("Incorrect data");
            else
                sqlExpression = $"UPDATE Subjects SET Name='{textBox1.Text}' WHERE Id = '{id}'";

            if (sqlExpression != "")
                using (SqlConnection connection = new SqlConnection(connectionsString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine(number);
                    f.View();
                    this.Close();
                }
        }
    }
}
