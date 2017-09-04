using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using System.IO;

namespace Ecm.Bar.Forms
{
    public partial class Frmbar_Table_MngrEdit :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet dsTable_Order = new DataSet();
        DataSet dsTable_Order_Chitiet = new DataSet();
        DataSet dsTable_Order_Chitiet_Log = new DataSet();
        DataSet ds_Hanghoa_Ban;
        DataSet dsNhansu_Order;
        DataSet ds_Khachhang;
        DataSet ds_Donvitinh;
        object SelectedId_Table_Order;
        object SelectedId_Cuahang_Ban;
        int focusOfGirdView1;
        bool AllowEdit_Per_Dongia = false;
        int Id_Nhansu_Km = -1;

        #region local data

        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        string xml_WARE_DM_KHACHHANG = @"Resources\localdata\Ware_Dm_Khachhang.xml";
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_rex_nhansu;
        DateTime dtlc_ware_dm_khachhang;

        #endregion

        public Frmbar_Table_MngrEdit()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            this.dtNgay_Order.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Order.DateTime = objBarService.GetServerDateTime();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.BarSystem.Visible = false;
            this.AfterCheckUserRightAction += new EventHandler(Frmbar_Table_MngrEdit_AfterCheckUserRightAction);
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

        void Frmbar_Table_MngrEdit_AfterCheckUserRightAction(object sender, EventArgs e)
        {
            this.btnCash.Enabled = this.EnablePrintPreview;
            this.btnEdit.Enabled = this.EnableEdit;
        }

        /// <summary>
        /// Thay doi trang thai form
        /// </summary>
        /// <param name="editTable"></param>
        public override void ChangeStatus(bool editTable)
        {
            this.dgbar_Dm_Table.Enabled = !editTable;
            gridView2.OptionsBehavior.Editable = editTable;
            dtNgay_Order.Enabled = !editTable;
            txtPer_Dongia_All.Properties.ReadOnly = !editTable;
        }

        void LoadMasterData()
        {
            /*
              //load data from local xml when last change at local differ from database
             dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_hanghoa_ban], "
                   + "[ware_dm_donvitinh], [rex_nhansu], [ware_dm_khachhang]").ToDataSet();
             dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
             dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
             dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
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
                 dsNhansu_Order = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                 dsNhansu_Order.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
             }
             else if (dsNhansu_Order == null || dsNhansu_Order.Tables.Count == 0)
             {
                 dsNhansu_Order = new DataSet();
                 dsNhansu_Order.ReadXml(xml_REX_NHANSU);
             }
             if (DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0
                 || !System.IO.File.Exists(xml_WARE_DM_DONVITINH))
             {
                 ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                 ds_Donvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
             }
             else if (ds_Donvitinh == null || ds_Donvitinh.Tables.Count == 0)
             {
                 ds_Donvitinh = new DataSet();
                 ds_Donvitinh.ReadXml(xml_WARE_DM_DONVITINH);
             }
            
             */


            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            dsNhansu_Order = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();

            gridLookUpEdit_Nhansu.DataSource = dsNhansu_Order.Tables[0];
            gridLookUp_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = ds_Donvitinh.Tables[0];
        }

        /// <summary>
        /// load du lieu ban dau khi load form
        /// </summary>
        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();
                lookUpEdit_Cuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
                //dgbar_Dm_Table
                if (dtNgay_Order.EditValue != null && lookUpEdit_Cuahang_Ban.EditValue != null)
                {
                    dsTable_Order = objBarService.Get_All_Bar_Table_Order_By_DateOrder(true, dtNgay_Order.EditValue, lookUpEdit_Cuahang_Ban.EditValue).ToDataSet();
                    this.dgbar_Dm_Table.DataSource = dsTable_Order.Tables[0];
                    gridView1.BestFitColumns();
                }
                AllowEdit_Per_Dongia = false;
                txtPer_Dongia_All.Properties.ReadOnly = true;
                this.ChangeStatus(false);
                changeStatusButton(true);
                if (gridView1.RowCount > 0)
                {
                    SelectedId_Table_Order = gridView1.GetFocusedRowCellValue("Id_Table_Order");
                    btnEdit.Enabled = true;
                    gridView1.Focus();
                }
                else
                    btnEdit.Enabled = false;
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
            }
        }

        /// <summary>
        /// hien thi danh sach hang hoa theo order
        /// </summary>
        void DisplayInfo2()
        {
            btnCash.Enabled = true;
            if (lblStatus_Bar.Text != "")
                lblStatus_Bar.Text = "";
            try
            {
                if ("" + SelectedId_Table_Order == "")
                {
                    this.dgbar_Table_Order.DataSource = null;
                    return;
                }
                this.dsTable_Order_Chitiet = objBarService.Get_All_Bar_Table_Order_Chitiet_ById_Order(SelectedId_Table_Order).ToDataSet();
                this.dsTable_Order_Chitiet_Log = objBarService.Get_All_Bar_Table_Order_Chitiet_Log_ById_Order(SelectedId_Table_Order).ToDataSet();
                this.dgbar_Table_Order.DataSource = dsTable_Order_Chitiet;
                this.dgbar_Table_Order.DataMember = dsTable_Order_Chitiet.Tables[0].TableName;
                DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                styleFormatCondition.Appearance.BackColor = Color.LightCyan;
                styleFormatCondition.Appearance.Options.UseBackColor = true;
                styleFormatCondition.ApplyToRow = true;
                styleFormatCondition.Column = this.gridView2.Columns["Served"];
                styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                styleFormatCondition.Value1 = null;
                this.gridView2.FormatConditions.Add(styleFormatCondition);
                this.DoClickEndEdit(dgbar_Table_Order); // dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                gridView2.BestFitColumns();
            }
            catch { }
        }

        #region Event Override
        public object UpdateObject()
        {
            try
            {
                DataRow drTable_Order = dsTable_Order.Tables[0].Select("Id_Table_Order = " + gridView1.GetFocusedRowCellValue("Id_Table_Order"))[0];
                Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
                if ("" + drTable_Order["Finish"] != "") bar_Table_Order.Finish = drTable_Order["Finish"];
                if ("" + drTable_Order["Id_Booking"] != "") bar_Table_Order.Id_Booking = drTable_Order["Id_Booking"];
                if ("" + drTable_Order["Id_Ca_Lamviec"] != "") bar_Table_Order.Id_Ca_Lamviec = drTable_Order["Id_Ca_Lamviec"];
                if ("" + drTable_Order["Id_Cuahang_Ban"] != "") bar_Table_Order.Id_Cuahang_Ban = drTable_Order["Id_Cuahang_Ban"];
                if ("" + drTable_Order["Id_Khachhang"] != "") bar_Table_Order.Id_Khachhang = drTable_Order["Id_Khachhang"];
                if ("" + drTable_Order["Id_Nhansu_Bill"] != "") bar_Table_Order.Id_Nhansu_Bill = drTable_Order["Id_Nhansu_Bill"];
                if ("" + drTable_Order["Id_Nhansu_Casher"] != "") bar_Table_Order.Id_Nhansu_Casher = drTable_Order["Id_Nhansu_Casher"];
                if (Id_Nhansu_Km != -1)
                    bar_Table_Order.Id_Nhansu_Km = Id_Nhansu_Km;
                if ("" + drTable_Order["Id_Nhansu_Order"] != "") bar_Table_Order.Id_Nhansu_Order = drTable_Order["Id_Nhansu_Order"];
                if ("" + drTable_Order["Id_Table"] != "") bar_Table_Order.Id_Table = drTable_Order["Id_Table"];
                if ("" + drTable_Order["Id_Table_Order"] != "") bar_Table_Order.Id_Table_Order = drTable_Order["Id_Table_Order"];
                if ("" + drTable_Order["Id_Vip_Member_Card"] != "") bar_Table_Order.Id_Vip_Member_Card = drTable_Order["Id_Vip_Member_Card"];
                if ("" + drTable_Order["Ngay_Casher"] != "") bar_Table_Order.Ngay_Casher = drTable_Order["Ngay_Casher"];
                if ("" + drTable_Order["Ngay_Order"] != "") bar_Table_Order.Ngay_Order = drTable_Order["Ngay_Order"];
                if ("" + drTable_Order["Sochungtu"] != "") bar_Table_Order.Sochungtu = drTable_Order["Sochungtu"];
                //if ("" + drTable_Order["Sotien"] != "") bar_Table_Order.Sotien = drTable_Order["Sotien"];
                //bar_Table_Order.Sotien = gridView2.Columns["Thanhtien"].SummaryItem.SummaryValue;
                if (bar_Table_Order.Id_Khachhang != null)
                    Recal_Dongia(bar_Table_Order.Id_Khachhang);
                bar_Table_Order.Sotien = Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien)", ""))
                          - Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien_Km)", ""));
                if ("" + drTable_Order["Tien_Booking"] != "") bar_Table_Order.Tien_Booking = drTable_Order["Tien_Booking"];
                objBarService.Update_Bar_Table_Order(bar_Table_Order);

                this.DoClickEndEdit(dgbar_Table_Order); //dgbar_Table_Order.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                    {
                        dr["Id_Table_Order"] = SelectedId_Table_Order;
                        dr["Booking"] = true;
                    }
                }
                //neu sua row
                //save row trong Ware_Hdbanhang_Chitiet_Log
                if (dsTable_Order_Chitiet.HasChanges(DataRowState.Modified))
                {
                    DataTable dt_Modified = dsTable_Order_Chitiet.Tables[0].GetChanges(DataRowState.Modified).Copy();
                    dt_Modified.RejectChanges();
                    foreach (DataRow dr_Modified in dt_Modified.Rows)
                    {
                        DataRow ndr_Log = dsTable_Order_Chitiet_Log.Tables[0].NewRow();
                        foreach (DataColumn col in dt_Modified.Columns)
                            try
                            {
                                ndr_Log[col.ColumnName] = dr_Modified[col.ColumnName];
                            }
                            catch (Exception ex) { continue; }
                        ndr_Log["RowState"] = DataRowState.Modified.ToString();
                        ndr_Log["Id_Nhansu"] =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu(); //nhan su sua row
                        ndr_Log["Ngay_Hieuchinh"] = objBarService.GetServerDateTime();
                        dsTable_Order_Chitiet_Log.Tables[0].Rows.Add(ndr_Log);
                    }
                }
                objBarService.Update_Bar_Table_Order_Chitiet_Log_Collection(dsTable_Order_Chitiet_Log);

                //Update_Bar_Table_Order_Chitiet_Collection
                if (dsTable_Order_Chitiet.HasChanges())
                    objBarService.Update_Bar_Table_Order_Chitiet_Collection(dsTable_Order_Chitiet);
                return true;
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message);
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.BarService.Bar_Table_Order bar_Table_Order = new Ecm.WebReferences.BarService.Bar_Table_Order();
            bar_Table_Order.Id_Table_Order = SelectedId_Table_Order;
            return objBarService.Delete_Bar_Table_Order(bar_Table_Order);
        }

        public override bool PerformEdit()
        {
            if ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return false;
            }
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            AllowEdit_Per_Dongia = false;
            Id_Nhansu_Km = -1;
            txtPer_Dongia_All.Text = "";
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = (bool)this.UpdateObject();
                }
                if (success)
                {
                    this.DisplayInfo2();
                    ChangeStatus(false);
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
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Bar_Table_Order"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Bar_Table_Order")   }) == DialogResult.Yes)
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
            DataRow[] sdr = dsTable_Order.Tables[0].Select("Id_Table_Order = " + SelectedId_Table_Order);
            Ecm.Bar.DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Bar.DataSets.dsHdbanhang_Chitiet();
            Ecm.Bar.Reports.rptHdbanhang_noVAT rptHdbanhang_noVAT = new Ecm.Bar.Reports.rptHdbanhang_noVAT();

             GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptHdbanhang_noVAT;
            rptHdbanhang_noVAT.DataSource = dsrHdbanhang_Chitiet;
            int i = 1;
            foreach (DataRow dr in dsTable_Order_Chitiet.Tables[0].Rows)
            {
                DataRow drnew = dsrHdbanhang_Chitiet.Tables[0].NewRow();
                foreach (DataColumn dc in dsTable_Order_Chitiet.Tables[0].Columns)
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
                drnew["Ten_Hanghoa"] = gridLookUp_Hanghoa_Ban.GetDisplayText(dr["Id_Hanghoa_Ban"]);
                drnew["Dongia_Ban"] = dr["Dongia"];
                drnew["Stt"] = i++;
                dsrHdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
            }
            rptHdbanhang_noVAT.tbc_Ngay.Text = "" + dtNgay_Order .Text + "          " + sdr[0]["Ten_Table"];
            rptHdbanhang_noVAT.lblNhansu_Bill.Text = "" + gridLookUpEdit_Nhansu.GetDisplayText(sdr[0]["Id_Nhansu_Bill"]);
            double thanhtien = Convert.ToDouble(dsTable_Order_Chitiet.Tables[0].Compute("sum(thanhtien)", ""));
            if ("" + gridView1.GetFocusedRowCellValue("Id_Khachhang") != "")
            {
                DataRow[] sdrKhachhang = ds_Khachhang.Tables[0].Select("Id_Khachhang= " + gridView1.GetFocusedRowCellValue("Id_Khachhang"));
                rptHdbanhang_noVAT.lblKhachhang.Text = "" +
                   ((sdrKhachhang != null && sdrKhachhang.Length > 0) ? sdrKhachhang[0]["Ten_Khachhang"] : "");
                // check if khách hàng quota --> hiển thị thông tin giảm giá               
                //ds_Khachhang = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(gridView1.GetFocusedRowCellValue("Id_Khachhang")).ToDataSet();
                //if (ds_Khachhang.Tables.Count > 0 && ds_Khachhang.Tables[0].Rows.Count > 0)
                //{
                //    if (ds_Khachhang.Tables[0].Rows[0]["Id_Vip_Member"].ToString() == "") // check if khach hang VIP
                //    {
                //        rptHdbanhang_noVAT.lblSotien_Giam.Visible = true;
                //        rptHdbanhang_noVAT.xrSotien_Giam.Visible = true;
                //        thanhtien -= Convert.ToDouble("0" + dsTable_Order_Chitiet.Tables[0].Compute("Sum(Thanhtien_Km)", ""));
                //    }
                //}
            }
            rptHdbanhang_noVAT.tbcSochungtu.Text = "" + sdr[0]["Sochungtu"];
            //đổi số tiền thành chữ
            DataRow[] dtr_Order = dsTable_Order.Tables[0].Select("Id_Table_Order = " + sdr[0]["Id_Table_Order"]);
            if (dtr_Order[0]["Tien_Booking"].ToString() != "")
                thanhtien -= Convert.ToDouble(sdr[0]["Tien_Booking"]);
            string str =  GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            rptHdbanhang_noVAT.tbcThanhtien_Bangchu.Text = str;
            rptHdbanhang_noVAT.PageSize = new Size(800, 2000 + 120 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables[0].Rows.Count));
            if ("" + dtr_Order[0]["Tien_Booking"] != "")    //Trừ tiền cọc booking
            {
                decimal Thanhtien_TG = Convert.ToDecimal("0" +
                    dsrHdbanhang_Chitiet.Tables[0].Rows[dsrHdbanhang_Chitiet.Tables[0].Rows.Count - 1]["Thanhtien_TG"]);
                Thanhtien_TG -= Convert.ToDecimal(dtr_Order[0]["Tien_Booking"]);
                dsrHdbanhang_Chitiet.Tables[0].Rows[dsrHdbanhang_Chitiet.Tables[0].Rows.Count - 1]["Thanhtien_TG"] = Thanhtien_TG;
                rptHdbanhang_noVAT.xrTable_Tien_Booking.Visible = true;
                rptHdbanhang_noVAT.lblTien_Booking.Text = string.Format("{0:#,#}", dtr_Order[0]["Tien_Booking"]);
            }
            else
            {
                rptHdbanhang_noVAT.xrTable6.Location = new System.Drawing.Point(21, 42);
                rptHdbanhang_noVAT.xrTable4.Location = new System.Drawing.Point(21, 135);
            }

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
                rptHdbanhang_noVAT.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptHdbanhang_noVAT.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptHdbanhang_noVAT.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion

            if (sdr[0]["Finish"].ToString() == "True")
                rptHdbanhang_noVAT.lbl_Dathutien.Visible = true;
            rptHdbanhang_noVAT.lblTongcong.Text = thanhtien.ToString();
            rptHdbanhang_noVAT.CreateDocument();

             GoobizFrame.Windows.Forms.ReportOptions oReportOptions =  GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptHdbanhang_noVAT);
             if (Convert.ToBoolean(oReportOptions.PrintPreview))
             {
                 frmPrintPreview.Text = "" + oReportOptions.Caption;
                 frmPrintPreview.printControl1.PrintingSystem = rptHdbanhang_noVAT.PrintingSystem;
                 frmPrintPreview.MdiParent = this.MdiParent;
                 frmPrintPreview.Text = this.Text + "(Xem trang in)";
                 frmPrintPreview.Show();
                 frmPrintPreview.Activate();
             }
             else
             {
                  var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptHdbanhang_noVAT);
                  reportPrintTool.Print();
             }

            return base.PerformPrintPreview();
        }
        #endregion

        void ChangeStatusButtonEdit()
        {
            if (gridView1.RowCount == 0)
                btnEdit.Enabled = false;
            else
                btnEdit.Enabled = true;
        }

        void changeStatusButton(bool boo)
        {
            btnEdit.Enabled = boo && this.EnableEdit;
            btnSave.Enabled = boo;
            btnCash.Enabled = boo && this.EnablePrintPreview;
            btnClose.Enabled = boo;
            btnSave.Enabled = !boo;
            btnCancel.Enabled = !boo;
            lookUpEdit_Cuahang_Ban.Enabled = boo;
        }

        public bool checkUser_KM()
        {
            //neu thay doi field KM(Per_Dongia) --> phai xac nhan nguoi thay doi co quyen hay khong
             GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions =  GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
            if (Actions.Count == 0 || !Actions.Contains("EnableReduce"))
            {
                lblStatus_Bar.Text = "Thẻ khuyến mãi không có hiệu lực";
                return false;
            }
            else
            {
                AllowEdit_Per_Dongia = true;
                Id_Nhansu_Km = Convert.ToInt32(Actions.Id_Nhansu);
                return true;
            }
        }

        void Recal_Dongia(object Id_Khachhang)
        {
            try
            {
                if (Id_Khachhang.ToString() == "" || Id_Khachhang.ToString() == "-1")
                    return;
                ////Update Min quota nhanvuong --> chuyển code update sang performsave();
                //if ("" + lookUp_Khachhang.EditValue != "" && Convert.ToInt32(lookUp_Khachhang.EditValue) != -1)
                //    objWareService.Update_Ware_Khachhang_Min_Quota(lookUp_Khachhang.EditValue, NgayChungtu);
                //DataSet dsKhachhang_KM = objWareService.Get_All_Ware_Khachhang_Quota_Detail_By_Khachhang(Id_Khachhang).ToDataSet();
                //if (dsKhachhang_KM.Tables.Count > 0 && dsKhachhang_KM.Tables[0].Rows.Count > 0)
                //{
                //    if (dsKhachhang_KM.Tables[0].Rows[0]["Id_Vip_Member"].ToString() == "") // check if khach hang quota
                //    {
                //        Decimal sumBill = Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("sum(Thanhtien)", ""));
                //        Decimal minQuota = Convert.ToDecimal("0" + dsKhachhang_KM.Tables[0].Rows[0]["Min_Quota"]);
                //        minQuota = minQuota + Convert.ToDecimal("0" + dsTable_Order_Chitiet.Tables[0].Compute("sum(Thanhtien_Km)", ""));
                //        if (gridView2.RowCount != 0)
                //        {
                //            if (sumBill <= minQuota) // nếu tổng số tiền nhỏ hơn số tiền quota
                //            {
                //                foreach (DataRow row in dsTable_Order_Chitiet.Tables[0].Rows)
                //                {
                //                    row["Thanhtien_Km"] = row["Thanhtien"];
                //                }
                //                return;
                //            }
                //            else
                //            {
                //                object percentKM = minQuota / sumBill;
                //                foreach (DataRow row in dsTable_Order_Chitiet.Tables[0].Rows)
                //                {
                //                    row["Thanhtien_Km"] = Convert.ToDecimal("0" + Convert.ToDecimal(row["Thanhtien"]) * Convert.ToDecimal(percentKM));
                //                }
                //            }
                //        }
                //    }

                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region Event Handling

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SelectedId_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban");
            SelectedId_Table_Order = gridView1.GetFocusedRowCellValue("Id_Table_Order");
            focusOfGirdView1 = gridView1.FocusedRowHandle;
            txtPer_Dongia_All.Text = "";
            DisplayInfo2();
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr_change = gridView2.GetDataRow(e.RowHandle);
            if (dr_change == null) return;
            switch (e.Column.FieldName)
            {
                case "Per_Dongia":
                    if (e.Column.FieldName == "Per_Dongia" && !AllowEdit_Per_Dongia)
                    {
                         GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions =  GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
                        if (Actions.Count == 0 || !Actions.Contains("EnableReduce"))
                        {
                            dr_change.RejectChanges();
                            return;
                        }
                        else
                        {
                            AllowEdit_Per_Dongia = true;
                            Id_Nhansu_Km = Convert.ToInt32(Actions.Id_Nhansu);
                        }
                    }
                    if (Convert.ToDouble("0" + dr_change["Per_Dongia"]) > 100 || Convert.ToDouble("0" + dr_change["Per_Dongia"]) < 0)
                    {
                        MessageBox.Show("Giá trị khuyến mãi không hợp lệ (từ 0 - 100)");
                        dr_change.RejectChanges();
                    }
                    break;
                case "Id_Hanghoa_Ban":
                    lblStatus_Bar.Text = "";
                    if ("" + dr_change["Served"] == "")
                    {
                        dr_change["Id_Donvitinh"] =
                        ((System.Data.DataRowView)gridLookUp_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"];
                        dr_change["Dongia"] =
                           ((System.Data.DataRowView)gridLookUp_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Dongia_Ban"];
                    }
                    else
                    {
                        lblStatus_Bar.Text = "Món đã được phục vụ xong, không được phép chỉnh sửa";
                        dr_change.CancelEdit();
                    }
                    break;
                case "Soluong":
                    lblStatus_Bar.Text = "";
                    if ("" + dr_change["Served"] == "")
                        dr_change["Served"] = 0;

                    if (Convert.ToBoolean(dr_change["Served"]))
                    {
                        lblStatus_Bar.Text = "Món đã được phục vụ xong, không được phép chỉnh sửa";
                        dr_change.RejectChanges();
                    }
                    else
                    {
                        object SL_PV = dr_change["Soluong_Phucvu"];
                        object Soluong = dr_change["Soluong"];
                        if (Soluong.ToString().Contains("."))
                        {
                            lblStatus_Bar.Text = "Số lượng phải là số nguyên";
                            dr_change.RejectChanges();
                            return;
                        }
                        if (Convert.ToInt32("0" + Soluong) == 0)
                        {
                            lblStatus_Bar.Text = "Số lượng không được bằng 0";
                            dr_change.RejectChanges();
                        }
                        if (Convert.ToInt32("0" + SL_PV) == 0)
                            return;
                        if (Convert.ToInt32("0" + SL_PV) > Convert.ToInt32("0" + Soluong))
                        {
                            lblStatus_Bar.Text = "Số lượng không được dưới số lượng đã phục vụ: " + SL_PV;
                            dr_change.RejectChanges();
                        }
                        else if (Convert.ToInt32("0" + SL_PV) == Convert.ToInt32("0" + Soluong))
                            dr_change["Served"] = true;
                    }
                    break;
                case "Soluong_Phucvu":
                    lblStatus_Bar.Text = "";

                    if ("" + dr_change["Served"] == "")
                        dr_change["Served"] = 0;

                    if (Convert.ToBoolean(dr_change["Served"]))
                    {
                        lblStatus_Bar.Text = "Món đã được phục vụ xong, không được phép chỉnh sửa";
                        dr_change.RejectChanges();
                    }
                    if (dr_change["Soluong_Phucvu"].ToString().Contains("."))
                    {
                        lblStatus_Bar.Text = "Số lượng phải là số nguyên";
                        dr_change.RejectChanges();
                        return;
                    }
                    if (Convert.ToInt32("0" + dr_change["Soluong_Phucvu"]) > Convert.ToInt32("0" + dr_change["Soluong"]))
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng đã phục vụ lớn hơn số lượng yêu cầu");
                        gridView2.SetFocusedRowCellValue(gridView2.Columns["Soluong_Phucvu"], null);
                        gridView2.FocusedColumn = gridView2.Columns["Soluong_Phucvu"];
                        return;
                    }
                    if (Convert.ToInt32("0" + dr_change["Soluong_Phucvu"]) == Convert.ToInt32("0" + dr_change["Soluong"]))
                        gridView2.SetFocusedRowCellValue(gridView2.Columns["Served"], 1);
                    else
                        gridView2.SetFocusedRowCellValue(gridView2.Columns["Served"], 0);
                    break;
            }
            try
            {
                if (Convert.ToBoolean(dr_change["Served"]))
                {
                    ///tinh lai thanh tien
                    dr_change["Thanhtien"] = Convert.ToDecimal(dr_change["Soluong"])
                                            * Convert.ToDecimal("0" + dr_change["Dongia"]) * (1 - Convert.ToDecimal("0" + dr_change["Per_Dongia"]) / 100);
                    if (gridView1.GetFocusedRowCellValue("Id_Khachhang") != null || gridView1.GetFocusedRowCellValue("Id_Khachhang").ToString() != "-1")
                        Recal_Dongia(gridView1.GetFocusedRowCellValue("Id_Khachhang"));
                    //if ("" + dr_change["Per_Dongia"] != "")
                    //    dr_change["Thanhtien_Km"] = Convert.ToDecimal(dr_change["Per_Dongia"]) * (Convert.ToDecimal(dr_change["Soluong"]) * Convert.ToDecimal("0" + dr_change["Dongia"])) / 100;
                }
                else
                {
                    dr_change["Thanhtien"] = DBNull.Value;
                    dr_change["Thanhtien_Km"] = DBNull.Value;
                }
            }
            catch (Exception ex) { GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString()); }
        }

        private void dgbar_Table_Order_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //neu xoa row --> save row vao Ware_Hdbanhang_Chitiet_Log
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove
                &&  GoobizFrame.Windows.Forms.UserMessage.Show("Msg00021", new string[] { "" }) == DialogResult.Yes)
            {
                DataRow ndr_Log = dsTable_Order_Chitiet_Log.Tables[0].NewRow();
                DataRow fdr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                foreach (DataColumn col in fdr.Table.Columns)
                    try
                    {
                        ndr_Log[col.ColumnName] = fdr[col.ColumnName];
                    }
                    catch (Exception ex) { continue; }
                ndr_Log["RowState"] = DataRowState.Deleted.ToString();
                ndr_Log["Id_Nhansu"] =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu(); //nhan su xoa row
                ndr_Log["Ngay_Hieuchinh"] = objBarService.GetServerDateTime();
                dsTable_Order_Chitiet_Log.Tables[0].Rows.Add(ndr_Log);
            }
            else
                e.Handled = true;
        }

        private void repositoryItemCheckEdit1_CheckStateChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(gridView2.EditingValue))
            {
                gridView2.SetFocusedRowCellValue(gridView2.Columns["Soluong_Phucvu"], gridView2.GetFocusedRowCellValue("Soluong"));
            }
            else
            {
                gridView2.SetFocusedRowCellValue(gridView2.Columns["Served"], 0);
                if (Convert.ToInt32(gridView2.GetFocusedRowCellValue("Soluong")) != 1)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Vui lòng cập nhật lại số lượng đã phục vụ");
                    gridView2.FocusedColumn = gridView2.Columns["Soluong_Phucvu"];
                }
                gridView2.SetFocusedRowCellValue(gridView2.Columns["Soluong_Phucvu"], DBNull.Value);
            }
        }

        private void txtPer_Dongia_All_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32("0" + txtPer_Dongia_All.EditValue) < 0 || Convert.ToInt32("0" + txtPer_Dongia_All.EditValue) > 100)
                {
                    MessageBox.Show("Giá trị khuyến mãi không hợp lệ (từ 0 - 100)");
                    return;
                }
                if (Convert.ToInt32("0" + txtPer_Dongia_All.EditValue) == 0)
                {
                    for (int i = 0; i < dsTable_Order_Chitiet.Tables[0].Rows.Count; i++)
                    {
                        gridView2.SetRowCellValue(i, gridView2.Columns["Per_Dongia"], DBNull.Value);
                    }
                    gridView2.FocusedRowHandle = dsTable_Order_Chitiet.Tables[0].Rows.Count - 1;
                    return;
                }
                for (int i = 0; i < dsTable_Order_Chitiet.Tables[0].Rows.Count; i++)
                {
                    gridView2.SetRowCellValue(i, gridView2.Columns["Per_Dongia"], txtPer_Dongia_All.EditValue);
                }
                gridView2.FocusedRowHandle = dsTable_Order_Chitiet.Tables[0].Rows.Count - 1;
            }
        }

        private void dtNgay_Order_EditValueChanged(object sender, EventArgs e)
        {
            if (dtNgay_Order.Text != "")
            {
                try
                {
                    dsTable_Order = objBarService.Get_All_Bar_Table_Order_By_DateOrder(true, dtNgay_Order.EditValue, lookUpEdit_Cuahang_Ban.EditValue).ToDataSet();
                    this.dgbar_Dm_Table.DataSource = dsTable_Order;
                    this.dgbar_Dm_Table.DataMember = dsTable_Order.Tables[0].TableName;
                    if (dsTable_Order.Tables[0].Rows.Count > 0)
                    {
                        txtSochungtu.DataBindings.Clear();
                        txtSochungtu.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Sochungtu");
                        SelectedId_Table_Order = dsTable_Order.Tables[0].Rows[0]["Id_Table_Order"];
                        gridView1.BestFitColumns();
                        this.DisplayInfo2();
                    }
                    else
                    {
                        txtSochungtu.DataBindings.Clear();
                        txtSochungtu.Text = "";
                    }
                    //this.dgbar_Dm_Table.DataMember = dsTable_Order.Tables[0].TableName;
                    btnCash.Enabled = (dsTable_Order.Tables[0].Rows.Count != 0);
                    ChangeStatusButtonEdit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                this.dgbar_Dm_Table.DataSource = null;
                this.dgbar_Table_Order.DataSource = null;
            }
        }

        private void lookUpEdit_Cuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            dsTable_Order = objBarService.Get_All_Bar_Table_Order_By_DateOrder(true, dtNgay_Order.EditValue, lookUpEdit_Cuahang_Ban.EditValue).ToDataSet();
            dgbar_Dm_Table.DataSource = dsTable_Order;
            dgbar_Dm_Table.DataMember = dsTable_Order.Tables[0].TableName;
            if (dsTable_Order.Tables[0].Rows.Count > 0)
            {
                txtSochungtu.DataBindings.Clear();
                txtSochungtu.DataBindings.Add("EditValue", dsTable_Order, dsTable_Order.Tables[0].TableName + ".Sochungtu");
                SelectedId_Table_Order = dsTable_Order.Tables[0].Rows[0]["Id_Table_Order"];
                gridView1.BestFitColumns();
                this.DisplayInfo2();
                ChangeStatusButtonEdit();
            }
            else
            {
                txtSochungtu.DataBindings.Clear();
                txtSochungtu.Text = "";
            }
            btnCash.Enabled = (dsTable_Order.Tables[0].Rows.Count != 0);
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id_Table_Order") == null)
                return;
            if (dsTable_Order_Chitiet.Tables[0].Select("Served is null or Served = 0").Length > 0)
            {
                lblStatus_Bar.Text = "Bàn chưa phục vụ xong nên không thể in hóa đơn";
                btnCash.Enabled = false;
                return;
            }
            PerformPrintPreview();
            LoadMasterData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id_Table_Order") == null)
                return;
            if (gridView2.RowCount > 0)
            {
                if ((gridView1.GetFocusedRowCellValue("Finish").ToString() == "True"))
                {
                    lblStatus_Bar.Text = "Bàn đã thanh toán nên không thể chỉnh sửa";
                    return;
                }
                if (PerformEdit())
                {
                    FormState =  GoobizFrame.Windows.Forms.FormState.Edit;
                    changeStatusButton(false);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.FormState =  GoobizFrame.Windows.Forms.FormState.Edit;
            if (PerformSave())
            {
                this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
                changeStatusButton(true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            changeStatusButton(true);
            this.FormState =  GoobizFrame.Windows.Forms.FormState.View;
            PerformCancel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void gridButtonEdit_Soluong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            object value =  GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
                              "" + gridView2.GetFocusedRowCellValue("" + gridView2.FocusedColumn.FieldName));
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Số lượng phải là số nguyên";
                return;
            }
            if (value.ToString().Contains("-"))
            {
                lblStatus_Bar.Text = "Số lượng không được nhập số âm";
                gridView2.CancelUpdateCurrentRow();
                return;
            }
            if (value.ToString().Length >= 6)
            {
                lblStatus_Bar.Text = "Số lượng nhập không chính xác";
                gridView2.CancelUpdateCurrentRow();
                return;
            }
            if (value.Equals(""))
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, DBNull.Value);
            else
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, value);
            gridView2.RefreshRow(gridView2.FocusedRowHandle);
            lblStatus_Bar.Text = "";
        }

        private void gridButtonEdit_Giamgia_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!AllowEdit_Per_Dongia)
            {
                 GoobizFrame.Windows.Forms.Policy.Authorization.Actions Actions =  GoobizFrame.Windows.MdiUtils.MdiChecker.ShowIDCardLogonWithResult(this);
                if (Actions.Count == 0 || !Actions.Contains("EnableReduce"))
                {
                    lblStatus_Bar.Text = "Thẻ khuyến mãi không có hiệu lực";
                    return;
                }
                else
                {
                    AllowEdit_Per_Dongia = true;
                    Id_Nhansu_Km = Convert.ToInt32(Actions.Id_Nhansu);
                }
            }
            object value =  GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
                        "" + gridView2.GetFocusedRowCellValue("" + gridView2.FocusedColumn.FieldName));
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Khuyến mãi phải là số nguyên";
                return;
            }
            if (value.ToString().Contains("-"))
            {
                // GoobizFrame.Windows.Forms.MessageDialog.Show("Khuyến mãi không được nhập số âm");
                lblStatus_Bar.Text = "Khuyến mãi không được nhập số âm";
                gridView2.CancelUpdateCurrentRow();
                return;
            }
            if (value.ToString().Length > 3)
            {
                // GoobizFrame.Windows.Forms.MessageDialog.Show("Khuyến mãi nhập không chính xác");
                //value = value.ToString().Substring(0, 5);
                //gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, value);
                lblStatus_Bar.Text = "Khuyến mãi nhập không chính xác";
                gridView2.CancelUpdateCurrentRow();
                return;
            }
            if (Convert.ToInt32(value) > 100)
            {
                lblStatus_Bar.Text = "Khuyến mãi nhập không chính xác";
                gridView2.CancelUpdateCurrentRow();
                return;
            }
            if (value.Equals(""))
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, DBNull.Value);
            else
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, value);
            gridView2.RefreshRow(gridView2.FocusedRowHandle);
            lblStatus_Bar.Text = "";
        }

        private void gridButtonEdit_Soluong_Phucvu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            object value =  GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(
          "" + gridView2.GetFocusedRowCellValue("" + gridView2.FocusedColumn.FieldName));
            if (value.ToString().Contains("."))
            {
                lblStatus_Bar.Text = "Số lượng phải là số nguyên";
                return;
            }
            if (value.ToString().Contains("-"))
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được nhập số âm");
                value = value.ToString().Replace("-", "");
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, value);
                return;
            }
            if (value.ToString().Length >= 6)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng nhập không chính xác");
                value = value.ToString().Substring(0, 5);
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, value);
                return;
            }
            if (value.Equals(""))
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, DBNull.Value);
            else
                gridView2.SetFocusedRowCellValue(gridView2.FocusedColumn, value);
            gridView2.RefreshRow(gridView2.FocusedRowHandle);
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            gridView1.MovePrevPage();
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            gridView1.MoveNextPage();
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            gridView2.MovePrevPage();
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            gridView2.MoveNextPage();
        }

        private void txtPer_Dongia_All_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.View)
                return;
            lblStatus_Bar.Text = "";
            if (!AllowEdit_Per_Dongia)
            {
                if (checkUser_KM() == false)
                    return;
            }
            txtPer_Dongia_All.Text = "" +  GoobizFrame.Windows.Forms.FrmGNumboardInput.ShowInputDialog(txtPer_Dongia_All.Text);
        }

        private void txtPer_Dongia_All_EditValueChanged(object sender, EventArgs e)
        {
            if (FormState ==  GoobizFrame.Windows.Forms.FormState.Edit && txtPer_Dongia_All.Text != "")
            {
                if (txtPer_Dongia_All.Text.Length < 4 && Convert.ToInt32(txtPer_Dongia_All.EditValue) <= 100)
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        gridView2.SetRowCellValue(i, gridView2.Columns["Per_Dongia"], txtPer_Dongia_All.EditValue);
                    }
                else
                {
                    lblStatus_Bar.Text = "Khuyến mãi nhập không đúng, vui lòng nhập lại";
                    txtPer_Dongia_All.EditValue = null;
                }
            }
        }

        #endregion

    }
}