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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void btuSave_Click(object sender, EventArgs e)
        {
            string clientName = txt_clientName.Text;
            string clientNumber = txt_clientNum.Text;
            string clientAddress = txt_clientAddress.Text;
            string sql = $"INSERT INTO Client ( Client_name,Client_number,Client_Address) VALUES ('{txt_clientName.Text}', '{txt_clientNum.Text}', '{txt_clientAddress.Text}')";
            Database.save(sql);
            loadtabTableFunction();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            loadtabTableFunction();
        }

        private void loadtabTableFunction() 
        {
            Database.loadDataFromDBtoDataGridView("SELECT * FROM Client", clientGridView);
        }

        private void clientGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            string AppliedID = clientGridView.Rows[rowindex].Cells[0].Value.ToString();
            string sql = $"select * from Client where Client.Client_id = '{AppliedID}'";
            DataTable dt = Database.getDataFromDB(sql);

            if (dt.Rows.Count > 0)
            {
                txt_ClientID.Text = dt.Rows[0]["Client_id"].ToString();
                txt_clientName.Text = dt.Rows[0]["Client_name"].ToString();
                txt_clientNum.Text = dt.Rows[0]["Client_number"].ToString();
                txt_clientAddress.Text = dt.Rows[0]["Client_Address"].ToString();

            }
        }

        private void btuUpdate_Click(object sender, EventArgs e)
        {
            string sql = $"update Client set Client_name = '{txt_clientName.Text}', Client_number = '{txt_clientNum.Text}', Client_Address = '{txt_clientAddress.Text}' where Client_id = '{txt_ClientID.Text}'";
            Database.update(sql);
            loadtabTableFunction();
        }

        private void btuDelete_Click(object sender, EventArgs e)
        {
            string sql = $"delete from Client where Client_id = '{txt_ClientID.Text}'";
            Database.delete(sql);
            loadtabTableFunction();
        }

        private void btuClear_Click(object sender, EventArgs e)
        {
            {
                Commom_class.clearInputs(new List<Control>()
            {
                txt_ClientID,
                txt_clientName,
                txt_clientNum,
                txt_clientAddress,

         });

            }
        }
    }
}
