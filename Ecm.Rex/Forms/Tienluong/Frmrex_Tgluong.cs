using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Rex.Forms.Tienluong
{
    public partial class Frmrex_Tgluong : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public object _kyluong; // id kỳ lương hiện tại
        public object _id_nhansu; // id nhân sự hiện tại
        public object ma_nhansu;
        public object hoten_nhansu;

        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet ds_Tgluong = new DataSet();
        Ecm.WebReferences.RexService.Rex_Tgluong Selected_Rex_Tgluong;

        #region properties
        private bool haschange = false;
        public bool HasChange
        {
            get { return haschange; }
            set { haschange = value; }
        }
        #endregion

        public Frmrex_Tgluong()
        {
            InitializeComponent();

            // An 2 nut Them & Cap nhat & Xoa
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }


        private void dgrex_Dm_Chungchi_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {

        }

        private void gridLookUpEdit_Ndung_Tgluong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterService.dll", "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Ndung_Tgluong", this);
                if (dialog == null)
                    return;
                var SelectedObject = dialog.GetType().GetProperty("Selected_Rex_Dm_Ndung_Tgluong").GetValue(dialog, null)
                   as Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong;

                // Update database
                gridLookUpEdit_Ndung_Tgluong.DataSource = objMasterService.Get_All_Rex_Dm_Ndung_Tgluong_Collection().ToDataSet().Tables[0];

                // Selected id
                if ("" + SelectedObject != "")
                {
                    if ("" + SelectedObject.Id_Ndung_Tgluong != "")
                    {
                        //gvrex_Dm_Ndung_Tgluong.SetFocusedRowCellValue("Id_Ndung_Tgluong", frmrex_Dm_Ndung_Tgluong.Selected_Rex_Dm_Ndung_Tgluong.Id_Ndung_Tgluong);
                        gvrex_Tgluong.SetFocusedRowCellValue(gvrex_Tgluong.FocusedColumn, SelectedObject.Id_Ndung_Tgluong);
                    }
                    gvrex_Tgluong.FocusedColumn.BestFit();
                }
            }
        }

        public override void DisplayInfo()
        {
            try
            {
                lookUpEdit_Dm_Kyluong.EditValue = _kyluong;
                txtMa_Nhansu.EditValue = ma_nhansu;
                txtHoten_Nhansu.EditValue = hoten_nhansu;

                gridLookUpEdit_Ndung_Tgluong.DataSource = objMasterService.Get_All_Rex_Dm_Ndung_Tgluong_Collection().ToDataSet().Tables[0];
                lookUpEdit_Dm_Kyluong.Properties.DataSource = objRexService.Get_All_Rex_Kyluong_Collection().ToDataSet().Tables[0];
                gridLookUpEdit_Ma_Nhansu.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];

                // Select by Id_Kyluong & Id_Nhansu
                Ecm.WebReferences.RexService.Rex_Tgluong tgluong = new Ecm.WebReferences.RexService.Rex_Tgluong();
                tgluong.Id_Kyluong = _kyluong;
                tgluong.Id_Nhansu = _id_nhansu;
                ds_Tgluong = objRexService.Rex_Tgluong_Select_By_Id_Kyluong_Nhansu(tgluong).ToDataSet();
                ds_Tgluong.Tables[0].Columns["Nhom_Ndung_Tgluong"].AllowDBNull = true;
                ds_Tgluong.Tables[0].Columns["Id_Ndung_Tgluong"].ReadOnly = false;
                ds_Tgluong.Tables[0].Columns["Sotien"].ReadOnly = false;

                dgrex_Tgluong.DataSource = ds_Tgluong;
                dgrex_Tgluong.DataMember = ds_Tgluong.Tables[0].TableName;

                Data = ds_Tgluong;
                GridControl = dgrex_Tgluong;
                
                gvrex_Tgluong.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        

        #region Event Override
        public object InsertObject()
        {
            Ecm.WebReferences.RexService.Rex_Tgluong objRex_Tgluong = new Ecm.WebReferences.RexService.Rex_Tgluong();
            //objRex_Tgluong.Id_Tgluong = -1;
            objRex_Tgluong.Id_Nhansu = _id_nhansu;
            objRex_Tgluong.Id_Ndung_Tgluong = gvrex_Tgluong.GetFocusedRowCellValue("Id_Ndung_Tgluong");
            objRex_Tgluong.Id_Kyluong = _kyluong;
            objRex_Tgluong.Sotien = gvrex_Tgluong.GetFocusedRowCellValue("Sotien");

            objRexService.Insert_Rex_Tgluong(objRex_Tgluong);
            return true;
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.RexService.Rex_Tgluong objRex_Tgluong = new Ecm.WebReferences.RexService.Rex_Tgluong();
            objRex_Tgluong.Id_Tgluong = gvrex_Tgluong.GetFocusedRowCellValue("Id_Tgluong");
            objRex_Tgluong.Id_Nhansu = _id_nhansu;
            objRex_Tgluong.Id_Ndung_Tgluong = gvrex_Tgluong.GetFocusedRowCellValue("Id_Ndung_Tgluong");
            objRex_Tgluong.Id_Kyluong = _kyluong;
            objRex_Tgluong.Sotien = gvrex_Tgluong.GetFocusedRowCellValue("Sotien");

            objRexService.Update_Rex_Tgluong(objRex_Tgluong);
            return true;
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.RexService.Rex_Tgluong objRex_Tgluong = new Ecm.WebReferences.RexService.Rex_Tgluong();
            objRex_Tgluong.Id_Tgluong = gvrex_Tgluong.GetFocusedRowCellValue("Id_Tgluong");

            objRexService.Delete_Rex_Tgluong(objRex_Tgluong);
            return true;
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            ChangeStatus(true);
            ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            DisplayInfo();
            ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                if (_id_nhansu + "" == "" || _kyluong + "" == "") return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = Convert.ToBoolean(InsertObject());
                }
                else if (FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = Convert.ToBoolean(UpdateObject());
                }

                if (success)
                {
                    DisplayInfo();
                    haschange = true;
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    //GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Ndung_Tgluong.Text, lblNdung_Tgluong.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvrex_Tgluong.Columns["Id_Ndung_Tgluong"], "");
            hashtableControls.Add(gvrex_Tgluong.Columns["Sotien"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvrex_Tgluong))
                return false;

            try
            {
                dgrex_Tgluong.EmbeddedNavigator.Buttons.DoClick(dgrex_Tgluong.EmbeddedNavigator.Buttons.EndEdit);
                ds_Tgluong.Tables[0].Columns["Id_Ndung_Tgluong"].Unique = true;
                //ds_Tgluong.Tables[0].Columns["Id_Nhansu"].Unique = true;
                //ds_Tgluong.Tables[0].Columns["Id_Kyluong"].Unique = true;

                objRexService.Update_Rex_Tgluong_Collection(ds_Tgluong);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { "Nội dung", "" });
                    return false;
                }
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            DisplayInfo();
            haschange = true;
            return true;
        }

        //        public override bool PerformDelete()
        //        {
        //            if (GoobizFrame.Windows.Forms.UserMessage.Show("SYS_CONFIRM_BFDELETE", new string[]  {
        //            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Dm_Ndung_Tgluong"),
        //            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Dm_Ndung_Tgluong")   }) == DialogResult.Yes)
        //            {
        //                try
        //                {
        //                    if (Convert.ToInt32(objRexService.GetExistReferences("Rex_Dm_Ndung_Tgluong", "Id_Ndung_Tgluong", this.gvrex_Dm_Ndung_Tgluong.GetFocusedRowCellValue("Id_Ndung_Tgluong"))) > 0)
        //                    {
        //                        GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { Text.ToLower() });
        //                        return true;
        //                    }
        //                    this.DeleteObject();
        //                }
        //                catch
        //                {
        //                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { this.Text.ToLower() });

        //                }
        //                DisplayInfo();
        //            }
        //            return base.PerformDelete();
        //        }

        //        public override object PerformSelectOneObject()
        //        {
        //            Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong Rex_Dm_Ndung_Tgluong = new Ecm.WebReferences.MasterService.Rex_Dm_Ndung_Tgluong();
        //            try
        //            {
        //                int focusedRow = gvrex_Dm_Ndung_Tgluong.GetDataSourceRowIndex(gvrex_Dm_Ndung_Tgluong.FocusedRowHandle);
        //                DataRow dr = ds_Tgluong.Tables[0].Rows[focusedRow];
        //                if (dr != null)
        //                {
        //                    Rex_Dm_Ndung_Tgluong.Id_Ndung_Tgluong = dr["Id_Ndung_Tgluong"];
        //                    Rex_Dm_Ndung_Tgluong.Ma_Ndung_Tgluong = dr["Ma_Ndung_Tgluong"];
        //                    Rex_Dm_Ndung_Tgluong.Noidung = dr["Noidung"];
        //                    Rex_Dm_Ndung_Tgluong.Pb_Tangluong = dr["Pb_Tangluong"];
        //                    Rex_Dm_Ndung_Tgluong.Pb_Thue_Tncn = dr["Pb_Thue_Tncn"];
        //                }
        //                Selected_Rex_Dm_Ndung_Tgluong = Rex_Dm_Ndung_Tgluong;
        //                Dispose();
        //                Close();
        //                return Rex_Dm_Ndung_Tgluong;
        //            }
        //            catch (Exception ex)
        //            {
        //#if DEBUG
        //                MessageBox.Show(ex.Message);
        //#endif
        //                return null;
        //            }
        //        }
        #endregion

        //        private void dgrex_Dm_Ndung_Tgluong_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        //        {
        //            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
        //            {
        //                if (Convert.ToInt32(objRexService.GetExistReferences("Rex_Dm_Ndung_Tgluong", "Id_Ndung_Tgluong", this.gvrex_Dm_Ndung_Tgluong.GetFocusedRowCellValue("Id_Ndung_Tgluong"))) > 0)
        //                {
        //                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { this.Text.ToLower() });
        //                    e.Handled = true;
        //                }
        //            }
        //        }        

        //        private void gvrex_Dm_Ndung_Tgluong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //        {
        //            dgrex_Dm_Ndung_Tgluong.EmbeddedNavigator.Buttons.DoClick(dgrex_Dm_Ndung_Tgluong.EmbeddedNavigator.Buttons.EndEdit);
        //        }

        //        private void gvrex_Dm_Ndung_Tgluong_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //        {
        //            gvrex_Dm_Ndung_Tgluong.FocusedColumn = gvrex_Dm_Ndung_Tgluong.Columns["Ma_Ndung_Tgluong"];
        //            addnewrow_clicked = true;
        //        }

        private void txtMa_Ndung_Tgluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

        private void Frmrex_Tgluong_Load(object sender, EventArgs e)
        {
            DisplayInfo();
            item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void gvrex_Dm_Ndung_Tgluong_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvrex_Tgluong.SetFocusedRowCellValue("Id_Nhansu", _id_nhansu);
            gvrex_Tgluong.SetFocusedRowCellValue("Id_Kyluong", _kyluong);
            gvrex_Tgluong.SetFocusedRowCellValue("Nhom_Ndung_Tgluong", "+/-");
        }

     

        private void gvrex_Tgluong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.DoClickEndEdit(dgrex_Tgluong);
        }

     
    }
}