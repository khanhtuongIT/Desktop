using System;
using System.Collections.Generic;
using System.Text;
using GoobizFrame.Windows.PlugIn;

namespace Ecm.Ware.Plugins
{
    /// <summary>
    /// handle Ware_Input, Ware_Output
    /// </summary>
    public class Ware_Pro : IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        //input
        Forms.Frmware_Hdbanhang_noVAT_MngrEdit frmware_Hdbanhang_noVAT_MngrEdit;
        //Forms.Frmware_Kehoach_Banhang_Edit _Frmware_Kehoach_Banhang_Edit;
        Forms.Frmware_Dondathang_Edit _Frmware_Dondathang_Edit;
        //Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Import frmware_Dm_Hanghoa_Ban_Import;
        //Forms.Frmware_Nhap_Hh_Ban_Err frmware_Nhap_Hh_Ban_Err;
        //Forms.Frmware_Hh_Cuahang_Ban frmware_Hh_Cuahang_Ban;
        //Forms.Frmware_Xuat_Hh_Ban frmware_Xuat_Hh_Ban;
        //Forms.Frmware_Hh_Mua_Tra_Ncc frmware_Hh_Mua_Tra_Ncc;

        #endregion

        public Ware_Pro()
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
            else
                if (e.GetType() == typeof(DevExpress.XtraBars.ItemClickEventArgs))
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
                #region Ware_Input  - Dự trù mua hàng, Nhập hàng hóa mua, nhập hàng hóa sản xuất

                //case "Frmware_Kehoach_Banhang_Edit":
                //    _Frmware_Kehoach_Banhang_Edit = (Forms.Frmware_Kehoach_Banhang_Edit)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Kehoach_Banhang_Edit");

                //    if (_Frmware_Kehoach_Banhang_Edit == null || _Frmware_Kehoach_Banhang_Edit.IsDisposed)
                //        _Frmware_Kehoach_Banhang_Edit = new Forms.Frmware_Kehoach_Banhang_Edit();
                //    _Frmware_Kehoach_Banhang_Edit.Text = formText;
                //    _Frmware_Kehoach_Banhang_Edit.MdiParent = mdiParent;
                //    _Frmware_Kehoach_Banhang_Edit.Show();
                //    _Frmware_Kehoach_Banhang_Edit.Activate();
                //    break;

                case "Frmware_Hdbanhang_noVAT_MngrEdit":
                    frmware_Hdbanhang_noVAT_MngrEdit = (Forms.Frmware_Hdbanhang_noVAT_MngrEdit)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hdbanhang_noVAT_MngrEdit");

                    if (frmware_Hdbanhang_noVAT_MngrEdit == null || frmware_Hdbanhang_noVAT_MngrEdit.IsDisposed)
                        frmware_Hdbanhang_noVAT_MngrEdit = new Forms.Frmware_Hdbanhang_noVAT_MngrEdit();
                    frmware_Hdbanhang_noVAT_MngrEdit.Text = formText;
                    frmware_Hdbanhang_noVAT_MngrEdit.MdiParent = mdiParent;
                    frmware_Hdbanhang_noVAT_MngrEdit.Show();
                    frmware_Hdbanhang_noVAT_MngrEdit.Activate();
                    break;

                case "Frmware_Dondathang_Edit":
                    _Frmware_Dondathang_Edit = (Forms.Frmware_Dondathang_Edit)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Dondathang_Edit");

                    if (_Frmware_Dondathang_Edit == null || _Frmware_Dondathang_Edit.IsDisposed)
                        _Frmware_Dondathang_Edit = new Forms.Frmware_Dondathang_Edit();
                    _Frmware_Dondathang_Edit.Text = formText;
                    _Frmware_Dondathang_Edit.MdiParent = mdiParent;
                    _Frmware_Dondathang_Edit.Show();
                    _Frmware_Dondathang_Edit.Activate();
                    break;

                //case "Frmware_Hh_Cuahang_Ban":
                //    frmware_Hh_Cuahang_Ban = (Forms.Frmware_Hh_Cuahang_Ban) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hh_Cuahang_Ban");

                //    if (frmware_Hh_Cuahang_Ban == null || frmware_Hh_Cuahang_Ban.IsDisposed)
                //        frmware_Hh_Cuahang_Ban = new Forms.Frmware_Hh_Cuahang_Ban();
                //    frmware_Hh_Cuahang_Ban.Text = formText;
                //    frmware_Hh_Cuahang_Ban.MdiParent = mdiParent;
                //    frmware_Hh_Cuahang_Ban.Show();
                //    frmware_Hh_Cuahang_Ban.Activate();
                //    break;

                //case "Frmware_Xuat_Hh_Ban":
                //    frmware_Xuat_Hh_Ban = (Forms.Frmware_Xuat_Hh_Ban)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Xuat_Hh_Ban");

                //    if (frmware_Xuat_Hh_Ban == null || frmware_Xuat_Hh_Ban.IsDisposed)
                //        frmware_Xuat_Hh_Ban = new Forms.Frmware_Xuat_Hh_Ban();
                //    frmware_Xuat_Hh_Ban.Text = formText;
                //    frmware_Xuat_Hh_Ban.MdiParent = mdiParent;
                //    frmware_Xuat_Hh_Ban.Show();
                //    frmware_Xuat_Hh_Ban.Activate();
                //    break;
                #endregion


                //default:
                //     GoobizFrame.Windows.Forms.MessageDialog.Show("Chức năng " + formText + " đang được xây dựng");
                //    break;

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
                //frmware_Dm_Cuahang_Ban_Add = new Ecm.Ware.Forms.Frmware_Dm_Cuahang_Ban_Add();
                //frmware_Dm_Cuahang_Ban_Add.Dispose();



                DataLoaded = true;
            }
        }
        #endregion
    }
}
