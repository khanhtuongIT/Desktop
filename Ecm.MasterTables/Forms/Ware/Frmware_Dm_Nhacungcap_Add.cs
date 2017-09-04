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
    public partial class Frmware_Dm_Nhacungcap_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.MasterService.Ware_Dm_Nhacungcap SeletedWare_Dm_Nhacungcap;
        DataSet ds_Collection = new DataSet();

        public Frmware_Dm_Nhacungcap_Add()
        {
            InitializeComponent();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Collection = objMasterService.Get_All_Ware_Dm_Nhacungcap().ToDataSet();
                dgware_Dm_Nhacungcap.DataSource = ds_Collection;
                dgware_Dm_Nhacungcap.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Nhacungcap;

                this.ChangeStatus(false);
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        #region Event Override
        //public object InsertObject()
        //{
        //    Ecm.WebReferences.MasterService.Ware_Dm_Nhacungcap objWare_Dm_Nhacungcap = new Ecm.WebReferences.MasterService.Ware_Dm_Nhacungcap();
        //    objWare_Dm_Nhacungcap.Id_Nhacungcap = -1;
        //    objWare_Dm_Nhacungcap.Ma_Nhacungcap = txtMa_Nhacungcap.EditValue;
        //    objWare_Dm_Nhacungcap.Ten_Nhacungcap = txtTen_Nhacungcap.EditValue;
        //    objWare_Dm_Nhacungcap.Diachi_Nhacungcap = txtDiachi_Nhacungcap.EditValue;
        //    objWare_Dm_Nhacungcap.Masothue = txtMasothue.EditValue;
        //    objWare_Dm_Nhacungcap.Dienthoai = txtDienthoai.EditValue;
        //    objWare_Dm_Nhacungcap.Fax = txtFax.EditValue;
        //    objWare_Dm_Nhacungcap.Email = txtEmail.EditValue;
        //    objWare_Dm_Nhacungcap.Website = txtWebsite.EditValue;

        //    return objMasterService.Insert_Ware_Dm_Nhacungcap(objWare_Dm_Nhacungcap);
        //}

        //public object UpdateObject()
        //{
        //    Ecm.WebReferences.MasterService.Ware_Dm_Nhacungcap objWare_Dm_Nhacungcap = new Ecm.WebReferences.MasterService.Ware_Dm_Nhacungcap();
        //    objWare_Dm_Nhacungcap.Id_Nhacungcap = gridView1.GetFocusedRowCellValue("Id_Nhacungcap");
        //    objWare_Dm_Nhacungcap.Ma_Nhacungcap = txtMa_Nhacungcap.EditValue;
        //    objWare_Dm_Nhacungcap.Ten_Nhacungcap = txtTen_Nhacungcap.EditValue;
        //    objWare_Dm_Nhacungcap.Diachi_Nhacungcap = txtDiachi_Nhacungcap.EditValue;
        //    objWare_Dm_Nhacungcap.Masothue = txtMasothue.EditValue;
        //    objWare_Dm_Nhacungcap.Dienthoai = txtDienthoai.EditValue;
        //    objWare_Dm_Nhacungcap.Fax = txtFax.EditValue;
        //    objWare_Dm_Nhacungcap.Email = txtEmail.EditValue;
        //    objWare_Dm_Nhacungcap.Website = txtWebsite.EditValue;

        //    return objMasterService.Update_Ware_Dm_Nhacungcap(objWare_Dm_Nhacungcap);
        //}

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nhacungcap objWare_Dm_Nhacungcap = new Ecm.WebReferences.MasterService.Ware_Dm_Nhacungcap();
            objWare_Dm_Nhacungcap.Id_Nhacungcap = gridView1.GetFocusedRowCellValue("Id_Nhacungcap");
            return objMasterService.Delete_Ware_Dm_Nhacungcap(objWare_Dm_Nhacungcap);
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Nhacungcap"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Nhacungcap"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Nhacungcap"].Unique = true;
                //ds_Collection.Tables[0].Columns["Masothue"].Unique = true;
                objMasterService.Update_Ware_Dm_Nhacungcap_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1 && ex.ToString().IndexOf("Ma_Nhacungcap") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { gridColumn2.Caption, gridColumn2.Caption.ToLower() });
                    return false;
                }
            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Nhacungcap ware_Dm_Nhacungcap = new Ecm.WebReferences.MasterService.Ware_Dm_Nhacungcap();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Nhacungcap.Id_Nhacungcap = dr["Id_Nhacungcap"];
                    ware_Dm_Nhacungcap.Ma_Nhacungcap = dr["Ma_Nhacungcap"];
                    ware_Dm_Nhacungcap.Ten_Nhacungcap = dr["Ten_Nhacungcap"];
                    ware_Dm_Nhacungcap.Diachi_Nhacungcap = dr["Diachi_Nhacungcap"];
                    ware_Dm_Nhacungcap.Masothue = dr["Masothue"];
                    ware_Dm_Nhacungcap.Dienthoai = dr["Dienthoai"];
                    ware_Dm_Nhacungcap.Fax = dr["Fax"];
                    ware_Dm_Nhacungcap.Email = dr["Email"];
                    ware_Dm_Nhacungcap.Website = dr["Website"];
                }
                SeletedWare_Dm_Nhacungcap = ware_Dm_Nhacungcap;
                this.Dispose();
                this.Close();
                return ware_Dm_Nhacungcap;
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
            this.dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Nhacungcap.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Nhacungcap_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Nhacungcap", "Id_Nhacungcap", this.gridView1.GetFocusedRowCellValue("Id_Nhacungcap"))) > 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Nhacungcap"];
            this.addnewrow_clicked = true;
        }

    }
}

