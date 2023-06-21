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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            View();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucaa\\source\\repos\\C_sharp_lab_4\\C_sharp_lab_4\\university.mdf;Integrated Security=True";

            string sqlExpression = "INSERT INTO Teachers (FirstName,SecondName) VALUES ('Maksym','Bihunov')";

            using (SqlConnection connection=new SqlConnection(connectionsString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Dob obj: {0}", number);
            }*/
            AddTeacher addTeacher = new AddTeacher(this);
            addTeacher.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSubject addSubject = new AddSubject(this);
            addSubject.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddLink addLink = new AddLink(this);
            addLink.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void View()
        {
            dataGridView1.Rows.Clear();
            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nevermage\\Desktop\\CS\\C_sharp_lab_4\\C_sharp_lab_4\\university.mdf;Integrated Security=True";

            string sqlExpression = "SELECT FirstName,SecondName, Name FROM Teachers JOIN TeachersToSub ON Teachers.Id=TeachersToSub.TeacherId JOIN Subjects ON Subjects.Id = TeachersToSub.SubjectId";

            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (res.Read())
                {
                    /*string FN = res.GetString(0);
                    string SN = res.GetString(1);
                    string N = res.GetString(2);
                    Console.WriteLine($"{FN} \t{SN} \t{N}");*/

                    data.Add(new string[3]);

                    data[data.Count - 1][0] = res[0].ToString();
                    data[data.Count - 1][1] = res[1].ToString();
                    data[data.Count - 1][2] = res[2].ToString();

                }
                res.Close();
                connection.Close();
                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateForm updateForm = new UpdateForm(this);
            updateForm.ShowDialog();
        }
    }
}
