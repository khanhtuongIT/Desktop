using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{

    public partial class Frmware_Donmuahang_Kh_Hhban :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Donmuahang_Kh = new DataSet();
        DataSet ds_Donmuahang_Kh_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();
        DataSet ds_Hanghoa_Dinhgia = new DataSet();
        DataSet dsDonvitinh = new DataSet();
        DataSet dsNhansu = new DataSet();
        public DataSet dsSelected = new DataSet();
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_rex_nhansu;

        #region Initialize

        public Frmware_Donmuahang_Kh_Hhban()
        {
            InitializeComponent();
            //this.AllowTest = EnableTest;
            //this.AllowVerify = EnableVerify;
            //date mask
            dtNgay_Muahang.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Muahang.Properties.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            dtNgay_Giaohang.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Giaohang.Properties.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit1.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            this.DisplayInfo();
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
            //load data from local xml when last change at local differ from database
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_hanghoa_ban], "
                                         + "[ware_dm_donvitinh],  [rex_nhansu]").ToDataSet();
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
            if (DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0
               || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN))
            {
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                ds_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else
            {
                if (ds_Hanghoa_Ban == null || ds_Hanghoa_Ban.Tables.Count == 0)
                {
                    ds_Hanghoa_Ban = new DataSet();
                    ds_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
                }
            }
            if (DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0
                || !System.IO.File.Exists(xml_REX_NHANSU))
            {
                dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                dsNhansu.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else
            {
                if (dsNhansu == null || dsNhansu.Tables.Count == 0)
                {
                    dsNhansu = new DataSet();
                    dsNhansu.ReadXml(xml_REX_NHANSU);
                }
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
            lookUpEdit_Nhansu_Lap.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEditMa_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];
        }
        #endregion

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();
                //Get data Get_All_Ware_Dm_Cuahang_Ban
                lookUpEdit_Cuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
                //Get data Get_All_Ware_Dm_Hanghoa_Ban
                ds_Hanghoa_Dinhgia = objWareService.Get_All_Ware_Hanghoa_Ban_Dinhgia().ToDataSet();
                //Get data Get_All_Ware_Dm_Khachhang
                DataSet dsWare_Dm_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                gridLookUpEdit_Khachhang.DataSource = dsWare_Dm_Khachhang.Tables[0];
                lookUpEdit_Khachhang.Properties.DataSource = dsWare_Dm_Khachhang.Tables[0];
                //Get data Ware_Donmuahang
                this.dtThang_Nam.EditValue = DateTime.Now;
                //Reload_Chungtu(dtThang_Nam.DateTime);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        void DisplayInfo2()
        {
            try
            {
                this.ChangeFormState( GoobizFrame.Windows.Forms.FormState.View);
                if ("" + gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh") != "")
                {
                    this.ds_Donmuahang_Kh_Chitiet = objWareService.Get_All_Ware_Donmuahang_Kh_Chitiet_By_Donmuahang_Kh(gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh")).ToDataSet();
                    this.dgware_Donmuahang_Kh_Chitiet.DataSource = ds_Donmuahang_Kh_Chitiet;
                    this.dgware_Donmuahang_Kh_Chitiet.DataMember = ds_Donmuahang_Kh_Chitiet.Tables[0].TableName;
                    if (ds_Donmuahang_Kh_Chitiet.Tables[0].Rows[0]["Dongia_Bansi"].ToString() == ""
                            || ds_Donmuahang_Kh_Chitiet.Tables[0].Rows[0]["Dongia_Bansi"].ToString() == "0")
                        chkDongia_Bansi.Checked = false;
                    else
                        chkDongia_Bansi.Checked = true;
                    gridView4.BestFitColumns();
                }
                else
                {
                    dgware_Donmuahang_Kh_Chitiet.DataSource = null;
                    this.ResetText();
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ClearDataBindings()
        {
            this.txtId_Donmuahang_Kh.DataBindings.Clear();
            this.txtMa_Donmuahang_Kh.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Muahang.DataBindings.Clear();
            this.dtNgay_Giaohang.DataBindings.Clear();
            this.lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEdit_Khachhang.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Lap.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Donmuahang_Kh.DataBindings.Add("EditValue", ds_Donmuahang_Kh, ds_Donmuahang_Kh.Tables[0].TableName + ".Id_Donmuahang_Kh");
                this.txtMa_Donmuahang_Kh.DataBindings.Add("EditValue", ds_Donmuahang_Kh, ds_Donmuahang_Kh.Tables[0].TableName + ".Ma_Donmuahang_Kh");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Donmuahang_Kh, ds_Donmuahang_Kh.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Muahang.DataBindings.Add("EditValue", ds_Donmuahang_Kh, ds_Donmuahang_Kh.Tables[0].TableName + ".Ngay_Muahang");
                this.dtNgay_Giaohang.DataBindings.Add("EditValue", ds_Donmuahang_Kh, ds_Donmuahang_Kh.Tables[0].TableName + ".Ngay_Giaohang");
                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", ds_Donmuahang_Kh, ds_Donmuahang_Kh.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_Khachhang.DataBindings.Add("EditValue", ds_Donmuahang_Kh, ds_Donmuahang_Kh.Tables[0].TableName + ".Id_Khachhang");
                this.lookUpEdit_Nhansu_Lap.DataBindings.Add("EditValue", ds_Donmuahang_Kh, ds_Donmuahang_Kh.Tables[0].TableName + ".Id_Nhansu_Lap");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

            }
        }

        public override void ChangeStatus(bool editTable)
        {
            this.dgware_Donmuahang_Kh.Enabled = !editTable;
            this.dgware_Donmuahang_Kh_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gridView4.OptionsBehavior.Editable = editTable;
            this.txtMa_Donmuahang_Kh.Properties.ReadOnly = true;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.txtDienthoai.Properties.ReadOnly = true;
            this.txtDiachi.Properties.ReadOnly = true;
            this.dtNgay_Muahang.Properties.ReadOnly = true;
            this.dtNgay_Giaohang.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Cuahang_Ban.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Khachhang.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Nhansu_Lap.Properties.ReadOnly = true;
            this.chkDongia_Bansi.Enabled = editTable;
        }

        public override void ResetText()
        {
            this.txtId_Donmuahang_Kh.EditValue = "";
            this.txtGhichu.EditValue = "";
            this.dtNgay_Giaohang.EditValue = null;
            this.chkDongia_Bansi.Checked = false;
            this.lookUpEdit_Khachhang.EditValue = null;
            this.ds_Donmuahang_Kh_Chitiet = objWareService.Get_All_Ware_Donmuahang_Kh_Chitiet_By_Donmuahang_Kh(0).ToDataSet();
            this.dgware_Donmuahang_Kh_Chitiet.DataSource = ds_Donmuahang_Kh_Chitiet.Tables[0];
            this.txtMa_Donmuahang_Kh.EditValue = null;
            this.dtNgay_Muahang.EditValue = null;
            this.lookUpEdit_Nhansu_Lap.EditValue = null;
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Donmuahang_Kh objWare_Donmuahang_Kh = new Ecm.WebReferences.WareService.Ware_Donmuahang_Kh();
                objWare_Donmuahang_Kh.Id_Donmuahang_Kh = -1;
                objWare_Donmuahang_Kh.Ma_Donmuahang_Kh = txtMa_Donmuahang_Kh.EditValue;
                objWare_Donmuahang_Kh.Ghichu = txtGhichu.EditValue;
                objWare_Donmuahang_Kh.Ngay_Muahang = dtNgay_Muahang.EditValue;
                objWare_Donmuahang_Kh.Ngay_Giaohang = dtNgay_Giaohang.EditValue;
                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Donmuahang_Kh.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;

                if ("" + lookUpEdit_Khachhang.EditValue != "")
                    objWare_Donmuahang_Kh.Id_Khachhang = lookUpEdit_Khachhang.EditValue;

                if ("" + lookUpEdit_Nhansu_Lap.EditValue != "")
                    objWare_Donmuahang_Kh.Id_Nhansu_Lap = lookUpEdit_Nhansu_Lap.EditValue;

                object identity = objWareService.Insert_Ware_Donmuahang_Kh(objWare_Donmuahang_Kh);

                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Donmuahang_Kh_Chitiet); //dgware_Donmuahang_Kh_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Donmuahang_Kh_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Donmuahang_Kh"] = identity;
                    }
                    //update Donmuahang_Kh_chitiet
                    objWareService.Update_Ware_Donmuahang_Kh_Chitiet_Collection(ds_Donmuahang_Kh_Chitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Donmuahang_Kh objWare_Donmuahang_Kh = new Ecm.WebReferences.WareService.Ware_Donmuahang_Kh();
                objWare_Donmuahang_Kh.Id_Donmuahang_Kh = gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh");
                objWare_Donmuahang_Kh.Ma_Donmuahang_Kh = txtMa_Donmuahang_Kh.EditValue;
                objWare_Donmuahang_Kh.Ghichu = txtGhichu.EditValue;
                objWare_Donmuahang_Kh.Ngay_Muahang = dtNgay_Muahang.EditValue;

                if ("" + dtNgay_Giaohang.EditValue == "")
                    objWare_Donmuahang_Kh.Ngay_Giaohang = null;
                else
                    objWare_Donmuahang_Kh.Ngay_Giaohang = dtNgay_Giaohang.EditValue;

                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Donmuahang_Kh.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;

                if ("" + lookUpEdit_Khachhang.EditValue != "")
                    objWare_Donmuahang_Kh.Id_Khachhang = lookUpEdit_Khachhang.EditValue;

                if ("" + lookUpEdit_Nhansu_Lap.EditValue != "")
                    objWare_Donmuahang_Kh.Id_Nhansu_Lap = lookUpEdit_Nhansu_Lap.EditValue;

                //update Donmuahang_Kh
                objWareService.Update_Ware_Donmuahang_Kh(objWare_Donmuahang_Kh);

                //update Donmuahang_Kh_chitiet
                this.DoClickEndEdit(dgware_Donmuahang_Kh_Chitiet);
                foreach (DataRow dr in ds_Donmuahang_Kh_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Donmuahang_Kh"] = gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh");
                }

                objWareService.Update_Ware_Donmuahang_Kh_Chitiet_Collection(ds_Donmuahang_Kh_Chitiet);
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
            Ecm.WebReferences.WareService.Ware_Donmuahang_Kh objWare_Donmuahang_Kh = new Ecm.WebReferences.WareService.Ware_Donmuahang_Kh();
            objWare_Donmuahang_Kh.Id_Donmuahang_Kh = gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh");
            return objWareService.Delete_Ware_Donmuahang_Kh(objWare_Donmuahang_Kh);
        }

        public override bool PerformAdd()
        {
            this.ResetText();
            dtNgay_Muahang.EditValue = objWareService.GetServerDateTime();
            //Kiểm tra nếu nhân viên login không tồn tại trong kho hàng hóa mua thì access denied.
            lookUpEdit_Nhansu_Lap.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Lap.EditValue).ToDataSet();
            this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
            if (ds_Cuahang_Ban.Tables[0].Rows.Count > 0)
                lookUpEdit_Cuahang_Ban.EditValue = ds_Cuahang_Ban.Tables[0].Rows[0]["Id_Cuahang_Ban"];
            else
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                lookUpEdit_Nhansu_Lap.EditValue = null;
                return false;
            }
            ClearDataBindings();
            this.ChangeStatus(true);
            txtMa_Donmuahang_Kh.EditValue = objWareService.GetNew_Sochungtu("ware_donmuahang_kh", "ma_donmuahang_kh", "DHKH");
            return true;
        }

        public override bool PerformEdit()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh") == null)
                    return false;
                if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Lap.EditValue))
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
                else
                {
                    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "Ware_Donmuahang_Kh";
                    DocumentProcessStatus.PK_Name = "Id_Donmuahang_Kh";
                    DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh");
                    DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                        return false;
                    }
                }

                DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Lap.EditValue).ToDataSet();
                this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
                if (ds_Cuahang_Ban.Tables[0].Rows.Count == 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    lookUpEdit_Nhansu_Lap.EditValue = null;
                    return false;
                }

                this.ChangeStatus(true);
                if ("" + gridView4.GetRowCellValue(0, "Dongia_Bansi") == "")
                    chkDongia_Bansi.Checked = false;
                else
                    chkDongia_Bansi.Checked = true;
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
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Donmuahang_Kh, lblMa_Donmuahang_Kh.Text);
                hashtableControls.Add(dtNgay_Muahang, lblNgay_Muahang.Text);
                //hashtableControls.Add(dtNgay_Giaohang, lblNgay_Giaohang.Text);
                hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);
                hashtableControls.Add(lookUpEdit_Khachhang, lblKhachhang.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                this.DoClickEndEdit(dgware_Donmuahang_Kh_Chitiet);

                if (gridView4.RowCount == 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa nhập hàng hóa, vui lòng nhập lại");
                    return false;
                }

                System.Collections.Hashtable hashtableUnique = new System.Collections.Hashtable();
                hashtableUnique.Add(gridView4.Columns["Id_Hanghoa_Ban"], "");
                hashtableUnique.Add(gridView4.Columns["Soluong"], "");

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableUnique, gridView4))
                    return false;

                DataRow[] dtr = null;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    dtr = ds_Donmuahang_Kh_Chitiet.Tables[0].Select("Id_Hanghoa_Ban = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Hanghoa_Ban"])
                                                        + "and Id_Donvitinh = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Donvitinh"]));
                    if (dtr.Length > 1)
                    {
                        object donvitinh = dtr[0]["Id_Donvitinh"];
                        for (int x = 0; x < dtr.Length; x++)
                        {
                            if (x == dtr.Length - 1)
                                break;

                            if (donvitinh.Equals(dtr[x]["Id_Donvitinh"]))
                            {
                                 GoobizFrame.Windows.Forms.MessageDialog.Show(dtr[x]["Ten_Hanghoa_Ban"] + " (" + dtr[x]["Ten_Donvitinh"] + ") " +
                                    " đã tồn tại, vui lòng nhập lại hàng hóa khác");
                                return false;
                            }
                        }
                    }
                }
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Muahang, dtNgay_Giaohang))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Muahang, dtNgay_Giaohang))
                        return false;
                    success = (bool)this.UpdateObject();
                }
                if (success)
                {
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public override bool PerformDelete()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh") == null)
                    return false;

                Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                DocumentProcessStatus.Tablename = "Ware_Donmuahang_Kh";
                DocumentProcessStatus.PK_Name = "Id_Donmuahang_Kh";
                DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh");
                DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);

                //if ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Lap.EditValue))
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
                 GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Donmuahang_Kh"),
                 GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Donmuahang_Kh")   }) == DialogResult.Yes)
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
                this.DoClickEndEdit(dgware_Donmuahang_Kh_Chitiet);
                DataRow[] drSelected = ds_Donmuahang_Kh_Chitiet.Tables[0].Select("Chon = true");
                dsSelected = ds_Donmuahang_Kh_Chitiet.Clone();
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

        public override bool PerformTest()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh") == null)
                    return false;
                //show form ShowFormDocProgress
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                    "Ware_Donmuahang_Kh" //Table name
                    , "Id_Donmuahang_Kh" //PK name
                    , gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh") //value
                    ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.TestDoc //New enum DocStatus
                    , false);
                DisplayInfo();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformTest();
        }

        public override bool PerformVerify()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh") == null)
                    return false;
                //show form ShowFormDocProgress
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                    "Ware_Donmuahang_Kh" //Table name
                    , "Id_Donmuahang_Kh" //PK name
                    , gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh") //value
                    ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.VerifyDoc //New enum DocStatus
                    , false);
                DisplayInfo();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformVerify();
        }

        public override bool PerformPrintPreview()
        {
            if (gridView1.GetFocusedRowCellValue("Id_Donmuahang_Kh") == null)
                return false;
            DataSets.dsBaogia_Chitiet dsBaogia_Chitiet = new Ecm.Ware.DataSets.dsBaogia_Chitiet();
            Reports.rptBaogia_Khachhang rptBaogia_Khachhang = new Ecm.Ware.Reports.rptBaogia_Khachhang();
             GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptBaogia_Khachhang;
            rptBaogia_Khachhang.DataSource = dsBaogia_Chitiet;
            int i = 1;
            foreach (DataRow dr in ds_Donmuahang_Kh_Chitiet.Tables[0].Rows)
            {
                DataRow drn = dsBaogia_Chitiet.Tables[0].NewRow();
                foreach (DataColumn dc in ds_Donmuahang_Kh_Chitiet.Tables[0].Columns)
                {
                    try
                    {
                        if (dc.ColumnName == "Dongia" || dc.ColumnName == "Dongia_Bansi")
                        {
                            if (chkDongia_Bansi.Checked)
                                drn["Dongia"] = dr["Dongia_Bansi"];
                            else
                                drn["Dongia"] = dr["Dongia"];
                        }
                        else
                            drn[dc.ColumnName] = dr[dc.ColumnName];
                    }
                    catch
                    {
                        continue;
                    }
                }
                drn["Ten_Hanghoa"] = ("" + this.lookUpEdit_Cuahang_Ban.GetColumnValue("Id_Cuahang_Ban") != "")
                    ? dr["Ten_Hanghoa_Ban"] : dr["Ten_Hanghoa_Mua"];
                drn["stt"] = i++;
                dsBaogia_Chitiet.Tables[0].Rows.Add(drn);
            }
            rptBaogia_Khachhang.txtTen_Khachhang.Text = lookUpEdit_Khachhang.GetColumnValue("Ten_Khachhang").ToString();
            rptBaogia_Khachhang.txtDiachi.Text = txtDiachi.Text;
            rptBaogia_Khachhang.txtDienthoai.Text = txtDienthoai.Text;
            rptBaogia_Khachhang.txtSophieu.Text = txtMa_Donmuahang_Kh.Text;
            rptBaogia_Khachhang.txtNgay_Baogia.Text = dtNgay_Muahang.EditValue.ToString();
            rptBaogia_Khachhang.txtNguoiLapPhieu.Text = lookUpEdit_Nhansu_Lap.GetColumnValue("Ho_Nhansu").ToString() + " " + lookUpEdit_Nhansu_Lap.GetColumnValue("Ten_Nhansu").ToString();

            rptBaogia_Khachhang.lblNgay.Text = objWareService.GetServerDateTime().Day.ToString();
            rptBaogia_Khachhang.lblThang.Text = objWareService.GetServerDateTime().Month.ToString();
            rptBaogia_Khachhang.lblNam.Text = objWareService.GetServerDateTime().Year.ToString();
            rptBaogia_Khachhang.xr_GhiChu.Text = txtGhichu.Text;

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
                    ,imageData
                });

                rptBaogia_Khachhang.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptBaogia_Khachhang.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptBaogia_Khachhang.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }

            #endregion

            rptBaogia_Khachhang.CreateDocument();
             GoobizFrame.Windows.Forms.ReportOptions oReportOptions =  GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptBaogia_Khachhang);
             if (Convert.ToBoolean(oReportOptions.PrintPreview))
             {
                 frmPrintPreview.Text = "" + oReportOptions.Caption;
                 frmPrintPreview.printControl1.PrintingSystem = rptBaogia_Khachhang.PrintingSystem;
                 frmPrintPreview.MdiParent = this.MdiParent;
                 frmPrintPreview.Text = this.Text + "(Xem trang in)";
                 frmPrintPreview.Show();
                 frmPrintPreview.Activate();
             }
             else
             {
                 var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptBaogia_Khachhang);
                 reportPrintTool.Print();
             }
            return base.PerformPrintPreview();
        }
        #endregion

        #region Even

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            this.DisplayInfo2();
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            this.txtDiachi.EditValue = lookUpEdit_Khachhang.GetColumnValue("Diachi_Khachhang");
            this.txtDienthoai.EditValue = lookUpEdit_Khachhang.GetColumnValue("Dienthoai");
        }

        private void chkShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.OptionsView.ShowPreview = chkShowPreview.Checked;
        }

        private void Frmware_Donmuahang_Kh_Hhban_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
                gridView4.Columns["Chon"].Visible = false;
            else
                this.AllowSelect = true;
        }

        private void gridView4_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia")
            {
                if ("" + gridView4.GetFocusedRowCellValue("Soluong") != ""
                && ("" + gridView4.GetFocusedRowCellValue("Dongia") != ""))
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Thanhtien"],
                          Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Soluong")) * Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Dongia")));
            }
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia_Bansi")
            {
                if ("" + gridView4.GetFocusedRowCellValue("Soluong") != ""
                && ("" + gridView4.GetFocusedRowCellValue("Dongia_Bansi") != ""))
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Thanhtien"],
                        Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Soluong")) * Convert.ToDecimal(gridView4.GetFocusedRowCellValue("Dongia_Bansi")));
            }
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                if (gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban") == null)
                    return;
                DataRow[] dtr = ds_Hanghoa_Ban.Tables[0].Select("Id_Hanghoa_Ban = " + gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban"));
                if (dtr == null || dtr.Length == 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa chưa được định giá");
                    gridView4.CancelUpdateCurrentRow();
                    return;
                }
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Ten_Hanghoa_Ban"], dtr[0]["Ten_Hanghoa_Ban"]);
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Ten_Donvitinh"], dtr[0]["Ten_Donvitinh"]);
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Id_Donvitinh"], dtr[0]["Id_Donvitinh"]);
            }
            if (e.Column.FieldName == "Id_Donvitinh")
            {
                if (gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban") == null || gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban").ToString() == "")
                    return;
                DataRow[] dtr = ds_Hanghoa_Dinhgia.Tables[0].Select("Id_Hanghoa_Ban = " + gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban")
                                    + "and Id_Donvitinh = " + gridView4.GetFocusedRowCellValue("Id_Donvitinh"));
                if (chkDongia_Bansi.Checked == false)
                {
                    if (dtr.Length == 0 || dtr[0]["Dongia_Ban"].ToString() == "")
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa chưa có đơn giá bán");
                        gridView4.CancelUpdateCurrentRow();
                        return;
                    }
                    else
                        gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia"], dtr[0]["Dongia_Ban"]);
                }
                else
                    if (dtr[0]["Dongia_Bansi"].ToString() == "")
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa chưa có đơn giá bán sĩ");
                        gridView4.CancelUpdateCurrentRow();
                        return;
                    }
                    else
                        gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia_Bansi"], dtr[0]["Dongia_Bansi"]);
            }
        }

        private void chkDongia_Bansi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDongia_Bansi.Checked == false)
            {
                gridView4.Columns["Dongia"].Visible = true;
                gridView4.Columns["Dongia_Bansi"].Visible = false;
            }
            else
            {
                gridView4.Columns["Dongia_Bansi"].Visible = true;
                gridView4.Columns["Dongia"].Visible = false;
            }
            if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.View || gridView4.RowCount == 0)
                return;

            if (gridView4.GetFocusedRowCellValue("Id_Hanghoa_Ban").ToString() == "")
                return;
            if (!chkDongia_Bansi.Checked)
            {
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    DataRow[] dtr = ds_Hanghoa_Dinhgia.Tables[0].Select("Id_Hanghoa_Ban = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Hanghoa_Ban"])
                                                      + "and Id_Donvitinh = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Donvitinh"]));
                    if (dtr.Length == 0)
                        gridView4.SetRowCellValue(i, gridView4.Columns["Dongia"], null);

                    else
                        gridView4.SetRowCellValue(i, gridView4.Columns["Dongia"], "0" + dtr[0]["Dongia_Ban"]);
                    gridView4.SetRowCellValue(i, gridView4.Columns["Dongia_Bansi"], null);
                    if (gridView4.GetRowCellValue(i, gridView4.Columns["Dongia"]).ToString() != ""
                              && gridView4.GetRowCellValue(i, gridView4.Columns["Soluong"]).ToString() != "")
                    {
                        double thanhtien = Convert.ToDouble(gridView4.GetRowCellValue(i, gridView4.Columns["Soluong"]))
                                                        * Convert.ToDouble(gridView4.GetRowCellValue(i, gridView4.Columns["Dongia"]));
                        gridView4.SetRowCellValue(i, gridView4.Columns["Thanhtien"], thanhtien);
                    }
                    else
                        gridView4.SetRowCellValue(i, gridView4.Columns["Thanhtien"], null);
                }
            }
            else
            {
                System.Collections.ArrayList List_ItemToDelete = new System.Collections.ArrayList();
                bool check = false;
                DataRow[] dtr = null;
                for (int i = 0; i < ds_Donmuahang_Kh_Chitiet.Tables[0].Rows.Count; )
                {
                    if (gridView4.GetDataRow(i) != null && gridView4.GetDataRow(i).RowState != DataRowState.Deleted)
                    {
                        dtr = ds_Hanghoa_Dinhgia.Tables[0].Select("Id_Hanghoa_Ban = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Hanghoa_Ban"])
                            + "and Id_Donvitinh = " + gridView4.GetRowCellValue(i, gridView4.Columns["Id_Donvitinh"]));
                        if (dtr.Length > 0)
                        {
                            gridView4.SetRowCellValue(i, gridView4.Columns["Dongia_Bansi"], dtr[0]["Dongia_Bansi"]);
                            gridView4.SetRowCellValue(i, gridView4.Columns["Dongia_Ban"], null);

                            if (Convert.ToDecimal("0" + gridView4.GetRowCellValue(i, gridView4.Columns["Dongia_Bansi"])) == 0)
                            {
                                List_ItemToDelete.Add(i);
                                gridView4.SetRowCellValue(i, gridView4.Columns["Dongia_Ban"], null);
                                gridView4.SetRowCellValue(i, gridView4.Columns["Thanhtien"], null);
                                check = true;
                            }
                        }
                    }
                    i++;
                }
                if (check)
                {
                    if ( GoobizFrame.Windows.Forms.MessageDialog.Show(" Hàng hóa chưa có đơn giá bán sỉ, xóa khỏi danh sách ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int x = 0; x < List_ItemToDelete.Count; x++)
                        {
                            object position = List_ItemToDelete[x];
                            for (int j = 0; j < ds_Donmuahang_Kh_Chitiet.Tables[0].Rows.Count; j++)
                            {
                                if (j.Equals(position))
                                    ds_Donmuahang_Kh_Chitiet.Tables[0].Rows[j].Delete();
                            }
                        }
                    }
                    else
                        dgware_Donmuahang_Kh_Chitiet.DataSource = ds_Donmuahang_Kh_Chitiet.Tables[0];
                }
            }
            this.DoClickEndEdit(dgware_Donmuahang_Kh_Chitiet); //dgware_Donmuahang_Kh_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }

        private void lookUpEdit_Cuahang_Ban_EditValueChanged_1(object sender, EventArgs e)
        {
            object Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
            if (Id_Cuahang_Ban != null && this.FormState !=  GoobizFrame.Windows.Forms.FormState.View)
            {
                gridLookUpEdit_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(Id_Cuahang_Ban, dtNgay_Muahang.EditValue).ToDataSet().Tables[0];
                gridLookUpEditMa_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(Id_Cuahang_Ban, dtNgay_Muahang.EditValue).ToDataSet().Tables[0];
            }
        }

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
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
                    var DsDm_Hanghoa_Ban = dialog.GetType().GetProperty("DsDm_Hanghoa_Ban").GetValue(dialog, null) as DataSet;

                    if (SelectedObject != null)
                    {
                        gridLookUpEdit_Hanghoa_Ban.DataSource = DsDm_Hanghoa_Ban.Tables[0];
                        gridView4.SetFocusedRowCellValue(gridView4.Columns["Id_Hanghoa_Ban"], SelectedObject.Id_Hanghoa_Ban);
                        gridView4.SetFocusedRowCellValue(gridView4.Columns["Id_Donvitinh"], SelectedObject.Id_Donvitinh);
                    }
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }

            }
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add frm_Donvitinh = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add();
                if (gridView4.GetFocusedRowCellValue(gridView4.Columns["Id_Hanghoa_Ban"]).ToString() == "")
                    return;
                frm_Donvitinh.setId_Hanghoa_Ban(gridView4.GetFocusedRowCellValue(gridView4.Columns["Id_Hanghoa_Ban"]));
                frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frm_Donvitinh.ShowDialog();
                if (frm_Donvitinh.SelecteWare_Dm_Donvitinh != null)
                {
                    gridView4.SetFocusedRowCellValue(gridView4.Columns["Id_Donvitinh"], frm_Donvitinh.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                }
                gridView4.BestFitColumns();
            }
        }
        #endregion

        private void repositoryItemTextEdit8_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (e.NewValue.ToString().Length > 10)
                    e.Cancel = true;
                else if (Convert.ToInt32(e.NewValue) <= 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng phải lớn hơn 0, vui lòng nhập lại.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                //Nếu số lượng vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Soluong"], null);
                e.Cancel = true;
            }
        }

        private void repositoryItemTextEdit9_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToDecimal(e.NewValue) <= 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Đơn giá phải lớn hơn 0, vui lòng nhập lại.");
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToDecimal(e.NewValue) >= Decimal.MaxValue)
                {
                    //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị đơn giá không hợp lệ, vui lòng nhập lại.");
                    gridView4.SetFocusedRowCellValue(gridView4.FocusedColumn, null);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị đơn giá không hợp lệ, vui lòng nhập lại.");
                gridView4.SetFocusedRowCellValue(gridView4.Columns["Dongia"], null);
                e.Cancel = true;
            }
        }

        void Reload_Chungtu(object Ngay_Chungtu)
        {
            ds_Donmuahang_Kh = objWareService.Get_All_Ware_Donmuahang_Kh(Ngay_Chungtu).ToDataSet();
            dgware_Donmuahang_Kh.DataSource = ds_Donmuahang_Kh;
            dgware_Donmuahang_Kh.DataMember = ds_Donmuahang_Kh.Tables[0].TableName;
            this.DataBindingControl();
            this.ChangeStatus(false);
            this.DisplayInfo2();
        }

        private void dtThang_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (dtThang_Nam.Text != "")
                Reload_Chungtu(dtThang_Nam.DateTime);
            else
                Reload_Chungtu(null);
        }

    }
}

