using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GoobizFrame.Windows.Forms;

namespace Ecm.SystemControl.SystemInfo
{
    public partial class FrmSys_Dm_Heso_Chuongtrinh :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = new Ecm.WebReferences.Classes.MasterService();
        DataSet dsDm_Heso_Chuongtrinh;
        
        // dùng Fax làm số TK 

        public FrmSys_Dm_Heso_Chuongtrinh()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            dgDm_Heso_Chuongtrinh.EmbeddedNavigator.Buttons.Remove.Visible = false;
            dgDm_Heso_Chuongtrinh.EmbeddedNavigator.Buttons.Append.Visible = false;
            DisplayInfo();
        }

        public override void ChangeStatus(bool editable)
        {            
            txtCompanyAddress.Properties.ReadOnly = !editable;
            txtCompanyAlias.Properties.ReadOnly = !editable;
            txtCompanyFax.Properties.ReadOnly = !editable;
            txtCompanyName.Properties.ReadOnly = !editable;
            txtCompanyTax.Properties.ReadOnly = !editable;
            txtCompanyTel.Properties.ReadOnly = !editable;
            btnComp_LogoAdd.Enabled = editable;
            btnComp_LogoDelete.Enabled = editable;
        }        

        #region Event Override
        public override void DisplayInfo()
        {
            dsDm_Heso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
            dgDm_Heso_Chuongtrinh.DataSource = dsDm_Heso_Chuongtrinh;
            dgDm_Heso_Chuongtrinh.DataMember = dsDm_Heso_Chuongtrinh.Tables[0].TableName;

            this.Data = dsDm_Heso_Chuongtrinh;
            this.GridControl = dgDm_Heso_Chuongtrinh;

            gridView1.BestFitColumns();
            ChangeStatus(false);
            DisplayInfo_Company();
            base.DisplayInfo();
        }

        public override bool PerformEdit()
        {
            ChangeStatus(true);
            return base.PerformEdit();
        }

        public override bool PerformCancel()
        {
            dsDm_Heso_Chuongtrinh.RejectChanges();
            DisplayInfo();
            return base.PerformCancel();
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Heso_Chuongtrinh"], "");
            //hashtableControls.Add(gridView1.Columns["Heso"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                dgDm_Heso_Chuongtrinh.EmbeddedNavigator.Buttons.DoClick(dgDm_Heso_Chuongtrinh.EmbeddedNavigator.Buttons.EndEdit);
                //dsDm_Heso_Chuongtrinh.Tables[0].Columns["Ma_Heso_Chuongtrinh"].Unique = true;
                objMasterService.Update_Rex_Dm_Heso_Chuongtrinh_Collection(this.dsDm_Heso_Chuongtrinh);
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);

                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { gridView1.Columns["Ma_Heso_Chuongtrinh"].Caption, gridView1.Columns["Ma_Heso_Chuongtrinh"].Caption.ToLower() });
                    return false;
                }
                else
                    MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyAddress'")[0]["Heso"] = txtCompanyAddress.EditValue;
                dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyAlias'")[0]["Heso"] = txtCompanyAlias.EditValue;
                dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyFax'")[0]["Heso"] = txtCompanyFax.EditValue; // dùng Fax làm số TK 
                dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyName'")[0]["Heso"] = txtCompanyName.EditValue;
                dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyTax'")[0]["Heso"] = txtCompanyTax.EditValue;
                dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyTel'")[0]["Heso"] = txtCompanyTel.EditValue;
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }
            if (picCompanyLogo.Image != null)
            {
                //get image source and resize it
                Image srcImage = picCompanyLogo.Image;
                int percentSize = (srcImage.Width > 100) ? 100 * 100 / srcImage.Width : 100;
                Image hinh =  GoobizFrame.Windows.ImageUtils.ImageResize.ScaleByPercent(srcImage, percentSize);
                //save image to memory
                MemoryStream ms = new MemoryStream();
                hinh.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageData = ms.GetBuffer();
                //asign image in buffer to property Hinh
                dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyLogo'")[0]["Heso"] = Convert.ToBase64String(imageData);
            }
            else
            {
                picCompanyLogo.Image = null;
            }
            PerformSaveChanges();
            return base.PerformSave();
        }
        #endregion

        #region Company
        void DisplayInfo_Company()
        {
            try
            {
                txtCompanyAddress.EditValue = dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyAddress'")[0]["Heso"];
                txtCompanyAlias.EditValue = dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyAlias'")[0]["Heso"];
                txtCompanyFax.EditValue = dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyFax'")[0]["Heso"];
                txtCompanyName.EditValue = dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyName'")[0]["Heso"];
                txtCompanyTax.EditValue = dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyTax'")[0]["Heso"];
                txtCompanyTel.EditValue = dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyTel'")[0]["Heso"];
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }

            //Get image data from gridview column.
            try
            {
                object logo = dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyLogo'")[0]["Heso"];
                if ("" + logo != "")
                {
                    byte[] imagedata = Convert.FromBase64String("" + logo);

                    //Read image data into a memory stream
                    MemoryStream ms = new MemoryStream(imagedata, 0, imagedata.Length);

                    ms.Write(imagedata, 0, imagedata.Length);

                    //Set image variable value using memory stream.
                    Image image = Image.FromStream(ms, true);

                    picCompanyLogo.Image = image;
                    picCompanyLogo.Update();
                }
                else
                {
                    picCompanyLogo.Image = null;
                }
            }
            catch { }
        }
       
        #endregion

        private void btnComp_LogoAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tập tin hình ảnh (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult != DialogResult.Cancel)
            {
                picCompanyLogo.Image = Image.FromFile( openFileDialog.FileName );
            }
        }

        private void btnComp_LogoDelete_Click(object sender, EventArgs e)
        {
            picCompanyLogo.Image = null;
        }
    
    }
}

