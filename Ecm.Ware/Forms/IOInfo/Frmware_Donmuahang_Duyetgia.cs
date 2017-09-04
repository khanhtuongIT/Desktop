using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Donmuahang_Duyetgia :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public DataSet ds_Donmuahang_Chitiet_Ncc = new DataSet();
        public DataSet ds_Donmuahang_Chitiet = new DataSet();
        public DataRow[] SelectedRow = null;

        #region Properties
        object id_donmuahang;
        public object Id_Donmuahang
        {
            get { return id_donmuahang; }
            set
            {
                id_donmuahang = value;
                DisplayInfo();
            }
        }
        #endregion

        public Frmware_Donmuahang_Duyetgia()
        {
            InitializeComponent();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        #region Event Override

        public override void DisplayInfo()
        {
            //lookUpEdit_Hanghoa_Mua
            DataSet ds_hanghoa_ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            gridLookUpEdit_Hanghoa.DataSource = ds_hanghoa_ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa.DataSource = ds_hanghoa_ban.Tables[0];
            gridLookUpEdit_Hanghoa_2.DataSource = ds_hanghoa_ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_2.DataSource = ds_hanghoa_ban.Tables[0];

            //gridLookUpEdit_Donvitinh
            DataSet ds_donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            gridLookUpEdit_Donvitinh.DataSource = ds_donvitinh.Tables[0];
            gridLookUpEdit_Donvitinh_2.DataSource = ds_donvitinh.Tables[0];

            //Get data Ware_Dm_Nhacungcap --> chuyển sang lấy từ ware_dm_khachhang
            DataSet ds_Nhacungcap = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            gridLookUpEditNhacungcap.DataSource = ds_Nhacungcap.Tables[0];
            gridLookUpEdit_Nhacungcap_2.DataSource = ds_Nhacungcap.Tables[0];

            //dgware_Donmuahang_Chitiet
            if (id_donmuahang != null)
            {
                //dgware_Donmuahang_Chitiet_Ncc
                ds_Donmuahang_Chitiet_Ncc = objWareService.Get_All_Ware_Ncc_By_Donmuahang(id_donmuahang).ToDataSet();
                dgware_Donmuahang_Chitiet_Ncc.DataSource = ds_Donmuahang_Chitiet_Ncc;
                dgware_Donmuahang_Chitiet_Ncc.DataMember = ds_Donmuahang_Chitiet_Ncc.Tables[0].TableName;          

                //dgware_Donmuahang_Chitiet
                ds_Donmuahang_Chitiet = objWareService.Get_All_Ware_Donmuahang_Chitiet_By_Donmuahang(id_donmuahang).ToDataSet();
                dgware_Donmuahang_Chitiet.DataSource = ds_Donmuahang_Chitiet;
                dgware_Donmuahang_Chitiet.DataMember = ds_Donmuahang_Chitiet.Tables[0].TableName;            
           
            }
            gridView1.BestFitColumns();
            gridView5.BestFitColumns();
            gridView1.OptionsBehavior.Editable = false;
            base.DisplayInfo();
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView5.Columns["Id_Khachhang"], "");
            hashtableControls.Add(gridView5.Columns["Dongia"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView5))
                return false;

            try
            {
                //update dgware_Donmuahang_Chitiet_Ncc
                this.DoClickEndEdit(dgware_Donmuahang_Chitiet_Ncc); 
                objWareService.Update_Ware_Donmuahang_Chitiet_Ncc_Collection(this.ds_Donmuahang_Chitiet_Ncc);

                //update dgware_Donmuahang_Chitiet
                this.DoClickEndEdit(dgware_Donmuahang_Chitiet); 
                objWareService.Update_Ware_Donmuahang_Chitiet_Collection(ds_Donmuahang_Chitiet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
            this.DoClickEndEdit(dgware_Donmuahang_Chitiet);
            SelectedRow = ds_Donmuahang_Chitiet_Ncc.Tables[0].Select("Chon = True ");
            this.Close();
            return base.PerformSelectOneObject();
        }

        #endregion

        #region Even

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia")
            {
                if ("" + gridView1.GetFocusedRowCellValue("Soluong") != ""
                    && "" + gridView1.GetFocusedRowCellValue("Dongia") != "")
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Thanhtien"], Convert.ToDecimal(gridView5.GetFocusedRowCellValue("Soluong"))
                                                                 * Convert.ToDecimal(gridView5.GetFocusedRowCellValue("Dongia")));
            }
            else if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
            }
            this.DoClickEndEdit(dgware_Donmuahang_Chitiet);
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //uncheck others
                this.DoClickEndEdit(dgware_Donmuahang_Chitiet_Ncc);
                int check = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.GetRowCellValue(i, gridView5.Columns["Guid"]).Equals(gridView5.GetFocusedRowCellValue("Guid")))
                    {
                        if (gridView5.GetRowCellValue(i, gridView5.Columns["Chon"]).ToString() != "")
                            if (Convert.ToBoolean(gridView5.GetRowCellValue(i, gridView5.Columns["Chon"])))
                                check++;
                    }
                }
                if (check > 1)
                {
                    MessageBox.Show("Không được chọn 2 giá khác nhau cho cùng một mặt hàng");
                    gridView5.SetFocusedRowCellValue(gridView5.Columns["Chon"], false);
                }

                //cap nhat ncc & gia
                DataRow[] sdr_chitiet = ds_Donmuahang_Chitiet.Tables[0].Select("Id_Donmuahang_Chitiet = " + gridView5.GetFocusedRowCellValue("Id_Donmuahang_Chitiet"));
                sdr_chitiet[0]["Id_Khachhang"] = gridView5.GetFocusedRowCellValue("Id_Khachhang");
                sdr_chitiet[0]["Dongia"] = gridView5.GetFocusedRowCellValue("Dongia");
                sdr_chitiet[0]["Thanhtien"] = Convert.ToDecimal(sdr_chitiet[0]["Soluong"]) * Convert.ToDecimal(sdr_chitiet[0]["Dongia"]);
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion


    }
}