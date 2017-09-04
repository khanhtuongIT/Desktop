using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Hanghoa_Mua_Dgmua : SunLine.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Mua_Add
    {
        public Frmware_Dm_Hanghoa_Mua_Dgmua()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            dgware_Dm_Hanghoa_Mua.EmbeddedNavigator.Buttons.Remove.Visible = false;
            dgware_Dm_Hanghoa_Mua.EmbeddedNavigator.Buttons.Remove.Enabled = false;

            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 10;
        }
    }
}

