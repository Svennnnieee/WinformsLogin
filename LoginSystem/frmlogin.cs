using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace LoginSystem
{
    public partial class frmlogin : Form
    {
        private static string constring = "server=localhost;uid=root;pwd=;database=login";
        private MySqlConnection Connection { get; set; }

        public frmlogin()
        {
            Connection = new MySqlConnection(constring);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string login = "SELECT * FROM user_info WHERE Username = @Username and Password = @Password";
            Connection.Open();
            MySqlCommand comm = Connection.CreateCommand();
            comm.CommandText = login;
            comm.Parameters.AddWithValue("@Username", txtusername.Text);
            comm.Parameters.AddWithValue("@Password", txtpassword.Text);
            comm.ExecuteNonQuery();
            MySqlDataReader Reader = comm.ExecuteReader();

            if (Reader.Read() == true)
            {
                Connection.Close();
                new Dashboard().Show();
                this.Hide();
            }
            else
            {
                Connection.Close();
                MessageBox.Show("Invalid username or password, please try again!", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearTextBoxes();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void checkbxshowpas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxshowpas.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmregister().Show();
            this.Hide();
        }

        private void clearTextBoxes()
        {
            txtusername.Clear();
            txtpassword.Clear();
            txtusername.Focus();
        }
    }
}
