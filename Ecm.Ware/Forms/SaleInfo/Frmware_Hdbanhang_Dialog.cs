using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hdbanhang_Dialog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet dsCollection = new DataSet();
        public DataRow drHdbanhang;
        
        public Frmware_Hdbanhang_Dialog()
        {
            InitializeComponent();
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridView1.BestFitColumns();

            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //gridLookUpEdit_Cuahang_Ban
                gridLookUpEdit_Cuahang_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];

                //gridLookUpEdit_Kho_Hanghoa_Mua
                //gridLookUpEdit_Kho_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua().ToDataSet().Tables[0];

                //gridLookUpEdit_Nhansu
                gridLookUpEdit_Nhansu.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];

                //grid
                //dgware_Hdbanhang.DataSource = objWareService.Get_All_Ware_Hdbanhang().ToDataSet().Tables[0];
                dgware_Hdbanhang.DataSource = objWareService.Get_All_Ware_Xuatkho_Banhang().ToDataSet().Tables[0];
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void setDs_Xuatkho_Banhang()
        {
            dgware_Hdbanhang.DataSource = objWareService.Get_All_Ware_Xuatkho_Banhang().ToDataSet().Tables[0];
            this.gridView1.BestFitColumns();
        }

        public void loadDS_Hoadon(object id_Khachhang)
        {
            dgware_Hdbanhang.DataSource = objWareService.Get_All_Ware_Hdbanhang_ById_khachhang(id_Khachhang).ToDataSet().Tables[0];
        }

        public override object PerformSelectOneObject()
        {
            if (gridView1.GetFocusedRowCellValue("Doc_Process_Status") != null)
            {
                if (gridView1.GetFocusedRowCellValue("Doc_Process_Status").ToString() != "2")
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Hóa đơn này chưa được kiểm duyệt nên không thể xuất Phiếu thu");
                    return false;
                }
            }
            if (gridView1.GetFocusedRowCellValue("Sotien").Equals(gridView1.GetFocusedRowCellValue("Sotien_Thanhtoan")))
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Hóa đơn này đã thanh toán đủ tiền, nên không thể xuất thêm Phiếu thu");
                return false;
            }
            drHdbanhang = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            this.Dispose();
            this.Close();
            return null;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (gridView1.GetFocusedRowCellValue("Doc_Process_Status") != null)
            //{
            //    if (gridView1.GetFocusedRowCellValue("Doc_Process_Status").ToString() == "2")
            //        this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    else
            //        this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
        }
    }
}

