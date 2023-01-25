using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginFormWindowApplication
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-FATC326B\SQLEXPRESS;Initial Catalog=ajay;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == ""  && textBox2.Text == "" && TextBox3.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please Enter Password", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (textBox2.Text == TextBox3.Text)
            {
                con.Open();
                string register = "INSERT INTO Login_new VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";
                cmd = new SqlCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                TextBox3.Text = "";

                MessageBox.Show("Your Account Has Been Successfully Created","Registration Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
       
            else
            {
                MessageBox.Show("Password does not match, please Re-Enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                TextBox3.Text = "";
                textBox2.Focus();
            }

    }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                TextBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '•';
                TextBox3.PasswordChar = '•';
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            TextBox3.Text = "";
            textBox1.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
