using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Loai_Hanghoa_Ban_Dialog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
               public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        public DataRow[] SelectedRows = null;

        public Frmware_Dm_Loai_Hanghoa_Ban_Dialog()
        {
            InitializeComponent();
            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Loai_Hanghoa_Ban
                DataSet dsWare_Dm_Nhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet();
                gridLookUp_Nhom_Hanghoa_Ban.DataSource = dsWare_Dm_Nhom_Hanghoa_Ban.Tables[0];

                //Get data Ware_Dm_Loai_Hanghoa_Ban
                ds_Collection = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
                ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));

                dgware_Dm_Loai_Hanghoa_Ban.DataSource = ds_Collection;
                dgware_Dm_Loai_Hanghoa_Ban.DataMember = ds_Collection.Tables[0].TableName;

                ////this.Data = ds_Collection;
                //this.GridControl = dgware_Dm_Loai_Hanghoa_Ban;

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
            dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
            SelectedRows = ds_Collection.Tables[0].Select("Chon = true");
            this.Close();
            return base.PerformSelectOneObject();
        }


        private void dgware_Dm_Loai_Hanghoa_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }
    }
}

