using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using OfficeOpenXml;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Botri_Nhansu_Stt : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet dsSearch_Nhansu = new DataSet();
        DataSet dsBotriNhansuStt = new DataSet();
        DataSet dsHesochuongtrinh_Company = new DataSet();

        public string XlsTemplate = @"\Resources\xls\rex_chamcong_thang.xlsx";
        public string LastXlsPath = "";

        public Frmrex_Botri_Nhansu_Stt()
        {
            InitializeComponent();

            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();
        }

        void DisplayBotriNhansuStt(object Id_Bophan, object Nam, object Thang)
        {
            dsBotriNhansuStt = objRexService.GetAll_Rex_Botri_Nhansu_Stt(Id_Bophan, Nam, Thang).ToDataSet();
            dgRex_Botri_Nhansu.DataSource = dsBotriNhansuStt;
            dgRex_Botri_Nhansu.DataMember = dsBotriNhansuStt.Tables[0].TableName;

            gvRex_Botri_Nhansu.BestFitColumns();
        }

        #region override
        public override void DisplayInfo()
        {
            dsHesochuongtrinh_Company = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Company").ToDataSet();

            DataSet ds_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
            gridLookUpEdit_Bophan.DataSource = ds_Bophan.Tables[0];
            lookUpEdit_Bophan.Properties.DataSource = ds_Bophan.Tables[0];
            lookUpEdit_Ma_Bophan.Properties.DataSource = ds_Bophan.Tables[0];

            DataSet ds_Chucvu = objMasterService.Get_All_Rex_Dm_Chucvu_Collection().ToDataSet();
            gridLookUpEdit_Chucvu.DataSource = ds_Chucvu.Tables[0];

            DataSet dsAll_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            gridLookUpEdit_Ma_Nhansu.DataSource = dsAll_Nhansu.Tables[0];
            gridLookUpEdit_Hoten_Nhansu.DataSource = dsAll_Nhansu.Tables[0];

            DisplayBotriNhansuStt(lookUpEdit_Bophan.EditValue, dtThangNam.DateTime.Year, dtThangNam.DateTime.Month);

            ChangeStatus(false);

            base.DisplayInfo();
        }

        public override void ChangeStatus(bool editTable)
        {
            dtThangNam.Properties.ReadOnly = editTable;
            lookUpEdit_Ma_Bophan.Properties.ReadOnly = editTable;
            lookUpEdit_Bophan.Properties.ReadOnly = editTable;
            gvRex_Botri_Nhansu.OptionsBehavior.Editable = editTable;
            btnStt_Add.Enabled = editTable;
            btnStt_Delete.Enabled = editTable;
            btnStt_Up.Enabled = editTable;
            btnStt_Down.Enabled = editTable;
            btnStt_Reset.Enabled = editTable;
            base.ChangeStatus(editTable);
        }

        public override bool PerformEdit()
        {
            ChangeStatus(true);
            return base.PerformEdit();
        }

        public override bool PerformCancel()
        {
            DisplayInfo();
            
            return base.PerformCancel();
        }

        public override bool PerformSave()
        {
            this.DoClickEndEdit(dgRex_Botri_Nhansu);

            //case nhan su con thoi han bo tri -> chi xep lai stt
            if (dsBotriNhansuStt.GetChanges(DataRowState.Modified) != null)
            {
                foreach (DataRow dr in dsBotriNhansuStt.Tables[0].Rows)
                {
                    if (Convert.ToBoolean(dr["Pb_New_Stt"]))
                    {
                        dr.AcceptChanges();
                        dr.SetAdded();
                    }
                }
            }
            objRexService.Update_Rex_Botri_Nhansu_Stt_Collection(dsBotriNhansuStt);

            DisplayInfo();
            return base.PerformSave();
        }
        #endregion

        #region Nhansu Search
        private void txtMa_Nhansu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nhansu_Search();
            }
        }

        private void btnNhansu_Search_Click(object sender, EventArgs e)
        {
            Nhansu_Search();
        }

        void Nhansu_Search()
        {
            Ecm.WebReferences.RexService.Rex_Nhansu nhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();
            nhansu.Ma_Nhansu = txtMa_Nhansu.EditValue;
            nhansu.Ho_Nhansu = txtHo_Nhansu.EditValue;
            nhansu.Ten_Nhansu = txtTen_Nhansu.EditValue;
            nhansu.Tenkhac = txtTen_Khac.EditValue;
            nhansu.Cmnd = txtCMND.EditValue;
            nhansu.Hochieu = txtHochieu.EditValue;
            nhansu.Diachi_Thuongtru = txtDiachi_Thuongtru.EditValue;
            nhansu.Diachi_Tamtru = txtDiachi_Tamtru.EditValue;
            nhansu.Dienthoai = txtDienthoai_Didong.EditValue;
            nhansu.Dienthoai_Nharieng = txtDienthoai_Nha.EditValue;
            nhansu.Fax = txtFax.EditValue;
            nhansu.Email = txtEmail.EditValue;

            dsSearch_Nhansu = objRexService.Get_Search_Rex_Nhansu(nhansu).ToDataSet();
            dgSearch_Nhansu.DataSource = dsSearch_Nhansu;
            dgSearch_Nhansu.DataMember = dsSearch_Nhansu.Tables[0].TableName;
        }
        #endregion

        private void lookUpEdit_Ma_Bophan_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_Bophan.EditValue = lookUpEdit_Ma_Bophan.EditValue;
            DisplayBotriNhansuStt(lookUpEdit_Bophan.EditValue, dtThangNam.DateTime.Year, dtThangNam.DateTime.Month);
        }

        private void lookUpEdit_Bophan_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_Ma_Bophan.EditValue = lookUpEdit_Bophan.EditValue;
            DisplayBotriNhansuStt(lookUpEdit_Bophan.EditValue, dtThangNam.DateTime.Year, dtThangNam.DateTime.Month);

        }

        private void dtThangNam_EditValueChanged(object sender, EventArgs e)
        {
            DisplayBotriNhansuStt(lookUpEdit_Bophan.EditValue, dtThangNam.DateTime.Year, dtThangNam.DateTime.Month);
        }

        #region btnStt
        private void btnStt_Add_Click(object sender, EventArgs e)
        {
            DataRowView drvSearch_Nhansu = (DataRowView) gvSearch_Nhansu.GetFocusedRow();
            if (drvSearch_Nhansu != null )
            {
                if (dsBotriNhansuStt.Tables[0].Select(string.Format("Id_Nhansu={0}", drvSearch_Nhansu["Id_Nhansu"])).Length>0)
                    return;
                DataRow ndrBotriNhansuStt = dsBotriNhansuStt.Tables[0].NewRow();
                ndrBotriNhansuStt["Stt"] = Convert.ToInt32("0"+ dsBotriNhansuStt.Tables[0].Compute("Max(Stt)",""))+1;
                ndrBotriNhansuStt["Thang"] = dtThangNam.DateTime.Month;
                ndrBotriNhansuStt["Nam"] = dtThangNam.DateTime.Year;
                ndrBotriNhansuStt["Id_Botri_Nhansu"] = -1;
                ndrBotriNhansuStt["Id_Nhansu"] = drvSearch_Nhansu["Id_Nhansu"];
                ndrBotriNhansuStt["Id_Bophan"] = lookUpEdit_Bophan.EditValue;
                ndrBotriNhansuStt["Id_Quyetdinh"] = -1;
                ndrBotriNhansuStt["Ngay_Batdau"] = new DateTime(dtThangNam.DateTime.Year, dtThangNam.DateTime.Month, 1);
                dsBotriNhansuStt.Tables[0].Rows.Add(ndrBotriNhansuStt);
            }
        }

        private void btnStt_Delete_Click(object sender, EventArgs e)
        {
            DataRowView drvBotriNhansuStt = (DataRowView)gvRex_Botri_Nhansu.GetFocusedRow();
            drvBotriNhansuStt.Delete();
        }
  
        private void btnStt_Up_Click(object sender, EventArgs e)
        {
            DataRowView drvBotriNhansuStt = (DataRowView)gvRex_Botri_Nhansu.GetFocusedRow();
            if (Convert.ToInt32("0" + drvBotriNhansuStt["Stt"]) > 1)
            {
                DataRow []sdr = dsBotriNhansuStt.Tables[0].Select(string.Format("Stt = {0}-1", drvBotriNhansuStt["Stt"]));
                if (sdr.Length > 0)
                    sdr[0]["Stt"] = Convert.ToInt32("0" + drvBotriNhansuStt["Stt"]);
                drvBotriNhansuStt["Stt"] = Convert.ToInt32("0" + drvBotriNhansuStt["Stt"]) - 1;
            }

            gvRex_Botri_Nhansu.SortInfo.Add(new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gvRex_Botri_Nhansu.Columns["Stt"], DevExpress.Data.ColumnSortOrder.Ascending));
            gvRex_Botri_Nhansu.RefreshData();
        }

        private void btnStt_Down_Click(object sender, EventArgs e)
        {
            DataRowView drvBotriNhansuStt = (DataRowView)gvRex_Botri_Nhansu.GetFocusedRow();
            if (Convert.ToInt32("0" + drvBotriNhansuStt["Stt"]) < Convert.ToInt32("0" + dsBotriNhansuStt.Tables[0].Compute("Max(Stt)", "")))
            {
                DataRow[] sdr = dsBotriNhansuStt.Tables[0].Select(string.Format("Stt = {0}+1", drvBotriNhansuStt["Stt"]));
                if (sdr.Length > 0)
                    sdr[0]["Stt"] = Convert.ToInt32("0" + drvBotriNhansuStt["Stt"]);
                drvBotriNhansuStt["Stt"] = Convert.ToInt32("0" + drvBotriNhansuStt["Stt"]) + 1;
            }

            gvRex_Botri_Nhansu.SortInfo.Add(new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gvRex_Botri_Nhansu.Columns["Stt"], DevExpress.Data.ColumnSortOrder.Ascending));
            gvRex_Botri_Nhansu.RefreshData();
        }

        private void btnStt_Reset_Click(object sender, EventArgs e)
        {
            DateTime prev_month = dtThangNam.DateTime.AddMonths(-1);
            DataSet dsBotriNhansuStt_Prev = objRexService.GetAll_Rex_Botri_Nhansu_Stt(lookUpEdit_Bophan.EditValue, prev_month.Year, prev_month.Month).ToDataSet();
            //neu ton tai bang xep stt thang truoc
            if (dsBotriNhansuStt_Prev != null && dsBotriNhansuStt_Prev.Tables.Count > 0)
            {
                foreach (DataRow drBotriNhansuStt in dsBotriNhansuStt.Tables[0].Rows)
                {
                    DataRow[] sdr = dsBotriNhansuStt_Prev.Tables[0].Select(string.Format("Id_Nhansu={0}", drBotriNhansuStt["Id_Nhansu"]));
                    if (sdr.Length > 0)
                        drBotriNhansuStt["Stt"] = sdr[0]["Stt"];
                }
            }
            else
            {
                int stt=1;
                foreach (DataRow drBotriNhansuStt in dsBotriNhansuStt_Prev.Tables[0].Rows)
                {
                    drBotriNhansuStt["Stt"] = stt++;
                }
            }

            gvRex_Botri_Nhansu.SortInfo.Add(new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gvRex_Botri_Nhansu.Columns["Stt"], DevExpress.Data.ColumnSortOrder.Ascending));
            gvRex_Botri_Nhansu.RefreshData();
        }
        #endregion

        /// <summary>
        /// export excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Exp_Click(object sender, EventArgs e)
        {
            if (gvRex_Botri_Nhansu.RowCount > 0)
            {
                    SaveFileDialog ofd = new SaveFileDialog();
                    ofd.Filter = "Excel Files|*.xls|Excel 2007 Files|*.xlsx";
                    ofd.FileName = "rex_chamcong_thang_"
                        + dtThangNam.DateTime.Year.ToString() + "_"
                        + dtThangNam.DateTime.Month.ToString() + "_"
                        + "_" + lookUpEdit_Ma_Bophan.Text;
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LastXlsPath = ofd.FileName;
                        (new System.Threading.Thread(
                               new System.Threading.ThreadStart(ExcelExp)
                               )).Start();
                    }
            }

           
        }

        void ExcelExp()
        {
            try
            {
                if (gvRex_Botri_Nhansu.RowCount > 0)
                {
                    FileInfo newFile = new FileInfo(LastXlsPath);
                    FileInfo template = new FileInfo(Application.StartupPath + XlsTemplate);

                    ExcelPackage pck = new ExcelPackage(template);
                    //Add the Content sheet
                    //var ws = pck.Workbook.Worksheets.Add(""+lookUpEdit_Bophan.GetColumnValue("Ma_Bophan"));
                    var ws = pck.Workbook.Worksheets["Sheet1"];
                    ws.Name = "" + lookUpEdit_Bophan.EditValue;
                    ws.View.ShowGridLines = true;

                    #region CompanyName info
                    ws.Cells[2, 3].Value = "" + dsHesochuongtrinh_Company.Tables[0].Select("ma_heso_chuongtrinh='CompanyName'")[0]["Heso"];

                    try
                    {
                        object logo = dsHesochuongtrinh_Company.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyLogo'")[0]["Heso"];
                        if ("" + logo != "")
                        {
                            byte[] imagedata = Convert.FromBase64String("" + logo);

                            //Read image data into a memory stream
                            MemoryStream ms = new MemoryStream(imagedata, 0, imagedata.Length);

                            ms.Write(imagedata, 0, imagedata.Length);

                            //Set image variable value using memory stream.
                            Image image = Image.FromStream(ms, true);

                            OfficeOpenXml.Drawing.ExcelPicture logoPic = null;
                            logoPic = ws.Drawings.AddPicture("Logo", image);
                            logoPic.From.Column = 0;
                            logoPic.From.Row = 0;
                            logoPic.SetSize(100, 100);
                        }

                    }
                    catch { }
                    #endregion

                    var range = ws.Cells[1, 1, 1, 100];
                    var enumvalues = range.GetEnumerator();

                    int col = 1;
                    int row = 9;
                    int i = 1;
                    int end_index = 0;
                    DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ trong vài giât...", "Đang thực hiện");
                    foreach (System.Data.DataRow r in dsBotriNhansuStt.Tables[0].Rows)
                    {
                        col = 1;
                        enumvalues.Reset();
                        int i_header = 1;
                        while (enumvalues.MoveNext())
                        {
                            try
                            {
                                if ("" + enumvalues.Current.Value != "~!>")
                                    ws.Cells[row + i, i_header].Value = "" + r["" + enumvalues.Current.Value];
                                else
                                    end_index = (end_index == 0) ? i_header : end_index;
                            }
                            catch (Exception ex) { }

                            i_header++;
                        }

                        i++;
                    }

                    var erow = ws.Row(1);
                    erow.Hidden = true;

                    var border = ws.Cells[row, 1, row + i, end_index].Style.Border;
                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    WaitDialogForm.Close();
                    //ws.Cells[string.Format("A{0}:D{1}",new object[]{1, irow-1})].Style.Border.Le

                    pck.SaveAs(newFile);
                    //open file
                    System.Diagnostics.Process.Start(LastXlsPath);
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }
    }
}