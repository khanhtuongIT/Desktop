using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class FrmRptware_Nxt_Hhban_Notify :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        public FrmRptware_Nxt_Hhban_Notify()
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
            lookUpEditCuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
            base.DisplayInfo();
        }

        public override bool PerformQuery()
        {
            if (""+lookUpEditCuahang_Ban.EditValue!="")
                DisplayInfo2();
            return base.PerformQuery();
        }

        public override bool PerformPrintPreview()
        {
            dgware_Nxt_Hhban_Notify.ShowPrintPreview();
            return base.PerformPrintPreview();
        }

        private void lookUpEditCuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            DisplayInfo2();
        }

        void DisplayInfo2()
        {
            try
            {
                dgware_Nxt_Hhban_Notify.DataSource = objWareService.Get_All_Nxt_Hhban_Notify(objWareService.GetServerDateTime(), lookUpEditCuahang_Ban.EditValue).ToDataSet().Tables[0];
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (FormState ==  GoobizFrame.Windows.Forms.FormState.View)
            //    DisplayInfo2();
        }
    }
}

