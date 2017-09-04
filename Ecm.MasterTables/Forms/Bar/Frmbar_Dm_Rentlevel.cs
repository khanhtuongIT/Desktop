using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Bar
{
    public partial class Frmbar_Dm_Rentlevel : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsBar_Dm_Rentlevel;

        public Frmbar_Dm_Rentlevel()
        {
            InitializeComponent();
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                dsBar_Dm_Rentlevel = objMasterService.Get_All_Bar_Dm_Rentlevel_Collection().ToDataSet();
                dgbar_Dm_Rentlevel.DataSource = dsBar_Dm_Rentlevel.Tables[0];
                gvbar_Dm_Rentlevel.BestFitColumns();
                this.Data = dsBar_Dm_Rentlevel;
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
                this.DoClickEndEdit(dgbar_Dm_Rentlevel);
                objMasterService.Update_Bar_Dm_Rentlevel_Collection(dsBar_Dm_Rentlevel);
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
