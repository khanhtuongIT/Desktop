using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Congthuc_Phache_Chitiet_Dialog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
               public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        public DataRow[] SelectedRows = null;

        public Frmware_Dm_Congthuc_Phache_Chitiet_Dialog()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Donvitinh
                DataSet dsWare_Dm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                gridLookUp_Donvitinh.DataSource = dsWare_Dm_Donvitinh.Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua
                DataSet dsWare_Dm_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                gridLookUp_Hanghoa_Mua.DataSource = dsWare_Dm_Hanghoa_Mua.Tables[0];

                //Get data Ware_Dm_Congthuc_Phache
                DataSet dsWare_Dm_Congthuc_Phache = objMasterService.Get_All_Ware_Dm_Congthuc_Phache().ToDataSet();
                gridLookUp_Congthuc_Phache.DataSource = dsWare_Dm_Congthuc_Phache.Tables[0];

                //gridLookUpEdit_Nhom_Hanghoa_Ban
                gridLookUp_Nhom_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet().Tables[0];

                //gridLookUpEdit_Loai_Hanghoa_Ban
                gridLookUp_Loai_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet().Tables[0];

                //Get data Ware_Dm_Congthuc_Phache_Chitiet
                ds_Collection = objMasterService.Get_All_Ware_Dm_Congthuc_Phache_Chitiet().ToDataSet();
                dgware_Dm_Congthuc_Phache_Chitiet.DataSource = ds_Collection;
                dgware_Dm_Congthuc_Phache_Chitiet.DataMember = ds_Collection.Tables[0].TableName;
                ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));

                //this.Data = ds_Collection;
                //this.GridControl = dgware_Dm_Congthuc_Phache_Chitiet;

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                // GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        public override object PerformSelectOneObject()
        {
            dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.EndEdit);
            SelectedRows = ds_Collection.Tables[0].Select("Chon = true");
            this.Close();
            return base.PerformSelectOneObject();
        }

        private void dgware_Dm_Congthuc_Phache_Chitiet_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

    }
}