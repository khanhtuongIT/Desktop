using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_SetLocation : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        WareService.WareService objWareService = new SunLine.Ware.WareService.WareService();
        MasterService.MasterService objMasterService = new SunLine.Ware.MasterService.MasterService();

        public Frmware_SetLocation()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();
        }

        void ChangeStatus(bool editable)
        {
            lookUpEditMa_Kho_Hanghoa.Properties.ReadOnly = !editable;
        }

        public override void DisplayInfo()
        {
            lookUpEditMa_Kho_Hanghoa.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa().Tables[0];

            try
            {
                if ("" + GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban") != "")
                    lookUpEditMa_Kho_Hanghoa.EditValue = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            //try
            //{
            //    if ("" + GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocationId_Kho_Hanghoa_Mua() != "")
            //        lookUpEditMa_Kho_Hanghoa.EditValue = "Kh" +
            //            GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocationId_Kho_Hanghoa_Mua();
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }

            ChangeStatus(false);
        }

        public override bool PerformEdit()
        {
            ChangeStatus(true);
            return base.PerformEdit();
        }

        public override bool PerformSave()
        {
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetLocation("Id_Cuahang_Ban", "" + lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Cuahang_Ban"));
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetLocationId_Kho_Hanghoa_Mua(""+lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua"));
            if (System.IO.Directory.Exists(Application.StartupPath + @"\Resources\localdata"))
                System.IO.Directory.Delete(Application.StartupPath + @"\Resources\localdata", true);
            DisplayInfo();
            return base.PerformSave();
        }

        public override bool PerformCancel()
        {
            DisplayInfo();
            return base.PerformCancel();
        }
    }
}