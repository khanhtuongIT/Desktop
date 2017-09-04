using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.MasterTables.Forms.Ware
{
    public partial class  Frmware_Dm_Loai_Hanghoa_Mua_Dialog: GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
               public MasterService.MasterService objMasterService = new SunLine.MasterTables.MasterService.MasterService();
        DataSet ds_Collection = new DataSet();
        public MasterService.Ware_Dm_Loai_Hanghoa_Mua SelectedWare_Dm_Loai_Hanghoa_Mua;
        public DataRow[] SelectedRows = null;

        public Frmware_Dm_Loai_Hanghoa_Mua_Dialog()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Loai_Hanghoa_Mua
                DataSet dsWare_Dm_Nhom_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Mua();
                gridLookUpEdit_Nhom_Hanghoa_Mua.DataSource          = dsWare_Dm_Nhom_Hanghoa_Mua.Tables[0];

                //Get data Ware_Dm_Loai_Hanghoa_Mua
                ds_Collection = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Mua();
                ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));

                dgware_Dm_Loai_Hanghoa_Mua.DataSource = ds_Collection;
                dgware_Dm_Loai_Hanghoa_Mua.DataMember = ds_Collection.Tables[0].TableName;

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                //GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        public override object PerformSelectOneObject()
        {
            dgware_Dm_Loai_Hanghoa_Mua.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            SelectedRows = ds_Collection.Tables[0].Select("Chon = true");
            this.Close();
            return base.PerformSelectOneObject();
        }
    }
}

