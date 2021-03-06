using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Dieuxe_Dialog : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Dieuxe = new DataSet();
        object identity;
        object id_xuatkho;
        object id_nhansu_current;
        DataSet ds_Xkbanhang_Chitiet;
        DataSet ds_Dieuxe_Chitet;
        public DataRow[] _selectedRows;

        public Frmware_Dieuxe_Dialog(object Id_Xuatkho_Banhang, string Sochungtu)
        {
            InitializeComponent();
            id_xuatkho = Id_Xuatkho_Banhang;
            txtPhieuxuat.Text = Sochungtu;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.EnableAdd = true;
            this.EnableEdit = true;
            this.EnableDelete = true;
            dtThangnam.EditValue = DateTime.Now;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                DataSet dsCollection = objMasterService.GetAll_Ware_Dm_Xe().ToDataSet();
                gridLookupEdit_Xe.DataSource = dsCollection.Tables[0];
                lookupEdit_Dm_Xe.Properties.DataSource = dsCollection.Tables[0];

                dsCollection = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
                lookUpEdit_Kho.Properties.DataSource = dsCollection.Tables[0];

                dsCollection = objRexService.Get_Rex_Nhansu_ByBoPhan_Collection(6).ToDataSet();
                gridLookupEdit_Taixe.DataSource = dsCollection.Tables[0];
                lookUpEdit_Taixe.Properties.DataSource = dsCollection.Tables[0];

                dsCollection = objMasterService.Get_All_Ware_Dm_Hanghoa().ToDataSet();
                gridLookUpEdit_Hanghoa_Ban.DataSource = dsCollection.Tables[0];
                gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = dsCollection.Tables[0];
                gridLookupEdit_Mahanghoa2.DataSource = dsCollection.Tables[0];
                gridLookupEdit_Tenhanghoa2.DataSource = dsCollection.Tables[0];

                dsCollection = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                gridLookUpEdit_Donvitinh.DataSource = dsCollection.Tables[0];
                gridLookupEdit_DVT2.DataSource = dsCollection.Tables[0];

                //ds_Dieuxe = objWareService.Ware_Dieuxe_SelectBy_Id_Xuatkho(id_xuatkho).ToDataSet();
                //dgDieuxe.DataSource = ds_Dieuxe;
                //dgDieuxe.DataMember = ds_Dieuxe.Tables[0].TableName;

                dsCollection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
                DataSet dsCuahang_Ban = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
                //gridLookUpEdit_Cuahang_Ban_Xuat.DataSource = dsCuahang_Ban.Tables[0];

                if (dsCollection.Tables[0].Rows.Count > 0 &&
                    "" + dsCollection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                {
                    DataTable temp = dsCuahang_Ban.Tables[0].Copy();
                    DataRow row = temp.NewRow();
                    row["Id_Cuahang_Ban"] = -1;
                    row["Ma_Cuahang_Ban"] = "All";
                    row["Ten_Cuahang_Ban"] = "Tất cả";
                    temp.Rows.Add(row);
                    lookUpEdit_Kho_View.Properties.DataSource = temp;
                    lookUpEdit_Kho_View.EditValue = -1;
                }
                else
                {
                    DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, true).ToDataSet();
                    lookUpEdit_Kho_View.Properties.DataSource = dsCuahang.Tables[0];
                }

                ChangeStatus(true);
                DisplayInfo_Details();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DisplayInfo_Details()
        {
            try
            {
                DataBindingControl();
                identity = gvDieuxe.GetFocusedRowCellValue("Id_Dieuxe");
                ds_Xkbanhang_Chitiet = objWareService.Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(id_xuatkho).ToDataSet();
                ds_Xkbanhang_Chitiet.Tables[0].Columns.Add("Chon", typeof(bool));
                this.dgware_Hdbanhang_Chitiet.DataSource = ds_Xkbanhang_Chitiet;
                this.dgware_Hdbanhang_Chitiet.DataMember = ds_Xkbanhang_Chitiet.Tables[0].TableName;

                //ds_Dieuxe_Chitet = objWareService.Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe(identity).ToDataSet();
                //ds_Dieuxe_Chitet.Tables[0].Columns.Add("Chon", typeof(bool));
                //dgDieuxe_Chitiet.DataSource = ds_Dieuxe_Chitet;
                //dgDieuxe_Chitiet.DataMember = ds_Dieuxe_Chitet.Tables[0].TableName;
                gvDieuxe_Chitiet.ExpandAllGroups();
            }
            catch { }
        }

        public override void ResetText()
        {
            lookupEdit_Dm_Xe.EditValue = null;
            lookUpEdit_Taixe.EditValue = null;
            lookUpEdit_Kho.EditValue = null;
            dateEdit_Ngaydi.EditValue = null;
            dateEdit__Ngayden.EditValue = null;
            dateEdit_Ngayve.EditValue = null;
            txtQuangduongdi.EditValue = null;
            richTextBoxGhichu.Text = "";
            base.ResetText();
        }

        public override void ClearDataBindings()
        {
            lookupEdit_Dm_Xe.DataBindings.Clear();
            lookUpEdit_Taixe.DataBindings.Clear();
            lookUpEdit_Kho.DataBindings.Clear();
            dateEdit_Ngaydi.DataBindings.Clear();
            dateEdit__Ngayden.DataBindings.Clear();
            dateEdit_Ngayve.DataBindings.Clear();
            txtQuangduongdi.DataBindings.Clear();
            richTextBoxGhichu.DataBindings.Clear();
            base.ClearDataBindings();
        }

        public override void DataBindingControl()
        {
            ClearDataBindings();
            lookupEdit_Dm_Xe.DataBindings.Add("EditValue", ds_Dieuxe, ds_Dieuxe.Tables[0].TableName + ".Id_Xe");
            lookUpEdit_Taixe.DataBindings.Add("EditValue", ds_Dieuxe, ds_Dieuxe.Tables[0].TableName + ".Id_Taixe");
            lookUpEdit_Kho.DataBindings.Add("EditValue", ds_Dieuxe, ds_Dieuxe.Tables[0].TableName + ".Id_Cuahang_Ban");
            dateEdit_Ngaydi.DataBindings.Add("EditValue", ds_Dieuxe, ds_Dieuxe.Tables[0].TableName + ".Ngay_Di");
            dateEdit__Ngayden.DataBindings.Add("EditValue", ds_Dieuxe, ds_Dieuxe.Tables[0].TableName + ".Ngay_Den");
            dateEdit_Ngayve.DataBindings.Add("EditValue", ds_Dieuxe, ds_Dieuxe.Tables[0].TableName + ".Ngay_Ve");
            txtQuangduongdi.DataBindings.Add("EditValue", ds_Dieuxe, ds_Dieuxe.Tables[0].TableName + ".Quangduong_Di");
            richTextBoxGhichu.DataBindings.Add("Text", ds_Dieuxe, ds_Dieuxe.Tables[0].TableName + ".Ghichu");
            base.DataBindingControl();
        }

        public override void ChangeStatus(bool editTable)
        {
            lookupEdit_Dm_Xe.Properties.ReadOnly = editTable;
            lookUpEdit_Taixe.Properties.ReadOnly = editTable;
            lookUpEdit_Kho.Properties.ReadOnly = editTable;
            dateEdit_Ngaydi.Properties.ReadOnly = editTable;
            dateEdit__Ngayden.Properties.ReadOnly = editTable;
            dateEdit_Ngayve.Properties.ReadOnly = editTable;
            txtQuangduongdi.Properties.ReadOnly = editTable;
            richTextBoxGhichu.ReadOnly = editTable;
            dgDieuxe.Enabled = editTable;
            tableLayoutPanel2.Enabled = editTable;
            gvware_Xuat_Hanghoa_Ban_Chitiet.OptionsBehavior.ReadOnly = editTable;
            gvDieuxe_Chitiet.OptionsBehavior.ReadOnly = editTable;

            btnAdd.Enabled = !editTable;
            btnAdd_All.Enabled = !editTable;
            btnRemove.Enabled = !editTable;
            btnRemove_All.Enabled = !editTable;
            base.ChangeStatus(editTable);
        }

        public override bool PerformAdd()
        {
            ResetText();
            ChangeStatus(false);
            //ds_Dieuxe_Chitet = objWareService.Ware_Dieuxe_Chitiet_SelectBy_Id_Dieuxe(-1).ToDataSet();
            dgDieuxe_Chitiet.DataSource = ds_Dieuxe_Chitet.Tables[0];
            return base.PerformAdd();
        }

        public override bool PerformEdit()
        {
            if (gvDieuxe.GetFocusedRowCellValue("Id_Dieuxe") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu điều xe, vui lòng chọn lại");
                return false;
            }
            ChangeStatus(false);
            return base.PerformEdit();
        }

        public override bool PerformDelete()
        {
            if (gvDieuxe.GetFocusedRowCellValue("Id_Dieuxe") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu điều xe, vui lòng chọn lại");
                return false;
            }

            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dieuxe"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dieuxe")   }) == DialogResult.Yes)
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

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Dieuxe _Ware_Dieuxe = new Ecm.WebReferences.WareService.Ware_Dieuxe();
            _Ware_Dieuxe.Id_Dieuxe = identity;
            return objWareService.Delete_Ware_Dieuxe(_Ware_Dieuxe);
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(lookupEdit_Dm_Xe, lblXe.Text);
                hashtableControls.Add(lookUpEdit_Taixe, lblTaixe.Text);
                hashtableControls.Add(lookUpEdit_Kho, lblKho.Text);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                DoClickEndEdit(dgware_Hdbanhang_Chitiet);
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                    success = (bool)this.InsertObject();
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                    success = (bool)this.UpdateObject();
                if (success)
                {
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvDieuxe.Columns["Id_Nhansu_Dieuxe"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvDieuxe))
                return false;

            //if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gvDieuxe))
            //    return;
            try
            {
                dgDieuxe.EmbeddedNavigator.Buttons.DoClick(dgDieuxe.EmbeddedNavigator.Buttons.EndEdit);
                //ds_Dieuxe.BeginInit();
                objWareService.Update_Ware_Dieuxe_Collection(ds_Dieuxe);
                ds_Dieuxe.AcceptChanges();
                ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
                return false;
            }
            this.DisplayInfo();
            return base.PerformSaveChanges();
        }

        public override bool PerformCancel()
        {
            DisplayInfo();
            return base.PerformCancel();
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Dieuxe _Ware_Dieuxe = new Ecm.WebReferences.WareService.Ware_Dieuxe();
                _Ware_Dieuxe.Id_Xuatkho_Banhang = id_xuatkho;
                _Ware_Dieuxe.Id_Xe = lookupEdit_Dm_Xe.EditValue;
                _Ware_Dieuxe.Id_Nhansu_Dieuxe = id_nhansu_current;
                _Ware_Dieuxe.Id_Taixe = lookUpEdit_Taixe.EditValue;
                _Ware_Dieuxe.Ngay_Di = dateEdit_Ngaydi.EditValue;
                _Ware_Dieuxe.Ngay_Den = dateEdit__Ngayden.EditValue;
                _Ware_Dieuxe.Ngay_Ve = dateEdit_Ngayve.EditValue;
                _Ware_Dieuxe.Quangduong_Di = txtQuangduongdi.EditValue;
                _Ware_Dieuxe.Ghichu = richTextBoxGhichu.Text;
                //_Ware_Dieuxe.Id_Cuahang_Ban = lookUpEdit_Kho.EditValue;
                identity = objWareService.Insert_Ware_Dieuxe(_Ware_Dieuxe);

                //if (identity != null)
                //{
                //    DataSet dsDieuxe_Xuatkho_temp = objWareService.Get_Schema_Ware_Dieuxe_Xuatkho().ToDataSet();
                //    DataRow Row = dsDieuxe_Xuatkho_temp.Tables[0].NewRow();
                //    Row["Id_Dieuxe"] = identity;
                //    Row["Id_Xuatkho_Banhang"] = id_xuatkho;
                //    dsDieuxe_Xuatkho_temp.Tables[0].Rows.Add(Row);
                //    objWareService.Update_Ware_Dieuxe_Xuatkho_Collection(dsDieuxe_Xuatkho_temp);

                //    DoClickEndEdit(dgDieuxe_Chitiet);
                //    foreach (DataRow dr in ds_Dieuxe_Chitet.Tables[0].Rows)
                //    {
                //        if (dr.RowState == DataRowState.Added)
                //            dr["Id_Dieuxe"] = identity;
                //    }
                //    objWareService.Update_Ware_Dieuxe_Chitiet_Collection(ds_Dieuxe_Chitet);
                //}
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Dieuxe _Ware_Dieuxe = new Ecm.WebReferences.WareService.Ware_Dieuxe();
                _Ware_Dieuxe.Id_Dieuxe = identity;
                _Ware_Dieuxe.Id_Xuatkho_Banhang = id_xuatkho;
                _Ware_Dieuxe.Id_Xe = lookupEdit_Dm_Xe.EditValue;
                _Ware_Dieuxe.Id_Nhansu_Dieuxe = id_nhansu_current;
                _Ware_Dieuxe.Id_Taixe = lookUpEdit_Taixe.EditValue;
                _Ware_Dieuxe.Ngay_Di = dateEdit_Ngaydi.EditValue;
                _Ware_Dieuxe.Ngay_Den = dateEdit__Ngayden.EditValue;
                _Ware_Dieuxe.Ngay_Ve = dateEdit_Ngayve.EditValue;
                _Ware_Dieuxe.Quangduong_Di = txtQuangduongdi.EditValue;
                _Ware_Dieuxe.Ghichu = richTextBoxGhichu.Text;
                //_Ware_Dieuxe.Id_Cuahang_Ban = lookUpEdit_Kho.EditValue;
                objWareService.Update_Ware_Dieuxe(_Ware_Dieuxe);

                //if (identity != null)
                //{
                //    if (!gvDieuxe.GetFocusedRowCellValue("Id_Xuatkho_Banhang").Equals(id_xuatkho))
                //    {
                //        DataSet dsDieuxe_Xuatkho_temp = objWareService.Get_Schema_Ware_Dieuxe_Xuatkho().ToDataSet();
                //        DataRow Row = dsDieuxe_Xuatkho_temp.Tables[0].NewRow();
                //        Row["Id_Dieuxe"] = identity;
                //        Row["Id_Xuatkho_Banhang"] = id_xuatkho;
                //        dsDieuxe_Xuatkho_temp.Tables[0].Rows.Add(Row);
                //        objWareService.Update_Ware_Dieuxe_Xuatkho_Collection(dsDieuxe_Xuatkho_temp);
                //    }

                //    DoClickEndEdit(dgDieuxe_Chitiet);
                //    foreach (DataRow dr in ds_Dieuxe_Chitet.Tables[0].Rows)
                //    {
                //        if (dr.RowState == DataRowState.Added)
                //            dr["Id_Dieuxe"] = identity;
                //    }
                //    objWareService.Update_Ware_Dieuxe_Chitiet_Collection(ds_Dieuxe_Chitet);
                //}
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearDataBindings();
            //if (gridView1.FocusedRowHandle >= 0)
            //    DisplayInfo_Details();
            //else
            //    ResetText();
        }

        private void gvDieuxe_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDieuxe.SetFocusedRowCellValue("Ngay_Di", DateTime.Now);
            gvDieuxe.SetFocusedRowCellValue("Ngay_Den", DateTime.Now);
            gvDieuxe.SetFocusedRowCellValue("Ngay_Ve", DateTime.Now);
            gvDieuxe.SetFocusedRowCellValue("Id_Xuatkho_Banhang", identity);
        }

        private void gvDieuxe_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearDataBindings();
            if (gvDieuxe.FocusedRowHandle >= 0)
                DisplayInfo_Details();
            else
                ResetText();
        }

        private void lookUpEdit_Taixe_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_Kho.EditValue = lookUpEdit_Taixe.EditValue;
        }

        private void btnAdd_All_Click(object sender, EventArgs e)
        {
            DoClickEndEdit(dgware_Hdbanhang_Chitiet);
            foreach (DataRow dtr in ds_Xkbanhang_Chitiet.Tables[0].Rows)
            {
                if (Convert.ToDecimal("0" + dtr["Soluong_Conlai"]) > 0)
                {
                    DataRow[] row_xuatkho_banhang_chitiet = ds_Dieuxe_Chitet.Tables[0].Select("Id_Xuatkho_Banhang_Chitiet = " + dtr["Id_Xuatkho_Banhang_Chitiet"], "");
                    if (row_xuatkho_banhang_chitiet.Length > 0) // update
                    {
                        row_xuatkho_banhang_chitiet[0]["Soluong"] = Convert.ToDecimal("0" + row_xuatkho_banhang_chitiet[0]["Soluong"]) + Convert.ToDecimal("0" + dtr["Soluong_Conlai"]);
                    }
                    else // add new
                    {
                        DataRow row = ds_Dieuxe_Chitet.Tables[0].NewRow();
                        row["Id_Dieuxe"] = ("" + identity == "") ? -1 : identity;
                        row["Id_Xuatkho_Banhang_Chitiet"] = dtr["Id_Xuatkho_Banhang_Chitiet"];
                        row["Id_Hanghoa_Ban"] = dtr["Id_Hanghoa_Ban"];
                        row["Id_Donvitinh"] = dtr["Id_Donvitinh"];
                        row["Soluong"] = dtr["Soluong_Conlai"];
                        row["Dongia"] = dtr["Dongia"];
                        ds_Dieuxe_Chitet.Tables[0].Rows.Add(row);
                    }
                }
            }
            //ds_Xkbanhang_Chitiet.Tables[0].Rows.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds_Xkbanhang_Chitiet == null || ds_Xkbanhang_Chitiet.Tables.Count == 0) return;
                _selectedRows = ds_Xkbanhang_Chitiet.Tables[0].Select("Chon=true");
                if (_selectedRows == null || _selectedRows.Length == 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Tên hàng" });
                    return;
                }
                foreach (DataRow dtr in _selectedRows)
                {
                    if (Convert.ToDecimal("0" + dtr["Soluong_Conlai"]) > 0)
                    {
                        DataRow row = ds_Dieuxe_Chitet.Tables[0].NewRow();
                        row["Id_Dieuxe"] = ("" + identity == "") ? -1 : identity;
                        row["Id_Xuatkho_Banhang_Chitiet"] = dtr["Id_Xuatkho_Banhang_Chitiet"];
                        row["Id_Hanghoa_Ban"] = dtr["Id_Hanghoa_Ban"];
                        row["Id_Donvitinh"] = dtr["Id_Donvitinh"];
                        row["Soluong"] = dtr["Soluong_Conlai"];
                        row["Dongia"] = dtr["Dongia"];
                        ds_Dieuxe_Chitet.Tables[0].Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("Msg00130", new string[] { ex.Message });
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds_Dieuxe_Chitet == null || ds_Dieuxe_Chitet.Tables.Count == 0) return;
                _selectedRows = ds_Dieuxe_Chitet.Tables[0].Select("Chon=true");
                if (_selectedRows == null || _selectedRows.Length == 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Tên hàng" });
                    return;
                }
                for (int i = ds_Dieuxe_Chitet.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = ds_Dieuxe_Chitet.Tables[0].Rows[i];
                    {
                        if (Convert.ToBoolean(("" + row["Chon"] == "") ? false : row["Chon"]))
                            ds_Dieuxe_Chitet.Tables[0].Rows[i].Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("Msg00130", new string[] { ex.Message });
            }
        }

        private void btnRemove_All_Click(object sender, EventArgs e)
        {
            for (int i = ds_Dieuxe_Chitet.Tables[0].Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = ds_Dieuxe_Chitet.Tables[0].Rows[i];
                {
                    ds_Dieuxe_Chitet.Tables[0].Rows[i].Delete();
                }
            }
        }

        private void gvware_Xuat_Hanghoa_Ban_Chitiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Soluong_Conlai")
            {
                decimal soluong_donhang = Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Soluong_Conlai_Bef"));
                if (Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Soluong_Conlai")) > soluong_donhang)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được lớn hơn số lượng đơn hàng");
                    gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue("Soluong_Conlai", gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Soluong_Conlai_Bef"));
                }
            }
        }

        private void gvDieuxe_Chitiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Soluong")
            {
                decimal Soluong_Da_Dieuxe = Convert.ToDecimal("0" + gvDieuxe_Chitiet.GetFocusedRowCellValue("Soluong_Da_Dieuxe"));
                decimal soluong_donhang = Convert.ToDecimal("0" + gvDieuxe_Chitiet.GetFocusedRowCellValue("Soluong_Donhang"));

                if (Convert.ToDecimal("0" + gvDieuxe_Chitiet.GetFocusedRowCellValue("Soluong")) > (soluong_donhang - Soluong_Da_Dieuxe))
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được lớn hơn số lượng đơn hàng");
                    gvDieuxe_Chitiet.SetFocusedRowCellValue("Soluong", gvDieuxe_Chitiet.GetFocusedRowCellValue("Soluong2"));
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //ds_Dieuxe = objWareService.Get_All_Ware_Dieuxe(dtThangnam.EditValue, lookUpEdit_Kho_View.EditValue).ToDataSet();
            //dgDieuxe.DataSource = ds_Dieuxe;
            //dgDieuxe.DataMember = ds_Dieuxe.Tables[0].TableName;
            //gvDieuxe.BestFitColumns();
            //this.DataBindingControl();
            //this.ChangeStatus(true);
        }

    }
}