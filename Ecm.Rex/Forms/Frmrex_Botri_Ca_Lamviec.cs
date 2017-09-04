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
    public partial class Frmrex_Botri_Ca_Lamviec : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsCollection = new DataSet();

        public Frmrex_Botri_Ca_Lamviec()
        {
            InitializeComponent();

            ////date mask
            dtNgay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Batdau.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            dtNgay_Ketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Ketthuc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            repositoryItemDateEdit_Ngay_Batdau.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit_Ngay_Batdau.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            repositoryItemDateEdit_Ngay_Ketthuc.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit_Ngay_Ketthuc.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();


            this.item_Add.Visibility    = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Ca_Lamviec
                DataSet dsWare_Dm_Ca_Lamviec = objMasterService.Get_All_Rex_Dm_Ca_Lamviec().ToDataSet();
                dgrex_Dm_Ca_Lamviec.DataSource = dsWare_Dm_Ca_Lamviec.Tables[0];

                //Get data Ware_Dm_Ca_Lamviec
                DataSet dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUpEdit_Nhansu.Properties.DataSource             = dsNhansu.Tables[0];
                gridLookUpEdit_Nhansu.DataSource         = dsNhansu.Tables[0];
                gridLookUpEdit_Nhansu_Ho.DataSource      = dsNhansu.Tables[0];
                gridLookUpEdit_Nhansu_Ten.DataSource     = dsNhansu.Tables[0];
                gridLookUpEdit_Nhansu_Hinh.DataSource    = dsNhansu.Tables[0];

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();

                this.DisplayInfo2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void ClearText()
        {
            //this.txtId_Botri_Ca_Lamviec.EditValue = "";
            this.txtHo_Nhansu.EditValue = "";
            this.txtTen_Nhansu.EditValue = "";
            this.dtNgay_Batdau.EditValue = "";
            this.dtNgay_Ketthuc.EditValue = "";
            this.lookUpEdit_Nhansu.EditValue = null;
            pictureEdit_Hinh.Image = null;
        }

        public void DisplayInfo2()
        {
            if ("" + gridView2.GetFocusedRowCellValue("Id_Ca_Lamviec") != "")
            {
                dsCollection = objRexService.Get_All_Rex_Botri_Ca_Lamviec_By_Ca(gridView2.GetFocusedRowCellValue("Id_Ca_Lamviec")).ToDataSet();
                dgrex_Botri_Ca_Lamviec.DataSource = dsCollection;
                dgrex_Botri_Ca_Lamviec.DataMember = dsCollection.Tables[0].TableName;
                this.DataBindingControl();
                if (gridView1.RowCount == 0)
                    ClearText();
            }
        }

        void ClearDataBindings()
        {
            //this.txtId_Botri_Ca_Lamviec.DataBindings.Clear();
            this.lookUpEdit_Nhansu.DataBindings.Clear();
            this.dtNgay_Batdau.DataBindings.Clear();
            this.dtNgay_Ketthuc.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                //this.txtId_Botri_Ca_Lamviec.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName +  ".Id_Botri_Ca_Lamviec");
                this.lookUpEdit_Nhansu.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName +       ".Id_Nhansu");
                this.dtNgay_Batdau.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName +           ".Ngay_Batdau");
                this.dtNgay_Ketthuc.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName +          ".Ngay_Ketthuc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            this.dgrex_Dm_Ca_Lamviec.Enabled        = !editTable;
            gridView2.OptionsBehavior.Editable = editTable;
            this.simpleButton1.Enabled              =  editTable;
            this.gridView1.OptionsBehavior.Editable = editTable;
            this.dgrex_Botri_Ca_Lamviec.EmbeddedNavigator.Buttons.Remove.Enabled = editTable;
        }

        #region Event Override
        
        public override bool PerformEdit()
        {
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                this.DoClickEdit(dgrex_Botri_Ca_Lamviec);// dgrex_Botri_Ca_Lamviec.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDateGrid(gridView1.Columns["Ngay_Batdau"], gridView1.Columns["Ngay_Ketthuc"], gridView1))
                    return false;
                foreach (DataRow dr in dsCollection.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)                  
                        dr["Id_Ca_Lamviec"] = gridView2.GetFocusedRowCellValue("Id_Ca_Lamviec");
                    
                }

                success =  (bool)objRexService.Update_Botri_Ca_Lamviec_Collection(dsCollection);

                if (success)
                {
                    this.DisplayInfo();
                    this.ChangeStatus(false);
                }

                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        #endregion

        private void gridLookUpEdit_Nhansu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Frmrex_Nhansu_Dialog frmrex_Nhansu_Dialog = new Frmrex_Nhansu_Dialog();
            //frmrex_Nhansu_Dialog.StartPosition = FormStartPosition.CenterScreen;

            //frmrex_Nhansu_Dialog.ShowDialog();

            //if (frmrex_Nhansu_Dialog.Id_Nhansu != null && frmrex_Nhansu_Dialog.Id_Nhansu.Length > 0)
            //{
            //    for (int i = 0; i < frmrex_Nhansu_Dialog.Id_Nhansu.Length; i++)
            //    {
            //        DataRow dr = dsCollection.Tables[0].NewRow();
            //        dr["Id_Nhansu"] = frmrex_Nhansu_Dialog.Id_Nhansu[i];
            //        dsCollection.Tables[0].Rows.Add(dr);
            //    }
            //    dgrex_Botri_Ca_Lamviec.DataSource = dsCollection;
            //    dgrex_Botri_Ca_Lamviec.DataMember = dsCollection.Tables[0].TableName;
            //}
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.DisplayInfo2();
            
        }
        
        private void lookUpEdit_Nhansu_EditValueChanged(object sender, EventArgs e)
        {
            this.txtHo_Nhansu.EditValue     = lookUpEdit_Nhansu.GetColumnValue("Ho_Nhansu");
            this.txtTen_Nhansu.EditValue    = lookUpEdit_Nhansu.GetColumnValue("Ten_Nhansu");

            //Get image data from gridview column.
            if ("" + lookUpEdit_Nhansu.GetColumnValue("Hinh") != "")
            {
                byte[] imagedata = (byte[])lookUpEdit_Nhansu.GetColumnValue("Hinh");

                //Read image data into a memory stream
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagedata, 0, imagedata.Length);

                ms.Write(imagedata, 0, imagedata.Length);

                //Set image variable value using memory stream.
                Image image = Image.FromStream(ms, true);

                pictureEdit_Hinh.Image = image;
            }
            else
            {
                pictureEdit_Hinh.Image = null;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Frmrex_Nhansu_Dialog frmrex_Nhansu_Dialog = new Frmrex_Nhansu_Dialog();
            frmrex_Nhansu_Dialog.StartPosition = FormStartPosition.CenterScreen;

            frmrex_Nhansu_Dialog.ShowDialog();

            if (frmrex_Nhansu_Dialog.Id_Nhansu != null && frmrex_Nhansu_Dialog.Id_Nhansu.Length > 0)
            {
                for (int i = 0; i < frmrex_Nhansu_Dialog.Id_Nhansu.Length; i++)
                {
                    DataRow dr = dsCollection.Tables[0].NewRow();
                    dr["Id_Nhansu"] = frmrex_Nhansu_Dialog.Id_Nhansu[i];
                    dsCollection.Tables[0].Rows.Add(dr);
                }
                dgrex_Botri_Ca_Lamviec.DataSource = dsCollection;
                dgrex_Botri_Ca_Lamviec.DataMember = dsCollection.Tables[0].TableName;
            }
        }
        
    }
}

