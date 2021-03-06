#region edit
/*
 * edit     phuongphan
 * date     04/04/2011
 * content  edit GUI
 * ---
 */
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Chamcong_Thang : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.RexService.Rex_Chamcong_Thang rex_Chamcong_Thang;
        DataSet dsChamcong = new DataSet();
        DataSet dsNhansu = new DataSet();
        DataSet dsNghiphep = new DataSet();
        public long id_bophan;
        DataSet dsHeso_Chuongtrinh;
        Frmrex_Nghiphep_ByNhansu frmrex_Nghiphep_ByNhansu;
        DataSet dsDm_Chucvu;
        DataSet ds_Bophan;

        public Frmrex_Chamcong_Thang()
        {
            InitializeComponent();
            DisplayInfo();
            ChangeStatus(false);
            dtThangnam.EditValue = DateTime.Now;
           
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Query.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
         
        }

        #region Event Override

        public override void DataBindingControl()
        {
            chkChunhat.DataBindings.Clear();
            chkThuhai.DataBindings.Clear();
            chkThuba.DataBindings.Clear();
            chkThutu.DataBindings.Clear();
            chkThunam.DataBindings.Clear();
            chkThusau.DataBindings.Clear();
            chkThubay.DataBindings.Clear();

            //``````````````````````````````````````````````````
            chkChunhat.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ChuNhat");
            chkThuhai.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuHai");
            chkThuba.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuBa");
            chkThutu.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuTu");
            chkThunam.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuNam");
            chkThusau.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuSau");
            chkThubay.DataBindings.Add("EditValue", ds_Bophan, ds_Bophan.Tables[0].TableName + ".ThuBay");

            base.DataBindingControl();
        }

        public override void DisplayInfo()
        {
            try
            {
                GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
                //TreeList - Rex_Dm_Bophan
                ds_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
                treeListColumn1.TreeList.DataSource = ds_Bophan;
                treeListColumn1.TreeList.DataMember = ds_Bophan.Tables[0].TableName;
                //lookUpEdit_Kyluong - Rex_Dm_Kyluong
                //LocalHostWebservice.Rex_Dm_Kyluong[] arrRex_Dm_Kyluong = objRexService.Get_Rex_Dm_Kyluong_Collection1();
                //lookUpEdit_Kyluong.Properties.DataSource = arrRex_Dm_Kyluong;
                //lookUpEdit_Kyluong.ItemIndex = 0;
                dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();

                dsDm_Chucvu = objMasterService.Get_All_Rex_Dm_Chucvu_Collection().ToDataSet();

                DataBindingControl();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
            }
        }

        private void DisplayInfo2()
        {
            try
            {
                if ("" + dtThangnam.EditValue != "")
                {
                    dsChamcong.Clear();
                    //rex_Chamcong_Thang = new Ecm.WebReferences.RexService.Rex_Chamcong_Thang();
                    //rex_Chamcong_Thang.Id_Bophan = id_bophan;
                    //rex_Chamcong_Thang.Thang_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Month);
                    //rex_Chamcong_Thang.Nam_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Year);
                    //rex_Chamcong_Thang.Baogom_Nghiphep = true;
                    dsChamcong = objRexService.Get_All_Rex_Chamcong_Thang_Collection(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, id_bophan, true, false).ToDataSet();
                    int day_in_month = System.DateTime.DaysInMonth(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month);
                    foreach (DataColumn col in dsChamcong.Tables[0].Columns)
                    {
                        col.ReadOnly = false;                       
                    }

                    //foreach (DataRow dt in dsChamcong.Tables[0].Rows)
                    //{
                    //    dsNghiphep = objRexService.Get_All_Rex_Nghiphep_By_Nhansu_Nam_Thang(dt["Id_Nhansu"], dtThangnam.DateTime.Year, dtThangnam.DateTime.Month);
                    //    for (int i = 1; i <= day_in_month; i++)
                    //    {
                    //        DateTime date_nghiphep = new DateTime(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, i);
                    //        foreach (DataRow dtnghi_phep in dsNghiphep.Tables[0].Rows)
                    //        {
                    //            if (date_nghiphep >= DateTime.Parse(dtnghi_phep["Ngay_Batdau"].ToString()) && date_nghiphep <= DateTime.Parse(dtnghi_phep["Ngay_Ketthuc"].ToString()))
                    //            {
                    //                dt["Ngay" + i.ToString("00")] = (string.IsNullOrEmpty(dt["Ngay" + i.ToString("00")].ToString()) ? "" : dt["Ngay" + i.ToString("00")] + ",") + dtnghi_phep["Ma_Loai_Nghiphep"];
                    //            }
                    //        }
                    //    }
                    //}

                    //dsChamcong.AcceptChanges();
                    for (int i = 0; i < dsChamcong.Tables[0].Rows.Count; i++)
                    {
                        if ("" + dsChamcong.Tables[0].Rows[i]["ngay_nghiviec"] != "")
                        {
                            DateTime day = new DateTime(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, 1);
                            if (DateTime.Parse(dsChamcong.Tables[0].Rows[i]["ngay_nghiviec"].ToString()) < day)
                            {
                                dsChamcong.Tables[0].Rows.RemoveAt(i);
                            }
                            else
                            {
                                for (int j = 0; j < dsChamcong.Tables[0].Rows.Count; j++)
                                {
                                    if (dsChamcong.Tables[0].Rows[j]["id_nhansu"].ToString().Equals(dsChamcong.Tables[0].Rows[i]["id_nhansu"].ToString()) && j != i)
                                    {
                                        dsChamcong.Tables[0].Rows.RemoveAt(i);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    dgrex_Chamcong_Thang.DataSource = dsChamcong;
                    dgrex_Chamcong_Thang.DataMember = dsChamcong.Tables[0].TableName;
                    //this.Data = dsChamcong;
                    //this.GridControl = dgrex_Chamcong_Thang;
                    gridColumn33.Visible = true;
                    gridColumn34.Visible = true;
                    gridColumn35.Visible = true;
                    if (day_in_month < 31)
                    {
                        gridColumn35.Visible = false;
                        if (day_in_month < 30)
                        {
                            gridColumn34.Visible = false;
                            if (day_in_month < 29)
                                gridColumn33.Visible = false;
                        }
                    }
                    //update gridview header column
                    for (int day = 1; day <= day_in_month; day++)
                    {
                        DateTime date = new DateTime(dtThangnam.DateTime.Year,dtThangnam.DateTime.Month, day);
                        if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                        {
                            gvChamcong_Thang.Columns["Ngay" + day.ToString().PadLeft(2, '0')].Caption = date.DayOfWeek.ToString();
                            gvChamcong_Thang.Columns["Ngay" + day.ToString().PadLeft(2, '0')].AppearanceCell.BackColor = Color.Pink;
                            if (date.DayOfWeek == DayOfWeek.Sunday)
                                gvChamcong_Thang.Columns["Ngay" + day.ToString().PadLeft(2, '0')].Caption = "Chủ nhật";
                            else
                                gvChamcong_Thang.Columns["Ngay" + day.ToString().PadLeft(2, '0')].Caption = "Thứ bảy";
                        }
                        else
                        {
                            gvChamcong_Thang.Columns["Ngay" + day.ToString().PadLeft(2, '0')].Caption = "Ngày " + day.ToString().PadLeft(2, '0');
                            gvChamcong_Thang.Columns["Ngay" + day.ToString().PadLeft(2, '0')].AppearanceCell.BackColor = Color.White;
                        }
                    }
                    gvChamcong_Thang.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
            }
        }

       

        public override bool PerformEdit()
        {
            dgrex_Chamcong_Thang.DataSource = null;

            dsChamcong = objRexService.Get_All_Rex_Chamcong_Thang_Collection(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, id_bophan, false, false).ToDataSet();

            dgrex_Chamcong_Thang.DataSource = dsChamcong.Tables[0];
            gvChamcong_Thang.RefreshData();

            ChangeStatus(true);

            foreach (DataRow drChamcong in dsChamcong.Tables[0].Rows)
            {
                if (Convert.ToBoolean(drChamcong["Pb_Btri_Nsu_New"]))
                    drChamcong.SetAdded();
            }
            return base.PerformEdit();
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo2();
            ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            PerformSaveChanges();
            ChangeStatus(false);
            return base.PerformSave();
        }

        public override bool PerformSaveChanges()
        {
            try
            {
                this.DoClickEndEdit(dgrex_Chamcong_Thang);
                string s = "";
                int day_in_month = System.DateTime.DaysInMonth(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month);
                foreach (DataRow dt in dsChamcong.Tables[0].Rows)
                {
                    decimal giocong = 0;
                    dsNghiphep = objRexService.Get_All_Rex_Nghiphep_By_Nhansu_Nam_Thang(dt["Id_Nhansu"], dtThangnam.DateTime.Year, dtThangnam.DateTime.Month).ToDataSet();
                    for (int i = 1; i <= day_in_month; i++)
                    {
                        DateTime date_nghiphep = new DateTime(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, i);
                        foreach (DataRow dtnghi_phep in dsNghiphep.Tables[0].Rows)
                        {
                            if (date_nghiphep >= DateTime.Parse(dtnghi_phep["Ngay_Batdau"].ToString()) && date_nghiphep <= DateTime.Parse(dtnghi_phep["Ngay_Ketthuc"].ToString()))
                            {
                                if (dt["Ngay" + i.ToString("00")].ToString().IndexOf("," + dtnghi_phep["Ma_Loai_Nghiphep"].ToString()) > 0)
                                {
                                    dt["Ngay" + i.ToString("00")] = dt["Ngay" + i.ToString("00")].ToString().Replace("," + dtnghi_phep["Ma_Loai_Nghiphep"], "");
                                }
                                else if (dt["Ngay" + i.ToString("00")].ToString().Equals(dtnghi_phep["Ma_Loai_Nghiphep"].ToString()))
                                {
                                    dt["Ngay" + i.ToString("00")] = dt["Ngay" + i.ToString("00")].ToString().Replace(dtnghi_phep["Ma_Loai_Nghiphep"].ToString(), "");
                                }
                            }
                        }
                        //giocong += Convert.ToDecimal("0" + dt["Ngay" + i.ToString("00")]);
                    }
                    dt["Giocong"] = giocong;
                }
                //dsChamcong.Tables[0].Columns.Add("Id_Bophan");
                dsChamcong.Tables[0].Columns.Add("Heso");
                dsChamcong.Tables[0].Columns.Add("Uid");
                dsChamcong.Tables[0].Columns.Add("Date_Create");
                dsChamcong.Tables[0].Columns.Add("Date_Modify");
                dsChamcong.Tables[0].Columns.Add("Loai");
                objRexService.Update_Rex_Chamcong_Thang_Collection(dsChamcong.GetChanges());

                //tinh lai gio cong
                var rex_chamcong = new Ecm.WebReferences.RexService.Rex_Chamcong_Thang()
                       {
                           Nam_Kyluong = dtThangnam.DateTime.Year,
                           Thang_Kyluong = dtThangnam.DateTime.Month,
                           Id_Bophan = id_bophan
                       };
                objRexService.Rex_Chamcong_Thang_Tinhgiocong(rex_chamcong );
                
                //tinh luong
                new System.Threading.Thread(new System.Threading.ThreadStart(Luongtonghop_Init)).Start();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"Exception");
            }
            DisplayInfo2();
            return true;
        }

        void Luongtonghop_Init()
        {
            try
            {
                //tinh luong
                objRexService.Rex_Luong_Tonghop_Init_ByBophan(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, id_bophan);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"Exception");
            }
        }

        public override bool PerformQuery()
        {
            if (gvChamcong_Thang.RowCount > 0)
            {
                if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00035", new string[] { "Bảng chấm công" }) != DialogResult.Yes)
                    return false;
            }
            try
            {
                //Lập lại bảng chấm công
                rex_Chamcong_Thang = new Ecm.WebReferences.RexService.Rex_Chamcong_Thang();
                rex_Chamcong_Thang.Nam_Kyluong = this.dtThangnam.DateTime.Year;
                rex_Chamcong_Thang.Id_Bophan = id_bophan;
                rex_Chamcong_Thang.Thang_Kyluong = this.dtThangnam.DateTime.Month;
                objRexService.Init_Rex_Chamcong_Thang_ByFinger(rex_Chamcong_Thang);
                DisplayInfo();
                return base.PerformQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public override bool PerformPrintPreview()
        {
            //dsChamcong = objRexService.Get_All_Rex_Chamcong_Thang_Collection(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, id_bophan, true, false);

            //int day_in_month = System.DateTime.DaysInMonth(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month);
            //foreach (DataRow dt in dsChamcong.Tables[0].Rows)
            //{
            //    dsNghiphep = objRexService.Get_All_Rex_Nghiphep_By_Nhansu_Nam_Thang(dt["Id_Nhansu"], dtThangnam.DateTime.Year, dtThangnam.DateTime.Month);

            //    for (int i = 1; i <= day_in_month; i++)
            //    {
            //        DateTime date_nghiphep = new DateTime(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, i);

            //        foreach (DataRow dtnghi_phep in dsNghiphep.Tables[0].Rows)
            //        {
            //            if (date_nghiphep >= DateTime.Parse(dtnghi_phep["Ngay_Batdau"].ToString()) && date_nghiphep <= DateTime.Parse(dtnghi_phep["Ngay_Ketthuc"].ToString()))
            //            {
            //                dt["Ngay" + i.ToString("00")] = (string.IsNullOrEmpty(dt["Ngay" + i.ToString("00")].ToString()) ? "" : dt["Ngay" + i.ToString("00")] + ",") + dtnghi_phep["Ma_Loai_Nghiphep"];
            //            }
            //        }
            //    }
            //}
            //khoi tao report cham cong
            Reports.rptRex_Chamcong_Thang objrptChamcong_Thang = new Ecm.Rex.Reports.rptRex_Chamcong_Thang();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = objrptChamcong_Thang;


            ReportHelper.SetCompanyInfoAtHeader(objrptChamcong_Thang);
            objrptChamcong_Thang.FindControl("xrc_Ngay_Ketthuc",true).Text = string.Format("{0:MM/yyyy}",dtThangnam.DateTime);
            objrptChamcong_Thang.DataSource = dsChamcong;
            objrptChamcong_Thang.CreateDocument();
            //objrptChamcong_Thang.xrChart1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Ngay01", "Ngay02", "Ngay03", "Ngay04", "Ngay05" });
            //su dung control report
            frmPrintPreview.printControl1.PrintingSystem = objrptChamcong_Thang.PrintingSystem;
            frmPrintPreview.MdiParent = this.MdiParent;
            frmPrintPreview.Text = this.Text + @"(Xem trang in)";
            frmPrintPreview.Show();
            return base.PerformPrintPreview();
        }
        #endregion

        #region Custom method

        void ChangeStatus(bool editable)
        {
            treeList_Bophan.Enabled = !editable;
            gvChamcong_Thang.OptionsBehavior.Editable = editable;
            dtThangnam.Properties.ReadOnly = editable;
            btnUpdate_Hs_Trachnhiem.Enabled = editable;
            btnImportExcel.Enabled = editable;
        }

        private int GetHours(string chamcong)
        {
            int hour = 0;
            int index = 0;
            string[] words = chamcong.Split(',');
            foreach (string word in words)
            {
                if (int.TryParse(word, out index))
                {
                    hour += int.Parse(word.ToString());
                }
            }
            return hour;
        }

        public static bool IsNumeric(object value)
        {
            try
            {
                int d = System.Int32.Parse(value.ToString(),
                System.Globalization.NumberStyles.Any);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        #endregion

        #region Event Handling

      

        private void treeList_Bophan_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            try
            {
                id_bophan = Convert.ToInt64("" + e.Node.GetValue("Id_Bophan"));
                this.DisplayInfo2();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if ((e.Column.FieldName != "Ngaycong") && (e.Column.FieldName != "Giocong"))
            {
                int day_in_month = System.DateTime.DaysInMonth(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month);
                object cellvalue;
                int so_ngay = 0;
                int so_gio = 0;
                int number_value = 0;
                int index;
                for (int day = 1; day <= day_in_month; day++)
                {
                    index = day + 3;
                    cellvalue = gvChamcong_Thang.GetFocusedRowCellValue(gvChamcong_Thang.Columns[index]);
                    if (IsNumeric(cellvalue))
                    {
                        number_value = Int32.Parse(cellvalue.ToString());
                        if (number_value > 0)
                        {
                            so_ngay++;
                            so_gio += number_value;
                        }
                    }
                }
                gvChamcong_Thang.SetFocusedRowCellValue(gvChamcong_Thang.Columns["Ngaycong"], so_ngay);
                gvChamcong_Thang.SetFocusedRowCellValue(gvChamcong_Thang.Columns["Giocong"], so_gio);
                //dgrex_Chamcong_Thang.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                this.DoClickEndEdit(dgrex_Chamcong_Thang);
            }
        }

        private void lookUpEdit_Kyluong_EditValueChanged(object sender, EventArgs e)
        {
            this.DisplayInfo2();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvChamcong_Thang.FocusedColumn = gvChamcong_Thang.Columns[1];
        }

        private void dtThangnam_EditValueChanged(object sender, EventArgs e)
        {
            DataSet dsKyluong = objRexService.Get_All_Rex_Kyluong_ByThangNam(dtThangnam.DateTime.Month, dtThangnam.DateTime.Year).ToDataSet();
            DisplayInfo2();
        }

        private void repositoryItemButtonEdit_Ca_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {

                gvChamcong_Thang.SetFocusedRowCellValue(gvChamcong_Thang.FocusedColumn,
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "GIOCONG_NGAY"))[0]["Heso"]
                    );
               
            }
            else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Minus)
            {
                if (frmrex_Nghiphep_ByNhansu == null || frmrex_Nghiphep_ByNhansu.IsDisposed)
                    frmrex_Nghiphep_ByNhansu = new Frmrex_Nghiphep_ByNhansu();
                frmrex_Nghiphep_ByNhansu.Id_Nhansu = gvChamcong_Thang.GetFocusedRowCellValue("Id_Nhansu");
                frmrex_Nghiphep_ByNhansu.Ngay_Batdau = new DateTime( 
                    dtThangnam.DateTime.Year, 
                    dtThangnam.DateTime.Month,
                    Convert.ToInt32( gvChamcong_Thang.FocusedColumn.FieldName.Replace("Ngay", "")));
                frmrex_Nghiphep_ByNhansu.ShowDialog();
            }
            else
            {
                System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterService.dll",
                    "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Loai_Nghiphep_Add", this);
                if (dialog == null)
                    return;
                var SelectedObject = dialog.GetType().GetProperty("Selected_Rex_Dm_Loai_Nghiphep").GetValue(dialog, null)
                   as Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep;
               
                if (SelectedObject != null)
                {
                    gvChamcong_Thang.SetFocusedRowCellValue(gvChamcong_Thang.FocusedColumn, SelectedObject.Ma_Loai_Nghiphep);
                }
            }
        }

        

        private void gridButton_Ca_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (e.NewValue.ToString() != "" && Convert.ToDecimal("0" + e.NewValue) > 24)
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"");
            }
        }

        #endregion

        private void btnUpdate_Hs_Trachnhiem_Click(object sender, EventArgs e)
        {
            foreach (DataRow drChamcong in dsChamcong.Tables[0].Rows)
            {
                if ("" + drChamcong["Id_Chucvu"] != "")
                {
                    DataRow[] sdrChucvu = dsDm_Chucvu.Tables[0].Select(string.Format("Id_Chucvu={0}", drChamcong["Id_Chucvu"]));
                    if (sdrChucvu.Length > 0)
                        drChamcong["Hs_Trachnhiem"] = sdrChucvu[0]["Heso_Chucvu"];
                }
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
             GoobizFrame.Windows.Tools.FrmExcelData frmExcelData = new GoobizFrame.Windows.Tools.FrmExcelData();
            frmExcelData.ShowDialog();

            if (frmExcelData.DsImportData != null)
            {
                DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ trong vài giây...","Đang thực hiện");
                DataSet dsExcel = frmExcelData.DsImportData;
                bool split_update = false;
                if (dsExcel.Tables[0].Rows.Count > 100)
                    split_update = 
                        (GoobizFrame.Windows.Forms.MessageDialog.Show("Dữ liệu quá lớn, bạn đồng ý cập nhật từng phần không?","Xác nhận", MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes);

                int rec_update = 0;
                foreach (DataRow drChamcong in dsChamcong.Tables[0].Rows)
                {
                    DataRow[] sdrExcel = dsExcel.Tables[0].Select(string.Format("Ma_Nhansu='{0}'", drChamcong["Ma_Nhansu"]));
                    if (sdrExcel.Length > 0)
                    {                        
                        drChamcong["Ngay01"] = sdrExcel[0]["Ngay01"];
                        drChamcong["Ngay02"] = sdrExcel[0]["Ngay02"];
                        drChamcong["Ngay03"] = sdrExcel[0]["Ngay03"];
                        drChamcong["Ngay04"] = sdrExcel[0]["Ngay04"];
                        drChamcong["Ngay05"] = sdrExcel[0]["Ngay05"];
                        drChamcong["Ngay06"] = sdrExcel[0]["Ngay06"];
                        drChamcong["Ngay07"] = sdrExcel[0]["Ngay07"];
                        drChamcong["Ngay08"] = sdrExcel[0]["Ngay08"];
                        drChamcong["Ngay09"] = sdrExcel[0]["Ngay09"];
                        drChamcong["Ngay10"] = sdrExcel[0]["Ngay10"];
                        drChamcong["Ngay11"] = sdrExcel[0]["Ngay11"];
                        drChamcong["Ngay12"] = sdrExcel[0]["Ngay12"];
                        drChamcong["Ngay13"] = sdrExcel[0]["Ngay13"];
                        drChamcong["Ngay14"] = sdrExcel[0]["Ngay14"];
                        drChamcong["Ngay15"] = sdrExcel[0]["Ngay15"];
                        drChamcong["Ngay16"] = sdrExcel[0]["Ngay16"];
                        drChamcong["Ngay17"] = sdrExcel[0]["Ngay17"];
                        drChamcong["Ngay18"] = sdrExcel[0]["Ngay18"];
                        drChamcong["Ngay19"] = sdrExcel[0]["Ngay19"];
                        drChamcong["Ngay20"] = sdrExcel[0]["Ngay20"];
                        drChamcong["Ngay21"] = sdrExcel[0]["Ngay21"];
                        drChamcong["Ngay22"] = sdrExcel[0]["Ngay22"];
                        drChamcong["Ngay23"] = sdrExcel[0]["Ngay23"];
                        drChamcong["Ngay24"] = sdrExcel[0]["Ngay24"];
                        drChamcong["Ngay25"] = sdrExcel[0]["Ngay25"];
                        drChamcong["Ngay26"] = sdrExcel[0]["Ngay26"];
                        drChamcong["Ngay27"] = sdrExcel[0]["Ngay27"];
                        drChamcong["Ngay28"] = sdrExcel[0]["Ngay28"];
                        drChamcong["Ngay29"] = sdrExcel[0]["Ngay29"];
                        drChamcong["Ngay30"] = sdrExcel[0]["Ngay30"];
                        drChamcong["Ngay31"] = sdrExcel[0]["Ngay31"];

                        drChamcong["Hs_Trachnhiem"] = sdrExcel[0]["Hs_Trachnhiem"];
                        drChamcong["Hs_Chuyencan"] = sdrExcel[0]["Hs_Chuyencan"];

                        rec_update++;
                        if (split_update
                            && (rec_update % 10 == 0 || rec_update >= dsExcel.Tables[0].Rows.Count)
                            )
                        {
                            objRexService.Update_Rex_Chamcong_Thang_Collection(dsChamcong.GetChanges());
                            dsChamcong.AcceptChanges();
                        }
                    }
                }

                WaitDialogForm.Close();
            }
        }

    }
}

