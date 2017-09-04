using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms.WareGen_Hdbanhang
{
    public partial class FrmwareGen_Dm_Hanghoa_Tree :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet dsHanghoa_TreeFull;
        public DataSet dsHanghoa_Selected;
        public object Ngay_Chungtu;

        public FrmwareGen_Dm_Hanghoa_Tree()
        {
            InitializeComponent();

            dtNgay_Batdau.EditValue = objWareService.GetServerDateTime();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        #region  override

        public override void DisplayInfo()
        {
            DataSet dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];


            dsHanghoa_TreeFull = objMasterService.Get_All_Ware_Dm_Hanghoa_TreeFull(dtNgay_Batdau.DateTime).ToDataSet();
            dsHanghoa_TreeFull.Tables[0].Columns.Add("Chon", typeof(bool));
            treeListColumn1.TreeList.DataSource = dsHanghoa_TreeFull.Tables[0];

            base.DisplayInfo();
        }

        public override object PerformSelectOneObject()
        {
            GetSelectedDataRows();
            Ngay_Chungtu = dtNgay_Batdau.EditValue;
            this.Close();
            return base.PerformSelectOneObject();
        }
        #endregion

        #region  Even

        private void btnDisplay_Hanghoa_Click(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Chon")
            {
                DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();

                DataRowView drvFocused = (DataRowView)treeListColumn1.TreeList.GetDataRecordByNode(treeListColumn1.TreeList.FocusedNode);
                object parentkey = drvFocused["Ma_Ql_Pk"];
                object key = drvFocused["Ma_Ql"];

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

                WaitDialogForm.Close();
            }
        }
        #endregion

        #region Custom method

        void CheckAllChildren(DataSet ds, object key, object value)
        {
            DataRow[] sdrChildren = ds.Tables[0].Select("Ma_Ql_Pk = '" + key + "'");
            foreach (DataRow drChild in sdrChildren)
            {
                drChild["Chon"] = value;
                CheckAllChildren(ds, drChild["Ma_Ql"], value);
            }
        }

        public DataSet GetSelectedDataRows()
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

            return dsHanghoa_Selected;
        }
        #endregion

   
               
    }
}