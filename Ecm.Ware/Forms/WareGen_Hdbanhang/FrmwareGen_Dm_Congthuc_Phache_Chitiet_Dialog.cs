using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms.WareGen_Hdbanhang
{
    public partial class FrmwareGen_Dm_Congthuc_Phache_Chitiet_Dialog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Collection = new DataSet();
        public DataRow[] SelectedRows = null;

        public FrmwareGen_Dm_Congthuc_Phache_Chitiet_Dialog()
        {
            InitializeComponent();
            DisplayInfo();
        }

        #region Override

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Donvitinh
                DataSet dsWare_Dm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                gridLookUpEdit_Donvitinh.DataSource = dsWare_Dm_Donvitinh.Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua
                DataSet dsWare_Dm_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua().ToDataSet();
                gridLookUpEdit_Hanghoa_Mua.DataSource = dsWare_Dm_Hanghoa_Mua.Tables[0];

                //Get data Ware_Dm_Congthuc_Phache
                DataSet dsWare_Dm_Congthuc_Phache = objWareService.Get_All_WareGen_Dm_Congthuc_Phache().ToDataSet();
                gridLookUpEdit_Congthuc_Phache.DataSource = dsWare_Dm_Congthuc_Phache.Tables[0];

                //gridLookUpEdit_Nhom_Hanghoa_Ban
                gridLookUpEdit_Nhom_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet().Tables[0];

                //gridLookUpEdit_Loai_Hanghoa_Ban
                gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet().Tables[0];

                //Get data Ware_Dm_Congthuc_Phache_Chitiet
                ds_Collection = objWareService.Get_All_WareGen_Dm_Congthuc_Phache_Chitiet().ToDataSet();
                dgwareGen_Dm_Congthuc_Phache_Chitiet.DataSource = ds_Collection;
                dgwareGen_Dm_Congthuc_Phache_Chitiet.DataMember = ds_Collection.Tables[0].TableName;
                ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif


            }

        }

        public override object PerformSelectOneObject()
        {
            this.DoClickEndEdit(dgwareGen_Dm_Congthuc_Phache_Chitiet);
            SelectedRows = ds_Collection.Tables[0].Select("Chon = true");
            this.Close();
            return base.PerformSelectOneObject();
        }
        #endregion

        private void dgwareGen_Dm_Congthuc_Phache_Chitiet_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

    }
}