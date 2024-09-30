using Quiet_AtticFilms.Class;
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
    public partial class proTOstaff : Form
    {
        public proTOstaff()
        {
            InitializeComponent();
        }

        private void btuSave_Click(object sender, EventArgs e)
        {
            string productionFK = comBox_production.SelectedValue.ToString();
            string staff= comBox_staff.SelectedValue.ToString();
            string sql = $"insert into ProToStaff (Production,Staff) values ('{productionFK}','{staff}')";
            Database.save(sql);
            loadtabTableFunction();
        }

        private void proTOstaff_Load(object sender, EventArgs e)
        {
            Database.loadFkDataInComboBox("SELECT *FROM Production", comBox_production, "Production_id", "Production_name");
            Database.loadFkDataInComboBox("SELECT * FROM Staff", comBox_staff, "Staff_id", "Staff_name");
            loadtabTableFunction();
        }

        private void loadtabTableFunction()
        {
            Database.loadDataFromDBtoDataGridView("select * from ProToStaff ", proTOstaffGridView);
        }

        private void btuUpdate_Click(object sender, EventArgs e)
        {
            string id = txt_ID.Text;
            string productionFK = comBox_production.SelectedValue.ToString();
            string staff = comBox_staff.SelectedValue.ToString();
            string sql = $"update ProToStaff set Production = '{productionFK}', Staff = '{staff}' where ID = '{id}'";
            Database.update(sql);
            loadtabTableFunction();
        }

        private void btuDelete_Click(object sender, EventArgs e)
        {
            string id = txt_ID.Text;
            string sql = $"delete from ProToStaff where ID = '{id}'";
            Database.delete(sql);
            loadtabTableFunction();
        }

        private void proTOstaffGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            string id = proTOstaffGridView.Rows[rowindex].Cells[0].Value.ToString();
            string sql = $"select * from ProToStaff where ProToStaff.ID = '{id}'";
            DataTable dt = Database.getDataFromDB(sql);

            if (dt.Rows.Count > 0)
            {
                txt_ID.Text = dt.Rows[0]["ID"].ToString();
                comBox_production.SelectedValue = dt.Rows[0]["Production"].ToString();
                comBox_staff.SelectedValue = dt.Rows[0]["Staff"].ToString();
            }
        }
    }
}
