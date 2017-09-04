using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_Gen_Hdbanhang_Frhanghoa : SunLine.Windows.Forms.FormUpdateWithToolbar
    {
        WareService.WareService objWareService = new SunLine.Ware.WareService.WareService();
        RexService.RexService objRexService = new SunLine.Ware.RexService.RexService();
        DataSet dsHanghoa_TreeFull;
        DataSet dsHanghoa_Selected;
        DataSet dsNhansu;

        public Frmware_Gen_Hdbanhang_Frhanghoa()
        {
            InitializeComponent();
            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            DataSet dsDonvitinh = objWareService.Get_All_Ware_Dm_Donvitinh();
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];
            gridLookUpEdit_Donvitinh_2.DataSource = dsDonvitinh.Tables[0];

            //lookUpEditMa_Kho_Hanghoa
            lookUpEditMa_Kho_Hanghoa.Properties.DataSource = objWareService.Get_All_Ware_Dm_Kho_Hanghoa().Tables[0];

            //Get data Rex_Nhansu
            dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection();
            lookUpEdit_Nhansu_Banhang.Properties.DataSource = dsNhansu.Tables[0];
            //gridLookUpEdit_Kho_Hanghoa.DataSource = objWareService.Get_All_Ware_Dm_Kho_Hanghoa().Tables[0];

            //gridLookUpEdit_Khachhang.DataSource = objWareService.Get_All_Ware_Dm_Khachhang().Tables[0];

            //gridLookUpEdit_Nhansu.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().Tables[0];
            dsHanghoa_TreeFull = objWareService.Get_All_Ware_Dm_Hanghoa_TreeFull(dtNgay_Batdau.DateTime);
            dsHanghoa_TreeFull.Tables[0].Columns.Add("Chon", typeof(bool));
            treeListColumn1.TreeList.DataSource = dsHanghoa_TreeFull.Tables[0];

            //DataSet dsAll_Hanghoa = objWareService.Get_All_Ware_Dm_Hanghoa();
            //gridLookUpEdit_Ma_Hanghoa.DataSource = dsAll_Hanghoa.Tables[0];
            //gridLookUpEdit_Ten_Hanghoa.DataSource = dsAll_Hanghoa.Tables[0];

            base.DisplayInfo();
        }

        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Chon")
            {
                DataRowView drvFocused = (DataRowView)treeListColumn1.TreeList.GetDataRecordByNode(treeListColumn1.TreeList.FocusedNode);
                object parentkey    = drvFocused["Ma_Ql_Pk"];
                object key          = drvFocused["Ma_Ql"];
                    
                dsHanghoa_TreeFull.AcceptChanges();

                //neu node vua chon khong co con -- node la
                if (!e.Node.HasChildren)
                {
                    DataRow[] sdrCheck = dsHanghoa_TreeFull.Tables[0].Select("Ma_Ql_Pk = '" + parentkey + "' and Chon=true");
                    try
                    {
                        DataRow[] sdrParent = dsHanghoa_TreeFull.Tables[0].Select("Ma_Ql = '" + parentkey + "'");
                        if (sdrCheck.Length > 0)
                            sdrParent[0]["Chon"] = true;
                        else
                            sdrParent[0]["Chon"] = false;
                    }
                    catch { }
                }
                else
                    CheckAllChildren(dsHanghoa_TreeFull, key, drvFocused["Chon"]);
            }
        }

        void CheckAllChildren(DataSet ds, object key, object value)
        {
            DataRow[] sdrChildren = ds.Tables[0].Select("Ma_Ql_Pk = '" + key + "'");
            foreach (DataRow drChild in sdrChildren)
            {
                drChild["Chon"] = value;
                CheckAllChildren(ds, drChild["Ma_Ql"], value);
            }
        }

        private void dgware_Hdbanhang_Chitiet_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        private void btnDisplay_Hanghoa_Click(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnGen_Ds_Hanghoa_Click(object sender, EventArgs e)
        {
            dsHanghoa_Selected = dsHanghoa_TreeFull.Clone();
            dsHanghoa_Selected.Tables[0].Columns.Add("Soluong", typeof(int));
            dsHanghoa_Selected.Tables[0].Columns.Add("Thanhtien", typeof(decimal));
            dsHanghoa_Selected.Tables[0].Columns.Add("Random_Id_Hdbanhang", typeof(long));

            //import all selected hang hoa
            DataRow[] sdrHanghoa = dsHanghoa_TreeFull.Tables[0].Select("Chon=true and (Id_Hanghoa_Mua is not null or Id_Hanghoa_Ban is not null)");
            foreach (DataRow drHanghoa in sdrHanghoa)
            {
                dsHanghoa_Selected.Tables[0].ImportRow(drHanghoa);
            }

            //set random soluong
            int nRecords = dsHanghoa_Selected.Tables[0].Rows.Count;
            decimal vThanhtien = 0;
            System.Random randomRow = new Random();
            while (true)
            {
                int iRow = randomRow.Next(nRecords);

                dsHanghoa_Selected.Tables[0].Rows[iRow]["Soluong"] =
                    Convert.ToInt32("0" + dsHanghoa_Selected.Tables[0].Rows[iRow]["Soluong"]) + 1;

                dsHanghoa_Selected.Tables[0].Rows[iRow]["Thanhtien"] =
                    Convert.ToDecimal( dsHanghoa_Selected.Tables[0].Rows[iRow]["Soluong"])
                    * Convert.ToDecimal(dsHanghoa_Selected.Tables[0].Rows[iRow]["Dongia_Ban"])
                    * (1 - Convert.ToDecimal("0"+dsHanghoa_Selected.Tables[0].Rows[iRow]["Per_Dongia"]) / 100);

                vThanhtien += Convert.ToDecimal(dsHanghoa_Selected.Tables[0].Rows[iRow]["Dongia_Ban"])
                    * (1 - Convert.ToDecimal("0" + dsHanghoa_Selected.Tables[0].Rows[iRow]["Per_Dongia"]) / 100);
                if (vThanhtien - Convert.ToDecimal(txtSotien.EditValue) > 1000)
                {
                    vThanhtien -= Convert.ToDecimal(dsHanghoa_Selected.Tables[0].Rows[iRow]["Dongia_Ban"])
                    * (1 - Convert.ToDecimal("0" + dsHanghoa_Selected.Tables[0].Rows[iRow]["Per_Dongia"]) / 100);
                    dsHanghoa_Selected.Tables[0].Rows[iRow].RejectChanges();
                    continue;
                }
                else if (vThanhtien - Convert.ToDecimal(txtSotien.EditValue) > 0
                    && vThanhtien - Convert.ToDecimal(txtSotien.EditValue) <= 1000)
                    break;
                else
                    dsHanghoa_Selected.Tables[0].Rows[iRow].AcceptChanges();
            }

            //set Random_Id_Hdbanhang
            DataRow[] sdrHanghoa_Changed = dsHanghoa_Selected.Tables[0].Select("Soluong > 0");
            int nHoadon = Convert.ToInt32(txtSohoadon.EditValue);
            System.Random random_Hoadon = new Random();
            foreach (DataRow drHanghoa in sdrHanghoa_Changed)
            {
                int Random_Id_Hdbanhang = random_Hoadon.Next(nHoadon);
                drHanghoa["Random_Id_Hdbanhang"] = Random_Id_Hdbanhang;
            }


            dgware_Hanghoa_Selected.DataSource = dsHanghoa_Selected;
            dgware_Hanghoa_Selected.DataMember = dsHanghoa_Selected.Tables[0].TableName;
            gridView4.BestFitColumns();

        }

       

    }
}