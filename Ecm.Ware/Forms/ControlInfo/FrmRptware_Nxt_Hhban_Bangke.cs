using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class FrmRptware_Nxt_Hhban_Bangke :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection;

        public FrmRptware_Nxt_Hhban_Bangke()
        {
            InitializeComponent();

            dtNgay_Batdau.EditValue = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 23, 59, 59);

            DisplayInfo();
        }

        #region  Override

        public override void DisplayInfo()
        {
            gridmLookUpEdit_Nhom_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet().Tables[0];
            gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet().Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];

            gridLookUpEdit_Kho_Hanghoa.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa().ToDataSet().Tables[0];

            DataSet dsAll_Hanghoa = objMasterService.Get_All_Ware_Dm_Hanghoa().ToDataSet();
            gridLookUpEdit_Ma_Hanghoa.DataSource = dsAll_Hanghoa.Tables[0];
            gridLookUpEdit_Ten_Hanghoa.DataSource = dsAll_Hanghoa.Tables[0];

            base.DisplayInfo();
        }

        public override bool PerformQuery()
        {
            try
            {
                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
                hashtableControls.Add(txtMa_Hanghoa, lblMa_Hanghoa.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                ds_Collection = objWareService.Rptware_Nxt_Hhban_Bangke(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime, txtMa_Hanghoa.EditValue).ToDataSet();

                dgware_Hanghoa_Bangke_Chitiet.DataSource = ds_Collection;
                dgware_Hanghoa_Bangke_Chitiet.DataMember = ds_Collection.Tables[0].TableName;

                bandedGridView1.BestFitColumns();
            }
            catch { }
            return base.PerformQuery();
        }

        public override bool PerformPrintPreview()
        {
            dgware_Hanghoa_Bangke_Chitiet.ShowPrintPreview();
            return base.PerformPrintPreview();
        }
        #endregion

        private void txtTen_hanghoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Tree frmware_Dm_Hanghoa_Tree = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Tree();
            //frmware_Dm_Hanghoa_Tree.Text = lblMa_Hanghoa.Text;
            // GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Tree);
            //frmware_Dm_Hanghoa_Tree.ShowDialog();

            //if (frmware_Dm_Hanghoa_Tree.SelectedRow != null)
            //{
            //    txtMa_Hanghoa.EditValue = frmware_Dm_Hanghoa_Tree.SelectedRow["Ma_Ql"];
            //    txtTen_hanghoa.EditValue = frmware_Dm_Hanghoa_Tree.SelectedRow["Ten_Hanghoa"];
            //} 
        }
    }
}