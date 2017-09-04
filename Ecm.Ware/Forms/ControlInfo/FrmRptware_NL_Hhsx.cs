using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class FrmRptware_NL_Hhsx :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();

        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet dsWare_Hhban_Quydoi_Hhmua = new DataSet();

        public FrmRptware_NL_Hhsx()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            
            dtNgay_Batdau.EditValue = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 23, 59, 59);

            DisplayInfo();
        }

        #region Override Events

        public override void DisplayInfo()
        {
            //gridLookUpEdit_Hanghoa_Ban
            DataSet ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];

            //gridLookUpEdit_Loai_Hanghoa_Ban
            gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet().Tables[0];

            //gridLookUpEdit_Nhom_Hanghoa_Ban
            gridLookUpEdit_Nhom_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet().Tables[0];

            //lookUpEditCuahang_Ban
            lookUpEditCuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];

            base.DisplayInfo();
        }

        public override bool PerformQuery()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
            hashtableControls.Add(lookUpEditCuahang_Ban, lblCuahang_Ban.Text);

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            objMasterService.Ware_Hhban_Quydoi_Hhmua_Init();

            dsWare_Hhban_Quydoi_Hhmua = objMasterService.Ware_Hhban_Quydoi_Hhmua_SelectByHhsx(
                dtNgay_Batdau.EditValue
                , dtNgay_Ketthuc.EditValue
                , lookUpEditCuahang_Ban.EditValue
                , rdg_Filter_Cond.EditValue).ToDataSet();
            dgware_Dm_Hanghoa_Ban.DataSource = dsWare_Hhban_Quydoi_Hhmua;
            dgware_Dm_Hanghoa_Ban.DataMember = dsWare_Hhban_Quydoi_Hhmua.Tables[0].TableName;
            
            gvNguyenlieu.BestFitColumns();

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
    }
}