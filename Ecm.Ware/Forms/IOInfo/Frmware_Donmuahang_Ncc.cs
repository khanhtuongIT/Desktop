using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Donmuahang_Ncc :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public DataSet ds_Donmuahang_Chitiet_Ncc = new DataSet();
        public DataRow[] SelectedRow = null;
        public object guid;

        #region Properties

        object id_donmuahang_chitiet;
        public object Id_Donmuahang_Chitiet
        {
            get { return id_donmuahang_chitiet; }
            set
            {
                id_donmuahang_chitiet = value;
                DisplayInfo();
            }
        }

        object id_hanghoa_mua;
        public object Id_Hanghoa_Ban
        {
            get { return id_hanghoa_mua; }
            set
            {
                id_hanghoa_mua = value;
                lookUpEdit_Hanghoa_Ban.EditValue = id_hanghoa_mua;
            }
        }

        public object Guid
        {
            get { return guid; }
            set
            {
                this.guid = value;
                DisplayInfo();
                this.xtraHNavigator1.Enabled = false;
            }
        }
        #endregion

        public Frmware_Donmuahang_Ncc()
        {
            InitializeComponent();
        }

        #region Event Override

        public override void ChangeStatus(bool editTable)
        {
            this.gridColumn2.OptionsColumn.ReadOnly = !editTable;
            this.gridColumn9.OptionsColumn.ReadOnly = !editTable;
            this.gridColumn13.OptionsColumn.ReadOnly = !editTable;
        }


        public override void DisplayInfo()
        {
            //lookUpEdit_Hanghoa_Ban
            lookUpEdit_Hanghoa_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet().Tables[0];
            
            //Get data Ware_Dm_Nhacungcap            
            gridLookUpEditNhacungcap.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0]; 
            
            //dgware_Donmuahang_Chitiet
            if (guid != null && guid.ToString() != "")
            {
                ds_Donmuahang_Chitiet_Ncc = objWareService.Get_All_Ware_Ncc_By_Donmuahang_Chitiet(guid).ToDataSet();
                dgware_Donmuahang_Chitiet.DataSource = ds_Donmuahang_Chitiet_Ncc;
                dgware_Donmuahang_Chitiet.DataMember = ds_Donmuahang_Chitiet_Ncc.Tables[0].TableName;
            }
            else
            {
                ds_Donmuahang_Chitiet_Ncc = objWareService.Get_All_Ware_Ncc_By_Donmuahang_Chitiet(-1).ToDataSet();
                dgware_Donmuahang_Chitiet.DataSource = ds_Donmuahang_Chitiet_Ncc;
                dgware_Donmuahang_Chitiet.DataMember = ds_Donmuahang_Chitiet_Ncc.Tables[0].TableName;
            }
            gridView5.BestFitColumns();            
            base.DisplayInfo();
        }

        public override bool PerformSave()
        {
            return this.PerformSaveChanges();
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView5.Columns["Id_Khachhang"], "");
            hashtableControls.Add(gridView5.Columns["Dongia"], "");
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView5))
                return false;

            try
            {
                this.DoClickEndEdit(dgware_Donmuahang_Chitiet); 
                foreach (DataRow dr in ds_Donmuahang_Chitiet_Ncc.Tables[0].Rows)
                    if (dr.RowState == DataRowState.Added)
                        dr["Guid"] = guid;
                objWareService.Update_Ware_Donmuahang_Chitiet_Ncc_Collection(this.ds_Donmuahang_Chitiet_Ncc);

                this.DoClickEndEdit(dgware_Donmuahang_Chitiet);
                SelectedRow = ds_Donmuahang_Chitiet_Ncc.Tables[0].Select("Chon = True ");
                this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
            this.DoClickEndEdit(dgware_Donmuahang_Chitiet); 
            if (ds_Donmuahang_Chitiet_Ncc.Tables[0].Select("Chon = True").Length == 0)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Không có Nhà cung cấp nào được chọn");
                return false;
            }
            SelectedRow = ds_Donmuahang_Chitiet_Ncc.Tables[0].Select("Chon = True ");
            this.Close();
            return base.PerformSelectOneObject();
        }

        public override bool PerformEdit()
        {
            this.xtraHNavigator1.Enabled = true;
            return base.PerformEdit();
        }

        public override bool PerformCancel()
        {
            this.xtraHNavigator1.Enabled = false;
            this.DisplayInfo();
            return base.PerformCancel();
        }

        public override bool PerformAdd()
        {
            return base.PerformAdd();
        }
        #endregion

        #region Even

    
        private void gridLookUpEditNhacungcap_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Nhacungcap_Add frmware_Dm_Nhacungcap_Add = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Nhacungcap_Add();
                frmware_Dm_Nhacungcap_Add.Text = gridView5.Columns["Id_Khachhang"].Caption;
                 GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Nhacungcap_Add);
                 GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(frmware_Dm_Nhacungcap_Add);
                frmware_Dm_Nhacungcap_Add.ShowDialog();
                if (frmware_Dm_Nhacungcap_Add.SeletedWare_Dm_Nhacungcap != null)
                {
                    gridLookUpEditNhacungcap.DataSource = frmware_Dm_Nhacungcap_Add.Data.Tables[0];
                    gridView5.SetFocusedRowCellValue(gridView5.Columns["Id_Khachhang"], frmware_Dm_Nhacungcap_Add.SeletedWare_Dm_Nhacungcap.Id_Nhacungcap);
                }
            }
        }

        private void gridRadioGroup_Chon_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] dtr = ds_Donmuahang_Chitiet_Ncc.Tables[0].Select("Id_Khachhang <> " + gridView5.GetFocusedRowCellValue("Id_Khachhang"));
                foreach (DataRow row in dtr)
                {
                    row["Chon"] = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void xtraHNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {
                this.FormState =  GoobizFrame.Windows.Forms.FormState.Add;
                this.addnewrow_clicked = true;
                this.PerformAdd();
            }
        }
        #endregion

        private void repositoryItemTextEdit3_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gridView5.SetFocusedRowCellValue(gridView5.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToDecimal(e.NewValue) <= 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Đơn giá phải lớn hơn 0, vui lòng nhập lại.");
                    gridView5.SetFocusedRowCellValue(gridView5.FocusedColumn, null);
                    e.Cancel = true;
                }
                //Thành tiền trong database là [numeric(18, 2) = (16 số nguyên và 2 số thập phân)]. Nếu đơn giá vược quá 16 ký tự thì hiện thông báo lỗi.
                else if (e.NewValue.ToString().Length > 16)
                {
                    //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị đơn giá không hợp lệ, vui lòng nhập lại.");
                    gridView5.SetFocusedRowCellValue(gridView5.FocusedColumn, null);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị đơn giá không hợp lệ, vui lòng nhập lại.");
                gridView5.SetFocusedRowCellValue(gridView5.Columns["Dongia"], null);
                e.Cancel = true;
            }
        }

    }
}