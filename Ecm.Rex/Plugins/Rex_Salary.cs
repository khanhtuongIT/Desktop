using System;
using System.Collections.Generic;
using System.Text;
using itvs.Windows.PlugIn;

namespace TruthPos.Rex.Plugins
{
    public class Rex_Salary : IPlugin
    {

        #region Forms
        Forms.Frmrex_Kyluong frmrex_Kyluong;
        //Forms.Frmrex_Chitiet_Congviec_Thuchien frmrex_Chitiet_Congviec_Thuchien;
        //Forms.Frmrex_Dongia_Luong_Congviec frmrex_Dongia_Luong_Congviec;
        //Forms.Frmrex_Dongia_Luong_Hieunang frmrex_Dongia_Luong_Hieunang;
        //Forms.Frmrex_Luong_Nhom frmrex_Luong_Nhom;
        //Forms.Frmrex_Luong_Hieunang frmrex_Luong_Hieunang;
        //Forms.Frmrex_Luong_Thoigian frmrex_Luong_Thoigian;

        Forms.Frmrex_Luong_Tonghop frmrex_Luong_Tonghop;
        Forms.Tienluong.FrmRex_Tamung_Ky1 frmRex_Tamung_Ky1;
        #endregion

        public Rex_Salary()
        {
            m_strName = "Đang kiểm tra";
            m_PluginItemConfig = @"";
        }
        public void BarManager_ItemClick(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ trong vài giây...", "Đang thực hiện");

            string formName = "";
            string formText = "";

            if (e.GetType() == typeof(DevExpress.XtraNavBar.NavBarLinkEventArgs))
            {
                formName = ((DevExpress.XtraNavBar.NavBarItem)sender).Name;
                formText = ((DevExpress.XtraNavBar.NavBarItem)sender).Caption;
            }
            else if (e.GetType() == typeof(DevExpress.XtraBars.ItemClickEventArgs))
            {
                formName = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Name;
                formText = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Caption;
            }

            switch (formName)
            {

                case "Frmrex_Kyluong":
                    frmrex_Kyluong = (Forms.Frmrex_Kyluong)itvs.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Kyluong");

                    if (frmrex_Kyluong == null || frmrex_Kyluong.IsDisposed)
                        frmrex_Kyluong = new Forms.Frmrex_Kyluong();
                    frmrex_Kyluong.Text = formText;
                    frmrex_Kyluong.MdiParent = mdiParent;
                    frmrex_Kyluong.Show();
                    frmrex_Kyluong.Activate();
                    break;
              
                //case "Frmrex_Chitiet_Congviec_Thuchien":
                //    frmrex_Chitiet_Congviec_Thuchien = (Forms.Frmrex_Chitiet_Congviec_Thuchien)itvs.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Chitiet_Congviec_Thuchien");

                //    if (frmrex_Chitiet_Congviec_Thuchien == null || frmrex_Chitiet_Congviec_Thuchien.IsDisposed)
                //        frmrex_Chitiet_Congviec_Thuchien = new Forms.Frmrex_Chitiet_Congviec_Thuchien();
                //    frmrex_Chitiet_Congviec_Thuchien.Text = formText;
                //    frmrex_Chitiet_Congviec_Thuchien.MdiParent = mdiParent;
                //    frmrex_Chitiet_Congviec_Thuchien.Show();
                //    frmrex_Chitiet_Congviec_Thuchien.Activate();
                //    break;
               
                //case "Frmrex_Dongia_Luong_Congviec":
                //    frmrex_Dongia_Luong_Congviec = (Forms.Frmrex_Dongia_Luong_Congviec)itvs.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dongia_Luong_Congviec");

                //    if (frmrex_Dongia_Luong_Congviec == null || frmrex_Dongia_Luong_Congviec.IsDisposed)
                //        frmrex_Dongia_Luong_Congviec = new Forms.Frmrex_Dongia_Luong_Congviec();
                //    frmrex_Dongia_Luong_Congviec.Text = formText;
                //    frmrex_Dongia_Luong_Congviec.MdiParent = mdiParent;
                //    frmrex_Dongia_Luong_Congviec.Show();
                //    frmrex_Dongia_Luong_Congviec.Activate();
                //    break;
                //case "Frmrex_Dongia_Luong_Hieunang":
                //    frmrex_Dongia_Luong_Hieunang = (Forms.Frmrex_Dongia_Luong_Hieunang)itvs.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dongia_Luong_Hieunang");

                //    if (frmrex_Dongia_Luong_Hieunang == null || frmrex_Dongia_Luong_Hieunang.IsDisposed)
                //        frmrex_Dongia_Luong_Hieunang = new Forms.Frmrex_Dongia_Luong_Hieunang();
                //    frmrex_Dongia_Luong_Hieunang.Text = formText;
                //    frmrex_Dongia_Luong_Hieunang.MdiParent = mdiParent;
                //    frmrex_Dongia_Luong_Hieunang.Show();
                //    frmrex_Dongia_Luong_Hieunang.Activate();
                //    break;

                //case "Frmrex_Luong_Nhom":
                //    frmrex_Luong_Nhom = (Forms.Frmrex_Luong_Nhom)itvs.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Luong_Nhom");

                //    if (frmrex_Luong_Nhom == null || frmrex_Luong_Nhom.IsDisposed)
                //        frmrex_Luong_Nhom = new Forms.Frmrex_Luong_Nhom();
                //    frmrex_Luong_Nhom.Text = formText;
                //    frmrex_Luong_Nhom.MdiParent = mdiParent;
                //    frmrex_Luong_Nhom.Show();
                //    frmrex_Luong_Nhom.Activate();
                //    break;
                //case "Frmrex_Luong_Hieunang":
                //    frmrex_Luong_Hieunang = (Forms.Frmrex_Luong_Hieunang)itvs.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Luong_Hieunang");

                //    if (frmrex_Luong_Hieunang == null || frmrex_Luong_Hieunang.IsDisposed)
                //        frmrex_Luong_Hieunang = new Forms.Frmrex_Luong_Hieunang();
                //    frmrex_Luong_Hieunang.Text = formText;
                //    frmrex_Luong_Hieunang.MdiParent = mdiParent;
                //    frmrex_Luong_Hieunang.Show();
                //    frmrex_Luong_Hieunang.Activate();
                //    break;
                //case "Frmrex_Luong_Thoigian":
                //    frmrex_Luong_Thoigian = (Forms.Frmrex_Luong_Thoigian)itvs.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Luong_Thoigian");

                //    if (frmrex_Luong_Thoigian == null || frmrex_Luong_Thoigian.IsDisposed)
                //        frmrex_Luong_Thoigian = new Forms.Frmrex_Luong_Thoigian();
                //    frmrex_Luong_Thoigian.Text = formText;
                //    frmrex_Luong_Thoigian.MdiParent = mdiParent;
                //    frmrex_Luong_Thoigian.Show();
                //    frmrex_Luong_Thoigian.Activate();
                //    break;

                case "Frmrex_Luong_Tonghop":
                    frmrex_Luong_Tonghop = (Forms.Frmrex_Luong_Tonghop)itvs.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Luong_Tonghop");

                    if (frmrex_Luong_Tonghop == null || frmrex_Luong_Tonghop.IsDisposed)
                        frmrex_Luong_Tonghop = new Forms.Frmrex_Luong_Tonghop();
                    frmrex_Luong_Tonghop.Text = formText;
                    frmrex_Luong_Tonghop.MdiParent = mdiParent;
                    frmrex_Luong_Tonghop.Show();
                    frmrex_Luong_Tonghop.Activate();
                    break;

                case "FrmRex_Tamung_Ky1":
                    frmRex_Tamung_Ky1 = (Forms.Tienluong.FrmRex_Tamung_Ky1)itvs.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRex_Tamung_Ky1");

                    if (frmRex_Tamung_Ky1 == null || frmRex_Tamung_Ky1.IsDisposed)
                        frmRex_Tamung_Ky1 = new Forms.Tienluong.FrmRex_Tamung_Ky1();
                    frmRex_Tamung_Ky1.Text = formText;
                    frmRex_Tamung_Ky1.MdiParent = mdiParent;
                    frmRex_Tamung_Ky1.Show();
                    frmRex_Tamung_Ky1.Activate();
                    break;            
            
            }
            WaitDialogForm.Close();
        }
        public void SetMdiParent(System.Windows.Forms.Form mdiParent)
        {
            this.mdiParent = mdiParent;
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
                
            }
        }
        #endregion
    }
}
