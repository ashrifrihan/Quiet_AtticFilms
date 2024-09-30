using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiet_AtticFilms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btuLogin_Click(object sender, EventArgs e)
        {
            {
                string username = txt_userName.Text;
                string password = txt_Password.Text;
                if (txt_userName.Text == "Rihan" && txt_Password.Text == "ashrif20912")
                {
                    MessageBox.Show("Login_Successfully", "Login_Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Dashboard Loginform = new Dashboard();
                    Loginform.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Insert correct username and password");
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox_Show_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Show.Checked == true)
            {
                txt_Password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_Password.UseSystemPasswordChar = true;
            }
        }

        private void txt_userName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
