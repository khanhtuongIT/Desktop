using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class FrmRptware_Hanghoa_Bangke_Doanhso :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Collection;
        DataSet ds_Khachhang;
        DataSet ds_Nhansu;
        DataSet ds_Hanghoa_Ban;

        #region local data
        DataSet dsSys_Lognotify = null;

        string Sys_Lognotify_Path = @"Resources\localdata\SYS_LOGNOTIFY.xml";
        string xml_WARE_DM_HANGHOA_BAN_TREE = @"Resources\localdata\WARE_DM_HANGHOA_BAN_TREE.xml";
        string xml_REX_NHANSU = @"Resources\localdata\REX_NHANSU.xml";
        string xml_WARE_DM_KHACHHANG = @"Resources\localdata\WARE_DM_KHACHHANG.xml";

        DateTime dtlc_ware_dm_khachhang;
        DateTime dtlc_rex_nhansu;
        DateTime dtlc_ware_dm_hanghoa_ban_tree;

        #endregion

        #region Initialize

        public FrmRptware_Hanghoa_Bangke_Doanhso()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            dtNgay_Batdau.EditValue = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 23, 59, 59);

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;      //Chưa lập query thì không cho xem trang in (thuynguyen)    
            DisplayInfo();
        }

        /// <summary>
        /// Truy xuat DateTime thay doi du lieu cuoi cung
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        private DateTime GetLastChange_FrmLognotify(string table_name)
        {
            try
            {
                return Convert.ToDateTime(dsSys_Lognotify.Tables[0].Select(string.Format("Table_Name='{0}'", table_name))[0]["Last_Change"]);
            }
            catch (Exception ex)
            {
                return new DateTime(2010, 01, 01);
            }
        }

        /// <summary>
        /// Load master table store on local
        /// </summary>
        void LoadMasterData()
        {
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(
             "[WARE_DM_KHACHHANG], [REX_NHANSU]," +
              "[WARE_DM_DONVITINH], " +
              "[WARE_DM_HANGHOA_BAN],[WARE_DM_LOAI_HANGHOA_BAN], [WARE_DM_NHOM_HANGHOA_BAN]").ToDataSet();

            //get date time last change
            dtlc_ware_dm_khachhang = GetLastChange_FrmLognotify("ware_dm_khachhang");
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("rex_nhansu");

            dtlc_ware_dm_hanghoa_ban_tree = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_ware_dm_hanghoa_ban_tree = (DateTime.Compare(dtlc_ware_dm_hanghoa_ban_tree, GetLastChange_FrmLognotify("WARE_DM_DONVITINH")) > 0)
                ? dtlc_ware_dm_hanghoa_ban_tree : GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
            dtlc_ware_dm_hanghoa_ban_tree = (DateTime.Compare(dtlc_ware_dm_hanghoa_ban_tree, GetLastChange_FrmLognotify("WARE_DM_LOAI_HANGHOA_BAN")) > 0)
                ? dtlc_ware_dm_hanghoa_ban_tree : GetLastChange_FrmLognotify("WARE_DM_LOAI_HANGHOA_BAN");
            dtlc_ware_dm_hanghoa_ban_tree = (DateTime.Compare(dtlc_ware_dm_hanghoa_ban_tree, GetLastChange_FrmLognotify("WARE_DM_NHOM_HANGHOA_BAN")) > 0)
               ? dtlc_ware_dm_hanghoa_ban_tree : GetLastChange_FrmLognotify("WARE_DM_NHOM_HANGHOA_BAN");


            //load data from local xml when last change at local differ from database
            if (!System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN_TREE)
                 || DateTime.Compare(dtlc_ware_dm_hanghoa_ban_tree, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN_TREE)) > 0)
            {
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Tree(true, null, null).ToDataSet();
                ds_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN_TREE, XmlWriteMode.WriteSchema);
            }
            else if (ds_Hanghoa_Ban == null || ds_Hanghoa_Ban.Tables.Count == 0)
            {
                ds_Hanghoa_Ban = new DataSet();
                ds_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN_TREE);
            }
            if (!System.IO.File.Exists(xml_WARE_DM_KHACHHANG)
              || DateTime.Compare(dtlc_ware_dm_khachhang, System.IO.File.GetLastWriteTime(xml_WARE_DM_KHACHHANG)) > 0)
            {
                ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                ds_Khachhang.WriteXml(xml_WARE_DM_KHACHHANG, XmlWriteMode.WriteSchema);
            }
            else if (ds_Khachhang == null || ds_Khachhang.Tables.Count == 0)
            {
                ds_Khachhang = new DataSet();
                ds_Khachhang.ReadXml(xml_WARE_DM_KHACHHANG);
            }
            if (!System.IO.File.Exists(xml_REX_NHANSU)
                || DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0)
            {
                ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                ds_Nhansu.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else if (ds_Nhansu == null || ds_Nhansu.Tables.Count == 0)
            {
                ds_Nhansu = new DataSet();
                ds_Nhansu.ReadXml(xml_REX_NHANSU);
            }
            gridLookUpEdit_Khachhang.DataSource = ds_Khachhang.Tables[0];
            gridLookUpEdit_Nhansu.DataSource = ds_Nhansu.Tables[0];
            treeListColumn1.TreeList.DataSource = ds_Hanghoa_Ban.Tables[0];
            treeListColumn1.TreeList.BestFitColumns();

            txtMa_Hanghoa.DataBindings.Clear();
            txtTen_hanghoa.DataBindings.Clear();
            txtBarcode_Txt.DataBindings.Clear();
            txtMa_Hanghoa.DataBindings.Add(new Binding("EditValue", ds_Hanghoa_Ban.Tables[0], "Ma_Hanghoa"));
            txtTen_hanghoa.DataBindings.Add(new Binding("EditValue", ds_Hanghoa_Ban.Tables[0], "Ten_hanghoa"));
            txtBarcode_Txt.DataBindings.Add(new Binding("EditValue", ds_Hanghoa_Ban.Tables[0], "Barcode_Txt"));
        }
#endregion

        #region  Override

        public override void DisplayInfo()
        {
            LoadMasterData();
            gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];
            gridLookUpEdit_Kho_Hanghoa.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa().ToDataSet().Tables[0];
            base.DisplayInfo();
        }

        public override bool PerformQuery()
        {
            //WaitDialogForm
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            try
            {
                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
                hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);
                hashtableControls.Add(txtMa_Hanghoa, lblMa_Hanghoa.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return false;

                ds_Collection = objWareService.Rptware_Hanghoa_Bangke_Doanhso(
                    dtNgay_Batdau.DateTime
                    , dtNgay_Ketthuc.DateTime
                    , treeListColumn1.TreeList.FocusedNode.GetValue("Ma_Ql")).ToDataSet();

                dgware_Hanghoa_Bangke_Chitiet.DataSource = ds_Collection;
                dgware_Hanghoa_Bangke_Chitiet.DataMember = ds_Collection.Tables[0].TableName;
                bandedGridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            WaitDialogForm.Close();
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            return base.PerformQuery();
        }

        public override bool PerformPrintPreview()
        {
            Reports.rptHanghoa_Bangke_Doanhso rptHanghoa_Bangke_Doanhso = new Ecm.Ware.Reports.rptHanghoa_Bangke_Doanhso();
            DataSets.dsHanghoa_Bangke_Doanhso dsHanghoa_Bangke_Doanhso = new Ecm.Ware.DataSets.dsHanghoa_Bangke_Doanhso();
             GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptHanghoa_Bangke_Doanhso;
            try
            {
                foreach (DataRow dr in ds_Collection.Tables[0].Rows)
                {
                    dsHanghoa_Bangke_Doanhso.Tables["Ware_Hanghoa_Bangke_Doanhthu"].ImportRow(dr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            rptHanghoa_Bangke_Doanhso.DataSource = dsHanghoa_Bangke_Doanhso;
            rptHanghoa_Bangke_Doanhso.txtNgay_Batdau.Text = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", dtNgay_Batdau.EditValue);
            rptHanghoa_Bangke_Doanhso.txtNgay_Ketthuc.Text = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", dtNgay_Ketthuc.EditValue);
            #region Set he so ctrinh - logo, ten cty

            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData});

                rptHanghoa_Bangke_Doanhso.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptHanghoa_Bangke_Doanhso.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptHanghoa_Bangke_Doanhso.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion
            rptHanghoa_Bangke_Doanhso.CreateDocument();
            frmPrintPreview.Text = "Thống kê";
            frmPrintPreview.printControl1.PrintingSystem = rptHanghoa_Bangke_Doanhso.PrintingSystem;
            frmPrintPreview.MdiParent = this.MdiParent;
            frmPrintPreview.Show();
            frmPrintPreview.Activate();
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            return base.PerformPrintPreview();
        }
        #endregion

        #region  Even

        private void txtTen_hanghoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Tree frmware_Dm_Hanghoa_Tree = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Tree();
            //frmware_Dm_Hanghoa_Tree.Text = lblMa_Hanghoa.Text;
            // GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Tree);
            //frmware_Dm_Hanghoa_Tree.ShowDialog();

            //if (frmware_Dm_Hanghoa_Tree.SelectedRow != null)
            //{
            //    txtMa_Hanghoa.EditValue = frmware_Dm_Hanghoa_Tree.SelectedRow["Ma_Ql"];
            //    txtTen_hanghoa.EditValue = frmware_Dm_Hanghoa_Tree.SelectedRow["Ten_Hanghoa"];
            //}
        }

        private void gridLookUpEdit_Nhansu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                //Ecm.Rex.Forms.Frmrex_Nhansu_Dialog frmrex_Nhansu_Dialog = new Ecm.Rex.Forms.Frmrex_Nhansu_Dialog();
                //frmrex_Nhansu_Dialog.Text = "Nhân sự";
                // GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmrex_Nhansu_Dialog);
                //frmrex_Nhansu_Dialog.ShowDialog();
                //if (frmrex_Nhansu_Dialog.Id_Nhansu != null && frmrex_Nhansu_Dialog.Id_Nhansu.Length > 0)
                //{
                //    bandedGridView1.SetFocusedRowCellValue(bandedGridView1.FocusedColumn, frmrex_Nhansu_Dialog.Id_Nhansu[0]);
                //}
            }
        }

        private void gridLookUpEdit_Ten_Hanghoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            //{
            //    Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Tree frmware_Dm_Hanghoa_Tree = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Tree();
            //    frmware_Dm_Hanghoa_Tree.Text = bandedGridView1.FocusedColumn.Caption;
            //     GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Tree);
            //    frmware_Dm_Hanghoa_Tree.ShowDialog();
            //    if (frmware_Dm_Hanghoa_Tree.SelectedRow != null)
            //    {
            //        bandedGridView1.SetFocusedRowCellValue(bandedGridView1.FocusedColumn,
            //            frmware_Dm_Hanghoa_Tree.SelectedRow["Ma_Ql"].ToString().Replace("Pro", ""));
            //    }
            //}
        }

        private void treeList1_AfterExpand(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            treeListColumn1.TreeList.BestFitColumns();
        }
        #endregion
    }
}