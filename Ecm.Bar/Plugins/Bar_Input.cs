using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Bar.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Bar_Input : IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        Forms.Frmbar_Table_Cash frmbar_Table_Cash;
        Forms.Version2.Frmbar_Table_Order frmbar_Table_Order;
        Forms.Version2.Frmbar_Table_Monitor_Pos frmbar_Table_Monitor_Pos;
        Forms.Frmbar_Table_MngrEdit frmbar_Table_MngrEdit;
        Forms.Frmbar_Table_Booking frmbar_Table_Booking;
        Forms.Frmbar_Kitchen_Printer frmbar_Kitchen_Printer;
        Forms.Frmbar_Kitchen_Order_Chitiet frmbar_Kitchen_Order_Chitiet;
        Forms.Frmbar_Kitchen_Order_ChitietLog frmbar_Kitchen_Order_ChitietLog;
        Forms.Frmbar_Winecard frmbar_Winecard;
       #endregion

        public Bar_Input()
        {
            m_strName = "Đang kiểm tra";
            m_PluginItemConfig = @"";
        }

        public void SetMdiParent(System.Windows.Forms.Form mdiParent)
        {
            this.mdiParent = mdiParent;
        }

        public void BarManager_ItemClick(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();

            string formName = "";
            string formText = "";

            if (e.GetType() == typeof(DevExpress.XtraNavBar.NavBarLinkEventArgs))
            {
                formName = ((DevExpress.XtraNavBar.NavBarLinkEventArgs)e).Link.ItemName;
                formText = ((DevExpress.XtraNavBar.NavBarLinkEventArgs)e).Link.Caption;
            }
            else if (e.GetType() == typeof(DevExpress.XtraBars.ItemClickEventArgs))
            {
                formName = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Name;
                formText = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Caption;
            }
            else
            {
                formName = ((System.Windows.Forms.Control)sender).Name;
                formText = ((System.Windows.Forms.Control)sender).Text;
            }

            switch (formName)
            {
                case "Frmbar_Table_Order":
                    frmbar_Table_Order = (Forms.Version2.Frmbar_Table_Order) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmbar_Table_Order");

                    if (frmbar_Table_Order == null || frmbar_Table_Order.IsDisposed)
                        frmbar_Table_Order = new Forms.Version2.Frmbar_Table_Order();
                    frmbar_Table_Order.Text = formText;
                    frmbar_Table_Order.MdiParent = mdiParent;
                    frmbar_Table_Order.Show();
                    frmbar_Table_Order.Activate();
                    break;

                case "Frmbar_Table_Cash":
                    frmbar_Table_Cash = (Forms.Frmbar_Table_Cash) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmbar_Table_Cash");

                    if (frmbar_Table_Cash == null || frmbar_Table_Cash.IsDisposed)
                        frmbar_Table_Cash = new Forms.Frmbar_Table_Cash();
                    frmbar_Table_Cash.Text = formText;
                    frmbar_Table_Cash.MdiParent = mdiParent;
                    frmbar_Table_Cash.Show();
                    frmbar_Table_Cash.Activate();
                    break;

                case "Frmbar_Table_Monitor_Pos":
                    frmbar_Table_Monitor_Pos = (Forms.Version2.Frmbar_Table_Monitor_Pos) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmbar_Table_Monitor_Pos");

                    if (frmbar_Table_Monitor_Pos == null || frmbar_Table_Monitor_Pos.IsDisposed)
                        frmbar_Table_Monitor_Pos = new Forms.Version2.Frmbar_Table_Monitor_Pos();
                    frmbar_Table_Monitor_Pos.Text = formText;
                    frmbar_Table_Monitor_Pos.MdiParent = mdiParent;
                    frmbar_Table_Monitor_Pos.Show();
                    frmbar_Table_Monitor_Pos.Activate();
                    break;


                case "Frmbar_Table_MngrEdit":
                    frmbar_Table_MngrEdit = (Forms.Frmbar_Table_MngrEdit) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmbar_Table_MngrEdit");

                    if (frmbar_Table_MngrEdit == null || frmbar_Table_MngrEdit.IsDisposed)
                        frmbar_Table_MngrEdit = new Forms.Frmbar_Table_MngrEdit();
                    frmbar_Table_MngrEdit.Text = formText;
                    frmbar_Table_MngrEdit.MdiParent = mdiParent;
                    frmbar_Table_MngrEdit.Show();
                    frmbar_Table_MngrEdit.Activate();
                    break;

                case "Frmbar_Table_Booking":
                    frmbar_Table_Booking = (Forms.Frmbar_Table_Booking) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmbar_Table_Booking");

                    if (frmbar_Table_Booking == null || frmbar_Table_Booking.IsDisposed)
                        frmbar_Table_Booking = new Forms.Frmbar_Table_Booking();
                    frmbar_Table_Booking.Text = formText;
                    frmbar_Table_Booking.MdiParent = mdiParent;
                    frmbar_Table_Booking.Show();
                    frmbar_Table_Booking.Activate();
                    break;

                case "Frmbar_Kitchen_Printer":
                    frmbar_Kitchen_Printer = (Forms.Frmbar_Kitchen_Printer) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmbar_Kitchen_Printer");

                    if (frmbar_Kitchen_Printer == null || frmbar_Kitchen_Printer.IsDisposed)
                        frmbar_Kitchen_Printer = new Forms.Frmbar_Kitchen_Printer();
                    frmbar_Kitchen_Printer.Text = formText;
                    frmbar_Kitchen_Printer.MdiParent = mdiParent;
                    frmbar_Kitchen_Printer.Show();
                    frmbar_Kitchen_Printer.Activate();
                    break;

                case "Frmbar_Kitchen_Order_Chitiet":
                    frmbar_Kitchen_Order_Chitiet = (Forms.Frmbar_Kitchen_Order_Chitiet) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmbar_Kitchen_Order_Chitiet");

                    if (frmbar_Kitchen_Order_Chitiet == null || frmbar_Kitchen_Order_Chitiet.IsDisposed)
                        frmbar_Kitchen_Order_Chitiet = new Forms.Frmbar_Kitchen_Order_Chitiet();
                    frmbar_Kitchen_Order_Chitiet.Text = formText;
                    frmbar_Kitchen_Order_Chitiet.MdiParent = mdiParent;
                    frmbar_Kitchen_Order_Chitiet.Show();
                    frmbar_Kitchen_Order_Chitiet.Activate();
                    break;

                case "Frmbar_Kitchen_Order_ChitietLog":
                    frmbar_Kitchen_Order_ChitietLog = (Forms.Frmbar_Kitchen_Order_ChitietLog) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmbar_Kitchen_Order_ChitietLog");

                    if (frmbar_Kitchen_Order_ChitietLog == null || frmbar_Kitchen_Order_ChitietLog.IsDisposed)
                        frmbar_Kitchen_Order_ChitietLog = new Forms.Frmbar_Kitchen_Order_ChitietLog();
                    frmbar_Kitchen_Order_ChitietLog.Text = formText;
                    frmbar_Kitchen_Order_ChitietLog.MdiParent = mdiParent;
                    frmbar_Kitchen_Order_ChitietLog.Show();
                    frmbar_Kitchen_Order_ChitietLog.Activate();
                    break;
                case "Frmbar_Winecard":
                    frmbar_Winecard = (Forms.Frmbar_Winecard)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmbar_Winecard");

                    if (frmbar_Winecard == null || frmbar_Winecard.IsDisposed)
                        frmbar_Winecard = new Forms.Frmbar_Winecard();
                    frmbar_Winecard.Text = formText;
                    frmbar_Winecard.MdiParent = mdiParent;
                    frmbar_Winecard.Show();
                    frmbar_Winecard.Activate();
                    break;
       
              
            }
            WaitDialogForm.Close();
        }

        #region Implements Interface
        private string m_strName;
        private string m_PluginItemConfig;
        private IPluginHost m_Host;

        private System.Windows.Forms.Form mdiParent;
        public System.Windows.Forms.Form MdiParent
        {
            get { return mdiParent; }
            set { mdiParent = value; }
        }
        public string Name
        { get { return m_strName; } set { m_strName = value; } }

        public string PluginItemConfig
        { get { return m_PluginItemConfig; } set { m_PluginItemConfig = value; } }

        //public void Show(System.Windows.Forms.Form mdiParent)
        //{ 
        //    Main1 mn = new Main1();
        //    mn.ShowDialog();
        //}

        public IPluginHost Host
        {
            get { return m_Host; }
            set
            {
                m_Host = value;
                m_Host.Register(this);
            }
        }

        public void PreLoadData()
        {
            new System.Threading.Thread(new System.Threading.ThreadStart(this.PreLoadThread)).Start();
        }

        void PreLoadThread()
        {
            lock (this)
            {
               

                

                DataLoaded = true;
            }
        }
        #endregion
    }
}
