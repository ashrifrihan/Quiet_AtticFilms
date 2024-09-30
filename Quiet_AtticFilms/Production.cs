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
    public partial class Production : Form
    {
        public Production()
        {
            InitializeComponent();
        }

        private void btuSave_Click(object sender, EventArgs e)
        {
            string productionID = txt_ProductionID.Text;
            string productionName = txt_ProductionName.Text;
            string productionQuantity = txt_ProductionQuantity.Text;
            string productionType = txt_txt_ProductionType.Text;
            string productionPrice = txt_Production_Price.Text;
            string clientFk = comBox_client.SelectedValue.ToString();
            string sql = $"insert into Production (Production_name,Production_Quantity,Production_type,Production_Price,Clientid_fk) values ('{productionName}','{productionQuantity}','{productionType}','{productionPrice}','{clientFk}')";
            Database.save(sql);
            loadtabTableFunction();
        }

        private void Production_Load(object sender, EventArgs e)
        {
            Database.loadFkDataInComboBox("SELECT *FROM Client", comBox_client, "Client_id", "Client_name");
            loadtabTableFunction() ;
        }

        private void loadtabTableFunction()
        {
            Database.loadDataFromDBtoDataGridView("select p.Production_id as ID, p.Production_name as Production, p.Production_Quantity as Quantity,p.Production_type as Type , p.Production_Price as Price, p.Clientid_fk as Client from Production p", proGridview);
        }

        private void btuUpdate_Click(object sender, EventArgs e)
        {
            string productionID = txt_ProductionID.Text;
            string productionName = txt_ProductionName.Text;
            string productionQuantity = txt_ProductionQuantity.Text;
            string productionType = txt_txt_ProductionType.Text;
            string productionPrice = txt_Production_Price.Text;
            string clientFk = comBox_client.SelectedValue.ToString();
            string sql = $"update Production set Production_name = '{productionName}', Production_Quantity = '{productionQuantity}', Production_type = '{productionType}', Production_Price = '{productionPrice}', Clientid_fk = '{clientFk}' where Production_id = '{productionID}'";
            Database.update(sql);
            loadtabTableFunction();
        }

        private void btuDelete_Click(object sender, EventArgs e)
        {
            string productionID = txt_ProductionID.Text;
            string sql = $"delete from Production where Production_id = '{productionID}'";
            Database.delete(sql);
            loadtabTableFunction();
        }

        private void proGridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            string empid = proGridview.Rows[rowindex].Cells[0].Value.ToString();
            string sql = $"select * from Production where Production.Production_id = '{empid}'";
            DataTable dt = Database.getDataFromDB(sql);

            if (dt.Rows.Count > 0)
            {
                txt_ProductionID.Text = dt.Rows[0]["Production_id"].ToString();
                txt_ProductionName.Text = dt.Rows[0]["Production_name"].ToString();
                txt_ProductionQuantity.Text = dt.Rows[0]["Production_Quantity"].ToString();
                txt_Production_Price.Text = dt.Rows[0]["Production_Price"].ToString();
                txt_txt_ProductionType.Text = dt.Rows[0]["Production_type"].ToString(); ;
                comBox_client.SelectedValue = dt.Rows[0]["Clientid_fk"].ToString();
            }
        }
    }
}
