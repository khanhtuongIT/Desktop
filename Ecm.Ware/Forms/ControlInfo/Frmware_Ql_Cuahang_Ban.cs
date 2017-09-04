using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Ql_Cuahang_Ban :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();

        public Frmware_Ql_Cuahang_Ban()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        #region Event Override


        public override void DisplayInfo()
        {
            try
            {
                //Get data Rex_Nhansu
                DataSet dsRex_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUpEdit_Nhansu.Properties.DataSource = dsRex_Nhansu.Tables[0];
                gridLookUpEdit_Nhansu.DataSource = dsRex_Nhansu.Tables[0];

                //Get data Ware_Cuahang_Ban
                DataSet dsWare_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet();
                lookUpEdit_Cuahang_Ban.Properties.DataSource = dsWare_Cuahang_Ban.Tables[0];
                gridLookUpEdit_Cuahang_Ban.DataSource = dsWare_Cuahang_Ban.Tables[0];

                //Get data Ware_Quytm_Dauky
                ds_Collection = objWareService.Get_All_Ware_Ql_Cuahang_Ban().ToDataSet();
                dgware_Ql_Cuahang_Ban.DataSource = ds_Collection;
                dgware_Ql_Cuahang_Ban.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Ql_Cuahang_Ban;

                this.DataBindingControl();
                this.ChangeStatus(false);
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                //MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ClearDataBindings()
        {
            this.txtId_Ql_Cuahang_Ban.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEdit_Nhansu.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Ql_Cuahang_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Ql_Cuahang_Ban");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ghichu");
                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_Nhansu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nhansu");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
             }
        }

        public override void ChangeStatus(bool editTable)
        {
            this.dgware_Ql_Cuahang_Ban.Enabled = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Cuahang_Ban.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Nhansu.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Ql_Cuahang_Ban.EditValue = "";
            this.txtGhichu.EditValue = "";
            this.lookUpEdit_Cuahang_Ban.EditValue = null;
            this.lookUpEdit_Nhansu.EditValue = null;
        }

        public object InsertObject()
        {
            Ecm.WebReferences.WareService.Ware_Ql_Cuahang_Ban objWare_Ql_Cuahang_Ban = new Ecm.WebReferences.WareService.Ware_Ql_Cuahang_Ban();
            objWare_Ql_Cuahang_Ban.Id_Ql_Cuahang_Ban = -1;
            objWare_Ql_Cuahang_Ban.Ghichu = txtGhichu.EditValue;

            if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                objWare_Ql_Cuahang_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
            if ("" + lookUpEdit_Nhansu.EditValue != "")
                objWare_Ql_Cuahang_Ban.Id_Nhansu = lookUpEdit_Nhansu.EditValue;

            return objWareService.Insert_Ware_Ql_Cuahang_Ban(objWare_Ql_Cuahang_Ban);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.WareService.Ware_Ql_Cuahang_Ban objWare_Ql_Cuahang_Ban = new Ecm.WebReferences.WareService.Ware_Ql_Cuahang_Ban();
            objWare_Ql_Cuahang_Ban.Id_Ql_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Ql_Cuahang_Ban");

            if ("" + txtGhichu.EditValue != "")
                objWare_Ql_Cuahang_Ban.Ghichu = txtGhichu.EditValue;
            else
                objWare_Ql_Cuahang_Ban.Ghichu = null;

            if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                objWare_Ql_Cuahang_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
            if ("" + lookUpEdit_Nhansu.EditValue != "")
                objWare_Ql_Cuahang_Ban.Id_Nhansu = lookUpEdit_Nhansu.EditValue;

            return objWareService.Update_Ware_Ql_Cuahang_Ban(objWare_Ql_Cuahang_Ban);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Ql_Cuahang_Ban objWare_Ql_Cuahang_Ban = new Ecm.WebReferences.WareService.Ware_Ql_Cuahang_Ban();
            objWare_Ql_Cuahang_Ban.Id_Ql_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Ql_Cuahang_Ban");

            return objWareService.Delete_Ware_Ql_Cuahang_Ban(objWare_Ql_Cuahang_Ban);
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
                hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblId_Cuahang_Ban.Text);
                hashtableControls.Add(lookUpEdit_Nhansu, lblId_Nhansu.Text);

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
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblId_Nhansu.Text, lblId_Nhansu.Text.ToLower() });
                } 
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Id_Nhansu"], "");
            hashtableControls.Add(gridView1.Columns["Id_Cuahang_Ban"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGridOnComplex(new string[] { "Id_Nhansu", "Id_Cuahang_Ban" }, gridView1))
                return false;
            try
            {
                this.DoClickEndEdit(dgware_Ql_Cuahang_Ban); //dgware_Ql_Cuahang_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                objWareService.Update_Ware_Ql_Cuahang_Ban_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
#if DEBUG
              //  MessageBox.Show(ex.ToString());
#endif
                //Error here
                 GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                return false;
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Ql_Cuahang_Ban"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Ql_Cuahang_Ban")   }) == DialogResult.Yes)
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
            Ecm.WebReferences.WareService.Ware_Ql_Cuahang_Ban ware_Ql_Cuahang_Ban = new Ecm.WebReferences.WareService.Ware_Ql_Cuahang_Ban();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Ql_Cuahang_Ban.Id_Ql_Cuahang_Ban = dr["Id_Ql_Cuahang_Ban"];
                    ware_Ql_Cuahang_Ban.Id_Nhansu = dr["Id_Nhansu"];
                    ware_Ql_Cuahang_Ban.Id_Cuahang_Ban = dr["Id_Cuahang_Ban"];
                    ware_Ql_Cuahang_Ban.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Ql_Cuahang_Ban;
            }
            catch (Exception ex)
            {
#if DEBUG
               // MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }
        #endregion

        #region Even

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Id_Cuahang_Ban"];
            this.addnewrow_clicked = true;
         }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Nhansu")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Hoten_Nhansu"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Nhansu.GetDataSourceRowByKeyValue(e.Value))["Hoten_Nhansu"]);
            }
            this.DoClickEndEdit(dgware_Ql_Cuahang_Ban); 
        }
        #endregion

    }
}

