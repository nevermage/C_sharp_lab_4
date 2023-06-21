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
    public partial class AddLink : Form
    {
        Form1 f;
        Dictionary<string, int> teachers = new Dictionary<string, int>();
        Dictionary<string, int> subjects = new Dictionary<string, int>();
        public AddLink(Form1 f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void AddLink__Load(object sender, EventArgs e)
        {
            /*List<string> teachers = new List<string>();
            List<string> subjects = new List<string>();*/

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
                    teachers.Add(result.GetString(1) + " " + result.GetString(2),result.GetInt32(0));
                    /*string FN = result1.GetString(0);
                    string SN = result1.GetString(1);

                    Console.WriteLine($"{FN} \t{SN}");*/


                }
                result.Close();
                command = new SqlCommand(sqlExpression2, connection);
                result = command.ExecuteReader();
                while (result.Read())
                {
                    subjects.Add(result.GetString(1),result.GetInt32(0));
                    /*string FN = result1.GetString(0);
                    string SN = result1.GetString(1);

                    Console.WriteLine($"{FN} \t{SN}");*/


                }
                result.Close();
            }

            foreach (var t in teachers)
            {
                comboBox1.Items.Add(t.Key);
            }

            foreach (var s in subjects)
            {
                comboBox2.Items.Add(s.Key);
            }





        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            teachers.TryGetValue(comboBox1.SelectedItem.ToString(), out int IdT);
            subjects.TryGetValue(comboBox2.SelectedItem.ToString(), out int IdS);



            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nevermage\\Desktop\\CS\\C_sharp_lab_4\\C_sharp_lab_4\\university.mdf;Integrated Security=True";

            string sqlExpression = ($"INSERT INTO TeachersToSub (TeacherId,SubjectId) VALUES ('{IdT}','{IdS}')");

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
