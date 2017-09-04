using System;
using GoobizFrame.Windows.PlugIn;

namespace Ecm.Rex.Plugins
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class Rex_Report : IPlugin
	{

        public static bool DataLoaded = false;
        #region Forms
        Forms.FrmRptRex_Nhansu_Thongke_Chitieu frmRptRex_Nhansu_Thongke_Chitieu;
        Forms.FrmRptRex_Nhansu_Thongke_Tinhhinh frmRptRex_Nhansu_Thongke_Tinhhinh;
        //Forms.FrmRptRex_Thongke_Phepnam frmRptRex_Thongke_Phepnam;
        Forms.FrmRptRex_Thongke_Loai_Hopdong frmRptRex_Thongke_Loai_Hopdong;

        //Forms.FrmRptRex_Lylich_Trichngang frmRptRex_Lylich_Trichngang;
        //Forms.FrmRptRex_Nghiphep frmRptRex_Nghiphep;
        //Forms.FrmRptRex_Nghiviec frmRptRex_Nghiviec;
        //Forms.FrmRptRex_Tamhoan_Hopdong frmRptRex_Tamhoan_Hopdong;
        //Forms.FrmRptRex_Hopdong_Thuviec frmRptRex_Hopdong_Thuviec;
        //Forms.FrmRptRex_Hopdong_Hethan frmRptRex_Hopdong_Hethan;
        //Forms.FrmRptRex_Nhansu_Tuoihuu frmRptRex_Nhansu_Tuoihuu;
        //Forms.FrmRptRex_Luong_Tonghop frmRptRex_Luong_Tonghop;
        Forms.FrmRptRex_Thamgia_Tochuc frmRptRex_Thamgia_Tochuc;
        #endregion

        public Rex_Report()
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
                case "FrmRptRex_Nhansu_Thongke_Chitieu":
                    frmRptRex_Nhansu_Thongke_Chitieu = (Forms.FrmRptRex_Nhansu_Thongke_Chitieu)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Nhansu_Thongke_Chitieu");

                    if (frmRptRex_Nhansu_Thongke_Chitieu == null || frmRptRex_Nhansu_Thongke_Chitieu.IsDisposed)
                        frmRptRex_Nhansu_Thongke_Chitieu = new Forms.FrmRptRex_Nhansu_Thongke_Chitieu();
                    frmRptRex_Nhansu_Thongke_Chitieu.Text = formText;
                    frmRptRex_Nhansu_Thongke_Chitieu.MdiParent = mdiParent;
                    frmRptRex_Nhansu_Thongke_Chitieu.Show();
                    frmRptRex_Nhansu_Thongke_Chitieu.Activate();
                    break;
                case "FrmRptRex_Nhansu_Thongke_Tinhhinh":
                    frmRptRex_Nhansu_Thongke_Tinhhinh = (Forms.FrmRptRex_Nhansu_Thongke_Tinhhinh)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Nhansu_Thongke_Tinhhinh");

                    if (frmRptRex_Nhansu_Thongke_Tinhhinh == null || frmRptRex_Nhansu_Thongke_Tinhhinh.IsDisposed)
                        frmRptRex_Nhansu_Thongke_Tinhhinh = new Forms.FrmRptRex_Nhansu_Thongke_Tinhhinh();
                    frmRptRex_Nhansu_Thongke_Tinhhinh.Text = formText;
                    frmRptRex_Nhansu_Thongke_Tinhhinh.MdiParent = mdiParent;
                    frmRptRex_Nhansu_Thongke_Tinhhinh.Show();
                    frmRptRex_Nhansu_Thongke_Tinhhinh.Activate();
                    break;
                
                //case "FrmRptRex_Thongke_Phepnam":
                //    frmRptRex_Thongke_Phepnam = (Forms.FrmRptRex_Thongke_Phepnam)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Thongke_Phepnam");

                //    if (frmRptRex_Thongke_Phepnam == null || frmRptRex_Thongke_Phepnam.IsDisposed)
                //        frmRptRex_Thongke_Phepnam = new Forms.FrmRptRex_Thongke_Phepnam();
                //    frmRptRex_Thongke_Phepnam.Text = formText;
                //    frmRptRex_Thongke_Phepnam.MdiParent = mdiParent;
                //    frmRptRex_Thongke_Phepnam.Show();
                //    frmRptRex_Thongke_Phepnam.Activate();
                //    break;

                case "FrmRptRex_Thongke_Loai_Hopdong":
                    frmRptRex_Thongke_Loai_Hopdong = (Forms.FrmRptRex_Thongke_Loai_Hopdong)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Thongke_Loai_Hopdong");

                    if (frmRptRex_Thongke_Loai_Hopdong == null || frmRptRex_Thongke_Loai_Hopdong.IsDisposed)
                        frmRptRex_Thongke_Loai_Hopdong = new Forms.FrmRptRex_Thongke_Loai_Hopdong();
                    frmRptRex_Thongke_Loai_Hopdong.Text = formText;
                    frmRptRex_Thongke_Loai_Hopdong.MdiParent = mdiParent;
                    frmRptRex_Thongke_Loai_Hopdong.Show();
                    frmRptRex_Thongke_Loai_Hopdong.Activate();
                    break;

                //case "FrmRptRex_Lylich_Trichngang":
                //    frmRptRex_Lylich_Trichngang = (Forms.FrmRptRex_Lylich_Trichngang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Lylich_Trichngang");

                //    if (frmRptRex_Lylich_Trichngang == null || frmRptRex_Lylich_Trichngang.IsDisposed)
                //        frmRptRex_Lylich_Trichngang = new Forms.FrmRptRex_Lylich_Trichngang();
                //    frmRptRex_Lylich_Trichngang.Text = formText;
                //    frmRptRex_Lylich_Trichngang.MdiParent = mdiParent;
                //    frmRptRex_Lylich_Trichngang.Show();
                //    frmRptRex_Lylich_Trichngang.Activate();
                //    break;

                //case "FrmRptRex_Nghiphep":
                //    frmRptRex_Nghiphep = (Forms.FrmRptRex_Nghiphep)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Nghiphep");

                //    if (frmRptRex_Nghiphep == null || frmRptRex_Nghiphep.IsDisposed)
                //        frmRptRex_Nghiphep = new Forms.FrmRptRex_Nghiphep();
                //    frmRptRex_Nghiphep.Text = formText;
                //    frmRptRex_Nghiphep.MdiParent = mdiParent;
                //    frmRptRex_Nghiphep.Show();
                //    frmRptRex_Nghiphep.Activate();
                //    break;

                //case "FrmRptRex_Nghiviec":
                //    frmRptRex_Nghiviec = (Forms.FrmRptRex_Nghiviec)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Nghiviec");

                //    if (frmRptRex_Nghiviec == null || frmRptRex_Nghiviec.IsDisposed)
                //        frmRptRex_Nghiviec = new Forms.FrmRptRex_Nghiviec();
                //    frmRptRex_Nghiviec.Text = formText;
                //    frmRptRex_Nghiviec.MdiParent = mdiParent;
                //    frmRptRex_Nghiviec.Show();
                //    frmRptRex_Nghiviec.Activate();
                //    break;

                //case "FrmRptRex_Tamhoan_Hopdong":
                //    frmRptRex_Tamhoan_Hopdong = (Forms.FrmRptRex_Tamhoan_Hopdong)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Tamhoan_Hopdong");

                //    if (frmRptRex_Tamhoan_Hopdong == null || frmRptRex_Tamhoan_Hopdong.IsDisposed)
                //        frmRptRex_Tamhoan_Hopdong = new Forms.FrmRptRex_Tamhoan_Hopdong();
                //    frmRptRex_Tamhoan_Hopdong.Text = formText;
                //    frmRptRex_Tamhoan_Hopdong.MdiParent = mdiParent;
                //    frmRptRex_Tamhoan_Hopdong.Show();
                //    frmRptRex_Tamhoan_Hopdong.Activate();
                //    break;

                //case "FrmRptRex_Hopdong_Thuviec":
                //    frmRptRex_Hopdong_Thuviec = (Forms.FrmRptRex_Hopdong_Thuviec)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Hopdong_Thuviec");

                //    if (frmRptRex_Hopdong_Thuviec == null || frmRptRex_Hopdong_Thuviec.IsDisposed)
                //        frmRptRex_Hopdong_Thuviec = new Forms.FrmRptRex_Hopdong_Thuviec();
                //    frmRptRex_Hopdong_Thuviec.Text = formText;
                //    frmRptRex_Hopdong_Thuviec.MdiParent = mdiParent;
                //    frmRptRex_Hopdong_Thuviec.Show();
                //    frmRptRex_Hopdong_Thuviec.Activate();
                //    break;

                //case "FrmRptRex_Hopdong_Hethan":
                //    frmRptRex_Hopdong_Hethan = (Forms.FrmRptRex_Hopdong_Hethan)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Hopdong_Hethan");

                //    if (frmRptRex_Hopdong_Hethan == null || frmRptRex_Hopdong_Hethan.IsDisposed)
                //        frmRptRex_Hopdong_Hethan = new Forms.FrmRptRex_Hopdong_Hethan();
                //    frmRptRex_Hopdong_Hethan.Text = formText;
                //    frmRptRex_Hopdong_Hethan.MdiParent = mdiParent;
                //    frmRptRex_Hopdong_Hethan.Show();
                //    frmRptRex_Hopdong_Hethan.Activate();
                //    break;

                //case "FrmRptRex_Nhansu_Tuoihuu":
                //    frmRptRex_Nhansu_Tuoihuu = (Forms.FrmRptRex_Nhansu_Tuoihuu)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Nhansu_Tuoihuu");

                //    if (frmRptRex_Nhansu_Tuoihuu == null || frmRptRex_Nhansu_Tuoihuu.IsDisposed)
                //        frmRptRex_Nhansu_Tuoihuu = new Forms.FrmRptRex_Nhansu_Tuoihuu();
                //    frmRptRex_Nhansu_Tuoihuu.Text = formText;
                //    frmRptRex_Nhansu_Tuoihuu.MdiParent = mdiParent;
                //    frmRptRex_Nhansu_Tuoihuu.Show();
                //    frmRptRex_Nhansu_Tuoihuu.Activate();
                //    break;

                //case "FrmRptRex_Luong_Tonghop":
                //    frmRptRex_Luong_Tonghop = (Forms.FrmRptRex_Luong_Tonghop)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Luong_Tonghop");

                //    if (frmRptRex_Luong_Tonghop == null || frmRptRex_Luong_Tonghop.IsDisposed)
                //        frmRptRex_Luong_Tonghop = new Forms.FrmRptRex_Luong_Tonghop();
                //    frmRptRex_Luong_Tonghop.Text = formText;
                //    frmRptRex_Luong_Tonghop.MdiParent = mdiParent;
                //    frmRptRex_Luong_Tonghop.Show();
                //    frmRptRex_Luong_Tonghop.Activate();
                //    break;

                case "FrmRptRex_Thamgia_Tochuc":
                    frmRptRex_Thamgia_Tochuc = (Forms.FrmRptRex_Thamgia_Tochuc)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Thamgia_Tochuc");

                    if (frmRptRex_Thamgia_Tochuc == null || frmRptRex_Thamgia_Tochuc.IsDisposed)
                        frmRptRex_Thamgia_Tochuc = new Forms.FrmRptRex_Thamgia_Tochuc();
                    frmRptRex_Thamgia_Tochuc.Text = formText;
                    frmRptRex_Thamgia_Tochuc.MdiParent = mdiParent;
                    frmRptRex_Thamgia_Tochuc.Show();
                    frmRptRex_Thamgia_Tochuc.Activate();
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
		{get{return m_strName;}set{m_strName=value;}}

        public string PluginItemConfig
        { get { return m_PluginItemConfig; } set { m_PluginItemConfig = value; } }
		
        //public void Show(System.Windows.Forms.Form mdiParent)
        //{ 
        //    Main1 mn = new Main1();
        //    mn.ShowDialog();
        //}

		public IPluginHost Host
		{
			get{return m_Host;}
			set
			{
				m_Host=value;
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
                //frmrex_Ds_Nhansu = new Ecm.Rex.Forms.Frmrex_Ds_Nhansu();
                //frmrex_Ds_Nhansu.Dispose();

                DataLoaded = true;
            }
        }
        #endregion
    }
}
