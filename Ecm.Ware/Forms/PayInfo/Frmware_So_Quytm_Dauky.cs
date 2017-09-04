using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_So_Quytm_Dauky :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Frmware_So_Quytm_Dauky()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
                WebReferences.WareService.Ware_So_Quytm objWare_So_Quytm = new Ecm.WebReferences.WareService.Ware_So_Quytm();
                objWare_So_Quytm.Thang = "" + DateTime.Now.Month;
                objWare_So_Quytm.Nam = "" + DateTime.Now.Year;
                objWare_So_Quytm.Sotien = Convert.ToDecimal("0" +txtSotien.Text);
                objWareService.Insert_Ware_So_Quytm(objWare_So_Quytm);
                this.Dispose();
            }
            catch (Exception ex)
            {
                #if (DEBUG)
                MessageBox.Show(ex.Message);
                #endif
            }
        }
    }
}

