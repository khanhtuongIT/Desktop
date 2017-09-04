using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Phieu_Chi_Congno :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        
        DataSet dsCollection = new DataSet();
        DataSet dsCollection_Chitiet = new DataSet();
        object id_phieuchi_congno = null;

        #region Initialize

        public Frmware_Phieu_Chi_Congno()
        {
            InitializeComponent();
            dtNgay_Chungtu.Properties.MinValue = new DateTime(2000, 01, 01);
            DisplayInfo();
        }

        #endregion

        #region Event Override
        public override void DisplayInfo()
        {
            try
            {
                //Get data Get_All_Rex_Nhansu_Collection
                DataSet dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUpEdit_Nhansu_Lapphieu.Properties.DataSource = dsNhansu.Tables[0];
                gridLookUpEdit_Nhansu_Lapphieu.DataSource = dsNhansu.Tables[0];

                //Get data Get_All_Ware_Dm_Doituong
                DataSet dsDoituong = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                lookUpEdit_Doituong.Properties.DataSource = dsDoituong.Tables[0];
                gridLookUpEdit_Doituong.DataSource = dsDoituong.Tables[0];

                //Get data Get_All_Ware_Dm_Tiente
                DataSet dsTiente = objMasterService.Get_All_Ware_Dm_Tiente().ToDataSet();
                lookUpEdit_Tiente.Properties.DataSource = dsTiente.Tables[0];
                gridLookUpEdit_Tiente.DataSource = dsTiente.Tables[0];

                dsCollection = objWareService.Get_All_Ware_Phieuchi_Congno().ToDataSet();
                dgware_Phieu_Chi_Congno.DataSource = dsCollection;
                dgware_Phieu_Chi_Congno.DataMember = dsCollection.Tables[0].TableName;

                this.DataBindingControl();

                this.ChangeStatus(false);

                DisplayInfo2();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public void DisplayInfo2()
        {
            try
            {
                if ("" + gridView_Ware_Phieuchi_Congno.GetFocusedRowCellValue("Id_Phieuchi_Congno") != "")
                {
                    id_phieuchi_congno = Convert.ToInt64(gridView_Ware_Phieuchi_Congno.GetFocusedRowCellValue("Id_Phieuchi_Congno"));
                    dsCollection_Chitiet = objWareService.Get_Ware_Phieuchi_Congno_Chitiet_ByPCCongno(id_phieuchi_congno).ToDataSet();
                    dgware_Phieu_Chi_Congno_Chitiet.DataSource = dsCollection_Chitiet;
                    dgware_Phieu_Chi_Congno_Chitiet.DataMember = dsCollection_Chitiet.Tables[0].TableName;
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }

        }

        public override void ClearDataBindings()
        {
            this.txtLydo.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtSotien_Quydoi.DataBindings.Clear();
            this.txtSotien_Ngoaite.DataBindings.Clear();
            this.txtTygia.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.txtNguoi_Nhan.DataBindings.Clear();
            this.lookUpEdit_Doituong.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Lapphieu.DataBindings.Clear();
            this.lookUpEdit_Tiente.DataBindings.Clear();
            //Hinh thuc chi tra
            this.radioHinhthuc_Thanhtoan.EditValue = null;
            this.radioHinhthuc_Thanhtoan.SelectedIndex = -1;
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtSochungtu.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Sochungtu");
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Ngay_Chungtu");
                this.lookUpEdit_Nhansu_Lapphieu.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Id_Nhansu_Lapphieu");

                this.lookUpEdit_Doituong.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Id_Khachhang");
                this.txtNguoi_Nhan.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Nguoi_Nhan");
                this.txtLydo.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Lydo");

                this.lookUpEdit_Tiente.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Id_Tiente");
                this.txtTygia.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Tygia");
                this.txtSotien_Ngoaite.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Sotien");
                this.txtSotien_Quydoi.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Sotien_Quydoi");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            this.txtLydo.Properties.ReadOnly = !editTable;
            this.txtNguoi_Nhan.Properties.ReadOnly = !editTable;
            this.txtDiachi.Properties.ReadOnly = true;
            this.lookUpEdit_Doituong.Properties.ReadOnly = (FormState ==  GoobizFrame.Windows.Forms.FormState.Add) ? !editTable : true;
            this.chkNgoaite.Properties.ReadOnly = !editTable;
            this.chkPrint_Save.Properties.ReadOnly = !editTable;
            this.dgware_Phieu_Chi_Congno.Enabled = !editTable;
            this.chkNgoaite.Properties.ReadOnly = true;
            this.gridView_Ware_Phieuchi_Congno_Chitiet.OptionsBehavior.Editable = false;
            
            if (gridView_Ware_Phieuchi_Congno_Chitiet.RowCount == 0)
                radioHinhthuc_Thanhtoan.Properties.ReadOnly = true;
            else
                radioHinhthuc_Thanhtoan.Properties.ReadOnly = (FormState ==  GoobizFrame.Windows.Forms.FormState.Edit || FormState ==  GoobizFrame.Windows.Forms.FormState.Add) ? !editTable : true;

            if (chkNgoaite.Checked == true)
            {
                this.lookUpEdit_Tiente.Properties.ReadOnly = (FormState ==  GoobizFrame.Windows.Forms.FormState.Edit || FormState ==  GoobizFrame.Windows.Forms.FormState.Add) ? false : true;
                this.txtTygia.Properties.ReadOnly = (FormState ==  GoobizFrame.Windows.Forms.FormState.Edit || FormState ==  GoobizFrame.Windows.Forms.FormState.Add) ? false : true;
                this.txtSotien_Ngoaite.Properties.ReadOnly = (FormState ==  GoobizFrame.Windows.Forms.FormState.Edit || FormState ==  GoobizFrame.Windows.Forms.FormState.Add) ? false : true;
            }
            else
            {
                this.lookUpEdit_Tiente.Properties.ReadOnly = true;
                this.txtTygia.Properties.ReadOnly = true;
                this.txtSotien_Ngoaite.Properties.ReadOnly = true;
            }
        }

        public override void ResetText()
        {
            this.ClearDataBindings();

            this.chkNgoaite.Checked = false;
            this.radioHinhthuc_Thanhtoan.EditValue = null;
            this.radioHinhthuc_Thanhtoan.SelectedIndex = -1;

            this.txtLydo.EditValue = "";
            this.txtSotien_Quydoi.EditValue = "";
            this.txtSotien_Ngoaite.EditValue = "";
            this.txtTygia.EditValue = "";
            this.txtSotien_Chu.EditValue = "";
            this.txtNguoi_Nhan.EditValue = null;
            this.lookUpEdit_Doituong.EditValue = null;
            this.lookUpEdit_Tiente.EditValue = null;
            this.lookUpEdit_Nhansu_Lapphieu.EditValue = null;
            this.chkPrint_Save.Checked = false;
            this.dtNgay_Chungtu.EditValue = null;
            this.txtSochungtu.EditValue = "";
        }

        public object InsertObject()
        {
            try
            {
                if (gridView_Ware_Phieuchi_Congno_Chitiet.RowCount == 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Không thể lập phiếu chi vì không có nợ.");
                    return false;
                }

                Ecm.WebReferences.WareService.Ware_Phieuchi_Congno objWare_Phieuchi_Congno = new Ecm.WebReferences.WareService.Ware_Phieuchi_Congno();
                objWare_Phieuchi_Congno.Id_Phieuchi_Congno = -1;
                objWare_Phieuchi_Congno.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Phieuchi_Congno.Sochungtu = txtSochungtu.EditValue;
                objWare_Phieuchi_Congno.Lydo = txtLydo.Text;
                objWare_Phieuchi_Congno.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;
                objWare_Phieuchi_Congno.Id_Khachhang = Convert.ToInt64(lookUpEdit_Doituong.EditValue);
                objWare_Phieuchi_Congno.Nguoi_Nhan = txtNguoi_Nhan.Text;
                if (chkNgoaite.Checked == true)
                {
                    objWare_Phieuchi_Congno.Sotien = Convert.ToDecimal(txtSotien_Ngoaite.EditValue);
                    objWare_Phieuchi_Congno.Id_Tiente = Convert.ToInt64(lookUpEdit_Tiente.EditValue);
                    objWare_Phieuchi_Congno.Tygia = Convert.ToDecimal(txtTygia.EditValue);
                }
                else
                {
                    objWare_Phieuchi_Congno.Sotien = null;
                    objWare_Phieuchi_Congno.Id_Tiente = null;
                    objWare_Phieuchi_Congno.Tygia = null;
                }
                objWare_Phieuchi_Congno.Sotien_Quydoi = Convert.ToDecimal(txtSotien_Quydoi.EditValue);

                int identity = (int)objWareService.Insert_Ware_Phieuchi_Congno(objWare_Phieuchi_Congno);

                //Phiếu chi công nợ chi tiết.
                for (int i = 0; i < gridView_Ware_Phieuchi_Congno_Chitiet.RowCount; i++)
                {
                    Ecm.WebReferences.WareService.Ware_Phieuchi_Congno_Chititet objWare_Phieuchi_Congno_Chititet = new Ecm.WebReferences.WareService.Ware_Phieuchi_Congno_Chititet();
                    objWare_Phieuchi_Congno_Chititet.Id_Phieuchi_Congno = identity;
                    objWare_Phieuchi_Congno_Chititet.Chungtu_Goc = gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Chungtu_Goc");
                    objWare_Phieuchi_Congno_Chititet.Sotien = Convert.ToDecimal("0" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien"));
                    objWare_Phieuchi_Congno_Chititet.Sotien_Thanhtoan = Convert.ToDecimal("0" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_Thanhtoan"));
                    objWare_Phieuchi_Congno_Chititet.Sotien_No = Convert.ToDecimal("0" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_No"));
                    objWare_Phieuchi_Congno_Chititet.Sotien_Thanhtoan_Trongky = Convert.ToDecimal("0" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_Thanhtoan_Trongky"));
                    objWare_Phieuchi_Congno_Chititet.Sotien_No_Trongky = Convert.ToDecimal("0" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_No_Trongky"));
                    if (Convert.ToDecimal("0" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_Thanhtoan_Trongky")) > 0)
                        objWareService.Insert_Ware_Phieuchi_Congno_Chitiet(objWare_Phieuchi_Congno_Chititet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

            return true;
        }

        public object UpdateObject()
        {
            try
            {
                long identity = Convert.ToInt64(gridView_Ware_Phieuchi_Congno.GetFocusedRowCellValue("Id_Phieuchi_Congno"));

                Ecm.WebReferences.WareService.Ware_Phieuchi_Congno objWare_Phieuchi_Congno = new Ecm.WebReferences.WareService.Ware_Phieuchi_Congno();
                objWare_Phieuchi_Congno.Id_Phieuchi_Congno = identity;
                objWare_Phieuchi_Congno.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Phieuchi_Congno.Sochungtu = txtSochungtu.EditValue;
                objWare_Phieuchi_Congno.Lydo = txtLydo.EditValue;
                objWare_Phieuchi_Congno.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;
                objWare_Phieuchi_Congno.Id_Khachhang = Convert.ToInt64(lookUpEdit_Doituong.EditValue);
                objWare_Phieuchi_Congno.Nguoi_Nhan = txtNguoi_Nhan.Text;
                if (chkNgoaite.Checked == true)
                {
                    objWare_Phieuchi_Congno.Sotien = Convert.ToDecimal(txtSotien_Ngoaite.EditValue);
                    objWare_Phieuchi_Congno.Id_Tiente = Convert.ToInt64(lookUpEdit_Tiente.EditValue);
                    objWare_Phieuchi_Congno.Tygia = Convert.ToDecimal(txtTygia.EditValue);
                }
                else
                {
                    objWare_Phieuchi_Congno.Sotien = null;
                    objWare_Phieuchi_Congno.Id_Tiente = null;
                    objWare_Phieuchi_Congno.Tygia = null;
                }

                objWare_Phieuchi_Congno.Sotien_Quydoi = Convert.ToDecimal(txtSotien_Quydoi.EditValue);

                objWareService.Update_Ware_Phieuchi_Congno(objWare_Phieuchi_Congno);

                //Xóa chi tiết phiếu chi công nợ (Thông tin chi tiết củ).
                objWareService.Delete_Ware_Phieuchi_Congno_Chitiet_ByPCCongno(identity);

                //Phiếu chi công nợ chi tiết (Thông tin chi tiết mới).
                for (int i = 0; i < gridView_Ware_Phieuchi_Congno_Chitiet.RowCount; i++)
                {
                    Ecm.WebReferences.WareService.Ware_Phieuchi_Congno_Chititet objWare_Phieuchi_Congno_Chititet = new Ecm.WebReferences.WareService.Ware_Phieuchi_Congno_Chititet();
                    objWare_Phieuchi_Congno_Chititet.Id_Phieuchi_Congno = identity;
                    objWare_Phieuchi_Congno_Chititet.Chungtu_Goc = gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Chungtu_Goc");
                    objWare_Phieuchi_Congno_Chititet.Sotien = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien"));
                    objWare_Phieuchi_Congno_Chititet.Sotien_Thanhtoan = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_Thanhtoan"));
                    objWare_Phieuchi_Congno_Chititet.Sotien_No = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_No"));
                    objWare_Phieuchi_Congno_Chititet.Sotien_Thanhtoan_Trongky = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_Thanhtoan_Trongky"));
                    objWare_Phieuchi_Congno_Chititet.Sotien_No_Trongky = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_No_Trongky"));
                    if (Convert.ToDecimal("0" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_Thanhtoan_Trongky")) > 0)
                        objWareService.Insert_Ware_Phieuchi_Congno_Chitiet(objWare_Phieuchi_Congno_Chititet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Phieuchi_Congno objWare_Phieuchi_Congno = new Ecm.WebReferences.WareService.Ware_Phieuchi_Congno();
            objWare_Phieuchi_Congno.Id_Phieuchi_Congno = gridView_Ware_Phieuchi_Congno.GetFocusedRowCellValue("Id_Phieuchi_Congno");
            return objWareService.Delete_Ware_Phieuchi_Congno(objWare_Phieuchi_Congno);
        }

        public override bool PerformAdd()
        {
            this.FormState =  GoobizFrame.Windows.Forms.FormState.Add;

            this.ResetText();

            lookUpEdit_Nhansu_Lapphieu.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            dtThang_Nam.EditValue = objWareService.GetServerDateTime().Month + "/" + objWareService.GetServerDateTime().Year;
            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_phieuchi_congno", "sochungtu", "CHICN");
            txtSotien_Quydoi.EditValue = string.Empty;
            txtSotien_Chu.EditValue = string.Empty;
            this.dsCollection_Chitiet = objWareService.Ware_Congno_Khachhang(0).ToDataSet();
            this.dgware_Phieu_Chi_Congno_Chitiet.DataSource = dsCollection_Chitiet;
            this.dgware_Phieu_Chi_Congno_Chitiet.DataMember = dsCollection_Chitiet.Tables[0].TableName;

            this.ChangeStatus(true);

            return true;
        }

        public override bool PerformEdit()
        {
            this.FormState =  GoobizFrame.Windows.Forms.FormState.Edit;

            try
            {
                if ("" + id_phieuchi_congno != "")
                {
                    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "Ware_Phieuchi_Congno";
                    DocumentProcessStatus.PK_Name = "Id_Phieuchi_Congno";
                    DocumentProcessStatus.Identity = gridView_Ware_Phieuchi_Congno.GetFocusedRowCellValue("Id_Phieuchi_Congno");
                    DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                        return false;
                    }
                    if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Lapphieu.EditValue))
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                        return false;
                    }

                    if (txtSotien_Quydoi.Text == "")
                        chkNgoaite.Checked = false;
                    else
                        chkNgoaite.Checked = true;
                }

                this.ChangeStatus(true);
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
            return true;
        }

        public override bool PerformCancel()
        {
            ResetText();
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                htbControl1.Add(lookUpEdit_Doituong, lblNhacungcap.Text);
                htbControl1.Add(txtNguoi_Nhan, lblNguoi_Nhan.Text);
                htbControl1.Add(txtLydo, lblLydo.Text);
                htbControl1.Add(txtSotien_Quydoi, lblSotien_Quydoi.Text);

                if (chkNgoaite.Checked == true)
                {
                    htbControl1.Add(txtSotien_Ngoaite, lblSotien_Ngoaite.Text);
                    htbControl1.Add(lookUpEdit_Tiente, lblTiente.Text);
                }

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
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
                    if (chkPrint_Save.Checked == true)
                        PerformPrintPreview();

                    this.FormState =  GoobizFrame.Windows.Forms.FormState.View;

                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public override bool PerformDelete()
        {
            try
            {
                if ("" + id_phieuchi_congno != "")
                {
                    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "Ware_Phieuchi_Congno";
                    DocumentProcessStatus.PK_Name = "Id_Phieuchi_Congno";
                    DocumentProcessStatus.Identity = gridView_Ware_Phieuchi_Congno.GetFocusedRowCellValue("Id_Phieuchi_Congno");
                    DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                        return false;
                    }
                    if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Lapphieu.EditValue))
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                        return false;
                    }
                    if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                     GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Phieuchi_Congno"),
                     GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Phieuchi_Congno")   }) == DialogResult.Yes)
                    {
                        try
                        {
                            this.DeleteObject();
                        }
                        catch (Exception ex)
                        {
                             GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                        }
                        ResetText();
                        this.DisplayInfo();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformDelete();
        }

        public override bool PerformTest()
        {
            try
            {
                if ("" + id_phieuchi_congno != "")
                {
                    //show form ShowFormDocProgress
                     GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                        "Ware_Phieuchi_Congno" //Table name
                        , "Id_Phieuchi_Congno" //PK name
                        , gridView_Ware_Phieuchi_Congno.GetFocusedRowCellValue("Id_Phieuchi_Congno") //value
                        ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.TestDoc //New enum DocStatus
                        , false);
                    DisplayInfo();
                }
                return false;
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
                if ("" + id_phieuchi_congno != "")
                {
                    //show form ShowFormDocProgress
                     GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                        "Ware_Phieuchi_Congno" //Table name
                        , "Id_Phieuchi_Congno" //PK name
                        , gridView_Ware_Phieuchi_Congno.GetFocusedRowCellValue("Id_Phieuchi_Congno") //value
                        ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.VerifyDoc //New enum DocStatus
                        , false);
                    DisplayInfo();
                }
                return false;
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

        public override bool PerformPrintPreview()
        {
            if ("" + id_phieuchi_congno != "")
            {
                Reports.rptPhieu_Chi rptPhieu_Chi = new Ecm.Ware.Reports.rptPhieu_Chi();
                 GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = rptPhieu_Chi;
                //add parameter values
                rptPhieu_Chi.tbcDiachi.Text = txtDiachi.Text;
                rptPhieu_Chi.tbcLydo.Text = txtLydo.Text;
                rptPhieu_Chi.tbcNam.Text = "" + dtNgay_Chungtu.DateTime.Year;
                rptPhieu_Chi.tbcThang.Text = "" + dtNgay_Chungtu.DateTime.Month;
                rptPhieu_Chi.tbcNgay.Text = "" + dtNgay_Chungtu.DateTime.Day;
                rptPhieu_Chi.tbcNguoi_Nhantien.Text = "" + txtNguoi_Nhan.Text;
                rptPhieu_Chi.tbcNguoi_Nhantien_Kyten.Text = "" + txtNguoi_Nhan.Text;
                rptPhieu_Chi.tbcNhansu_Lapphieu.Text = "" + lookUpEdit_Nhansu_Lapphieu.Text;
                rptPhieu_Chi.tbcSochungtu.Text = txtSochungtu.Text;
                if (chkNgoaite.Checked)
                {
                    rptPhieu_Chi.tbcSotien.Text = string.Format("{0:#,#} {1}, Tỷ giá 1 {2} = {3} đồng", txtSotien_Ngoaite.Text, lookUpEdit_Tiente.Text, lookUpEdit_Tiente.Text, txtTygia.Text);

                    string str =  GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(Convert.ToDouble(txtSotien_Ngoaite.EditValue), " " + lookUpEdit_Tiente.Text.ToUpper());
                    str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();

                    rptPhieu_Chi.tbcSotien_Bangchu.Text = str;
                }
                else
                {
                    rptPhieu_Chi.tbcSotien.Text = string.Format("{0:#,#} {1}", txtSotien_Quydoi.Text, lookUpEdit_Tiente.Text);

                    string str =  GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(Convert.ToDouble(txtSotien_Quydoi.EditValue), " đồng");
                    str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();

                    rptPhieu_Chi.tbcSotien_Bangchu.Text = str;
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
                        ,imageData
                    });

                    rptPhieu_Chi.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    rptPhieu_Chi.xrc_CompanyAddress.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                }

                #endregion

                rptPhieu_Chi.CreateDocument();
                 GoobizFrame.Windows.Forms.ReportOptions oReportOptions =  GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptPhieu_Chi);

                 if (Convert.ToBoolean(oReportOptions.PrintPreview))
                 {
                     frmPrintPreview.Text = "" + oReportOptions.Caption;
                     frmPrintPreview.printControl1.PrintingSystem = rptPhieu_Chi.PrintingSystem;
                     frmPrintPreview.MdiParent = this.MdiParent;
                     frmPrintPreview.Show();
                     frmPrintPreview.Activate();
                 }
                 else
                 {
                     var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptPhieu_Chi);
                     reportPrintTool.Print();
                 }
                return base.PerformPrintPreview();
            }
            return false;
        }

        #endregion

        #region Event Handling

        private void lookUpEdit_Doituong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (this.FormState !=  GoobizFrame.Windows.Forms.FormState.View)
                    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                    {
                        Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add frmware_Dm_Khachhang_Add = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add();
                        frmware_Dm_Khachhang_Add.StartPosition = FormStartPosition.CenterScreen;
                        frmware_Dm_Khachhang_Add.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        frmware_Dm_Khachhang_Add.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        frmware_Dm_Khachhang_Add.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        frmware_Dm_Khachhang_Add.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        frmware_Dm_Khachhang_Add.ShowDialog();
                        if (frmware_Dm_Khachhang_Add.SelectedWare_Dm_Khachhang != null)
                        {
                            lookUpEdit_Doituong.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
                            this.lookUpEdit_Doituong.EditValue = frmware_Dm_Khachhang_Add.SelectedWare_Dm_Khachhang.Id_Khachhang;
                            this.txtDiachi.Text = "" + frmware_Dm_Khachhang_Add.SelectedWare_Dm_Khachhang.Diachi_Khachhang;
                        }
                    }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void radioHinhthuc_Chitra_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkNgoaite.Properties.ReadOnly = false;

                if ("" + radioHinhthuc_Thanhtoan.EditValue == "MANUAL")
                {
                    this.Init_Phieuchi_Congno_Chuatra_ByDoituong();

                    this.gridView_Ware_Phieuchi_Congno_Chitiet.OptionsBehavior.Editable = true;

                    this.txtSotien_Quydoi.Text = "";
                    this.txtSotien_Quydoi.Properties.ReadOnly = true;
                }

                if ("" + radioHinhthuc_Thanhtoan.EditValue == "AUTO")
                {
                    this.Init_Phieuchi_Congno_Chuatra_ByDoituong();

                    this.gridView_Ware_Phieuchi_Congno_Chitiet.OptionsBehavior.Editable = false;

                    this.txtSotien_Quydoi.Text = "";
                    this.txtSotien_Quydoi.Properties.ReadOnly = false;
                }

                if ("" + radioHinhthuc_Thanhtoan.EditValue == "ALL")
                {
                    this.Thanhtoan_Het_Hoadon();

                    this.gridView_Ware_Phieuchi_Congno_Chitiet.OptionsBehavior.Editable = false;

                    this.txtSotien_Ngoaite.Properties.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
#if ( DEBUG )
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void chkNgoaite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgoaite.Checked == true)
            {
                this.lookUpEdit_Tiente.Properties.ReadOnly = (FormState ==  GoobizFrame.Windows.Forms.FormState.Edit || FormState ==  GoobizFrame.Windows.Forms.FormState.Add) ? false : true;
                this.txtTygia.Properties.ReadOnly = (FormState ==  GoobizFrame.Windows.Forms.FormState.Edit || FormState ==  GoobizFrame.Windows.Forms.FormState.Add) ? false : true;
            }
            else
            {
                this.lookUpEdit_Tiente.Properties.ReadOnly = true;
                this.txtTygia.Properties.ReadOnly = true;
            }
        }

        private void lookUpEdit_Doituong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtDiachi.Text = "" + lookUpEdit_Doituong.GetColumnValue("Diachi_Khachhang");
                if (FormState ==  GoobizFrame.Windows.Forms.FormState.Add || FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    this.txtSotien_Quydoi.Text = "";

                    if ("" + radioHinhthuc_Thanhtoan.EditValue == "ALL")
                        this.Thanhtoan_Het_Hoadon();
                    else
                        this.Init_Phieuchi_Congno_Chuatra_ByDoituong();
                }
            }
            catch (Exception ex)
            {
#if ( DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void gridView_Ware_Phieuchi_Congno_Chitiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if ("" + radioHinhthuc_Thanhtoan.EditValue == "MANUAL" && e.Column.FieldName == "Sotien_Thanhtoan_Trongky")
                {
                    decimal sotien = 0;
                    decimal sotien_no = 0;
                    decimal sotien_thanhtoan_trongky = 0;

                    if ("" + gridView_Ware_Phieuchi_Congno_Chitiet.GetFocusedRowCellValue("Sotien") != "")
                        sotien = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.GetFocusedRowCellValue("Sotien"));
                    if ("" + gridView_Ware_Phieuchi_Congno_Chitiet.GetFocusedRowCellValue("Sotien_No") != "")
                        sotien_no = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.GetFocusedRowCellValue("Sotien_No"));
                    if ("" + gridView_Ware_Phieuchi_Congno_Chitiet.GetFocusedRowCellValue("Sotien_Thanhtoan_Trongky") != "")
                        sotien_thanhtoan_trongky = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.GetFocusedRowCellValue("Sotien_Thanhtoan_Trongky"));

                    if (sotien_thanhtoan_trongky > sotien_no)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền thanh toán không được vược quá số nợ.");
                        gridView_Ware_Phieuchi_Congno_Chitiet.SetFocusedRowCellValue("Sotien_Thanhtoan_Trongky", null);
                        gridView_Ware_Phieuchi_Congno_Chitiet.SetFocusedRowCellValue("Sotien_No", sotien_no);
                        gridView_Ware_Phieuchi_Congno_Chitiet.SetFocusedRowCellValue("Sotien_No_Trongky", 0);
                    }
                    else
                    {
                        gridView_Ware_Phieuchi_Congno_Chitiet.SetFocusedRowCellValue("Sotien_No_Trongky", sotien_no - sotien_thanhtoan_trongky);
                    }

                    this.gridView_Ware_Phieuchi_Congno_Chitiet.UpdateTotalSummary();

                    this.txtSotien_Quydoi.Text = String.Format("{0:###,###}", gridView_Ware_Phieuchi_Congno_Chitiet.Columns["Sotien_Thanhtoan_Trongky"].SummaryText);
                }
            }
            catch (Exception ex)
            {
#if ( DEBUG)
                MessageBox.Show(ex.Message);
#endif

            }
        }

        private void txtSotien_Quydoi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ("" + radioHinhthuc_Thanhtoan.EditValue == "AUTO")
                {
                    this.Init_Phieuchi_Congno_Chuatra_ByDoituong();

                    decimal sotien_phanbo = 0;
                    decimal sotien_cantra_kt = 0;

                    if (txtSotien_Quydoi.Text != "")
                        sotien_phanbo = Convert.ToDecimal(txtSotien_Quydoi.Text);
                    if (gridView_Ware_Phieuchi_Congno_Chitiet.Columns["Sotien"].SummaryText != "")
                        sotien_cantra_kt = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.Columns["Sotien"].SummaryText);

                    if (sotien_phanbo.ToString().Length > 16)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền phân bổ không hợp lý, vui lòng nhập lại!");

                        this.txtSotien_Ngoaite.Text = "";
                        this.txtSotien_Quydoi.Text = "";
                    }

                    if (sotien_phanbo > sotien_cantra_kt)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền phân bổ không được vược quá tổng số nợ.");

                        this.txtSotien_Ngoaite.Text = "";
                        this.txtSotien_Quydoi.Text = "";
                    }
                    else
                    {
                        for (int i = 0; i < gridView_Ware_Phieuchi_Congno_Chitiet.RowCount; i++)
                        {
                            decimal sotien = 0;
                            decimal sotien_thanhtoan = 0;

                            if ("" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien") != "")
                                sotien = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien"));
                            if ("" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_Thanhtoan") != "")
                                sotien_thanhtoan = Convert.ToDecimal(gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_Thanhtoan"));

                            if ((sotien_phanbo - (sotien - sotien_thanhtoan))  < 0)
                            {
                                gridView_Ware_Phieuchi_Congno_Chitiet.SetRowCellValue(i, "Sotien_No", (sotien - sotien_thanhtoan));
                                gridView_Ware_Phieuchi_Congno_Chitiet.SetRowCellValue(i, "Sotien_Thanhtoan_Trongky", sotien_phanbo);
                                gridView_Ware_Phieuchi_Congno_Chitiet.SetRowCellValue(i, "Sotien_No_Trongky", (sotien - sotien_thanhtoan) - sotien_phanbo);
                                sotien_phanbo = 0;
                            }
                            else
                            {
                                gridView_Ware_Phieuchi_Congno_Chitiet.SetRowCellValue(i, "Sotien_No", (sotien - sotien_thanhtoan));
                                gridView_Ware_Phieuchi_Congno_Chitiet.SetRowCellValue(i, "Sotien_Thanhtoan_Trongky", (sotien - sotien_thanhtoan));
                                gridView_Ware_Phieuchi_Congno_Chitiet.SetRowCellValue(i, "Sotien_No_Trongky", 0);
                                sotien_phanbo = sotien_phanbo - (sotien - sotien_thanhtoan);
                            }
                        }
                    }
                }

                if (txtSotien_Quydoi.Text != "")
                {
                    //Đổi tiền thành chữ
                    txtSotien_Chu.Text =  GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(Convert.ToDouble(txtSotien_Quydoi.Text), " đồng.");

                    decimal tygia = 0;
                    decimal sotien_quydoi = 0;

                    if (txtTygia.Text != "")
                        tygia = Convert.ToDecimal(txtTygia.Text);
                    if (txtSotien_Quydoi.Text != "")
                        sotien_quydoi = Convert.ToDecimal(txtSotien_Quydoi.Text);

                    if (tygia > 0)
                        txtSotien_Ngoaite.Text = String.Format("{0:###,###}", (sotien_quydoi / tygia));
                }
            }
            catch (Exception ex)
            {
#if ( DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void txtTygia_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNgoaite.Checked)
                {
                    decimal tygia = 0;
                    decimal sotien_quydoi = 0;

                    if (txtTygia.Text != "")
                        tygia = Convert.ToDecimal(txtTygia.Text);
                    if (txtSotien_Quydoi.Text != "")
                        sotien_quydoi = Convert.ToDecimal(txtSotien_Quydoi.Text);

                    if (tygia > 0)
                        txtSotien_Ngoaite.Text = String.Format("{0:###,###}", (sotien_quydoi / tygia));
                }
            }
            catch (Exception ex)
            {
#if ( DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void gridView_Ware_Phieuchi_Congno_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.DisplayInfo2();
        }

        private void lookUpEdit_Tiente_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEdit_Tiente.EditValue != "")
            {
                chkNgoaite.Checked = true;
                this.txtTygia.EditValue = lookUpEdit_Tiente.GetColumnValue("Tygia_Vnd");
            }
            else
                chkNgoaite.Checked = false;
        }

        private void chkShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            gridView_Ware_Phieuchi_Congno.OptionsView.ShowPreview = chkShowPreview.Checked;
        }

        private void dtThang_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (dtThang_Nam.Text != "")
            {
                DateTime dtValue = dtThang_Nam.DateTime;
                gridView_Ware_Phieuchi_Congno.Columns["Thang"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView_Ware_Phieuchi_Congno.Columns["Thang"], dtValue.Month);
                gridView_Ware_Phieuchi_Congno.Columns["Nam"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView_Ware_Phieuchi_Congno.Columns["Nam"], dtValue.Year);
            }
            else
                gridView_Ware_Phieuchi_Congno.ClearColumnsFilter();
        }

        private void txtSotien_Quydoi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString() != "" && e.NewValue.ToString().Length > 16)
                e.Cancel = true;
        }

        private void txtTygia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString() != "" && e.NewValue.ToString().Length > 10)
                e.Cancel = true;
        }

        private void txtSotien_Ngoaite_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString() != "" && e.NewValue.ToString().Length > 10)
                e.Cancel = true;
        }

        #endregion

        #region Custom Function

        private void Thanhtoan_Het_Hoadon()
        {
            try
            {
                decimal sotien_phaitra = 0;

                for (int i = 0; i < gridView_Ware_Phieuchi_Congno_Chitiet.RowCount; i++)
                {
                    decimal sotien = Convert.ToDecimal("0" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien"));
                    decimal sotien_thanhtoan = Convert.ToDecimal("0" + gridView_Ware_Phieuchi_Congno_Chitiet.GetRowCellValue(i, "Sotien_Thanhtoan"));
                   
                    sotien_phaitra += (sotien - sotien_thanhtoan);

                    gridView_Ware_Phieuchi_Congno_Chitiet.SetRowCellValue(i, "Sotien_Thanhtoan", sotien);
                    gridView_Ware_Phieuchi_Congno_Chitiet.SetRowCellValue(i, "Sotien_No", 0);
                    gridView_Ware_Phieuchi_Congno_Chitiet.SetRowCellValue(i, "Sotien_Thanhtoan_Trongky", (sotien - sotien_thanhtoan));
                    gridView_Ware_Phieuchi_Congno_Chitiet.SetRowCellValue(i, "Sotien_No_Trongky", 0);
                }

                this.txtSotien_Quydoi.Text = String.Format("{0:###,###}", sotien_phaitra);
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void Init_Phieuchi_Congno_Chuatra_ByDoituong()
        {
            try
            {
                if ("" + lookUpEdit_Doituong.EditValue != "")
                {
                    this.dsCollection_Chitiet = objWareService.Get_Ware_Phieuchi_Congno_Chuatra_ByDoituong(lookUpEdit_Doituong.EditValue).ToDataSet();
                    this.dgware_Phieu_Chi_Congno_Chitiet.DataSource = dsCollection_Chitiet;
                    this.dgware_Phieu_Chi_Congno_Chitiet.DataMember = dsCollection_Chitiet.Tables[0].TableName;
                    
                    //Nếu phát sinh nợ mới cho phép chọn phương thức thanh toán
                    if (gridView_Ware_Phieuchi_Congno_Chitiet.RowCount == 0)
                        radioHinhthuc_Thanhtoan.Properties.ReadOnly = true;
                    else
                        radioHinhthuc_Thanhtoan.Properties.ReadOnly = (FormState ==  GoobizFrame.Windows.Forms.FormState.Edit || FormState ==  GoobizFrame.Windows.Forms.FormState.Add) ? false : true;
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }
        #endregion
    }
}

