using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Kh_Hh_Ban :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Kh_Hh_Ban = new DataSet();
        DataSet ds_Kh_Hh_Ban_Chitiet = new DataSet();
        DataSet dsDm_Hanghoa_Ban;
        object identity;

        public Frmware_Kh_Hh_Ban()
        {
            InitializeComponent();

            //date mask
            dtNgay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Batdau.Properties.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            repositoryItemDateEdit_Ngay_Nhap_Hh_Mua.Properties.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit_Ngay_Nhap_Hh_Mua.Properties.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            //reset lookup edit as delete value
            lookUpEdit_Cuahang_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Kh.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);

            this.DisplayInfo();
        }


        #region Event Override


        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Kho_Hanghoa_Ban
                DataSet dsCuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet();
                lookUpEdit_Cuahang_Ban.Properties.DataSource = dsCuahang_Ban.Tables[0];
                gridookUpEdit_Cuahang_Ban.DataSource = dsCuahang_Ban.Tables[0];

                //Get data Rex_Nhansu
                DataSet dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUpEdit_Nhansu_Kh.Properties.DataSource = dsNhansu.Tables[0];

                //Get data Ware_Dm_Hanghoa_Ban
                dsDm_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                gridLookUpEdit_Hanghoa_Ban.DataSource = dsDm_Hanghoa_Ban.Tables[0];
                gridLookUpEditMa_Hanghoa_Ban.DataSource = dsDm_Hanghoa_Ban.Tables[0];


                //Get data Ware_Dm_Donvitinh
                gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];

                //Get data Ware_Khp_Hh_Ban
                ds_Kh_Hh_Ban = objWareService.Get_All_Ware_Kh_Hh_Ban().ToDataSet();
                dgware_Kh_Hh_Ban.DataSource = ds_Kh_Hh_Ban;
                dgware_Kh_Hh_Ban.DataMember = ds_Kh_Hh_Ban.Tables[0].TableName;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gvware_Kh_Hh_Ban_Chitiet.BestFitColumns();

                DisplayInfo2();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

            }

        }

        void ClearDataBindings()
        {
            this.txtId_Kh_Hh_Ban.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Batdau.DataBindings.Clear();
            this.dtNgay_Ketthuc.DataBindings.Clear();

            this.lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Kh.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Kh_Hh_Ban.DataBindings.Add("EditValue", ds_Kh_Hh_Ban, ds_Kh_Hh_Ban.Tables[0].TableName + ".Id_Kh_Hh_Ban");
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Kh_Hh_Ban, ds_Kh_Hh_Ban.Tables[0].TableName + ".Sochungtu");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Kh_Hh_Ban, ds_Kh_Hh_Ban.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Batdau.DataBindings.Add("EditValue", ds_Kh_Hh_Ban, ds_Kh_Hh_Ban.Tables[0].TableName + ".Ngay_Batdau");
                this.dtNgay_Ketthuc.DataBindings.Add("EditValue", ds_Kh_Hh_Ban, ds_Kh_Hh_Ban.Tables[0].TableName + ".Ngay_Ketthuc");

                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", ds_Kh_Hh_Ban, ds_Kh_Hh_Ban.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_Nhansu_Kh.DataBindings.Add("EditValue", ds_Kh_Hh_Ban, ds_Kh_Hh_Ban.Tables[0].TableName + ".Id_Nhansu_Kh");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

            }
        }

        public void ChangeStatus(bool editTable)
        {
            this.dgware_Kh_Hh_Ban.Enabled = !editTable;
            this.txtSochungtu.Properties.ReadOnly = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.dtNgay_Batdau.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Cuahang_Ban.Properties.ReadOnly = !editTable;
            this.dgware_Kh_Hh_Ban_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gvware_Kh_Hh_Ban_Chitiet.OptionsBehavior.Editable = editTable;

            btn_Hanghoa_Mua_Est.Enabled = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Kh_Hh_Ban.EditValue = "";
            this.txtSochungtu.EditValue = "";
            this.txtGhichu.EditValue = "";
            this.lookUpEdit_Cuahang_Ban.EditValue = "";
            this.ds_Kh_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Kh_Hh_Ban_Chitiet_By_Kh_Hh_Ban(0).ToDataSet();
            this.dgware_Kh_Hh_Ban_Chitiet.DataSource = ds_Kh_Hh_Ban_Chitiet.Tables[0];
        }

        void DisplayInfo2()
        {
            try
            {
                identity = gvware_Kh_Hh_Ban.GetFocusedRowCellValue("Id_Kh_Hh_Ban");

                this.ds_Kh_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Kh_Hh_Ban_Chitiet_By_Kh_Hh_Ban(identity != null ? identity : 0).ToDataSet();
                this.dgware_Kh_Hh_Ban_Chitiet.DataSource = ds_Kh_Hh_Ban_Chitiet;
                this.dgware_Kh_Hh_Ban_Chitiet.DataMember = ds_Kh_Hh_Ban_Chitiet.Tables[0].TableName;

                gvware_Kh_Hh_Ban_Chitiet.BestFitColumns();
            }
            catch { }
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Kh_Hh_Ban objWare_Kh_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Kh_Hh_Ban();
                objWare_Kh_Hh_Ban.Id_Kh_Hh_Ban = -1;
                objWare_Kh_Hh_Ban.Sochungtu = txtSochungtu.EditValue;
                objWare_Kh_Hh_Ban.Ghichu = txtGhichu.EditValue;
                objWare_Kh_Hh_Ban.Ngay_Batdau = dtNgay_Batdau.EditValue;
                objWare_Kh_Hh_Ban.Ngay_Ketthuc = dtNgay_Ketthuc.EditValue;

                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Kh_Hh_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nhansu_Kh.EditValue != "")
                    objWare_Kh_Hh_Ban.Id_Nhansu_Kh = lookUpEdit_Nhansu_Kh.EditValue;

                identity = objWareService.Insert_Ware_Kh_Hh_Ban(objWare_Kh_Hh_Ban);

                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Kh_Hh_Ban_Chitiet); //dgware_Kh_Hh_Ban_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Kh_Hh_Ban_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Kh_Hh_Ban"] = identity;
                    }
                    //update donmuahang_chitiet
                    objWareService.Update_Ware_Kh_Hh_Ban_Chitiet_Collection(ds_Kh_Hh_Ban_Chitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Kh_Hh_Ban objWare_Kh_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Kh_Hh_Ban();
                objWare_Kh_Hh_Ban.Id_Kh_Hh_Ban = gvware_Kh_Hh_Ban.GetFocusedRowCellValue("Id_Kh_Hh_Ban");
                objWare_Kh_Hh_Ban.Sochungtu = txtSochungtu.EditValue;
                objWare_Kh_Hh_Ban.Ghichu = txtGhichu.EditValue;
                objWare_Kh_Hh_Ban.Ngay_Batdau = dtNgay_Batdau.EditValue;
                if ("" + dtNgay_Ketthuc.EditValue != "") objWare_Kh_Hh_Ban.Ngay_Ketthuc = dtNgay_Ketthuc.EditValue;

                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "") objWare_Kh_Hh_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nhansu_Kh.EditValue != "") objWare_Kh_Hh_Ban.Id_Nhansu_Kh = lookUpEdit_Nhansu_Kh.EditValue;
                //update donmuahang
                objWareService.Update_Ware_Kh_Hh_Ban(objWare_Kh_Hh_Ban);

                //update donmuahang_chitiet
                this.DoClickEndEdit(dgware_Kh_Hh_Ban_Chitiet);
                foreach (DataRow dr in ds_Kh_Hh_Ban_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Kh_Hh_Ban"] = gvware_Kh_Hh_Ban.GetFocusedRowCellValue("Id_Kh_Hh_Ban");
                }
                //ds_Donmuahang_Chitiet.RejectChanges();
                objWareService.Update_Ware_Kh_Hh_Ban_Chitiet_Collection(ds_Kh_Hh_Ban_Chitiet);

                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Kh_Hh_Ban objWare_Kh_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Kh_Hh_Ban();
            objWare_Kh_Hh_Ban.Id_Kh_Hh_Ban = gvware_Kh_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Kh_Hh_Ban");

            return objWareService.Delete_Ware_Kh_Hh_Ban(objWare_Kh_Hh_Ban);
        }

        public override bool PerformAdd()
        {
            dtNgay_Batdau.EditValue = objWareService.GetServerDateTime();
            //Kiểm tra nếu nhân viên login không tồn tại trong kho hàng hóa mua thì access denied.
            lookUpEdit_Nhansu_Kh.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Kh.EditValue).ToDataSet();
            if (ds_Cuahang_Ban.Tables[0].Rows.Count > 0)
                lookUpEdit_Cuahang_Ban.EditValue = ds_Cuahang_Ban.Tables[0].Rows[0]["Id_Cuahang_Ban"];
            else
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                lookUpEdit_Nhansu_Kh.EditValue = null;
                return false;
            }

            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("Ware_Kh_Hh_Ban", "sochungtu", "KHSX-");

            return true;
        }

        public override bool PerformEdit()
        {
            try
            {
                if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Kh.EditValue))
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
                else
                {
                    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "Ware_Kh_Hh_Ban";
                    DocumentProcessStatus.PK_Name = "Id_Kh_Hh_Ban";
                    DocumentProcessStatus.Identity = gvware_Kh_Hh_Ban.GetFocusedRowCellValue("Id_Kh_Hh_Ban");
                    DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                        return false;
                    }
                }

                //gridLookUpEdit_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue).ToDataSet().Tables[0];
                //gridLookUpEditMa_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue).ToDataSet().Tables[0];
                this.ChangeStatus(true);
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
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
            bool success = false;
            try
            {
               

                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtSochungtu, lblSochungtu.Text);
                hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblId_Cuahang_Ban.Text);
                hashtableControls.Add(lookUpEdit_Nhansu_Kh, lblId_Nhansu_Kh.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    this.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
            return success;

        }

        public override bool PerformDelete()
        {
            if ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Kh.EditValue))
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
                else
                {
                    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "Ware_Kh_Hh_Ban";
                    DocumentProcessStatus.PK_Name = "Id_Kh_Hh_Ban";
                    DocumentProcessStatus.Identity = gvware_Kh_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Kh_Hh_Ban");
                    DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                        return false;
                    }
                }

            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Kh_Hh_Ban"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Kh_Hh_Ban")   }) == DialogResult.Yes)
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

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.WareService.Ware_Kh_Hh_Ban ware_Kh_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Kh_Hh_Ban();
            try
            {
                int focusedRow = gvware_Kh_Hh_Ban.GetDataSourceRowIndex(gvware_Kh_Hh_Ban.FocusedRowHandle);
                DataRow dr = ds_Kh_Hh_Ban.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Kh_Hh_Ban.Id_Kh_Hh_Ban = dr["Id_Kh_Hh_Ban"];
                    ware_Kh_Hh_Ban.Sochungtu = dr["Sochungtu"];
                    ware_Kh_Hh_Ban.Ngay_Batdau = dr["Ngay_Batdau"];
                    ware_Kh_Hh_Ban.Ngay_Ketthuc = dr["Ngay_Ketthuc"];
                    ware_Kh_Hh_Ban.Id_Cuahang_Ban = dr["Id_Cuahang_Ban"];
                    ware_Kh_Hh_Ban.Id_Nhansu_Kh = dr["Id_Nhansu_Kh"];
                    ware_Kh_Hh_Ban.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Kh_Hh_Ban;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        public override bool PerformTest()
        {
            try
            {
                //show form ShowFormDocProgress
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                    "Ware_Kh_Hh_Ban" //Table name
                    , "Id_Kh_Hh_Ban" //PK name
                    , gvware_Kh_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Kh_Hh_Ban") //value
                    ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.TestDoc //New enum DocStatus
                    , false);

                DisplayInfo();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformTest();

        }

        public override bool PerformVerify()
        {
            try
            {
                //show form ShowFormDocProgress
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                    "Ware_Kh_Hh_Ban" //Table name
                    , "Id_Kh_Hh_Ban" //PK name
                    , gvware_Kh_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Kh_Hh_Ban") //value
                    ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.VerifyDoc //New enum DocStatus
                    , false);
                DisplayInfo();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformVerify();

        }
        public override bool PerformQuery()
        {
            DataSets.DsWare_Nxt_Hhban dsWare_Nxt_Hhban = new Ecm.Ware.DataSets.DsWare_Nxt_Hhban();
            DataSet dsCollection = objWareService.Rptware_Nxt_Hhban_ByKhsx(objWareService.GetServerDateTime(), lookUpEdit_Cuahang_Ban.EditValue).ToDataSet();
            
            int i = 1;
            foreach (DataRow dr in dsCollection.Tables[0].Rows)
            {
                DataRow drnew = dsWare_Nxt_Hhban.Tables[0].NewRow();
                foreach (DataColumn dc in dsWare_Nxt_Hhban.Tables[0].Columns)
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
                drnew["Stt"] = i++;

                dsWare_Nxt_Hhban.Tables[0].Rows.Add(drnew);
            }

            XtraReports.Rptware_Nxt_Hhban rptware_Nxt_Hhban = new Ecm.Ware.XtraReports.Rptware_Nxt_Hhban();
            rptware_Nxt_Hhban.xrLblKho.Text = "Tại: " + lookUpEdit_Cuahang_Ban.Text;
            rptware_Nxt_Hhban.xrLbkNgay.Text = string.Format("Ngày: {0:dd/MM/yyyy}", objWareService.GetServerDateTime());
            rptware_Nxt_Hhban.xrlblNhansu_Lap.Text = lookUpEdit_Nhansu_Kh.Text;
            //add parameter values
            rptware_Nxt_Hhban.DataSource = dsWare_Nxt_Hhban;

             GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptware_Nxt_Hhban;
            frmPrintPreview.printControl1.PrintingSystem = rptware_Nxt_Hhban.PrintingSystem;
            frmPrintPreview.MdiParent = this.MdiParent;
            frmPrintPreview.Text = this.Text + "(Xem trang in)";
            frmPrintPreview.Show();
            frmPrintPreview.Activate();

            return base.PerformQuery();
        }
        public override bool PerformPrintPreview()
        {
            PerformQuery();
            return base.PerformPrintPreview();
        }
        #endregion

        #region Even

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog frmware_Dm_Hanghoa_Ban_Dialog = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog();
                frmware_Dm_Hanghoa_Ban_Dialog.Text = "Hàng hóa";
                frmware_Dm_Hanghoa_Ban_Dialog.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                 GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Ban_Dialog);
                frmware_Dm_Hanghoa_Ban_Dialog.ShowDialog();

                if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows != null
                    && frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
                {

                    gvware_Kh_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Kh_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]
                        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Ban"]);
                    gvware_Kh_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Kh_Hh_Ban_Chitiet.Columns["Id_Donvitinh"]
                        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Donvitinh"]);

                    if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 1)
                    {
                        for (int i = 1; i < frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length; i++)
                        {
                            DataRow nrow = ds_Kh_Hh_Ban_Chitiet.Tables[0].NewRow();
                            nrow["Id_Hanghoa_Ban"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"];
                            nrow["Id_Donvitinh"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Donvitinh"];
                            ds_Kh_Hh_Ban_Chitiet.Tables[0].Rows.Add(nrow);
                        }
                    }
                }
            }
        }

        private void chkShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            gvware_Kh_Hh_Ban.OptionsView.ShowPreview = chkShowPreview.Checked;
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Id_Hanghoa_Ban")
                {
                    gvware_Kh_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Kh_Hh_Ban_Chitiet.Columns["Id_Donvitinh"]
                        , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void lookUpEdit_Cuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    dsDm_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Batdau.EditValue);
            //}
            //catch { }
        }

        private void btn_Hanghoa_Mua_Est_Click(object sender, EventArgs e)
        {
            //Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FrKhhhban frmware_Dm_Hanghoa_Ban_FrKhhhban = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FrKhhhban();
            //frmware_Dm_Hanghoa_Ban_FrKhhhban.Text = btn_Hanghoa_Mua_Est.Text;
            //frmware_Dm_Hanghoa_Ban_FrKhhhban.Id_Kh_Hh_Ban = gvware_Kh_Hh_Ban.GetFocusedRowCellValue("Id_Kh_Hh_Ban");
            // GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Ban_FrKhhhban);
            //frmware_Dm_Hanghoa_Ban_FrKhhhban.ShowDialog();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvware_Kh_Hh_Ban.FocusedRowHandle >= 0)
            {
                DisplayInfo2();
            }

            //neu chung tu da duoc xac nhan thi cho phep in
            if (Convert.ToInt64(gvware_Kh_Hh_Ban.GetFocusedRowCellValue("Doc_Process_Status")) == 2)
                this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            else
                this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        #endregion

    }
}

