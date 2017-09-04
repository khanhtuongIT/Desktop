using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Phieu_Thu_Congno :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsCollection = new DataSet();
        DataSet dsCollection_chitiet = new DataSet();
        object _id_phieuthu_congno;
        object Sotien_Quydoi = null;

        #region Initialize

        public Frmware_Phieu_Thu_Congno()
        {
            InitializeComponent();
            dtNgay_Chungtu.Properties.MinValue = new DateTime(2000, 01, 01);
        }

        private void Frmware_Phieu_Thu_Congno_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
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

                //Get data Get_All_Ware_Dm_Doituong--> khách hàng
                DataSet dsDoituong = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                lookUpEdit_Doituong.Properties.DataSource = dsDoituong.Tables[0];
                gridLookUpEdit_Doituong.DataSource = dsDoituong.Tables[0];

                //Get data Get_All_Ware_Dm_Tiente
                DataSet dsTiente = objMasterService.Get_All_Ware_Dm_Tiente().ToDataSet();
                lookUpEdit_Tiente.Properties.DataSource = dsTiente.Tables[0];
                gridLookUpEdit_Tiente.DataSource = dsTiente.Tables[0];

                //Get data Ware_Phieuthu_Congno
                dsCollection = objWareService.Get_All_Ware_Phieuthu_Congno().ToDataSet();
                this.DataBindingControl();
                dgware_Phieu_Thu_Congno.DataSource = dsCollection;
                dgware_Phieu_Thu_Congno.DataMember = dsCollection.Tables[0].TableName;
                this.ChangeStatus(false);
                radioGroup1.EditValue = null;
                DisplayInfo2();
                this.gridView_Ware_Phieuthu_Congno_chitiet.OptionsBehavior.Editable = false;
                txtSotien_Quydoi.Properties.ReadOnly = true;
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
                if ("" + gridView_Ware_Phieuthu_Congno.GetFocusedRowCellValue("Id_Phieuthu_Congno") != "")
                {
                    _id_phieuthu_congno = Convert.ToInt64(gridView_Ware_Phieuthu_Congno.GetFocusedRowCellValue("Id_Phieuthu_Congno"));
                    dsCollection_chitiet = objWareService.Get_Ware_Phieuthu_Congno_chitiet_ByPCCongno(_id_phieuthu_congno).ToDataSet();
                    dgware_Phieu_Thu_Congno_Chitiet.DataSource = dsCollection_chitiet;
                    dgware_Phieu_Thu_Congno_Chitiet.DataMember = dsCollection_chitiet.Tables[0].TableName;
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
            this.txtNguoi_Nop.DataBindings.Clear();
            this.lookUpEdit_Doituong.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Lapphieu.DataBindings.Clear();
            this.lookUpEdit_Tiente.DataBindings.Clear();
            lookUpEdit_Nhansu_Lapphieu.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtLydo.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Lydo");
                this.txtSochungtu.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Sochungtu");
                this.txtSotien_Quydoi.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Sotien_Quydoi");
                this.txtSotien_Ngoaite.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Sotien");
                this.txtTygia.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Tygia");
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Ngay_Chungtu");
                this.txtNguoi_Nop.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Nguoi_Nop");
                this.lookUpEdit_Nhansu_Lapphieu.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Id_Nhansu_Lapphieu");
                this.lookUpEdit_Tiente.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Id_Tiente");
                this.lookUpEdit_Doituong.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Id_Khachhang");
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
            this.txtDiachi.Properties.ReadOnly = true;
            this.txtNguoi_Nop.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Doituong.Properties.ReadOnly = !editTable;
            this.radioGroup1.Properties.ReadOnly = !editTable;
            this.chkNgoaite.Properties.ReadOnly = !editTable;
            this.chkPrint_Save.Properties.ReadOnly = !editTable;
            this.txtSotien_Chu.Properties.ReadOnly = !editTable;
            //this.txtSotien_Ngoaite.Properties.ReadOnly = !editTable;
            dgware_Phieu_Thu_Congno.Enabled = !editTable;
        }

        public override void ResetText()
        {
            ClearDataBindings();
            this.txtSochungtu.EditValue = "";
            this.dtNgay_Chungtu.EditValue = "";
            this.lookUpEdit_Nhansu_Lapphieu.EditValue = null;
            this.txtLydo.EditValue = "";
            this.txtSotien_Quydoi.EditValue = "";
            this.txtSotien_Ngoaite.EditValue = "";
            this.txtTygia.EditValue = "";
            this.txtSotien_Chu.EditValue = "";
            this.txtDiachi.EditValue = "";
            this.txtNguoi_Nop.EditValue = null;
            this.lookUpEdit_Doituong.EditValue = null;
            this.lookUpEdit_Tiente.EditValue = null;
            chkNgoaite.Checked = false;
            chkPrint_Save.Checked = false;
            radioGroup1.EditValue = null;
            this.dsCollection_chitiet = objWareService.Ware_Congno_Khachhang(0).ToDataSet();
            this.dgware_Phieu_Thu_Congno_Chitiet.DataSource = dsCollection_chitiet;
            this.dgware_Phieu_Thu_Congno_Chitiet.DataMember = dsCollection_chitiet.Tables[0].TableName;

        }

        public object InsertObject()
        {
            try
            {
              

                Ecm.WebReferences.WareService.Ware_Phieuthu_Congno objWare_Phieuthu_Congno = new Ecm.WebReferences.WareService.Ware_Phieuthu_Congno();
                objWare_Phieuthu_Congno.Id_Phieuthu_Congno = -1;
                objWare_Phieuthu_Congno.Lydo = txtLydo.EditValue;
                objWare_Phieuthu_Congno.Sochungtu = txtSochungtu.EditValue;
                objWare_Phieuthu_Congno.Sotien_Quydoi = txtSotien_Quydoi.EditValue;
                objWare_Phieuthu_Congno.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Phieuthu_Congno.Id_Khachhang = lookUpEdit_Doituong.EditValue;
                objWare_Phieuthu_Congno.Nguoi_Nop = txtNguoi_Nop.EditValue;
                objWare_Phieuthu_Congno.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;
                if (chkNgoaite.Checked == true)
                {
                    objWare_Phieuthu_Congno.Sotien = txtSotien_Ngoaite.EditValue;
                    objWare_Phieuthu_Congno.Tygia = txtTygia.EditValue;
                    objWare_Phieuthu_Congno.Id_Tiente = lookUpEdit_Tiente.EditValue;
                }
                else
                {
                    objWare_Phieuthu_Congno.Sotien = null;
                    objWare_Phieuthu_Congno.Tygia = null;
                    objWare_Phieuthu_Congno.Id_Tiente = -1;
                }

                int identity = (int)objWareService.Insert_Ware_Phieuthu_Congno(objWare_Phieuthu_Congno);

                for (int i = 0; i < gridView_Ware_Phieuthu_Congno_chitiet.RowCount; i++)
                {
                    if (Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Trakynay")) > 0)
                    {
                        Ecm.WebReferences.WareService.Ware_Phieuthu_Congno_Chitiet objWare_Phieuthu_Congno_chitiet = new Ecm.WebReferences.WareService.Ware_Phieuthu_Congno_Chitiet();
                        objWare_Phieuthu_Congno_chitiet.Id_Phieuthu_Congno = identity;
                        objWare_Phieuthu_Congno_chitiet.Chungtu_Goc = String.Format("{0}", gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Sochungtu"));
                        objWare_Phieuthu_Congno_chitiet.Sotien = Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Tongtien"));
                        objWare_Phieuthu_Congno_chitiet.Sotien_Thanhtoan = Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Tratruoc"));
                        objWare_Phieuthu_Congno_chitiet.Sotien_No = Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Tienno"));
                        objWare_Phieuthu_Congno_chitiet.Sotien_Thanhtoan_Trongky = Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Trakynay"));
                        objWare_Phieuthu_Congno_chitiet.Sotien_No_Trongky = Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Connokynay"));

                        objWareService.Insert_Ware_Phieuthu_Congno_chitiet(objWare_Phieuthu_Congno_chitiet);
                    }
                }
                radioGroup1.EditValue = null;
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

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phieuthu_Congno objWare_Phieuthu_Congno = new Ecm.WebReferences.WareService.Ware_Phieuthu_Congno();
                objWare_Phieuthu_Congno.Id_Phieuthu_Congno = _id_phieuthu_congno;
                objWare_Phieuthu_Congno.Lydo = txtLydo.EditValue;
                objWare_Phieuthu_Congno.Sochungtu = txtSochungtu.EditValue;
                objWare_Phieuthu_Congno.Sotien_Quydoi = txtSotien_Quydoi.EditValue;
                objWare_Phieuthu_Congno.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Phieuthu_Congno.Id_Khachhang = lookUpEdit_Doituong.EditValue;
                objWare_Phieuthu_Congno.Nguoi_Nop = txtNguoi_Nop.EditValue;
                objWare_Phieuthu_Congno.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;
                if (chkNgoaite.Checked == true)
                {
                    objWare_Phieuthu_Congno.Sotien = txtSotien_Ngoaite.EditValue;
                    objWare_Phieuthu_Congno.Tygia = txtTygia.EditValue;
                    objWare_Phieuthu_Congno.Id_Tiente = lookUpEdit_Tiente.EditValue;
                }
                else
                {
                    objWare_Phieuthu_Congno.Sotien = null;
                    objWare_Phieuthu_Congno.Tygia = null;
                    objWare_Phieuthu_Congno.Id_Tiente = -1;
                }

                objWareService.Update_Ware_Phieuthu_Congno(objWare_Phieuthu_Congno);

                objWareService.Delete_Ware_Phieuthu_Congno_chitiet(_id_phieuthu_congno);

                for (int i = 0; i < gridView_Ware_Phieuthu_Congno_chitiet.RowCount; i++)
                {
                    if (Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Trakynay")) > 0)
                    {
                        Ecm.WebReferences.WareService.Ware_Phieuthu_Congno_Chitiet objWare_Phieuthu_Congno_chitiet = new Ecm.WebReferences.WareService.Ware_Phieuthu_Congno_Chitiet();
                        objWare_Phieuthu_Congno_chitiet.Id_Phieuthu_Congno = _id_phieuthu_congno;
                        objWare_Phieuthu_Congno_chitiet.Chungtu_Goc = gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Sochungtu");
                        objWare_Phieuthu_Congno_chitiet.Sotien = Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Tongtien"));
                        objWare_Phieuthu_Congno_chitiet.Sotien_Thanhtoan = Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Tratruoc"));
                        objWare_Phieuthu_Congno_chitiet.Sotien_No = Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Tienno"));
                        objWare_Phieuthu_Congno_chitiet.Sotien_Thanhtoan_Trongky = Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Trakynay"));
                        objWare_Phieuthu_Congno_chitiet.Sotien_No_Trongky = Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Connokynay"));

                        objWareService.Insert_Ware_Phieuthu_Congno_chitiet(objWare_Phieuthu_Congno_chitiet);
                    }
                }
                radioGroup1.EditValue = null;

                //dsCollection_chitiet.AcceptChanges();
                //objWareService.Update_Ware_Phieuthu_Congno_chitiet_Collection(dsCollection_chitiet);
                
                return true;
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Phieuthu_Congno objWare_Phieuthu_Congno = new Ecm.WebReferences.WareService.Ware_Phieuthu_Congno();
            objWare_Phieuthu_Congno.Id_Phieuthu_Congno = gridView_Ware_Phieuthu_Congno.GetFocusedRowCellValue("Id_Phieuthu_Congno");
            return objWareService.Delete_Ware_Phieuthu_Congno(objWare_Phieuthu_Congno);
        }

        public override bool PerformAdd()
        {
            this.ResetText();
            this.ChangeStatus(true);
            lookUpEdit_Nhansu_Lapphieu.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            dtThang_Nam.EditValue = objWareService.GetServerDateTime().Month + "/" + objWareService.GetServerDateTime().Year;
            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_phieuthu_congno", "sochungtu", "THUCN");
            txtSotien_Quydoi.EditValue = string.Empty;
            txtSotien_Chu.EditValue = string.Empty;
            this.dsCollection_chitiet = objWareService.Ware_Congno_Khachhang(0).ToDataSet();
            this.dgware_Phieu_Thu_Congno_Chitiet.DataSource = dsCollection_chitiet;
            this.dgware_Phieu_Thu_Congno_Chitiet.DataMember = dsCollection_chitiet.Tables[0].TableName;

            return true;
        }

        public override bool PerformEdit()
        {
            try
            {
                if ("" + _id_phieuthu_congno != "")
                {
                    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "Ware_Phieuthu_Congno";
                    DocumentProcessStatus.PK_Name = "Id_Phieuthu_Congno";
                    DocumentProcessStatus.Identity = gridView_Ware_Phieuthu_Congno.GetFocusedRowCellValue("Id_Phieuthu_Congno");
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
                    this.ChangeStatus(true);

                    this.lookUpEdit_Doituong.Properties.ReadOnly = true;
                    lookUpEdit_Doituong.Properties.Buttons[1].Enabled = false;

                    if ("" + Sotien_Quydoi == "")
                        chkNgoaite.Checked = false;
                    else
                        chkNgoaite.Checked = true;
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
        }

        public override bool PerformCancel()
        {
            ResetText();
            this.DisplayInfo();
            radioGroup1.EditValue = null;
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                txtSotien_Quydoi.Focus();
                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                htbControl1.Add(lookUpEdit_Doituong, lblKhachhang.Text);
                htbControl1.Add(txtNguoi_Nop, lblNguoi_Nop.Text);
                htbControl1.Add(txtLydo, lblLydo.Text);
                //htbControl1.Add(radioGroup1, "Hình thức thu");
                htbControl1.Add(txtSotien_Quydoi, lblSotien_Quydoi.Text);

                if (chkNgoaite.Checked == true)
                {
                    htbControl1.Add(txtSotien_Ngoaite, lblSotien_Ngoaite.Text);
                    htbControl1.Add(lookUpEdit_Tiente, lblTiente.Text);
                }

                if (gridView_Ware_Phieuthu_Congno_chitiet.RowCount == 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Không thể lập phiếu thu vì không có nợ.");
                    return false;
                }

                if ("" + txtSotien_Quydoi.EditValue != "")
                {
                    if(Convert.ToDecimal(txtSotien_Quydoi.EditValue).Equals(0))
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền thu phải lớn hơn 0.");
                        return false;
                    }
                }
                else
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền thu phải lớn hơn 0.");
                    return false;
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
                if ("" + _id_phieuthu_congno != "")
                {
                    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "Ware_Phieuthu_Congno";
                    DocumentProcessStatus.PK_Name = "Id_Phieuthu_Congno";
                    DocumentProcessStatus.Identity = gridView_Ware_Phieuthu_Congno.GetFocusedRowCellValue("Id_Phieuthu_Congno");
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
                     GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Phieu_thu"),
                     GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Phieu_thu")   }) == DialogResult.Yes)
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
                if ("" + _id_phieuthu_congno != "")
                {
                    //show form ShowFormDocProgress
                     GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                        "Ware_Phieuthu_Congno" //Table name
                        , "Id_Phieuthu_Congno" //PK name
                        , gridView_Ware_Phieuthu_Congno.GetFocusedRowCellValue("Id_Phieuthu_Congno") //value
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
                if ("" + _id_phieuthu_congno != "")
                {
                    //show form ShowFormDocProgress
                     GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                        "Ware_Phieuthu_Congno" //Table name
                        , "Id_Phieuthu_Congno" //PK name
                        , gridView_Ware_Phieuthu_Congno.GetFocusedRowCellValue("Id_Phieuthu_Congno") //value
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
            if ("" + _id_phieuthu_congno != "")
            {
                Reports.rptPhieu_Thu rptPhieu_Thu = new Ecm.Ware.Reports.rptPhieu_Thu();
                 GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = rptPhieu_Thu;
                //add parameter values
                rptPhieu_Thu.tbcDiachi.Text = txtDiachi.Text;
                rptPhieu_Thu.tbcLydo.Text = txtLydo.Text;
                rptPhieu_Thu.tbcNam.Text = "" + dtNgay_Chungtu.DateTime.Year;
                rptPhieu_Thu.tbcThang.Text = "" + dtNgay_Chungtu.DateTime.Month;
                rptPhieu_Thu.tbcNgay.Text = "" + dtNgay_Chungtu.DateTime.Day;
                rptPhieu_Thu.tbcNguoi_Noptien.Text = "" + txtNguoi_Nop.Text;
                rptPhieu_Thu.tbcNguoi_Noptien_Kyten.Text = "" + txtNguoi_Nop.Text;
                rptPhieu_Thu.tbcNhansu_Lapphieu.Text = "" + lookUpEdit_Nhansu_Lapphieu.Text;
                rptPhieu_Thu.tbcSochungtu.Text = txtSochungtu.Text;
                double sotien = 0;
                string str = "";
                if ("" + txtSotien_Ngoaite.EditValue != "")
                {
                    sotien = Convert.ToDouble(txtSotien_Ngoaite.EditValue);
                    rptPhieu_Thu.tbcSotien.Text = string.Format("{0:#,#}", txtSotien_Ngoaite.EditValue);
                    str =  GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(sotien, " " + lookUpEdit_Tiente.Text + ".");
               
                }
                else
                {
                    sotien = Convert.ToDouble(txtSotien_Quydoi.EditValue);
                    rptPhieu_Thu.tbcSotien.Text = string.Format("{0:#,#}", txtSotien_Quydoi.EditValue);
                    str =  GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(sotien, " đồng.");
               
                }
              
                str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
                rptPhieu_Thu.tbcSotien_Bangchu.Text = str;

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

                    rptPhieu_Thu.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    rptPhieu_Thu.xrc_CompanyAddress.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                }

                #endregion

                rptPhieu_Thu.CreateDocument();
                 GoobizFrame.Windows.Forms.ReportOptions oReportOptions =  GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptPhieu_Thu);
                 if (Convert.ToBoolean(oReportOptions.PrintPreview))
                 {
                     frmPrintPreview.Text = "" + oReportOptions.Caption;
                     frmPrintPreview.printControl1.PrintingSystem = rptPhieu_Thu.PrintingSystem;
                     frmPrintPreview.MdiParent = this.MdiParent;
                     frmPrintPreview.Show();
                     frmPrintPreview.Activate();
                 }
                 else
                 {
                     var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptPhieu_Thu);
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
                        Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add frmware_Dm_Doituong = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add();
                        frmware_Dm_Doituong.StartPosition = FormStartPosition.CenterScreen;
                        frmware_Dm_Doituong.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        frmware_Dm_Doituong.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        frmware_Dm_Doituong.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        frmware_Dm_Doituong.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        frmware_Dm_Doituong.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        frmware_Dm_Doituong.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        frmware_Dm_Doituong.ChangeFormState( GoobizFrame.Windows.Forms.FormState.View);
                        frmware_Dm_Doituong.gvDm_Khahhang.OptionsBehavior.Editable = false;
                        frmware_Dm_Doituong.ShowDialog();
                        if (frmware_Dm_Doituong.Id_Khachhang != null)
                        {
                            this.lookUpEdit_Doituong.EditValue = frmware_Dm_Doituong.Id_Khachhang[0];
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

        private void lookUpEdit_Doituong_EditValueChanged_1(object sender, EventArgs e)
        {
            if ("" + lookUpEdit_Doituong.EditValue != "")
            {
                this.txtDiachi.EditValue = lookUpEdit_Doituong.GetColumnValue("Diachi_Khachhang");
                this.dsCollection_chitiet = objWareService.Ware_Congno_Khachhang(lookUpEdit_Doituong.EditValue).ToDataSet();
                this.dgware_Phieu_Thu_Congno_Chitiet.DataSource = dsCollection_chitiet;
                this.dgware_Phieu_Thu_Congno_Chitiet.DataMember = dsCollection_chitiet.Tables[0].TableName;
            }
        }

        private void txtSotien_Quydoi_EditValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (txtSotien_Quydoi.Text != "")
                {
                    double sotien_quydoi = Convert.ToDouble(txtSotien_Quydoi.Text);
                    txtSotien_Chu.Text =  GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(sotien_quydoi, " đồng.");
                    Quydoi_Ngoaite();
                }

                if ("" + radioGroup1.EditValue == "AUTO" && txtSotien_Quydoi.Text != "")
                {
                    decimal sotien_phanbo = 0;
                    try
                    {
                        sotien_phanbo = Convert.ToDecimal(txtSotien_Quydoi.Text);
                    }
                    catch (Exception ex)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền phân bổ không hợp lý, vui lòng nhập lại!");
                        txtSotien_Quydoi.EditValue = @"0";

                    }
                    if (sotien_phanbo > Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.Columns["Tienno"].SummaryItem.SummaryValue))
                    {
                        if (txtSotien_Quydoi.Tag == null)
                        {
                             GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền phân bổ không được vược quá tổng số nợ.");
                        }
                        txtSotien_Quydoi.Tag = gridView_Ware_Phieuthu_Congno_chitiet.Columns["Tienno"].SummaryItem.SummaryValue;
                        txtSotien_Quydoi.EditValue = gridView_Ware_Phieuthu_Congno_chitiet.Columns["Tienno"].SummaryItem.SummaryValue;
                        Phanbo_Tudong(Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.Columns["Tienno"].SummaryItem.SummaryValue));
                        txtSochungtu.Focus();
                    }
                    else
                    {
                        Phanbo_Tudong(sotien_phanbo);
                    }
                }
                txtSotien_Quydoi.Tag = null;
            }
            catch (Exception ex)
            {
#if ( DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ("" + radioGroup1.EditValue == "MANUAL")
                {

                    this.txtSotien_Quydoi.Text = "";
                    this.gridView_Ware_Phieuthu_Congno_chitiet.OptionsBehavior.Editable = true;
                    txtSotien_Quydoi.EditValue = gridView_Ware_Phieuthu_Congno_chitiet.Columns["Trakynay"].SummaryItem.SummaryValue;
                    txtSotien_Quydoi.Properties.ReadOnly = true;
                }

                if ("" + radioGroup1.EditValue == "AUTO")
                {

                    this.txtSotien_Quydoi.Text = "";
                    this.gridView_Ware_Phieuthu_Congno_chitiet.OptionsBehavior.Editable = false;
                    txtSotien_Quydoi.EditValue = gridView_Ware_Phieuthu_Congno_chitiet.Columns["Trakynay"].SummaryItem.SummaryValue;
                    txtSotien_Quydoi.Properties.ReadOnly = false;
                }

                if ("" + radioGroup1.EditValue == "ALL")
                {

                    this.gridView_Ware_Phieuthu_Congno_chitiet.OptionsBehavior.Editable = false;
                    Phanbo_Tudong(Convert.ToDecimal(gridView_Ware_Phieuthu_Congno_chitiet.Columns["Tienno"].SummaryItem.SummaryValue));
                    txtSotien_Quydoi.EditValue = gridView_Ware_Phieuthu_Congno_chitiet.Columns["Tienno"].SummaryItem.SummaryValue;
                    txtSotien_Quydoi.Properties.ReadOnly = true;
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
                this.lookUpEdit_Tiente.Properties.ReadOnly = false;
                lookUpEdit_Tiente.EditValue = null;
                this.txtTygia.Properties.ReadOnly = false;
                this.txtSotien_Ngoaite.Properties.ReadOnly = false;
                lblNgoaite.Text = string.Empty;
            }
            else
            {
                lookUpEdit_Tiente.EditValue = null;
                this.lookUpEdit_Tiente.Properties.ReadOnly = true;
                this.txtTygia.Properties.ReadOnly = true;
                this.txtSotien_Ngoaite.Properties.ReadOnly = true;
                this.lookUpEdit_Tiente.EditValue = string.Empty;
                this.txtTygia.EditValue = string.Empty;
                this.txtSotien_Ngoaite.EditValue = string.Empty;
                lblNgoaite.Text = string.Empty;
            }
        }
 

        private void txtTygia_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTygia.Text != "" && txtSotien_Quydoi.Text != "")
                {
                    //txtSotien_Quydoi.Text = "" + Convert.ToDecimal(txtTygia.Text) * Convert.ToDecimal(txtSotien_Ngoaite.Text);
                    Quydoi_Ngoaite();
                }
            }
            catch (Exception ex)
            {
#if ( DEBUG)
                MessageBox.Show(ex.Message);
#endif

            }
        }

        private void gridView_Ware_Phieuthu_Congno_chitiet_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Trakynay")
                {
                    decimal sotien = decimal.Parse(gridView_Ware_Phieuthu_Congno_chitiet.GetFocusedRowCellValue("Tienno").ToString());
                    decimal tientra = decimal.Parse(gridView_Ware_Phieuthu_Congno_chitiet.GetFocusedRowCellValue("Trakynay").ToString());

                    if (tientra > decimal.Parse(sotien.ToString()) && sotien > 0)
                    {

                        gridView_Ware_Phieuthu_Congno_chitiet.SetFocusedRowCellValue("Sotien_Thanhtoan_Trongky", sotien);
                        gridView_Ware_Phieuthu_Congno_chitiet.SetFocusedRowCellValue("Sotien_No_Trongky", 0);
                        gridView_Ware_Phieuthu_Congno_chitiet.SetFocusedRowCellValue("Trakynay", sotien);
                        gridView_Ware_Phieuthu_Congno_chitiet.SetFocusedRowCellValue("Connokynay", 0);

                        sotien = 0;

                    }
                    else if (tientra < decimal.Parse(sotien.ToString()) && sotien > 0)
                    {
                        gridView_Ware_Phieuthu_Congno_chitiet.SetFocusedRowCellValue("Sotien_No_Trongky", decimal.Parse(sotien.ToString()) - tientra);
                        gridView_Ware_Phieuthu_Congno_chitiet.SetFocusedRowCellValue("Sotien_Thanhtoan_Trongky", tientra);
                        gridView_Ware_Phieuthu_Congno_chitiet.SetFocusedRowCellValue("Connokynay", decimal.Parse(sotien.ToString()) - tientra);

                        sotien = 0;
                    }

                    if ("" + radioGroup1.EditValue == "MANUAL")
                    {
                        decimal _Sotien_Quydoi = 0;
                        for (int i = 0; i < gridView_Ware_Phieuthu_Congno_chitiet.RowCount; i++)
                        {
                            _Sotien_Quydoi += Convert.ToDecimal("0" + gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Trakynay"));
                        }

                        txtSotien_Quydoi.EditValue = _Sotien_Quydoi;
                    }
                    dgware_Phieu_Thu_Congno_Chitiet.Refresh();
                    gridView_Ware_Phieuthu_Congno_chitiet.RefreshData();
                }
            }
            catch (Exception ex)
            {
#if ( DEBUG)
                MessageBox.Show(ex.Message);
#endif

            }
        }

        private void gridView_Ware_Phieuthu_Congno_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DisplayInfo2();
        }

        private void chkShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            gridView_Ware_Phieuthu_Congno.OptionsView.ShowPreview = chkShowPreview.Checked;
        }

        private void dtThang_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (dtThang_Nam.Text == "")
                return;
            DateTime dtValue = dtThang_Nam.DateTime;
            gridView_Ware_Phieuthu_Congno.Columns["Thang"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView_Ware_Phieuthu_Congno.Columns["Thang"], dtValue.Month);
            gridView_Ware_Phieuthu_Congno.Columns["Nam"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gridView_Ware_Phieuthu_Congno.Columns["Nam"], dtValue.Year);

        }

        private void txtSotien_Quydoi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
                if (e.NewValue.ToString().Length > 16)
                    e.Cancel = true;
        }

        private void lookUpEdit_Tiente_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEdit_Tiente.EditValue != "")
            {
                this.txtTygia.EditValue = lookUpEdit_Tiente.GetColumnValue("Tygia_Vnd");
                if (txtTygia.Text != "")
                {
                    this.lblNgoaite.Text = lookUpEdit_Tiente.GetColumnValue("Ten_Tiente").ToString();
                    if (txtSotien_Ngoaite.Text != "")
                        txtSotien_Quydoi.EditValue = Convert.ToDecimal(txtSotien_Ngoaite.EditValue) * Convert.ToDecimal(txtTygia.EditValue);
                }
            }
        }

        private void txtTygia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
                if (e.NewValue.ToString().Length > 10)
                    e.Cancel = true;
        }
        #endregion

        #region Custom Method

        private void Phanbo_Tudong(decimal tongtien)
        {
            for (int i = 0; i < gridView_Ware_Phieuthu_Congno_chitiet.RowCount; i++)
            {
                decimal sotien = Convert.ToDecimal("0" + gridView_Ware_Phieuthu_Congno_chitiet.GetRowCellValue(i, "Tienno"));
                if (tongtien <= sotien && tongtien > 0)
                {
                    gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Sotien_Thanhtoan_Trongky", tongtien);
                    gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Sotien_No_Trongky", sotien - tongtien);
                    gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Trakynay", tongtien);
                    gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Connokynay", sotien - tongtien);


                    tongtien = 0;
                    continue;
                }
                else if (tongtien > sotien)
                {
                    gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Sotien_Thanhtoan_Trongky", sotien);
                    gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Sotien_No_Trongky", 0);
                    gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Trakynay", sotien);
                    gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Connokynay", 0);

                    tongtien = tongtien - sotien;
                    continue;
                }
                gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Sotien_Thanhtoan_Trongky", 0);
                gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Sotien_No_Trongky", 0);
                gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Trakynay", 0);
                gridView_Ware_Phieuthu_Congno_chitiet.SetRowCellValue(i, "Connokynay", 0);

            }
        }

        private void Quydoi_Ngoaite()
        {
            try
            {
                if ("" + lookUpEdit_Tiente.EditValue != "" && "" + txtTygia.EditValue != "" && "" + txtSotien_Quydoi.EditValue != "")
                {
                    txtSotien_Ngoaite.EditValue = (double)(double.Parse(txtSotien_Quydoi.Text) / double.Parse(txtTygia.Text));
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        #endregion

 
    }
}

