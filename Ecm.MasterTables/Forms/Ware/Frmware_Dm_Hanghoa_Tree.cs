using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Hanghoa_Tree :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet dsCollection = new DataSet();
        public DataRow SelectedRow = null;
        public bool Bc_Doanhso = true;

        private Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban _Ware_Dm_Hanghoa_Ban;
        public Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban Selected_Ware_Dm_Hanghoa_Ban
        {
            get { return _Ware_Dm_Hanghoa_Ban; }
            set { _Ware_Dm_Hanghoa_Ban = value; }
        }

        public Frmware_Dm_Hanghoa_Tree()
        {
            InitializeComponent();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            
            //treeListColumn1.TreeList.ExpandAll();
        }

        public override void DisplayInfo()
        {
            dsCollection = objMasterService.Get_All_Ware_Dm_Hanghoa_Tree(Bc_Doanhso, null, null).ToDataSet();
            treeListColumn1.TreeList.DataSource = dsCollection.Tables[0];

            base.DisplayInfo();
        }
        public override object PerformSelectOneObject()
        {
            SelectedRow = dsCollection.Tables[0].NewRow();
            SelectedRow["Id_Nhom_Hanghoa"] =    treeListColumn1.TreeList.FocusedNode.GetValue("Id_Nhom_Hanghoa");
            SelectedRow["Id_Loai_Hanghoa"] =    treeListColumn1.TreeList.FocusedNode.GetValue("Id_Loai_Hanghoa");
            SelectedRow["Id_Hanghoa"] =         treeListColumn1.TreeList.FocusedNode.GetValue("Id_Hanghoa");
            SelectedRow["Ma_Hanghoa"] =         treeListColumn1.TreeList.FocusedNode.GetValue("Ma_Hanghoa");
            SelectedRow["Ten_Hanghoa"] =        treeListColumn1.TreeList.FocusedNode.GetValue("Ten_Hanghoa");
            SelectedRow["Ma_Ql"] =              treeListColumn1.TreeList.FocusedNode.GetValue("Ma_Ql");
            SelectedRow["Ma_Ql_Pk"] =           treeListColumn1.TreeList.FocusedNode.GetValue("Ma_Ql_Pk");

            _Ware_Dm_Hanghoa_Ban = new WebReferences.MasterService.Ware_Dm_Hanghoa_Ban()
            {
                Barcode_Txt = treeListColumn1.TreeList.FocusedNode.GetValue("Barcode_Txt"),
                Dongia_Mua = treeListColumn1.TreeList.FocusedNode.GetValue("Dongia_Mua"),
                Hamluong = treeListColumn1.TreeList.FocusedNode.GetValue("Hamluong"),
                Id_Donvitinh = treeListColumn1.TreeList.FocusedNode.GetValue("Id_Donvitinh"),
                Id_Hanghoa_Ban = treeListColumn1.TreeList.FocusedNode.GetValue("Id_Hanghoa_Ban"),
                Ma_Hanghoa_Ban = treeListColumn1.TreeList.FocusedNode.GetValue("Ma_Hanghoa_Ban"),
                Quycach = treeListColumn1.TreeList.FocusedNode.GetValue("Quycach"),
                Ten_Hanghoa_Ban = treeListColumn1.TreeList.FocusedNode.GetValue("Ten_Hanghoa_Ban"),
            };

                this.Close();
           return base.PerformSelectOneObject();
        }

        private void Frmware_Dm_Hanghoa_Tree_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dsCollection = objMasterService.Get_All_Ware_Dm_Hanghoa_Tree(
                Bc_Doanhso,
                (""+txtMa_Hanghoa_Ban.EditValue!="")?txtMa_Hanghoa_Ban.EditValue:null,
                ("" + txtTen_Hanghoa_Ban.EditValue != "") ? txtTen_Hanghoa_Ban.EditValue : null).ToDataSet();
            treeListColumn1.TreeList.DataSource = dsCollection.Tables[0];
            treeListColumn1.TreeList.ExpandAll();
        }
    }
}