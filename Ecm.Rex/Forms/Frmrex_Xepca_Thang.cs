using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Xepca_Thang : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //Ecm.WebReferences.RexService.Rex_Xepca_Thang rex_Xepca_Thang;
        DataSet dsChamcong = new DataSet();
      
        public Frmrex_Xepca_Thang()
        {
            InitializeComponent();
            //ShowToolbar(false);
            this.item_Edit.Enabled = false;
            this.item_Refresh.Enabled = false;
            this.item_PrintPreview.Enabled = false;
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            dtThangnam.EditValue = DateTime.Now;
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            // hide tap thang
            txtNam_Kyluong.Text = DateTime.Now.Year.ToString();
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
        }

        public override void DisplayInfo()
        {
            try
            {
                GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
                //TreeList - Rex_Dm_Bophan
                DataSet dsDm_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
                treeListColumn1.TreeList.DataSource = dsDm_Bophan.Tables[0];
           
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
                    //rex_Xepca_Thang = new Ecm.WebReferences.RexService.Rex_Xepca_Thang();                    
                    //rex_Xepca_Thang.Thang_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Month);
                    //rex_Xepca_Thang.Nam_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Year);
                    dsChamcong = objRexService.Get_All_Rex_Xepca_Thang_Collection(id_bophan, dtThangnam.DateTime.Year, dtThangnam.DateTime.Month).ToDataSet();
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
                    dgrex_Xepca_Thang.DataSource = dsChamcong;
                    dgrex_Xepca_Thang.DataMember = dsChamcong.Tables[0].TableName;

                    this.Data = dsChamcong;
                    this.GridControl = dgrex_Xepca_Thang;
                    int day_in_month = System.DateTime.DaysInMonth(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month);
                    gridView1.OptionsBehavior.Editable = false;
                    treeList_Bophan.Enabled = true;

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
                        DateTime date = new DateTime(Convert.ToInt32(dtThangnam.DateTime.Year),
                            Convert.ToInt32(dtThangnam.DateTime.Month), day);
                        if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                        {
                            gridView1.Columns["Ngay" + day.ToString().PadLeft(2, '0')].Caption = date.DayOfWeek.ToString();
                            gridView1.Columns["Ngay" + day.ToString().PadLeft(2, '0')].AppearanceCell.BackColor = Color.Pink;
                            if (date.DayOfWeek == DayOfWeek.Sunday)
                                gridView1.Columns["Ngay" + day.ToString().PadLeft(2, '0')].Caption = "Chủ nhật";
                            else
                                gridView1.Columns["Ngay" + day.ToString().PadLeft(2, '0')].Caption = "Thứ bảy";
                        }
                        else
                        {
                            gridView1.Columns["Ngay" + day.ToString().PadLeft(2, '0')].Caption = "Ngày " + day.ToString().PadLeft(2, '0');
                            gridView1.Columns["Ngay" + day.ToString().PadLeft(2, '0')].AppearanceCell.BackColor = Color.White;
                        }
                    }
                    gridView1.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                //MessageBox.Show(ex.ToString());
#endif
            }
        }

        public long id_bophan;
    
        #region override events
        public override bool PerformCancel()
        {
            treeList_Bophan.Enabled = true;
            this.DisplayInfo2();
            return true;
        }

        public override bool PerformSave()
        {
            PerformSaveChanges();
            return base.PerformSave();
        }

        public override bool PerformSaveChanges()
        {
            try
            {
                this.DoClickEndEdit(dgrex_Xepca_Thang);//dgrex_Xepca_Thang.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                objRexService.Update_Rex_Xepca_Thang_Collection(dsChamcong);
                this.DisplayInfo2();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "Chấm công tháng");
            }
            return true;
        }


        public override bool PerformPrintPreview()
        {
            //khoi tao report cham cong
            Reports.rptRex_Xepca_Thang objrptXepca_Thang = new Ecm.Rex.Reports.rptRex_Xepca_Thang();
            GoobizFrame.Windows.Forms.FrmPrintPreview objFormReport = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            objFormReport.Report = objrptXepca_Thang;
            objrptXepca_Thang.DataSource = dsChamcong;
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

                objrptXepca_Thang.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                objrptXepca_Thang.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }

            #endregion

            objrptXepca_Thang.CreateDocument();
            objFormReport.printControl1.PrintingSystem = objrptXepca_Thang.PrintingSystem;
            objFormReport.MdiParent = this.MdiParent;
            objFormReport.Text = this.Text + @"(Xem trang in)";
            objFormReport.Show();
            return base.PerformPrintPreview();
        }

        public override bool PerformEdit()
        {           
            gridView1.OptionsBehavior.Editable = true;
            int day_in_month = System.DateTime.DaysInMonth(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month);
            DateTime ngay_BD = new DateTime(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, day_in_month);
            DateTime ngay_KT = new DateTime(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, 1);
            DataSet dsNhansu = objRexService.Get_Rex_NhansuChamcomg_ByBoPhan(id_bophan, dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, ngay_BD, ngay_KT).ToDataSet();
            //rex_Xepca_Thang = new Ecm.WebReferences.RexService.Rex_Xepca_Thang();            
            //rex_Xepca_Thang.Thang_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Month);
            //rex_Xepca_Thang.Nam_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Year);
            dsChamcong = objRexService.Get_All_Rex_Xepca_Thang_Collection(id_bophan, dtThangnam.DateTime.Year, dtThangnam.DateTime.Month).ToDataSet();
            if (dsChamcong.Tables[0].Rows.Count == 0)
            {
                if (dsNhansu.Tables[0].Rows.Count > 0)
                {
                    DataRow dtr = null;
                    for (int i = 0; i < dsNhansu.Tables[0].Rows.Count; i++)
                    {
                        dtr = dsChamcong.Tables[0].NewRow();
                        dtr["Id_Nhansu"] = dsNhansu.Tables[0].Rows[i]["Id_Nhansu"];
                        dtr["Ma_Nhansu"] = dsNhansu.Tables[0].Rows[i]["Ma_Nhansu"];
                        dtr["Ho_Nhansu"] = dsNhansu.Tables[0].Rows[i]["Ho_Nhansu"];
                        dtr["Ten_Nhansu"] = dsNhansu.Tables[0].Rows[i]["Ten_Nhansu"];
                        dtr["Thang_Kyluong"] = dtThangnam.DateTime.Month;//rex_Xepca_Thang.Thang_Kyluong;
                        dtr["Nam_Kyluong"] = dtThangnam.DateTime.Year;// rex_Xepca_Thang.Nam_Kyluong;
                        dsChamcong.Tables[0].Rows.Add(dtr);
                    }
                }
            }
            else
            {               
                if (dsNhansu.Tables[0].Rows.Count > 0)
                {                    
                    for (int i = 0; i < dsNhansu.Tables[0].Rows.Count; i++)
                    { 
                        bool kiemtra = true;
                        if (dsChamcong.Tables[0].Rows.Count > 0)
                        {
                            DataRow dtr = null;
                            for (int j = 0; j < dsChamcong.Tables[0].Rows.Count; j++)
                            {
                                if (
                                    dsNhansu.Tables[0].Rows[i]["Id_Nhansu"].Equals(dsChamcong.Tables[0].Rows[j]["Id_Nhansu"]))
                                {
                                    kiemtra = false;
                                }
                            }
                            if (kiemtra)
                            {
                                dtr = dsChamcong.Tables[0].NewRow();
                                dtr["Id_Nhansu"] = dsNhansu.Tables[0].Rows[i]["Id_Nhansu"];
                                dtr["Ma_Nhansu"] = dsNhansu.Tables[0].Rows[i]["Ma_Nhansu"];
                                dtr["Ho_Nhansu"] = dsNhansu.Tables[0].Rows[i]["Ho_Nhansu"];
                                dtr["Ten_Nhansu"] = dsNhansu.Tables[0].Rows[i]["Ten_Nhansu"];
                                dtr["Thang_Kyluong"] = dtThangnam.DateTime.Month;// rex_Xepca_Thang.Thang_Kyluong;
                                dtr["Nam_Kyluong"] = dtThangnam.DateTime.Year;// rex_Xepca_Thang.Nam_Kyluong;
                                dsChamcong.Tables[0].Rows.Add(dtr);
                                kiemtra = true;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < dsChamcong.Tables[0].Rows.Count; i++ )
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
            dgrex_Xepca_Thang.DataSource = dsChamcong;
            dgrex_Xepca_Thang.DataMember = dsChamcong.Tables[0].TableName;
            treeList_Bophan.Enabled = false;
            return base.PerformEdit();
        }

        #endregion

        #region Even 

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
            this.DoClickEndEdit(dgrex_Xepca_Thang);//dgrex_Xepca_Thang.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }

        private void lookUpEdit_Kyluong_EditValueChanged(object sender, EventArgs e)
        {
            this.DisplayInfo2();
        }

        private void Frmrex_Xepca_Thang_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
            //ShowToolbar(false);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.FocusedColumn = gridView1.Columns[1];
        }

        private void dtThangnam_EditValueChanged(object sender, EventArgs e)
        {
            DisplayInfo2();
        }

        private void repositoryItemButtonEdit_Ca_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                "Ecm.MasterService.dll",
                "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Ca_Lamviec_Add", this);
            if (dialog == null)
                return;
            var SelectedObject = dialog.GetType().GetProperty("SelectedRows").GetValue(dialog, null)
                as System.Data.DataRow [];


            if (SelectedObject != null && SelectedObject.Length > 0)
            {
                string Ca_s = "";
                foreach (DataRow dr in SelectedObject)
                    Ca_s += dr["Ma_Ca_Lamviec"] + ", ";
                Ca_s = Ca_s.Remove(Ca_s.Length - 2, 2);
                gridView1.SetFocusedRowCellValue(gridView1.FocusedColumn, Ca_s);
            }
        }
        
       private void btnBack_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            ShowToolbar(false);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex.Equals(0))
            {
                ShowToolbar(false);
            }
            else
            {
                ShowToolbar(true);
            }
        }

        #endregion

        #region btnThang Click

        private void btnThang_Mot_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("01/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Hai_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("02/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Ba_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("03/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Tu_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("04/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Nam_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("05/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Sau_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("06/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Bay_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("07/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Tam_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("08/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Chin_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("09/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Muoi_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("10/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Muoimot_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("11/" + txtNam_Kyluong.Text);
        }

        private void btnThang_Muoihai_Click(object sender, EventArgs e)
        {
            SetValueTabThangnam("12/" + txtNam_Kyluong.Text);
        }
       
        private void SetValueTabThangnam(string thangnam)
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            dtThangnam.Text = thangnam;
            ShowToolbar(true);
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        #endregion

        private void ShowToolbar(bool show)
        {
            this.item_Edit.Enabled = show;
            this.item_Refresh.Enabled = show;
            this.item_PrintPreview.Enabled = show;
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
        }
     
    }
}

