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
    public partial class Form3 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-K6A2GOM\SQLEXPRESS;Initial Catalog=login;Integrated Security=True"); //Rohan
        public static string SetValueForText1;
        public static string reserveColor;
        public Form3()
        {
            InitializeComponent();
        }
        
        private void TableFunc()
        {
            int tableNo = Convert.ToInt32(tableComboBox.Text);
            SetValueForText1 = tableNo.ToString();
            
        }

        

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string tableNo = tableComboBox.Text;
            string isTableExist = null;
            reserveColor = "Red";
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                SqlCommand commandToCheckTable = new SqlCommand("select Convert(Varchar(10), tableNo) from reservationDetails where Convert(Varchar(10), tableNo)=@parameter_tableNo", connect);
                commandToCheckTable.Parameters.AddWithValue("@parameter_tableNo", tableNo);
                isTableExist = (string)commandToCheckTable.ExecuteScalar();
                connect.Close();
                string seletedTableColor = reserveColor;
                if (isTableExist == tableNo)
                {
                    connect.Open();
                    string query = "select color from reservationDetails where tableNo=@parameter_tableNo";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@parameter_tableNo", tableNo);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["color"].ToString() == "Red")
                        {
                            MessageBox.Show("Table is Already Occupied! Look for Another Table.");

                        }
                        if (rdr["color"].ToString() == "Yellow")
                        {
                            MessageBox.Show("Table is Already Reserved! Look for Another Table.");

                        }
                    }
                    connect.Close();
                }
                else
                {
                    if(tableNo != "")
                    {
                        connect.Open();
                        string query = "Insert into reservationDetails (tableNo, color)  values (@parameter_tableNo, @parameter_color)";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@parameter_tableNo", tableNo);
                        cmd.Parameters.AddWithValue("@parameter_color", seletedTableColor);
                        cmd.ExecuteNonQuery();
                    }
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

            if (tableNo == "")
            {
                MessageBox.Show("Please Select Table No first :)");
            }
            else
            {
                TableFunc();
                if (isTableExist != tableNo)
                {
                    new Form2().Show();
                    this.Hide();
                }
                tableComboBox.Text = "";
                tableComboBox.Focus();
            }
        }

        int counter = 0;
        int len = 0;
        string txt;

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            txt = welcomeText3.Text;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            len = txt.Length;
            welcomeText3.Text = "";
            counter++;
            if(counter > len)
            {
                counter = 0;
                welcomeText3.Text = "";
            }
            else
            {
                
                welcomeText3.Text = txt.Substring(0, counter);
            }
        }
        
        string isTableExist = null;
        private void button1_Click(object sender, EventArgs e)
        {
            string tableNo = tableComboBox.Text;
            reserveColor = "Yellow";
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                SqlCommand commandToCheckTable = new SqlCommand("select Convert(Varchar(10), tableNo) from reservationDetails where Convert(Varchar(10), tableNo)=@parameter_tableNo", connect);
                commandToCheckTable.Parameters.AddWithValue("@parameter_tableNo", tableNo);
                isTableExist = (string)commandToCheckTable.ExecuteScalar();
                connect.Close();
                string seletedTableColor = reserveColor;
                if (isTableExist == tableNo)
                {
                    connect.Open();
                    string query = "select color from reservationDetails where tableNo=@parameter_tableNo";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@parameter_tableNo", tableNo);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if(rdr["color"].ToString() == "Yellow")
                        {
                            MessageBox.Show("Table is Already Reserved! Look for Another Table.");

                        }
                        if (rdr["color"].ToString() == "Red")
                        {
                            MessageBox.Show("Table is Already Occupied! Look for Another Table.");

                        }
                    }
                    connect.Close();
                    
                }
                else
                {
                    if(tableNo != "")
                    {
                        connect.Open();
                        string query = "Insert into reservationDetails (tableNo, color)  values (@parameter_tableNo, @parameter_color)";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@parameter_tableNo", tableNo);
                        cmd.Parameters.AddWithValue("@parameter_color", seletedTableColor);
                        cmd.ExecuteNonQuery();
                    }
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
            
            if (tableNo == "")
            {
                MessageBox.Show("Please Select Table No first :)");
            }
            if(tableNo != "")
            {
                TableFunc();
                if(isTableExist != tableNo)
                {
                    new Form2().Show();
                    this.Hide();
                }
                tableComboBox.Text = "";
                tableComboBox.Focus();
            }
        }

        private void tableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string tableNo = tableComboBox.Text;
            try
            {
                if(connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                SqlCommand commandToCheckTable = new SqlCommand("select Convert(Varchar(10), tableNo) from reservationDetails where Convert(Varchar(10), tableNo)=@parameter_tableNo", connect);
                commandToCheckTable.Parameters.AddWithValue("@parameter_tableNo", tableNo);
                isTableExist = (string)commandToCheckTable.ExecuteScalar();
                connect.Close();
                if(isTableExist == tableNo)
                {
                    SetValueForText1 = tableNo;
                }
                else
                {
                    SetValueForText1 = "";
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                if(connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            new Form2().Show();
            this.Hide();
        }
    }
}
