using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Hanghoa_Ban_Dgvon :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsWare_Hhban_Quydoi_Hhmua = new DataSet();

        public Frmware_Dm_Hanghoa_Ban_Dgvon()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();
        }

        #region Override Events

        public override void DisplayInfo()
        {
            //gridLookUpEdit_Hanghoa_Ban
            DataSet ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            gridLookUp_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUp_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];

            //gridLookUpEdit_Loai_Hanghoa_Ban
            gridLookUp_Loai_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet().Tables[0];

            //gridLookUpEdit_Nhom_Hanghoa_Ban
            gridLookUp_Nhom_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet().Tables[0];

            //dgware_Dm_Hanghoa_Ban
            dsWare_Hhban_Quydoi_Hhmua = objMasterService.Ware_Hhban_Quydoi_Hhmua_SelectAll().ToDataSet();
            dgware_Dm_Hanghoa_Ban.DataSource = dsWare_Hhban_Quydoi_Hhmua;
            dgware_Dm_Hanghoa_Ban.DataMember = dsWare_Hhban_Quydoi_Hhmua.Tables[0].TableName;
            base.DisplayInfo();
        }

        public override bool PerformQuery()
        {
            objMasterService.Ware_Hhban_Quydoi_Hhmua_Init();
            DisplayInfo();
            return base.PerformQuery();
        }

        public override bool PerformPrintPreview()
        {
            dgware_Dm_Hanghoa_Ban.ShowPrintPreview();
            return base.PerformPrintPreview();
        }

        #endregion

        private void dgware_Dm_Hanghoa_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        private void btnExpExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "Excel|*.xls";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                dgware_Dm_Hanghoa_Ban.ExportToXls(SaveFileDialog.FileName);
            }
        }

        private void dgware_Dm_Hanghoa_Ban_Click(object sender, EventArgs e)
        {

        }

    }
}

