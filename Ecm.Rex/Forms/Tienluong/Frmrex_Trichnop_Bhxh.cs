using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Trichnop_Bhxh : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService masterTables = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.RexService objRex = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.RexService.Rex_Trichnop_Bhxh rex_Trichnop_Bhxh = new WebReferences.RexService.Rex_Trichnop_Bhxh();
        DataSet dsTrichnop_Bhxh = new DataSet();
        public long id_bophan;
        GoobizFrame.Windows.Forms.FormReport objFormReport;

        public Frmrex_Trichnop_Bhxh()
        {
            InitializeComponent();

            //reset lookup edit as delete value
            lookUpEdit_Kyluong.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);

            DisplayInfo();
        }
        public override void DisplayInfo()
        {
            try
            {
                //TreeList - Rex_Dm_Bophan
                treeListColumn1.TreeList.DataSource = masterTables.Get_All_Rex_Dm_Bophan_Collection().ToDataSet().Tables[0];

                //lookUpEdit_Kyluong - Rex_Dm_Kyluong
                lookUpEdit_Kyluong.Properties.DataSource = objRex.Get_All_Rex_Kyluong_Collection().ToDataSet().Tables[0];

                this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
            }
        }

        public void DisplayInfo2()
        {
            try
            {
                if ("" + lookUpEdit_Kyluong.GetColumnValue("Thang_Kyluong") != "")
                {
                    dsTrichnop_Bhxh.Clear();
                    rex_Trichnop_Bhxh = new Ecm.WebReferences.RexService.Rex_Trichnop_Bhxh();
                    rex_Trichnop_Bhxh.Id_Bophan = id_bophan;
                    rex_Trichnop_Bhxh.Thang_Kyluong = Convert.ToInt64("" + lookUpEdit_Kyluong.GetColumnValue("Thang_Kyluong"));
                    rex_Trichnop_Bhxh.Nam_Kyluong   = Convert.ToInt64("" + lookUpEdit_Kyluong.GetColumnValue("Nam_Kyluong"));
                    dsTrichnop_Bhxh = objRex.Get_Rex_Trichnop_Bhxh_Collection_By_Kyluong(rex_Trichnop_Bhxh).ToDataSet();
                    dgrex_Trichnop_Bhxh.DataSource = dsTrichnop_Bhxh;
                    dgrex_Trichnop_Bhxh.DataMember = dsTrichnop_Bhxh.Tables[0].TableName;

                    this.Data = dsTrichnop_Bhxh;
                    this.GridControl = dgrex_Trichnop_Bhxh;

                    //bind data to control
                    txtId_Trichnop_Bhxh.DataBindings.Clear();
                    txtMa_Nhansu.DataBindings.Clear();
                    txtHo_Nhansu.DataBindings.Clear();
                    txtTen_Nhansu.DataBindings.Clear();
                    txtTienluong_Tiencong.DataBindings.Clear();
                    txtPccv.DataBindings.Clear();
                    txtPctnvk.DataBindings.Clear();
                    txtPctnnn.DataBindings.Clear();
                    txtPckv.DataBindings.Clear();
                    txtBhxh.DataBindings.Clear();
                    txtBhyt.DataBindings.Clear();
                    txtGhichu.DataBindings.Clear();

                    //add databindings
                    if (dsTrichnop_Bhxh.Tables[0].Rows.Count > 0)
                    {
                        txtId_Trichnop_Bhxh.DataBindings.Add("Text", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Id_Trichnop_Bhxh");
                        txtMa_Nhansu.DataBindings.Add("Text", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Ma_Nhansu");
                        txtHo_Nhansu.DataBindings.Add("Text", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Ho_Nhansu");
                        txtTen_Nhansu.DataBindings.Add("Text", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Ten_Nhansu");
                        txtTienluong_Tiencong.DataBindings.Add("EditValue", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Tienluong");
                        txtPccv.DataBindings.Add("EditValue", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Pccv");
                        txtPctnvk.DataBindings.Add("EditValue", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Pctnvk");
                        txtPctnnn.DataBindings.Add("EditValue", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Pctnnn");
                        txtPckv.DataBindings.Add("EditValue", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Pckv");
                        txtBhxh.DataBindings.Add("EditValue", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Bhxh");
                        txtBhyt.DataBindings.Add("EditValue", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Bhyt");
                        txtGhichu.DataBindings.Add("Text", dsTrichnop_Bhxh, dsTrichnop_Bhxh.Tables[0].TableName + ".Ghichu");
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
            }
        }

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

        public override bool PerformCancel()
        {
            this.DisplayInfo2();
            return true;
        }

        public override bool PerformSaveChanges()
        {
            try
            {
                //cap nhat lai Trichnop_Bhxh
                this.DoClickEndEdit(dgrex_Trichnop_Bhxh);//dgrex_Trichnop_Bhxh.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                objRex.Update_Rex_Trichnop_Bhxh_Collection(dsTrichnop_Bhxh);

                //refresh lai Trichnop_Bhxh
                rex_Trichnop_Bhxh = new Ecm.WebReferences.RexService.Rex_Trichnop_Bhxh();
                rex_Trichnop_Bhxh.Thang_Kyluong = Convert.ToInt64("" + lookUpEdit_Kyluong.GetColumnValue("Thang_Kyluong"));
                rex_Trichnop_Bhxh.Nam_Kyluong   = Convert.ToInt64("" + lookUpEdit_Kyluong.GetColumnValue("Nam_Kyluong"));
                objRex.Update_Rex_Trichnop_Bhxh_Fresh(rex_Trichnop_Bhxh);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "Trích nộp bảo hiểm xã hội");
                return false;
            }

            DisplayInfo2();
            return true;
        }

        private void lookUpEdit_Kyluong_EditValueChanged(object sender, EventArgs e)
        {
            DisplayInfo2();
        }

        public override bool PerformQuery()
        {
            if ("" + lookUpEdit_Kyluong.EditValue == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] {lblKyluong.Text });
                return false;
            }
            bool valid = true;
            try
            {
                rex_Trichnop_Bhxh = new Ecm.WebReferences.RexService.Rex_Trichnop_Bhxh();
                rex_Trichnop_Bhxh.Thang_Kyluong = lookUpEdit_Kyluong.GetColumnValue("Thang_Kyluong");
                rex_Trichnop_Bhxh.Nam_Kyluong   = lookUpEdit_Kyluong.GetColumnValue("Nam_Kyluong");
                objRex.Insert_Rex_Trichnop_Bhxh(rex_Trichnop_Bhxh);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
                valid = false;
            }
            if (valid)
                MessageBox.Show("Bảng trích nộp bhxh đã lập thành công");

            return valid;
        }
        public override bool PerformPrintPreview()
        {
            try
            {
                //khoi tao report rptLuong_Hieunang
                Reports.rptTrichnop_Bhxh objrptTrichnop_Bhxh = new Ecm.Rex.Reports.rptTrichnop_Bhxh();
                objrptTrichnop_Bhxh.xrPictureBox1.Image = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCompanyLogo();
                objrptTrichnop_Bhxh.DataSource = dsTrichnop_Bhxh;
                objrptTrichnop_Bhxh.CreateDocument();
                if (this.objFormReport == null || objFormReport.IsDisposed)
                    objFormReport = new GoobizFrame.Windows.Forms.FormReport();
                objFormReport.Report = objrptTrichnop_Bhxh;
                //su dung control report
                objFormReport.printControl1.PrintingSystem = objrptTrichnop_Bhxh.PrintingSystem;
                objFormReport.MdiParent = this.MdiParent;
                objFormReport.Text = this.Text + "(Xem trang in)";
                objFormReport.Show();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
            }
            return base.PerformPrintPreview();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.FocusedColumn = gridView1.Columns[1];
        }

        private void popupMenu1_CloseUp(object sender, EventArgs e)
        {
            this.barButton_Kyluong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        } 

        private void Frmrex_Trichnop_Bhxh_Load(object sender, EventArgs e)
        {
            lookUpEdit_Kyluong.ToolTip = GoobizFrame.Windows.Forms.UserMessage.GetTooltips("rex_dm_kyluong");
            this.barButton_Kyluong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void lookUpEdit_Kyluong_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.barButton_Kyluong.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.popupMenu1.ShowPopup(MousePosition);
            }

        }

        private void barButton_Kyluong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Frmrex_Kyluong objFrmrex_Kyluong = new Frmrex_Kyluong();

            //GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(objFrmrex_Kyluong);
            //GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(objFrmrex_Kyluong);
            //objFrmrex_Kyluong.ShowDialog();

            //if (objFrmrex_Kyluong.rex_Dm_Kyluong.Id_Kyluong + "" != "")
            //{
            //    DataSet dsKyluong = objRex.Get_All_Rex_Kyluong_Collection();
            //    lookUpEdit_Kyluong.Properties.DataSource = dsKyluong.Tables[0];
            //    for (int i = 0; i < dsKyluong.Tables[0].Rows.Count; i++)
            //    {
            //        if (dsKyluong.Tables[0].Rows[i]["Id_Kyluong"] + "" == objFrmrex_Kyluong.rex_Dm_Kyluong.Id_Kyluong + "")
            //        {
            //            lookUpEdit_Kyluong.ItemIndex = i;
            //            break;
            //        }
            //    }
            //}
        }

      
    }
}

