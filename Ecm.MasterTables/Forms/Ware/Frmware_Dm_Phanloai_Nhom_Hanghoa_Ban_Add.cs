using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Phanloai_Nhom_Hanghoa_Ban_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        public Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban SelectedWare_Dm_Loai_Hanghoa_Ban;

        public Frmware_Dm_Phanloai_Nhom_Hanghoa_Ban_Add()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Collection = objMasterService.Get_All_Ware_Dm_Phanloai_Nhom_Hanghoa_Ban().ToDataSet();
                dgware_Dm_Loai_Hanghoa_Ban.DataSource = ds_Collection;
                dgware_Dm_Loai_Hanghoa_Ban.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Loai_Hanghoa_Ban;
                this.DataBindingControl();
                this.ChangeStatus(false);
                dgware_Dm_Loai_Hanghoa_Ban.Enabled = true;
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                // GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        #region Event Override
    
        public override bool PerformAdd()
        {
            return true;
        }

        public override bool PerformEdit()
        {
            return base.PerformEdit();
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
             hashtableControls.Add(gridView1.Columns["Ma_Phanloai_Nhom_Hanghoa_Ban"], "");
             hashtableControls.Add(gridView1.Columns["Ten_Phanloai_Nhom_Hanghoa_Ban"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
                return false;

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Phanloai_Nhom_Hanghoa_Ban"].Unique = true;
                objMasterService.Update_Ware_Dm_Phanloai_Nhom_Hanghoa_Ban_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { "Mã " });
                }
                //MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban ware_Dm_Loai_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Loai_Hanghoa_Ban.Id_Loai_Hanghoa_Ban = dr["Id_Phanloai_Nhom_Hanghoa_Ban"];
                    ware_Dm_Loai_Hanghoa_Ban.Ma_Loai_Hanghoa_Ban = dr["Ma_Phanloai_Nhom_Hanghoa_Ban"];
                    ware_Dm_Loai_Hanghoa_Ban.Ten_Loai_Hanghoa_Ban = dr["Ten_Phanloai_Nhom_Hanghoa_Ban"];
                }
                SelectedWare_Dm_Loai_Hanghoa_Ban = ware_Dm_Loai_Hanghoa_Ban;
                this.Dispose();
                this.Close();
                return ware_Dm_Loai_Hanghoa_Ban;
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

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Loai_Hanghoa_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Phanloai_Nhom_Hanghoa_Ban") != "")
                if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Loai_Hanghoa_Ban", "Id_Loai_Hanghoa_Ban", this.gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

    }
}

