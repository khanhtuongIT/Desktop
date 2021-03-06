using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.SystemControl.SystemInfo
{
    public partial class FrmThemeInfo : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        private Reports.rptTemplate rptTemplate = new SunLine.SystemControl.Reports.rptTemplate();

        public FrmThemeInfo()
        {
            InitializeComponent();
            //this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
            DisplayInfo();
        }

        #region override event
        public override void DisplayInfo()
        {
            #region theme
            picCompanyLogo.Image        = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCompanyLogo();
            btnCompanyLogoPath.Text     = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCompanyLogoPath();
            txtCompanyName.Text         = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCompanyName();
            txtCompanyAlias.Text        = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCompanyAlias();
            txtCompanyAddress.Text      = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCompanyAddress();
            txtCompanyTel.Text          = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCompanyTel();
            txtCompanyFax.Text          = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCompanyFax();
            txtMasothue.Text            = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCompany_Masothue();
            //show report template            
            rptTemplate.xrPictureBox1.Image = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCompanyLogo();
            rptTemplate.xrLabel1.Text       = txtCompanyName.Text;
            rptTemplate.xrLabel2.Text       = txtCompanyAlias.Text;
            rptTemplate.xrLabel3.Text       = txtCompanyAddress.Text;
            rptTemplate.xrLabel4.Text       = txtCompanyTel.Text;
            rptTemplate.xrLabel5.Text       = txtCompanyFax.Text;
            printControl1.PrintingSystem = rptTemplate.PrintingSystem;
            rptTemplate.CreateDocument();
            #endregion
            #region DisplayFormat
            txtDateTimeFormat.Text = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetDateTimeFormat();
            txtDateTimeFormat_Sample.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtDateTimeFormat_Sample.Properties.DisplayFormat.FormatString =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetDateTimeFormat();
            
            txtLongDateTimeFormat.Text = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLongDateTimeFormat();
            txtLongDateTimeFormat_Sample.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtLongDateTimeFormat_Sample.Properties.DisplayFormat.FormatString = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLongDateTimeFormat();

            txtNumericFormat.Text = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetNumericFormat();
            txtNumericFormat_Sample.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtNumericFormat_Sample.Properties.DisplayFormat.FormatString = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetNumericFormat();
            #endregion
        }
        
        public override bool PerformSave()
        {
            //theme
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCompanyLogoPath(btnCompanyLogoPath.Text);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCompanyName(txtCompanyName.Text);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCompanyAlias(txtCompanyAlias.Text);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCompanyAddress(txtCompanyAddress.Text);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCompanyTel(txtCompanyTel.Text);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCompanyFax(txtCompanyFax.Text);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetCompany_Masothue(txtMasothue.Text);
            //DisplayFormat
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDateTimeFormat(txtDateTimeFormat.Text);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetLongDateTimeFormat(txtLongDateTimeFormat.Text);
            GoobizFrame.Windows.MdiUtils.ThemeSettings.SetNumericFormat(txtNumericFormat.Text);
            DisplayInfo();
            return true;
        }
        #endregion

        private void txtDateTimeFormat_Validating(object sender, CancelEventArgs e)
        {
            txtDateTimeFormat_Sample.Properties.DisplayFormat.FormatString = txtDateTimeFormat.Text;
        }

        private void txtLongDateTimeFormat_Validating(object sender, CancelEventArgs e)
        {
            txtLongDateTimeFormat_Sample.Properties.DisplayFormat.FormatString = txtLongDateTimeFormat.Text;

        }

        private void txtNumericFormat_Validating(object sender, CancelEventArgs e)
        {
            txtNumericFormat_Sample.Properties.DisplayFormat.FormatString = txtNumericFormat.Text;
        }

        private void btnCompanyLogoPath_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                picCompanyLogo.Image = Image.FromFile(btnCompanyLogoPath.Text);
                rptTemplate.xrPictureBox1.Image = Image.FromFile(btnCompanyLogoPath.Text);
                rptTemplate.CreateDocument();
            }
            catch(Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
            }
        }

        private void txtCompanyName_Validating(object sender, CancelEventArgs e)
        {
            rptTemplate.xrLabel1.Text = txtCompanyName.Text;
            rptTemplate.CreateDocument();
        }

        private void txtCompanyAlias_Validating(object sender, CancelEventArgs e)
        {
            rptTemplate.xrLabel2.Text = txtCompanyAlias.Text;
            rptTemplate.CreateDocument();
        }

        private void txtCompanyAddress_Validating(object sender, CancelEventArgs e)
        {
            rptTemplate.xrLabel3.Text = txtCompanyAddress.Text;
            rptTemplate.CreateDocument();
        }

        private void txtCompanyTel_Validating(object sender, CancelEventArgs e)
        {
            rptTemplate.xrLabel4.Text = txtCompanyTel.Text;
            rptTemplate.CreateDocument();
        }

        private void txtCompanyFax_Validating(object sender, CancelEventArgs e)
        {
            rptTemplate.xrLabel5.Text = txtCompanyFax.Text;
            rptTemplate.CreateDocument();
        }


        private void btnCompanyLogoPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tập tin hình ảnh (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                btnCompanyLogoPath.Text = openFileDialog.FileName;
        }
    }
}

