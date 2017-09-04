using System;
using GoobizFrame.Windows.PlugIn;

namespace Ecm.Rex.Plugins
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Rex : IPlugin
	{


        #region Forms
        //Forms.Frmrex_Ds_Nhansu frmrex_Ds_Nhansu;
        //Forms.Frmrex_Dienbien_Luong frmrex_Dienbien_Luong;
        //Forms.Frmrex_Hopdong_Laodong frmrex_Hopdong_Laodong;
        //Forms.Frmrex_Nghiphep frmrex_Nghiphep;
        //Forms.Frmrex_Chamcong_Thang frmrex_Chamcong_Thang;
        //Forms.Frmrex_Chitiet_Congviec_Thuchien frmrex_Chitiet_Congviec_Thuchien;
        //Forms.Frmrex_Tinhluong frmrex_Tinhluong;
        //Forms.Frmrex_Dongia_Luong_Congviec frmrex_Dongia_Luong_Congviec;
        //Forms.Frmrex_Dongia_Luong_Hieunang frmrex_Dongia_Luong_Hieunang;
        //Forms.Frmrex_Luong_Nhom frmrex_Luong_Nhom;
        //Forms.Frmrex_Luong_Hieunang frmrex_Luong_Hieunang;
        //Forms.Frmrex_Luong_Thoigian frmrex_Luong_Thoigian;
        //Forms.Frmrex_Botri_Nhansu frmrex_Botri_Nhansu;
        //Forms.Frmrex_Trichnop_Bhxh frmrex_Trichnop_Bhxh;
        //Forms.Frmrex_Phucap frmrex_Phucap;
        
        #endregion

        public Rex()
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

            //switch (formName)
            //{
            //    //case "Frmrex_Ds_Nhansu":
            //    //    frmrex_Ds_Nhansu = (Forms.Frmrex_Ds_Nhansu)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Ds_Nhansu");

            //    //    if (frmrex_Ds_Nhansu == null || frmrex_Ds_Nhansu.IsDisposed)
            //    //        frmrex_Ds_Nhansu = new Forms.Frmrex_Ds_Nhansu();
            //    //    frmrex_Ds_Nhansu.Text = formText;
            //    //    frmrex_Ds_Nhansu.MdiParent = mdiParent;
            //    //    frmrex_Ds_Nhansu.Show();
            //    //    frmrex_Ds_Nhansu.Activate();
            //    //    break;
            //    //case "Frmrex_Dienbien_Luong":
            //    //    frmrex_Dienbien_Luong = (Forms.Frmrex_Dienbien_Luong)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dienbien_Luong");

            //    //    if (frmrex_Dienbien_Luong == null || frmrex_Dienbien_Luong.IsDisposed)
            //    //        frmrex_Dienbien_Luong = new Forms.Frmrex_Dienbien_Luong();
            //    //    frmrex_Dienbien_Luong.Text = formText;
            //    //    frmrex_Dienbien_Luong.MdiParent = mdiParent;
            //    //    frmrex_Dienbien_Luong.Show();
            //    //    frmrex_Dienbien_Luong.Activate();
            //    //    break;
            //    //case "Frmrex_Hopdong_Laodong":
            //    //    frmrex_Hopdong_Laodong = (Forms.Frmrex_Hopdong_Laodong)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Hopdong_Laodong");

            //    //    if (frmrex_Hopdong_Laodong == null || frmrex_Hopdong_Laodong.IsDisposed)
            //    //        frmrex_Hopdong_Laodong = new Forms.Frmrex_Hopdong_Laodong();
            //    //    frmrex_Hopdong_Laodong.Text = formText;
            //    //    frmrex_Hopdong_Laodong.MdiParent = mdiParent;
            //    //    frmrex_Hopdong_Laodong.Show();
            //    //    frmrex_Hopdong_Laodong.Activate();
            //    //    break;
            //    //case "Frmrex_Nghiphep":
            //    //    frmrex_Nghiphep = (Forms.Frmrex_Nghiphep)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Nghiphep");

            //    //    if (frmrex_Nghiphep == null || frmrex_Nghiphep.IsDisposed)
            //    //        frmrex_Nghiphep = new Forms.Frmrex_Nghiphep();
            //    //    frmrex_Nghiphep.Text = formText;
            //    //    frmrex_Nghiphep.MdiParent = mdiParent;
            //    //    frmrex_Nghiphep.Show();
            //    //    frmrex_Nghiphep.Activate();
            //    //    break;
            //    //case "Frmrex_Chamcong_Thang":
            //    //    frmrex_Chamcong_Thang = (Forms.Frmrex_Chamcong_Thang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Chamcong_Thang");

            //    //    if (frmrex_Chamcong_Thang == null || frmrex_Chamcong_Thang.IsDisposed)
            //    //        frmrex_Chamcong_Thang = new Forms.Frmrex_Chamcong_Thang();
            //    //    frmrex_Chamcong_Thang.Text = formText;
            //    //    frmrex_Chamcong_Thang.MdiParent = mdiParent;
            //    //    frmrex_Chamcong_Thang.Show();
            //    //    frmrex_Chamcong_Thang.Activate();
            //    //    break;
            //    //case "Frmrex_Chitiet_Congviec_Thuchien":
            //    //    frmrex_Chitiet_Congviec_Thuchien = (Forms.Frmrex_Chitiet_Congviec_Thuchien)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Chitiet_Congviec_Thuchien");

            //    //    if (frmrex_Chitiet_Congviec_Thuchien == null || frmrex_Chitiet_Congviec_Thuchien.IsDisposed)
            //    //        frmrex_Chitiet_Congviec_Thuchien = new Forms.Frmrex_Chitiet_Congviec_Thuchien();
            //    //    frmrex_Chitiet_Congviec_Thuchien.Text = formText;
            //    //    frmrex_Chitiet_Congviec_Thuchien.MdiParent = mdiParent;
            //    //    frmrex_Chitiet_Congviec_Thuchien.Show();
            //    //    frmrex_Chitiet_Congviec_Thuchien.Activate();
            //    //    break;
            //    //case "Frmrex_Tinhluong":
            //    //    frmrex_Tinhluong = (Forms.Frmrex_Tinhluong)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Tinhluong");

            //    //    if (frmrex_Tinhluong == null || frmrex_Tinhluong.IsDisposed)
            //    //        frmrex_Tinhluong = new Forms.Frmrex_Tinhluong();
            //    //    frmrex_Tinhluong.Text = formText;
            //    //    frmrex_Tinhluong.MdiParent = mdiParent;
            //    //    frmrex_Tinhluong.Show();
            //    //    frmrex_Tinhluong.Activate();
            //    //    break;

            //    //case "Frmrex_Dongia_Luong_Congviec":
            //    //    frmrex_Dongia_Luong_Congviec = (Forms.Frmrex_Dongia_Luong_Congviec)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dongia_Luong_Congviec");

            //    //    if (frmrex_Dongia_Luong_Congviec == null || frmrex_Dongia_Luong_Congviec.IsDisposed)
            //    //        frmrex_Dongia_Luong_Congviec = new Forms.Frmrex_Dongia_Luong_Congviec();
            //    //    frmrex_Dongia_Luong_Congviec.Text = formText;
            //    //    frmrex_Dongia_Luong_Congviec.MdiParent = mdiParent;
            //    //    frmrex_Dongia_Luong_Congviec.Show();
            //    //    frmrex_Dongia_Luong_Congviec.Activate();
            //    //    break;
            //    //case "Frmrex_Dongia_Luong_Hieunang":
            //    //    frmrex_Dongia_Luong_Hieunang = (Forms.Frmrex_Dongia_Luong_Hieunang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dongia_Luong_Hieunang");

            //    //    if (frmrex_Dongia_Luong_Hieunang == null || frmrex_Dongia_Luong_Hieunang.IsDisposed)
            //    //        frmrex_Dongia_Luong_Hieunang = new Forms.Frmrex_Dongia_Luong_Hieunang();
            //    //    frmrex_Dongia_Luong_Hieunang.Text = formText;
            //    //    frmrex_Dongia_Luong_Hieunang.MdiParent = mdiParent;
            //    //    frmrex_Dongia_Luong_Hieunang.Show();
            //    //    frmrex_Dongia_Luong_Hieunang.Activate();
            //    //    break;
            //    //case "Frmrex_Luong_Nhom":
            //    //    frmrex_Luong_Nhom = (Forms.Frmrex_Luong_Nhom)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Luong_Nhom");

            //    //    if (frmrex_Luong_Nhom == null || frmrex_Luong_Nhom.IsDisposed)
            //    //        frmrex_Luong_Nhom = new Forms.Frmrex_Luong_Nhom();
            //    //    frmrex_Luong_Nhom.Text = formText;
            //    //    frmrex_Luong_Nhom.MdiParent = mdiParent;
            //    //    frmrex_Luong_Nhom.Show();
            //    //    frmrex_Luong_Nhom.Activate();
            //    //    break;
            //    //case "Frmrex_Luong_Hieunang":
            //    //    frmrex_Luong_Hieunang = (Forms.Frmrex_Luong_Hieunang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Luong_Hieunang");

            //    //    if (frmrex_Luong_Hieunang == null || frmrex_Luong_Hieunang.IsDisposed)
            //    //        frmrex_Luong_Hieunang = new Forms.Frmrex_Luong_Hieunang();
            //    //    frmrex_Luong_Hieunang.Text = formText;
            //    //    frmrex_Luong_Hieunang.MdiParent = mdiParent;
            //    //    frmrex_Luong_Hieunang.Show();
            //    //    frmrex_Luong_Hieunang.Activate();
            //    //    break;
            //    //case "Frmrex_Luong_Thoigian":
            //    //    frmrex_Luong_Thoigian = (Forms.Frmrex_Luong_Thoigian)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Luong_Thoigian");

            //    //    if (frmrex_Luong_Thoigian == null || frmrex_Luong_Thoigian.IsDisposed)
            //    //        frmrex_Luong_Thoigian = new Forms.Frmrex_Luong_Thoigian();
            //    //    frmrex_Luong_Thoigian.Text = formText;
            //    //    frmrex_Luong_Thoigian.MdiParent = mdiParent;
            //    //    frmrex_Luong_Thoigian.Show();
            //    //    frmrex_Luong_Thoigian.Activate();
            //    //    break;
            //    //case "Frmrex_Botri_Nhansu":
            //    //    frmrex_Botri_Nhansu = (Forms.Frmrex_Botri_Nhansu)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Botri_Nhansu");

            //    //    if (frmrex_Botri_Nhansu == null || frmrex_Botri_Nhansu.IsDisposed)
            //    //        frmrex_Botri_Nhansu = new Forms.Frmrex_Botri_Nhansu();
            //    //    frmrex_Botri_Nhansu.Text = formText;
            //    //    frmrex_Botri_Nhansu.MdiParent = mdiParent;
            //    //    frmrex_Botri_Nhansu.Show();
            //    //    frmrex_Botri_Nhansu.Activate();
            //    //    break;

            //    //case "Frmrex_Trichnop_Bhxh":
            //    //    frmrex_Trichnop_Bhxh = (Forms.Frmrex_Trichnop_Bhxh)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Trichnop_Bhxh");

            //    //    if (frmrex_Trichnop_Bhxh == null || frmrex_Trichnop_Bhxh.IsDisposed)
            //    //        frmrex_Trichnop_Bhxh = new Forms.Frmrex_Trichnop_Bhxh();
            //    //    frmrex_Trichnop_Bhxh.Text = formText;
            //    //    frmrex_Trichnop_Bhxh.MdiParent = mdiParent;
            //    //    frmrex_Trichnop_Bhxh.Show();
            //    //    frmrex_Trichnop_Bhxh.Activate();
            //    //    break;

            //    //case "Frmrex_Phucap":
            //    //    frmrex_Phucap = (Forms.Frmrex_Phucap)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Phucap");

            //    //    if (frmrex_Phucap == null || frmrex_Phucap.IsDisposed)
            //    //        frmrex_Phucap = new Forms.Frmrex_Phucap();
            //    //    frmrex_Phucap.Text = formText;
            //    //    frmrex_Phucap.MdiParent = mdiParent;
            //    //    frmrex_Phucap.Show();
            //    //    frmrex_Phucap.Activate();
            //    //    break;
                
            //}

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
        }
        #endregion
    }
}
