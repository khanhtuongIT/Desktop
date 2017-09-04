using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using Wref = Ecm.WebReferences.Classes;

namespace Ecm.MasterTables.Forms.Bar
{
    public partial class Frmbar_Dm_Menu_Hanghoa_Ban_Dialog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        public DataRow[] drs_Hanghoa;
        public Frmbar_Dm_Menu_Hanghoa_Ban_Dialog()
        {
            InitializeComponent();
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();

            //gridView1.Columns[""].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Bar_Dm_Menu
                DataSet dsBar_Dm_Menu = objMasterService.Get_All_Bar_Dm_Menu().ToDataSet();
                gridLookUpEdit_Menu.DataSource = dsBar_Dm_Menu.Tables[0];
                lookUpEdit_Menu.Properties.DataSource = dsBar_Dm_Menu.Tables[0];
                dgbar_Dm_Menu.DataSource = dsBar_Dm_Menu.Tables[0];

                //Get data Ware_Dm_Hanghoa_Ban
                DataSet dsWare_Dm_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                gridLookUpEdit_Hanghoa_Ban.DataSource = dsWare_Dm_Hanghoa_Ban.Tables[0];

                //Get data Bar_Dm_Menu_Hanghoa_Ban
                ds_Collection = objMasterService.Get_All_Bar_Dm_Menu_Hanghoa_Ban().ToDataSet();
                ds_Collection.Tables[0].Columns.Add("Soluong");
                ds_Collection.Tables[0].Columns.Add("Thanhtien");
                foreach (DataRow dr in ds_Collection.Tables[0].Rows)
                    dr["Ghichu"] = System.DBNull.Value;
                dgbar_Dm_Menu_Hanghoa_Ban.DataSource = ds_Collection;
                dgbar_Dm_Menu_Hanghoa_Ban.DataMember = ds_Collection.Tables[0].TableName;


                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                ////Ecm.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        public override object PerformSelectOneObject()
        {
            dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
            drs_Hanghoa = ds_Collection.Tables[0].Select("Soluong <> 0");
            this.Dispose();
            this.Close();
            return base.PerformSelectOneObject();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Soluong")
            {
                if ("" + gridView1.GetFocusedRowCellValue("Soluong") == "" || "" + gridView1.GetFocusedRowCellValue("Dongia") == "")
                    return;

                gridView1.SetFocusedRowCellValue(gridView1.Columns["Thanhtien"], 
                        Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Soluong"))
                      * Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Dongia")
                        ));
            }
        }

        private void lookUpEdit_Menu_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.Columns["Id_Menu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView1.Columns["Id_Menu"],
                lookUpEdit_Menu.EditValue);

        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                object id_menu = gridView2.GetFocusedRowCellValue(gridView2.Columns["Id_Menu"]);
                lookUpEdit_Menu.EditValue = id_menu;
                gridView1.Columns["Id_Menu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView1.Columns["Id_Menu"],
                   lookUpEdit_Menu.EditValue);
            }
            catch { }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.PerformSelectOneObject();
        }
    }
}

