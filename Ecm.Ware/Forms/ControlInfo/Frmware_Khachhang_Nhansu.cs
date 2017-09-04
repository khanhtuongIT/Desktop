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
    public partial class Frmware_Khachhang_Nhansu : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsKhachhang_Nhansu = new DataSet();
        DataSet dsKhachhang;

        public Frmware_Khachhang_Nhansu()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnKetchuyen.Visible = false;
            this.DisplayInfo();
        }

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                dsKhachhang = null;
                DataSet dsTemp = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUpEdit_Nhansu.Properties.DataSource = dsTemp.Tables[0];
                gridLookupEdit_Nhansu.DataSource = dsTemp.Tables[0];

                dsTemp = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet();
                lookUpEdit_Cuahang_Ban.Properties.DataSource = dsTemp.Tables[0];
                gridLookupEdit_Khuvuc.DataSource = dsTemp.Tables[0];

                dsTemp = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                gridLookUpEdit_Tenkhachhang.DataSource = dsTemp.Tables[0];
                gridLookUpEdit_MaKhachhang.DataSource = dsTemp.Tables[0];
                LookupEdit_Makhachhang.Properties.DataSource = dsTemp.Tables[0];
                lookUpEdit_TenKhachhang.Properties.DataSource = dsTemp.Tables[0];

                dsKhachhang_Nhansu = objMasterService.Ware_Dm_Khachhang_Nhansu_SelectAll().ToDataSet();
                dgware_Ql_Cuahang_Ban.DataSource = dsKhachhang_Nhansu;
                dgware_Ql_Cuahang_Ban.DataMember = dsKhachhang_Nhansu.Tables[0].TableName;

                this.Data = dsKhachhang_Nhansu;
                this.GridControl = dgware_Ql_Cuahang_Ban;

                this.DataBindingControl();
                this.ChangeStatus(false);
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ClearDataBindings()
        {
            lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            lookUpEdit_Nhansu.DataBindings.Clear();
            lookUpEdit_TenKhachhang.DataBindings.Clear();
            LookupEdit_Makhachhang.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", dsKhachhang_Nhansu, dsKhachhang_Nhansu.Tables[0].TableName + ".Id_Khuvuc");
                this.lookUpEdit_Nhansu.DataBindings.Add("EditValue", dsKhachhang_Nhansu, dsKhachhang_Nhansu.Tables[0].TableName + ".Id_Nhansu");
                lookUpEdit_TenKhachhang.DataBindings.Add("EditValue", dsKhachhang_Nhansu, dsKhachhang_Nhansu.Tables[0].TableName + ".Id_Khachhang");
                LookupEdit_Makhachhang.DataBindings.Add("EditValue", dsKhachhang_Nhansu, dsKhachhang_Nhansu.Tables[0].TableName + ".Id_Khachhang");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ResetText()
        {
            this.lookUpEdit_Cuahang_Ban.EditValue = null;
            this.lookUpEdit_Nhansu.EditValue = null;
            lookUpEdit_TenKhachhang.EditValue = null;
            LookupEdit_Makhachhang.EditValue = null;
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

                // GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                //hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblId_Cuahang_Ban.Text);
                //hashtableControls.Add(lookUpEdit_Nhansu, lblId_Nhansu.Text);

                //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                //    return false;
                //if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                //{
                //    success = (bool)this.InsertObject();
                //}
                //else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                //{
                //    success = (bool)this.UpdateObject();
                //}

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
            // GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            //hashtableControls.Add(gridView1.Columns["Id_Nhansu"], "");
            //hashtableControls.Add(gridView1.Columns["Id_Khachhang"], "");

            //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
            //    return false;

            //if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGridOnComplex(new string[] { "Id_Nhansu", "Id_Khachhang" }, gridView1))
            //    return false;
            try
            {
                this.DoClickEndEdit(dgware_Ql_Cuahang_Ban); //dgware_Ql_Cuahang_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                if (dsKhachhang != null)
                {
                    //DataRow[] rows = dsKhachhang.Tables[0].Select("Id_Nhansu is null or Id_Dm_Khachhang_Nhansu is not null");
                    //rows[0].Delete();

                    //DataSet dsKhachhang_Nhansu = objMasterService.Ware_Dm_Khachhang_Nhansu_SelectAll().ToDataSet();
                    foreach (DataRow dtr in dsKhachhang.Tables[0].Rows)
                    {
                        if ("" + dtr["Id_Nhansu"] == "" || "" + dtr["Id_Dm_Khachhang_Nhansu"] != "")
                            continue;
                        DataRow dtr_new = dsKhachhang_Nhansu.Tables[0].NewRow();
                        dtr_new["Id_Khachhang"] = dtr["Id_Khachhang"];
                        dtr_new["Id_Nhansu"] = dtr["Id_Nhansu"];
                        dsKhachhang_Nhansu.Tables[0].Rows.Add(dtr_new);
                    }
                }
                objMasterService.Update_Ware_Dm_Khachhang_Nhansu_Collection(dsKhachhang_Nhansu);
                dsKhachhang_Nhansu.AcceptChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
                //Error here
                GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                return false;
            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.WareService.Ware_Ql_Cuahang_Ban ware_Ql_Cuahang_Ban = new Ecm.WebReferences.WareService.Ware_Ql_Cuahang_Ban();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = dsKhachhang_Nhansu.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Ql_Cuahang_Ban.Id_Nhansu = dr["Id_Nhansu"];
                    ware_Ql_Cuahang_Ban.Id_Cuahang_Ban = dr["Id_Khuvuc"];
                }
                this.Dispose();
                this.Close();
                return ware_Ql_Cuahang_Ban;
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
            this.gridView1.FocusedColumn = gridView1.Columns["Id_Khachhang"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Khachhang")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Khuvuc"]
                    , ((System.Data.DataRowView)gridLookUpEdit_MaKhachhang.GetDataSourceRowByKeyValue(e.Value))["Id_Khuvuc"]);
            }
            this.DoClickEndEdit(dgware_Ql_Cuahang_Ban);
        }
        #endregion

        private void btnKetchuyen_Click(object sender, EventArgs e)
        {
            dsKhachhang = objMasterService.Ware_Dm_Khachhang_LJoinNhansu().ToDataSet();
            dgware_Ql_Cuahang_Ban.DataSource = dsKhachhang;
            dgware_Ql_Cuahang_Ban.DataMember = dsKhachhang.Tables[0].TableName;

            this.Data = dsKhachhang;
            this.GridControl = dgware_Ql_Cuahang_Ban;

            this.DataBindingControl();
            this.ChangeStatus(false);
            this.gridView1.BestFitColumns();
        }

    }
}

