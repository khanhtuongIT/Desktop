using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms.WareGen_Hdbanhang
{
    public partial class FrmwareGen_Hdbanhang :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {        
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet dsWareGen_Hdbanhang;
        DataSet ds_Hdbanhang_Chitiet;
        DataSet dsHanghoa_Selected;
        DataSet dsNhansu_Khohanghoa;
        DataSet dsNhansu_Cuahang;

        public FrmwareGen_Hdbanhang()
        {
            InitializeComponent();
            dtNgay_Batdau.EditValue = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(objWareService.GetServerDateTime().Year, objWareService.GetServerDateTime().Month, objWareService.GetServerDateTime().Day, 23, 59, 59);
            DisplayInfo();

        }

        void DisplayInfo2()
        {
            if ("" + gridView1.GetFocusedRowCellValue("Id_Hdbanhang") == "")
                return;
            this.ds_Hdbanhang_Chitiet = objWareService.Get_All_WareGen_Hdbanhang_Chitiet_By_Hdbanhang(gridView1.GetFocusedRowCellValue("Id_Hdbanhang")).ToDataSet();
            this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet;
            this.dgware_Hdbanhang_Chitiet.DataMember = ds_Hdbanhang_Chitiet.Tables[0].TableName;
            gridView4.BestFitColumns();
        }

        #region override
        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
            objWare_Hdbanhang.Id_Hdbanhang = gridView1.GetFocusedRowCellValue("Id_Hdbanhang");

            return objWareService.Delete_WareGen_Hdbanhang(objWare_Hdbanhang);
        }

        public override void DisplayInfo()
        {
            //lookUpEditMa_Kho_Hanghoa
            DataSet dsKho_Hanghoa = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa().ToDataSet();
            lookUpEditMa_Kho_Hanghoa.Properties.DataSource = dsKho_Hanghoa.Tables[0];

            gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];

            base.DisplayInfo();
        }

        public override bool PerformDelete()
        {
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
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
                this.PerformQuery();
            }
            return base.PerformDelete();
        }

        public override bool PerformQuery()
        {
            dsWareGen_Hdbanhang = objWareService.Get_All_WareGen_Hdbanhang_2(dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue, lookUpEditMa_Kho_Hanghoa.GetColumnValue("Ma_Kho_Hanghoa")).ToDataSet();
            dsWareGen_Hdbanhang.Tables[0].Columns.Add("Chon", typeof(bool));
            dgware_Hdbanhang.DataSource = dsWareGen_Hdbanhang.Tables[0];
            gridView1.BestFitColumns();

            gridView1.Focus();
            DisplayInfo2();

            return base.PerformQuery();
        }

        public override bool PerformPrintPreview()
        {
            Print(chkPrintPreview.Checked);
            return base.PerformPrintPreview();
        }
        
        #endregion

        void Print(bool Preview)
        {
            DataRow[] sdr = dsWareGen_Hdbanhang.Tables[0].Select("Chon = true" );
            foreach (DataRow drGen_Hdbanhang in sdr)
            {
                object identity = drGen_Hdbanhang["Id_Hdbanhang"];
                //DataRow[] sdr = dsWareGen_Hdbanhang.Tables[0].Select("Id_Hdbanhang = " + identity);
                DataSet ds_Hdbanhang_Chitiet = objWareService.Get_All_WareGen_Hdbanhang_Chitiet_By_Hdbanhang(identity).ToDataSet();

                DataSets.dsHdbanhang_Chitiet dsrHdbanhang_Chitiet = new Ecm.Ware.DataSets.dsHdbanhang_Chitiet();
                Reports.rptHdbanhang_noVAT rptHdbanhang_noVAT = new Ecm.Ware.Reports.rptHdbanhang_noVAT();
                //             GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
                 GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = rptHdbanhang_noVAT;
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
                    drnew["Ten_Hanghoa"] = dr["Ten_Hanghoa"];
                    drnew["Ma_Hanghoa"] = dr["Ma_Hanghoa"];
                    drnew["Stt"] = i++;

                    dsrHdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
                }

                //add parameter values
                rptHdbanhang_noVAT.tbc_Ngay.Text = "" + string.Format("{0:dd/MM/yyyy}", drGen_Hdbanhang["Ngay_Chungtu"]);
                rptHdbanhang_noVAT.lblNhansu_Bill.Text = "";
                rptHdbanhang_noVAT.tbcSochungtu.Text = "" + drGen_Hdbanhang["Sochungtu"];
                rptHdbanhang_noVAT.lblNhansu_Bill.Text = "";
             
                double thanhtien = Convert.ToDouble("0" + drGen_Hdbanhang["Thanhtien"]);
                string str =  GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
                str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();

                rptHdbanhang_noVAT.tbcThanhtien_Bangchu.Text = str;

                rptHdbanhang_noVAT.PageSize = new Size(800, 1400 + 120 * Convert.ToInt32(dsrHdbanhang_Chitiet.Tables[0].Rows.Count));

                rptHdbanhang_noVAT.CreateDocument();

                if (!Preview)
                {
                    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptHdbanhang_noVAT);
                    reportPrintTool.Print();
                }
                else
                {
                    frmPrintPreview.printControl1.PrintingSystem = rptHdbanhang_noVAT.PrintingSystem;
                    frmPrintPreview.MdiParent = this.MdiParent;
                    frmPrintPreview.Text = this.Text + "(Xem trang in)";
                    frmPrintPreview.Show();
                    frmPrintPreview.Activate();
                }
            }
        }

        #region  Even

        private void dgware_Hdbanhang_Chitiet_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }
        /// <summary>
        /// change focus to other hdbanhang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DisplayInfo2();
        }

        /// <summary>
        /// Gen By Doanhso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenByDoanhso_Click(object sender, EventArgs e)
        {

            if ("" + lookUpEditMa_Kho_Hanghoa.EditValue == "")
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] { lblKho_Hanghoa.Text, lblKho_Hanghoa.Text });
                return;
            }

            object Ngay_Chungtu = null;

            //chon hang hoa can dua vao hoa don
            FrmwareGen_Dm_Hanghoa_Tree frmwareGen_Dm_Hanghoa_Tree = new FrmwareGen_Dm_Hanghoa_Tree();
             GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmwareGen_Dm_Hanghoa_Tree);
            frmwareGen_Dm_Hanghoa_Tree.ShowDialog();
            dsHanghoa_Selected = frmwareGen_Dm_Hanghoa_Tree.dsHanghoa_Selected;
            Ngay_Chungtu = frmwareGen_Dm_Hanghoa_Tree.Ngay_Chungtu;

            //lap ds hang hoa random: sl hang hoa, sl hoa don
            //FrmwareGen_RandomList_Hanghoa frmwareGen_RandomList_Hanghoa = new FrmwareGen_RandomList_Hanghoa(dsHanghoa_Selected);
            // GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmwareGen_RandomList_Hanghoa);
            //frmwareGen_RandomList_Hanghoa.ShowDialog();
            //dsHanghoa_Selected = frmwareGen_RandomList_Hanghoa.DsRandom_Hanghoa;

            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            //neu co hdbanhang duoc chon --> save
            //if (frmwareGen_RandomList_Hanghoa.Arr_Random_Id_Hdbanhang != null && frmwareGen_RandomList_Hanghoa.Arr_Random_Id_Hdbanhang.Count > 0)
            //{
            //    //them file Id_Hdbanhang
            //    dsHanghoa_Selected.Tables[0].Columns.Add("Id_Hdbanhang");
            //    dsHanghoa_Selected.Tables[0].Columns.Add("Id_Hdbanhang_Chitiet");

            //    for (int i = 0; i < frmwareGen_RandomList_Hanghoa.Arr_Random_Id_Hdbanhang.Count; i++)
            //    {
            //        object Random_Id_Hdbanhang = frmwareGen_RandomList_Hanghoa.Arr_Random_Id_Hdbanhang[i];
            //        object thanhtien = dsHanghoa_Selected.Tables[0].Compute("SUM(Thanhtien)", "Random_Id_Hdbanhang=" + Random_Id_Hdbanhang);
            //        decimal Sotien = Convert.ToDecimal(thanhtien) / Convert.ToDecimal(1.1);
            //        decimal Sotien_Vat = Convert.ToDecimal(0.1) * Convert.ToDecimal(thanhtien) / Convert.ToDecimal(1.1);

            //        Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();

            //        objWare_Hdbanhang.Id_Hdbanhang = -1;
            //        objWare_Hdbanhang.Gen_Fr_Hhsx = true;
            //        objWare_Hdbanhang.Hoten_Nguoimua = "";
            //        objWare_Hdbanhang.Per_Vat = 10;
            //        objWare_Hdbanhang.Phuongthuc_Thanhtoan = "TM";
            //        objWare_Hdbanhang.So_Seri = "";
            //        objWare_Hdbanhang.Sochungtu = objWareService.GetNew_Sochungtu("WareGen_Hdbanhang", "Sochungtu", lookUpEditMa_Kho_Hanghoa.GetColumnValue("DocCode")); ;
            //        objWare_Hdbanhang.Sotien = Sotien;
            //        objWare_Hdbanhang.Sotien_Vat = Sotien_Vat;
            //        objWare_Hdbanhang.Ngay_Chungtu = Ngay_Chungtu;
            //        objWare_Hdbanhang.Ngay_Thanhtoan = Ngay_Chungtu;

            //        if ("" + lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Cuahang_Ban") != "")
            //            objWare_Hdbanhang.Id_Cuahang_Ban = lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Cuahang_Ban");
            //        if ("" + lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua") != "")
            //            objWare_Hdbanhang.Id_Kho_Hanghoa_Mua = lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua");


            //          object identity = objWareService.Insert_WareGen_Hdbanhang(objWare_Hdbanhang);

            //        if (identity != null)
            //        {
            //            foreach (DataRow dr in dsHanghoa_Selected.Tables[0].Select("Random_Id_Hdbanhang = " + Random_Id_Hdbanhang))
            //            {
            //                dr["Id_Hdbanhang"] = identity;
            //                dr.AcceptChanges();
            //                dr.SetAdded();
            //            }
            //        }
            //    }

            //    //update hdmuahang_chitiet                        
            //    objWareService.Update_WareGen_Hdbanhang_Chitiet_Collection(dsHanghoa_Selected);

            //    this.PerformQuery();
            //    WaitDialogForm.Close();
            //}
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow drHdbanhang in dsWareGen_Hdbanhang.Tables[0].Rows)
                drHdbanhang["Chon"] = chkAll.EditValue;
        }

        private void btnGen_Donmuahang_Click(object sender, EventArgs e)
        {
            FrmwareGen_Donmuahang FrmwareGen_Donmuahang = new FrmwareGen_Donmuahang();
            FrmwareGen_Donmuahang.Text = btnGen_Donmuahang.Text;
             GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(FrmwareGen_Donmuahang);
            FrmwareGen_Donmuahang.ShowDialog();
        }
        #endregion

        
     
    }
}