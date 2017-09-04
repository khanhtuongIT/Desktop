using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms.WareGen_Hdbanhang
{
    public partial class FrmwareGen_RandomList_Hanghoa :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        public DataSet DsRandom_Hanghoa;
        public DataSet dsHanghoa_Selected_Source = new DataSet();
        public System.Collections.ArrayList Arr_Random_Id_Hdbanhang = new System.Collections.ArrayList();

        public FrmwareGen_RandomList_Hanghoa()
        {
            InitializeComponent();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            DisplayInfo();

        }

        public FrmwareGen_RandomList_Hanghoa(DataSet dsHanghoa_Selected_Source)
        {
            InitializeComponent();
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            this.dsHanghoa_Selected_Source = dsHanghoa_Selected_Source;
            DisplayInfo();

        }

        public override void DisplayInfo()
        {
            DataSet dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            gridLookUpEdit_Donvitinh_2.DataSource = dsDonvitinh.Tables[0];


            dgware_Hanghoa_Selected.DataSource = dsHanghoa_Selected_Source;
            dgware_Hanghoa_Selected.DataMember = dsHanghoa_Selected_Source.Tables[0].TableName;
            gridView4.BestFitColumns();

            base.DisplayInfo();
        }

        #region override
        public override bool PerformQuery()
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            Arr_Random_Id_Hdbanhang = new System.Collections.ArrayList();
            DataSet dsHanghoa_Selected = dsHanghoa_Selected_Source.Copy();

            //set random soluong
            int nRecords = dsHanghoa_Selected.Tables[0].Rows.Count;
            decimal vThanhtien = 0;
            System.Random randomRow = new Random();
            int nSkip = 0;
            while (true)
            {
                int iRow = randomRow.Next(nRecords);

                dsHanghoa_Selected.Tables[0].Rows[iRow]["Soluong"] =
                    Convert.ToInt32("0" + dsHanghoa_Selected.Tables[0].Rows[iRow]["Soluong"]) + 1;

                dsHanghoa_Selected.Tables[0].Rows[iRow]["Thanhtien"] =
                    Convert.ToDecimal(dsHanghoa_Selected.Tables[0].Rows[iRow]["Soluong"])
                    * Convert.ToDecimal(dsHanghoa_Selected.Tables[0].Rows[iRow]["Dongia_Ban"])
                    * (1 - Convert.ToDecimal("0" + dsHanghoa_Selected.Tables[0].Rows[iRow]["Per_Dongia"]) / 100);

                vThanhtien += Convert.ToDecimal(dsHanghoa_Selected.Tables[0].Rows[iRow]["Dongia_Ban"])
                    * (1 - Convert.ToDecimal("0" + dsHanghoa_Selected.Tables[0].Rows[iRow]["Per_Dongia"]) / 100);
                if (vThanhtien - Convert.ToDecimal(txtSotien.EditValue) > 1000)
                {
                    vThanhtien -= Convert.ToDecimal(dsHanghoa_Selected.Tables[0].Rows[iRow]["Dongia_Ban"])
                    * (1 - Convert.ToDecimal("0" + dsHanghoa_Selected.Tables[0].Rows[iRow]["Per_Dongia"]) / 100);
                    dsHanghoa_Selected.Tables[0].Rows[iRow].RejectChanges();
                    nSkip++;
                    if (nSkip > 100)
                        break;
                    else
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
                if (!Arr_Random_Id_Hdbanhang.Contains(Random_Id_Hdbanhang))
                    Arr_Random_Id_Hdbanhang.Add(Random_Id_Hdbanhang);
            }


            DsRandom_Hanghoa = dsHanghoa_Selected.Clone();
            foreach (DataRow drHanghoa in dsHanghoa_Selected.Tables[0].Select("Random_Id_Hdbanhang is not null"))
                DsRandom_Hanghoa.Tables[0].ImportRow(drHanghoa);

            dgware_Hanghoa_Selected.DataSource = null;
            dgware_Hanghoa_Selected.DataSource = DsRandom_Hanghoa;
            dgware_Hanghoa_Selected.DataMember = DsRandom_Hanghoa.Tables[0].TableName;
            gridView4.BestFitColumns();
            this.ChangeFormState( GoobizFrame.Windows.Forms.FormState.Edit);

            WaitDialogForm.Close();
            return base.PerformQuery();
        }
        public override bool PerformSave()
        {
            this.Close();
            return base.PerformSave();
        }
        public override bool PerformCancel()
        {
            return base.PerformCancel();
        }
        #endregion
    }
}