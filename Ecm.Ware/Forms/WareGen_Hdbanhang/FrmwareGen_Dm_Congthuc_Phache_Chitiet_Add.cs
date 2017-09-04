using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using MessageDialogAlias =  GoobizFrame.Windows.Forms.MessageDialog;

namespace Ecm.Ware.Forms.WareGen_Hdbanhang
{
    public partial class FrmwareGen_Dm_Congthuc_Phache_Chitiet_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Collection = new DataSet();
        DataSet ds_Congthuc_Phache;
        DataSet dsHanghoa_Ban;

        public FrmwareGen_Dm_Congthuc_Phache_Chitiet_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        #region Event Override
        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Donvitinh
                DataSet dsWare_Dm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                lookUpEdit_Donvitinh.Properties.DataSource = dsWare_Dm_Donvitinh.Tables[0];
                gridLookUpEdit_Donvitinh.DataSource = dsWare_Dm_Donvitinh.Tables[0];
                gridLookUpEdit_Donvitinh_2.DataSource = dsWare_Dm_Donvitinh.Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua
                DataSet dsWare_Dm_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua().ToDataSet();
                lookUpEdit_Hanghoa_Mua.Properties.DataSource = dsWare_Dm_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Hanghoa_Mua.DataSource = dsWare_Dm_Hanghoa_Mua.Tables[0];

                //Get data WareGen_Dm_Congthuc_Phache
                DataSet dsWareGen_Dm_Congthuc_Phache = objWareService.Get_All_WareGen_Dm_Congthuc_Phache().ToDataSet();
                lookUpEdit_Congthuc_Phache.Properties.DataSource = dsWareGen_Dm_Congthuc_Phache.Tables[0];
                gridLookUpEdit_Congthuc_Phache.DataSource = dsWareGen_Dm_Congthuc_Phache.Tables[0];

                //gridLookUpEdit_Nhom_Hanghoa_Ban
                DataSet dsNhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet();
                gridLookUpEdit_Nhom_Hanghoa_Ban.DataSource = dsNhom_Hanghoa_Ban.Tables[0];
                gridLookUpEdit_Nhom_Hanghoa_Ban_2.DataSource = dsNhom_Hanghoa_Ban.Tables[0];

                //gridLookUpEdit_Loai_Hanghoa_Ban
                DataSet dsLoai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
                gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = dsLoai_Hanghoa_Ban.Tables[0];
                gridLookUpEdit_Loai_Hanghoa_Ban_2.DataSource = dsLoai_Hanghoa_Ban.Tables[0];

                //gridLookUpEdit_Hanghoa_Ban
                dsHanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                gridLookUpEdit_Hanghoa_Ban.DataSource = dsHanghoa_Ban.Tables[0];

                //Get data WareGen_Dm_Congthuc_Phache_Chitiet
                ds_Collection = objWareService.Get_All_WareGen_Dm_Congthuc_Phache_Chitiet().ToDataSet();
                dgwareGen_Dm_Congthuc_Phache_Chitiet.DataSource = ds_Collection;
                dgwareGen_Dm_Congthuc_Phache_Chitiet.DataMember = ds_Collection.Tables[0].TableName;

                //Get data WareGen_Dm_Congthuc_Phache
                ds_Congthuc_Phache = objWareService.Get_All_WareGen_Dm_Congthuc_Phache().ToDataSet();
                dgware_Dm_Congthuc_Phache.DataSource = ds_Congthuc_Phache;
                dgware_Dm_Congthuc_Phache.DataMember = ds_Congthuc_Phache.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgwareGen_Dm_Congthuc_Phache_Chitiet;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageDialogAlias.Show(ex.Message, ex.ToString(), "Exception");
#endif
 
            }

        }

        void ClearDataBindings()
        {
            this.txtId_Congthuc_Phache_Chitiet.DataBindings.Clear();
            this.txtSoluong.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();

            this.lookUpEdit_Congthuc_Phache.DataBindings.Clear();
            this.lookUpEdit_Donvitinh.DataBindings.Clear();
            this.lookUpEdit_Hanghoa_Mua.DataBindings.Clear();

        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Congthuc_Phache_Chitiet.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Congthuc_Phache_Chitiet");
                this.txtSoluong.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Soluong");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ghichu");

                this.lookUpEdit_Congthuc_Phache.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Congthuc_Phache");
                this.lookUpEdit_Donvitinh.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Donvitinh");
                this.lookUpEdit_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hanghoa_Mua");

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

            }
        }

        public void ChangeStatus(bool editTable)
        {
            this.dgwareGen_Dm_Congthuc_Phache_Chitiet.Enabled = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.txtSoluong.Properties.ReadOnly = !editTable;

            this.lookUpEdit_Donvitinh.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Congthuc_Phache.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Hanghoa_Mua.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Congthuc_Phache_Chitiet.EditValue = "";
            this.txtSoluong.EditValue = null;
            this.txtGhichu.EditValue = "";

            this.lookUpEdit_Donvitinh.EditValue = null;
            this.lookUpEdit_Congthuc_Phache.EditValue = null;
            this.lookUpEdit_Hanghoa_Mua.EditValue = null;
        }

        public object InsertObject()
        {
            Ecm.WebReferences.WareService.Ware_Dm_Congthuc_Phache_Chitiet wareGen_Dm_Congthuc_Phache_Chitiet = new Ecm.WebReferences.WareService.Ware_Dm_Congthuc_Phache_Chitiet();
            wareGen_Dm_Congthuc_Phache_Chitiet.Id_Congthuc_Phache = lookUpEdit_Congthuc_Phache.EditValue;
            wareGen_Dm_Congthuc_Phache_Chitiet.Ghichu          = txtGhichu.EditValue;
            
            if ("" + txtSoluong.EditValue != "")
                wareGen_Dm_Congthuc_Phache_Chitiet.Soluong         = txtSoluong.EditValue;
            if ("" + lookUpEdit_Donvitinh.EditValue != "")
                wareGen_Dm_Congthuc_Phache_Chitiet.Id_Donvitinh    = lookUpEdit_Donvitinh.EditValue;
            if ("" + lookUpEdit_Hanghoa_Mua.EditValue != "")
                wareGen_Dm_Congthuc_Phache_Chitiet.Id_Hanghoa_Mua  = lookUpEdit_Hanghoa_Mua.EditValue;

            return objWareService.Insert_WareGen_Dm_Congthuc_Phache_Chitiet(wareGen_Dm_Congthuc_Phache_Chitiet);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.WareService.Ware_Dm_Congthuc_Phache_Chitiet wareGen_Dm_Congthuc_Phache_Chitiet = new Ecm.WebReferences.WareService.Ware_Dm_Congthuc_Phache_Chitiet();
            wareGen_Dm_Congthuc_Phache_Chitiet.Id_Congthuc_Phache_Chitiet = txtId_Congthuc_Phache_Chitiet.EditValue;
            wareGen_Dm_Congthuc_Phache_Chitiet.Id_Congthuc_Phache      = lookUpEdit_Congthuc_Phache.EditValue;
            wareGen_Dm_Congthuc_Phache_Chitiet.Ghichu                  = txtGhichu.EditValue;
            
            if ("" + txtSoluong.EditValue != "")
                wareGen_Dm_Congthuc_Phache_Chitiet.Soluong = txtSoluong.EditValue;
            if ("" + lookUpEdit_Donvitinh.EditValue != "")
                wareGen_Dm_Congthuc_Phache_Chitiet.Id_Donvitinh = lookUpEdit_Donvitinh.EditValue;
            if ("" + lookUpEdit_Hanghoa_Mua.EditValue != "")
                wareGen_Dm_Congthuc_Phache_Chitiet.Id_Hanghoa_Mua = lookUpEdit_Hanghoa_Mua.EditValue;

            return objWareService.Update_WareGen_Dm_Congthuc_Phache_Chitiet(wareGen_Dm_Congthuc_Phache_Chitiet);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Dm_Congthuc_Phache ware_Dm_Congthuc_Phache = new Ecm.WebReferences.WareService.Ware_Dm_Congthuc_Phache();
            ware_Dm_Congthuc_Phache.Id_Congthuc_Phache = gridView2.GetFocusedRowCellValue("Id_Congthuc_Phache");

            return objWareService.Delete_WareGen_Dm_Congthuc_Phache(ware_Dm_Congthuc_Phache);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(lookUpEdit_Congthuc_Phache, lblId_Congthuc_Phache.Text);
                hashtableControls.Add(lookUpEdit_Donvitinh, lblId_Donvitinh.Text);
                hashtableControls.Add(lookUpEdit_Hanghoa_Mua, lblId_Hanghoa_Mua.Text);
                hashtableControls.Add(txtSoluong, lblSoluong.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblId_Congthuc_Phache.Text, lblId_Congthuc_Phache.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Id_Congthuc_Phache"], "");
            hashtableControls.Add(gridView1.Columns["Id_Donvitinh"], "");
            hashtableControls.Add(gridView1.Columns["Id_Hanghoa_Mua"], "");
            hashtableControls.Add(gridView1.Columns["Soluong"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                this.DoClickEndEdit(dgware_Dm_Congthuc_Phache); // dgware_Dm_Congthuc_Phache.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                ds_Congthuc_Phache.Tables[0].Columns["Ma_Congthuc_Phache"].Unique = true;
                objWareService.Update_WareGen_Dm_Congthuc_Phache_Collection(this.ds_Congthuc_Phache);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }

            try
            {
                this.DoClickEndEdit(dgwareGen_Dm_Congthuc_Phache_Chitiet); //dgwareGen_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                objWareService.Update_WareGen_Dm_Congthuc_Phache_Chitiet_Collection(this.ds_Collection);
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

        public override bool PerformDelete()
        {
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("WareGen_Dm_Congthuc_Phache_Chitiet"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("WareGen_Dm_Congthuc_Phache_Chitiet")   }) == DialogResult.Yes)
            {
                try
                {
                   
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                     GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.WareService.Ware_Dm_Congthuc_Phache_Chitiet wareGen_Dm_Congthuc_Phache_Chitiet = new Ecm.WebReferences.WareService.Ware_Dm_Congthuc_Phache_Chitiet();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    wareGen_Dm_Congthuc_Phache_Chitiet.Id_Congthuc_Phache_Chitiet = dr["Id_Congthuc_Phache_Chitiet"];
                    wareGen_Dm_Congthuc_Phache_Chitiet.Id_Congthuc_Phache  = dr["Id_Congthuc_Phache"];
                    wareGen_Dm_Congthuc_Phache_Chitiet.Ghichu              = dr["Ghichu"];
                    wareGen_Dm_Congthuc_Phache_Chitiet.Soluong             = dr["Soluong"];
                    wareGen_Dm_Congthuc_Phache_Chitiet.Id_Donvitinh        = dr["Id_Donvitinh"];
                    wareGen_Dm_Congthuc_Phache_Chitiet.Id_Hanghoa_Mua      = dr["Id_Hanghoa_Mua"];
                }
                this.Dispose();
                this.Close();
                return wareGen_Dm_Congthuc_Phache_Chitiet;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        public override bool PerformPrintPreview()
        {
            dgwareGen_Dm_Congthuc_Phache_Chitiet.ShowPrintPreview();
            return base.PerformPrintPreview();
        }
        #endregion

        #region  Even

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Id_Congthuc_Phache"];
            this.gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Congthuc_Phache"],
                gridView2.GetFocusedRowCellValue("Id_Congthuc_Phache"));
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
            this.DoClickEndEdit(dgwareGen_Dm_Congthuc_Phache_Chitiet); //this.dgwareGen_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }
         
        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add frmware_Dm_Donvitinh_Add = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add();
                frmware_Dm_Donvitinh_Add.Text = "Đơn vị tính";
                 GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Donvitinh_Add);
                frmware_Dm_Donvitinh_Add.ShowDialog();

                if (frmware_Dm_Donvitinh_Add.SelecteWare_Dm_Donvitinh != null)
                {
                    gridLookUpEdit_Donvitinh.DataSource = frmware_Dm_Donvitinh_Add.Data.Tables[0];

                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"], frmware_Dm_Donvitinh_Add.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                }
            }
        }

    
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.FocusedRowHandle >= 0)
                gridView1.Columns["Id_Congthuc_Phache"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView2.GetFocusedRowCellValue("Id_Congthuc_Phache"));
        }

        private void btnCopy_Chitiet_Click(object sender, EventArgs e)
        {
            FrmwareGen_Dm_Congthuc_Phache_Chitiet_Dialog frmware_Dm_Hanghoa_Ban_Dialog = new FrmwareGen_Dm_Congthuc_Phache_Chitiet_Dialog();
            frmware_Dm_Hanghoa_Ban_Dialog.Text = btnCopy_Chitiet.Text;
             GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Ban_Dialog);
            frmware_Dm_Hanghoa_Ban_Dialog.ShowDialog();

            if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows != null
                && frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
            {
                 gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Congthuc_Phache"], gridView2.GetFocusedRowCellValue("Id_Congthuc_Phache"));
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Mua"]
                    , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Mua"]);
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Soluong"]
                    , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Soluong"]);
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"]
                    , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Donvitinh"]);

                   if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 1)
                {
                    for (int i = 1; i < frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length; i++)
                    {
                        DataRow nrow = ds_Collection.Tables[0].NewRow();
                           nrow["Id_Congthuc_Phache"] = gridView2.GetFocusedRowCellValue("Id_Congthuc_Phache");
                        nrow["Id_Hanghoa_Mua"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Mua"];
                        nrow["Soluong"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Soluong"];
                        nrow["Id_Donvitinh"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Donvitinh"];
                        ds_Collection.Tables[0].Rows.Add(nrow);
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            foreach (DataRow drHanghoa_Ban in dsHanghoa_Ban.Tables[0].Rows)
            {
                if (ds_Congthuc_Phache.Tables[0].Select("Id_Hanghoa_Ban=" + drHanghoa_Ban["Id_Hanghoa_Ban"]).Length == 0)
                {
                    DataRow ndrCongthuc_Phache = ds_Congthuc_Phache.Tables[0].NewRow();
                    ndrCongthuc_Phache["Id_Hanghoa_Ban"] = drHanghoa_Ban["Id_Hanghoa_Ban"];
                    ndrCongthuc_Phache["Ma_Congthuc_Phache"] = drHanghoa_Ban["Ma_Hanghoa_Ban"];
                    ndrCongthuc_Phache["Ten_Congthuc_Phache"] = drHanghoa_Ban["Ten_Hanghoa_Ban"];
                    ndrCongthuc_Phache["Id_Donvitinh"] = drHanghoa_Ban["Id_Donvitinh"];
                    ds_Congthuc_Phache.Tables[0].Rows.Add(ndrCongthuc_Phache);
                }
            }

            objWareService.Update_WareGen_Dm_Congthuc_Phache_Collection(ds_Congthuc_Phache);
            DisplayInfo();

            WaitDialogForm.Close();
        }
        #endregion
    }
}

