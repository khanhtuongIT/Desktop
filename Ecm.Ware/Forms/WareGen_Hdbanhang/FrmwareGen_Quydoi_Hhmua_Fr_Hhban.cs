using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms.WareGen_Hdbanhang
{
    public partial class FrmwareGen_Quydoi_Hhmua_Fr_Hhban :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet dsWareGen_Quydoi_Hhmua_Fr_Hhban;
        public DataRow[] SelectedRows;

        public FrmwareGen_Quydoi_Hhmua_Fr_Hhban()
        {
            InitializeComponent();

            dtNgay_Batdau.DateTime = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 0, 0, 0);
            dtNgay_Ketthuc.DateTime = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 23, 59, 59);

            DisplayInfo();
        }

        #region  Override

        public override void DisplayInfo()
        {
            //gridLookUpEdit_Donvitinh
            gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];

            //gridLookUpEdit_Ma_Hanghoa_Mua
            DataSet dsHanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua().ToDataSet();
            gridLookUpEdit_Ma_Hanghoa_Mua.DataSource = dsHanghoa_Mua.Tables[0];
            gridLookUpEdit_Hanghoa_Mua.DataSource = dsHanghoa_Mua.Tables[0];

            base.DisplayInfo();
        }

        public override bool PerformQuery()
        {
            dsWareGen_Quydoi_Hhmua_Fr_Hhban = objWareService.Get_All_WareGen_Quydoi_Hhmua_Fr_Hhban(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue).ToDataSet();
            dsWareGen_Quydoi_Hhmua_Fr_Hhban.Tables[0].Columns.Add("Chon", typeof(bool));
            dgWareGen_Quydoi_Hhmua_Fr_Hhban.DataSource = dsWareGen_Quydoi_Hhmua_Fr_Hhban;
            dgWareGen_Quydoi_Hhmua_Fr_Hhban.DataMember = dsWareGen_Quydoi_Hhmua_Fr_Hhban.Tables[0].TableName;

            gridView5.BestFitColumns();
            return base.PerformQuery();
        }

        public override object PerformSelectOneObject()
        {
            this.DoClickEndEdit(dgWareGen_Quydoi_Hhmua_Fr_Hhban);
            SelectedRows = dsWareGen_Quydoi_Hhmua_Fr_Hhban.Tables[0].Select("Chon = true");
            this.Close();
            return base.PerformSelectOneObject();
        }
        #endregion
    }
}