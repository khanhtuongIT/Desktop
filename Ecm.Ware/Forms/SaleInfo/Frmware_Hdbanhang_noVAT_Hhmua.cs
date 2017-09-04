using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_Hdbanhang_noVAT_Hhmua : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public WareService.WareService objWareService = new SunLine.Ware.WareService.WareService();
        public RexService.RexService objRexService = new SunLine.Ware.RexService.RexService();
        public MasterService.MasterService objMasterService = new SunLine.Ware.MasterService.MasterService();

        DataSet ds_Hdbanhang = new DataSet();
        DataSet ds_Hdbanhang_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Mua;
        DataSet dsDm_Loai_Hanghoa_Mua;
        DataSet dsCtrinh_Kmai_Chitiet;
        DataSet ds_Khachhang;
        DataSet ds_Nhansu;

        object identity;
        double thanhtien;
        decimal vip_per_dongia = 0;
        int Id_Nhansu_Km = -1;
        bool AllowEdit_Per_Dongia = false;
        object sotien_mat;
        object sotien_thua;
        object LocationId_Kho_Hanghoa_Mua;

        #region local data
        bool Exists_Sys_Lognotify_Path = false;
        DataSet dsSys_Lognotify = null;

        string log_WARE_DM_HANGHOA_MUA = "init";
        string log_WARE_HANGHOA_DINHGIA = "init";
        string log_WARE_HH_KHO_HANGHOA_MUA = "init";
        string log_REX_NHANSU = "init";
        string log_CTRINH_KMAI_CHITIET = "init";
        string log_WARE_DM_KHACHHANG = "init";

        string Sys_Lognotify_Path = @"Resources\localdata\SYS_LOGNOTIFY.xml";
        string xml_WARE_DM_LOAI_HANGHOA_MUA = @"Resources\localdata\WARE_DM_LOAI_HANGHOA_MUA_BYLOCATION.xml";
        string xml_WARE_DM_HANGHOA_MUA = @"Resources\localdata\WARE_DM_HANGHOA_MUA_BYLOCATION.xml";
        string xml_REX_NHANSU = @"Resources\localdata\REX_NHANSU.xml";
        string xml_WARE_CTRINH_KMAI_CHITIET = @"Resources\localdata\WARE_CTRINH_KMAI_CHITIET.xml";
        string xml_WARE_DM_KHACHHANG = @"Resources\localdata\WARE_DM_KHACHHANG.xml";

        #endregion


        public Frmware_Hdbanhang_noVAT_Hhmua()
        {
            InitializeComponent();

            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            //date mask
            //dtNgay_Chungtu.Properties.Mask.UseMaskAsDisplayFormat = true;
            //dtNgay_Chungtu.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            //this.DisplayInfo();

            xtraTabControl2.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            lblStatus_Bar.Text = "";
            ShowLogonForm();
            ShowTabPage(xtraTabControl2, xtraTabPage_Logon);

            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;

        }

        Color GetColor(int index)
        {
            Color color = Color.BlueViolet;
            switch (index)
            {
                case 0:
                    color = Color.AliceBlue;
                    break;
                case 1:
                    color = Color.AntiqueWhite;
                    break;
                case 2:
                    color = Color.LightGreen;
                    break;
                case 3:
                    color = Color.Pink;
                    break;
                case 4:
                    color = Color.Yellow;
                    break;
                case 5:
                    color = Color.Cyan;
                    break;
                case 6:
                    color = Color.Bisque;
                    break;
                case 7:
                    color = Color.Tomato;
                    break;
                case 8:
                    color = Color.BlueViolet;
                    break;
            }
            return color;
        }

        public override void DisplayInfo()
        {
            try
            {
                gridColumn13.Visible = true;
                lblStatus_Bar.Text = "";
                BarSystem.Visible = false;

                //Get data Kho_Hanghoa_Mua
                lookUpEdit_Kho_Hanghoa_Mua.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua().Tables[0];
                //get id_cuahang dua vao vi tri cua may ban hang - set tu Frmware_SetLocation
                LocationId_Kho_Hanghoa_Mua = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocationId_Kho_Hanghoa_Mua();
                lookUpEdit_Kho_Hanghoa_Mua.EditValue = Convert.ToInt64(LocationId_Kho_Hanghoa_Mua);

                //Get data Ware_Dm_Donvitinh
                gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua
                GetDmHanghoaMua_ByKhoHanghoaMua();


                //Get data Ware_Hdbanhang
                ds_Hdbanhang = objWareService.Get_All_Ware_Hdbanhang_Novat_Hhmua_ByKhohh(lookUpEdit_Kho_Hanghoa_Mua.EditValue);
                dgware_Hdbanhang.DataSource = ds_Hdbanhang;
                dgware_Hdbanhang.DataMember = ds_Hdbanhang.Tables[0].TableName;



                txtKm_All.Enabled = false;
                txtMa_Khachhang.Enabled = false;

                ClearDataBindings();
                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
                if (gridView1.RowCount > 0)
                {
                    gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                    gridView1.Focus();
                }

                DisplayInfo2();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                //GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        void GetDmHanghoaMua_ByKhoHanghoaMua()
        {
            string vlog_WARE_DM_HANGHOA_MUA = log_WARE_DM_HANGHOA_MUA;
            string vlog_WARE_HANGHOA_DINHGIA = log_WARE_HANGHOA_DINHGIA;
            string vlog_WARE_HH_KHO_HANGHOA_MUA = log_WARE_HH_KHO_HANGHOA_MUA;
            string vlog_REX_NHANSU = log_REX_NHANSU;
            string vlog_CTRINH_KMAI_CHITIET = log_CTRINH_KMAI_CHITIET;
            string vlog_WARE_DM_KHACHHANG = log_WARE_DM_KHACHHANG;

            Exists_Sys_Lognotify_Path = System.IO.File.Exists(Sys_Lognotify_Path);
            if (Exists_Sys_Lognotify_Path)
            {
                //get last change at local
                dsSys_Lognotify = new DataSet();
                dsSys_Lognotify.ReadXml(Sys_Lognotify_Path);

                //write new log change from database --> write to local last change
                DataSet dsSys_Lognotify_db = objMasterService.GetAll_Sys_Lognotify();
                bool haschange_atlast = false;
                foreach (DataRow dr in dsSys_Lognotify_db.Tables[0].Rows)
                {
                    DataRow[] sdr = dsSys_Lognotify.Tables[0].Select("Table_Name = '" + dr["table_name"] + "'");
                    if (sdr == null || sdr.Length == 0)
                        haschange_atlast = true;
                    else if ("" + sdr[0]["Last_Change"] != "" + dr["Last_Change"])
                        haschange_atlast = true;

                    if (haschange_atlast) break;
                }

                if (haschange_atlast)
                {
                    dsSys_Lognotify_db.WriteXml(Sys_Lognotify_Path, XmlWriteMode.WriteSchema);

                    log_WARE_DM_HANGHOA_MUA = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'").Length > 0)
                    ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'")[0]["Last_Change"] : "";
                    log_WARE_HANGHOA_DINHGIA = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'")[0]["Last_Change"] : "";
                    log_WARE_HH_KHO_HANGHOA_MUA = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_HH_KHO_HANGHOA_MUA'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_HH_KHO_HANGHOA_MUA'")[0]["Last_Change"] : "";
                    log_REX_NHANSU = (dsSys_Lognotify.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";
                    log_CTRINH_KMAI_CHITIET = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_CTRINH_KMAI'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_CTRINH_KMAI'")[0]["Last_Change"] : "";
                    log_WARE_DM_KHACHHANG = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'")[0]["Last_Change"] : "";

                    vlog_WARE_DM_HANGHOA_MUA = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'")[0]["Last_Change"] : "";
                    vlog_WARE_HANGHOA_DINHGIA = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'")[0]["Last_Change"] : "";
                    vlog_WARE_HH_KHO_HANGHOA_MUA = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_HH_KHO_HANGHOA_MUA'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_HH_KHO_HANGHOA_MUA'")[0]["Last_Change"] : "";
                    vlog_REX_NHANSU = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";
                    vlog_CTRINH_KMAI_CHITIET = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_CTRINH_KMAI'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_CTRINH_KMAI'")[0]["Last_Change"] : "";
                    vlog_WARE_DM_KHACHHANG = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_KHACHHANG'")[0]["Last_Change"] : "";

                }
            }
            else
            {
                dsSys_Lognotify = new DataSet();
                dsSys_Lognotify = objMasterService.GetAll_Sys_Lognotify();
                dsSys_Lognotify.WriteXml(Sys_Lognotify_Path, XmlWriteMode.WriteSchema);
            }

            //load data from local xml when last change at local differ from database
            if (vlog_WARE_DM_HANGHOA_MUA + vlog_WARE_HANGHOA_DINHGIA + vlog_WARE_HH_KHO_HANGHOA_MUA
                != log_WARE_DM_HANGHOA_MUA + log_WARE_HANGHOA_DINHGIA + log_WARE_HH_KHO_HANGHOA_MUA
                || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_MUA))
            {
                ds_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(LocationId_Kho_Hanghoa_Mua, DateTime.Now);
                ds_Hanghoa_Mua.WriteXml(xml_WARE_DM_HANGHOA_MUA, XmlWriteMode.WriteSchema);

                dsDm_Loai_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Mua_SelectBy_Id_Kho_HH_Mua(LocationId_Kho_Hanghoa_Mua);
                dsDm_Loai_Hanghoa_Mua.WriteXml(xml_WARE_DM_LOAI_HANGHOA_MUA, XmlWriteMode.WriteSchema);
            }
            else if (ds_Hanghoa_Mua == null || ds_Hanghoa_Mua.Tables.Count == 0)
            {
                ds_Hanghoa_Mua = new DataSet();
                ds_Hanghoa_Mua.ReadXml(xml_WARE_DM_HANGHOA_MUA);

                dsDm_Loai_Hanghoa_Mua = new DataSet();
                dsDm_Loai_Hanghoa_Mua.ReadXml(xml_WARE_DM_LOAI_HANGHOA_MUA);
            }

            if (vlog_WARE_DM_KHACHHANG != log_WARE_DM_KHACHHANG || !System.IO.File.Exists(xml_WARE_DM_KHACHHANG))
            {
                ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang();
                ds_Khachhang.WriteXml(xml_WARE_DM_KHACHHANG, XmlWriteMode.WriteSchema);
            }
            else if (ds_Khachhang == null || ds_Khachhang.Tables.Count == 0)
            {
                ds_Khachhang = new DataSet();
                ds_Khachhang.ReadXml(xml_WARE_DM_KHACHHANG);
            }

            if (log_CTRINH_KMAI_CHITIET != vlog_CTRINH_KMAI_CHITIET || !System.IO.File.Exists(xml_WARE_CTRINH_KMAI_CHITIET))
            {
                dsCtrinh_Kmai_Chitiet = objWareService.Get_All_Ware_Ctrinh_Kmai_Chitiet_ByDate(DateTime.Now);
                dsCtrinh_Kmai_Chitiet.WriteXml(xml_WARE_CTRINH_KMAI_CHITIET, XmlWriteMode.WriteSchema);
            }
            else if (dsCtrinh_Kmai_Chitiet == null || dsCtrinh_Kmai_Chitiet.Tables.Count == 0)
            {
                dsCtrinh_Kmai_Chitiet = new DataSet();
                dsCtrinh_Kmai_Chitiet.ReadXml(xml_WARE_CTRINH_KMAI_CHITIET);
            }

            if (vlog_REX_NHANSU != log_REX_NHANSU || !System.IO.File.Exists(xml_REX_NHANSU))
            {
                ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection();
                ds_Nhansu.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else if (ds_Nhansu == null || ds_Nhansu.Tables.Count == 0)
            {
                ds_Nhansu = new DataSet();
                ds_Nhansu.ReadXml(xml_REX_NHANSU);
            }

            //gridLookUpEdit_Loai_Hanghoa_Mua
            dgware_Dm_Loai_Hanghoa_Mua.DataSource = dsDm_Loai_Hanghoa_Mua;
            dgware_Dm_Loai_Hanghoa_Mua.DataMember = dsDm_Loai_Hanghoa_Mua.Tables[0].TableName;
            gridLookUpEdit_Loai_Hanghoa_Mua.DataSource = dsDm_Loai_Hanghoa_Mua.Tables[0];
            //set color
            int i = Convert.ToInt32(dsDm_Loai_Hanghoa_Mua.Tables[0].Rows[0]["Id_Loai_Hanghoa_Mua"]);
            foreach (DataRow drLoai_Hanghoa_Mua in dsDm_Loai_Hanghoa_Mua.Tables[0].Rows)
            {
                DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                styleFormatCondition.Appearance.BackColor = GetColor(Convert.ToInt32(drLoai_Hanghoa_Mua["Id_Loai_Hanghoa_Mua"]) % i);
                styleFormatCondition.Appearance.Options.UseBackColor = true;
                styleFormatCondition.ApplyToRow = true;
                styleFormatCondition.Column = this.cardView2.Columns["Id_Loai_Hanghoa_Mua"];
                styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                styleFormatCondition.Value1 = Convert.ToInt32(drLoai_Hanghoa_Mua["Id_Loai_Hanghoa_Mua"]);
                this.cardView2.FormatConditions.Add(styleFormatCondition);
            }

            //dgware_Dm_Hanghoa_Mua          
            gridLookUpEdit_Hanghoa_Mua.DataSource = ds_Hanghoa_Mua.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Mua.DataSource = ds_Hanghoa_Mua.Tables[0];
            dgware_Dm_Hanghoa_Mua.DataSource = ds_Hanghoa_Mua.Tables[0];

            //khach hang
            lookUpEdit_Khachhang.Properties.DataSource = ds_Khachhang.Tables[0];

            //Get data Rex_Nhansu
            lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
            lookUpEdit_Nhansu_Banhang.EditValue = System.Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());

            //set color
            //int i = Convert.ToInt32(ds_Hanghoa_Mua.Tables[0].Rows[0]["Id_Loai_Hanghoa_Mua"]);
            //foreach (DataRow drLoai_Hanghoa_Mua in ds_Hanghoa_Mua.Tables[0].Rows)
            //{

            //    DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            //    styleFormatCondition.Appearance.BackColor = GetColor(Convert.ToInt32(drLoai_Hanghoa_Mua["Id_Loai_Hanghoa_Mua"]) % i);
            //    styleFormatCondition.Appearance.Options.UseBackColor = true;
            //    styleFormatCondition.ApplyToRow = true;
            //    styleFormatCondition.Column = this.cardView1.Columns["Id_Loai_Hanghoa_Mua"];
            //    styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            //    styleFormatCondition.Value1 = Convert.ToInt32(drLoai_Hanghoa_Mua["Id_Loai_Hanghoa_Mua"]);
            //    this.cardView1.FormatConditions.Add(styleFormatCondition);
            //}
        }

        void SetDsHanghoa_ByNhansu()
        {
            //Kiểm tra nếu nhân viên login không tồn tại trong kho hàng hóa mua thì access denied.
            lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            DataSet ds_Kho_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_MuaBy_Id_Nhansu(lookUpEdit_Nhansu_Banhang.EditValue);
            if (ds_Kho_Hanghoa_Mua.Tables[0].Rows.Count > 0)
            {
                lookUpEdit_Kho_Hanghoa_Mua.EditValue = ds_Kho_Hanghoa_Mua.Tables[0].Rows[0]["Id_Kho_Hanghoa_Mua"];
                ds_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(lookUpEdit_Kho_Hanghoa_Mua.EditValue, dtNgay_Chungtu.EditValue);
                gridLookUpEdit_Hanghoa_Mua.DataSource = ds_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Ma_Hanghoa_Mua.DataSource = ds_Hanghoa_Mua.Tables[0];

            }
            //Get data Ware_Hdbanhang
            ds_Hdbanhang = objWareService.Get_All_Ware_Hdbanhang_Novat_Hhmua_ByKhohh(lookUpEdit_Kho_Hanghoa_Mua.EditValue);
            dgware_Hdbanhang.DataSource = ds_Hdbanhang;
            dgware_Hdbanhang.DataMember = ds_Hdbanhang.Tables[0].TableName;

        }
        void ClearDataBindings()
        {
            this.txtId_Hdbanhang.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtSotien.DataBindings.Clear();
            this.txtSotien_Vat.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();

            this.lookUpEdit_Kho_Hanghoa_Mua.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Banhang.DataBindings.Clear();

            lookUpEdit_Khachhang.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Hdbanhang.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Hdbanhang");
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Sochungtu");
                this.txtSotien.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Sotien");
                this.txtSotien_Vat.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Sotien_Vat");

                this.dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Ngay_Chungtu");

                this.lookUpEdit_Kho_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Kho_Hanghoa_Mua");
                this.lookUpEdit_Nhansu_Banhang.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Nhansu_Bh");

                lookUpEdit_Khachhang.DataBindings.Add("EditValue", ds_Hdbanhang, ds_Hdbanhang.Tables[0].TableName + ".Id_Khachhang");

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                //GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            this.dgware_Hdbanhang.Enabled = !editTable;
            gridView4.OptionsBehavior.Editable = editTable;

            this.txtId_Hdbanhang.Properties.ReadOnly = !editTable;
            this.txtSochungtu.Properties.ReadOnly = !editTable;
            this.txtSotien.Properties.ReadOnly = !editTable;
            this.txtBarcode_Txt.Properties.ReadOnly = !editTable;
            this.txtSoluong.Properties.ReadOnly = !editTable;
            this.dtNgay_Chungtu.Properties.ReadOnly = !editTable;

            //this.lookUpEdit_Kho_Hanghoa_Mua.Properties.ReadOnly = !editTable;
            //this.lookUpEdit_Nhansu_Banhang.Properties.ReadOnly = !editTable;

            txtMa_Khachhang.Properties.ReadOnly = !editTable;

            txtMa_Khachhang.Properties.ReadOnly = !editTable;

            //  btnLogon.Enabled = !editTable;
        }

        public void ResetText()
        {
            this.txtMin_Quota.EditValue = "";
            lblStatus_Bar.Text = "";
            this.txtId_Hdbanhang.EditValue = "";
            this.txtSochungtu.EditValue = "";
            this.txtSotien.EditValue = "";
            this.txtSotien_Vat.EditValue = "";
            this.txtSotien_Khachtra.EditValue = "";
            this.txtSotien_Thua.EditValue = "";
            txtKm_All.EditValue = "0";
            txtMa_Khachhang.EditValue = "";
            txtSoluong.EditValue = 1;
            //this.dtNgay_Chungtu.EditValue = "";

            //   this.lookUpEdit_Kho_Hanghoa_Mua.EditValue = null;

            lookUpEdit_Khachhang.EditValue = DBNull.Value;

            Id_Nhansu_Km = -1;

            ////begin******
            ////Khi add new: Get id_nhansu login -> Get cửa hàng bán(kho_hh_mua) theo id_nhansu -> Get hàng hóa sản xuất(mua) theo cửa hàng bán(kho_hh_mua)
            ////Kiểm tra nếu cửa hàng bán(kho_hh_mua) != null thì lock <-else-> unlock
            //object Id_Nhansu = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            //this.lookUpEdit_Nhansu_Banhang.EditValue = Id_Nhansu;
            //lookUpEdit_Kho_Hanghoa_Mua.EditValue = objWareService.Get_All_Ware_Dm_Kho_Hanghoa_Mua_By_Id_Nhansu(Id_Nhansu).Tables[0].Rows[0]["Id_Kho_Hanghoa_Mua"];

            //if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
            //    lookUpEdit_Kho_Hanghoa_Mua.Properties.ReadOnly = true;
            //else
            //    lookUpEdit_Kho_Hanghoa_Mua.Properties.ReadOnly = false;
            ////end******


            this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(0);

            // ds_Hdbanhang_Chitiet.Tables[0].Columns.Add("Thanhtien_Km", typeof(decimal));
            this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet;
            this.dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet.Tables[0].TableName;
            dgware_Hdbanhang_Chitiet.RefreshDataSource();
            gridView4.RefreshData();
        }

        #region Event Override
        public object InsertObject()
        {
            try
            {
                WareService.Ware_Hdbanhang objWare_Hdbanhang = new SunLine.Ware.WareService.Ware_Hdbanhang();
                objWare_Hdbanhang.Id_Hdbanhang = -1;
                objWare_Hdbanhang.Sochungtu = txtSochungtu.EditValue;
                objWare_Hdbanhang.Sotien = txtSotien.EditValue;
                objWare_Hdbanhang.Sotien_Vat = txtSotien_Vat.EditValue;
                objWare_Hdbanhang.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Hdbanhang.NoVAT = true;

                if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
                    objWare_Hdbanhang.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;

                if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                {
                    objWare_Hdbanhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;
                    objWare_Hdbanhang.Id_Nhansu_Casher = lookUpEdit_Nhansu_Banhang.EditValue;
                }

                objWare_Hdbanhang.Id_Khachang = ("" + lookUpEdit_Khachhang.EditValue != "") ? lookUpEdit_Khachhang.EditValue : -1;
                objWare_Hdbanhang.Id_Nhansu_Km = Id_Nhansu_Km;

                identity = objWareService.Insert_Ware_Hdbanhang(objWare_Hdbanhang);

                if (identity != null)
                {
                    dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Hdbanhang"] = identity;
                    }
                    //update hdmuahang_chitiet
                    objWareService.Update_Ware_Hdbanhang_Chitiet_Collection(ds_Hdbanhang_Chitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                WareService.Ware_Hdbanhang objWare_Hdbanhang = new SunLine.Ware.WareService.Ware_Hdbanhang();
                objWare_Hdbanhang.Id_Hdbanhang = txtId_Hdbanhang.EditValue;
                objWare_Hdbanhang.Sochungtu = txtSochungtu.EditValue;
                objWare_Hdbanhang.Sotien = txtSotien.EditValue;
                objWare_Hdbanhang.Sotien_Vat = txtSotien_Vat.EditValue;
                objWare_Hdbanhang.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Hdbanhang.NoVAT = true;
                objWare_Hdbanhang.Hoten_Nguoimua = "";
                objWare_Hdbanhang.Per_Vat = 0;
                objWare_Hdbanhang.Phuongthuc_Thanhtoan = "TM";
                objWare_Hdbanhang.So_Seri = "N/A";
                objWare_Hdbanhang.Ngay_Thanhtoan = dtNgay_Chungtu.EditValue;
                objWare_Hdbanhang.Id_Khachang = -1;
                objWare_Hdbanhang.Id_Nhansu_Km = Id_Nhansu_Km;

                if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
                    objWare_Hdbanhang.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;

                if ("" + lookUpEdit_Nhansu_Banhang.EditValue != "")
                    objWare_Hdbanhang.Id_Nhansu_Bh = lookUpEdit_Nhansu_Banhang.EditValue;

                objWare_Hdbanhang.Id_Khachang = ("" + lookUpEdit_Khachhang.EditValue != "") ? lookUpEdit_Khachhang.EditValue : -1;

                //update donmuahang
                objWareService.Update_Ware_Hdbanhang(objWare_Hdbanhang);

                //update donmuahang_chitiet
                dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Hdbanhang"] = txtId_Hdbanhang.EditValue;
                }
                //ds_Hdbanhang_Chitiet.RejectChanges();
                objWareService.Update_Ware_Hdbanhang_Chitiet_Collection(ds_Hdbanhang_Chitiet);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public object DeleteObject()
        {
            WareService.Ware_Hdbanhang objWare_Hdbanhang = new SunLine.Ware.WareService.Ware_Hdbanhang();
            objWare_Hdbanhang.Id_Hdbanhang = txtId_Hdbanhang.EditValue;

            return objWareService.Delete_Ware_Hdbanhang(objWare_Hdbanhang);
        }

        void ShowTabPage(
            DevExpress.XtraTab.XtraTabControl xtraTabControl,
            DevExpress.XtraTab.XtraTabPage xtraTabPage)
        {
            //  if (xtraTabControl.SelectedTabPage == xtraTabPage) return;
            while (xtraTabControl.TabPages.Count > 0)
                xtraTabControl.TabPages.RemoveAt(0);

            xtraTabControl.TabPages.Add(xtraTabPage);
        }


        public override bool PerformAdd()
        {
            this.gridColumn19.Visible = false;
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            changeStatusButton(true);
            this.ResetText();
            repositoryItemButtonEdit3.Buttons[0].Visible = false;
            repositoryItemButtonEdit2.Buttons[0].Visible = true;

            gridColumn13.Visible = true;
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            txtMin_Quota.EditValue = null;


            dtNgay_Chungtu.EditValue = DateTime.Now;
            ClearDataBindings();
            //get id_cuahang dua vao vi tri cua may ban hang - set tu Frmware_SetLocation
            LocationId_Kho_Hanghoa_Mua = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocationId_Kho_Hanghoa_Mua();
            lookUpEdit_Kho_Hanghoa_Mua.EditValue = Convert.ToInt64(LocationId_Kho_Hanghoa_Mua);

            //Get data Ware_Dm_Hanghoa_Mua
            GetDmHanghoaMua_ByKhoHanghoaMua();

            //Kiểm tra nếu nhân viên login không tồn tại trong kho hàng hóa mua thì access denied.
            lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            DataSet ds_Kho_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_MuaBy_Id_Nhansu(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            if (ds_Kho_Hanghoa_Mua.Tables[0].Rows.Count == 0)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                lookUpEdit_Nhansu_Banhang.EditValue = null;
                return false;
            }

            this.ChangeStatus(true);

            txtBarcode_Txt.Focus();
            txtSoluong.EditValue = 1;
            txtSochungtu.EditValue = objWareService.Getnew_Sohoadon_NoVAT(lookUpEdit_Kho_Hanghoa_Mua.GetColumnValue("Ma_Kho_Hanghoa_Mua"));

            AllowEdit_Per_Dongia = false;
            btnCash.Enabled = false;
            return true;
        }

        public override bool PerformEdit()
        {
            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return false;
            }
            this.ChangeStatus(true);
            Id_Nhansu_Km = -1;
            AllowEdit_Per_Dongia = false;
            return true;
        }

        public override bool PerformCancel()
        {
            repositoryItemButtonEdit2.Buttons[0].Visible = false;
            changeStatusButton(false);
            this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet;
            this.dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet.Tables[0].TableName;
            this.DisplayInfo();
            DisplayInfo2();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                htbControl1.Add(txtSochungtu, lblSochungtu.Text);
                htbControl1.Add(txtSotien, lblSotien.Text);
                htbControl1.Add(txtSotien_Vat, lblSotien_Vat.Text);
                htbControl1.Add(dtNgay_Chungtu, lblNgay_Chungtu.Text);
                htbControl1.Add(lookUpEdit_Kho_Hanghoa_Mua, lblKho_Hanghoa_Mua.Text);
                htbControl1.Add(lookUpEdit_Nhansu_Banhang, lblNhansu_Banhang.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;

                //try
                //{
                //    //xoa row ko co data
                //    ds_Hdbanhang_Chitiet.Tables[0].Select("Id_Hanghoa_Mua is null")[0].Delete();
                //}
                //catch(Exception ex) { }

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = (bool)this.UpdateObject();
                }
                if (success)
                {
                    //Update Min quota
                    if ("" + lookUpEdit_Khachhang.EditValue != "")
                        objWareService.Update_Ware_Khachhang_Min_Quota(lookUpEdit_Khachhang.EditValue, dtNgay_Chungtu.EditValue);

                    this.DisplayInfo();
                    DisplayInfo2();


                }
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }

            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hdbanhang"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hdbanhang")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override bool PerformPrintPreview()
        {
            //DataSet _ds_Hdbanhang_Chitiet = ds_Hdbanhang_Chitiet.Copy();
            //ds_Hdbanhang_Chitiet.Tables[0].Columns["Ten_Hanghoa_Mua"].ColumnName = "Ten_Hanghoa";
            DataRow[] sdr = ds_Hdbanhang.Tables[0].Select("Id_Hdbanhang = " + identity);

            DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new SunLine.Ware.DataSets.dsHdbanhang_Chitiet();
            Reports.rptHdbanhang_noVAT rptHdbanhang_noVAT = new SunLine.Ware.Reports.rptHdbanhang_noVAT();
            GoobizFrame.Windows.Forms.FormReportWithHeader objFormReport = new GoobizFrame.Windows.Forms.FormReportWithHeader();
            objFormReport.Report = rptHdbanhang_noVAT;
            rptHdbanhang_noVAT.DataSource = dsrHdbanhang_Chitiet;

            int i = 1;
            foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
            {
                DataRow drnew = dsrHdbanhang_Chitiet.Tables[0].NewRow();
                foreach (DataColumn dc in ds_Hdbanhang_Chitiet.Tables[0].Columns)
                {
                    try
                    {
                        drnew[dc.ColumnName] = dr[dc.ColumnName];
                    }
                    catch
                    {
                        continue;
                    }
                }
                drnew["Ten_Hanghoa"] = dr["Ten_Hanghoa_Mua"];
                drnew["Ma_Hanghoa"] = dr["Ma_Hanghoa_Mua"];
                drnew["Stt"] = i++;

                dsrHdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
            }

            //add parameter values
            rptHdbanhang_noVAT.tbc_Ngay.Text = "" + string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", sdr[0]["Ngay_Chungtu"]);
            //rptHdbanhang_noVAT.lblNhansu_Order.Text = lookUpEdit_Nhansu_Banhang.Text;
            rptHdbanhang_noVAT.lblNhansu_Bill.Text = lookUpEdit_Nhansu_Banhang.Text;

            DataRow[] sdrKhachhang = ds_Khachhang.Tables[0].Select("Id_Khachhang=" + sdr[0]["Id_Khachhang"]);
            rptHdbanhang_noVAT.lblKhachhang.Text = "" +
               ((sdrKhachhang != null && sdrKhachhang.Length > 0) ? sdrKhachhang[0]["Ten_Khachhang"] : "");
            //rptHdbanhang_noVAT.lblNhansu_Cash.Text = lookUpEdit_Nhansu_Banhang.Text;
            rptHdbanhang_noVAT.tbcSochungtu.Text = "" + sdr[0]["Sochungtu"];
            //rptHdbanhang_noVAT.xrBarCode_Sochungtu.Text = "" + sdr[0]["Sochungtu"];
            //rptHdbanhang_noVAT.tbcSotien_Khachtra.Text = string.Format("{0:#,#}", Convert.ToDouble("0" + sotien_mat));
            //rptHdbanhang_noVAT.tbcSotien_Thua.Text = string.Format("{0:#,#}", Convert.ToDouble("0" + sotien_thua));
            //rptHdbanhang_noVAT.tbcSotien_VAT.Text = "" + sdr[0]["Sotien_Vat"];//txtSotien_Vat.Text;
            rptHdbanhang_noVAT.lblNhansu_Bill.Text = lookUpEdit_Nhansu_Banhang.Text;
            //rptHdbanhang_noVAT.xrTblVIP_Card.Text = lookUpEdit_Khachhang.Text;

            double thanhtien = Convert.ToDouble(ds_Hdbanhang_Chitiet.Tables[0].Compute("sum(Thanhtien_TG)", ""));          

            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();

            rptHdbanhang_noVAT.tbcThanhtien_Bangchu.Text = str;

            rptHdbanhang_noVAT.PageSize = new Size(800, 1400 + 120 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables[0].Rows.Count));

            rptHdbanhang_noVAT.xrTable6.Location = new System.Drawing.Point(21, 42);
            rptHdbanhang_noVAT.xrTable4.Location = new System.Drawing.Point(21, 135);

            rptHdbanhang_noVAT.CreateDocument();

            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetPrintpreview("rptHdbanhang_noVAT"))
            {
                rptHdbanhang_noVAT.Print();
            }
            else
            {
                objFormReport.printControl1.PrintingSystem = rptHdbanhang_noVAT.PrintingSystem;
                objFormReport.MdiParent = this.MdiParent;
                objFormReport.Text = this.Text + "(Xem trang in)";
                objFormReport.Show();
                objFormReport.Activate();
            }
            return base.PerformPrintPreview();
        }
        #endregion

        #region Logon process
        /// <summary>
        /// scan barcode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (textUser.Text != "")
                    LogOn();
        }

        /// <summary>
        /// show screen logon
        /// </summary>
        void ShowLogonForm()
        {
            BarSystem.Visible = false;
            if (FormState == GoobizFrame.Windows.Forms.FormState.View)
            {
                //dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;


                //panelControl_Logonbg.ContentImage = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetSplashBitmap();
                panelLogon.Visible = true;
                panelLogon.Dock = DockStyle.Fill;
                panelControl_Cash.Visible = false;

                //item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                item_Delete.Enabled = false;
                item_Edit.Enabled = false;

                btnCash.Enabled = false;
                btnLogon.Visible = true;
                BarSystem.Visible = false;

                //textUser.Text = "123";
                textUser.Focus();
                textUser.Text = "";
            }
            else
            {
                panelLogon.Visible = false;
                panelControl_Cash.Visible = true;
                //panelControl_Cash.Dock = DockStyle.Fill;
                //dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                //btnLogon.Visible = false;

            }

        }

        /// <summary>
        /// verify logon
        /// </summary>
        void LogOn()
        {
            PolicyService.PolicyService objPolicy = new SunLine.Ware.PolicyService.PolicyService();

            if (textUser.Text.Trim() == "")
            {
                //GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] {
                //            labelUser.Text});
                return;
            }
            else
            {
                string user_name = textUser.Text;
                //Mã hóa password nếu password không rỗng
                string user_password = "";
                if (user_password != null && user_password != "")
                    user_password = GoobizFrame.Windows.HelperClasses.SecurityManager.HashData(user_password);
                //Tạo đối tượng Pol_Dm_User
                PolicyService.Pol_Dm_User Pol_Dm_User = new SunLine.Ware.PolicyService.Pol_Dm_User();
                Pol_Dm_User.User_Name = user_name;
                Pol_Dm_User.User_Password = user_password;
                DataSet dsPol_Dm_User_Set = objPolicy.Pol_Dm_User_Select_ByMa_Nhansu(user_name);
                if (dsPol_Dm_User_Set.Tables[0].Rows.Count > 0)
                {
                    //Lưu định danh của người đăng nhập 
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentUser("" + dsPol_Dm_User_Set.Tables[0].Rows[0]["User_Name"]);
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentUserId("" + dsPol_Dm_User_Set.Tables[0].Rows[0]["Id_User"]);
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentId_Nhansu("" + dsPol_Dm_User_Set.Tables[0].Rows[0]["Id_Nhansu"]);

                    PolicyService.Pol_User_Right Pol_User_Right = new SunLine.Ware.PolicyService.Pol_User_Right();
                    Pol_User_Right.Id_User = dsPol_Dm_User_Set.Tables[0].Rows[0]["Id_User"];
                    DataSet dsPol_User_Right = objPolicy.Select_Pol_User_Right_ByIDUser3(Pol_User_Right);
                    if (dsPol_User_Right.Tables[0].Rows.Count == 1)
                        GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentUserRight("" + dsPol_User_Right.Tables[0].Rows[0]["Right_System_Name"]);
                    else
                        GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCurrentUserRight("");

                    ShowTabPage(xtraTabControl2, xtraTabPage_Banhang);
                    panelControl_Cash.Visible = true;
                    //panelControl_Cash.Dock = DockStyle.Fill;

                    BarSystem.Visible = true;

                    btnCash.Enabled = true;

                    DisplayInfo();
                    btnAdd.Enabled = false;
                    changeStatusButton(true);
                    PerformAdd();
                    ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);

                    //GoobizFrame.Windows.MdiUtils.MdiChecker.NotifyLogon.Notify();
                }
                else
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00007", new string[] {
                            textUser.Text});
                    textUser.SelectAll();
                    textUser.Focus();
                }
            }
        }

        private void textUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            //khong cho phep nhap text vao o ma nhân su
            e.Handled = true;
        }

        private void Frmbar_Table_Order_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert && this.MdiParent == null)
            {
                panelLogon.Visible = true;

                textUser.Focus();
                textUser.Text = "";
            }
        }
        #endregion

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.FieldName == "Per_Dongia" && !AllowEdit_Per_Dongia)
            if (e.Column.FieldName == "Per_Dongia")
            {
                //lblStatus_Bar.Text = "";
                ////neu thay doi fiel giam gia --> phai xac nhan nguoi thay doi co quyen hay khong
                //SunLine.SystemControl.DBUsers.IDCardLogonWithResult IDCardLogonWithResult = new SunLine.SystemControl.DBUsers.IDCardLogonWithResult();
                //GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(IDCardLogonWithResult);
                //IDCardLogonWithResult.Right_System_Name = this.Name;
                //IDCardLogonWithResult.ShowDialog();
                //if (IDCardLogonWithResult.Actions.Count == 0 || !IDCardLogonWithResult.Actions.Contains("EnableReduce"))
                //{
                //    gridView4.CancelUpdateCurrentRow();
                //    return;
                //}
                //else
                //{
                //    AllowEdit_Per_Dongia = true;
                //    Id_Nhansu_Km = Convert.ToInt32(IDCardLogonWithResult.Id_Nhansu);
                //}
            }

            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia_Ban" || e.Column.FieldName == "Per_Dongia")
            {
                if (gridView4.GetFocusedRowCellValue("Soluong").ToString() == "0")
                {
                    lblStatus_Bar.Text = "";
                    lblStatus_Bar.Text = "Số lượng không được bằng 0";
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 1);
                    return;
                }
                if ("" + gridView4.GetFocusedRowCellValue("Soluong") != ""
                    && "" + gridView4.GetFocusedRowCellValue("Dongia_Ban") != "")
                {
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Thanhtien"],
                        Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Soluong"))
                                                                 * Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Dongia_Ban"))
                                                                 * (1 - Convert.ToDecimal("0" + gridView4.GetFocusedRowCellValue("Per_Dongia")) / 100)
                                                    );



                    //txtSotien.EditValue = Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue) / Convert.ToDecimal(1.1);
                }
            }
            if (e.Column.FieldName == "Thanhtien")
            {
                gridView4.FocusedRowHandle = gridView4.RowCount;
            }
            else if (e.Column.FieldName == "Id_Hanghoa_Mua")
            {
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Id_Donvitinh"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Ban"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Dongia_Ban"]);

                //set giam gia theo ct km
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Per_Dongia"], 0);
                if (dsCtrinh_Kmai_Chitiet != null
                    && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
                    && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
                {
                    DataRow[] sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Mua=" + e.Value);
                    if (sdr != null && sdr.Length > 0)
                        gridView4.GetDataRow(gridView4.FocusedRowHandle)["Per_Dongia"] = sdr[0]["Per_Dongia"];
                }
            }
            if (txtMa_Khachhang.Text != "")
            {
                Recal_Dongia();
            }
            else
            {
                dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                txtSotien.EditValue = Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue);
            }
            txtSotien_Khachtra.Text = "";
            txtSotien_Thua.Text = "";
        }

        private void txtSotien_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSotien.Text != "")
            {
                txtSotien_Vat.EditValue = Convert.ToDecimal(txtSotien.EditValue) * Convert.ToDecimal(0.1) / Convert.ToDecimal(1.1);
            }
        }

        void DisplayInfo2()
        {
            gridColumn13.Visible = false;

            if ("" + gridView1.GetFocusedRowCellValue("Id_Hdbanhang") == "")
            {
                ds_Hdbanhang_Chitiet = new DataSet();
                this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(-1);
                return;
            }
            else
            {
                identity = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");
                this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(identity);
                this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet;
                this.dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet.Tables[0].TableName;
                gridView4.BestFitColumns();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnPrint.Enabled = true;
            this.DisplayInfo2();
        }

        private void txtTien_Khachtra_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ("" + gridView4.GetFocusedRowCellValue("Id_Hdbanhang_Chitiet") == "")
                return;
            //dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
            //if (gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue != null)
            //{
            //    txtSotien.EditValue = Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue) / Convert.ToDecimal(1.1);
            //}
        }

        private void lookUpEdit_Kho_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                object Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
                GetDmHanghoaMua_ByKhoHanghoaMua();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.PageUp)
                txtSotien_Khachtra.Focus();
            else if (e.KeyData == Keys.PageDown)
                txtSoluong.Focus();
            else if (e.KeyData == Keys.Insert)
                txtBarcode_Txt.Focus();
        }

        private void txtBarcode_Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && "" + txtBarcode_Txt.Text != "")
            {
                AddNewRow_Hdbanhang_Chitiet();
            }
        }

        void AddNewRow_Hdbanhang_Chitiet()
        {
            btnCash.Enabled = true;
            lblStatus_Bar.Text = "";
            try
            {
                DataRow nrow = null;
                DataRow[] sr = ds_Hanghoa_Mua.Tables[0].Select("Barcode_Txt = '" + txtBarcode_Txt.Text + "'");
                if (sr.Length == 0)
                {
                    lblStatus_Bar.Text = "Không có hàng hóa với mã vạch này, nhập lại";
                    return;
                }
                bool check = false;
                if (sr != null && sr.Length > 0)
                {
                    if ("" + sr[0]["Dongia_Ban"] == "")
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] { "ĐG", "ĐG" });
                        return;
                    }
                    for (int i = 0; i < ds_Hdbanhang_Chitiet.Tables[0].Rows.Count; i++)
                    {
                        if (ds_Hdbanhang_Chitiet.Tables[0].Rows[i]["Id_Hanghoa_Mua"].Equals(sr[0]["Id_Hanghoa_Mua"]))
                        {
                            nrow = ds_Hdbanhang_Chitiet.Tables[0].Rows[i];
                            nrow["Soluong"] = Convert.ToInt32(nrow["Soluong"]) + Convert.ToInt32(txtSoluong.EditValue);
                            nrow["Per_Dongia"] = nrow["Per_Dongia"];
                            nrow["Thanhtien"] = Convert.ToDecimal(nrow["Soluong"])
                                                     * Convert.ToDecimal(nrow["Dongia_Ban"])
                                                     * (1 - Convert.ToDecimal("0" + nrow["Per_Dongia"]) / 100);
                            gridView4.FocusedRowHandle = i;
                            check = true;
                        }
                    }

                    if (!check)
                    {
                        nrow = ds_Hdbanhang_Chitiet.Tables[0].NewRow();//gridView4.AddNewRow();     
                        nrow["Id_Hanghoa_Mua"] = sr[0]["Id_Hanghoa_Mua"];
                        nrow["Soluong"] = txtSoluong.EditValue;
                        nrow["Dongia_Ban"] = sr[0]["Dongia_Ban"];
                        nrow["Id_Donvitinh"] = sr[0]["Id_Donvitinh"];

                        //set giam gia theo ct km
                        if (txtKm_All.Text.ToString() != "0")
                        {
                            nrow["Per_Dongia"] = txtKm_All.EditValue;
                        }
                        else
                        {
                            nrow["Per_Dongia"] = 0;

                            if (dsCtrinh_Kmai_Chitiet != null
                                && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
                                && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
                            {
                                DataRow[] sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Mua=" + sr[0]["Id_Hanghoa_Mua"]);
                                if (sdr != null && sdr.Length > 0)
                                    nrow["Per_Dongia"] = sdr[0]["Per_Dongia"];
                            }
                        }

                        //tinh thanh tien
                        nrow["Thanhtien"] = Convert.ToDecimal(nrow["Soluong"])
                            * Convert.ToDecimal(nrow["Dongia_Ban"])
                            * (1 - Convert.ToDecimal("0" + nrow["Per_Dongia"]) / 100);

                        ds_Hdbanhang_Chitiet.Tables[0].Rows.Add(nrow);
                        gridView4.FocusedRowHandle = gridView4.RowCount - 1;
                    }

                    if (txtMa_Khachhang.EditValue.ToString() != "")
                    {
                        Cal_KhuyenMai();
                        Recal_Dongia();
                    }

                    else
                    {
                        dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                        txtSotien.EditValue = gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue;
                    }

                    txtBarcode_Txt.Text = "";
                    txtBarcode_Txt.Focus();
                }

            }
            catch (Exception ex)
            {
                ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(0);
            }
            dgware_Hdbanhang_Chitiet.RefreshDataSource();
            txtSoluong.EditValue = 1;
            gridView4.RefreshData();
        }

        private void txtBarcode_Txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarcode_Txt.SelectAll();
                txtBarcode_Txt.Focus();
            }
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_Load(object sender, EventArgs e)
        {
            ShowLogonForm();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            //if ((txtSotien_Khachtra.Text == "" || txtSotien_Khachtra.Text == "0") && txtSotien.Text != "0")
            //{
            //    // GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] { lblSotien_Khachtra.Text });
            //    lblStatus_Bar.Text = "Tiền khách đưa không được để rỗng hoặc bằng 0, nhập lại";
            //    return;
            //}
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            thanhtien = Convert.ToDouble(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue);
            sotien_mat = txtSotien_Khachtra.EditValue;
            sotien_thua = txtSotien_Thua.EditValue;

            PerformSave();

            this.ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(identity);
            PerformPrintPreview();

            PerformAdd();
            //btnKm_All.Enabled = false;
            //btnKhachhang.Enabled = false;
            //btnCash.Enabled = false;
            //btnHanghoa_Mua.Enabled = false;
            //btnAdd.Enabled = true;
            //btnPrint.Enabled = true;
            //btnCancel.Enabled = false;
            //   ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            //    ShowLogonForm();
        }



        /// <summary>
        /// tinh lai gia gia cho VIP card
        /// </summary>
        void Recal_Dongia()
        {
            if (lookUpEdit_Khachhang.EditValue.ToString() == "")
            {
                return;
            }
            txtMin_Quota.EditValue = null;
            //Update Min quota
            objWareService.Update_Ware_Khachhang_Min_Quota(lookUpEdit_Khachhang.EditValue, dtNgay_Chungtu.EditValue);
            DataSet dsKhachhang_KM = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(lookUpEdit_Khachhang.EditValue);
            #region check khach hang VIP
            if (dsKhachhang_KM.Tables[0].Rows[0]["Id_Vip_Member"].ToString() != "") // check if khach hang VIP
            {
                DataSet dsVip_Member_HhDetail_By_Khachhang = objWareService.Get_All_Ware_Vip_Member_HhDetail_By_Khachhang(lookUpEdit_Khachhang.EditValue, dtNgay_Chungtu.EditValue);
                if (dsVip_Member_HhDetail_By_Khachhang != null && dsVip_Member_HhDetail_By_Khachhang.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                    {
                        DataRow[] sdr = dsVip_Member_HhDetail_By_Khachhang.Tables[0].Select("Id_Hanghoa_Mua=" + row["Id_Hanghoa_Mua"]);
                        if (sdr != null && sdr.Length > 0)
                        {
                            vip_per_dongia = Convert.ToDecimal(sdr[0]["Per_Hoadon"]);
                            if (vip_per_dongia > Convert.ToDecimal(row["Per_Dongia"]))
                                row["Per_Dongia"] = vip_per_dongia;
                        }
                        try
                        {
                            row["Thanhtien"] =
                                Convert.ToDecimal(row["Soluong"]) * Convert.ToDecimal(row["Dongia_Ban"]) * (1 - Convert.ToDecimal("0" + row["Per_Dongia"]) / 100);
                        }
                        catch (Exception exception) { }
                    }
                }
            }
            #endregion
            #region khach hang Quota
            else
            {
                Decimal sumBill = Convert.ToDecimal("0" + gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue);
                Decimal minQuota = Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Min_Quota"]);
                if (gridView4.RowCount != 0)
                {
                    if (sumBill <= minQuota)
                    {
                        foreach (DataRow row in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                        {
                            row["Thanhtien_Km"] = row["Thanhtien"];
                        }
                        txtMin_Quota.EditValue = minQuota;
                        lblStatus_Bar.Text = "Khách hàng " + dsKhachhang_KM.Tables[0].Rows[0]["Ten_Khachhang"] + " có quota là: " + Convert.ToInt32(minQuota);
                        txtSotien.EditValue = 0;
                        return;
                    }
                    else
                    {
                        object percentKM = minQuota / sumBill;

                        foreach (DataRow row in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                        {
                            row["Thanhtien_Km"] = Convert.ToInt32(Convert.ToDecimal(row["Thanhtien"]) * Convert.ToDecimal(percentKM));
                        }
                    }
                }

                txtMin_Quota.EditValue = minQuota;
                lblStatus_Bar.Text = "Khách hàng " + dsKhachhang_KM.Tables[0].Rows[0]["Ten_Khachhang"] + " có quota là: " + Convert.ToInt32(minQuota);
            }
            if (Convert.ToDecimal("0" + gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue) < Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Min_Quota"]))
            {
                return;
            }
            dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            txtSotien.EditValue = Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue) - Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Min_Quota"]);
            #endregion
        }

        /// <summary>
        /// Tinh khuyen mai
        /// </summary>
        void Cal_KhuyenMai()
        {
            foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
            {
                //set giam gia theo khuyen mai
                if (dsCtrinh_Kmai_Chitiet != null
                && dsCtrinh_Kmai_Chitiet.Tables.Count > 0
                && dsCtrinh_Kmai_Chitiet.Tables[0].Rows.Count > 0)
                {
                    DataRow[] sdr = dsCtrinh_Kmai_Chitiet.Tables[0].Select("Id_Hanghoa_Mua=" + dr["Id_Hanghoa_Mua"]);
                    if (sdr != null && sdr.Length > 0)
                        if (Convert.ToDecimal("0" + dr["Per_Dongia"]) < Convert.ToDecimal("0" + sdr[0]["Per_Dongia"]))
                            dr["Per_Dongia"] = Convert.ToDecimal("0" + sdr[0]["Per_Dongia"]);
                }
                dr["Thanhtien"] = Convert.ToDecimal(dr["Soluong"]) * Convert.ToDecimal(dr["Dongia_Ban"]) * (1 - Convert.ToDecimal("0" + dr["Per_Dongia"]) / 100);
            }
        }
        private void txtMa_Khachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Check_Khachhang();
            }
        }

        void Check_Khachhang()
        {
            lblStatus_Bar.Text = "";
            if (txtMa_Khachhang.Text != "")
            {
                try
                {
                    //if ("" + gridView1.GetFocusedRowCellValue("Id_Khachhang") != ""
                    //        && Convert.ToInt64(gridView1.GetFocusedRowCellValue("Id_Khachhang")) != -1)
                    //    return;

                    //reset per_dongia theo km

                    foreach (DataRow dr in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                    {
                        dr["Per_Dongia"] = 0;
                        dr["Thanhtien"] = Convert.ToDecimal(dr["Soluong"]) * Convert.ToDecimal(dr["Dongia_Ban"]) * (1 - Convert.ToDecimal("0" + dr["Per_Dongia"]) / 100);
                    }

                    Cal_KhuyenMai();
                    DataTable dt = (DataTable)lookUpEdit_Khachhang.Properties.DataSource;
                    lookUpEdit_Khachhang.EditValue = dt.Select("Ma_Khachhang = '" + txtMa_Khachhang.Text + "'")[0]["Id_Khachhang"];


                    Recal_Dongia();
                }
                catch (Exception ex)
                {
                    lblStatus_Bar.Text = "Mã khách hàng không tồn tại, nhập lại";
                    txtMa_Khachhang.EditValue = null;
                    txtMa_Khachhang.Focus();
                    lookUpEdit_Khachhang.EditValue = DBNull.Value;
                }
            }
            else
                lookUpEdit_Khachhang.EditValue = null;
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            ShowLogonForm();
            ShowTabPage(xtraTabControl2, xtraTabPage_Logon);
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (FormState == GoobizFrame.Windows.Forms.FormState.View && "" + lookUpEdit_Khachhang.EditValue != "")
                    txtMa_Khachhang.Text = "" + ((DataRowView)lookUpEdit_Khachhang.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Khachhang.EditValue))["Ma_Khachhang"];
            }
            catch { txtMa_Khachhang.Text = ""; }
        }

        private void dgware_Dm_Hanghoa_Mua_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        private void lookUpEdit_Loai_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            //gridView2.Columns["Id_Loai_Hanghoa_Mua"].FilterInfo =
            //    new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView2.Columns["Id_Loai_Hanghoa_Mua"], lookUpEdit_Loai_Hanghoa_Mua.EditValue);
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (gridView2.FocusedRowHandle >= 0 && FormState != GoobizFrame.Windows.Forms.FormState.View)
            //{
            //    txtBarcode_Txt.EditValue = gridView2.GetFocusedRowCellValue("Barcode_Txt");
            //    txtBarcode_Txt.SelectAll();
            //    txtBarcode_Txt.Focus();
            //}
        }

        private void gridView4_RowCountChanged(object sender, EventArgs e)
        {
            dgware_Hdbanhang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            txtSotien.EditValue = Convert.ToDecimal("0" + gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue) - Convert.ToDecimal("0" + ds_Hdbanhang_Chitiet.Tables[0].Compute("sum(Thanhtien_Km)", ""));
            txtSotien_Khachtra.Text = "";
            txtSotien_Thua.Text = "";

        }

        //private void lookUpEdit_Loai_Hanghoa_Mua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
        //    {
        //        SunLine.MasterTables.Forms.Ware.Frmware_Dm_Loai_Hanghoa_Mua_Dialog frmware_Dm_Loai_Hanghoa_Mua_Dialog = new SunLine.MasterTables.Forms.Ware.Frmware_Dm_Loai_Hanghoa_Mua_Dialog();
        //        frmware_Dm_Loai_Hanghoa_Mua_Dialog.Text = "Loại hàng hóa";
        //        GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Loai_Hanghoa_Mua_Dialog);
        //        frmware_Dm_Loai_Hanghoa_Mua_Dialog.ShowDialog();
        //        if (frmware_Dm_Loai_Hanghoa_Mua_Dialog.SelectedRows != null && frmware_Dm_Loai_Hanghoa_Mua_Dialog.SelectedRows.Length > 0)
        //        {
        //            //lookUpEdit_Loai_Hanghoa_Mua.EditValue = frmware_Dm_Loai_Hanghoa_Mua_Dialog.SelectedRows[0]["Id_Loai_Hanghoa_Mua"];
        //        }
        //    }
        //}

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    SunLine.MasterTables.Forms.Ware.Frmware_Dm_Loai_Hanghoa_Mua_Dialog frmware_Dm_Loai_Hanghoa_Mua_Dialog = new SunLine.MasterTables.Forms.Ware.Frmware_Dm_Loai_Hanghoa_Mua_Dialog();
        //    frmware_Dm_Loai_Hanghoa_Mua_Dialog.Text = "Loại hàng hóa";
        //    GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Loai_Hanghoa_Mua_Dialog);
        //    frmware_Dm_Loai_Hanghoa_Mua_Dialog.ShowDialog();
        //    if (frmware_Dm_Loai_Hanghoa_Mua_Dialog.SelectedRows != null && frmware_Dm_Loai_Hanghoa_Mua_Dialog.SelectedRows.Length > 0)
        //    {
        //        //lookUpEdit_Loai_Hanghoa_Mua.EditValue = frmware_Dm_Loai_Hanghoa_Mua_Dialog.SelectedRows[0]["Id_Loai_Hanghoa_Mua"];
        //    }
        //}

        private void dgware_Dm_Loai_Hanghoa_Mua_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }


        // click vào button DS hoa don
        private void btnHdbanhang_Click(object sender, EventArgs e)
        {
            ShowTabPage(xtraTabControl1, xtraTabPage_Hdbanhang);

            //if (xtraTabControl1.SelectedTabPage == xtraTabPage_Hdbanhang)
            splitContainerControl1.PanelVisibility =
                (splitContainerControl1.PanelVisibility != DevExpress.XtraEditors.SplitPanelVisibility.Both)
                ? DevExpress.XtraEditors.SplitPanelVisibility.Both
                : DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
        }

        // click vào button tìm hàng
        private void btnHanghoa_Mua_Click_1(object sender, EventArgs e)
        {


            splitContainerControl1.PanelVisibility =
                (splitContainerControl1.PanelVisibility != DevExpress.XtraEditors.SplitPanelVisibility.Both)
                ? DevExpress.XtraEditors.SplitPanelVisibility.Both
                : DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            ShowTabPage(xtraTabControl1, xtraTabPage_Loai_Hanghoa_Mua);
        }


        private void btnKm_All_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr_change = gridView4.GetDataRow(gridView4.FocusedRowHandle);
                if (!AllowEdit_Per_Dongia)
                {
                    SunLine.SystemControl.DBUsers.IDCardLogonWithResult IDCardLogonWithResult = new SunLine.SystemControl.DBUsers.IDCardLogonWithResult();
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(IDCardLogonWithResult);
                    IDCardLogonWithResult.Right_System_Name = this.Name;
                    IDCardLogonWithResult.ShowDialog();

                    if (IDCardLogonWithResult.Actions.Count == 0 || !IDCardLogonWithResult.Actions.Contains("EnableReduce"))
                    {
                        dr_change.CancelEdit();
                        dr_change.RejectChanges();
                    }
                    else
                    {
                        AllowEdit_Per_Dongia = true;
                        txtKm_All.Enabled = true;
                        this.gridColumn5.OptionsColumn.AllowEdit = true;
                        repositoryItemButtonEdit3.Buttons[0].Visible = true;
                        Id_Nhansu_Km = Convert.ToInt32(IDCardLogonWithResult.Id_Nhansu);
                        //   txtKm_All.EditValue = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtKm_All.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message);
            }
        }

        private void txtKm_All_EditValueChanged(object sender, EventArgs e)
        {
        }

        void Check_Km_All()
        {
            lblStatus_Bar.Text = "";
            object value = txtKm_All.EditValue;
            try
            {
                if (value.ToString().Contains("."))
                {
                    lblStatus_Bar.Text = "Khuyến mãi chỉ được phép nhập số";
                    txtKm_All.EditValue = 0;
                    return;
                }

                if (Convert.ToInt32(value) < 0 || Convert.ToInt32(value) > 100)
                {
                    lblStatus_Bar.Text = "Khuyến mãi chỉ được phép nhập trong khoảng từ 0 đến 100";
                    txtKm_All.EditValue = 0;
                    return;
                }

                if (gridView4.RowCount > 0)
                {
                    for (int i = 0; i < ds_Hdbanhang_Chitiet.Tables[0].Rows.Count; i++)
                    {
                        DataRow dtr = ds_Hdbanhang_Chitiet.Tables[0].Rows[i];
                        dtr["Per_Dongia"] = txtKm_All.EditValue;
                        object thanhtien = Convert.ToDouble(dtr["Dongia_Ban"]) * Convert.ToDouble(dtr["Soluong"]);
                        dtr["Thanhtien"] = Convert.ToDouble(thanhtien) * (100 - Convert.ToDouble(dtr["Per_Dongia"])) / 100;
                    }
                    txtSotien.EditValue = Convert.ToDouble("0" + gridColumn25.SummaryText);
                    Recal_Dongia();
                }
            }
            catch
            {
                lblStatus_Bar.Text = "Khuyến mãi chỉ được phép nhập số";
                txtKm_All.EditValue = 0;
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        void repositoryItemButtonEdit1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa hàng hóa này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lblStatus_Bar.Text = "";
                ds_Hdbanhang_Chitiet.Tables[0].Rows[gridView4.FocusedRowHandle].Delete();
                dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet;
                dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet.Tables[0].TableName;
                if (gridView4.RowCount == 0)
                {
                    btnCash.Enabled = false;
                }
                else
                    Recal_Dongia();
                //    ResetText();
            }
        }

        private void btnBack_Hanghoa_Mua_Click(object sender, EventArgs e)
        {
            cardView1.MovePrevPage();
        }

        private void btnNext_Hanghoa_Mua_Click(object sender, EventArgs e)
        {
            cardView1.MoveNextPage();
        }

        private void btnBack_Loai_Hanghoa_Mua_Click(object sender, EventArgs e)
        {
            cardView2.MovePrevPage();
        }

        private void btnNext_Loai_Hanghoa_Mua_Click(object sender, EventArgs e)
        {
            cardView2.MoveNextPage();
        }

        private void cardView1_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView1.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                //DataRow dtr = ds_Hdbanhang_Chitiet.Tables[0].NewRow();
                //dtr["Id_Hanghoa_Mua"] = ds_Hanghoa_Mua.Tables[0].Rows[cardHit.RowHandle]["Id_Hanghoa_Mua"];
                ////  dtr["Ma_Hanghoa_Ban"] = ds_HangHoa.Tables[0].Rows[0]["Ma_Hanghoa_Mua"];
                //dtr["Id_Donvitinh"] = ds_Hanghoa_Mua.Tables[0].Rows[cardHit.RowHandle]["Id_Donvitinh"];
                //dtr["soluong"] = txtSoluong.EditValue;
                //dtr["Per_Dongia"] = txtKm_All.EditValue;
                //dtr["Dongia_Ban"] = ds_Hanghoa_Mua.Tables[0].Rows[cardHit.RowHandle]["Dongia_Mua"];
                //object thanhtien = Convert.ToDouble("0" + dtr["Dongia_Ban"]) * Convert.ToInt32(txtSoluong.Text);
                //dtr["Thanhtien"] = Convert.ToDouble(thanhtien) * (100 - Convert.ToDouble(dtr["Per_Dongia"])) / 100;
                //ds_Hdbanhang_Chitiet.Tables[0].Rows.Add(dtr);
                //dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet;
                //dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet.Tables[0].TableName;
                txtBarcode_Txt.Text = "" + cardView1.GetRowCellValue(cardHit.RowHandle, "Barcode_Txt");
                AddNewRow_Hdbanhang_Chitiet();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PerformPrintPreview();
        }


        // button them moi
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtBarcode_Txt.Enabled = true;
            txtSoluong.Enabled = true;
            txtSotien_Khachtra.Enabled = true;

            PerformAdd();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
        }

        // button bỏ qua
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.gridColumn19.Visible = true;
            ResetText();
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            txtBarcode_Txt.Enabled = false;
            txtSotien_Khachtra.Enabled = false;
            txtSoluong.Enabled = false;
            ShowTabPage(xtraTabControl1, xtraTabPage_Hdbanhang);
            gridView1.FocusedRowHandle = ds_Hdbanhang.Tables[0].Rows.Count;
            PerformCancel();
            ChangeFormState(GoobizFrame.Windows.Forms.FormState.Cancel);
        }

        void changeStatusButton(bool boo)
        {
            btnCancel.Enabled = boo;
            lblStatus_Bar.Text = "";
            btnCash.Visible = boo;
            btnKhachhang.Enabled = boo;
            btnKm_All.Enabled = boo;
            txtSoluong.Enabled = boo;
            txtBarcode_Txt.Enabled = boo;
            txtSotien_Khachtra.Enabled = boo;
            btnHanghoa_Mua.Enabled = boo;

            btnPrint.Visible = !boo;
            btnHdbanhang.Enabled = !boo;
            btnLogon.Enabled = !boo;
            btnSplit.Enabled = !boo;
            btnClose.Enabled = !boo;
            btnAdd.Enabled = !boo;
        }

        private void cardView2_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView2.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                //xtraTabControl1.TabPages.Remove(xtraTabPage_Loai_Hanghoa_Mua);
                //xtraTabControl1.TabPages.Add(xtraTabPage_Hanghoa_Mua);
                object id_loai_Hh = cardView2.GetRowCellValue(cardHit.RowHandle, "Id_Loai_Hanghoa_Mua");
                //object id_loai_Hh = dsDm_Loai_Hanghoa_Mua.Tables[0].Rows[cardHit.RowHandle]["Id_Loai_Hanghoa_Mua"];
                //ds_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua_By_Id_Loai_Hh(id_loai_Hh);            
                //dgware_Dm_Hanghoa_Mua.DataSource = ds_Hanghoa_Mua;
                //dgware_Dm_Hanghoa_Mua.DataMember = dsDm_Loai_Hanghoa_Mua.Tables[0].TableName;
                cardView1.Columns["Id_Loai_Hanghoa_Mua"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
               "Id_Loai_Hanghoa_Mua = " + id_loai_Hh);
                ShowTabPage(xtraTabControl1, xtraTabPage_Hanghoa_Mua);
            }
        }

        private void btnLoai_Hanghoa_Mua_Click(object sender, EventArgs e)
        {
            ShowTabPage(xtraTabControl1, xtraTabPage_Loai_Hanghoa_Mua);
        }

        private void txtBarcode_Txt_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            lblStatus_Bar.Text = "";
            txtBarcode_Txt.Text = GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(txtBarcode_Txt.Text);
            AddNewRow_Hdbanhang_Chitiet();
        }

        private void txtSoluong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            lblStatus_Bar.Text = "";
            object value = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtSoluong.Text);
            if (value.ToString() == "0")
            {
                lblStatus_Bar.Text = "Số lượng không được bằng 0";
                txtSoluong.EditValue = 1;
                txtSoluong.Focus();
                return;
            }
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Số lượng phải là số nguyên";
                txtSoluong.EditValue = 1;
                txtSoluong.Focus();
                return;
            }
            txtSoluong.EditValue = value;
        }

        private void txtMa_Khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtMa_Khachhang.Text = GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(txtMa_Khachhang.Text);
            Check_Khachhang();
        }

        private void txtKm_All_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtKm_All.Text = "" + GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtKm_All.Text);
            Check_Km_All();
        }

        private void txtSotien_Khachtra_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            lblStatus_Bar.Text = "";
            object value = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtSotien_Khachtra.EditValue);
            if (value.ToString() == "0")
            {
                lblStatus_Bar.Text = "Tiền khách trả không được bằng 0";
                txtSotien_Khachtra.EditValue = DBNull.Value;
                txtSotien_Thua.EditValue = null;
                return;
            }
            txtSotien_Khachtra.EditValue = value;
        }

        private void txtSotien_Khachtra_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtSotien_Khachtra.Text == "0")
            //    {
            //        lblStatus_Bar.Text = "Tiền khách trả không được = 0";
            //        txtSotien_Khachtra.EditValue = DBNull.Value;
            //        txtSotien_Thua.EditValue = DBNull.Value;
            //        return;
            //    }

            //    if (txtSotien_Khachtra.Text != "")
            //    {
            //        try
            //        {
            //            txtSotien_Thua.EditValue = Convert.ToDecimal(txtSotien_Khachtra.EditValue) - Convert.ToDecimal(gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue);

            //            lblStatus_Bar.Text = "";
            //            object tienKhachDua = txtSotien_Khachtra.EditValue;
            //            if (tienKhachDua.ToString() == "" || gridColumn25.SummaryText == "")
            //            {
            //                return;
            //            }
            //            if (Convert.ToDouble(tienKhachDua) == 0)
            //            {
            //                lblStatus_Bar.Text = "Số tiền khách đưa không được bằng 0";
            //                return;
            //            }

            //            if (Convert.ToDouble(tienKhachDua) < Convert.ToDouble(gridColumn25.SummaryText))
            //            {
            //                lblStatus_Bar.Text = "Số tiền khách đưa không được nhỏ hơn số tiền trên hóa đơn";
            //                txtSotien_Thua.EditValue = "";
            //                return;
            //            }
            //            txtSotien_Thua.EditValue = Convert.ToDouble(tienKhachDua) - Convert.ToDouble(gridColumn25.SummaryText);
            //        }
            //        catch
            //        {
            //            lblStatus_Bar.Text = "Số tiền khách đưa chỉ được nhập số, nhập lại.";
            //            txtSotien_Khachtra.Focus();
            //            txtSotien_Khachtra.EditValue = "";
            //            return;
            //        }
            //    }
            //    else
            //        txtSotien_Thua.EditValue = null;
            //}
        }

        // button the khach hang
        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            txtMa_Khachhang.Enabled = true;
            txtMa_Khachhang.Text = GoobizFrame.Windows.Forms.FrmGKeyboardInput.ShowInputDialog(txtMa_Khachhang.Text);
            Check_Khachhang();
        }


        private void txtKm_All_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Check_Km_All();
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            lblStatus_Bar.Text = "";
            object value = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
                                    "" + gridView4.GetFocusedRowCellValue("" + gridView4.FocusedColumn.FieldName));
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Số lượng phải là số nguyên";
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 1);
                return;
            }
            if (value.ToString() == "0")
            {
                lblStatus_Bar.Text = "Số lượng không được bằng 0";
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 1);
                return;
            }

            if (value.Equals(""))
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, DBNull.Value);
            else
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, value);
            gridView4.RefreshRow(gridView4.FocusedRowHandle);
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }


        void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            object value = GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
                                  "" + gridView4.GetFocusedRowCellValue("" + gridView4.FocusedColumn.FieldName));
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Khuyến mãi chỉ được phép nhập số";
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 0);
                return;
            }

            if (Convert.ToInt32(value) < 0 || Convert.ToInt32(value) > 100)
            {
                lblStatus_Bar.Text = "Khuyến mãi chỉ được phép nhập trong khoảng từ 0 đến 100";
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, 0);
                return;
            }

            if (value.Equals(""))
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, DBNull.Value);
            else
                gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, value);
            gridView4.RefreshRow(gridView4.FocusedRowHandle);
        }


        private void txtSoluong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSoluong.Text == "0")
                {
                    lblStatus_Bar.Text = "Số lượng không được bằng 0";
                    txtSoluong.EditValue = 1;
                    txtSoluong.Focus();
                }
            }
        }

        private void txtSotien_Khachtra_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSotien_Khachtra.Text == "0")
            {
                lblStatus_Bar.Text = "Tiền khách trả không được = 0";
                txtSotien_Khachtra.EditValue = DBNull.Value;
                txtSotien_Thua.EditValue = DBNull.Value;
                return;
            }

            if (txtSotien_Khachtra.Text != "")
            {
                try
                {
                    txtSotien_Thua.EditValue = Convert.ToDecimal(txtSotien_Khachtra.EditValue) - Convert.ToDecimal(txtSotien.EditValue);

                    lblStatus_Bar.Text = "";
                    object tienKhachDua = txtSotien_Khachtra.EditValue;
                    if (tienKhachDua.ToString() == "" || gridColumn25.SummaryText == "")
                    {
                        return;
                    }
                    if (Convert.ToDouble(tienKhachDua) == 0)
                    {
                        lblStatus_Bar.Text = "Số tiền khách đưa không được bằng 0";
                        return;
                    }

                    if (Convert.ToDouble(tienKhachDua) < Convert.ToDouble(txtSotien.EditValue))
                    {
                        lblStatus_Bar.Text = "Số tiền khách đưa không được nhỏ hơn số tiền trên hóa đơn";
                        txtSotien_Thua.EditValue = "";
                        return;
                    }
                    txtSotien_Thua.EditValue = Convert.ToDouble(tienKhachDua) - Convert.ToDouble(txtSotien.EditValue);
                }
                catch
                {
                    lblStatus_Bar.Text = "Số tiền khách đưa chỉ được nhập số, nhập lại.";
                    txtSotien_Khachtra.Focus();
                    txtSotien_Khachtra.EditValue = "";
                    return;
                }
            }
            else
                txtSotien_Thua.EditValue = null;
        }

        private void Frmware_Hdbanhang_noVAT_Hhmua_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DataRow[] sdr = dsSys_Lognotify.Tables[0].Select("Table_Name='Ware_Ctrinh_Kmai'");
                if (sdr != null && sdr.Length > 0)
                    sdr[0].Delete();
                dsSys_Lognotify.AcceptChanges();
                dsSys_Lognotify.WriteXml(Sys_Lognotify_Path, XmlWriteMode.WriteSchema);
            }
            catch { }
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            SunLine.Reports.Forms.FrmRptSplit_Sum_Hhmua formReport_HhMua = new SunLine.Reports.Forms.FrmRptSplit_Sum_Hhmua();
            formReport_HhMua.Show();
        }

    }
}

