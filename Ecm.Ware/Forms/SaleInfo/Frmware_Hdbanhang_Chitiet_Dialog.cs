using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hdbanhang_Chitiet_Dialog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Hdbanhang = new DataSet();
        DataSet ds_Hdbanhang_Chitiet = new DataSet();
        public DataRow[] SelectedRows = null;
        object identity;

        #region Properties

        object id_cuahang_ban;
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set
            {
                id_cuahang_ban = value;
                id_kho_hanghoa_mua = null;

                gridView4.Columns.Remove(gridView4.Columns["Id_Hanghoa_Mua"]);

                ds_Hdbanhang = objWareService.Get_All_Ware_Hdbanhang_ByCuahang(id_cuahang_ban).ToDataSet();
                DisplayInfo();
            }
        }

        object id_kho_hanghoa_mua;
        public object Id_Kho_Hanghoa_Mua
        {
            get { return id_kho_hanghoa_mua; }
            set
            {
                id_kho_hanghoa_mua = value;
                id_cuahang_ban = null;

                gridView4.Columns.Remove(gridView4.Columns["Id_Hanghoa_Ban"]);

                ds_Hdbanhang = objWareService.Get_All_Ware_Hdbanhang_ByKhoHanghoa(id_kho_hanghoa_mua).ToDataSet();
                DisplayInfo();
            }
        }
        #endregion

        public Frmware_Hdbanhang_Chitiet_Dialog()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        #region Override

        public override void DisplayInfo()
        {
            try
            {
                //Set lại trạng thái form là view
                FormState =  GoobizFrame.Windows.Forms.FormState.View;

                //Get data Ware_Dm_Donvitinh
                gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];

                dgware_Hdbanhang.DataSource = ds_Hdbanhang;
                dgware_Hdbanhang.DataMember = ds_Hdbanhang.Tables[0].TableName;
                dgware_Hdbanhang.RefreshDataSource();

                this.gridView1.BestFitColumns();
                if (gridView1.RowCount > 0)
                    gridView1.FocusedRowHandle = gridView1.RowCount - 1;

                DisplayInfo2();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

            }

        }

        void DisplayInfo2()
        {
            try
            {
                if ("" + gridView1.GetFocusedRowCellValue("Id_Hdbanhang") == "")
                {
                    ds_Hdbanhang_Chitiet = new DataSet();
                    this.dgware_Hdbanhang_Chitiet.DataSource = null;
                    dgware_Hdbanhang_Chitiet.Refresh();
                    return;
                }
                else
                {
                    //neu chon khu vuc cua hang ban
                    if ("" + gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban") != "")
                    {
                        //Get data Ware_Dm_Hanghoa_Ban
                        DataSet dsHanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban"), gridView1.GetFocusedRowCellValue("Ngay_Chungtu")).ToDataSet();
                        gridLookUpEdit_Hanghoa_Ban.DataSource = dsHanghoa_Ban.Tables[0];
                        gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = dsHanghoa_Ban.Tables[0];

                        gridColumn11.Visible = true;
                        gridColumn5.Visible = true;
                        gridColumn12.Visible = false;
                        gridColumn7.Visible = false;

                    }
                    //neu chon khu vuc kho hang hoa mua
                    else if ("" + gridView1.GetFocusedRowCellValue("Id_Kho_Hanghoa_Mua") != "")
                    {
                        //Get data Ware_Dm_Hanghoa_Ban
                        DataSet dsHanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(gridView1.GetFocusedRowCellValue("Id_Kho_Hanghoa_Mua"), gridView1.GetFocusedRowCellValue("Ngay_Chungtu")).ToDataSet();
                        gridLookUpEdit_Hanghoa_Mua.DataSource = dsHanghoa_Mua.Tables[0];
                        gridLookUpEdit_Ma_Hanghoa_Mua.DataSource = dsHanghoa_Mua.Tables[0];

                        gridColumn11.Visible = false;
                        gridColumn5.Visible = false;
                        gridColumn12.Visible = true;
                        gridColumn7.Visible = true;
                    }

                    //dgware_Hdbanhang_Chitiet
                    identity = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");
                    this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(gridView1.GetFocusedRowCellValue("Id_Hdbanhang")).ToDataSet();
                    this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet;
                    this.dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet.Tables[0].TableName;

                    ds_Hdbanhang_Chitiet.Tables[0].Columns.Add("Chon", typeof(bool));
                }

                gridView4.BestFitColumns();

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif 
            }
        }

        public override object PerformSelectOneObject()
        {
            this.DoClickEndEdit(dgware_Hdbanhang_Chitiet); 
            SelectedRows = ds_Hdbanhang_Chitiet.Tables[0].Select("Chon = true");
            this.Close();
            return base.PerformSelectOneObject();
        }
        #endregion

        #region Even

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
                DisplayInfo2();
        }

        private void txtSochungtu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txtSochungtu.Text != "")
            {
                gridView1.Columns["Sochungtu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView1.Columns["Sochungtu"], txtSochungtu.EditValue);
                gridView1.Focus();
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            }
        }

        private void dtNgay_Chungtu_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.Columns["Ngay_Chungtu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView1.Columns["Ngay_Chungtu"], dtNgay_Chungtu.DateTime);
            gridView1.Focus();
            DisplayInfo2();
        }
        #endregion


    }
}