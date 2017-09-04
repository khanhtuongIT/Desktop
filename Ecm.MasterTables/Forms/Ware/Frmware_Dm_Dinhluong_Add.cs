using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Dinhluong_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet ds_Collection = new DataSet();
        object id_nhansu_current;

        public Frmware_Dm_Dinhluong_Add()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                DataSet ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                DataRow row = ds_Nhansu.Tables[0].NewRow();
                row["Id_Nhansu"] = -1;
                row["Ma_Nhansu"] = "All";
                row["Hoten_Nhansu"] = "Tất cả";
                ds_Nhansu.Tables[0].Rows.Add(row);
                LookupEdit_Nhansu.Properties.DataSource = ds_Nhansu.Tables[0];

                DataTable dtb = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet().Tables[0];
                gridLookUp_Nhom_Hanghoa_Ban.DataSource = dtb;
                gridLookupEdit_Ten_Nhomhang.DataSource = dtb;

                DataSet ds_Role = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
                if (ds_Role.Tables[0].Rows.Count > 0 &&
                    "" + ds_Role.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                {
                    LookupEdit_Nhansu.Properties.ReadOnly = false;
                    dtb = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
                    gridLookupEdit_MaKH.DataSource = dtb;
                    gridLookupEdit_TenKH.DataSource = dtb;
                }
                else
                {
                    LookupEdit_Nhansu.EditValue = Convert.ToInt64(id_nhansu_current);
                    LookupEdit_Nhansu.Properties.ReadOnly = true;

                    dtb = objMasterService.Ware_Dm_Khachhang_SelectById_Nhansu(LookupEdit_Nhansu.EditValue, null).ToDataSet().Tables[0];
                    gridLookupEdit_MaKH.DataSource = dtb;
                    gridLookupEdit_TenKH.DataSource = dtb;
                }
                this.gvChitiet.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                // GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgware_Dm_Loai_Hanghoa_Ban.Enabled = !editTable;
            gvChitiet.OptionsBehavior.Editable = !editTable;
        }

        #region Event Override

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            //dgware_Dm_Loai_Hanghoa_Ban.Enabled = false;
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            this.ChangeStatus(true);
            return base.PerformEdit();
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            return true;
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvChitiet.Columns["Id_Loai_Hanghoa_Ban"], "");
            hashtableControls.Add(gvChitiet.Columns["Id_Khachhang"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvChitiet))
                return false;

            try
            {
                objWareService.Ware_Dm_Dinhluong_Update_Collection(ds_Collection);
            }
            catch (Exception ex)
            {
                //if (ex.ToString().IndexOf("Unique") != -1)
                //{
                //     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Loai_Hanghoa_Ban.Text, lblMa_Loai_Hanghoa_Ban.Text.ToLower() });
                //}
                MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban ware_Dm_Loai_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Ware_Dm_Loai_Hanghoa_Ban();
            try
            {
                int focusedRow = gvChitiet.GetDataSourceRowIndex(gvChitiet.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Loai_Hanghoa_Ban.Id_Loai_Hanghoa_Ban = dr["Id_Loai_Hanghoa_Ban"];
                    ware_Dm_Loai_Hanghoa_Ban.Ma_Loai_Hanghoa_Ban = dr["Ma_Loai_Hanghoa_Ban"];
                    ware_Dm_Loai_Hanghoa_Ban.Ten_Loai_Hanghoa_Ban = dr["Ten_Loai_Hanghoa_Ban"];
                    ware_Dm_Loai_Hanghoa_Ban.Id_Nhom_Hanghoa_Ban = dr["Id_Nhom_Hanghoa_Ban"];
                }
                //SelectedWare_Dm_Loai_Hanghoa_Ban = ware_Dm_Loai_Hanghoa_Ban;
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void LookupEdit_Nhansu_EditValueChanged(object sender, EventArgs e)
        {
            ds_Collection = objWareService.Ware_Dm_Dinhluong_SelectById_Nhansu(LookupEdit_Nhansu.EditValue).ToDataSet();
            dgware_Dm_Loai_Hanghoa_Ban.DataSource = ds_Collection;
            dgware_Dm_Loai_Hanghoa_Ban.DataMember = ds_Collection.Tables[0].TableName;
            this.Data = ds_Collection;
            this.GridControl = dgware_Dm_Loai_Hanghoa_Ban;
        }

    }
}

