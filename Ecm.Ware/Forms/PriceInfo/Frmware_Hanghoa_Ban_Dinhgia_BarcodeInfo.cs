using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo : Form
    {
        public Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNoBlock.EditValue == "")
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] { lblNoBlock.Text, lblNoBlock.Text });
                return;
            }
            else
                this.Close();
        }
    }
}