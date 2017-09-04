using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace Ecm.Rex.Forms
{
    // =============================================
    // Author:		Phuongphan
    // Create date: 24/02/2011
    // Description:	Tìm nhân sự
    // - user nhập 1 hoặc nhiều thông tin
    // - tìm ds nhân sự phù hợp
    // - user chọn 1 nhân sự trả về cho form khác cần dùng
    // =============================================
    public partial class Frmrex_Nhansu_Search : DevExpress.XtraEditors.XtraForm
    {

        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Collection = new DataSet();
        public DataRow dtnhansu;
        public Frmrex_Nhansu_Search()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

        public void DisplayInfo()
        {
            try
            {
                DataSet ds_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
                gridLookUpEdit_Bophan.DataSource = ds_Bophan.Tables[0];
               
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public void DisplayInfo2()
        {
            ds_Collection = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
           
            ds_Collection.Tables[0].Columns.Add("Trangthai_Hopdong");
            if (ds_Collection.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds_Collection.Tables[0].Rows.Count; i++)
                {
                    long id_nhansu = Convert.ToInt64(ds_Collection.Tables[0].Rows[i]["Id_Nhansu"]);
                    object trangthai = objRexService.Get_Nhansu_Trangthai_Hopdong(id_nhansu);
                    ds_Collection.Tables[0].Rows[i]["Trangthai_Hopdong"] = trangthai;
                }
            }


            dgrex_Nhansu.DataSource = ds_Collection;
            dgrex_Nhansu.DataMember = ds_Collection.Tables[0].TableName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Ecm.WebReferences.RexService.Rex_Nhansu nhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();
                nhansu.Ma_Nhansu = txtMa_Nhansu.EditValue;
                nhansu.Ho_Nhansu = txtHo_Nhansu.EditValue;
                nhansu.Ten_Nhansu = txtTen_Nhansu.EditValue;
                nhansu.Tenkhac = txtTen_Khac.EditValue;
                nhansu.Cmnd = txtCMND.EditValue;
                nhansu.Hochieu = txtHochieu.EditValue;
                nhansu.Diachi_Thuongtru = txtDiachi_Thuongtru.EditValue;
                nhansu.Diachi_Tamtru = txtDiachi_Tamtru.EditValue;
                nhansu.Dienthoai = txtDienthoai_Didong.EditValue;
                nhansu.Dienthoai_Nharieng = txtDienthoai_Nha.EditValue;
                nhansu.Fax = txtFax.EditValue;
                nhansu.Email = txtEmail.EditValue;

                ds_Collection = objRexService.Get_Search_Rex_Nhansu(nhansu).ToDataSet();
                dgrex_Nhansu.DataSource = ds_Collection;
                dgrex_Nhansu.DataMember = ds_Collection.Tables[0].TableName;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"");
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount > 0)
                {
                    int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                    dtnhansu = ds_Collection.Tables[0].Rows[focusedRow];
                    this.Dispose();
                    this.Close();
                }
                else
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn nhân sự!");
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message);
#endif
            }
        }
    }
}