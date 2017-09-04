using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Rex.Forms
{
    // =============================================
    // Author:		Phuongphan
    // Create date: 24/02/2011
    // Description:	Xếp thự tự nhân sự theo vị trí trong phân xưởng
    // =============================================
    public partial class Frmrex_Nhansu_Roll : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Nhansu_Roll = new DataSet();

        public Frmrex_Nhansu_Roll()
        {
            InitializeComponent();

            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            DataSet dsDm_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
            gridLookUpEdit_Bophan.DataSource = dsDm_Bophan.Tables[0];
            lookUpEdit_Nhansu.Properties.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];
            setData_On_Grid();
            base.DisplayInfo();
        }

        public override bool PerformSave()
        {
            try
            {
                if (lookUpEdit_Nhansu.EditValue == null)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn Nhân sự, vui lòng chọn lại Nhân sự");
                    lookUpEdit_Nhansu.Focus();
                    return false;
                }
                if (!check_Ma_Nhansu_Sx())
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa nhập vị trí, vui lòng nhập lại vị trí");
                    return false;
                }

                Ecm.WebReferences.RexService.Rex_Nhansu rex_nhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();
                rex_nhansu.Id_Nhansu = lookUpEdit_Nhansu.EditValue;
                rex_nhansu.Ma_Nhansu_Sx = txtMa_Nhansu_Sx.EditValue;
                objRexService.Update_Rex_Nhansu_Ma_Sx(rex_nhansu);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void lookUpEdit_Nhansu_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_Nhansu.EditValue == null)
            {
                txtMa_Nhansu_Sx.Properties.ReadOnly = true;
                btnUpdate.Enabled = false;
                txtHo_Nhansu.Text = "";
                txtTen_Nhansu.Text = "";
            }
            else
            {
                txtMa_Nhansu_Sx.Properties.ReadOnly = false;
                btnUpdate.Enabled = this.EnableEdit;

                txtHo_Nhansu.Text = "" + lookUpEdit_Nhansu.GetColumnValue("Ho_Nhansu");
                txtTen_Nhansu.Text = "" + lookUpEdit_Nhansu.GetColumnValue("Ten_Nhansu");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.PerformSave())
            {
                setData_On_Grid();
                txtMa_Nhansu_Sx.Text = "";
                lookUpEdit_Nhansu.EditValue = null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Frmrex_Nhansu_Search _Frmrex_Nhansu_Search = new Frmrex_Nhansu_Search();
            _Frmrex_Nhansu_Search.ShowDialog();

            if (_Frmrex_Nhansu_Search.dtnhansu != null)
            {
                lookUpEdit_Nhansu.EditValue = _Frmrex_Nhansu_Search.dtnhansu["Id_Nhansu"];
            }

        }

        private void txtVitri1_EditValueChanged(object sender, EventArgs e)
        {
            setData_On_Grid();
        }

        private void txtVitri2_EditValueChanged(object sender, EventArgs e)
        {
            setData_On_Grid();
        }

        void setData_On_Grid()
        {
            if (txtVitri2.Text != "" && txtVitri1.Text != "")
            {
                ds_Nhansu_Roll = objRexService.Get_Rex_Nhansu_Co_Ma_Sx(txtVitri1.EditValue, txtVitri2.EditValue).ToDataSet();
                ds_Nhansu_Roll.Tables[0].Columns.Add("Chon", typeof(bool));
                dgrex_Nhansu.DataSource = ds_Nhansu_Roll.Tables[0];
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Ecm.WebReferences.RexService.Rex_Nhansu rex_nhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();
            if (dgrex_Nhansu.DataSource == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn thông tin nhân sự để xóa");
                return;
            }
            bool check = false;
            foreach (DataRow row in ds_Nhansu_Roll.Tables[0].Rows)
            {
                if (row["Chon"].ToString() == "True")
                {
                    rex_nhansu.Id_Nhansu = row["Id_Nhansu"];
                    objRexService.Update_Rex_Nhansu_Ma_Sx_To_Null(rex_nhansu);
                    check = true;
                }
            }
            if (check == false)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn thông tin Nhân sự để xóa");
                return;
            }
            this.DisplayInfo();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgrex_Nhansu.DataSource == null && chkAll.Checked == true)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn vị trí hiển thị thông tin Nhân sư");
                chkAll.Checked = false;
                return;
            }
            else
            {
                if (dgrex_Nhansu.DataSource != null)
                    if (chkAll.Checked)
                    {
                        foreach (DataRow row in ds_Nhansu_Roll.Tables[0].Rows)
                        {
                            row["Chon"] = true;
                        }
                    }
                    else
                    {
                        foreach (DataRow row in ds_Nhansu_Roll.Tables[0].Rows)
                        {
                            row["Chon"] = false;
                        }
                    }
            }
        }

        private void txtMa_Nhansu_Sx_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMa_Nhansu_Sx.Text != "" && txtVitri2.Text != "" && txtVitri1.Text != "")
                check_Ma_Nhansu_Sx();
        }

        private bool check_Ma_Nhansu_Sx()
        {
            if (txtMa_Nhansu_Sx.Text == "" || txtVitri1.Text == "" || txtVitri2.Text == "")
                return false;
            if (Convert.ToInt32(txtMa_Nhansu_Sx.Text) < Convert.ToInt32(txtVitri1.EditValue)
                || Convert.ToInt32(txtMa_Nhansu_Sx.Text) > Convert.ToInt32(txtVitri2.EditValue))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Mã vị trí nhập không đúng. \n Mã vị trí phải nhập trong khoảng vị trí ở trên");
                txtMa_Nhansu_Sx.Focus();
                return false;
            }
            else
                return true;
        }

    }
}