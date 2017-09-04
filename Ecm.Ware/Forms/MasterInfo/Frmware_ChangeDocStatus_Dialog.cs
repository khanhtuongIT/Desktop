using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_ChangeDocStatus_Dialog : DevExpress.XtraEditors.XtraForm
    {
        public SunLine.WebReferences.Classes.RexService objRexService = new SunLine.WebReferences.Classes.RexService();
        public SunLine.WebReferences.Classes.WareService objWareService = new SunLine.WebReferences.Classes.WareService();
        public WareService.DocumentProcessStatus DocumentProcessStatus = new SunLine.Ware.WareService.DocumentProcessStatus();
        public string TableName;
        public string PK_Name;
        public object Identity;
        public WareService.EDocumentProcessStatus NEWDocumentProcessStatus;
        WareService.EDocumentProcessStatus EDocumentProcessStatus;

        public Frmware_ChangeDocStatus_Dialog()
        {
            InitializeComponent();
           
        }

        void DisplayInfo()
        {
            //Get data Rex_Nhansu
            lookUpEdit_Nhansu.Properties.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().Tables[0];
            lookUpEdit_Nhansu.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu() );

            dtNgay.EditValue = objWareService.GetServerDateTime();

            DocumentProcessStatus.Tablename = this.TableName;
            DocumentProcessStatus.PK_Name = this.PK_Name;
            DocumentProcessStatus.Identity = this.Identity;
            DocumentProcessStatus.Doc_Process_Status = -1;
            DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
            EDocumentProcessStatus = objWareService.GetEDocumentProcessStatus(
                Convert.ToInt32( DocumentProcessStatus.Doc_Process_Status ) );
        }


        private void Frmware_ChangeDocStatus_Dialog_Load(object sender, EventArgs e)
        {
            DisplayInfo();
            if (NEWDocumentProcessStatus == SunLine.Ware.WareService.EDocumentProcessStatus.TestDoc
                && EDocumentProcessStatus != SunLine.Ware.WareService.EDocumentProcessStatus.NewDoc)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chứng từ ở trạng thái "
                    + objWareService.GetEDocStatusText(EDocumentProcessStatus) 
                    + " nên không thể kiểm tra", "Thông báo");
                btnOK.Enabled = false;
                btnCancel.Enabled = false;
            }
            else if (NEWDocumentProcessStatus == SunLine.Ware.WareService.EDocumentProcessStatus.VerifyDoc
                && EDocumentProcessStatus != SunLine.Ware.WareService.EDocumentProcessStatus.TestDoc)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chứng từ ở trạng thái " 
                    + objWareService.GetEDocStatusText( EDocumentProcessStatus) 
                    + " nên không thể xác nhận", "Thông báo");
                btnOK.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtGhichu.Text.Trim() == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] { labelControl1.Text, labelControl1.Text });
                txtGhichu.Text = "";
                txtGhichu.Focus();
                return;
            }
            DocumentProcessStatus.Doc_Process_Status = NEWDocumentProcessStatus;
            switch (NEWDocumentProcessStatus)
            {
                case SunLine.Ware.WareService.EDocumentProcessStatus.TestDoc:
                    DocumentProcessStatus.Ghichu_Test = txtGhichu.EditValue;
                    DocumentProcessStatus.Id_Nhansu_Test = lookUpEdit_Nhansu.EditValue;
                    break;
                case SunLine.Ware.WareService.EDocumentProcessStatus.VerifyDoc:
                    DocumentProcessStatus.Ghichu_Verify = txtGhichu.EditValue;
                    DocumentProcessStatus.Id_Nhansu_Verify = lookUpEdit_Nhansu.EditValue;
                    break;
            }

            objWareService.Update_DocumentProcessStatus(DocumentProcessStatus);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtGhichu.Text.Trim() == "")
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] { labelControl1.Text, labelControl1.Text });
                txtGhichu.Text = "";
                txtGhichu.Focus();
                return;
            }

            DocumentProcessStatus.Doc_Process_Status = SunLine.Ware.WareService.EDocumentProcessStatus.NewDoc;

            switch (NEWDocumentProcessStatus)
            {
                case SunLine.Ware.WareService.EDocumentProcessStatus.TestDoc:
                    DocumentProcessStatus.Ghichu_Test = txtGhichu.EditValue;
                    DocumentProcessStatus.Id_Nhansu_Test = lookUpEdit_Nhansu.EditValue;
                    break;
                case SunLine.Ware.WareService.EDocumentProcessStatus.VerifyDoc:
                    DocumentProcessStatus.Ghichu_Verify = txtGhichu.EditValue;
                    DocumentProcessStatus.Id_Nhansu_Verify = lookUpEdit_Nhansu.EditValue;
                    break;
            }

            objWareService.Update_DocumentProcessStatus(DocumentProcessStatus);
            this.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!btnCancel.Enabled && !btnOK.Enabled)
                this.Close();
        }
    }
}