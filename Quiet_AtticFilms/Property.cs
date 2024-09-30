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
    public partial class Property : Form
    {
        public Property()
        {
            InitializeComponent();
        }

        private void empGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btuSave_Click(object sender, EventArgs e)
        {
            string propertyName = txt_PropertyName.Text;
            string propertyAddress = txt_PropertyAddress.Text;
            string propertyType = txt_PropertyType.Text;
            string location = comBox_location.Text;

            string sql = $"";
        }
    }
}
