using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TruthPos.MasterTables.Forms.Bar
{
    public partial class Frmbar_Dm_Table_Add :  itvs.Windows.Forms.FormUpdateWithToolbar
    {
        public TruthPos.WebReferences.Classes.MasterService objMasterService = new TruthPos.WebReferences.Classes.MasterService();
        DataSet ds_Collection = new DataSet();
        //string xml_BAR_DM_TABLE_VITRI = @"Resources\localdata\BAR_DM_TABLE_VITRI.xml";

        public Frmbar_Dm_Table_Add()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban();
                lookUp_Cuahang_Ban.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
                gridLookUp_Cuahang_Ban.DataSource = ds_Cuahang_Ban.Tables[0];

                ds_Collection = objMasterService.Get_All_Bar_Dm_Table();
                dgbar_Dm_Table.DataSource = ds_Collection;
                dgbar_Dm_Table.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgbar_Dm_Table;
                this.DataBindingControl();
                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                ////TruthPos.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ClearDataBindings()
        {
            this.txtId_Table.DataBindings.Clear();
            this.txtMa_Table.DataBindings.Clear();
            this.txtTen_Table.DataBindings.Clear();
            this.txtVitri.DataBindings.Clear();
            this.txtSoluong.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.lookUp_Cuahang_Ban.DataBindings.Clear();
            this.pictureEdit_Hinh.DataBindings.Clear();
        }
        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Table.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Table");
                this.txtMa_Table.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Table");
                this.txtTen_Table.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Table");
                this.txtVitri.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Vitri");
                this.txtSoluong.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Soluong");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ghichu");
                this.lookUp_Cuahang_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Khuvuc");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                ////TruthPos.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgbar_Dm_Table.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = !editTable;
            this.txtMa_Table.Properties.ReadOnly = !editTable;
            this.txtTen_Table.Properties.ReadOnly = !editTable;
            this.txtVitri.Properties.ReadOnly = !editTable;
            this.txtSoluong.Properties.ReadOnly = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.lookUp_Cuahang_Ban.Properties.ReadOnly = !editTable;
            this.btnThemhinh.Enabled = editTable;
            this.btnXoahinh.Enabled = editTable;
        }

        public override void ResetText()
        {
            this.txtId_Table.EditValue = null;
            this.txtMa_Table.EditValue = null;
            this.txtTen_Table.EditValue = null;
            this.txtVitri.EditValue = null;
            this.txtGhichu.EditValue = null;
            this.txtSoluong.EditValue = null;
            this.pictureEdit_Hinh.Image = null;
        }

        #region Event Override
        public object InsertObject()
        {
            TruthPos.WebReferences.MasterService.Bar_Dm_Table objBar_Dm_Table = new TruthPos.WebReferences.MasterService.Bar_Dm_Table();
            objBar_Dm_Table.Id_Table = -1;
            objBar_Dm_Table.Ma_Table = txtMa_Table.EditValue;
            objBar_Dm_Table.Ten_Table = txtTen_Table.EditValue;
            objBar_Dm_Table.Vitri = txtVitri.EditValue;
            objBar_Dm_Table.Ghichu = (txtGhichu.EditValue == null) ? null : txtGhichu.EditValue;
            objBar_Dm_Table.Id_Khuvuc = lookUp_Cuahang_Ban.EditValue;
            if ("" + txtSoluong.EditValue != "")
                objBar_Dm_Table.Soluong = txtSoluong.EditValue;

            if (pictureEdit_Hinh.Image != null)
            {
                //get image source and resize it
                Image srcImage = Image.FromFile(pictureEdit_Hinh.ImageLocation);

                int percentSize = (srcImage.Width > 100) ? 100 * 100 / srcImage.Width : 100;
                Image hinh =  itvs.Windows.ImageUtils.ImageResize.ScaleByPercent(srcImage, percentSize);
                //save image to memory
                MemoryStream ms = new MemoryStream();
                hinh.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageData = ms.GetBuffer();
                //asign image in buffer to property Hinh
                objBar_Dm_Table.Hinh = imageData;
            }
            return objMasterService.Insert_Bar_Dm_Table(objBar_Dm_Table);
        }

        public object UpdateObject()
        {
            TruthPos.WebReferences.MasterService.Bar_Dm_Table objBar_Dm_Table = new TruthPos.WebReferences.MasterService.Bar_Dm_Table();
            objBar_Dm_Table.Id_Table = gridView1.GetFocusedRowCellValue("Id_Table");
            objBar_Dm_Table.Ma_Table = txtMa_Table.EditValue;
            objBar_Dm_Table.Ten_Table = txtTen_Table.EditValue;
            objBar_Dm_Table.Vitri = txtVitri.EditValue;
            objBar_Dm_Table.Ghichu = (txtGhichu.EditValue == null) ? null : txtGhichu.EditValue;
            //objBar_Dm_Table.Id_Khuvuc = lookUpEdit_Cuahang_Ban.EditValue;
            //objBar_Dm_Table.id
            if ("" + txtSoluong.EditValue != "")
                objBar_Dm_Table.Soluong = txtSoluong.EditValue;

            if (pictureEdit_Hinh.Image != null)
            {
                Image srcImage = null;
                if (pictureEdit_Hinh.ImageLocation != null)
                    //get image source and resize it
                    srcImage = Image.FromFile(pictureEdit_Hinh.ImageLocation);
                else
                    srcImage = pictureEdit_Hinh.Image;
                int percentSize = (srcImage.Width > 100) ? 100 * 100 / srcImage.Width : 100;
                Image hinh =  itvs.Windows.ImageUtils.ImageResize.ScaleByPercent(srcImage, percentSize);

                //save image to memory
                MemoryStream ms = new MemoryStream();
                hinh.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageData = ms.GetBuffer();
                //asign image in buffer to property Hinh
                objBar_Dm_Table.Hinh = imageData;
            }
            objBar_Dm_Table.Id_Khuvuc = lookUp_Cuahang_Ban.EditValue;
            return objMasterService.Update_Bar_Dm_Table(objBar_Dm_Table);
        }

        public object DeleteObject()
        {
            TruthPos.WebReferences.MasterService.Bar_Dm_Table objBar_Dm_Table = new TruthPos.WebReferences.MasterService.Bar_Dm_Table();
            objBar_Dm_Table.Id_Table = gridView1.GetFocusedRowCellValue("Id_Table");
            return objMasterService.Delete_Bar_Dm_Table(objBar_Dm_Table);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            this.ChangeStatus(true);
            return true;
        }

        public override bool PerformCancel()
        {
            ResetText();
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                 itvs.Windows.Public.OrderHashtable hashtableControls = new  itvs.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Table, lblMa_Table.Text);
                hashtableControls.Add(txtTen_Table, lblTen_Table.Text);
                hashtableControls.Add(lookUp_Cuahang_Ban, lblKho.Text);

                System.Collections.Hashtable htbTen_Table = new System.Collections.Hashtable();
                htbTen_Table.Add(txtTen_Table, lblTen_Table.Text);

                if (! itvs.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState ==  itvs.Windows.Forms.FormState.Add)
                {
                    if (! itvs.Windows.MdiUtils.Validator.CheckExistValues(htbTen_Table, ds_Collection, "Ten_Table"))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  itvs.Windows.Forms.FormState.Edit)
                {
                    DataSet _ds =  itvs.Windows.MdiUtils.Validator.datasetFillter(ds_Collection, "Id_Table = " + gridView1.GetFocusedRowCellValue("Id_Table"));
                    if (! itvs.Windows.MdiUtils.Validator.CheckExistValues(htbTen_Table, _ds, "Ten_Table"))
                        return false;
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    //DataSet ds_Bar_Dm_Table_Vitri = objMasterService.Get_All_ViTri_Dm_Bar_Table();
                    //if (System.IO.File.Exists(xml_BAR_DM_TABLE_VITRI))
                    //    ds_Bar_Dm_Table_Vitri.WriteXml(xml_BAR_DM_TABLE_VITRI, XmlWriteMode.WriteSchema);
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                     itvs.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Table.Text, lblMa_Table.Text });
                }
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {
             itvs.Windows.Public.OrderHashtable hashtableControls = new  itvs.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Table"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Table"], "");
            hashtableControls.Add(gridView1.Columns["Id_Khuvuc"], "");
            if (! itvs.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            System.Collections.Hashtable htbTen_Table = new System.Collections.Hashtable();
            htbTen_Table.Add(gridView1.Columns["Ten_Table"], "");
            if (! itvs.Windows.MdiUtils.Validator.CheckExistGrid(htbTen_Table, gridView1))
                return false;
            try
            {
                dgbar_Dm_Table.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Table.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Table"].Unique = true;
                objMasterService.Update_Bar_Dm_Table_Collection(this.ds_Collection);
                //DataSet ds_Bar_Dm_Table_Vitri = objMasterService.Get_All_ViTri_Dm_Bar_Table();
                //if (System.IO.File.Exists(xml_BAR_DM_TABLE_VITRI))
                //    ds_Bar_Dm_Table_Vitri.WriteXml(xml_BAR_DM_TABLE_VITRI, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     itvs.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Table.Text, lblMa_Table.Text });
                    return false;
                }


            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if ( itvs.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             itvs.Windows.Forms.UserMessage.GetTableDescription("Bar_Dm_Table"),
             itvs.Windows.Forms.UserMessage.GetTableRelations("Bar_Dm_Table")   }) == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Bar_Dm_Table", "Id_Table", this.gridView1.GetFocusedRowCellValue("Id_Table"))) > 0)
                    {
                         itvs.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                     itvs.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    // itvs.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            TruthPos.WebReferences.MasterService.Bar_Dm_Table bar_Dm_Table = new TruthPos.WebReferences.MasterService.Bar_Dm_Table();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    bar_Dm_Table.Id_Table = dr["Id_Table"];
                    bar_Dm_Table.Ma_Table = dr["Ma_Table"];
                    bar_Dm_Table.Ten_Table = dr["Ten_Table"];
                    bar_Dm_Table.Vitri = dr["Vitri"];
                    bar_Dm_Table.Soluong = dr["Soluong"];
                    bar_Dm_Table.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return bar_Dm_Table;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }
        #endregion

        #region Even

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Ma_Table"];
            this.addnewrow_clicked = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            this.dgbar_Dm_Table.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Table.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void btnThemhinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult != DialogResult.Cancel)
            {
                pictureEdit_Hinh.ImageLocation = openFileDialog.FileName;
                //lbl_pathImage.Text = openFileDialog.FileName;
            }
        }

        private void btnXoahinh_Click(object sender, EventArgs e)
        {
            pictureEdit_Hinh.Image = null;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //Get image data from gridview column.
            if ("" + gridView1.GetFocusedRowCellValue("Hinh") != "")
            {
                byte[] imagedata = (byte[])gridView1.GetFocusedRowCellValue("Hinh");
                //Read image data into a memory stream
                MemoryStream ms = new MemoryStream(imagedata, 0, imagedata.Length);

                ms.Write(imagedata, 0, imagedata.Length);
                //Set image variable value using memory stream.
                Image image = Image.FromStream(ms, true);
                pictureEdit_Hinh.Image = image;
            }
            else
                pictureEdit_Hinh.Image = null;
        }

        private void dgbar_Dm_Table_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ("" + this.gridView1.GetFocusedRowCellValue("Id_Table") != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Bar_Dm_Table", "Id_Table", this.gridView1.GetFocusedRowCellValue("Id_Table"))) > 0)
                    {
                         itvs.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
                gridView1.OptionsBehavior.Editable = true;
        }

        private void txtSoluong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
                if (e.NewValue.ToString().Length > 15)
                    e.Cancel = true;
        }

        private void repositoryItemTextEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString().Length > 15)
                    e.Cancel = true;
                if (e.NewValue.ToString().Length == 0)
                {
                    gridView1.SetFocusedRowCellValue(gridView1.FocusedColumn, null);
                    e.Cancel = true;
                }
            }
        }

        private void txtMa_Table_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;
        }

        #endregion



    }
}

