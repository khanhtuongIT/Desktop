using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Bar.Forms
{
    public partial class Frmbar_Winecard : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = new WebReferences.Classes.BarService();
        Ecm.WebReferences.Classes.RexService objRexService = new WebReferences.Classes.RexService();

        DataSet ds_Hanghoa_Ban;
        DataSet ds_Khachhang;
        DataSet dsNhansu;
        DataSet dsBar_Winecard;
        DataSet dsHeso_Chuongtrinh;
        object CurrentId_Cuahang_Ban;
        object CurrentId_Nhansu;
        #region local data

        DataSet dsSys_Lognotify_db = null;
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_KHACHHANG = @"Resources\localdata\Ware_Dm_Khachhang.xml";

        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_rex_nhansu;
        DateTime dtlc_ware_dm_khachhang;

        #endregion

        public Frmbar_Winecard()
        {
            InitializeComponent();
            //get id_cuahang dua vao vi tri cua may ban hang - set tu Frmware_SetLocation
            CurrentId_Cuahang_Ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            lookUpEditSearch_Cuahang_Ban.EditValue = Convert.ToInt64(CurrentId_Cuahang_Ban);
            dtSearch_ThangNam.EditValue = objBarService.GetServerDateTime();
            CurrentId_Nhansu = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            DisplayInfo();
        }

        #region Load local data
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

        void LoadMasterData()
        {         

            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            //load data from local xml when last change at local differ from database
            dsSys_Lognotify_db = objMasterService.GetAll_Sys_Lognotify().ToDataSet();
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_hanghoa_ban], "
                             + " [rex_nhansu], [ware_dm_khachhang]").ToDataSet();

            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
            dtlc_ware_dm_khachhang = GetLastChange_FrmLognotify("WARE_DM_KHACHHANG");

            if (DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0
                || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN))
            {
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                ds_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (ds_Hanghoa_Ban == null || ds_Hanghoa_Ban.Tables.Count == 0)
            {
                ds_Hanghoa_Ban = new DataSet();
                ds_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }
            if (DateTime.Compare(dtlc_ware_dm_khachhang, System.IO.File.GetLastWriteTime(xml_WARE_DM_KHACHHANG)) > 0
                || !System.IO.File.Exists(xml_WARE_DM_KHACHHANG))
            {
                ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                ds_Khachhang.WriteXml(xml_WARE_DM_KHACHHANG, XmlWriteMode.WriteSchema);
            }
            else
            {
                ds_Khachhang = new DataSet();
                ds_Khachhang.ReadXml(xml_WARE_DM_KHACHHANG);
            }
            if (DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0
                || !System.IO.File.Exists(xml_REX_NHANSU))
            {
                dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                dsNhansu.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else if (dsNhansu == null || dsNhansu.Tables.Count == 0)
            {
                dsNhansu = new DataSet();
                dsNhansu.ReadXml(xml_REX_NHANSU);
            }

            //lookUpEdit_Nhansu_Cash
            gridLookUpEdit_Nhansu.DataSource = dsNhansu.Tables[0];
            lookUpEdit_Nhansu_Lap.Properties.DataSource = dsNhansu.Tables[0];
            lookUpEdit_Nhansu_Xnhan.Properties.DataSource = dsNhansu.Tables[0];
            lookUpEdit_Nhansu_Return.Properties.DataSource = dsNhansu.Tables[0];

            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            lookUpEditHanghoa_Ban.Properties.DataSource = ds_Hanghoa_Ban.Tables[0];
            lookUpEditSearch_Khachhang.Properties.DataSource = ds_Khachhang.Tables[0];
            lookUpEditKhachhang.Properties.DataSource = ds_Khachhang.Tables[0];
            gridLookUpEdit_Ma_Khachhang.DataSource = ds_Khachhang.Tables[0];
            gridLookUpEdit_Ten_Khachhang.DataSource = ds_Khachhang.Tables[0];
        }
        #endregion

        public override void ClearDataBindings()
        {            
            base.ClearDataBindings();
        }

        public override void DataBindingControl()
        {
            try
            {
                //clear
                txtSo_Chungtu.DataBindings.Clear();
                dtNgay_Batdau.DataBindings.Clear();
                dtNgay_Ketthuc.DataBindings.Clear();
                dtNgay_Return.DataBindings.Clear();
                lookUpEdit_Nhansu_Lap.DataBindings.Clear();
                lookUpEdit_Nhansu_Xnhan.DataBindings.Clear();
                lookUpEdit_Nhansu_Return.DataBindings.Clear();
                lookUpEditKhachhang.DataBindings.Clear();
                lookUpEditHanghoa_Ban.DataBindings.Clear();
                memoGhichu.DataBindings.Clear();

                //add
                this.txtSo_Chungtu.DataBindings.Add("EditValue", dsBar_Winecard, dsBar_Winecard.Tables[0].TableName + ".So_Chungtu");
                this.dtNgay_Batdau.DataBindings.Add("EditValue", dsBar_Winecard, dsBar_Winecard.Tables[0].TableName + ".Ngay_Batdau");
                this.dtNgay_Ketthuc.DataBindings.Add("EditValue", dsBar_Winecard, dsBar_Winecard.Tables[0].TableName + ".Ngay_Ketthuc");
                this.dtNgay_Return.DataBindings.Add("EditValue", dsBar_Winecard, dsBar_Winecard.Tables[0].TableName + ".Ngay_Return");
                this.lookUpEdit_Nhansu_Lap.DataBindings.Add("EditValue", dsBar_Winecard, dsBar_Winecard.Tables[0].TableName + ".Id_Nhansu_Lap");
                this.lookUpEdit_Nhansu_Xnhan.DataBindings.Add("EditValue", dsBar_Winecard, dsBar_Winecard.Tables[0].TableName + ".Id_Nhansu_Xnhan");
                this.lookUpEdit_Nhansu_Return.DataBindings.Add("EditValue", dsBar_Winecard, dsBar_Winecard.Tables[0].TableName + ".Id_Nhansu_Return");
                this.lookUpEditKhachhang.DataBindings.Add("EditValue", dsBar_Winecard, dsBar_Winecard.Tables[0].TableName + ".Id_Khachhang");
                this.lookUpEditHanghoa_Ban.DataBindings.Add("EditValue", dsBar_Winecard, dsBar_Winecard.Tables[0].TableName + ".Id_Hanghoa_Ban");
                this.memoGhichu.DataBindings.Add("EditValue", dsBar_Winecard, dsBar_Winecard.Tables[0].TableName + ".Ghichu");

            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.StackTrace);
            }
            base.DataBindingControl();
        }

        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();
                if (lookUpEditSearch_Cuahang_Ban.Properties.DataSource == null)
                    lookUpEditSearch_Cuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
                dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();                

                this.dsBar_Winecard = objBarService.Get_All_Bar_Winecard(
                    CurrentId_Cuahang_Ban, 
                    (""+dtSearch_ThangNam.EditValue != "") ? dtSearch_ThangNam.EditValue : null,
                    ("" + lookUpEditSearch_Khachhang.EditValue != "") ? lookUpEditSearch_Khachhang.EditValue : null).ToDataSet();
               
                dgBar_Winecard.DataSource = dsBar_Winecard;
                dgBar_Winecard.DataMember = dsBar_Winecard.Tables[0].TableName;
                gvBar_Winecard.BestFitColumns();

                btnXnhan_Nhap.Enabled = ("" + gvBar_Winecard.GetFocusedRowCellValue("Id_Nhansu_Xnhan") == "");
                btnXnhan_Xuat.Enabled = ("" + gvBar_Winecard.GetFocusedRowCellValue("Id_Nhansu_Xnhan") != "")
                                        && ("" + gvBar_Winecard.GetFocusedRowCellValue("Id_Nhansu_Return") == "");
                
                ResetText();
                this.DataBindingControl();
                this.ChangeStatus(false);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.StackTrace);
            }
            base.DisplayInfo();
        }

        public override void ChangeStatus(bool editTable)
        {
            txtSo_Chungtu.Properties.ReadOnly = !editTable;
            dtNgay_Batdau.Properties.ReadOnly = !editTable;
            dtNgay_Ketthuc.Properties.ReadOnly = !editTable;
            lookUpEdit_Nhansu_Lap.Properties.ReadOnly = true;
            lookUpEdit_Nhansu_Xnhan.Properties.ReadOnly = true;
            lookUpEditKhachhang.Properties.ReadOnly = !editTable;
            lookUpEditKhachhang.Properties.Buttons[1].Enabled = editTable;
            lookUpEditHanghoa_Ban.Properties.ReadOnly = !editTable;
            lookUpEditHanghoa_Ban.Properties.Buttons[1].Enabled = editTable;
            memoGhichu.Properties.ReadOnly = !editTable;
            btnSearch_Winecard.Enabled = !editTable;           

            dgBar_Winecard.Enabled = !editTable;
            gvBar_Winecard.OptionsBehavior.ReadOnly = true;

            dtSearch_ThangNam.Properties.ReadOnly = editTable;
            lookUpEditSearch_Khachhang.Properties.ReadOnly = editTable;

            base.ChangeStatus(editTable);
        }

        public override void ResetText()
        {
            txtSo_Chungtu.EditValue = null;
            dtNgay_Batdau.EditValue = null;
            dtNgay_Ketthuc.EditValue = null;
            dtNgay_Return.EditValue = null;
            lookUpEdit_Nhansu_Lap.EditValue = null;
            lookUpEdit_Nhansu_Xnhan.EditValue = null;
            lookUpEdit_Nhansu_Return.EditValue = null;
            lookUpEditKhachhang.EditValue = null;
            lookUpEditHanghoa_Ban.EditValue = null;
            memoGhichu.EditValue = null;
            base.ResetText();
        }

        public override bool PerformAdd()
        {

            DataSet ds_Cuahang_Ban_ByNhansu = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(CurrentId_Nhansu).ToDataSet();
            var sdr = ds_Cuahang_Ban_ByNhansu.Tables[0].Select(string.Format("Id_Cuahang_Ban={0}", CurrentId_Cuahang_Ban));
            if (sdr == null || sdr.Length == 0)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn không có quyền thao tác trên cửa hàng " + lookUpEditSearch_Cuahang_Ban.Text + "\n vui lòng hủy thao tác");
                ChangeStatus(false);
            }
            else
            {
                ChangeStatus(true);
                ResetText();

                dtNgay_Batdau.EditValue = objBarService.GetServerDateTime();
                dtNgay_Ketthuc.EditValue = dtNgay_Batdau.DateTime.AddDays(30);
                lookUpEdit_Nhansu_Lap.EditValue = Convert.ToInt64( CurrentId_Nhansu );
                txtSo_Chungtu.EditValue = "" + objBarService.GetNew_Sochungtu("bar_winecard", "So_Chungtu", "WICA.");

            }

            return base.PerformAdd();
        }

        public override bool PerformEdit()
        {
            try
            {
                if (gvBar_Winecard.GetFocusedRowCellValue("Id_Winecard") == null)
                    return false;
                if (!string.IsNullOrWhiteSpace(""+ gvBar_Winecard.GetFocusedRowCellValue("Id_Nhansu_Xnhan")))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                    return false;
                }
                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Lap.EditValue))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
                ChangeStatus(true);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }

            return base.PerformEdit();
        }

        public override bool PerformDelete()
        {
            try
            {
                if (gvBar_Winecard.GetFocusedRowCellValue("Id_Winecard") == null)
                    return false;
                if (!string.IsNullOrWhiteSpace("" + gvBar_Winecard.GetFocusedRowCellValue("Id_Nhansu_Xnhan")))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                    return false;
                }
                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Lap.EditValue))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }

                if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {this.Text, this.Text  }) == DialogResult.Yes)
                {
                    objBarService.Delete_Bar_Winecard(new WebReferences.BarService.Bar_Winecard()
                    {
                        Id_Winecard = gvBar_Winecard.GetFocusedRowCellValue("Id_Winecard"),
                    });
                }
                DisplayInfo();

                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }
            return base.PerformDelete();
        }

        public override bool PerformCancel()
        {
            ChangeStatus(false);
            DisplayInfo();
            return base.PerformCancel();
        }

        public override bool PerformSave()
        {
            try
            {
                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(lookUpEditKhachhang,lblKhachhang.Text);
                hashtableControls.Add(lookUpEditHanghoa_Ban, lblHanghoa_Ban.Text);
                hashtableControls.Add(memoGhichu, lblGhichu.Text);               

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    var Id_Winecard = objBarService.Insert_Bar_Winecard(new WebReferences.BarService.Bar_Winecard()
                     {
                         Ghichu = memoGhichu.EditValue,
                         Id_Cuahang_Ban = CurrentId_Cuahang_Ban,
                         Id_Hanghoa_Ban = lookUpEditHanghoa_Ban.EditValue,
                         Id_Khachhang = lookUpEditKhachhang.EditValue,
                         Id_Nhansu_Lap = CurrentId_Nhansu,
                         Id_Nhansu_Xnhan = (""+lookUpEdit_Nhansu_Xnhan.EditValue != "") ? lookUpEdit_Nhansu_Xnhan.EditValue : null,
                         Ngay_Batdau = dtNgay_Batdau.EditValue,
                         Ngay_Ketthuc = dtNgay_Ketthuc.EditValue,
                         So_Chungtu = txtSo_Chungtu.EditValue,
                     });
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    objBarService.Update_Bar_Winecard(new WebReferences.BarService.Bar_Winecard()
                    {
                        Id_Winecard = gvBar_Winecard.GetFocusedRowCellValue("Id_Winecard"),
                        Ghichu = memoGhichu.EditValue,
                        Id_Cuahang_Ban = CurrentId_Cuahang_Ban,
                        Id_Hanghoa_Ban = lookUpEditHanghoa_Ban.EditValue,
                        Id_Khachhang = lookUpEditKhachhang.EditValue,
                        Id_Nhansu_Lap = CurrentId_Nhansu,
                        Id_Nhansu_Xnhan = ("" + lookUpEdit_Nhansu_Xnhan.EditValue != "") ? lookUpEdit_Nhansu_Xnhan.EditValue : null,
                        Ngay_Batdau = dtNgay_Batdau.EditValue,
                        Ngay_Ketthuc = dtNgay_Ketthuc.EditValue,
                        So_Chungtu = txtSo_Chungtu.EditValue,
                    });
                }

                DisplayInfo();

                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.StackTrace);
                return false;
            }
            return base.PerformSave();
        }

        public override bool PerformPrintPreview()
        {
            Print(gvBar_Winecard.GetFocusedRowCellValue("Id_Winecard"));
            return base.PerformPrintPreview();
        }

        public void Print(object Id_Winecard)
        {
            var drWinecard = objBarService.GetBar_Winecard_ById(Id_Winecard).ToDataSet().Tables[0].Rows[0];

            if (string.IsNullOrWhiteSpace("" + drWinecard["Id_Nhansu_Xnhan"]))
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return ;
            }

            Ecm.Bar.Reports.rptBar_Winecard rptBar_Winecard = new Ecm.Bar.Reports.rptBar_Winecard();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptBar_Winecard;

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
                rptBar_Winecard.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptBar_Winecard.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptBar_Winecard.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            rptBar_Winecard.xrcSo_Chungtu.Text = "" + drWinecard["So_Chungtu"];
            rptBar_Winecard.xrbcSo_Chungtu.Text = "" + drWinecard["So_Chungtu"];//barcode
            rptBar_Winecard.xrcNgay_Batdau.Text = "" + drWinecard["Ngay_Batdau"];
            rptBar_Winecard.xrcTen_Khachhang.Text = "" + drWinecard["Ten_Khachhang"];
            rptBar_Winecard.xrcDienthoai.Text = "" + drWinecard["Dienthoai"];
            rptBar_Winecard.xrcTen_Hanghoa_Ban.Text = "" + drWinecard["Ten_Hanghoa_Ban"];
            rptBar_Winecard.xrcGhichu.Text = "" + drWinecard["Ghichu"];

            rptBar_Winecard.CreateDocument();

            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptBar_Winecard);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                frmPrintPreview.Text = "" + oReportOptions.Caption;
                frmPrintPreview.printControl1.PrintingSystem = rptBar_Winecard.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Text = this.Text + "(Xem trang in)";
                frmPrintPreview.Show();
                frmPrintPreview.Activate();
            }
            else
            {
                var ReportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptBar_Winecard);
                ReportPrintTool.Print();
            }

        }

        #region Search
        private void btnSearch_Winecard_Click(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void lookUpEdit_Cuahang_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                var _Frmware_Dm_Cuahang_Ban_Add = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterTables.dll", "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Cuahang_Ban_Add", this);
            }
            else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lookUpEditSearch_Cuahang_Ban.EditValue = null;
            }

        }

        private void dtSearch_ThangNam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                dtSearch_ThangNam.EditValue = null;
            }

        }

        private void lookUpEditSearch_Khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                    "Ecm.MasterTables.dll",
                    "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add", this);

                var SelectedObject = dialog.GetType().GetProperty("SelectedWare_Dm_Khachhang").GetValue(dialog, null)
                   as Ecm.WebReferences.MasterService.Ware_Dm_Khachhang;

                if (SelectedObject != null)
                {
                    lookUpEditSearch_Khachhang.EditValue = Convert.ToInt64(SelectedObject.Id_Khachhang);
                }
            }
            else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lookUpEditSearch_Khachhang.EditValue = null;
            }

        }

        #endregion

        private void lookUpEditKhachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                    "Ecm.MasterTables.dll",
                    "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add", this);
                var SelectedObject = dialog.GetType().GetProperty("SelectedWare_Dm_Khachhang").GetValue(dialog, null)
                   as Ecm.WebReferences.MasterService.Ware_Dm_Khachhang;

                if (SelectedObject != null)
                {
                    lookUpEditKhachhang.EditValue = Convert.ToInt64(SelectedObject.Id_Khachhang);
                }

            }
            else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEditKhachhang.EditValue = null;
        }

        private void lookUpEditHanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                try
                {
                    var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                        "Ecm.MasterTables.dll",
                        "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

                    if (dialog == null)
                        return;
                    var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;

                    if (SelectedObject != null)
                        lookUpEditHanghoa_Ban.EditValue = Convert.ToInt64(SelectedObject.Id_Hanghoa_Ban);
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
            }
            else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEditHanghoa_Ban.EditValue = null;
        }

        private void gvBar_Winecard_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnXnhan_Nhap.Enabled = ("" + gvBar_Winecard.GetFocusedRowCellValue("Id_Nhansu_Xnhan") == "");
            btnXnhan_Xuat.Enabled = ("" + gvBar_Winecard.GetFocusedRowCellValue("Id_Nhansu_Xnhan") != "")
                                    && ("" + gvBar_Winecard.GetFocusedRowCellValue("Id_Nhansu_Return") == "");
        }

        private void btnXnhan_Nhap_Click(object sender, EventArgs e)
        {
            //neu thay doi field KM(Per_Dongia) --> phai xac nhan nguoi thay doi co quyen hay khong
            GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions = GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
            if (Actions.Count == 0 || !Actions.Contains("EnableHold"))
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return ;
            }
            else
            {
                lookUpEdit_Nhansu_Xnhan.EditValue = Convert.ToInt64( Actions.Id_Nhansu );
                var _Id_Winecard = gvBar_Winecard.GetFocusedRowCellValue("Id_Winecard");
                objBarService.Update_Bar_Winecard(new WebReferences.BarService.Bar_Winecard()
                {
                    Id_Winecard = _Id_Winecard,
                    Ghichu = memoGhichu.EditValue,
                    Id_Cuahang_Ban = CurrentId_Cuahang_Ban,
                    Id_Hanghoa_Ban = lookUpEditHanghoa_Ban.EditValue,
                    Id_Khachhang = lookUpEditKhachhang.EditValue,
                    Id_Nhansu_Lap = CurrentId_Nhansu,
                    Id_Nhansu_Xnhan = Convert.ToInt64(Actions.Id_Nhansu),
                    Ngay_Batdau = dtNgay_Batdau.EditValue,
                    Ngay_Ketthuc = dtNgay_Ketthuc.EditValue,
                    So_Chungtu = txtSo_Chungtu.EditValue,
                });

                //in phieu
                Print(_Id_Winecard);
                DisplayInfo();
            }
        }

        private void btnXnhan_Xuat_Click(object sender, EventArgs e)
        {
            GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions = GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
            if (Actions.Count == 0 || !Actions.Contains("EnableReturn"))
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return;
            }
            else
            {
                objBarService.Update_Bar_Winecard(new WebReferences.BarService.Bar_Winecard()
                {
                    Id_Winecard = gvBar_Winecard.GetFocusedRowCellValue("Id_Winecard"),
                    Ghichu = memoGhichu.EditValue,
                    Id_Cuahang_Ban = CurrentId_Cuahang_Ban,
                    Id_Hanghoa_Ban = lookUpEditHanghoa_Ban.EditValue,
                    Id_Khachhang = lookUpEditKhachhang.EditValue,
                    Id_Nhansu_Lap = CurrentId_Nhansu,
                    Id_Nhansu_Xnhan = ("" + lookUpEdit_Nhansu_Xnhan.EditValue != "") ? lookUpEdit_Nhansu_Xnhan.EditValue : null,
                    Ngay_Batdau = dtNgay_Batdau.EditValue,
                    Ngay_Ketthuc = dtNgay_Ketthuc.EditValue,
                    So_Chungtu = txtSo_Chungtu.EditValue,

                    Id_Nhansu_Return = Actions.Id_Nhansu,
                    Ngay_Return = objBarService.GetServerDateTime(),
                });

                DisplayInfo();
            }
        }

        

    }
}