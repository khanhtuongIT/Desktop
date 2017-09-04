using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Nhansu_Import : DevExpress.XtraEditors.XtraForm
    {
        public enum ImportMode
        {
            REX_NHANSU_IMP,
            REX_NHANSU_ATM_IMP
        }

        private ImportMode impmode = ImportMode.REX_NHANSU_IMP;
        public ImportMode ImpMode
        {
            get { return impmode; }
            set 
            {
                impmode = value;
                DisplayInfo();
            }
        }

        Ecm.WebReferences.Classes.RexService objRex = new WebReferences.Classes.RexService();
        Ecm.WebReferences.Classes.MasterService objMasterTables = new WebReferences.Classes.MasterService();

        DataSet dsBophan = new DataSet();
        DataSet dsNhansu_Excel = new DataSet();
        DataSet dsHesochuongtrinh = new DataSet();

        public object Id_Bophan
        {
            get { return lookUpEdit_Bophan.EditValue; }
            set { lookUpEdit_Bophan.EditValue = lookUpEdit_Bophan1.EditValue  = value; }
        }

        public Frmrex_Nhansu_Import()
        {
            InitializeComponent();
            this.Icon = new Icon(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetValue("HostConfiguration", "Theme", "ProductIcon")); //from XML config file
            DisplayInfo();
        }

        public void DisplayInfo()
        {
            btnOK.Enabled = false;

            dsBophan = objMasterTables.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
            lookUpEdit_Bophan.Properties.DataSource = dsBophan.Tables[0];
            lookUpEdit_Bophan1.Properties.DataSource = dsBophan.Tables[0];

            DisplayNhansu_Impmap();
        }

        void DisplayNhansu_Impmap()
        {
            if (impmode == ImportMode.REX_NHANSU_IMP)
                dsHesochuongtrinh = objMasterTables.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("REX_NHANSU_IMPMAP").ToDataSet();
            else if (impmode == ImportMode.REX_NHANSU_ATM_IMP)
                dsHesochuongtrinh = objMasterTables.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("REX_NHANSU_ATM_IMPMAP").ToDataSet();

            dgNhansu_ImpMap.DataSource = dsHesochuongtrinh;
            dgNhansu_ImpMap.DataMember = dsHesochuongtrinh.Tables[0].TableName;
            gvNhansu_ImpMap.BestFitColumns();

            dsHesochuongtrinh.Tables[0].RowChanged += new DataRowChangeEventHandler(Frmrex_Nhansu_Import_RowChanged);
            btnSave_Heso_Chuongtrinh.Enabled = false;
        }

        void Frmrex_Nhansu_Import_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            btnSave_Heso_Chuongtrinh.Enabled = true;
        }

        /// <summary>
        /// fill data from excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFillFromFile_Click(object sender, EventArgs e)
        {
            GoobizFrame.Windows.Tools.FrmExcelData frmExcelData = new GoobizFrame.Windows.Tools.FrmExcelData();
            frmExcelData.ShowDialog();

            if (frmExcelData.DsImportData != null)
            {
                dsNhansu_Excel = frmExcelData.DsImportData;
                dgNhansu_Excel.DataSource = dsNhansu_Excel;
                dgNhansu_Excel.DataMember = dsNhansu_Excel.Tables[0].TableName;                

                gvNhansu_Excel.Columns.Clear();
                int visibleIndex = 0;
                foreach (DataColumn col in dsNhansu_Excel.Tables[0].Columns)
                {
                    DevExpress.XtraGrid.Columns.GridColumn GridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
                    GridColumn.FieldName = col.ColumnName;
                    GridColumn.Caption = col.ColumnName;
                    GridColumn.VisibleIndex = visibleIndex++;
                    GridColumn.Visible = true;

                    gvNhansu_Excel.Columns.Add(GridColumn);

                    gridComboBox_Nhansu_Excel.Items.Add(col.ColumnName);
                }

                gvNhansu_Excel.BestFitColumns();

                btnOK.Enabled = (gvNhansu_Excel.RowCount > 0);
            }
        }

        /// <summary>
        /// luu bang anh xa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Heso_Chuongtrinh_Click(object sender, EventArgs e)
        {
            dgNhansu_ImpMap.EmbeddedNavigator.Buttons.DoClick(dgNhansu_ImpMap.EmbeddedNavigator.Buttons.EndEdit);
            objMasterTables.Update_Rex_Dm_Heso_Chuongtrinh_Collection(dsHesochuongtrinh);
            DisplayNhansu_Impmap();
        }

        /// <summary>
        /// ket thuc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// dong y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ trong vài giây...", "Đang thực hiện");
            if (impmode == ImportMode.REX_NHANSU_IMP)
                ImportNhansu();
            else if (impmode == ImportMode.REX_NHANSU_ATM_IMP)
                UpdateTaikhoanNganhang();
            WaitDialogForm.Close();
            btnOK.Enabled = false;
        }

        void ImportNhansu()
        {
            foreach (DataRow drNhansu_Excel in dsNhansu_Excel.Tables[0].Rows)
            {
                try
                {
                    drNhansu_Excel.RowError = string.Empty;

                    Ecm.WebReferences.RexService.Rex_Nhansu objRex_Nhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();
                    objRex_Nhansu.Id_Nhansu = -1;

                    //**thong tin chung
                    objRex_Nhansu.Ma_Nhansu = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ma_Nhansu'").Length > 0
                        && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ma_Nhansu'")[0]["Heso"] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ma_Nhansu'")[0]["Heso"]] != ""
                        )
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ma_Nhansu'")[0]["Heso"]]
                        : null;

                    if ("" + objRex_Nhansu.Ma_Nhansu == "") continue;

                    objRex_Nhansu.Ho_Nhansu = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ho_Nhansu'").Length > 0
                         && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ho_Nhansu'")[0]["Heso"] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ho_Nhansu'")[0]["Heso"]] != ""
                         )
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ho_Nhansu'")[0]["Heso"]]
                        : null;
                    objRex_Nhansu.Ten_Nhansu = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ten_Nhansu'").Length > 0
                         && ("" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ten_Nhansu'")[0]["Heso"]).Trim() != "")
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ten_Nhansu'")[0]["Heso"]]
                        : null;
                    if (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Hoten_Nhansu'").Length > 0
                         && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Hoten_Nhansu'")[0]["Heso"] != "")
                    {
                        string hoten_nhansu = "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Hoten_Nhansu'")[0]["Heso"]];
                        hoten_nhansu = hoten_nhansu.Trim();
                        string ho_nhansu = hoten_nhansu.Substring(0, hoten_nhansu.LastIndexOf(" "));
                        string ten_nhansu = hoten_nhansu.Substring(hoten_nhansu.LastIndexOf(" ")).Trim();

                        objRex_Nhansu.Ho_Nhansu = ho_nhansu;
                        objRex_Nhansu.Ten_Nhansu = ten_nhansu;
                    }

                    objRex_Nhansu.Gioitinh = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Gioitinh'").Length > 0
                         && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngay_Sinh'")[0]["Heso"] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Gioitinh'")[0]["Heso"]] != ""
                         )
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Gioitinh'")[0]["Heso"]]
                        : null;
                    objRex_Nhansu.Ngay_Sinh = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngay_Sinh'").Length > 0
                         && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngay_Sinh'")[0]["Heso"] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngay_Sinh'")[0]["Heso"]] != ""
                         )
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngay_Sinh'")[0]["Heso"]]
                        : null;
                    objRex_Nhansu.Thangsinh = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Thangsinh'").Length > 0
                         && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Thangsinh'")[0]["Heso"] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Thangsinh'")[0]["Heso"]] != ""
                         )
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Thangsinh'")[0]["Heso"]]
                        : null;
                    objRex_Nhansu.Namsinh = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Namsinh'").Length > 0
                         && ("" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Namsinh'")[0]["Heso"]).Trim() != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Namsinh'")[0]["Heso"]] != ""
                         )
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Namsinh'")[0]["Heso"]]
                        : null;
                    objRex_Nhansu.Noisinh = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Noisinh'").Length > 0
                         && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Noisinh'")[0]["Heso"] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Noisinh'")[0]["Heso"]] != ""
                         )
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Noisinh'")[0]["Heso"]]
                        : null;
                    objRex_Nhansu.Cmnd = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Cmnd'").Length > 0
                         && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Cmnd'")[0]["Heso"] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Cmnd'")[0]["Heso"]] != ""
                         )
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Cmnd'")[0]["Heso"]]
                        : null;
                    objRex_Nhansu.Noicap = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Noicap'").Length > 0
                         && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Noicap'")[0]["Heso"] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Noicap'")[0]["Heso"]] != ""
                         )
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Noicap'")[0]["Heso"]]
                        : null;
                    objRex_Nhansu.Ngaycap = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngaycap'").Length > 0
                         && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngaycap'")[0]["Heso"] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngaycap'")[0]["Heso"]] != ""
                         )
                        ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngaycap'")[0]["Heso"]]
                        : null;

                    objRex_Nhansu.Hochieu = null;
                    objRex_Nhansu.Noicap_Hochieu = null;
                    objRex_Nhansu.Ngaycap_Hochieu = null;

                    objRex_Nhansu.Ngay_Vaolam = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngay_Vaolam'").Length > 0
                            && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngay_Vaolam'")[0]["Heso"]] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngay_Vaolam'")[0]["Heso"]] != ""
                            )
                        ?DateTime.FromOADate( Convert.ToDouble(
                        drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ngay_Vaolam'")[0]["Heso"]]))
                        : DateTime.Now;
                    objRex_Nhansu.Taikhoan_Nganhang = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Taikhoan_Nganhang'").Length > 0
                         && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Taikhoan_Nganhang'")[0]["Heso"] != ""
                         && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Taikhoan_Nganhang'")[0]["Heso"]] != ""
                         )
                        ? ""+drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Taikhoan_Nganhang'")[0]["Heso"]]
                        : null;

                    Image srcImage = global::Ecm.Rex.Properties.Resources.no_image;
                    int percentSize = (srcImage.Width > 100) ? 100 * 100 / srcImage.Width : 100;
                    Image hinh = GoobizFrame.Windows.ImageUtils.ImageResize.ScaleByPercent(srcImage, percentSize);
                    //save image to memory
                    MemoryStream ms = new MemoryStream();
                    hinh.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imageData = ms.GetBuffer();
                    //asign image in buffer to property Hinh
                    objRex_Nhansu.Hinh = imageData;

                    //**thong tin lien lac
                    objRex_Nhansu.Quequan = null;
                    objRex_Nhansu.Diachi_Thuongtru = null;
                    objRex_Nhansu.Diachi_Tamtru = null;
                    objRex_Nhansu.Dienthoai_Nharieng = null;
                    objRex_Nhansu.Dienthoai = null;
                    objRex_Nhansu.Email = null;

                    objRex_Nhansu.Id_Dantoc = null;
                    objRex_Nhansu.Id_Tongiao = null;
                    objRex_Nhansu.Id_Quocgia = null;
                    objRex_Nhansu.Id_Tpgiadinh = null;
                    objRex_Nhansu.Id_Tpbanthan = null;
                    objRex_Nhansu.Id_Honnhan = null;
                    objRex_Nhansu.Id_Vanhoa = null;
                    objRex_Nhansu.Id_Chuyenmon = null;

                    //bo tri nhan su
                    object identity = objRex.Insert_Rex_Nhansu(objRex_Nhansu);
                    Ecm.WebReferences.RexService.Rex_Botri_Nhansu Rex_Botri_Nhansu = new Ecm.WebReferences.RexService.Rex_Botri_Nhansu();
                    Rex_Botri_Nhansu.Id_Bophan = Id_Bophan;
                    Rex_Botri_Nhansu.Id_Nhansu = identity;
                    Rex_Botri_Nhansu.Ngay_Batdau = objRex_Nhansu.Ngay_Vaolam;
                    Rex_Botri_Nhansu.Ngay_Ketthuc = null;
                    objRex.Insert_Rex_Botri_Nhansu(Rex_Botri_Nhansu);


                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Exclamation, ex.Message, ex.ToString());
                    drNhansu_Excel.RowError = ex.Message;
                    continue;
                }
            }
        }

        /// <summary>
        /// cap nhat danh sach tai khoan ngan hang
        /// </summary>
        void UpdateTaikhoanNganhang()
        {
            foreach (DataRow drNhansu_Excel in dsNhansu_Excel.Tables[0].Rows)
            {
                try
                {
                    drNhansu_Excel.RowError = string.Empty;

                    Ecm.WebReferences.RexService.Rex_Nhansu objRex_Nhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();

                    objRex_Nhansu.Ma_Nhansu = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ma_Nhansu'").Length > 0
                       && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ma_Nhansu'")[0]["Heso"] != ""
                       && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ma_Nhansu'")[0]["Heso"]] != ""
                       )
                       ? drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Ma_Nhansu'")[0]["Heso"]]
                       : null;

                    objRex_Nhansu.Taikhoan_Nganhang = (dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Taikhoan_Nganhang'").Length > 0
                       && "" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Taikhoan_Nganhang'")[0]["Heso"] != ""
                       && "" + drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Taikhoan_Nganhang'")[0]["Heso"]] != ""
                       )
                      ?""+ drNhansu_Excel["" + dsHesochuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Taikhoan_Nganhang'")[0]["Heso"]]
                      : null;

                    objRex.Update_Rex_Nhansu_Taikhoan_Nganhang(objRex_Nhansu);
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Exclamation, ex.Message, ex.ToString());
                    drNhansu_Excel.RowError = ex.Message;
                    continue;
                }
            }
        }
       

    }
}