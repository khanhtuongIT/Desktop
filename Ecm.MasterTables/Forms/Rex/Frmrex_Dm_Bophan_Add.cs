using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Rex
{
    public partial class Frmrex_Dm_Bophan_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        //public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Bophan = new DataSet();
        DataSet ds_Loai_Bophan = new DataSet();
        DataSet ds_PT_Huongluong = new DataSet();
        DataSet ds_Collection = new DataSet();
        DevExpress.XtraTreeList.Nodes.TreeListNode focusNode;
        //object Id_Bophan;

        private Ecm.WebReferences.MasterService.Rex_Dm_Bophan _SelectedObject;
        public Ecm.WebReferences.MasterService.Rex_Dm_Bophan SelectedObject
        {
            get { return _SelectedObject; }
            set { _SelectedObject = value; }
        }
        
        public Frmrex_Dm_Bophan_Add()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            DisplayInfo();
            lookUp_Bophan.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
                ds_Loai_Bophan = objMasterService.Get_All_Rex_Dm_Loai_Bophan_Collection().ToDataSet();
                ds_PT_Huongluong = objMasterService.Get_All_Rex_Dm_Phuongthuc_Huongluong_Collection().ToDataSet();

                treeListColumn1.TreeList.DataSource = ds_Bophan.Tables[0];
                gridLookUp_Bophan.DataSource = ds_Bophan.Tables[0];
                //dgrex_Dm_Bophan.DataSource = ds_Bophan;
                //dgrex_Dm_Bophan.DataMember = ds_Bophan.Tables[0].TableName;
                //lookUpEdit_Bophan
                lookUp_Bophan.Properties.DataSource = ds_Bophan.Tables[0];
                lookUp_LoaiBP.Properties.DataSource = ds_Loai_Bophan.Tables[0];
                lookUp_PTHuongLuong.Properties.DataSource = ds_PT_Huongluong.Tables[0];
                //gridLookUpEdit_Bophan.DataSource = ds_Bophan.Tables[0];
                dgrex_Dm_Bophan.DataSource = ds_Bophan;
                dgrex_Dm_Bophan.DataMember = ds_Bophan.Tables[0].TableName;
                this.Data = ds_Bophan;
                //this.GridControl = dgrex_Dm_Bophan;
                this.DataBindingControl();
                this.ChangeStatus(false);
                this.bandedGridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void DisplayInfo2()
        {
            lock (this)
            {
                try
                {
                    //ds_Collection = objMasterService.Get_All_Rex_Dm_Bophan_Collection();
                    //DataSet ds = objRex.GetAll_Rex_Nhansu_By_Bophan_Collection(id_bophan);
                    //foreach (DataRow row_rex_nhansu in ds_Collection.Tables[0].Rows)
                    //    row_rex_nhansu["Ngaysinh"] = GoobizFrame.Windows.MdiUtils.DateTimeMask.YMDToShortDatePattern("" + row_rex_nhansu["Ngaysinh"],
                    //        GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat());

                    //dgrex_Dm_Bophan.DataSource = ds_Bophan;
                    //dgrex_Dm_Bophan.DataMember = ds_Bophan.Tables[0].TableName;

                    //bandedGridView1.FocusedRowHandle = 3;
                    //focusNode.GetValue("Id_Bophan");
                    //bandedGridView1.Columns["Id_Bophan"].FilterInfo = new 
                    //DevExpress.XtraGrid.Columns.ColumnFilterInfo(bandedGridView1.Columns["Id_Bophan"], Id_Bophan);
                    //bandedGridView1.BestFitColumns();
                    if (this.focusNode != null)
                        if (focusNode.GetValue("Id_Bophan").ToString() != "")
                        {
                            int focus = bandedGridView1.GetRowHandle(ds_Bophan.Tables[0].Rows.IndexOf(ds_Bophan.Tables[0].Select("Id_Bophan='" + focusNode.GetValue("Id_Bophan").ToString() + "'")[0]));
                            bandedGridView1.FocusedRowHandle = focus;
                            DataBindingControl();
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

        public override void ClearDataBindings()
        {
            this.txtId_Bophan.DataBindings.Clear();
            this.txtMa_Bophan.DataBindings.Clear();
            this.txtTen_Bophan.DataBindings.Clear();
            this.lookUp_Bophan.DataBindings.Clear();
            this.lookUp_LoaiBP.DataBindings.Clear();
            this.lookUp_PTHuongLuong.DataBindings.Clear();
            this.chkChunhat.DataBindings.Clear();
            this.chkThuhai.DataBindings.Clear();
            this.chkThuba.DataBindings.Clear();
            this.chkThutu.DataBindings.Clear();
            this.chkThunam.DataBindings.Clear();
            this.chkThusau.DataBindings.Clear();
            this.chkThubay.DataBindings.Clear();
        }

        public override void  DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Bophan.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".Id_Bophan");
                this.txtMa_Bophan.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".Ma_Bophan");
                this.txtTen_Bophan.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".Ten_Bophan");
                this.lookUp_Bophan.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".Id_Bophan_Ql");
                this.lookUp_LoaiBP.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".Id_Loai_Bophan");
                this.lookUp_PTHuongLuong.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".Id_Phuongthuc_Huongluong");
                this.chkChunhat.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ChuNhat");
                this.chkThuhai.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuHai");
                this.chkThuba.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuBa");
                this.chkThutu.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuTu");
                this.chkThunam.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuNam");
                this.chkThusau.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuSau");
                this.chkThubay.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuBay");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            this.dgrex_Dm_Bophan.Enabled = !editTable;
            this.txtMa_Bophan.Properties.ReadOnly = !editTable;
            this.txtTen_Bophan.Properties.ReadOnly = !editTable;
            lookUp_Bophan.Properties.ReadOnly = !editTable;
            lookUp_LoaiBP.Properties.ReadOnly = !editTable;
            lookUp_PTHuongLuong.Properties.ReadOnly = !editTable;
            chkChunhat.Enabled = editTable;
            chkThuba.Enabled = editTable;
            chkThubay.Enabled = editTable;
            chkThuhai.Enabled = editTable;
            chkThunam.Enabled = editTable;
            chkThusau.Enabled = editTable;
            chkThutu.Enabled = editTable;
            //bandedGridView1.OptionsBehavior.Editable = !editTable;
            treeList_Bophan.Enabled = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Bophan.EditValue = "";
            this.txtMa_Bophan.EditValue = "";
            this.txtTen_Bophan.EditValue = "";
            this.lookUp_Bophan.EditValue = null;
            this.lookUp_LoaiBP.EditValue = null;
            this.lookUp_PTHuongLuong.EditValue = null;
        }

        private void Frmrex_Dm_Bophan_Add_Load(object sender, EventArgs e)
        {
            //this.DisplayInfo();
        }

        //public void setBophan_By_Quytrinhsx(object Id_Congviec)
        //{
        //    DataSet ds_Bophan_ByCongviec;
        //    if (Id_Congviec != null)
        //        ds_Bophan_ByCongviec = objPro.GetAll_Pro_Botri_Sx_By_Congviec(Id_Congviec, DateTime.Now);
        //    else
        //        ds_Bophan_ByCongviec = ds_Bophan.Clone();
        //    treeListColumn1.TreeList.DataSource = ds_Bophan_ByCongviec.Tables[0];
        //    dgrex_Dm_Bophan.DataSource = ds_Bophan_ByCongviec;
        //    dgrex_Dm_Bophan.DataMember = ds_Bophan_ByCongviec.Tables[0].TableName;

        //    lookUp_Bophan.Properties.DataSource = ds_Bophan.Tables[0];
        //    lookUp_LoaiBP.Properties.DataSource = ds_Loai_Bophan.Tables[0];
        //    lookUp_PTHuongLuong.Properties.DataSource = ds_PT_Huongluong.Tables[0];
        //}

        #region Event Override
        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.MasterService.Rex_Dm_Bophan objRex_Dm_Bophan = new Ecm.WebReferences.MasterService.Rex_Dm_Bophan();
                objRex_Dm_Bophan.Id_Bophan = -1;
                objRex_Dm_Bophan.Ma_Bophan = txtMa_Bophan.EditValue;
                objRex_Dm_Bophan.Ten_Bophan = txtTen_Bophan.EditValue;

                if ("" + lookUp_Bophan.EditValue != "")
                    objRex_Dm_Bophan.Id_Bophan_Ql = lookUp_Bophan.EditValue;

                if ("" + lookUp_LoaiBP.EditValue != "")
                    objRex_Dm_Bophan.Id_Loai_Bophan = lookUp_LoaiBP.EditValue;

                if ("" + lookUp_PTHuongLuong.EditValue != "")
                    objRex_Dm_Bophan.Id_Phuongthuc_Huongluong = lookUp_PTHuongLuong.EditValue;

                objRex_Dm_Bophan.ThuHai = (chkThuhai.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ThuBa = (chkThuba.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ThuTu = (chkThutu.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ThuNam = (chkThunam.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ThuSau = (chkThusau.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ThuBay = (chkThubay.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ChuNhat = (chkChunhat.Checked) ? 1 : 0;

                objMasterService.Insert_Rex_Dm_Bophan(objRex_Dm_Bophan);
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Bophan.Text, lblMa_Bophan.Text });
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.MasterService.Rex_Dm_Bophan objRex_Dm_Bophan = new Ecm.WebReferences.MasterService.Rex_Dm_Bophan();
                objRex_Dm_Bophan.Id_Bophan = bandedGridView1.GetFocusedRowCellValue("Id_Bophan");
                objRex_Dm_Bophan.Ma_Bophan = txtMa_Bophan.EditValue;
                objRex_Dm_Bophan.Ten_Bophan = txtTen_Bophan.EditValue;

                if ("" + lookUp_Bophan.EditValue != "")
                    objRex_Dm_Bophan.Id_Bophan_Ql = lookUp_Bophan.EditValue;

                if ("" + lookUp_LoaiBP.EditValue != "")
                    objRex_Dm_Bophan.Id_Loai_Bophan = lookUp_LoaiBP.EditValue;

                if ("" + lookUp_PTHuongLuong.EditValue != "")
                    objRex_Dm_Bophan.Id_Phuongthuc_Huongluong = lookUp_PTHuongLuong.EditValue;

                objRex_Dm_Bophan.ThuHai = (chkThuhai.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ThuBa = (chkThuba.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ThuTu = (chkThutu.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ThuNam = (chkThunam.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ThuSau = (chkThusau.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ThuBay = (chkThubay.Checked) ? 1 : 0;
                objRex_Dm_Bophan.ChuNhat = (chkChunhat.Checked) ? 1 : 0;

                objMasterService.Update_Rex_Dm_Bophan(objRex_Dm_Bophan);
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Bophan.Text, lblMa_Bophan.Text });
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Rex_Dm_Bophan objRex_Dm_Bophan = new Ecm.WebReferences.MasterService.Rex_Dm_Bophan();
            objRex_Dm_Bophan.Id_Bophan = bandedGridView1.GetFocusedRowCellValue("Id_Bophan");
            return objMasterService.Delete_Rex_Dm_Bophan(objRex_Dm_Bophan);
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
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Bophan, lblMa_Bophan.Text);
                hashtableControls.Add(txtTen_Bophan, lblTen_Bophan.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = Convert.ToBoolean(this.InsertObject());
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = Convert.ToBoolean(this.UpdateObject());
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
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Bophan.Text, lblMa_Bophan.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(bandedGridView1.Columns["Ma_Bophan"], "");
            hashtableControls.Add(bandedGridView1.Columns["Ten_Bophan"], "");
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, bandedGridView1))
                return false;
            try
            {
                //dgrex_Dm_Bophan.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                ds_Bophan.Tables[0].Columns["Ma_Bophan"].Unique = true;
                objMasterService.Update_Rex_Dm_Bophan_Collection(this.ds_Bophan);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Bophan.Text, lblMa_Bophan.Text });
                    return false;
                }
                //MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("SYS_CONFIRM_BFDELETE", new string[]  {"bộ phận" }) == DialogResult.Yes)
            {
                try
                {
                    if ("" + this.bandedGridView1.GetFocusedRowCellValue("Id_Bophan") != "")
                        if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Bophan", "Id_Bophan", this.bandedGridView1.GetFocusedRowCellValue("Id_Bophan"))) > 0)
                        {
                            GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { this.Text.ToLower() });
                            return true;
                        }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { this.Text.ToLower() });
                    //GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            _SelectedObject = new Ecm.WebReferences.MasterService.Rex_Dm_Bophan();
            try
            {
                int focusedRow = bandedGridView1.GetDataSourceRowIndex(bandedGridView1.FocusedRowHandle);
                DataRow dr = ds_Bophan.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    _SelectedObject.Id_Bophan = dr["Id_Bophan"];
                    _SelectedObject.Ma_Bophan = dr["Ma_Bophan"];
                    _SelectedObject.Ten_Bophan = dr["Ten_Bophan"];
                    _SelectedObject.Id_Phuongthuc_Huongluong = dr["Id_Phuongthuc_Huongluong"];
                }
                this.Dispose();
                this.Close();
                return _SelectedObject;
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
            this.bandedGridView1.FocusedColumn = bandedGridView1.Columns["Ma_Bophan"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //this.dgrex_Dm_Bophan.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }

        private void dgrex_Dm_Bophan_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.bandedGridView1.GetFocusedRowCellValue("Id_Bophan") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Rex_Dm_Bophan", "Id_Bophan", this.bandedGridView1.GetFocusedRowCellValue("Id_Bophan"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        private void treeList_Bophan_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            focusNode = e.Node;
            //Id_Bophan = Convert.ToInt64("" + e.Node.GetValue("Id_Bophan"));
            this.DisplayInfo2();
        }

        private void bandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //TreeNode node = new TreeNode( treeList_Bophan.FocusedNode.SetValue("Id_Bophan", bandedGridView1.GetFocusedRowCellValue(bandedGridView1.Columns["Id_Bophan"]).ToString());
            DevExpress.XtraTreeList.Nodes.TreeListNode node = treeList_Bophan.FindNodeByFieldValue("Id_Bophan", bandedGridView1.GetFocusedRowCellValue(bandedGridView1.Columns["Id_Bophan"]));
            treeList_Bophan.SetFocusedNode(node);
        }

        private void txtMa_Bophan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

    }
}

