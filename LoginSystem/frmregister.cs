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
    public partial class frmregister : Form
    {
        private static string constring = "server=localhost;uid=root;pwd=;database=login";
        private MySqlConnection Connection { get; set; }

        public frmregister()
        {
            Connection = new MySqlConnection(constring);
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string register = "INSERT INTO user_info (Username, Password) VALUES (@Username, @Password)";
            if (txtusername.Text == "" && txtpassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtpassword.Text == txtComPassword.Text)
            {
                Connection.Open();
                MySqlCommand comm = Connection.CreateCommand();
                comm.CommandText = register;
                comm.Parameters.AddWithValue("@Username", txtusername.Text);
                comm.Parameters.AddWithValue("@Password", txtpassword.Text);
                comm.ExecuteNonQuery();
                Connection.Close();

                clearTextBoxes(true);

                MessageBox.Show("Your account has been successfully created!", "registration success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password does not match, please re-enter", "registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void checkbxshowpas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxshowpas.Checked)
            {
                txtpassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearTextBoxes(true);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmlogin().Show();
            this.Hide();
        }

        private void clearTextBoxes(bool full)
        {
            if (true)
            {
                txtpassword.Clear();
                txtComPassword.Clear();
                txtpassword.Focus();
            } else
            {
                txtusername.Clear();
                txtpassword.Clear();
                txtComPassword.Clear();
                txtusername.Focus();
            }

        }
    }

}
