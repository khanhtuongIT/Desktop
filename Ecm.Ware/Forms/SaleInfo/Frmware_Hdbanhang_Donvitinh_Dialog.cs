using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hdbanhang_Donvitinh_Dialog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Donvitinh = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();
        public DataSet ds_Selected = new DataSet();
        object id_Hanghoa_Ban;
        public object Id_Donvitinh; //Id_Hanghoa_Dinhgia;


        public Frmware_Hdbanhang_Donvitinh_Dialog()
        {
            InitializeComponent();
            this.BarSystem.Visible = false;
        }

        public void setId_Hanghoa_Ban(object id_hanghoa_ban)
        {
            this.id_Hanghoa_Ban = id_hanghoa_ban;
            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();

            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Ten_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];
            if ("" + id_Hanghoa_Ban != "")
            {
                ds_Donvitinh = objMasterService.Ware_Dm_Donvitinh_Quydoi_By_Id_Hanghoa_Ban(id_Hanghoa_Ban).ToDataSet();
                dgware_Donvitinh_Quydoi.DataSource = ds_Donvitinh;
                dgware_Donvitinh_Quydoi.DataMember = ds_Donvitinh.Tables[0].TableName;
            }
            else
                dgware_Donvitinh_Quydoi.DataSource = null;
        }

        #region  Even

        private void btnBack_Click(object sender, EventArgs e)
        {
            cardView1.MovePrevPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cardView1.MoveNextPage();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cardView1_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView1.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                if (ds_Donvitinh.Tables.Count == 0)
                    return;

                Id_Donvitinh = cardView1.GetRowCellValue(cardHit.RowHandle, cardView1.Columns["Id_Donvitinh"]);
                this.Hide();
            }
        }
        #endregion


    }
}

