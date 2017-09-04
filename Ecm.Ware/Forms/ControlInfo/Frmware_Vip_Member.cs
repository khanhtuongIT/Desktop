using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Vip_Member :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Vip_Member = new DataSet();
        DataSet ds_Vip_Member_Chitiet = new DataSet();
        DataSet ds_Vip_Member_HHChitiet = new DataSet();
        DataSet ds_Hanghoa_All = new DataSet();
        object Ma_Loai_VIP = null;

        #region local data
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_TREE = @"Resources\localdata\WARE_DM_HANGHOA_TREE.xml";
        DateTime dtlc_ware_dm_hanghoa_tree;

        #endregion

        #region Initialize

        public Frmware_Vip_Member()
        {
            InitializeComponent();
            this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            this.DisplayInfo();
        }

        /// <summary>
        /// Truy xuat DateTime thay doi du lieu cuoi cung
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        private DateTime GetLastChange_FrmLognotify(string table_name)
        {
            try
            {
                return Convert.ToDateTime(dsSys_Lognotify.Tables[0].Select(string.Format("Table_Name='{0}'", table_name))[0]["Last_Change"]);
            }
            catch (Exception ex)
            {
                return new DateTime(2010, 01, 01);
            }
        }

        void LoadMaterData()
        {
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_hanghoa_ban]").ToDataSet();
            dtlc_ware_dm_hanghoa_tree = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            //load data from local xml when last change at local differ from database
            if (DateTime.Compare(dtlc_ware_dm_hanghoa_tree, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_TREE)) > 0
               || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_TREE))
            {
                ds_Hanghoa_All = objMasterService.Get_All_Ware_Dm_Hanghoa_Tree(true, null, null).ToDataSet();
                ds_Hanghoa_All.WriteXml(xml_WARE_DM_HANGHOA_TREE, XmlWriteMode.WriteSchema);
            }
            else if (ds_Hanghoa_All == null || ds_Hanghoa_All.Tables.Count == 0)
            {
                ds_Hanghoa_All = new DataSet();
                ds_Hanghoa_All.ReadXml(xml_WARE_DM_HANGHOA_TREE);
            }
            //gridLookUpEdit_Hanghoa
            gridLookUpEdit_Hanghoa.DataSource = ds_Hanghoa_All.Tables[0];
        }

        #endregion

        #region Event Override


        public override void DisplayInfo()
        {
            try
            {
                LoadMaterData();
                gridLookUpEdit_Cuahang_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa().ToDataSet().Tables[0];
                //Get data Ware_Vip_Member
                ds_Vip_Member = objWareService.Get_All_Ware_Vip_Member().ToDataSet();
                dgware_Vip_Member.DataSource = ds_Vip_Member;
                dgware_Vip_Member.DataMember = ds_Vip_Member.Tables[0].TableName;

                this.DataBindingControl();
                this.ChangeStatus(false);
                this.gridView1.BestFitColumns();
                DisplayInfo2();
                Ma_Loai_VIP = null;
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
            this.txtMa_Vip_Member.DataBindings.Clear();
            this.txtTen_Vip_Member.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.txtMark_Rate.DataBindings.Clear();
            this.txtDuration.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Vip_Member.DataBindings.Add("EditValue", ds_Vip_Member, ds_Vip_Member.Tables[0].TableName + ".Ma_Vip_Member");
                this.txtTen_Vip_Member.DataBindings.Add("EditValue", ds_Vip_Member, ds_Vip_Member.Tables[0].TableName + ".Ten_Vip_Member");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Vip_Member, ds_Vip_Member.Tables[0].TableName + ".Ghichu");
                this.txtMark_Rate.DataBindings.Add("EditValue", ds_Vip_Member, ds_Vip_Member.Tables[0].TableName + ".Mark_Rate");
                this.txtDuration.DataBindings.Add("EditValue", ds_Vip_Member, ds_Vip_Member.Tables[0].TableName + ".Duration");
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
            this.dgware_Vip_Member.Enabled = !editTable;
            this.txtMa_Vip_Member.Properties.ReadOnly = !editTable;
            this.txtTen_Vip_Member.Properties.ReadOnly = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.txtMark_Rate.Properties.ReadOnly = !editTable;
            this.txtDuration.Properties.ReadOnly = !editTable;
            this.gridView2.OptionsBehavior.Editable = editTable;
            xtraHNavigator2.VisibleAppend = editTable;
            xtraHNavigator2.VisibleCancelEdit = editTable;
            xtraHNavigator2.VisibleRemove = editTable;
            xtraHNavigator2.VisibleEndEdit = editTable;
        }

        public override void ResetText()
        {
            this.txtMa_Vip_Member.EditValue = "";
            this.txtTen_Vip_Member.EditValue = "";
            this.txtGhichu.EditValue = "";
            this.txtMark_Rate.EditValue = "";
            this.txtDuration.EditValue = "";
            this.ds_Vip_Member_Chitiet = objWareService.Get_All_Ware_Vip_Member_Detail_By_Vip_Member(0).ToDataSet();
            this.dgware_Vip_Member_Chitiet.DataSource = ds_Vip_Member_Chitiet.Tables[0];
            this.ds_Vip_Member_HHChitiet = objWareService.Get_All_Ware_Vip_Member_HhDetail_By_Vip_Member(0).ToDataSet();
            this.dgVip_Member_Hhdetail.DataSource = ds_Vip_Member_HHChitiet.Tables[0];
        }


        void DisplayInfo2()
        {
            if ("" + gridView1.GetFocusedRowCellValue("Id_Vip_Member") == "")
                return;

            //dgware_Vip_Member_Chitiet
            this.ds_Vip_Member_Chitiet = objWareService.Get_All_Ware_Vip_Member_Detail_By_Vip_Member(gridView1.GetFocusedRowCellValue("Id_Vip_Member")).ToDataSet();
            this.dgware_Vip_Member_Chitiet.DataSource = ds_Vip_Member_Chitiet;
            this.dgware_Vip_Member_Chitiet.DataMember = ds_Vip_Member_Chitiet.Tables[0].TableName;
            gridView4.BestFitColumns();

            //dgVip_Member_Hhdetail
            this.ds_Vip_Member_HHChitiet = objWareService.Get_All_Ware_Vip_Member_HhDetail_By_Vip_Member(gridView1.GetFocusedRowCellValue("Id_Vip_Member")).ToDataSet();
            this.dgVip_Member_Hhdetail.DataSource = ds_Vip_Member_HHChitiet;
            this.dgVip_Member_Hhdetail.DataMember = ds_Vip_Member_HHChitiet.Tables[0].TableName;
            gridView2.BestFitColumns();
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Vip_Member objWare_Vip_Member = new Ecm.WebReferences.WareService.Ware_Vip_Member();
                objWare_Vip_Member.Id_Vip_Member = -1;
                objWare_Vip_Member.Ma_Vip_Member = txtMa_Vip_Member.EditValue;
                objWare_Vip_Member.Ten_Vip_Member = txtTen_Vip_Member.EditValue;
                objWare_Vip_Member.Ghichu = txtGhichu.EditValue;
                objWare_Vip_Member.Mark_Rate = txtMark_Rate.EditValue;
                objWare_Vip_Member.Duration = txtDuration.EditValue;
                object identity = objWareService.Insert_Ware_Vip_Member(objWare_Vip_Member);

                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Vip_Member_Chitiet); 
                    foreach (DataRow dr in ds_Vip_Member_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Vip_Member"] = identity;
                    }
                    //update hdmuahang_chitiet
                    objWareService.Update_Ware_Vip_Member_Detail_Collection(ds_Vip_Member_Chitiet);

                    this.DoClickEndEdit(dgVip_Member_Hhdetail); 
                    foreach (DataRow dr in ds_Vip_Member_HHChitiet.Tables[0].Rows)
                    {
                        dr["Id_Vip_Member"] = identity;
                    }
                    //update hdmuahang_chitiet
                    objWareService.Update_Ware_Vip_Member_HhDetail_Collection(ds_Vip_Member_HHChitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Vip_Member objWare_Vip_Member = new Ecm.WebReferences.WareService.Ware_Vip_Member();
                objWare_Vip_Member.Id_Vip_Member = gridView1.GetFocusedRowCellValue("Id_Vip_Member");
                objWare_Vip_Member.Ma_Vip_Member = txtMa_Vip_Member.EditValue;
                objWare_Vip_Member.Ten_Vip_Member = txtTen_Vip_Member.EditValue;
                objWare_Vip_Member.Ghichu = txtGhichu.EditValue;
                objWare_Vip_Member.Mark_Rate = txtMark_Rate.EditValue;
                objWare_Vip_Member.Duration = txtDuration.EditValue;
                //update hdbanhang
                objWareService.Update_Ware_Vip_Member(objWare_Vip_Member);

                //update hdbanhang_chitiet
                this.DoClickEndEdit(dgware_Vip_Member_Chitiet); 
                foreach (DataRow dr in ds_Vip_Member_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Vip_Member"] = gridView1.GetFocusedRowCellValue("Id_Vip_Member");
                }
                objWareService.Update_Ware_Vip_Member_Detail_Collection(ds_Vip_Member_Chitiet);

                //update Ware_Vip_Member_HhDetail
                this.DoClickEndEdit(dgVip_Member_Hhdetail); 
                foreach (DataRow dr in ds_Vip_Member_HHChitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Vip_Member"] = gridView1.GetFocusedRowCellValue("Id_Vip_Member");
                }
                //update hdmuahang_chitiet
                objWareService.Update_Ware_Vip_Member_HhDetail_Collection(ds_Vip_Member_HHChitiet);

                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Vip_Member objWare_Vip_Member = new Ecm.WebReferences.WareService.Ware_Vip_Member();
            objWare_Vip_Member.Id_Vip_Member = gridView1.GetFocusedRowCellValue("Id_Vip_Member");
            return objWareService.Delete_Ware_Vip_Member(objWare_Vip_Member);
        }

        public override bool PerformAdd()
        {
            this.ChangeStatus(true);
            ClearDataBindings();
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            this.ChangeStatus(true);
            Ma_Loai_VIP = txtMa_Vip_Member.EditValue;
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
                this.DoClickEndEdit(dgVip_Member_Hhdetail); //dgVip_Member_Hhdetail.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                htbControl1.Add(txtMark_Rate, lblMark_Rate.Text);
                htbControl1.Add(txtMa_Vip_Member, lblMa_Vip_Member.Text);
                htbControl1.Add(txtTen_Vip_Member, lblTen_Vip_Member.Text);
                htbControl1.Add(txtDuration, lblDuration.Text);

                this.DoClickEndEdit(dgware_Vip_Member_Chitiet);
                if (FormState ==  GoobizFrame.Windows.Forms.FormState.Add
                    || !txtMa_Vip_Member.EditValue.Equals(Ma_Loai_VIP))
                {
                    System.Collections.Hashtable htbControl_Gridview1 = new System.Collections.Hashtable();
                    htbControl_Gridview1.Add(txtMa_Vip_Member, lblMa_Vip_Member.Text);
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbControl_Gridview1, ds_Vip_Member, "Ma_Vip_Member"))
                        return false;
                }

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;

                if (gridView2.RowCount == 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Ngành hàng giảm giá không thể rỗng. Vui lòng nhập ngành hàng");
                    return false;
                }

                System.Collections.Hashtable htbGrid = new System.Collections.Hashtable();
                htbGrid.Add(gridView2.Columns["Ma_Ql"], "");
                htbGrid.Add(gridView2.Columns["Per_Hoadon"], "");

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(htbGrid, gridView2))
                    return false;

                htbGrid.Remove(gridView2.Columns["Per_Hoadon"]);
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htbGrid, gridView2))
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
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public override bool PerformDelete()
        {
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Vip_Member"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Vip_Member")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override bool PerformPrintPreview()
        {
            return base.PerformPrintPreview();
        }
        #endregion

        #region Even

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.DisplayInfo2();
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Ma_Kho_Hanghoa")
            {
                DataRow focus_row = gridView4.GetDataRow(gridView4.FocusedRowHandle);
                focus_row["Id_Cuahang_Ban"] = ((System.Data.DataRowView)gridLookUpEdit_Cuahang_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Cuahang_Ban"];
            }
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Ma_Ql")
            {
                DataRow focus_row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                focus_row["Id_Nhom_Hanghoa"] = ((System.Data.DataRowView)gridLookUpEdit_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Id_Nhom_Hanghoa"];
                focus_row["Id_Loai_Hanghoa"] = ((System.Data.DataRowView)gridLookUpEdit_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Id_Loai_Hanghoa"];
                focus_row["Id_Hanghoa"] = ((System.Data.DataRowView)gridLookUpEdit_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Id_Hanghoa"];
            }
            if (e.Column.FieldName == "Per_Hoadon")
            {
                object per_hoadon = gridView2.GetFocusedRowCellValue(gridView2.Columns["Per_Hoadon"]);
                if (per_hoadon.ToString() != "")
                {
                    if (per_hoadon.ToString().Contains("-"))
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Phần trăm giảm giá không được nhập số âm");
                        gridView2.SetFocusedRowCellValue(gridView2.Columns["Per_Hoadon"], per_hoadon.ToString().Replace("-", ""));
                        return;
                    }
                }
            }
        }

        private void gridLookUpEdit_Hanghoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Tree Frmware_Dm_Hanghoa_Tree = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Tree();
                Frmware_Dm_Hanghoa_Tree.Text = "Hàng hóa";
                 GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(Frmware_Dm_Hanghoa_Tree);
                Frmware_Dm_Hanghoa_Tree.ShowDialog();
                if (Frmware_Dm_Hanghoa_Tree.SelectedRow != null)
                {
                    DataRow focus_row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                    focus_row["Ma_Ql"] = Frmware_Dm_Hanghoa_Tree.SelectedRow["Ma_Ql"];
                }
            }
        }
#endregion

        private void gridText_Giamgia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (e.NewValue.ToString() != "" && Convert.ToInt32(e.NewValue) > 100)
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


      
    }
}

