using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using Ecm.Rex.Forms;
using Ecm.WebReferences.RexService;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Nghiphep : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        DataSet ds_Nhansu = new DataSet();
        object Id_Bophan;
        DevExpress.XtraTreeList.Nodes.TreeListNode focusedNode;

        public Frmrex_Nghiphep()
        {
            InitializeComponent();
            //datetime mask
            //dtNgay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            //dtNgay_Batdau.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            //dtNgay_Ketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            //dtNgay_Ketthuc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            //gridDate_Ngay_Batdau.Mask.UseMaskAsDisplayFormat = true;
            //gridDate_Ngay_Batdau.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            dtNgay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(2000, 01, 01);
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data master table REX
                lookUp_Loai_Nghiphep.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Loai_Nghiphep_Collection().ToDataSet().Tables[0];
                gridLookUp_Loai_Nghiphep.DataSource = objMasterService.Get_All_Rex_Dm_Loai_Nghiphep_Collection().ToDataSet().Tables[0];
                DataSet dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                gridLookUp_Nhansu.DataSource = dsNhansu.Tables[0];
                gridLookUpEdit_Nhansu.DataSource = dsNhansu.Tables[0];
                //TreeList
                DataSet ds_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
                treeListColumn1.TreeList.DataSource = ds_Bophan.Tables[0];
                //this.DataBindingControl();
                this.ChangeStatus(true);
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DisplayInfo2()
        {
            //if(isLoaded)
            lock (this)
            {
                try
                {
                    ds_Nhansu = objRexService.Get_Rex_NhansuNghiphep_ByBoPhan_Collection(Id_Bophan).ToDataSet();
                    lookUp_Nhansu.Properties.DataSource = ds_Nhansu.Tables[0];
                    gridLookUp_Nhansu.DataSource = ds_Nhansu.Tables[0];
                    gridLookUpEdit_Nhansu.DataSource = ds_Nhansu.Tables[0];
                    ds_Collection = objRexService.Get_All_Rex_Nghiphep_By_Bophan(Id_Bophan).ToDataSet();
                    dgrex_Nghiphep.DataSource = ds_Collection;
                    dgrex_Nghiphep.DataMember = ds_Collection.Tables[0].TableName;
                    DataBindingControl();
                    this.Data = ds_Collection;
                    this.GridControl = dgrex_Nghiphep;
                    gridView1.BestFitColumns();
                    GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
                    if (gridView1.RowCount == 0)
                    {
                        ResetText();
                        item_Edit.Enabled = false;
                        item_Delete.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString());
#endif
                }
            }
        }

        #region Override Section

        public override void ClearDataBindings()
        {
            //this.txtId_Nghiphep.DataBindings.Clear();            
            this.txtSogio_Nghi.DataBindings.Clear();
            this.lookUp_Loai_Nghiphep.DataBindings.Clear();
            this.txtHoten_Nhansu.DataBindings.Clear();
            this.lookUp_Nhansu.DataBindings.Clear();
            this.dtNgay_Batdau.DataBindings.Clear();
            this.dtNgay_Ketthuc.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                txtSogio_Nghi.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Sogio_Nghiphep");
                dtNgay_Batdau.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ngay_Batdau");
                dtNgay_Ketthuc.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ngay_Ketthuc");
                txtHoten_Nhansu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Hoten_Nhansu");
                lookUp_Nhansu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nhansu");
                lookUp_Loai_Nghiphep.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Loai_Nghiphep");
                txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ghichu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editable)
        {
            this.dgrex_Nghiphep.Enabled = editable;
            treeList_Bophan.Enabled = editable;
            gridView1.OptionsBehavior.Editable = !editable;
            txtSogio_Nghi.Properties.ReadOnly = editable;
            txtHoten_Nhansu.Properties.ReadOnly = true;
            txtGhichu.Properties.ReadOnly = editable;
            dtNgay_Batdau.Properties.ReadOnly = editable;
            dtNgay_Ketthuc.Properties.ReadOnly = editable;
            lookUp_Loai_Nghiphep.Properties.ReadOnly = editable;
            lookUp_Nhansu.Properties.ReadOnly = editable;
        }

        public override void ResetText()
        {
            this.txtSogio_Nghi.Text = "";
            this.dtNgay_Batdau.EditValue = null;
            this.dtNgay_Ketthuc.EditValue = null;
            this.lookUp_Loai_Nghiphep.EditValue = null;
            this.lookUp_Nhansu.EditValue = null;
            this.txtGhichu.Text = "";
            this.txtHoten_Nhansu.Text = "";
        }

        public object InsertObject()
        {
            try
            {
                if (CheckNhansu_Nghiphep(Convert.ToDateTime(dtNgay_Batdau.EditValue.ToString()), Convert.ToDateTime(dtNgay_Ketthuc.EditValue.ToString()), int.Parse(lookUp_Nhansu.EditValue.ToString())))
                {
                    Ecm.WebReferences.RexService.Rex_Nghiphep objRex_Nghiphep =
                        new Ecm.WebReferences.RexService.Rex_Nghiphep();
                    objRex_Nghiphep.Id_Nghiphep = -1;

                    if ("" + this.dtNgay_Batdau.EditValue != "")
                        objRex_Nghiphep.Ngay_Batdau = this.dtNgay_Batdau.EditValue;

                    if ("" + this.dtNgay_Ketthuc.EditValue != "")
                        objRex_Nghiphep.Ngay_Ketthuc = this.dtNgay_Ketthuc.EditValue;

                    if ("" + this.lookUp_Loai_Nghiphep.EditValue != "")
                        objRex_Nghiphep.Id_Loai_Nghiphep = this.lookUp_Loai_Nghiphep.EditValue;

                    if ("" + this.lookUp_Nhansu.EditValue != "")
                        objRex_Nghiphep.Id_Nhansu = this.lookUp_Nhansu.EditValue;
                    objRex_Nghiphep.Ghichu = (txtGhichu.Text == "") ? null : txtGhichu.EditValue;
                    objRex_Nghiphep.Sogio_Nghiphep = this.txtSogio_Nghi.Text;
                    objRexService.Insert_Rex_Nghiphep(objRex_Nghiphep);
                }
            }
            catch (Exception e)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Lỗi: " + e.Message);
                return false;
            }
            return true;
        }

        public object UpdateObject()
        {
            object success = null;
            try
            {
                if (CheckNhansu_Nghiphep(Convert.ToDateTime(dtNgay_Batdau.EditValue.ToString()), Convert.ToDateTime(dtNgay_Ketthuc.EditValue.ToString()), int.Parse(lookUp_Nhansu.EditValue.ToString())))
                {
                    Ecm.WebReferences.RexService.Rex_Nghiphep objRex_Nghiphep = new Ecm.WebReferences.RexService.Rex_Nghiphep();
                    objRex_Nghiphep.Id_Nghiphep = gridView1.GetFocusedRowCellValue("Id_Nghiphep");

                    if ("" + this.dtNgay_Batdau.EditValue != "")
                        objRex_Nghiphep.Ngay_Batdau = this.dtNgay_Batdau.EditValue;

                    if ("" + this.dtNgay_Ketthuc.EditValue != "")
                        objRex_Nghiphep.Ngay_Ketthuc = this.dtNgay_Ketthuc.EditValue;

                    if ("" + this.lookUp_Loai_Nghiphep.EditValue != "")
                        objRex_Nghiphep.Id_Loai_Nghiphep = this.lookUp_Loai_Nghiphep.EditValue;

                    if ("" + this.lookUp_Nhansu.EditValue != "")
                        objRex_Nghiphep.Id_Nhansu = this.lookUp_Nhansu.EditValue;

                    objRex_Nghiphep.Ghichu = (txtGhichu.Text == "") ? null : txtGhichu.EditValue;
                    objRex_Nghiphep.Sogio_Nghiphep = this.txtSogio_Nghi.Text;
                    success = objRexService.Update_Rex_Nghiphep(objRex_Nghiphep);
                }
                else
                {
                    //GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian nghỉ phép không đúng, Nhập lại");
                    return success;
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return success;
#endif
            }
            return success;
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.RexService.Rex_Nghiphep objRex_Nghiphep = new Ecm.WebReferences.RexService.Rex_Nghiphep();
            objRex_Nghiphep.Id_Nghiphep = gridView1.GetFocusedRowCellValue("Id_Nghiphep");
            return objRexService.Delete_Rex_Nghiphep(objRex_Nghiphep);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(false);
            //this.txtHoten_Nhansu.Enabled = false;
            this.ResetText();
            //this.dgrex_Nghiphep.Enabled = false;
            return true;
        }

        public override bool PerformEdit()
        {
            this.ChangeStatus(false);
            //this.txtHoten_Nhansu.Enabled = false;
            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(lookUp_Nhansu, lblMa_Nhansu.Text);
                hashtableControls.Add(lookUp_Loai_Nghiphep, lblLoai_Nghiphep.Text);
                hashtableControls.Add(txtSogio_Nghi, lblSogio_Nghi.Text);
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return false;

                if (Convert.ToDecimal(txtSogio_Nghi.EditValue) == 0)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Số giờ nghĩ không được bằng 0, Nhập lại");
                    txtSogio_Nghi.Focus();
                    return false;
                }
                //DataRow[] dtr = ds_Collection.Tables[0].Select("Id_Nhansu = " + lookUp_Nhansu.EditValue);
                //if (dtr.Length > 0)
                //{
                //    for (int i = 0; i < dtr.Length; i++)
                //    {
                //        if (dtr[i]["Ngay_Ketthuc"].ToString() != "")
                //            if (dtNgay_Batdau.DateTime.Date <= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) && dtNgay_Ketthuc.DateTime.Date > Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]))
                //            {
                //                GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian kết thúc nghĩ nhập không đúng, Nhập lại");
                //                gridView1.CancelUpdateCurrentRow();
                //                return false;
                //            }
                //    }
                //}

                #region Code mới thêm vào để kiểm tra tính hợp lệ của ngày bắt đầu và kết thúc khi PerformSave()
                DateTime ngay_batdau_new;
                DateTime ngay_ketthuc_new;
                int id_nghiphep = 0;
                //if (dtNgay_Batdau.EditValue.ToString() != "" && dtNgay_Ketthuc.EditValue.ToString() != "")
                //{
                ngay_batdau_new = dtNgay_Batdau.DateTime.Date;
                ngay_ketthuc_new = dtNgay_Ketthuc.DateTime.Date;
                id_nghiphep = Convert.ToInt32(lookUp_Nhansu.EditValue);

                if ((ngay_ketthuc_new < ngay_batdau_new))
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian kết thúc nghỉ nhập không đúng, Nhập lại");
                    gridView1.CancelUpdateCurrentRow();
                    return false;
                }
                // }
                if (gridView1.RowCount > 0)
                {
                    DataRow[] dtr = ds_Collection.Tables[0].Select("Id_Nhansu = " + lookUp_Nhansu.EditValue + " and Id_Nghiphep <> " + gridView1.GetFocusedRowCellValue("Id_Nghiphep"));
                    if (dtr.Length > 0)
                    {
                        for (int i = 0; i < dtr.Length; i++)
                        {
                            if (dtr[i]["Ngay_Batdau"].ToString() != "" && dtr[i]["Ngay_Ketthuc"].ToString() != "")
                                if (CheckNhansu_Nghiphep(Convert.ToDateTime(dtr[i]["Ngay_Batdau"]), Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]), int.Parse(dtr[i]["Id_Nhansu"].ToString())))
                                {
                                    //if (dtNgay_Batdau.EditValue.ToString() != "" && dtNgay_Ketthuc.EditValue.ToString() != "")
                                    //{
                                    //    ngay_batdau_new = dtNgay_Batdau.DateTime.Date;
                                    //    ngay_ketthuc_new = dtNgay_Ketthuc.DateTime.Date;

                                    //    //id_nghiphep = Convert.ToInt32(lookUp_Nhansu.EditValue);

                                    //    if (dtr[i]["Ngay_Ketthuc"].ToString() != "")
                                    //    {
                                    if (dtr[i].RowState == DataRowState.Unchanged &&
                                        ngay_ketthuc_new <= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) &&
                                        ngay_ketthuc_new >= Convert.ToDateTime(dtr[i]["Ngay_Batdau"]) &&
                                        id_nghiphep != Convert.ToInt32(dtr[i]["Id_Nghiphep"]))
                                    {
                                        GoobizFrame.Windows.Forms.MessageDialog.Show(
                                            "Thời gian nghỉ nhập không đúng, Nhập lại");
                                        gridView1.CancelUpdateCurrentRow();
                                        dtNgay_Ketthuc.EditValue = null;
                                        return false;
                                    }
                                    if (dtr[i].RowState == DataRowState.Unchanged &&
                                        ngay_batdau_new <= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) &&
                                        ngay_batdau_new >= Convert.ToDateTime(dtr[i]["Ngay_Batdau"]) &&
                                        id_nghiphep != Convert.ToInt32(dtr[i]["Id_Nghiphep"]))
                                    {
                                        GoobizFrame.Windows.Forms.MessageDialog.Show(
                                            "Thời gian nghỉ nhập không đúng, Nhập lại");
                                        gridView1.CancelUpdateCurrentRow();
                                        dtNgay_Batdau.EditValue = null;
                                        return false;
                                    }
                                    if (dtr[i].RowState == DataRowState.Unchanged &&
                                        ngay_ketthuc_new >= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) &&
                                        ngay_batdau_new <= Convert.ToDateTime(dtr[i]["Ngay_Batdau"]) &&
                                        id_nghiphep != Convert.ToInt32(dtr[i]["Id_Nghiphep"]))
                                    {
                                        GoobizFrame.Windows.Forms.MessageDialog.Show(
                                            "Thời gian nghỉ nhập không đúng, Nhập lại");
                                        gridView1.CancelUpdateCurrentRow();
                                        dtNgay_Batdau.EditValue = null;
                                        return false;
                                    }

                                    //    }
                                    //}
                                }
                        }
                    }
                }
                #endregion

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                    success = Convert.ToBoolean(this.InsertObject());
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                    success = Convert.ToBoolean(this.UpdateObject());

                if (success)
                {
                    treeListColumn1.TreeList.FocusedNode = focusedNode;
                    this.DisplayInfo2();
                    this.ChangeStatus(true);
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Nhansu.Text, lblMa_Nhansu.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            try
            {
                DataRow[] dtr = ds_Collection.Tables[0].Select("Id_Nhansu = " + gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Nhansu"]));
                if (dtr.Length > 1)
                {
                    for (int i = 0; i < dtr.Length; i++)
                    {
                        if (!CheckNhansu_Nghiphep(Convert.ToDateTime(dtr[i]["Ngay_Batdau"]),
                                                 Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]),
                                                 int.Parse(lookUp_Nhansu.EditValue.ToString())))
                        {
                            //GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian bắt đầu, kết thúc nghỉ phép không hợp lý, Nhập lại");
                            return false;
                        }
                    }
                }
                //this.DoClickEndEdit(dgrex_Nghiphep);
                System.Collections.Hashtable htb = new System.Collections.Hashtable();
                //htb.Add(gridView1.Columns["Id_Nghiphep"], "");
                htb.Add(gridView1.Columns["Id_Loai_Nghiphep"], "");
                htb.Add(gridView1.Columns["Sogio_Nghiphep"], "");
                htb.Add(gridView1.Columns["Ngay_Batdau"], "");
                htb.Add(gridView1.Columns["Ngay_Ketthuc"], "");
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(htb, gridView1))
                    return false;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDateGrid(gridView1.Columns["Ngay_Batdau"], gridView1.Columns["Ngay_Ketthuc"], gridView1))
                    return false;

                objRexService.Update_Rex_Nghiphep_Collection(ds_Collection);
                this.ChangeStatus(true);
                this.DisplayInfo2();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
            }
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("SYS_CONFIRM_BFDELETE", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Nghiphep"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Nghiphep")   }) == DialogResult.Yes)
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

        public override bool PerformPrintPreview()
        {
            return true;
        }

        #endregion

        #region Event Handling Section

        private void treeList_Bophan_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            focusedNode = e.Node;
            Id_Bophan = Convert.ToInt64("" + e.Node.GetValue("Id_Bophan"));
            DisplayInfo2();
        }

        private void lookUpEdit_Nhansu_EditValueChanged(object sender, EventArgs e)
        {
            if (this.FormState != GoobizFrame.Windows.Forms.FormState.View && lookUp_Nhansu.EditValue != null)
            {
                DataRow[] dtr = ds_Nhansu.Tables[0].Select("Id_Nhansu = " + lookUp_Nhansu.EditValue);
                if (dtr.Length > 0)
                    txtHoten_Nhansu.EditValue = dtr[0]["Hoten_Nhansu"];
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Nhansu")
            {
                ////DataRow[] dtr = objRexService.Get_All_Rex_Nhansu_Collection().Tables[0].Select("Id_Nhansu = " + gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Nhansu"]));
                //string hoten_nhansu = gridLookUp_Nhansu.GetDataSourceValue("Hoten_Nhansu", gridLookUp_Nhansu.GetDataSourceRowIndex("Id_Nhansu", gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Nhansu"]))).ToString();
                ////if (dtr.Length > 0)
                //gridView1.GetFocusedDataRow()["Hoten_Nhansu"] = hoten_nhansu;
                gridView1.SetFocusedRowCellValue("Hoten_Nhansu", gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Nhansu"]));
            }
            else if (e.Column.FieldName == "Hoten_Nhansu")
            {
                gridView1.SetFocusedRowCellValue("Id_Nhansu", gridView1.GetFocusedRowCellValue(gridView1.Columns["Hoten_Nhansu"]));
            }
            //else if (e.Column.FieldName == "Sogio_Nghiphep")
            //{
            //    double gionghi = Convert.ToDouble(gridView1.GetFocusedRowCellValue(gridView1.Columns["Sogio_Nghiphep"]));
            //    if (gionghi == 0)
            //    {
            //        GoobizFrame.Windows.Forms.MessageDialog.Show("Số giờ nghỉ không được bằng 0, Nhập lại");
            //        gridView1.CancelUpdateCurrentRow();
            //        return;
            //    }
            //}
            else if (e.Column.FieldName == "Ngay_Batdau")
            {
                DateTime ngay_batdau_new;
                DateTime ngay_ketthuc_new;

                if (gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"]).ToString() != "" && gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"]).ToString() != "")
                {
                    ngay_batdau_new = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"]));
                    ngay_ketthuc_new = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"]));

                    if ((ngay_ketthuc_new < ngay_batdau_new))
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian bắt đầu nghỉ nhập không đúng, Nhập lại");
                        gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"], null);
                        return;
                    }
                }
                int id_nghiphep = 0;
                if (gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Nhansu"]).ToString() != "")
                {
                    DataRow[] dtr = ds_Collection.Tables[0].Select("Id_Nhansu = '" + gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Nhansu"]) + "'");
                    if (dtr.Length > 0)
                    {
                        for (int i = 0; i < dtr.Length; i++)
                        {
                            if (dtr[i]["Ngay_Batdau"].ToString() != "" && dtr[i]["Ngay_Ketthuc"].ToString() != "")
                                if (CheckNhansu_Nghiphep(Convert.ToDateTime(dtr[i]["Ngay_Batdau"]), Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]), int.Parse(dtr[i]["Id_Nhansu"].ToString())))
                                {
                                    if (gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"]).ToString() != "" &&
                                        gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"]).ToString() != "")
                                    {
                                        ngay_batdau_new =
                                            Convert.ToDateTime(gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"]));
                                        ngay_ketthuc_new =
                                            Convert.ToDateTime(
                                                gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"]));
                                        id_nghiphep =
                                            Convert.ToInt32(
                                                gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Nghiphep"]).ToString());
                                        //if (dtr[i]["Ngay_Ketthuc"].ToString() != "")
                                        //    if (dtr[i].RowState == DataRowState.Unchanged
                                        //        && ngay_batdau_new <= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) && ngay_ketthuc_new > Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]))
                                        //    {
                                        //        GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian bắt đầu nghỉ nhập không đúng, Nhập lại");
                                        //        gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"], null);
                                        //        break;
                                        //    }
                                        if (dtr[i]["Ngay_Ketthuc"].ToString() != "")
                                        {
                                            if (dtr[i].RowState == DataRowState.Unchanged &&
                                                ngay_ketthuc_new <= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) &&
                                                ngay_ketthuc_new >= Convert.ToDateTime(dtr[i]["Ngay_Batdau"]) &&
                                                id_nghiphep != Convert.ToInt32(dtr[i]["Id_Nghiphep"]))
                                            {
                                                GoobizFrame.Windows.Forms.MessageDialog.Show(
                                                    "Thời gian nghỉ nhập không đúng, Nhập lại");
                                                gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"], null);
                                                break;
                                            }
                                            if (dtr[i].RowState == DataRowState.Unchanged &&
                                                ngay_batdau_new <= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) &&
                                                ngay_batdau_new >= Convert.ToDateTime(dtr[i]["Ngay_Batdau"]) &&
                                                id_nghiphep != Convert.ToInt32(dtr[i]["Id_Nghiphep"]))
                                            {
                                                GoobizFrame.Windows.Forms.MessageDialog.Show(
                                                    "Thời gian nghỉ nhập không đúng, Nhập lại");
                                                gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"], null);
                                                break;
                                            }
                                            if (dtr[i].RowState == DataRowState.Unchanged &&
                                                ngay_ketthuc_new >= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) &&
                                                ngay_batdau_new <= Convert.ToDateTime(dtr[i]["Ngay_Batdau"]) &&
                                                id_nghiphep != Convert.ToInt32(dtr[i]["Id_Nghiphep"]))
                                            {
                                                GoobizFrame.Windows.Forms.MessageDialog.Show(
                                                    "Thời gian nghỉ nhập không đúng, Nhập lại");
                                                gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"], null);
                                                break;
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    //GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian nghỉ phép không đúng, Nhập lại");
                                    //break;
                                }
                        }
                    }
                }
            }
            else if (e.Column.FieldName == "Ngay_Ketthuc")
            {
                DateTime ngay_batdau_new;
                DateTime ngay_ketthuc_new;

                if (gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"]).ToString() != "" && gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"]).ToString() != "")
                {
                    ngay_batdau_new = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"]));
                    ngay_ketthuc_new = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"]));

                    if ((ngay_ketthuc_new < ngay_batdau_new))
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian kết thúc nghỉ nhập không đúng, Nhập lại");
                        gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"], null);
                        return;
                    }
                }
                int id_nghiphep = 0;
                if (gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Nhansu"]).ToString() != "")
                {
                    DataRow[] dtr = ds_Collection.Tables[0].Select("Id_Nhansu = " + gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Nhansu"]));
                    if (dtr.Length > 0)
                    {
                        for (int i = 0; i < dtr.Length; i++)
                        {
                            if (dtr[i]["Ngay_Batdau"].ToString() != "" && dtr[i]["Ngay_Ketthuc"].ToString() != "")
                                if (CheckNhansu_Nghiphep(Convert.ToDateTime(dtr[i]["Ngay_Batdau"]), Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]), int.Parse(dtr[i]["Id_Nhansu"].ToString())))
                                {
                                    if (gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"]).ToString() != "" &&
                                        gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"]).ToString() != "")
                                    {
                                        ngay_batdau_new =
                                            Convert.ToDateTime(gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"]));
                                        ngay_ketthuc_new =
                                            Convert.ToDateTime(
                                                gridView1.GetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"]));
                                        id_nghiphep =
                                            Convert.ToInt32(
                                                gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Nghiphep"]).ToString());
                                        //if (dtr[i]["Ngay_Ketthuc"].ToString() != "")
                                        //    if (dtr[i].RowState == DataRowState.Unchanged
                                        //        && ngay_batdau_new <= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) && ngay_ketthuc_new > Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]))
                                        //    {
                                        //        GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian bắt đầu nghỉ nhập không đúng, Nhập lại");
                                        //        gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"], null);
                                        //        break;
                                        //    }
                                        if (dtr[i]["Ngay_Ketthuc"].ToString() != "")
                                        {
                                            if (dtr[i].RowState == DataRowState.Unchanged &&
                                                ngay_ketthuc_new <= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) &&
                                                ngay_ketthuc_new >= Convert.ToDateTime(dtr[i]["Ngay_Batdau"]) &&
                                                id_nghiphep != Convert.ToInt32(dtr[i]["Id_Nghiphep"]))
                                            {
                                                GoobizFrame.Windows.Forms.MessageDialog.Show(
                                                    "Thời gian nghỉ nhập không đúng, Nhập lại");
                                                gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Ketthuc"], null);
                                                break;
                                            }
                                            if (dtr[i].RowState == DataRowState.Unchanged &&
                                                ngay_batdau_new <= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) &&
                                                ngay_batdau_new >= Convert.ToDateTime(dtr[i]["Ngay_Batdau"]) &&
                                                id_nghiphep != Convert.ToInt32(dtr[i]["Id_Nghiphep"]))
                                            {
                                                GoobizFrame.Windows.Forms.MessageDialog.Show(
                                                    "Thời gian nghỉ nhập không đúng, Nhập lại");
                                                gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"], null);
                                                break;
                                            }
                                            if (dtr[i].RowState == DataRowState.Unchanged &&
                                                ngay_ketthuc_new >= Convert.ToDateTime(dtr[i]["Ngay_Ketthuc"]) &&
                                                ngay_batdau_new <= Convert.ToDateTime(dtr[i]["Ngay_Batdau"]) &&
                                                id_nghiphep != Convert.ToInt32(dtr[i]["Id_Nghiphep"]))
                                            {
                                                GoobizFrame.Windows.Forms.MessageDialog.Show(
                                                    "Thời gian nghỉ nhập không đúng, Nhập lại");
                                                gridView1.SetFocusedRowCellValue(gridView1.Columns["Ngay_Batdau"], null);
                                                break;
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    //GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian nghỉ phép không đúng, Nhập lại");
                                    //break;
                                }
                        }
                    }
                }
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.addnewrow_clicked = true;
            gridView1.OptionsBehavior.Editable = true;
            //ClearDataBindings();
        }

        #endregion

        private bool CheckNhansu_Nghiphep(DateTime ngay_Batdau, DateTime ngay_Ketthuc, int id_Nhansu)
        {
            // phan kiem tra ngay vao lam
            Rex_Nhansu nhansu = objRexService.Get_Rex_Nhansu_ById(id_Nhansu);
            if (DateTime.Parse(nhansu.Ngay_Vaolam.ToString()) > ngay_Batdau)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian bắt đầu nghỉ phép trước thời gian vào làm, Nhập lại");
                return false;
            }
            // phan nghi viec
            DataSet dsnghiviec = objRexService.Get_All_Rex_Nghiviec_ByNhansu(id_Nhansu).ToDataSet();
            if (dsnghiviec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dt in dsnghiviec.Tables[0].Rows)
                {
                    if (Convert.ToDateTime(dt["Ngay_Nghiviec"].ToString()) < ngay_Batdau || Convert.ToDateTime(dt["Ngay_Nghiviec"].ToString()) < ngay_Ketthuc)
                    {
                        // khong hop ly
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian này nhân viên đã nghỉ việc, không thêm được!");
                        return false;
                    }
                }
            }
            // phan hop dong lao dong
            // kiem tra nghi phep trong thoi gian hop dong 
            DataSet dshopdong = objRexService.Get_All_Rex_Hopdong_Laodong_By_Nhansu(id_Nhansu).ToDataSet();
            bool hopdong = false;
            if (dshopdong.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dt in dshopdong.Tables[0].Rows)
                {
                    hopdong = true;
                    if (Convert.ToDateTime(dt["Ngay_Batdau"].ToString()) <= ngay_Batdau)
                    {
                        return true;
                    }

                    // kiem tra ngay ket thuc hop dong
                    if ("" + dt["Ngay_Ketthuc"] != "")
                    {
                        if (Convert.ToDateTime(dt["Ngay_Ketthuc"].ToString()) < ngay_Batdau)
                        {
                            // kiem tra truong hop gia han them hop dong
                            if ("" + dt["thoigian_thuchien_den"] != "")
                            {
                                if (Convert.ToDateTime(dt["thoigian_thuchien_den"].ToString()) < ngay_Batdau)
                                {
                                    GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian nghỉ phép không nằm trong thời gian hợp đồng, Nhập lại");
                                    return false;
                                }
                            }

                        }
                    }
                }
                if (hopdong)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian nghỉ phép không nằm trong thời gian hợp đồng, Nhập lại");
                    return false;
                }
            }
            //GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian bắt đầu, kết thúc nghỉ phép không hợp lý, Nhập lại");
            return true;
        }

        private void txtSogio_Nghi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString().Length > 5)
                e.Cancel = true;
        }

        private void gridText_Sogio_Nghiphep_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString().Length > 5)
                    e.Cancel = true;
                if (e.NewValue.ToString().Equals("0"))
                    e.Cancel = true;
            }
        }


    }
}

