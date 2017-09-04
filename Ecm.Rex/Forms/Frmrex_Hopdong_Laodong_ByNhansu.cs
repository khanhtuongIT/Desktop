using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Hopdong_Laodong_ByNhansu : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();

        private object id_nhansu;
        public object Id_Nhansu
        {
            get { return id_nhansu; }
            set 
            { 
                id_nhansu = value;
                DisplayInfo();
            }
        }

        public Frmrex_Hopdong_Laodong_ByNhansu()
        {
            InitializeComponent();
            //datetime mask
            
            gridDate_Ngay_Batdau.Mask.UseMaskAsDisplayFormat = true;
            gridDate_Ngay_Batdau.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data master table REX
                gridLookUp_Loai_Hopdong.DataSource = objMasterService.Get_All_Rex_Dm_Loai_Hopdong_Collection().ToDataSet().Tables[0];

                gridLookUp_Nhansu.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];

                ds_Collection = objRexService.Get_All_Rex_Hopdong_Laodong_By_Nhansu(id_nhansu).ToDataSet();

                dgrex_Hopdong_Laodong.DataSource = ds_Collection;
                dgrex_Hopdong_Laodong.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgrex_Hopdong_Laodong;

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public override bool PerformSaveChanges()
        {
            try
            {
                this.DoClickEndEdit(dgrex_Hopdong_Laodong); //dgrex_Hopdong_Laodong.EmbeddedNavigator.Buttons.EndEdit.DoClick();

                objRexService.Update_Rex_Hopdong_Laodong_Collection(ds_Collection);
                DisplayInfo();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message);
            }
            return base.PerformSaveChanges();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, "Id_Nhansu", id_nhansu);
        }
    }
}