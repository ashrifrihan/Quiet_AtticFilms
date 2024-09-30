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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void btn_production_Click(object sender, EventArgs e)
        {
            loadform(new Production());
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            loadform(new staff());
        }

        private void btn_client_Click(object sender, EventArgs e)
        {
            loadform(new Client());
        }

        private void btn_propeaty_Click(object sender, EventArgs e)
        {
            loadform(new Property());
        }

        private void btn_locations_Click(object sender, EventArgs e)
        {
            loadform(new Location());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new proTOstaff());

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
            MessageBox.Show("You have been logged out", "Loggedout ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    
        private void btn_home_Click(object sender, EventArgs e)
        {
            loadform(new DashboadSimple());

        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
