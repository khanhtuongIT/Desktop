using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Accounting
{
    public partial class Frmacc_Dm_Nganhang_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterTables = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.MasterService.Acc_Dm_Nganhang Acc_Dm_Nganhang = new Ecm.WebReferences.MasterService.Acc_Dm_Nganhang();
        DataSet dsNganhang = new DataSet();

        public Frmacc_Dm_Nganhang_Add()
        {
            InitializeComponent();
            //this.SetCultureInfo(); //use  MdiUtils.CultureInfoHelper.SetupFormCultureInfo(this);
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public void SetCultureInfo()
        {
            //System.Collections.ArrayList controls = new System.Collections.ArrayList();
            //controls.Add(this);
            //controls.Add(lblId_Nganhang);
            //controls.Add(lblMa_Nganhang);
            //controls.Add(lblTen_Nganhang);
            //controls.Add(lblDiachi);
            //controls.Add(lblDienthoai);
            //controls.Add(gridColumn1);
            //controls.Add(gridColumn2);
            //controls.Add(gridColumn3);
            //controls.Add(gridColumn4);
            //controls.Add(gridColumn5);
            //GoobizFrame.Windows.CultureInfo.CultureInfoHelper.SetupFormCultureInfo(this, controls);
            //GoobizFrame.Windows.CultureInfo.CultureInfoHelper.SetupEmbeddedNavigatorCultureInfo(this, dgacc_Dm_Nganhang);
        }

        private void Frmacc_Dm_Nganhang_Add_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
            this.ChangeStatus(true);
        }

        public override void DisplayInfo()
        {
            try
            {
                dsNganhang = objMasterTables.Get_Acc_Dm_Nganhang_Collection3().ToDataSet();
                dgacc_Dm_Nganhang.DataSource = dsNganhang;
                dgacc_Dm_Nganhang.DataMember = dsNganhang.Tables[0].TableName;                               

                this.Data = dsNganhang;
                this.GridControl = dgacc_Dm_Nganhang;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                #if DEBUG //Hiển thị thông báo lổi niếu ở chế độ Debug
                MessageBox.Show(ex.ToString());
                #endif
                GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

            try
            {
                txtId_Nganhang.DataBindings.Clear();
                txtMa_Nganhang.DataBindings.Clear();
                txtTen_Nganhang.DataBindings.Clear();
                txtDiachi.DataBindings.Clear();
                txtDienthoai.DataBindings.Clear();
                if (dsNganhang.Tables[0].Rows.Count > 0)
                {
                    txtId_Nganhang.DataBindings.Add("Text", dsNganhang, dsNganhang.Tables[0].TableName + ".Id_Nganhang");
                    txtMa_Nganhang.DataBindings.Add("Text", dsNganhang, dsNganhang.Tables[0].TableName + ".Ma_Nganhang");
                    txtTen_Nganhang.DataBindings.Add("Text", dsNganhang, dsNganhang.Tables[0].TableName + ".Ten_Nganhang");
                    txtDiachi.DataBindings.Add("Text", dsNganhang, dsNganhang.Tables[0].TableName + ".Diachi");
                    txtDienthoai.DataBindings.Add("Text", dsNganhang, dsNganhang.Tables[0].TableName + ".Dienthoai");
                }
            }
            catch (Exception ex)
            {
                #if DEBUG  //Hiển thị thông báo lổi niếu ở chế độ Debug
                MessageBox.Show(ex.ToString());
                #endif
            }
        }

        #region event override
        public override void ChangeStatus(bool editable)
        {
            this.dgacc_Dm_Nganhang.Enabled = editable;
            txtDiachi.Properties.ReadOnly = editable;
            txtDienthoai.Properties.ReadOnly = editable;
            txtMa_Nganhang.Properties.ReadOnly = editable;
            txtTen_Nganhang.Properties.ReadOnly = editable;
        }
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Acc_Dm_Nganhang acc_Dm_Nganhang = new Ecm.WebReferences.MasterService.Acc_Dm_Nganhang();
            acc_Dm_Nganhang.Ma_Nganhang = txtMa_Nganhang.Text;
            acc_Dm_Nganhang.Ten_Nganhang = txtTen_Nganhang.Text;
            acc_Dm_Nganhang.Diachi = txtDiachi.Text;
            acc_Dm_Nganhang.Dienthoai = txtDienthoai.Text;
            return objMasterTables.Insert_Acc_Dm_Nganhang(acc_Dm_Nganhang);
        }
        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Acc_Dm_Nganhang acc_Dm_Nganhang = new Ecm.WebReferences.MasterService.Acc_Dm_Nganhang();
            acc_Dm_Nganhang.Id_Nganhang = txtId_Nganhang.Text;
            acc_Dm_Nganhang.Ma_Nganhang = txtMa_Nganhang.Text;
            acc_Dm_Nganhang.Ten_Nganhang = txtTen_Nganhang.Text;
            acc_Dm_Nganhang.Diachi = txtDiachi.Text;
            acc_Dm_Nganhang.Dienthoai = txtDienthoai.Text;
            return objMasterTables.Update_Acc_Dm_Nganhang(acc_Dm_Nganhang);
        }
        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Acc_Dm_Nganhang acc_Dm_Nganhang = new Ecm.WebReferences.MasterService.Acc_Dm_Nganhang();
            acc_Dm_Nganhang.Id_Nganhang = txtId_Nganhang.Text;
            return objMasterTables.Delete_Acc_Dm_Nganhang(acc_Dm_Nganhang);
        }

        public override bool PerformAdd()
        {
            this.ChangeStatus(false);
            txtId_Nganhang.Text = "";
            txtMa_Nganhang.Text = "";
            txtTen_Nganhang.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
            return true;
        }

        public override bool PerformEdit()
        {
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformSave()
        {
            bool saved = false;
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(txtMa_Nganhang, lblMa_Nganhang.Text);
            hashtableControls.Add(txtTen_Nganhang, lblTen_Nganhang.Text);
            hashtableControls.Add(txtDiachi, lblDiachi.Text);
            hashtableControls.Add(txtDienthoai, lblDienthoai.Text);

            System.Collections.Hashtable htb_Ma_Nganhang = new System.Collections.Hashtable();
            htb_Ma_Nganhang.Add(txtMa_Nganhang, lblMa_Nganhang.Text);

            System.Collections.Hashtable htb_Ten_Nganhang = new System.Collections.Hashtable();
            htb_Ten_Nganhang.Add(txtTen_Nganhang, lblTen_Nganhang.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;
            if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
            {
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Ma_Nganhang, (DataSet)dgacc_Dm_Nganhang.DataSource, "Ma_Nganhang"))
                    return false;
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Ten_Nganhang, (DataSet)dgacc_Dm_Nganhang.DataSource, "Ten_Nganhang"))
                    return false;
                this.InsertObject();
                saved = true;
            }
            else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
            {
                DataSet _ds = GoobizFrame.Windows.MdiUtils.Validator.datasetFillter((DataSet)dgacc_Dm_Nganhang.DataSource, "Id_Nganhang = " + txtId_Nganhang.Text);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Ma_Nganhang, _ds, "Ma_Nganhang"))
                    return false;
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htb_Ten_Nganhang, _ds, "Ten_Nganhang"))
                    return false;
                this.UpdateObject();
                saved = true;
            }
            if (saved)
            {
                this.DisplayInfo();
                this.ChangeStatus(true);
            }
            return saved;
        }
        public override bool PerformSaveChanges()
        {
            this.DoClickEndEdit(dgacc_Dm_Nganhang);// dgacc_Dm_Nganhang.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Nganhang"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Nganhang"], "");
            //hashtableControls.Add(gridView1.Columns["Diachi"], "");
            //hashtableControls.Add(gridView1.Columns["Dienthoai"], "");

            System.Collections.Hashtable htb_Ma_Nganhang = new System.Collections.Hashtable();
            htb_Ma_Nganhang.Add(gridView1.Columns["Ma_Nganhang"], "");

            System.Collections.Hashtable htb_Ten_Nganhang = new System.Collections.Hashtable();
            htb_Ten_Nganhang.Add(gridView1.Columns["Ten_Nganhang"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htb_Ma_Nganhang, gridView1))
                return false;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htb_Ten_Nganhang, gridView1))
                return false;
            try
            {                
                objMasterTables.Update_Acc_Dm_Nganhang_Collection(dsNganhang);
            }
            catch (Exception ex)
            {
                #if DEBUG //Hiển thị lổi niếu ở chế độ Debug
                MessageBox.Show(ex.Message);
                #endif
                GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "ngân hàng");
            }
            this.DisplayInfo();
            return true;
        }
        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("SYS_CONFIRM_BFDELETE", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Acc_Dm_Nganhang"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Acc_Dm_Nganhang")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    #if DEBUG //Hiển thị lổi niếu ở chế độ Debug
                    MessageBox.Show(ex.ToString());
                    #endif
                    GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "ngân hàng");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }
        public override object PerformSelectOneObject()
        {
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = dsNganhang.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    Acc_Dm_Nganhang.Id_Nganhang = dr["Id_Nganhang"];
                    Acc_Dm_Nganhang.Ma_Nganhang = dr["Ma_Nganhang"];
                    Acc_Dm_Nganhang.Ten_Nganhang = dr["Ten_Nganhang"];
                    Acc_Dm_Nganhang.Diachi = dr["Diachi"];
                    Acc_Dm_Nganhang.Dienthoai = dr["Dienthoai"];
                }
                this.Dispose();
                this.Close();
                return Acc_Dm_Nganhang;
            }
            catch (Exception ex)
            {
                #if DEBUG //Hiển thị lổi niếu ở chế độ Debug
                MessageBox.Show(ex.ToString());
                #endif
                return null;
            }
        }
        #endregion

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.DoClickEndEdit(dgacc_Dm_Nganhang);//this.dgacc_Dm_Nganhang.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }

        private void dgacc_Dm_Nganhang_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {
                this.gridView1.FocusedColumn = gridView1.Columns["Ma_Nganhang"];
                this.addnewrow_clicked = true;
            }
        }

  
    }
}


