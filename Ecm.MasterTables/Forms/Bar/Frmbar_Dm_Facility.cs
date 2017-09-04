using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.MasterTables.Forms.Bar
{
    public partial class Frmbar_Dm_Facility : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsBar_Dm_Facility;

        public Frmbar_Dm_Facility()
        {
            InitializeComponent();

            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                dsBar_Dm_Facility = objMasterService.Get_All_Bar_Dm_Facility().ToDataSet();

                dgDm_Facility.DataSource = dsBar_Dm_Facility.Tables[0];
                gvDm_Facility.BestFitColumns();

                this.Data = dsBar_Dm_Facility;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
            base.DisplayInfo();
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            return base.PerformCancel();
        }

        public override bool PerformSaveChanges()
        {
            try
            {
                this.DoClickEndEdit(dgDm_Facility);
                objMasterService.Update_Bar_Dm_Facility_Collection(dsBar_Dm_Facility);
                DisplayInfo();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
            return base.PerformSaveChanges();
        }
    }
}