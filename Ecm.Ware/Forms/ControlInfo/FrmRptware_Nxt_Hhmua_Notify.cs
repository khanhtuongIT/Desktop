using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class FrmRptware_Nxt_Hhmua_Notify :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        public FrmRptware_Nxt_Hhmua_Notify()
        {
            InitializeComponent();

            //hide edit items
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            //lookUpEditKho_Hanghoa_Mua.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua().ToDataSet().Tables[0];
            base.DisplayInfo();
        }

        private void lookUpEditKho_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            DisplayInfo2();
        }

        void DisplayInfo2()
        {
            try
            {
                //dgware_Nxt_Hhmua_Notify.DataSource = objWareService.Get_All_Nxt_Hhmua_Notify(objWareService.GetServerDateTime(), lookUpEditKho_Hanghoa_Mua.EditValue).ToDataSet().Tables[0];
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (FormState ==  GoobizFrame.Windows.Forms.FormState.View)
                DisplayInfo2();
        }

       
    }
}

