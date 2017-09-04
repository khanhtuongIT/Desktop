using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Donvitinh_Quydoi_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        DataSet ds_Hanghoa_ban;
        DataSet dsWare_Dm_Donvitinh;

        public Frmware_Dm_Donvitinh_Quydoi_Add()
        {
            InitializeComponent();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();
                LoadDataOnGrid();
                this.ChangeStatus(false);
                this.gvChitiet.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadMasterData()
        {
            ds_Hanghoa_ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsWare_Dm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            gridLookUp_Donvitinh.DataSource = dsWare_Dm_Donvitinh.Tables[0];
            gridLookUp_Hanghoa_Ban.DataSource = ds_Hanghoa_ban.Tables[0];
        }

        void LoadDataOnGrid()
        {
            ds_Collection = objMasterService.Get_All_Ware_Dm_Donvitinh_Quydoi().ToDataSet();
            dgware_Dm_Donvitinh_Quydoi.DataSource = ds_Collection;
            dgware_Dm_Donvitinh_Quydoi.DataMember = ds_Collection.Tables[0].TableName;
            this.Data = ds_Collection;
            this.GridControl = dgware_Dm_Donvitinh_Quydoi;
            gvChitiet.BestFitColumns();
            DataBindingControl();
        }

        #region Event Override

        public override bool PerformCancel()
        {
            DisplayInfo();
            return base.PerformCancel();
        }

        public override bool PerformSaveChanges()
        {
            dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.EndEdit);
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvChitiet.Columns["Id_Donvitinh1"], "");
            hashtableControls.Add(gvChitiet.Columns["Soluong2"], "");
            hashtableControls.Add(gvChitiet.Columns["Soluong1"], "");
            hashtableControls.Add(gvChitiet.Columns["Id_Donvitinh2"], "");
           ;
           

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvChitiet))
                return false;

            //for (int i = 0; i < ds_Collection.Tables[0].Rows.Count; i++)
            //{
            //    if (ds_Collection.Tables[0].Rows[i].RowState != DataRowState.Deleted
            //        && ds_Collection.Tables[0].Rows[i].RowState != DataRowState.Unchanged)
            //    {
            //        if (Convert.ToInt32(ds_Collection.Tables[0].Rows[i]["Id_Donvitinh1"]) == Convert.ToInt32(ds_Collection.Tables[0].Rows[i]["Id_Donvitinh2"]))
            //        {
            //            GoobizFrame.Windows.Forms.MessageDialog.Show("Không được chọn 2 đơn vị tính giống nhau, chọn lại");
            //            return false;
            //        }
                   
            //    }
            //}
            //try
            //{
            //    Constraint constraint = new UniqueConstraint("constraint1",
            //            new DataColumn[] {ds_Collection.Tables[0].Columns["Id_Hanghoa_Ban"],
            //    ds_Collection.Tables[0].Columns["Id_Donvitinh1"],ds_Collection.Tables[0].Columns["Id_Donvitinh2"] }, false);
            //    ds_Collection.Tables[0].Constraints.Clear();
            //    ds_Collection.Tables[0].Constraints.Add(constraint);
            //}
            //catch (Exception ex)
            //{
            //    if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
            //    {
            //        GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa và đơn vị tính bị trùng, vui lòng kiểm tra lại");
            //        return false;
            //    }
            //    //MessageBox.Show(ex.ToString());
            //}
            try
            {
              
               objMasterService.Update_Ware_Dm_Donvitinh_Quydoi_Collection(this.ds_Collection);
                ds_Collection.AcceptChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh_Quydoi ware_Dm_Donvitinh_Quydoi = new Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh_Quydoi();
            try
            {
                int focusedRow = gvChitiet.GetDataSourceRowIndex(gvChitiet.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Donvitinh_Quydoi.Id_Donvitinh_Quydoi = dr["Id_Donvitinh_Quydoi"];
                    ware_Dm_Donvitinh_Quydoi.Soluong1 = dr["Soluong1"];
                    ware_Dm_Donvitinh_Quydoi.Soluong2 = dr["Soluong2"];
                    ware_Dm_Donvitinh_Quydoi.Ghichu = dr["Ghichu"];
                    ware_Dm_Donvitinh_Quydoi.Id_Donvitinh2 = dr["Id_Donvitinh2"];
                   // ware_Dm_Donvitinh_Quydoi.Id_Donvitinh1 = dr["Id_Donvitinh1"];
                }
                this.Dispose();
                this.Close();
                return ware_Dm_Donvitinh_Quydoi;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }
        #endregion

        #region Even

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gvChitiet.FocusedColumn = gvChitiet.Columns["Id_Donvitinh1"];
            this.gvChitiet.FocusedColumn = gvChitiet.Columns["Id_Donvitinh2"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Donvitinh_Quydoi.EmbeddedNavigator.Buttons.EndEdit);
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                DataRow[] dtr = ds_Hanghoa_ban.Tables[0].Select("Id_Hanghoa_Ban = " + "" + gvChitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban"));
                gvChitiet.SetFocusedRowCellValue(gvChitiet.Columns["Ten_Hanghoa_Ban"], dtr[0]["Ten_Hanghoa_Ban"]);
               gvChitiet.SetFocusedRowCellValue(gvChitiet.Columns["Id_Donvitinh1"], dtr[0]["Id_Donvitinh"]);
            }
        }

        private void dgware_Dm_Donvitinh_Quydoi_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (gvChitiet.GetFocusedRowCellValue("Id_Donvitinh_Quydoi").ToString() != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Donvitinh_Quydoi", "Id_Donvitinh_Quydoi", this.gvChitiet.GetFocusedRowCellValue("Id_Donvitinh_Quydoi"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
               
            }
        }

        private void gridText_Soluong_Goc_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString() == "" || e.NewValue.ToString() == "0")
                    e.Cancel = true;

                if (e.NewValue.ToString().Length > 7)
                    e.Cancel = true;
            }
        }

        private void gridText_Soluong_Quydoi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString() == "" || e.NewValue.ToString() == "0")
                    e.Cancel = true;

                if (e.NewValue.ToString().Length > 7)
                    e.Cancel = true;
            }
        }

        #endregion

      

    }
}

