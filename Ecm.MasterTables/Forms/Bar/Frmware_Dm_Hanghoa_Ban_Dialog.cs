using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Bar
{
    public partial class Frmware_Dm_Hanghoa_Ban_Dialog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        public DataRow [] SelectedRows = null;
        object id_cuahang_ban;
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set 
            { 
                id_cuahang_ban = value;
            
                DisplayInfo();
            }
        }
        public Frmware_Dm_Hanghoa_Ban_Dialog()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Loai_Hanghoa_Ban
                DataSet dsWare_Dm_Loai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
                gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = dsWare_Dm_Loai_Hanghoa_Ban.Tables[0];

                //gridLookUpEdit_Nhom_Hanghoa_Ban
                gridLookUpEdit_Nhom_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet().Tables[0];

                //Get data Ware_Dm_Hanghoa_Ban
                ds_Collection = (id_cuahang_ban == null)
                    ? objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet()
                    : objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(id_cuahang_ban, null).ToDataSet();
                dgware_Dm_Hanghoa_Ban.DataSource = ds_Collection;
                dgware_Dm_Hanghoa_Ban.DataMember = ds_Collection.Tables[0].TableName;

                //lookUpEdit_Donvitinh
                DataSet dsDm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                gridLookUpEdit_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];

                this.Data = ds_Collection;
                this.GridControl = dgware_Dm_Hanghoa_Ban;

                ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));


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

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Id_Loai_Hanghoa_Ban"], "");


            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Hanghoa_Ban"].Unique = true;
                objMasterService.Update_Ware_Dm_Hanghoa_Ban_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { gridView1.Columns["Ma_Hanghoa_Ban"].Caption, gridView1.Columns["Ma_Hanghoa_Ban"].Caption });
                    return false;
                }

                //MessageBox.Show(ex.ToString());

            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
            dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
            SelectedRows = ds_Collection.Tables[0].Select("Chon = true");
            this.Close();
            return base.PerformSelectOneObject();
        }

        private void dgware_Dm_Hanghoa_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Chon")
            {
                gridView1.GetDataRow(gridView1.FocusedRowHandle).AcceptChanges();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in ds_Collection.Tables[0].Rows)
                dr["Chon"] = chkAll.EditValue;
        }
    }
}

