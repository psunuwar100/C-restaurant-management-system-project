using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System
{
    public partial class loginForm : Form
    {
       SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-K6A2GOM\SQLEXPRESS;Initial Catalog=login;Integrated Security=True"); //Rohan
       //SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-IIFK5IM\SQLEXPRESS;Initial Catalog=login;Integrated Security=True"); //Kushal
       //SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-23BLQQJ\SQLEXPRESS;Initial Catalog=login;Integrated Security=True");
        public loginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                string inputName = nameBox.Text;
                string inputPassword = passwordBox.Text;
                string query = "select name, password from loginInfo where name=@parameter_name and password=@parameter_password";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@parameter_name", inputName);
                cmd.Parameters.AddWithValue("@parameter_password", inputPassword);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    new Form3().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("login failed");
                    nameBox.Clear();
                    passwordBox.Clear();
                    nameBox.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void showPassword_Click(object sender, EventArgs e)
        {
            if(passwordBox.PasswordChar == '\0')
            {
                hidePassword.BringToFront();
                passwordBox.PasswordChar = '*';
            }
        }

        private void hidePassword_Click(object sender, EventArgs e)
        {
            if(passwordBox.PasswordChar == '*')
            {
                showPassword.BringToFront();
                passwordBox.PasswordChar = '\0';
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginHover(object sender, EventArgs e)
        {
            login.BackColor = Color.White;
            login.ForeColor = Color.FromArgb(255, 170, 76);
        }

        private void EndHover(object sender, EventArgs e)
        {
            login.BackColor = Color.FromArgb(255, 170, 76);
            login.ForeColor = Color.White;
        }
    }
}
