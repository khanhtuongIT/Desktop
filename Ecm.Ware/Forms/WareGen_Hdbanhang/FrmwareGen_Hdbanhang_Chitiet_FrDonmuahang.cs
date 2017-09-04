using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms.WareGen_Hdbanhang
{
    public partial class FrmwareGen_Hdbanhang_Chitiet_FrDonmuahang :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public DateTime Ngay_Chungtu;
        public object Id_Donmuahang;
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet dsInit_Hdbanhang_Chitiet;
        public System.Collections.ArrayList Arr_Random_Id_Hdbanhang = new System.Collections.ArrayList();

        public FrmwareGen_Hdbanhang_Chitiet_FrDonmuahang()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();
        }

        #region override
        public override void DisplayInfo()
        {
            //gridLookUpEdit_Donvitinh_2
            gridLookUpEdit_Donvitinh_2.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];

            //lookUpEditMa_Kho_Hanghoa
            lookUpEditMa_Kho_Hanghoa.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa().ToDataSet().Tables[0];

            base.DisplayInfo();
        }

        public override bool PerformQuery()
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            Arr_Random_Id_Hdbanhang = new System.Collections.ArrayList();
            System.Random random_Hoadon = new Random();
            int nHoadon = Convert.ToInt32(txtSohoadon.EditValue);

            System.Collections.ArrayList arr_Id_Hanghoa_Mua = new System.Collections.ArrayList();
            
            dsInit_Hdbanhang_Chitiet = objWareService.Get_All_WareGen_Hdbanhang_Chitiet_By_Donmuahang(Id_Donmuahang).ToDataSet();

            dsInit_Hdbanhang_Chitiet.Tables[0].Columns.Add("Thanhtien",typeof(decimal));
            dsInit_Hdbanhang_Chitiet.Tables[0].Columns.Add("Soluong_HHMua_PerTP", typeof(decimal));
            dsInit_Hdbanhang_Chitiet.Tables[0].Columns.Add("Soluong_HHMua_IsFull", typeof(bool));
            dsInit_Hdbanhang_Chitiet.Tables[0].Columns.Add("Random_Id_Hdbanhang", typeof(int));

            DataSet dsSource = dsInit_Hdbanhang_Chitiet.Copy();

            foreach (DataRow dr in dsInit_Hdbanhang_Chitiet.Tables[0].Rows)
            {
                dr["Soluong"] = 1;

                dr["Thanhtien"] =
                    Convert.ToDecimal(dr["Soluong"])
                    * Convert.ToDecimal(dr["Dongia_Ban"])
                    * (1 - Convert.ToDecimal("0" + dr["Per_Dongia"]) / 100);

                dr["Soluong_HHMua_IsFull"] = false;

                dr.AcceptChanges();

                if (!arr_Id_Hanghoa_Mua.Contains(dr["Id_Hanghoa_Mua"])) arr_Id_Hanghoa_Mua.Add(dr["Id_Hanghoa_Mua"]);
            }

            //set random soluong
            int nRecords = dsInit_Hdbanhang_Chitiet.Tables[0].Rows.Count;
            decimal vThanhtien = 0;
            System.Random randomRow = new Random();
            int nSkip = 0;
            while (true)
            {
                nSkip++;

                if (dsInit_Hdbanhang_Chitiet.Tables[0].Select("Soluong_HHMua_IsFull <> true").Length == 0)
                    break;
                
                nRecords = dsInit_Hdbanhang_Chitiet.Tables[0].Rows.Count;
                int iRow = randomRow.Next(nRecords);                
               
                #region TP dat gioi han min
                object Id_Hanghoa_Ban = dsInit_Hdbanhang_Chitiet.Tables[0].Rows[iRow]["Id_Hanghoa_Ban"];
                decimal Soluong_TP_Min = Convert.ToDecimal( dsInit_Hdbanhang_Chitiet.Tables[0].Compute("MIN(Soluong_TP)", "Id_Hanghoa_Ban="
                        + Id_Hanghoa_Ban) );
                decimal Soluong_TP = Convert.ToDecimal(dsInit_Hdbanhang_Chitiet.Tables[0].Compute("SUM(Soluong)", "Id_Hanghoa_Ban="
                        + Id_Hanghoa_Ban));
                if (Soluong_TP == Soluong_TP_Min)
                {
                    //neu so luong hang hoa san xuat dat den gioi han nho nhat
                    DataRow[] sdrInit_Hdbanhang_Chitiet = dsInit_Hdbanhang_Chitiet.Tables[0].Select("Id_Hanghoa_Ban="
                        + dsInit_Hdbanhang_Chitiet.Tables[0].Rows[iRow]["Id_Hanghoa_Ban"]);
                    foreach (DataRow dr in sdrInit_Hdbanhang_Chitiet)
                        dr["Soluong_HHMua_IsFull"] = true;
                    continue;
                }
                
                #endregion

                #region Set Soluong NL su dung trong TP
                foreach (object Id_Hanghoa_Mua in arr_Id_Hanghoa_Mua) //duyet tung NL
                {
                    //so luong NL (max)
                    decimal Soluong_Hhmua = Convert.ToDecimal(dsSource.Tables[0].Select("Id_Hanghoa_Mua=" + Id_Hanghoa_Mua)[0]["Soluong_HHMua"]);
                    //soluong NL su dung trong TP
                    decimal Soluong_Hhmua_PerTP = 0;
                    //soluong TP su dung NL dang xet
                    decimal Soluong_TP_SDNL = 0;

                    //tim tat ca cac TP khac co su dung NL dang xet
                    DataRow [] sdrTP_SDNL = dsSource.Tables[0].Select("Id_Hanghoa_Mua=" + Id_Hanghoa_Mua);
                    //duyet tung TP
                    foreach (DataRow drTP in sdrTP_SDNL)
                    {
                        decimal Soluong_Sum = Convert.ToDecimal(
                            dsInit_Hdbanhang_Chitiet.Tables[0].Compute("SUM(Soluong)", "Id_Hanghoa_Ban=" + drTP["Id_Hanghoa_Ban"])
                            );
                        Soluong_Hhmua_PerTP += Soluong_Sum * Convert.ToDecimal(drTP["Soluong_Hhmua_Per1TP"]);
                        Soluong_TP_SDNL += Soluong_Sum;
                    }

                    //if NL full
                    if (Soluong_Hhmua <= Soluong_Hhmua_PerTP)
                    {
                   
                        foreach (DataRow drTP_SDNL in sdrTP_SDNL)
                        {
                            drTP_SDNL["Soluong_HHMua_IsFull"] = true;
                            foreach (DataRow drTP in dsInit_Hdbanhang_Chitiet.Tables[0].Select("Id_Hanghoa_Ban=" + drTP_SDNL["Id_Hanghoa_Ban"]))
                                drTP["Soluong_HHMua_IsFull"] = true;
                        }
                    }

                }

                #endregion

                if (Convert.ToBoolean(dsInit_Hdbanhang_Chitiet.Tables[0].Rows[iRow]["Soluong_HHMua_IsFull"])) continue;
                DataRow drnew = dsInit_Hdbanhang_Chitiet.Tables[0].NewRow();
                foreach (DataColumn col in drnew.Table.Columns)
                    drnew[col.ColumnName] = dsInit_Hdbanhang_Chitiet.Tables[0].Rows[iRow][col.ColumnName];               
                dsInit_Hdbanhang_Chitiet.Tables[0].Rows.Add(drnew);
                drnew.AcceptChanges();
            }

            foreach (DataRow dr in dsInit_Hdbanhang_Chitiet.Tables[0].Rows)
            {
                int Random_Id_Hdbanhang = random_Hoadon.Next(nHoadon);
                dr["Random_Id_Hdbanhang"] = Random_Id_Hdbanhang;
                if (!Arr_Random_Id_Hdbanhang.Contains(Random_Id_Hdbanhang))
                    Arr_Random_Id_Hdbanhang.Add(Random_Id_Hdbanhang);
            }

            dsInit_Hdbanhang_Chitiet.AcceptChanges();
            dgware_Hanghoa_Selected.DataSource = dsInit_Hdbanhang_Chitiet;
            dgware_Hanghoa_Selected.DataMember = dsInit_Hdbanhang_Chitiet.Tables[0].TableName;

            this.ChangeFormState( GoobizFrame.Windows.Forms.FormState.Edit);

            WaitDialogForm.Close();
            return base.PerformQuery();
        }

        public override bool PerformSave()
        {
            if ("" + lookUpEditMa_Kho_Hanghoa.EditValue == "")
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] { lblKho_Hanghoa.Text, lblKho_Hanghoa.Text});
                return false;
            }

            if ("" + txtSohoadon.EditValue == "")
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("Msg00008", new string[] { lblSo_Hoadon.Text, lblSo_Hoadon.Text });
                return false;
            }
            
            //delete all hdbanhang from donmuahang
            Ecm.WebReferences.WareService.Ware_Donmuahang objWare_Donmuahang = new Ecm.WebReferences.WareService.Ware_Donmuahang();
            objWare_Donmuahang.Id_Donmuahang = Id_Donmuahang;
            objWareService.Delete_WareGen_Hdbanhang_ByDonmuahang(objWare_Donmuahang);

            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            //neu co hdbanhang duoc chon --> save
            if (this.Arr_Random_Id_Hdbanhang != null && this.Arr_Random_Id_Hdbanhang.Count > 0)
            {
                //them file Id_Hdbanhang
                dsInit_Hdbanhang_Chitiet.Tables[0].Columns.Add("Id_Hdbanhang");
                dsInit_Hdbanhang_Chitiet.Tables[0].Columns.Add("Id_Hdbanhang_Chitiet");

                for (int i = 0; i < this.Arr_Random_Id_Hdbanhang.Count; i++)
                {
                    object Random_Id_Hdbanhang = this.Arr_Random_Id_Hdbanhang[i];
                    object thanhtien = dsInit_Hdbanhang_Chitiet.Tables[0].Compute("SUM(Thanhtien)", "Random_Id_Hdbanhang=" + Random_Id_Hdbanhang);
                    decimal Sotien = Convert.ToDecimal("0"+thanhtien) / Convert.ToDecimal(1.1);
                    decimal Sotien_Vat = Convert.ToDecimal(0.1) * Convert.ToDecimal("0"+thanhtien) / Convert.ToDecimal(1.1);

                    Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();

                    objWare_Hdbanhang.Id_Hdbanhang = -1;
                    objWare_Hdbanhang.Id_Donmuahang = Id_Donmuahang;
                    objWare_Hdbanhang.Hoten_Nguoimua = "";
                    objWare_Hdbanhang.Per_Vat = 10;
                    objWare_Hdbanhang.Phuongthuc_Thanhtoan = "TM";
                    objWare_Hdbanhang.So_Seri = "";
                    objWare_Hdbanhang.Sochungtu = objWareService.GetNew_Sochungtu("WareGen_Hdbanhang", "Sochungtu", lookUpEditMa_Kho_Hanghoa.GetColumnValue("DocCode")); ;
                    objWare_Hdbanhang.Sotien = Sotien;
                    objWare_Hdbanhang.Sotien_Vat = Sotien_Vat;
                    objWare_Hdbanhang.Ngay_Chungtu = Ngay_Chungtu;
                    objWare_Hdbanhang.Ngay_Thanhtoan = Ngay_Chungtu;

                    if ("" + lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Cuahang_Ban") != "")
                        objWare_Hdbanhang.Id_Cuahang_Ban = lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Cuahang_Ban");
                    if ("" + lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua") != "")
                        objWare_Hdbanhang.Id_Kho_Hanghoa_Mua = lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua");

                    object identity = objWareService.Insert_WareGen_Hdbanhang(objWare_Hdbanhang);

                    if (identity != null)
                    {
                        foreach (DataRow dr in dsInit_Hdbanhang_Chitiet.Tables[0].Select("Random_Id_Hdbanhang = " + Random_Id_Hdbanhang))
                        {
                            dr["Id_Hdbanhang"] = identity;
                            dr.AcceptChanges();
                            dr.SetAdded();
                        }
                    }
                }

                //update hdmuahang_chitiet                        
                objWareService.Update_WareGen_Hdbanhang_Chitiet_Collection(dsInit_Hdbanhang_Chitiet);
                dsInit_Hdbanhang_Chitiet.AcceptChanges();

                WaitDialogForm.Close();

                this.Close();
            }
            return base.PerformSave();
        }


        #endregion
 
    }
}