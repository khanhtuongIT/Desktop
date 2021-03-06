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
    public partial class Frmrex_Chamcong_Tangca : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {

        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.RexService.Rex_Chamcong_Tangca rex_Chamcong_Tangca;
        DataSet dsChamcong = new DataSet();
        public long id_bophan;

        public Frmrex_Chamcong_Tangca()
        {
            InitializeComponent();
            DisplayInfo();
            item_Edit.Enabled = false;
            item_Refresh.Enabled = false;
            item_PrintPreview.Enabled = false;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Query.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
         
            dtThangnam.EditValue = DateTime.Now;
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            // hide tap thang
            txtNam_Kyluong.Text = DateTime.Now.Year.ToString();
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
        }

        #region override events

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
                    rex_Chamcong_Tangca = new Ecm.WebReferences.RexService.Rex_Chamcong_Tangca();
                    rex_Chamcong_Tangca.Id_Bophan = id_bophan;
                    rex_Chamcong_Tangca.Thang_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Month);
                    rex_Chamcong_Tangca.Nam_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Year);
                    dsChamcong = objRexService.Get_All_Rex_Chamcong_Tangca_Collection(rex_Chamcong_Tangca).ToDataSet();
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

                    dgrex_Chamcong_Tangca.DataSource = dsChamcong;
                    dgrex_Chamcong_Tangca.DataMember = dsChamcong.Tables[0].TableName;

                    this.Data = dsChamcong;
                    this.GridControl = dgrex_Chamcong_Tangca;
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
                        DateTime date = new DateTime(Convert.ToInt32(rex_Chamcong_Tangca.Nam_Kyluong),
                            Convert.ToInt32(rex_Chamcong_Tangca.Thang_Kyluong), day);
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
                this.DoClickEndEdit(dgrex_Chamcong_Tangca);
                objRexService.Update_Rex_Chamcong_Tangca_Collection(dsChamcong);
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

            rex_Chamcong_Tangca = new Ecm.WebReferences.RexService.Rex_Chamcong_Tangca();
            rex_Chamcong_Tangca.Id_Bophan = id_bophan;
            rex_Chamcong_Tangca.Thang_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Month);
            rex_Chamcong_Tangca.Nam_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Year);
            dsChamcong = objRexService.Get_All_Rex_Chamcong_Tangca_Collection(rex_Chamcong_Tangca).ToDataSet();

            // add columns 
            dsChamcong.Tables[0].Columns.Add("id_chamcong_thang", typeof(string));
            dsChamcong.Tables[0].Columns.Add("giocong", typeof(string));
            int i = 0;
            foreach (DataRow dr in dsChamcong.Tables[0].Rows)
            {
                dr["id_chamcong_thang"] = (i + 1).ToString();
                dr["giocong"] = "0";
                
                for(int j = 1; j < 32;j++)
                {
                    dr["giocong"] = int.Parse(dr["giocong"].ToString()) + int.Parse(string.IsNullOrEmpty(dr["Ngay" + j.ToString("00")].ToString()) 
                                                                                            ? "0" 
                                                                                            : dr["Ngay" + j.ToString("00")].ToString());
                }
                i++;
                
            }

            //khoi tao report cham tang ca
            Reports.rptRex_Chamcong_Thang objrptChamcong_Tangca = new Ecm.Rex.Reports.rptRex_Chamcong_Thang();
                       
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = objrptChamcong_Tangca;
            objrptChamcong_Tangca.DataSource = dsChamcong;
            dsChamcong.AcceptChanges();
            
            //objrptChamcong_Tangca.xrTable_Ngay.Text = DateTime.Now.Day.ToString();
            //objrptChamcong_Tangca.xrTable_Thang.Text = DateTime.Now.Month.ToString();
            //objrptChamcong_Tangca.xrTable_Nam.Text = DateTime.Now.Year.ToString();
            //objrptChamcong_Tangca.xrLbl_ReportName.Text = @"BẢNG CHẤM CÔNG TĂNG CA";

            ReportHelper.SetCompanyInfoAtHeader(objrptChamcong_Tangca);

            objrptChamcong_Tangca.CreateDocument();

            frmPrintPreview.printControl1.PrintingSystem = objrptChamcong_Tangca.PrintingSystem;
            frmPrintPreview.MdiParent = this.MdiParent;
            frmPrintPreview.Text = this.Text + @"(Xem trang in)";
            frmPrintPreview.Show();
            return base.PerformPrintPreview();
        }

        public override bool PerformEdit()
        {
            gridView1.OptionsBehavior.Editable = true;
            //DataSet dsNhansu = objRexService.Get_Rex_Nhansu_ByBoPhan_Collection(id_bophan);
            int day_in_month = System.DateTime.DaysInMonth(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month);
            DateTime ngay_BD = new DateTime(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, day_in_month);
            DateTime ngay_KT = new DateTime(dtThangnam.DateTime.Year, dtThangnam.DateTime.Month, 1);

            DataSet dsNhansu = objRexService.Get_Rex_NhansuChamcomg_ByBoPhan(id_bophan, dtThangnam.DateTime.Year,
                                                                             dtThangnam.DateTime.Month, ngay_BD, ngay_KT).ToDataSet();
            rex_Chamcong_Tangca = new Ecm.WebReferences.RexService.Rex_Chamcong_Tangca();
            rex_Chamcong_Tangca.Id_Bophan = id_bophan;
            rex_Chamcong_Tangca.Thang_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Month);
            rex_Chamcong_Tangca.Nam_Kyluong = Convert.ToInt64(dtThangnam.DateTime.Year);
            dsChamcong = objRexService.Get_All_Rex_Chamcong_Tangca_Collection(rex_Chamcong_Tangca).ToDataSet();
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
                        dtr["Thang_Kyluong"] = rex_Chamcong_Tangca.Thang_Kyluong;
                        dtr["Nam_Kyluong"] = rex_Chamcong_Tangca.Nam_Kyluong;
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
                                    dsNhansu.Tables[0].Rows[i]["Id_Nhansu"].Equals(
                                        dsChamcong.Tables[0].Rows[j]["Id_Nhansu"]))
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
                                dtr["Thang_Kyluong"] = rex_Chamcong_Tangca.Thang_Kyluong;
                                dtr["Nam_Kyluong"] = rex_Chamcong_Tangca.Nam_Kyluong;
                                dsChamcong.Tables[0].Rows.Add(dtr);
                                kiemtra = true;
                            }
                        }
                     }
                }
            }

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
            dgrex_Chamcong_Tangca.DataSource = dsChamcong;
            dgrex_Chamcong_Tangca.DataMember = dsChamcong.Tables[0].TableName;
            treeList_Bophan.Enabled = false;
            return base.PerformEdit();
        }
        
        #endregion

        #region Event Handling

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

        private void xtraTabControl1_SelectedPageChanged_1(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
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

        private void dtThangnam_EditValueChanged(object sender, EventArgs e)
        {
            this.DisplayInfo2();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            ShowToolbar(false);
        }

        private void ShowToolbar(bool show)
        {
            item_Edit.Enabled = show;
            item_Refresh.Enabled = show;
            item_PrintPreview.Enabled = show;
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
        }

        private void gridButton_Ngay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString() != "" && Convert.ToInt32(e.NewValue) > 24)
                e.Cancel = true;
        }
   
        #endregion

    }
}

