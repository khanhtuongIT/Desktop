using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using System.IO;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Donmuahang :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public BizFlow oBizFlow = BizFlow.Frmware_Donmuahang;

        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Donmuahang = new DataSet();
        DataSet ds_Donmuahang_Chitiet = new DataSet();
        public DataSet dsSelected = new DataSet();
        DataSet ds_Hanghoa_Ban;
        DataSet dsDm_Loai_Hanghoa_Ban;
        DataSet ds_Nhansu;
        DataSet dsDonvitinh = new DataSet();
        #region local data
        //bool Exists_Sys_Lognotify_Path = false;
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_rex_nhansu;
        #endregion

        public enum BizFlow
        {
            Frmware_Donmuahang,
            Frmware_Nhap_Hh_Ban,
            Frmware_Hh_Mua_Tra_Ncc,
            Frmware_Hdmuahang
        }

        #region Initialize

        public Frmware_Donmuahang()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                //System.IO.Directory.Delete(@"Resources\localdata", true);
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            //datetime mask
            dtNgay_Muahang.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Muahang.Properties.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            //reset lookup edit as delete value
            lookUpEdit_Nguoi_Lap.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            dockPanel3.Hide();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
            //this.gridView5.OptionsBehavior.Editable = false;
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

        void LoadMasterData()
        {
            #region code ole, not use
            /*
            string vlog_WARE_DM_HANGHOA_BAN = log_WARE_DM_HANGHOA_BAN;
            string vlog_REX_NHANSU = log_REX_NHANSU;

            Exists_Sys_Lognotify_Path = System.IO.File.Exists(Sys_Lognotify_Path);
            if (Exists_Sys_Lognotify_Path)
            {
                //get last change at local
                dsSys_Lognotify = new DataSet();
                dsSys_Lognotify.ReadXml(Sys_Lognotify_Path);

                //write new log change from database --> write to local last change
                DataSet dsSys_Lognotify_db = objMasterService.GetAll_Sys_Lognotify().ToDataSet();
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

                    log_WARE_DM_HANGHOA_BAN = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'").Length > 0)
                    ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'")[0]["Last_Change"] : "";
                    log_REX_NHANSU = (dsSys_Lognotify.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";

                    vlog_WARE_DM_HANGHOA_BAN = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'")[0]["Last_Change"] : "";
                    vlog_REX_NHANSU = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";
                }
            }
            else
            {
                dsSys_Lognotify = new DataSet();
                dsSys_Lognotify = objMasterService.GetAll_Sys_Lognotify().ToDataSet();
                dsSys_Lognotify.WriteXml(Sys_Lognotify_Path, XmlWriteMode.WriteSchema);
            }
            */
            #endregion

            //load data from local xml when last change at local differ from database
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_hanghoa_ban], "
                 + "[ware_dm_donvitinh],[ware_hanghoa_dinhgia], [rex_nhansu]").ToDataSet();
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
            if (DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0
                || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN))
            {
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                ds_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
                ds_Hanghoa_Ban.Tables[0].Columns.Add("Soluong", typeof(double));
            }
            else
            {
                ds_Hanghoa_Ban = new DataSet();
                ds_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
                ds_Hanghoa_Ban.Tables[0].Columns.Add("Soluong", typeof(double));
            }
            if (DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0
               || !System.IO.File.Exists(xml_REX_NHANSU))
            {
                ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                ds_Nhansu.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else if (ds_Nhansu == null || ds_Nhansu.Tables.Count == 0)
            {
                ds_Nhansu = new DataSet();
                ds_Nhansu.ReadXml(xml_REX_NHANSU);
            }
            if (DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0
             || !System.IO.File.Exists(xml_WARE_DM_DONVITINH))
            {
                dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                dsDonvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            }
            else
            {
                if (dsDonvitinh == null || dsDonvitinh.Tables.Count == 0)
                {
                    dsDonvitinh = new DataSet();
                    dsDonvitinh.ReadXml(xml_WARE_DM_DONVITINH);
                }
            }
            //DataSet dsCuahang_Ban = new DataSet();
            //dsCuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet();
            lookUpEditCuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
            lookUpEdit_Nguoi_Lap.Properties.DataSource = ds_Nhansu.Tables[0];
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa.DataSource = ds_Hanghoa_Ban.Tables[0];
            dgware_Dm_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];
            gridLookUpEdit_Donvitinh2.DataSource = dsDonvitinh.Tables[0];
        }

        #endregion

        #region Event Override


        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();
                //Get data Ware_Dm_Nhacungcap & Nhacungcap (NCC dùng ware_dm_khachhang
                gridLookUpEdit_Nhacungcap.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
                //gridLookUpEdit_Nhasanxuat.DataSource = objMasterService.Get_All_Ware_Dm_Nhasanxuat().ToDataSet().Tables[0];
                //Get data Ware_Donmuahang
                this.ChangeStatus(false);
                this.dtThang_Nam.EditValue = DateTime.Now;
                //Reload_Chungtu(dtThang_Nam.DateTime);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        void DisplayInfo2()
        {
            try
            {
                if ("" + gridView1.GetFocusedRowCellValue("Id_Donmuahang") == "")
                {
                    dgware_Donmuahang_Chitiet.DataSource = null;
                    return;
                }
                object identity = gridView1.GetFocusedRowCellValue("Id_Donmuahang");
                this.ds_Donmuahang_Chitiet = objWareService.Get_All_Ware_Donmuahang_Chitiet_By_Donmuahang(identity != null ? identity : 0).ToDataSet();
                this.ds_Donmuahang_Chitiet.Tables[0].Columns.Add("Chon", typeof(Boolean));
                this.ds_Donmuahang_Chitiet.Tables[0].Columns.Add("Soluong_Chenhlech", typeof(decimal));
                this.ds_Donmuahang_Chitiet.Tables[0].Columns.Add("Chitiet_Ncc", typeof(string));
                this.dgware_Donmuahang_Chitiet.DataSource = ds_Donmuahang_Chitiet;
                this.dgware_Donmuahang_Chitiet.DataMember = ds_Donmuahang_Chitiet.Tables[0].TableName;
                // neu chung tu da duoc xac nhan thi cho phep in
                if (Convert.ToInt64(gridView1.GetFocusedRowCellValue("Doc_Process_Status")) != 2)
                {
                    this.gvware_Donmuahang_Chitiet.OptionsBehavior.Editable = false;
                    gvware_Donmuahang_Chitiet.Columns["Chon"].OptionsColumn.ReadOnly = true;
                    //this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    this.gvware_Donmuahang_Chitiet.OptionsBehavior.Editable = (this.MdiParent != null) ? false : true;
                    gvware_Donmuahang_Chitiet.OptionsBehavior.ReadOnly = false;
                    gvware_Donmuahang_Chitiet.Columns["Chon"].OptionsColumn.ReadOnly = false;
                    //this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                gvware_Donmuahang_Chitiet.BestFitColumns();
            }
            catch { }
        }

        public override void ClearDataBindings()
        {
            this.txtMa_Donmuahang.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Muahang.DataBindings.Clear();
            this.lookUpEdit_Nguoi_Lap.DataBindings.Clear();
            this.lookUpEditCuahang_Ban.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Donmuahang.DataBindings.Add("EditValue", ds_Donmuahang, ds_Donmuahang.Tables[0].TableName + ".Ma_Donmuahang");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Donmuahang, ds_Donmuahang.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Muahang.DataBindings.Add("EditValue", ds_Donmuahang, ds_Donmuahang.Tables[0].TableName + ".Ngay_Muahang");
                this.lookUpEdit_Nguoi_Lap.DataBindings.Add("EditValue", ds_Donmuahang, ds_Donmuahang.Tables[0].TableName + ".Id_Nhansu_Lap");
                this.lookUpEditCuahang_Ban.DataBindings.Add("EditValue", ds_Donmuahang, ds_Donmuahang.Tables[0].TableName + ".Id_Cuahang_Ban");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            this.dgware_Donmuahang.Enabled = !editTable;
            //this.gridView5.OptionsBehavior.Editable = (this.MdiParent != null) ? editTable : true;
            this.gvware_Donmuahang_Chitiet.OptionsBehavior.Editable = editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.lookUpEditCuahang_Ban.Properties.ReadOnly = !editTable;
            this.dgware_Donmuahang_Chitiet.EmbeddedNavigator.Enabled = editTable;
            dockPanel3.Enabled = editTable;
            gridColumn37.Visible = editTable;//delete button
            gridColumn18.Visible = editTable;//giá theo ncc
            gridColumn15.Visible = !editTable;//sl nhap
            gridColumn16.Visible = !editTable;//sl thanh toan
            gridColumn38.Visible = !editTable;//sl tra ncc
        }

        public override void ResetText()
        {
            this.txtGhichu.EditValue = "";
            this.ds_Donmuahang_Chitiet = objWareService.Get_All_Ware_Donmuahang_Chitiet_By_Donmuahang(0).ToDataSet();
            this.dgware_Donmuahang_Chitiet.DataSource = ds_Donmuahang_Chitiet.Tables[0];
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Donmuahang objWare_Donmuahang = new Ecm.WebReferences.WareService.Ware_Donmuahang();
                objWare_Donmuahang.Id_Donmuahang = -1;
                objWare_Donmuahang.Ma_Donmuahang = txtMa_Donmuahang.EditValue;
                objWare_Donmuahang.Ghichu = txtGhichu.EditValue;
                objWare_Donmuahang.Ngay_Muahang = dtNgay_Muahang.EditValue;

                if ("" + lookUpEditCuahang_Ban.EditValue != "")
                    objWare_Donmuahang.Id_Kho_Hanghoa_Mua = lookUpEditCuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nguoi_Lap.EditValue != "")
                    objWare_Donmuahang.Id_Nhansu_Lap = lookUpEdit_Nguoi_Lap.EditValue;

                object identity = objWareService.Insert_Ware_Donmuahang(objWare_Donmuahang);
                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Donmuahang_Chitiet);//dgware_Donmuahang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Donmuahang_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Donmuahang"] = identity;
                    }
                    //update donmuahang_chitiet
                    objWareService.Update_Ware_Donmuahang_Chitiet_Collection(ds_Donmuahang_Chitiet);
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
                Ecm.WebReferences.WareService.Ware_Donmuahang objWare_Donmuahang = new Ecm.WebReferences.WareService.Ware_Donmuahang();
                objWare_Donmuahang.Id_Donmuahang = gridView1.GetFocusedRowCellValue("Id_Donmuahang");
                objWare_Donmuahang.Ma_Donmuahang = txtMa_Donmuahang.EditValue;
                objWare_Donmuahang.Ghichu = txtGhichu.EditValue;
                objWare_Donmuahang.Ngay_Muahang = dtNgay_Muahang.EditValue;

                if ("" + lookUpEditCuahang_Ban.EditValue != "")
                    objWare_Donmuahang.Id_Kho_Hanghoa_Mua = lookUpEditCuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nguoi_Lap.EditValue != "")
                    objWare_Donmuahang.Id_Nhansu_Lap = lookUpEdit_Nguoi_Lap.EditValue;
                //update donmuahang
                objWareService.Update_Ware_Donmuahang(objWare_Donmuahang);
                //update donmuahang_chitiet
                this.DoClickEndEdit(dgware_Donmuahang_Chitiet);//dgware_Donmuahang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                foreach (DataRow dr in ds_Donmuahang_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Donmuahang"] = gridView1.GetFocusedRowCellValue("Id_Donmuahang");
                }
                objWareService.Update_Ware_Donmuahang_Chitiet_Collection(ds_Donmuahang_Chitiet);
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
            Ecm.WebReferences.WareService.Ware_Donmuahang objWare_Donmuahang = new Ecm.WebReferences.WareService.Ware_Donmuahang();
            objWare_Donmuahang.Id_Donmuahang = gridView1.GetFocusedRowCellValue("Id_Donmuahang");
            return objWareService.Delete_Ware_Donmuahang(objWare_Donmuahang);
        }

        public override bool PerformAdd()
        {
            lookUpEdit_Nguoi_Lap.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            DataSet ds_Kho_Hanghoa = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nguoi_Lap.EditValue).ToDataSet();
            this.lookUpEditCuahang_Ban.Properties.DataSource = ds_Kho_Hanghoa.Tables[0];
            this.ChangeStatus(true);
            if (ds_Kho_Hanghoa.Tables[0].Rows.Count == 0)
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                lookUpEdit_Nguoi_Lap.EditValue = null;
                return false;
            }
            else
            {
                lookUpEditCuahang_Ban.EditValue = ds_Kho_Hanghoa.Tables[0].Rows[0]["Id_Cuahang_Ban"];
                if (ds_Kho_Hanghoa.Tables[0].Rows.Count > 1)
                    lookUpEditCuahang_Ban.Properties.ReadOnly = false;
                else
                    lookUpEditCuahang_Ban.Properties.ReadOnly = true;
            }
            dockPanel3.Show();
            this.ResetText();
            ClearDataBindings();
            GetDs_Hanghoa_MuaBy_Id_Kho_Hh_Mua();
            dtNgay_Muahang.EditValue = objWareService.GetServerDateTime();
            txtMa_Donmuahang.EditValue = objWareService.GetNew_Sochungtu("ware_donmuahang", "ma_donmuahang", lookUpEditCuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
            return true;
        }

        public override bool PerformEdit()
        {
            if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nguoi_Lap.EditValue))
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return false;
            }

            if (gridView1.GetFocusedRowCellValue("Id_Donmuahang") == null)
                return false;
            try
            {
                if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nguoi_Lap.EditValue))
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
                else
                {
                    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "ware_donmuahang";
                    DocumentProcessStatus.PK_Name = "id_donmuahang";
                    DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Donmuahang");
                    DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                        return false;
                    }
                    dockPanel3.Show();
                }
                this.ChangeStatus(true);
                GetDs_Hanghoa_MuaBy_Id_Kho_Hh_Mua();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return true;
        }

        public override bool PerformCancel()
        {
            dockPanel3.Hide();
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                if (gvware_Donmuahang_Chitiet.RowCount == 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa có hàng hóa, nhập hàng hóa");
                    return false;
                }
                this.DoClickEndEdit(dgware_Donmuahang_Chitiet);
                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(gvware_Donmuahang_Chitiet.Columns["Id_Hanghoa_Ban"], "");
                hashtableControls.Add(gvware_Donmuahang_Chitiet.Columns["Soluong"], "");
                hashtableControls.Add(gvware_Donmuahang_Chitiet.Columns["Dongia"], "");
                System.Collections.Hashtable hashtableUnique = new System.Collections.Hashtable();
                hashtableUnique.Add(gvware_Donmuahang_Chitiet.Columns["Id_Hanghoa_Ban"], gvware_Donmuahang_Chitiet.Columns["Id_Hanghoa_Ban"].Caption);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableUnique, gvware_Donmuahang_Chitiet))
                    return false;

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvware_Donmuahang_Chitiet))
                    return false;

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = (bool)this.UpdateObject();
                }
                if (success)
                {
                    this.DisplayInfo();
                    dockPanel3.Hide();
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
            if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nguoi_Lap.EditValue))
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return false;
            }

            if (gridView1.GetFocusedRowCellValue("Id_Donmuahang") == null)
                return false;
            try
            {
                Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                DocumentProcessStatus.Tablename = "ware_donmuahang";
                DocumentProcessStatus.PK_Name = "id_donmuahang";
                DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Donmuahang");
                DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);

                if ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                    if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nguoi_Lap.EditValue))
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                        return false;
                    }
                    else
                    {
                        if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                        {
                             GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                            return false;
                        }
                    }
                if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                    return false;
                }
                if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                 GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Donmuahang"),
                 GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Donmuahang")   }) == DialogResult.Yes)
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
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Donmuahang") == null)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn Phiếu dự trù mua hàng, vui lòng chọn lại");
                    return false;
                }
                this.DoClickEndEdit(dgware_Donmuahang_Chitiet);//dgware_Donmuahang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                DataRow[] drSelected = ds_Donmuahang_Chitiet.Tables[0].Select("Chon = true");
                dsSelected = ds_Donmuahang_Chitiet.Clone();
                foreach (DataRow dr in drSelected)
                {
                    dsSelected.Tables[0].ImportRow(dr);
                }
                this.Dispose();
                this.Close();
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        public override bool PerformPrintPreview()
        {
            if (gridView1.GetFocusedRowCellValue("Id_Donmuahang") == null || ds_Donmuahang_Chitiet.Tables.Count == 0)
                return false;
            DataSets.dsDutru_Muahang dsDutru_Muahang = new Ecm.Ware.DataSets.dsDutru_Muahang();
            if (ds_Donmuahang_Chitiet.Tables[0].Columns.IndexOf("Stt") == -1)
                ds_Donmuahang_Chitiet.Tables[0].Columns.Add("Stt");
            int i = 1;
            foreach (DataRow dr in ds_Donmuahang_Chitiet.Tables[0].Rows)
            {
                dr["Stt"] = i++;
                dsDutru_Muahang.Tables["ware_donmuahang_chitiet"].ImportRow(dr);
            }
            //Add datasoure & show report
            Reports.rptKehoach_Banhang rptDutru_Muahang = new Ecm.Ware.Reports.rptKehoach_Banhang();
             GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptDutru_Muahang;
            rptDutru_Muahang.DataSource = dsDutru_Muahang;
            rptDutru_Muahang.xrcell_Ngay_Chungtu.Text = dtNgay_Muahang.Text;
            //rptDutru_Muahang.xrcell_Sochungtu.Text = txtMa_Donmuahang.Text;
            //rptDutru_Muahang.lblNguoi_Denghi.Text = lookUpEdit_Nguoi_Lap.Text;
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

                rptDutru_Muahang.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptDutru_Muahang.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                //rptDutru_Muahang.xrPic_Logo.DataBindings.Add(
                //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            rptDutru_Muahang.CreateDocument();
             GoobizFrame.Windows.Forms.ReportOptions oReportOptions =  GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptDutru_Muahang);
             if (Convert.ToBoolean(oReportOptions.PrintPreview))
             {
                 frmPrintPreview.Text = "" + oReportOptions.Caption;
                 frmPrintPreview.printControl1.PrintingSystem = rptDutru_Muahang.PrintingSystem;
                 frmPrintPreview.MdiParent = this.MdiParent;
                 frmPrintPreview.Show();
                 frmPrintPreview.Activate();
             }
             else
             {
                 var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptDutru_Muahang);
                 reportPrintTool.Print();
             }
            return base.PerformPrintPreview();
        }
        #endregion

        #region Even

        private void Frmware_Donmuahang_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
                gvware_Donmuahang_Chitiet.Columns["Chon"].Visible = false;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DisplayInfo2();
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia")
            {
                try
                {
                    int soluong = 0;
                    decimal dongia = 0;
                    decimal thanhtien = 0;

                    if ("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong") != "")
                        soluong = Convert.ToInt32(gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong"));

                    if ("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Dongia") != "")
                        dongia = Convert.ToDecimal(gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Dongia"));

                    thanhtien = soluong * dongia;
                    if (thanhtien.ToString().Length > 16)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị thành tiền vượt quá khả năng lưu trữ.");
                        gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Soluong"], null);
                        gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Dongia"], null);
                    }
                    else
                        gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Thanhtien"], thanhtien);

                }
                catch (Exception ex)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị thành tiền vượt quá khả năng lưu trữ.");
                    gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Soluong"], null);
                    gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Dongia"], null);
                }
            }

            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Id_Donvitinh"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
            }

            if (e.Column.FieldName == "Chon")
            {
                switch (oBizFlow)
                {
                    case BizFlow.Frmware_Hdmuahang: //kiem tra chenh lech Soluong_Thanhtoan va Soluong
                        if ("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong_Thanhtoan") != ""
                            && Convert.ToDecimal("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong"))
                               - Convert.ToDecimal("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong_Thanhtoan")) <= 0)
                        {
                             GoobizFrame.Windows.Forms.MessageDialog.Show(String.Format("[{0}] đã được thanh toán xong, nên không thể chọn",
                                gvware_Donmuahang_Chitiet.GetFocusedRowCellDisplayText("Id_Hanghoa_Ban")));
                            gvware_Donmuahang_Chitiet.CancelUpdateCurrentRow();
                        }
                        else
                            gvware_Donmuahang_Chitiet.GetDataRow(gvware_Donmuahang_Chitiet.FocusedRowHandle)["Soluong_Chenhlech"] =
                                Convert.ToDecimal("0" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong"))
                               - Convert.ToDecimal("0" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong_Thanhtoan"));
                        break;
                    case BizFlow.Frmware_Hh_Mua_Tra_Ncc:
                        if ("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong_Tra_Ncc") != ""
                            && Convert.ToDecimal("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong"))
                               - Convert.ToDecimal("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong_Tra_Ncc")) <= 0)
                        {
                             GoobizFrame.Windows.Forms.MessageDialog.Show(String.Format("[{0}] đã được trả NCC xong, nên không thể chọn",
                                gvware_Donmuahang_Chitiet.GetFocusedRowCellDisplayText("Id_Hanghoa_Ban")));
                            gvware_Donmuahang_Chitiet.CancelUpdateCurrentRow();
                        }
                        else
                            gvware_Donmuahang_Chitiet.GetDataRow(gvware_Donmuahang_Chitiet.FocusedRowHandle)["Soluong_Chenhlech"] =
                                Convert.ToDecimal("0" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong"))
                               - Convert.ToDecimal("0" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong_Tra_Ncc"));
                        break;
                    case BizFlow.Frmware_Nhap_Hh_Ban:
                        if ("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong_Nhapkho") != ""
                            && Convert.ToDecimal("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong"))
                               - Convert.ToDecimal("" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong_Nhapkho")) <= 0)
                        {
                             GoobizFrame.Windows.Forms.MessageDialog.Show(String.Format("[{0}] đã được nhập kho xong, nên không thể chọn",
                                gvware_Donmuahang_Chitiet.GetFocusedRowCellDisplayText("Id_Hanghoa_Ban")));
                            gvware_Donmuahang_Chitiet.CancelUpdateCurrentRow();
                        }
                        else
                            gvware_Donmuahang_Chitiet.GetDataRow(gvware_Donmuahang_Chitiet.FocusedRowHandle)["Soluong_Chenhlech"] =
                                Convert.ToDecimal("0" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong"))
                               - Convert.ToDecimal("0" + gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Soluong_Nhapkho"));
                        break;
                }
            }
            this.DoClickEndEdit(dgware_Donmuahang_Chitiet);//dgware_Donmuahang_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }

        private void chkShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            this.gridView1.OptionsView.ShowPreview = chkShowPreview.Checked;
        }

        private void lookUpEditKho_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            GetDs_Hanghoa_MuaBy_Id_Kho_Hh_Mua();
        }

        private void lookUpEditCuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            if (this.FormState !=  GoobizFrame.Windows.Forms.FormState.View)
                txtMa_Donmuahang.EditValue = objWareService.GetNew_Sochungtu("ware_donmuahang", "ma_donmuahang", lookUpEditCuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
        }

        #region process card view

        /// <summary>
        /// chọn loại hàng --> hiển thị ds hàng hóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cardView2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView2.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                ShowTabPage(xtraTabControl1, xtraTabPage3);
                object id_loai_Hh = dsDm_Loai_Hanghoa_Ban.Tables[0].Rows[cardHit.RowHandle]["Id_Loai_Hanghoa_Ban"];
                cardView1.Columns["Id_Loai_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
               "Id_Loai_Hanghoa_Ban = " + id_loai_Hh);
            }
        }

        /// <summary>
        /// chọn hàng hóa --> add vào gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void cardView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cardView1.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                object id_Hanghoa_ban = cardView1.GetDataRow(cardHit.RowHandle)["Id_Hanghoa_Ban"];
                DataRow[] sdrDm_Hanghoa_Mua = null;
                if (cardView1.GetDataRow(cardHit.RowHandle)["Id_Donvitinh"].ToString() != "")
                    sdrDm_Hanghoa_Mua = ds_Donmuahang_Chitiet.Tables[0].Select("Id_Hanghoa_Ban =" + id_Hanghoa_ban
                                                     + "and Id_Donvitinh = " + cardView1.GetDataRow(cardHit.RowHandle)["Id_Donvitinh"]);
                else
                    sdrDm_Hanghoa_Mua = ds_Donmuahang_Chitiet.Tables[0].Select("Id_Hanghoa_Ban =" + id_Hanghoa_ban);

                if (sdrDm_Hanghoa_Mua.Length > 0)
                    sdrDm_Hanghoa_Mua[0]["Soluong"] = Convert.ToDecimal(sdrDm_Hanghoa_Mua[0]["Soluong"]) + 1;
                else
                {
                    DataRow nrow = ds_Donmuahang_Chitiet.Tables[0].NewRow();
                    nrow["Id_Hanghoa_Ban"] = id_Hanghoa_ban;
                    nrow["Id_Donvitinh"] = cardView1.GetDataRow(cardHit.RowHandle)["Id_Donvitinh"];
                    nrow["Soluong"] = 1;
                    nrow["Guid"] = Guid.NewGuid();
                    ds_Donmuahang_Chitiet.Tables[0].Rows.Add(nrow);
                }
            }
        }
        #endregion

        #region process button
        private void btnLoaihang_Click(object sender, EventArgs e)
        {
            ShowTabPage(xtraTabControl1, xtraTabPage2);
        }

        private void btnBack_Loaihang_Click_1(object sender, EventArgs e)
        {
            cardView2.MovePrevPage();
        }

        private void btnNext_Loaihang_Click_1(object sender, EventArgs e)
        {
            cardView2.MoveNextPage();
        }

        private void btnBack_Loaihang_Click(object sender, EventArgs e)
        {
            cardView1.MovePrevPage();
        }

        private void btnNext_Loaihang_Click(object sender, EventArgs e)
        {
            cardView1.MoveNextPage();
        }

        #endregion

        #region process button grid
        /// <summary>
        /// Giá mua theo nhà cung cấp
        /// open frmware_Donmuahang_Ncc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //Frmware_Donmuahang_Ncc frmware_Donmuahang_Ncc = new Frmware_Donmuahang_Ncc();
                //frmware_Donmuahang_Ncc.Text = gvware_Donmuahang_Chitiet.Columns["Chitiet_Ncc"].Caption;
                // GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Donmuahang_Ncc);
                // GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(frmware_Donmuahang_Ncc);
                //frmware_Donmuahang_Ncc.Guid = gvware_Donmuahang_Chitiet.GetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Guid"]);
                //frmware_Donmuahang_Ncc.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //frmware_Donmuahang_Ncc.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //frmware_Donmuahang_Ncc.xtraHNavigator1.Enabled = false;
                ////frmware_Donmuahang_Ncc.Id_Donmuahang_Chitiet = gridView5.GetFocusedRowCellValue("Id_Donmuahang_Chitiet");
                //frmware_Donmuahang_Ncc.Id_Hanghoa_Ban = gvware_Donmuahang_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban");
                ////if (Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Doc_Process_Status")) != 0)
                ////{
                ////    frmware_Donmuahang_Ncc.EnableAdd = false;
                ////    frmware_Donmuahang_Ncc.EnableEdit = false;
                ////    frmware_Donmuahang_Ncc.EnableDelete = false;
                ////}
                //if (FormState !=  GoobizFrame.Windows.Forms.FormState.View)
                //{
                //    frmware_Donmuahang_Ncc.ShowDialog();
                //    if (frmware_Donmuahang_Ncc.ds_Donmuahang_Chitiet_Ncc.Tables.Count == 0)
                //        return;
                //    DataRow[] sdr = frmware_Donmuahang_Ncc.ds_Donmuahang_Chitiet_Ncc.Tables[0].Select("Chon = true");
                //    if (sdr != null && sdr.Length > 0)
                //    {
                //        //Get data Ware_Dm_Nhacungcap
                //        gridLookUpEditNhacungcap.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0]; //Get_All_Ware_Dm_Nhacungcap().ToDataSet().Tables[0];
                //        gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Id_Khachhang"], sdr[0]["Id_Khachhang"]);
                //        gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Dongia"], sdr[0]["Dongia"]);
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
        }

        // xóa hàng hóa trên grid
        void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gvware_Donmuahang_Chitiet.GetDataRow(gvware_Donmuahang_Chitiet.FocusedRowHandle).Delete();
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add frm_Donvitinh = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add();
                if (gvware_Donmuahang_Chitiet.GetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Id_Hanghoa_Ban"]).ToString() == "")
                    return;
                frm_Donvitinh.setId_Hanghoa_Ban(gvware_Donmuahang_Chitiet.GetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Id_Hanghoa_Ban"]));
                frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frm_Donvitinh.ShowDialog();
                if (frm_Donvitinh.SelecteWare_Dm_Donvitinh != null)
                {
                    gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.Columns["Id_Donvitinh"], frm_Donvitinh.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                }
                gvware_Donmuahang_Chitiet.BestFitColumns();
            }
        }
        #endregion

        private void gridText_Soluong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToInt32(e.NewValue) <= 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng phải lớn hơn 0, vui lòng nhập lại.");
                    gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToInt32(e.NewValue) > int.MaxValue)
                {
                    // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                    //gridView5.SetFocusedRowCellValue(gridView5.FocusedColumn, null);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                //Nếu số lượng vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                //gridView5.SetFocusedRowCellValue(gridView5.Columns["Soluong"], null);
                e.Cancel = true;
            }
        }

        private void gridText_Tien_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToDecimal(e.NewValue) <= 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Đơn giá phải lớn hơn 0, vui lòng nhập lại.");
                    gvware_Donmuahang_Chitiet.SetFocusedRowCellValue(gvware_Donmuahang_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (e.NewValue.ToString().Length > 16)
                {
                    //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                    // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị đơn giá không hợp lệ, vui lòng nhập lại.");
                    //gridView5.SetFocusedRowCellValue(gridView5.FocusedColumn, null);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị đơn giá không hợp lệ, vui lòng nhập lại.");
                //gridView5.SetFocusedRowCellValue(gridView5.Columns["Dongia"], null);
                e.Cancel = true;
            }
        }

        #endregion

        #region Custom Method

        private void GetDs_Hanghoa_MuaBy_Id_Kho_Hh_Mua()
        {
            ShowTabPage(xtraTabControl1, xtraTabPage2);
            if (cardView2.RowCount == 0)
            {
                try
                {
                    if (dsDm_Loai_Hanghoa_Ban == null)
                        dsDm_Loai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
                    dgware_Dm_Loai_Hanghoa_Ban.DataSource = dsDm_Loai_Hanghoa_Ban;
                    dgware_Dm_Loai_Hanghoa_Ban.DataMember = dsDm_Loai_Hanghoa_Ban.Tables[0].TableName;
                    if (cardView2.FormatConditions.Count == 0)
                        if (dsDm_Loai_Hanghoa_Ban.Tables[0].Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dsDm_Loai_Hanghoa_Ban.Tables[0].Rows[0]["Id_Nhom_Hanghoa_Ban"]);
                            foreach (DataRow dr in dsDm_Loai_Hanghoa_Ban.Tables[0].Rows)
                            {
                                DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                                styleFormatCondition.Appearance.BackColor =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetColor(Convert.ToInt32(dr["Id_Nhom_Hanghoa_Ban"]) % i);
                                styleFormatCondition.Appearance.Options.UseBackColor = true;
                                styleFormatCondition.ApplyToRow = true;
                                styleFormatCondition.Column = cardView2.Columns["Id_Nhom_Hanghoa_Ban"];
                                styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                                styleFormatCondition.Value1 = Convert.ToDecimal(dr["Id_Nhom_Hanghoa_Ban"]);
                                cardView2.FormatConditions.Add(styleFormatCondition);
                            }
                            cardView2.Columns["Id_Nhom_Hanghoa_Ban"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        }
                    if (ds_Hanghoa_Ban.Tables[0].Rows.Count > 0)
                    {
                        int i = Convert.ToInt32("0" + ds_Hanghoa_Ban.Tables[0].Rows[0]["Id_Donvitinh"]);
                        foreach (DataRow drNhom_Hanghoa_Ban in ds_Hanghoa_Ban.Tables[0].Rows)
                        {
                            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                            styleFormatCondition.Appearance.BackColor =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetColor(Convert.ToInt32(drNhom_Hanghoa_Ban["Id_Donvitinh"]) % i);
                            styleFormatCondition.Appearance.Options.UseBackColor = true;
                            styleFormatCondition.ApplyToRow = true;
                            styleFormatCondition.Column = this.cardView1.Columns["Id_Donvitinh"];
                            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                            styleFormatCondition.Value1 = Convert.ToDecimal(drNhom_Hanghoa_Ban["Id_Donvitinh"]);
                            this.cardView1.FormatConditions.Add(styleFormatCondition);
                        }
                        this.cardView1.Columns["Id_Hanghoa_Ban"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                }
                catch { }
            }
        }


        void ShowTabPage(DevExpress.XtraTab.XtraTabControl xtraTabControl,
                         DevExpress.XtraTab.XtraTabPage xtraTabPage)
        {
            while (xtraTabControl.TabPages.Count > 0)
                xtraTabControl.TabPages.RemoveAt(0);
            xtraTabControl.TabPages.Add(xtraTabPage);
        }
        #endregion

        private void dtThang_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (dtThang_Nam.Text != "")
                Reload_Chungtu(dtThang_Nam.DateTime);
            else
                Reload_Chungtu(null);
        }

        void Reload_Chungtu(object Ngay_Chungtu)
        {
            ds_Donmuahang = objWareService.Get_All_Ware_Donmuahang(Ngay_Chungtu).ToDataSet();
            dgware_Donmuahang.DataSource = ds_Donmuahang;
            dgware_Donmuahang.DataMember = ds_Donmuahang.Tables[0].TableName;
            if (ds_Donmuahang.Tables[0].Rows.Count != 0)
            {
                this.DataBindingControl();
                this.gridView1.BestFitColumns();
            }
            //DisplayInfo2();
        }

        private void gridLookUpEdit_Ma_Hanghoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                try
                {
                    var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                        "Ecm.MasterTables.dll",
                        "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

                    if (dialog == null)
                        return;

                    ds_Hanghoa_Ban = dialog.GetType().GetProperty("DsDm_Hanghoa_Ban").GetValue(dialog, null) as DataSet;
                    gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
                    gridLookUpEdit_Ma_Hanghoa.DataSource = ds_Hanghoa_Ban.Tables[0];

                    var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;

                    if (SelectedObject != null)
                        gvware_Donmuahang_Chitiet.SetFocusedRowCellValue("Id_Hanghoa_Ban", SelectedObject.Id_Hanghoa_Ban);
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
            }
        }

    }
}
