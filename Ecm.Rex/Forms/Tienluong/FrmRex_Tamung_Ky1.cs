using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Rex.Forms.Tienluong
{
    public partial class FrmRex_Tamung_Ky1 : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.RexService objRex = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet dsTamung_Ky1;

        public long id_bophan;
        DevExpress.XtraTreeList.Nodes.TreeListNode focusedNode;

        public FrmRex_Tamung_Ky1()
        {
            InitializeComponent();

            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();

        }

        void DisplayInfo2()
        {
            try
            {
                dsTamung_Ky1 = objRex.Rex_Tamung_Ky1_SelectByBophan(dtThangNam.DateTime.Year, dtThangNam.DateTime.Month, id_bophan, false).ToDataSet();

                dgrex_Tamung_Ky1.DataSource = dsTamung_Ky1.Tables[0];

                gvrex_Tamung_Ky1.BestFitColumns();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        public override bool PerformPrintPreview()
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ vài giây...", "Đang thực hiện");
            Datasets.DsRex_Tamung_Ky1 dsRex_Tamung_Ky1 = new Datasets.DsRex_Tamung_Ky1();
            Reports.RptRex_Tamung_Ky1 XtraReport = new Ecm.Rex.Reports.RptRex_Tamung_Ky1();
           

            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = XtraReport;
            XtraReport.DataSource = dsTamung_Ky1;

            ReportHelper.SetCompanyInfoAtHeader(XtraReport);
            XtraReport.FindControl("xrc_Ngay_Ketthuc", true).Text = string.Format("{0:MM/yyyy}", dtThangNam.DateTime);

            XtraReport.CreateDocument();
            frmPrintPreview.printControl1.PrintingSystem = XtraReport.PrintingSystem;
            frmPrintPreview.Text = this.Text + " - Xem trang in";
            frmPrintPreview.MdiParent = this.MdiParent;
            frmPrintPreview.Show();
            frmPrintPreview.Activate();

            WaitDialogForm.Close();
            return base.PerformPrintPreview();
        }

        #region override

        public override void DisplayInfo()
        {
            try
            {
                //TreeList - Rex_Dm_Bophan
                treeListColumn1.TreeList.DataSource = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet().Tables[0];

                ChangeStatus(false);

                if (focusedNode != null)
                    treeListColumn1.TreeList.FocusedNode = focusedNode;

            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
            base.DisplayInfo();
        }

        public override bool PerformEdit()
        {
            foreach (DataRow drTamung_Ky1 in dsTamung_Ky1.Tables[0].Rows)
            {
                if (Convert.ToBoolean(drTamung_Ky1["Pb_Btri_Nsu_New"]))
                    drTamung_Ky1.SetAdded();
            }

            ChangeStatus(true);
            return base.PerformEdit();
        }

        public override bool PerformCancel()
        {
            DisplayInfo2();
            ChangeStatus(false);
            return base.PerformCancel();
        }

        public override bool PerformSave()
        {
            try
            {
                this.DoClickEndEdit(dgrex_Tamung_Ky1);
                objRex.Update_Rex_Tamung_Ky1_Collection(dsTamung_Ky1);
                DisplayInfo2();
                ChangeStatus(false);

                //tinh luong
                new System.Threading.Thread(new System.Threading.ThreadStart(this.Rex_Luong_Tonghop_Init)).Start();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
            return base.PerformSave();
        }

        void Rex_Luong_Tonghop_Init()
        {
            try
            {
                objRex.Rex_Luong_Tonghop_Init_ByBophan(dtThangNam.DateTime.Year, dtThangNam.DateTime.Month, id_bophan);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            txtSotien.Properties.ReadOnly = !editTable;
            gvrex_Tamung_Ky1.OptionsBehavior.Editable = editTable;
            btnSotien_FillAll.Enabled = editTable;
            treeListColumn1.TreeList.Enabled = !editTable;

            base.ChangeStatus(editTable);
        }
        #endregion

        private void treeList_Bophan_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            try
            {
                focusedNode = e.Node;
                id_bophan = Convert.ToInt64("" + e.Node.GetValue("Id_Bophan"));
                this.DisplayInfo2();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        private void btnSotien_FillAll_Click(object sender, EventArgs e)
        {
            if ("" + txtSotien.EditValue == "") return;
            try
            {
                foreach (DataRow dr in dsTamung_Ky1.Tables[0].Rows)
                {
                    if ("" + dr["Pb_Khong_Tamung"] == "" || !Convert.ToBoolean(dr["Pb_Khong_Tamung"]))
                        dr["Sotien"] = txtSotien.EditValue;
                    else
                        dr["Sotien"] = 0;
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        private void dtThangNam_EditValueChanged(object sender, EventArgs e)
        {
            DisplayInfo2();
        }

        private void gvrex_Tamung_Ky1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridTextEdit.ReadOnly = Convert.ToBoolean(gvrex_Tamung_Ky1.GetFocusedRowCellValue("Pb_Khong_Tamung"));
        }

       


    }
}