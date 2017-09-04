using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Doituong :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsCollection = new DataSet();
        public DataRow drDoituong;
        public Frmware_Dm_Doituong()
        {
            InitializeComponent();
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            this.DisplayInfo();
            ChangeStatus(false);
        }

        public override void DisplayInfo()
        {
            try
            {
                dsCollection = objMasterService.Get_All_Ware_Dm_Doituong().ToDataSet();
                dgware_Dm_Doituong.DataSource = dsCollection;
                dgware_Dm_Doituong.DataMember = dsCollection.Tables[0].TableName;
                gridView1.BestFitColumns();

                this.DatabindControl();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        void ChangeStatus(bool check)
        {
            this.txtDiachi.Enabled = check;
            this.txtMa_Doituong.Enabled = check;
            this.txtMasothue.Enabled = check;
            this.txtTen_Doituong.Enabled = check;
        }

        void ResetText()
        {
            this.txtTen_Doituong.EditValue = "";
            this.txtMasothue.EditValue = "";
            this.txtMa_Doituong.EditValue = "";
            this.txtDiachi.EditValue = "";
            this.txtCMND.EditValue = "";
        }

        void ClearDataBindings()
        {
            this.txtCMND.DataBindings.Clear();
            this.txtDiachi.DataBindings.Clear();
            this.txtMa_Doituong.DataBindings.Clear();
            this.txtMasothue.DataBindings.Clear();
            this.txtTen_Doituong.DataBindings.Clear();
        }

        void DatabindControl()
        {
            ClearDataBindings();

            this.txtCMND.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Cmnd");
            this.txtDiachi.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Diachi");
            this.txtMa_Doituong.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Ma_Doituong");
            this.txtMasothue.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Masothue");
            this.txtTen_Doituong.DataBindings.Add("EditValue", dsCollection, dsCollection.Tables[0].TableName + ".Ten_Doituong");

        }

        public override object PerformSelectOneObject()
        {
            int id_focus = gridView1.FocusedRowHandle;
            drDoituong = gridView1.GetDataRow(id_focus);
            this.Dispose();
            this.Close();
            return true;
        }

        private void dgware_Dm_Doituong_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        #region Event Override
        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.MasterService.Ware_Dm_Khachhang objKhachHang = new Ecm.WebReferences.MasterService.Ware_Dm_Khachhang();

                objKhachHang.Diachi_Khachhang = txtDiachi.EditValue;
                objKhachHang.Ma_Khachhang = txtMa_Doituong.EditValue;
                objKhachHang.Ten_Khachhang = txtTen_Doituong.EditValue;
                objKhachHang.Masothue = txtMasothue.EditValue;


                objMasterService.Insert_Ware_Dm_Khachhang(objKhachHang);
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

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            this.txtMa_Doituong.Focus();
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

                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                txtMa_Doituong_Temp.EditValue ="KH - " + txtMa_Doituong.EditValue;
                htbControl1.Add(txtMa_Doituong_Temp, lblMa_Doituong.Text);
                htbControl1.Add(txtTen_Doituong, lblTen_Doituong.Text);                

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbControl1, dsCollection, "Ma_Doituong"))
                    return false;


                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }

                if (success)
                {
                    this.DisplayInfo();
                    ChangeStatus(false);
                }
                return success;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }


        #endregion
    }
}

