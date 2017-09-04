using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Khachhang_AddnPrint :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        public Ecm.WebReferences.MasterService.Ware_Dm_Khachhang objWare_Dm_Khachhang;

        public Frmware_Dm_Khachhang_AddnPrint()
        {
            InitializeComponent();

            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        public void ChangeStatus(bool editTable)
        {
            this.txtMa_Khachhang.Properties.ReadOnly = !editTable;
            this.txtTen_Khachhang.Properties.ReadOnly = !editTable;
            this.txtDiachi_Khachhang.Properties.ReadOnly = !editTable;
            this.txtMasothue.Properties.ReadOnly = !editTable;
            this.txtDienthoai.Properties.ReadOnly = !editTable;
            this.txtFax.Properties.ReadOnly = !editTable;
            this.txtEmail.Properties.ReadOnly = !editTable;
            this.txtWebsite.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtMa_Khachhang.EditValue = "";
            this.txtTen_Khachhang.EditValue = "";
            this.txtDiachi_Khachhang.EditValue = "";
            this.txtMasothue.EditValue = "";
            this.txtDienthoai.EditValue = "";
            this.txtFax.EditValue = "";
            this.txtEmail.EditValue = "";
            this.txtWebsite.EditValue = "";
        }

        #region Event Override
        public object InsertObject()
        {
            objWare_Dm_Khachhang = new Ecm.WebReferences.MasterService.Ware_Dm_Khachhang();
            objWare_Dm_Khachhang.Ma_Khachhang = txtMa_Khachhang.EditValue;
            objWare_Dm_Khachhang.Ten_Khachhang = txtTen_Khachhang.EditValue;
            objWare_Dm_Khachhang.Diachi_Khachhang = txtDiachi_Khachhang.EditValue;
            objWare_Dm_Khachhang.Masothue = txtMasothue.EditValue;
            objWare_Dm_Khachhang.Dienthoai = txtDienthoai.EditValue;
            objWare_Dm_Khachhang.Fax = txtFax.EditValue;
            objWare_Dm_Khachhang.Email = txtEmail.EditValue;
            objWare_Dm_Khachhang.Website = txtWebsite.EditValue;
            objWare_Dm_Khachhang.Ngay_Sinh =  GoobizFrame.Windows.MdiUtils.DateTimeMask.YMDFromShortDatePattern(this.txtNgaysinh.Text,  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat());

            return objMasterService.Insert_Ware_Dm_Khachhang(objWare_Dm_Khachhang);
        }

        public override bool PerformAdd()
        {
            this.ChangeStatus(true);
            this.ResetText();

            txtMa_Khachhang.EditValue = objMasterService.GetNew_Sochungtu("Ware_Dm_Khachhang", "Ma_Khachhang", "");
            return true;
        }

        public override bool PerformCancel()
        {
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Khachhang, lblMa_Khachhang.Text);
                hashtableControls.Add(txtTen_Khachhang, lblTen_Khachhang.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
               
                if (success)
                {
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists_Ma_Khachhang") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Khachhang.Text, lblMa_Khachhang.Text.ToLower() });
                }
                else if (ex.ToString().IndexOf("exists_Masothue") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMasothue.Text, lblMasothue.Text.ToLower() });
                }
                return false;
            }
        }
        public override bool PerformPrintPreview()
        {
            
            return base.PerformPrintPreview();
        }
        #endregion

      
    }
}