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
    public partial class staff : Form
    {
        public staff()
        {
            InitializeComponent();
        }

        private void btuSave_Click(object sender, EventArgs e)
        {
            string StaffName = txt_staffName.Text;
            string StaffNumber = txt_phoneNum.Text;
            string staffType = txt_staffType.Text;
            string sql = $"insert into Staff (Staff_name,Staff_Phone_Num,Staff_type) values ('{StaffName}','{StaffNumber}','{staffType}')";
            Database.save(sql);
            loadtabTableFunction();
        }

        private void loadtabTableFunction()
        {
            Database.loadDataFromDBtoDataGridView("\r\nselect s.Staff_id as ID, s.Staff_name as Name, s.Staff_Phone_Num as Mobile_Number,s.Staff_type as Type from Staff s", staffGridview);
        }

        private void btuUpdate_Click(object sender, EventArgs e)
        {
            string ID = txt_staffID.Text;
            string StaffName = txt_staffName.Text;
            string StaffNumber = txt_phoneNum.Text;
            string staffType = txt_staffType.Text;
            string sql = $"update Staff set Staff_name = '{StaffName}' , Staff_Phone_Num = '{StaffNumber}' , Staff_type = '{staffType}' where Staff_id = '{ID}'";
            Database.update(sql);
            loadtabTableFunction();
        }

        private void btuDelete_Click(object sender, EventArgs e)
        {
            string ID = txt_staffID.Text;
            string sql = $"delete from Staff where Staff_id = '{ID}'";
            Database.delete(sql);
            loadtabTableFunction();
        }

        private void staff_Load(object sender, EventArgs e)
        {
            loadtabTableFunction();
        }

        private void staffGridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            string staffID = staffGridview.Rows[rowindex].Cells[0].Value.ToString();
            string sql = $"select * from Staff where Staff.Staff_id = '{staffID}'";
            DataTable dt = Database.getDataFromDB(sql);

            if (dt.Rows.Count > 0)
            {
                txt_staffID.Text = dt.Rows[0]["Staff_id"].ToString();
                txt_staffName.Text = dt.Rows[0]["Staff_name"].ToString();
                txt_phoneNum.Text = dt.Rows[0]["Staff_Phone_Num"].ToString();
                txt_staffType.Text = dt.Rows[0]["Staff_type"].ToString();
            }
        }
    }
}
