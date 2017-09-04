using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Nghiphep_ByNhansu : DevExpress.XtraEditors.XtraForm
    {
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Nhansu = new DataSet();
        DataSet dsHeso_Chuongtrinh;
        DataSet dsNghiphep;
        object Id_Nghiphep;

        public object Id_Nhansu
        {
            get { return lookUp_Nhansu.EditValue; }
            set 
            { 
                lookUp_Nhansu.EditValue = value;
                GetNghiphep();
            }
        }

        public DateTime Ngay_Batdau
        {
            get { return dtNgay_Batdau.DateTime; }
            set 
            {
                dtNgay_Batdau.DateTime = value;
                dtNgay_Ketthuc.DateTime = value;
                GetNghiphep();
            }
        }

        public Frmrex_Nghiphep_ByNhansu()
        {
            InitializeComponent();
            DisplayInfo();
        }

        void GetNghiphep()
        {
            if (Id_Nhansu != null && Ngay_Batdau != null)
            {
                try
                {
                    dsNghiphep = objRexService.Get_Rex_Nghiphep_ByNhansu_WithChamcong(Id_Nhansu, Ngay_Batdau).ToDataSet();
                    if (dsNghiphep != null && dsNghiphep.Tables[0].Rows.Count > 0)
                    {
                        var drNghiphep = dsNghiphep.Tables[0].Rows[0];
                        Id_Nghiphep = drNghiphep["Id_Nghiphep"];
                        dtNgay_Batdau.EditValue = drNghiphep["Ngay_Batdau"];
                        dtNgay_Ketthuc.EditValue = drNghiphep["Ngay_Ketthuc"];
                        lookUp_Loai_Nghiphep.EditValue = drNghiphep["Id_Loai_Nghiphep"];
                        txtGhichu.EditValue = drNghiphep["Ghichu"];
                        txtSogio_Nghi.EditValue = drNghiphep["Sogio_Nghiphep"];
                    }
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message,ex.ToString(),"Exception");
                }
            }
        }

        public  void DisplayInfo()
        {
            try
            {
                //Get data master table REX
                lookUp_Loai_Nghiphep.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Loai_Nghiphep_Collection().ToDataSet().Tables[0];
                ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUp_Nhansu.Properties.DataSource = ds_Nhansu.Tables[0];

                dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
                txtSogio_Nghi.EditValue = dsHeso_Chuongtrinh.Tables[0].Select(
                    string.Format("Ma_Heso_Chuongtrinh='{0}'", "GIOCONG_NGAY"))[0]["Heso"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(lookUp_Nhansu, lblMa_Nhansu.Text);
            hashtableControls.Add(lookUp_Loai_Nghiphep, lblLoai_Nghiphep.Text);
            hashtableControls.Add(txtSogio_Nghi, lblSogio_Nghi.Text);
            hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lblNgay_Ketthuc.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return ;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return ;

            if (Convert.ToDecimal(txtSogio_Nghi.EditValue) == 0)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số giờ nghĩ không được bằng 0, Nhập lại");
                txtSogio_Nghi.Focus();
                return ;
            }

            if ("" + Id_Nghiphep == "")
                InsertObject();
            else
                UpdateObject();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookUp_Nhansu_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUp_Nhansu.EditValue != null)
            {
                DataRow[] dtr = ds_Nhansu.Tables[0].Select("Id_Nhansu = " + lookUp_Nhansu.EditValue);
                if (dtr.Length > 0)
                    txtHoten_Nhansu.EditValue = dtr[0]["Hoten_Nhansu"];
            }
        }

        private bool CheckNhansu_Nghiphep(DateTime ngay_Batdau, DateTime ngay_Ketthuc, int id_Nhansu)
        {
            // phan kiem tra ngay vao lam
            Ecm.WebReferences.RexService.Rex_Nhansu nhansu = objRexService.Get_Rex_Nhansu_ById(id_Nhansu);
            if (DateTime.Parse(nhansu.Ngay_Vaolam.ToString()) > ngay_Batdau)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian bắt đầu nghỉ phép trước thời gian vào làm, Nhập lại");
                return false;
            }
            // phan nghi viec
            DataSet dsnghiviec = objRexService.Get_All_Rex_Nghiviec_ByNhansu(id_Nhansu).ToDataSet();
            if (dsnghiviec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dt in dsnghiviec.Tables[0].Rows)
                {
                    if (Convert.ToDateTime(dt["Ngay_Nghiviec"].ToString()) < ngay_Batdau || Convert.ToDateTime(dt["Ngay_Nghiviec"].ToString()) < ngay_Ketthuc)
                    {
                        // khong hop ly
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian này nhân viên đã nghỉ việc, không thêm được!");
                        return false;
                    }
                }
            }
            // phan hop dong lao dong
            // kiem tra nghi phep trong thoi gian hop dong 
            DataSet dshopdong = objRexService.Get_All_Rex_Hopdong_Laodong_By_Nhansu(id_Nhansu).ToDataSet();
            bool hopdong = false;
            if (dshopdong.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dt in dshopdong.Tables[0].Rows)
                {
                    hopdong = true;
                    if (Convert.ToDateTime(dt["Ngay_Batdau"].ToString()) <= ngay_Batdau)
                    {
                        return true;
                    }

                    // kiem tra ngay ket thuc hop dong
                    if ("" + dt["Ngay_Ketthuc"] != "")
                    {
                        if (Convert.ToDateTime(dt["Ngay_Ketthuc"].ToString()) < ngay_Batdau)
                        {
                            // kiem tra truong hop gia han them hop dong
                            if ("" + dt["thoigian_thuchien_den"] != "")
                            {
                                if (Convert.ToDateTime(dt["thoigian_thuchien_den"].ToString()) < ngay_Batdau)
                                {
                                    GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian nghỉ phép không nằm trong thời gian hợp đồng, Nhập lại");
                                    return false;
                                }
                            }

                        }
                    }
                }
                if (hopdong)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian nghỉ phép không nằm trong thời gian hợp đồng, Nhập lại");
                    return false;
                }
            }
            //GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian bắt đầu, kết thúc nghỉ phép không hợp lý, Nhập lại");
            return true;
        }

        public object InsertObject()
        {
            try
            {
                if (CheckNhansu_Nghiphep(Convert.ToDateTime(dtNgay_Batdau.EditValue.ToString()), Convert.ToDateTime(dtNgay_Ketthuc.EditValue.ToString()), int.Parse(lookUp_Nhansu.EditValue.ToString())))
                {
                    var  objRex_Nghiphep =  new Ecm.WebReferences.RexService.Rex_Nghiphep();
                    objRex_Nghiphep.Id_Nghiphep = -1;

                    if ("" + this.dtNgay_Batdau.EditValue != "")
                        objRex_Nghiphep.Ngay_Batdau = this.dtNgay_Batdau.EditValue;

                    if ("" + this.dtNgay_Ketthuc.EditValue != "")
                        objRex_Nghiphep.Ngay_Ketthuc = this.dtNgay_Ketthuc.EditValue;

                    if ("" + this.lookUp_Loai_Nghiphep.EditValue != "")
                        objRex_Nghiphep.Id_Loai_Nghiphep = this.lookUp_Loai_Nghiphep.EditValue;

                    if ("" + this.lookUp_Nhansu.EditValue != "")
                        objRex_Nghiphep.Id_Nhansu = this.lookUp_Nhansu.EditValue;
                    objRex_Nghiphep.Ghichu = (txtGhichu.Text == "") ? null : txtGhichu.EditValue;
                    objRex_Nghiphep.Sogio_Nghiphep = this.txtSogio_Nghi.Text;
                    objRexService.Insert_Rex_Nghiphep(objRex_Nghiphep);
                }
            }
            catch (Exception e)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Lỗi: " + e.Message);
                return false;
            }
            return true;
        }

        public object UpdateObject()
        {
            object success = null;
            try
            {
                if (CheckNhansu_Nghiphep(Convert.ToDateTime(dtNgay_Batdau.EditValue.ToString()), Convert.ToDateTime(dtNgay_Ketthuc.EditValue.ToString()), int.Parse(lookUp_Nhansu.EditValue.ToString())))
                {
                    Ecm.WebReferences.RexService.Rex_Nghiphep objRex_Nghiphep = new Ecm.WebReferences.RexService.Rex_Nghiphep();
                    objRex_Nghiphep.Id_Nghiphep = Id_Nghiphep;

                    if ("" + this.dtNgay_Batdau.EditValue != "")
                        objRex_Nghiphep.Ngay_Batdau = this.dtNgay_Batdau.EditValue;

                    if ("" + this.dtNgay_Ketthuc.EditValue != "")
                        objRex_Nghiphep.Ngay_Ketthuc = this.dtNgay_Ketthuc.EditValue;

                    if ("" + this.lookUp_Loai_Nghiphep.EditValue != "")
                        objRex_Nghiphep.Id_Loai_Nghiphep = this.lookUp_Loai_Nghiphep.EditValue;

                    if ("" + this.lookUp_Nhansu.EditValue != "")
                        objRex_Nghiphep.Id_Nhansu = this.lookUp_Nhansu.EditValue;

                    objRex_Nghiphep.Ghichu = (txtGhichu.Text == "") ? null : txtGhichu.EditValue;
                    objRex_Nghiphep.Sogio_Nghiphep = this.txtSogio_Nghi.Text;
                    success = objRexService.Update_Rex_Nghiphep(objRex_Nghiphep);
                }
                else
                {
                    //GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian nghỉ phép không đúng, Nhập lại");
                    return success;
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"Exception");
            }
            return success;
        }

        private void lookUp_Loai_Nghiphep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterService.dll",
                  "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Loai_Nghiphep_Add", this);
                if (dialog == null)
                    return;
                var SelectedObject = dialog.GetType().GetProperty("Selected_Rex_Dm_Loai_Nghiphep").GetValue(dialog, null)
                    as Ecm.WebReferences.MasterService.Rex_Dm_Loai_Nghiphep;

                var ds_Loai_Nghiphep = objMasterService.Get_All_Rex_Dm_Loai_Nghiphep_Collection().ToDataSet();
                lookUp_Loai_Nghiphep.Properties.DataSource = ds_Loai_Nghiphep.Tables[0];
                if (SelectedObject != null)
                {
                    lookUp_Loai_Nghiphep.EditValue = SelectedObject.Id_Loai_Nghiphep;
                }
            }
        }
    }
}