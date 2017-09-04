using System;
using System.Data;
using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class FrmRptWare_DataLog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        DataSet ds_Collection;

        public FrmRptWare_DataLog()
        {
            InitializeComponent();

            dtNgay_Batdau.EditValue = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 23, 59, 59);

            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


        }

        public override bool PerformQuery()
        {
            try
            {
                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                ds_Collection = objWareService.RptWare_GetAllDataLog(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime).ToDataSet();

                dgware_Hanghoa_Bangke_Chitiet.DataSource = ds_Collection;
                dgware_Hanghoa_Bangke_Chitiet.DataMember = ds_Collection.Tables[0].TableName;

                bandedGridView1.BestFitColumns();
            }
            catch(Exception ex) { }
            return base.PerformQuery();
        }

        public override bool PerformPrintPreview()
        {
            dgware_Hanghoa_Bangke_Chitiet.ShowPrintPreview();
            return base.PerformPrintPreview();
        }

    }
}