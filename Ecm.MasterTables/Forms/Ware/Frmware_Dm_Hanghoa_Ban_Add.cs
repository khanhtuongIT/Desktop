using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TruthPos.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Hanghoa_Ban_Add :  itvs.Windows.Forms.FormUpdateWithToolbar
    {
        public TruthPos.WebReferences.Classes.MasterService objMasterService = new TruthPos.WebReferences.Classes.MasterService();
        DataSet ds_Collection = new DataSet();
        DataSet ds_All_Hanghoa_Ban = new DataSet();
        DataSet dsDm_Loai_Hanghoa_Ban = new DataSet();
        DataSet dsWare_Dm_Nhom_Hanghoa_Ban;
        DataSet dsDm_Donvitinh;
        DataSet dsNhasanxuat; // --> Nhà sản xuất sẽ lấy từ ware_dm_khachhang
        public TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban SelectedWare_Dm_Hanghoa_Ban;
        Frmware_Dm_Loai_Hanghoa_Ban_Add frmware_Dm_Loai_Hanghoa_Ban_Add = new Frmware_Dm_Loai_Hanghoa_Ban_Add();
        Frmware_Dm_Donvitinh_Add frmware_Dm_Donvitinh_Add;
        object Ten_Hanghoa_Ban = null;

        private object id_cuahang_ban;
        public object Id_Cuahang_Ban
        {
            set
            {
                id_cuahang_ban = value;
                if (id_cuahang_ban != null)
                    DisplayInfo();
            }
        }

        #region local data
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_NHOM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Nhom_Hanghoa_Ban.xml";
        string xml_WARE_DM_LOAI_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Loai_Hanghoa_Ban.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";        
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_WARE_DM_KHACHHANG = @"Resources\localdata\Ware_Dm_Khachhang.xml";

        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_ware_dm_nhom_hanghoa_ban;
        DateTime dtlc_ware_dm_loai_hanghoa_ban;        
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_dm_khachhang;
        #endregion

        public Frmware_Dm_Hanghoa_Ban_Add()
        {
            InitializeComponent();

            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            frmware_Dm_Donvitinh_Add = new Frmware_Dm_Donvitinh_Add();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;  
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
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(
                    "[Ware_Dm_Nhom_Hanghoa_Ban], [Ware_Dm_Loai_Hanghoa_Ban], " +
                    "[Ware_Dm_Donvitinh], [Ware_Dm_Khachhang], [ware_dm_hanghoa_ban]");

            //date time last change
            dtlc_ware_dm_nhom_hanghoa_ban = GetLastChange_FrmLognotify("Ware_Dm_Nhom_Hanghoa_Ban");
            dtlc_ware_dm_loai_hanghoa_ban = GetLastChange_FrmLognotify("Ware_Dm_Loai_Hanghoa_Ban");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("Ware_Dm_Donvitinh");
            dtlc_ware_dm_khachhang = GetLastChange_FrmLognotify("Ware_Dm_Khachhang");
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("ware_dm_hanghoa_ban");
            //load data from local xml when last change at local differ from database
            if (!System.IO.File.Exists(xml_WARE_DM_NHOM_HANGHOA_BAN)
                || DateTime.Compare(dtlc_ware_dm_nhom_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_NHOM_HANGHOA_BAN)) > 0)
            {
                dsWare_Dm_Nhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban();
                dsWare_Dm_Nhom_Hanghoa_Ban.WriteXml(xml_WARE_DM_NHOM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (dsWare_Dm_Nhom_Hanghoa_Ban == null || dsWare_Dm_Nhom_Hanghoa_Ban.Tables.Count == 0)
            {
                dsWare_Dm_Nhom_Hanghoa_Ban = new DataSet();
                dsWare_Dm_Nhom_Hanghoa_Ban.ReadXml(xml_WARE_DM_NHOM_HANGHOA_BAN);
            }
            //xml_WARE_DM_LOAI_HANGHOA_BAN
            if (!System.IO.File.Exists(xml_WARE_DM_LOAI_HANGHOA_BAN)
                || DateTime.Compare(dtlc_ware_dm_loai_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_LOAI_HANGHOA_BAN)) > 0)
            {
                dsDm_Loai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban();
                dsDm_Loai_Hanghoa_Ban.WriteXml(xml_WARE_DM_LOAI_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (dsDm_Loai_Hanghoa_Ban == null || dsDm_Loai_Hanghoa_Ban.Tables.Count == 0)
            {
                dsDm_Loai_Hanghoa_Ban = new DataSet();
                dsDm_Loai_Hanghoa_Ban.ReadXml(xml_WARE_DM_LOAI_HANGHOA_BAN);
            }
            //xml_WARE_DM_DONVITINH
            if (!System.IO.File.Exists(xml_WARE_DM_DONVITINH)
                || DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0)
            {
                dsDm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh();
                dsDm_Donvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            }
            else if (dsDm_Donvitinh == null || dsDm_Donvitinh.Tables.Count == 0)
            {
                dsDm_Donvitinh = new DataSet();
                dsDm_Donvitinh.ReadXml(xml_WARE_DM_DONVITINH);
            }
            if (!System.IO.File.Exists(xml_WARE_DM_KHACHHANG)
                || DateTime.Compare(dtlc_ware_dm_khachhang, System.IO.File.GetLastWriteTime(xml_WARE_DM_KHACHHANG)) > 0)
            {
                dsNhasanxuat = objMasterService.Get_All_Ware_Dm_Khachhang(); // --> Nhà sản xuất sẽ lấy từ ware_dm_khachhang
                dsNhasanxuat.WriteXml(xml_WARE_DM_KHACHHANG, XmlWriteMode.WriteSchema);
            }
            else if (dsNhasanxuat == null || dsNhasanxuat.Tables.Count == 0)
            {
                dsNhasanxuat = new DataSet();
                dsNhasanxuat.ReadXml(xml_WARE_DM_KHACHHANG);
            }
            if (!System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN)
              || DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0)
            {
                ds_All_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban();
                ds_All_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else
            {
                ds_All_Hanghoa_Ban = new DataSet();
                ds_All_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }
        }

        public override void DisplayInfo()
        {
            try
            {                
                LoadMasterData();
                DisplayInfo2();
                //gridLookUpEdit_Nhom_Hanghoa_Ban
                gridLookUp_Nhom_Hanghoa_Ban.DataSource = dsWare_Dm_Nhom_Hanghoa_Ban.Tables[0];
                //Get data Ware_Dm_Loai_Hanghoa_Ban                
                lookUp_Loai_Hanghoa_Ban.Properties.DataSource = dsDm_Loai_Hanghoa_Ban.Tables[0];
                gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = dsDm_Loai_Hanghoa_Ban.Tables[0];
                gridLookUpEdit_Ma_Loai_Hanghoa.DataSource = dsDm_Loai_Hanghoa_Ban.Tables[0];
                gridLookUp_Ten_Loai_Hanghoa.DataSource = dsDm_Loai_Hanghoa_Ban.Tables[0];
                this.dgware_Dm_Loai_Hanghoa_Ban.DataSource = dsDm_Loai_Hanghoa_Ban.Tables[0];
                //lookUpEdit_Donvitinh                
                lookUp_Donvitinh.Properties.DataSource = dsDm_Donvitinh.Tables[0];
                gridLookUp_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];
                //gridLookUpEdit_Nhasanxuat
                lookUp_Nhasanxuat.Properties.DataSource = dsNhasanxuat.Tables[0];
                gridLookUp_Nhasanxuat.DataSource = dsNhasanxuat.Tables[0];
                //Get data Ware_Dm_Hanghoa_Ban                    
                //if (gridView2.RowCount > 0)
                //{
                //    gridView2.FocusedRowHandle = 0;
                //    DisplayInfo2();
                //}
                //this.DataBindingControl();              
                //btnGen_Barcode.Enabled = false;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// itvs.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public void DisplayInfo2()
        {
            ds_Collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hh_Ban_None_Dinhgia(gridView2.GetFocusedRowCellValue(gridColumn14), null, null, null);
            setDatasourceForGridview1();
            this.ChangeStatus(false);
            txtMavach.EditValue = null;
            txtMa_Hanghoa.EditValue = null;
            txtTen_Hanghoa.EditValue = null;
        }

        public override void ClearDataBindings()
        {
            this.txtId_Hanghoa_Ban.DataBindings.Clear();
            this.txtMa_Hanghoa_Ban.DataBindings.Clear();
            this.txtTen_Hanghoa_Ban.DataBindings.Clear();
            this.txtSize.DataBindings.Clear();
            this.txtQuycach.DataBindings.Clear();
            this.txtSoluong_Min.DataBindings.Clear();
            this.txtDongia_Mua.DataBindings.Clear();
            this.txtBarcode_Txt.DataBindings.Clear();
            this.lookUp_Loai_Hanghoa_Ban.DataBindings.Clear();
            this.lookUp_Donvitinh.DataBindings.Clear();
            this.txtXuatxu.DataBindings.Clear();
            this.txtHamluong.DataBindings.Clear();
            this.lookUp_Nhasanxuat.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hanghoa_Ban");
                this.txtMa_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Hanghoa_Ban");
                this.txtTen_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Hanghoa_Ban");
                this.txtSize.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Size");
                this.txtBarcode_Txt.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Barcode_Txt");
                this.txtDongia_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Dongia_Mua");
                this.txtQuycach.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Quycach");
                this.txtHamluong.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Hamluong");
                this.txtXuatxu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Xuatxu");
                this.lookUp_Nhasanxuat.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Khachhang");
                this.txtSoluong_Min.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Soluong_Min");
                this.lookUp_Loai_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Loai_Hanghoa_Ban");
                this.lookUp_Donvitinh.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Donvitinh");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// itvs.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgware_Dm_Hanghoa_Ban.Enabled          = !editTable;
            this.gridView1.OptionsBehavior.Editable = editTable;
            this.dgware_Dm_Loai_Hanghoa_Ban.Enabled = !editTable;
            this.btnThemhinh.Enabled = editTable;
            this.btnXoahinh.Enabled = editTable;
        }

        public override void ResetText()
        {
            this.txtId_Hanghoa_Ban.EditValue = "";
            this.txtMa_Hanghoa_Ban.EditValue = "";
            this.txtTen_Hanghoa_Ban.EditValue = "";
            this.txtSize.EditValue = "";
            this.txtQuycach.EditValue = "";
            this.txtBarcode_Txt.EditValue = "";
            this.txtSoluong_Min.EditValue = null;
            this.txtDongia_Mua.EditValue = null;
            this.lookUp_Donvitinh.EditValue = null;
            this.pictureEdit_Hinh.Image = null;
            this.txtXuatxu.EditValue = null;
            this.txtHamluong.EditValue = null;
            lookUp_Nhasanxuat.EditValue = null;
        }

        #region Event Override
        public object InsertObject()
        {
            TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban objWare_Dm_Hanghoa_Ban = new TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban();
            objWare_Dm_Hanghoa_Ban.Id_Hanghoa_Ban = -1;
            objWare_Dm_Hanghoa_Ban.Ma_Hanghoa_Ban = txtMa_Hanghoa_Ban.EditValue;
            objWare_Dm_Hanghoa_Ban.Ten_Hanghoa_Ban = txtTen_Hanghoa_Ban.EditValue;
            objWare_Dm_Hanghoa_Ban.Size = "" + txtSize.EditValue;
            objWare_Dm_Hanghoa_Ban.Quycach = "" + txtQuycach.EditValue;
            objWare_Dm_Hanghoa_Ban.Barcode_Txt = txtBarcode_Txt.EditValue;
            objWare_Dm_Hanghoa_Ban.Dongia_Mua = (txtDongia_Mua.Text == "") ? null : txtDongia_Mua.EditValue;
            objWare_Dm_Hanghoa_Ban.Hamluong = (txtHamluong.Text == "") ? null : txtHamluong.EditValue;
            objWare_Dm_Hanghoa_Ban.Xuatxu = (txtXuatxu.Text == "") ? null : txtXuatxu.EditValue;

            if ("" + lookUp_Nhasanxuat.EditValue != "")
                objWare_Dm_Hanghoa_Ban.Id_Khachhang = lookUp_Nhasanxuat.EditValue;
            if ("" + txtSoluong_Min.EditValue != "")
                objWare_Dm_Hanghoa_Ban.Soluong_Min = txtSoluong_Min.EditValue;
            if ("" + lookUp_Loai_Hanghoa_Ban.EditValue != "")
                objWare_Dm_Hanghoa_Ban.Id_Loai_Hanghoa_Ban = lookUp_Loai_Hanghoa_Ban.EditValue;
            if ("" + lookUp_Donvitinh.EditValue != "")
                objWare_Dm_Hanghoa_Ban.Id_Donvitinh = lookUp_Donvitinh.EditValue;

            if (pictureEdit_Hinh.Image != null)
            {
                //get image source and resize it
                Image srcImage = Image.FromFile(pictureEdit_Hinh.ImageLocation);
                int percentSize = (srcImage.Width > 100) ? 100 * 100 / srcImage.Width : 100;
                Image hinh =  itvs.Windows.ImageUtils.ImageResize.ScaleByPercent(srcImage, percentSize);
                //save image to memory
                MemoryStream ms = new MemoryStream();
                hinh.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageData = ms.GetBuffer();
                //asign image in buffer to property Hinh
                objWare_Dm_Hanghoa_Ban.Hinh = imageData;
            }
            return objMasterService.Insert_Ware_Dm_Hanghoa_Ban(objWare_Dm_Hanghoa_Ban);
        }

        public object UpdateObject()
        {
            TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban objWare_Dm_Hanghoa_Ban = new TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban();
            objWare_Dm_Hanghoa_Ban.Id_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban");
            objWare_Dm_Hanghoa_Ban.Ma_Hanghoa_Ban = txtMa_Hanghoa_Ban.EditValue;
            objWare_Dm_Hanghoa_Ban.Ten_Hanghoa_Ban = txtTen_Hanghoa_Ban.EditValue;
            objWare_Dm_Hanghoa_Ban.Size = "" + txtSize.EditValue;
            objWare_Dm_Hanghoa_Ban.Quycach = "" + txtQuycach.EditValue;
            objWare_Dm_Hanghoa_Ban.Barcode_Txt = txtBarcode_Txt.EditValue;
            objWare_Dm_Hanghoa_Ban.Dongia_Mua = (txtDongia_Mua.Text == "") ? null : txtDongia_Mua.EditValue;
            objWare_Dm_Hanghoa_Ban.Hamluong = (txtHamluong.Text == "") ? null : txtHamluong.EditValue;
            objWare_Dm_Hanghoa_Ban.Xuatxu = (txtXuatxu.Text == "") ? null : txtXuatxu.EditValue;

            if ("" + lookUp_Nhasanxuat.EditValue != "")
                objWare_Dm_Hanghoa_Ban.Id_Khachhang = lookUp_Nhasanxuat.EditValue;
            if ("" + txtSoluong_Min.EditValue != "")
                objWare_Dm_Hanghoa_Ban.Soluong_Min = txtSoluong_Min.EditValue;
            if ("" + lookUp_Loai_Hanghoa_Ban.EditValue != "")
                objWare_Dm_Hanghoa_Ban.Id_Loai_Hanghoa_Ban = lookUp_Loai_Hanghoa_Ban.EditValue;
            if ("" + lookUp_Donvitinh.EditValue != "")
                objWare_Dm_Hanghoa_Ban.Id_Donvitinh = lookUp_Donvitinh.EditValue;

            if (pictureEdit_Hinh.Image != null && pictureEdit_Hinh.ImageLocation != null)
            {
                //get image source and resize it
                Image srcImage = Image.FromFile(pictureEdit_Hinh.ImageLocation);
                int percentSize = (srcImage.Width > 100) ? 100 * 100 / srcImage.Width : 100;
                Image hinh =  itvs.Windows.ImageUtils.ImageResize.ScaleByPercent(srcImage, percentSize);
                //save image to memory
                MemoryStream ms = new MemoryStream();
                hinh.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageData = ms.GetBuffer();
                //asign image in buffer to property Hinh
                objWare_Dm_Hanghoa_Ban.Hinh = imageData;
            }
            return objMasterService.Update_Ware_Dm_Hanghoa_Ban(objWare_Dm_Hanghoa_Ban);
        }

        public object DeleteObject()
        {
            TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban objWare_Dm_Hanghoa_Ban = new TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban();
            objWare_Dm_Hanghoa_Ban.Id_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban");
            return objMasterService.Delete_Ware_Dm_Hanghoa_Ban(objWare_Dm_Hanghoa_Ban);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            if (gridView2.GetFocusedRowCellValue(gridColumn14) != null)
                {
                    this.ChangeStatus(true);
                    this.ClearDataBindings();
                    return true;
                }
            return false;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo2();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                ////dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                //this.DoClickEndEdit(dgware_Dm_Hanghoa_Ban);
                //bool success = false;
                // itvs.Windows.Public.OrderHashtable hashtableControls = new  itvs.Windows.Public.OrderHashtable();
                //hashtableControls.Add(txtMa_Hanghoa_Ban, lblMa_Hanghoa_Ban.Text);
                //hashtableControls.Add(txtTen_Hanghoa_Ban, lblTen_Hanghoa_Ban.Text);
                //hashtableControls.Add(lookUp_Donvitinh, lblDonvitinh.Text);
                ////System.Collections.Hashtable htbBarCode = new System.Collections.Hashtable();
                ////htbBarCode.Add(txtBarcode_Txt, lblBarcode_Txt.Text);

                //if (! itvs.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                //    return false;

                //System.Collections.Hashtable htb_MaHanghoa = new System.Collections.Hashtable();
                //htb_MaHanghoa.Add(txtMa_Hanghoa_Ban, lblMa_Hanghoa_Ban.Text);

                //if (FormState ==  itvs.Windows.Forms.FormState.Add)
                //    if (! itvs.Windows.MdiUtils.Validator.CheckExistValues(htb_MaHanghoa, ds_All_Hanghoa_Ban, "Ma_Hanghoa_Ban"))
                //        return false;

                //hashtableControls.Remove(txtMa_Hanghoa_Ban);
                //if (this.FormState ==  itvs.Windows.Forms.FormState.Add)
                //{
                //    if (! itvs.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ten_Hanghoa_Ban"))
                //        return false;
                //    //if (! itvs.Windows.MdiUtils.Validator.CheckExistValues(htbBarCode, ds_Collection, "Barcode_Txt"))
                //    //    return false;
                //    success = (bool)this.InsertObject();
                //}
                //else if (this.FormState ==  itvs.Windows.Forms.FormState.Edit)
                //{
                //    //if (!txtTen_Hanghoa_Ban.EditValue.Equals(Ten_Hanghoa_Ban))
                //    //{
                //    //    if (! itvs.Windows.MdiUtils.Validator.CheckExistValues(hashtableControls, ds_Collection, "Ten_Hanghoa_Ban"))
                //    //        return false;
                //    //}
                //    //DataSet _ds =  itvs.Windows.MdiUtils.Validator.datasetFillter(ds_Collection, "Id_Hanghoa_Ban = " + gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban"));
                //    //if (! itvs.Windows.MdiUtils.Validator.CheckExistValues(htbBarCode, _ds, "Barcode_Txt"))
                //    //    return false;
                    //success = (bool)this.UpdateObject();

                //}
                //if (success)
                //{
                    Ten_Hanghoa_Ban = null;
                    this.DisplayInfo2();
                //}
                return true;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                   //  itvs.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Hanghoa_Ban.Text, lblMa_Hanghoa_Ban.Text.ToLower() });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_hanghoa_ban]");
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("ware_dm_hanghoa_ban");

            if (!System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN)
              || DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0)
            {
                ds_All_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban();
                ds_All_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else
            {
                ds_All_Hanghoa_Ban = new DataSet();
                ds_All_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }

            this.DoClickEndEdit(dgware_Dm_Hanghoa_Ban);
             itvs.Windows.Public.OrderHashtable hashtableControls = new  itvs.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Id_Donvitinh"], "");
            hashtableControls.Add(gridView1.Columns["Barcode_Txt"], "");            

            if (! itvs.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            int focus = gridView1.FocusedRowHandle;
            if (FormState ==  itvs.Windows.Forms.FormState.Add)
            {
                System.Collections.Hashtable htbBarCode = new System.Collections.Hashtable();
                htbBarCode.Add(gridView1.Columns["Barcode_Txt"], "");
                if (! itvs.Windows.MdiUtils.Validator.CheckExistGrid(htbBarCode, gridView1))
                    return false;
            }
            hashtableControls.Remove(gridView1.Columns["Id_Donvitinh"]);
            hashtableControls.Remove(gridView1.Columns["Ten_Hanghoa_Ban"]);

            if (! itvs.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gridView1))
            {
                gridView1.FocusedRowHandle = focus;
                return false;
            }
            DataRow[] dtr = null;
            DataRow[] dtr_Id = null;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetDataRow(i).RowState == DataRowState.Modified)
                {
                    dtr_Id = ds_All_Hanghoa_Ban.Tables[0].Select("Id_Hanghoa_Ban = '" + gridView1.GetRowCellValue(i, gridView1.Columns["Id_Hanghoa_Ban"]) + "'");
                    if (!dtr_Id[0]["Ma_Hanghoa_Ban"].Equals(gridView1.GetRowCellValue(i, gridView1.Columns["Ma_Hanghoa_Ban"])))
                    {
                        dtr = ds_All_Hanghoa_Ban.Tables[0].Select("Ma_Hanghoa_Ban = '" + gridView1.GetRowCellValue(i, gridView1.Columns["Ma_Hanghoa_Ban"]) + "'");
                        if (dtr.Length >= 1)
                        {
                             itvs.Windows.Forms.MessageDialog.Show("Mã hàng " + gridView1.GetRowCellValue(i, gridView1.Columns["Ma_Hanghoa_Ban"]) + " đã tồn tại, nhập lại Mã hàng hóa");
                            return false;
                        }
                    }
                }
                if (gridView1.GetDataRow(i).RowState == DataRowState.Added)
                {
                    dtr = ds_All_Hanghoa_Ban.Tables[0].Select("Ma_Hanghoa_Ban = '" + gridView1.GetRowCellValue(i, gridView1.Columns["Ma_Hanghoa_Ban"]) + "'");
                    if (dtr.Length >= 1)
                    {
                         itvs.Windows.Forms.MessageDialog.Show("Mã hàng " + gridView1.GetRowCellValue(i, gridView1.Columns["Ma_Hanghoa_Ban"]) + " đã tồn tại, nhập lại Mã hàng hóa");
                        return false;
                    }
                }
            }
            try
            {
                //dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                //ds_Collection.Tables[0].Columns["Ma_Hanghoa_Ban"].Unique = true;
                //ds_Collection.Tables[0].Columns["Ten_Hanghoa_Ban"].Unique = true;
                objMasterService.Update_Ware_Dm_Hanghoa_Ban_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    if (ex.ToString().IndexOf("Ma_Hanghoa_Ban") != -1)
                         itvs.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Hanghoa_Ban.Text, lblMa_Hanghoa_Ban.Text.ToLower() });
                    //else if (ex.ToString().IndexOf("Ten_Hanghoa_Ban") != -1)
                    //     itvs.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Hanghoa_Ban.Text, lblTen_Hanghoa_Ban.Text.ToLower() });
                    return false;
                }
                //MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo2();
            return true;
        }

        public override bool PerformDelete()
        {
            if ( itvs.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             itvs.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Hanghoa_Ban"),
             itvs.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Hanghoa_Ban")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Hanghoa_Ban", "Id_Hanghoa_Ban", this.gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban"))) > 0)
                    {
                         itvs.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                     itvs.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    // itvs.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo2();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban ware_Dm_Hanghoa_Ban = new TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Hanghoa_Ban.Id_Hanghoa_Ban = dr["Id_Hanghoa_Ban"];
                    ware_Dm_Hanghoa_Ban.Ma_Hanghoa_Ban = dr["Ma_Hanghoa_Ban"];
                    ware_Dm_Hanghoa_Ban.Ten_Hanghoa_Ban = dr["Ten_Hanghoa_Ban"];
                    ware_Dm_Hanghoa_Ban.Size = dr["Size"];
                    ware_Dm_Hanghoa_Ban.Quycach = dr["Quycach"];
                    ware_Dm_Hanghoa_Ban.Id_Loai_Hanghoa_Ban = dr["Id_Loai_Hanghoa_Ban"];
                    ware_Dm_Hanghoa_Ban.Id_Donvitinh = dr["Id_Donvitinh"];
                    ware_Dm_Hanghoa_Ban.Soluong_Min = dr["Soluong_Min"];
                }
                SelectedWare_Dm_Hanghoa_Ban = ware_Dm_Hanghoa_Ban;
                this.Dispose();
                this.Close();
                return ware_Dm_Hanghoa_Ban;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }
        #endregion

        #region even

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Hanghoa_Ban"];
            this.addnewrow_clicked = true;
            //btnGen_Barcode.Enabled = true;
            gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Loai_Hanghoa_Ban"], gridView2.GetFocusedRowCellValue(gridColumn14));
            lookUp_Loai_Hanghoa_Ban.EditValue = gridView2.GetFocusedRowCellValue(gridColumn14);
            gridView1.OptionsBehavior.Editable = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Ma_Hanghoa_Ban" || e.Column.FieldName == "Id_Loai_Hanghoa_Ban")
                {
                    DataRowView drv = (DataRowView)gridLookUpEdit_Loai_Hanghoa_Ban.GetDataSourceRowByKeyValue(gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"));
                    gridView1.SetFocusedRowCellValue(
                        gridView1.Columns["Barcode_Txt"],
                        //    drv["Ma_Nhom_Hanghoa_Ban"]
                        //+ " "
                        //+ drv["Ma_Loai_Hanghoa_Ban"]
                        //+ " " +
                     gridView1.GetFocusedRowCellValue("Ma_Hanghoa_Ban"));
                }
                if (e.Column.FieldName == "Dongia_Mua")
                {
                    if (gridView1.GetFocusedRowCellValue("Dongia_Mua").ToString().Length > 9)
                    {
                         itvs.Windows.Forms.MessageDialog.Show("Số tiền nhập không đúng");
                        gridView1.SetFocusedRowCellValue(gridView1.Columns["Dongia_Mua"],
                                        gridView1.GetFocusedRowCellValue("Dongia_Mua").ToString().Substring(0, 9));
                    }
                }
                // this.dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                this.DoClickEndEdit(dgware_Dm_Hanghoa_Ban);
            }
            catch (Exception ex)
            {
            }
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Frmware_Dm_Donvitinh_Add objFrmware_Dm_Donvitinh_Add = new Frmware_Dm_Donvitinh_Add();
                 itvs.Windows.MdiUtils.ThemeSettings.SetDialogShow(objFrmware_Dm_Donvitinh_Add);
                objFrmware_Dm_Donvitinh_Add.ShowDialog();
                objFrmware_Dm_Donvitinh_Add.Text = lblDonvitinh.Text;
                if (objFrmware_Dm_Donvitinh_Add.SelecteWare_Dm_Donvitinh != null)
                {
                    //lookUpEdit_Donvitinh
                    DataSet dsDm_Donvitinh = objFrmware_Dm_Donvitinh_Add.Data;
                    lookUp_Donvitinh.Properties.DataSource = dsDm_Donvitinh.Tables[0];
                    gridLookUp_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"], objFrmware_Dm_Donvitinh_Add.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                }
            }
        }

        private void txtMa_Hanghoa_Ban_EditValueChanged(object sender, EventArgs e)
        {
            if (txtBarcode_Txt.Text == "" && this.FormState !=  itvs.Windows.Forms.FormState.View)
                try
                {
                    txtBarcode_Txt.EditValue = "" +
                       ((DataRowView)lookUp_Loai_Hanghoa_Ban.Properties.GetDataSourceRowByKeyValue(lookUp_Loai_Hanghoa_Ban.EditValue))["Ma_Nhom_Hanghoa_Ban"]
                       + " "
                       + ((DataRowView)lookUp_Loai_Hanghoa_Ban.Properties.GetDataSourceRowByKeyValue(lookUp_Loai_Hanghoa_Ban.EditValue))["Ma_Loai_Hanghoa_Ban"]
                       + " "
                       + txtMa_Hanghoa_Ban.EditValue;
                }
                catch { }
        }

        private void lookUpEdit_Loai_Hanghoa_Ban_EditValueChanged(object sender, EventArgs e)
        {
            txtMa_Hanghoa_Ban_EditValueChanged(sender, e);
        }

        private void btnGen_Barcode_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.FocusedRowHandle = i;
                if ("" + gridView1.GetFocusedRowCellValue("Barcode_Txt") == "")
                {
                    DataRowView drv = (DataRowView)gridLookUpEdit_Loai_Hanghoa_Ban.GetDataSourceRowByKeyValue(gridView1.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"));

                    gridView1.SetFocusedRowCellValue(
                        gridView1.Columns["Barcode_Txt"],
                        //    drv["Ma_Nhom_Hanghoa_Ban"]
                        //+ " "
                        //+ drv["Ma_Loai_Hanghoa_Ban"]
                        //+ " "+
                     gridView1.GetFocusedRowCellValue("Ma_Hanghoa_Ban"));
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Ten_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Ten_Hanghoa_Ban");
            //Get image data from gridview column.
            if ("" + gridView1.GetFocusedRowCellValue("Hinh") != "")
            {
                byte[] imagedata = (byte[])gridView1.GetFocusedRowCellValue("Hinh");
                //Read image data into a memory stream
                MemoryStream ms = new MemoryStream(imagedata, 0, imagedata.Length);
                ms.Write(imagedata, 0, imagedata.Length);
                //Set image variable value using memory stream.
                Image image = Image.FromStream(ms, true);
                pictureEdit_Hinh.Image = image;
            }
            else
                pictureEdit_Hinh.Image = null;
        }
        private void btnThemhinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.Cancel)
            {
                pictureEdit_Hinh.ImageLocation = openFileDialog.FileName;
                //lbl_pathImage.Text = openFileDialog.FileName;
            }
        }

        private void btnXoahinh_Click(object sender, EventArgs e)
        {
            pictureEdit_Hinh.Image = null;
        }

        private void btnLoai_Hanghoa_Ban_Click(object sender, EventArgs e)
        {
            if (frmware_Dm_Loai_Hanghoa_Ban_Add.IsDisposed || frmware_Dm_Loai_Hanghoa_Ban_Add == null)
                frmware_Dm_Loai_Hanghoa_Ban_Add = new Frmware_Dm_Loai_Hanghoa_Ban_Add();
             itvs.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Loai_Hanghoa_Ban_Add);
             itvs.Windows.PlugIn.RightHelpers.CheckUserRightAction(frmware_Dm_Loai_Hanghoa_Ban_Add);
            frmware_Dm_Loai_Hanghoa_Ban_Add.Text = "Thêm loại hàng hóa";
            frmware_Dm_Loai_Hanghoa_Ban_Add.Show();
        }

        private void btnDonvitinh_Click(object sender, EventArgs e)
        {
            if (frmware_Dm_Donvitinh_Add.IsDisposed || frmware_Dm_Donvitinh_Add == null)
                frmware_Dm_Donvitinh_Add = new Frmware_Dm_Donvitinh_Add();
             itvs.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Donvitinh_Add);
             itvs.Windows.PlugIn.RightHelpers.CheckUserRightAction(frmware_Dm_Donvitinh_Add);
            frmware_Dm_Donvitinh_Add.Text = "Thêm Đơn vị tính";
            frmware_Dm_Donvitinh_Add.Show();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //gridView1.Columns["Id_Loai_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
            //        gridView1.Columns["Id_Loai_Hanghoa_Ban"], gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"));
            this.DisplayInfo2();
        }

        private void txtMa_Hanghoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtMa_Hanghoa.EditValue != null && e.KeyCode == Keys.Enter)
            {
                gridView1.Columns["Id_Loai_Hanghoa_Ban"].ClearFilter();
                ds_Collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Ma_Hanghoa_Ban(txtMa_Hanghoa.EditValue);
                setDatasourceForGridview1();
            }
        }

        private void txtTen_Hanghoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTen_Hanghoa.EditValue != null && e.KeyCode == Keys.Enter)
            {
                gridView1.Columns["Id_Loai_Hanghoa_Ban"].ClearFilter();
                ds_Collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Ten_Hanghoa_Ban(txtTen_Hanghoa.EditValue);
                setDatasourceForGridview1();
            }
        }

        private void txtMavach_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtMavach.EditValue != null && e.KeyCode == Keys.Enter)
            {
                gridView1.Columns["Id_Loai_Hanghoa_Ban"].ClearFilter();
                ds_Collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Barcode_Txt(txtMavach.EditValue);
                setDatasourceForGridview1();
            }
        }

        void setDatasourceForGridview1()
        {
            dgware_Dm_Hanghoa_Ban.DataSource = ds_Collection;
            dgware_Dm_Hanghoa_Ban.DataMember = ds_Collection.Tables[0].TableName;
            this.Data = ds_Collection;
            this.GridControl = dgware_Dm_Hanghoa_Ban;
            this.DataBindingControl();
            this.gridView1.BestFitColumns();
        }

        private void txtDongia_Mua_EditValueChanged(object sender, EventArgs e)
        {
            if (FormState ==  itvs.Windows.Forms.FormState.Add)
            {
                if (txtDongia_Mua.Text == "")
                    return;
                if (Convert.ToInt32(txtDongia_Mua.EditValue).ToString().Length > 9)
                {
                     itvs.Windows.Forms.MessageDialog.Show("Số tiền nhập không đúng");
                    txtDongia_Mua.EditValue = Convert.ToInt32(txtDongia_Mua.EditValue).ToString().Substring(0, 9);
                }
            }
        }

        private void txtMa_Hanghoa_Ban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;

        }

        private void repositoryItemText_MaHH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

        private void gridText_Soluong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ("" + e.NewValue == "")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Soluong_Min"], null);
                e.Cancel = true;
            }

            if (e.NewValue.ToString().Length > 10)
                e.Cancel = true;


        }

        private void dgware_Dm_Hanghoa_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban") != "")
                {
                    try
                    {
                        TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban objWare_Dm_Hanghoa_Ban = new TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban();
                        objWare_Dm_Hanghoa_Ban.Id_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban");
                        objMasterService.Delete_Ware_Dm_Hanghoa_Ban(objWare_Dm_Hanghoa_Ban);
                    }
                    catch (Exception ex)
                    {
                         itvs.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }

                }
            }
        }

        private void xtraHNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban") != "")
                {
                    try
                    {
                        TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban objWare_Dm_Hanghoa_Ban = new TruthPos.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban();
                        objWare_Dm_Hanghoa_Ban.Id_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban");
                        objMasterService.Delete_Ware_Dm_Hanghoa_Ban(objWare_Dm_Hanghoa_Ban);
                    }
                    catch (Exception ex)
                    {
                         itvs.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }

                }
            }
        }


        private void gridText_Dongia_Mua_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString().Length > 9)
                e.Cancel = true;

            if ("" + e.NewValue == "")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Dongia_Mua"], null);
                e.Cancel = true;
            }

        }
        #endregion

      

    
    }
}

