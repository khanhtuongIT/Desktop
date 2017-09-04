using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Nhansu_Dialog : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        public long[] Id_Nhansu;
        object Id_Bophan;
        public Ecm.WebReferences.RexService.Rex_Nhansu SelectedRex_Nhansu;

        public Frmrex_Nhansu_Dialog()
        {
            InitializeComponent();
            this.item_Add.Visibility    = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility   = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Save.Visibility   = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //TreeList
                DataSet ds_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
                treeListColumn1.TreeList.DataSource = ds_Bophan.Tables[0];

                this.gvrex_Nhansu.BestFitColumns();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }

        }

        public void DisplayInfo2()
        {
            //if(isLoaded)
            lock (this)
            {
                try
                {
                    ds_Collection = objRexService.Get_Rex_Nhansu_ByBoPhan_Collection(Id_Bophan).ToDataSet();
                    //DataSet ds = objRex.GetAll_Rex_Nhansu_By_Bophan_Collection(id_bophan);
                    ds_Collection.Tables[0].Columns["Ngaysinh"].ReadOnly = false;
                    //foreach (DataRow row_rex_nhansu in ds_Collection.Tables[0].Rows)
                    //    row_rex_nhansu["Ngaysinh"] = GoobizFrame.Windows.MdiUtils.DateTimeMask.YMDToShortDatePattern("" + row_rex_nhansu["Ngaysinh"],
                    //        GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat());

                    dgrex_Nhansu.DataSource = ds_Collection.Tables[0];
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                }
            }
        }

        private void treeList_Bophan_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            Id_Bophan = Convert.ToInt64("" + e.Node.GetValue("Id_Bophan"));
            DisplayInfo2();
        }

        public override object PerformSelectOneObject()
        {
            //int[] id_nhansu_chon = gridView1.GetSelectedRows();
            //Id_Nhansu = new long[id_nhansu_chon.Length];
            //for (int i = 0; i < Id_Nhansu.Length; i++)
            //{
            //    Id_Nhansu[i] = Convert.ToInt64(gridView1.GetRowCellValue(id_nhansu_chon[i], "Id_Nhansu"));
            //}
            //this.Dispose();
            //this.Close();
            if ("" + gvrex_Nhansu.GetFocusedRowCellValue("Id_Nhansu") != "")
            {
                SelectedRex_Nhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();
                SelectedRex_Nhansu.Id_Nhansu = gvrex_Nhansu.GetFocusedRowCellValue("Id_Nhansu");
                SelectedRex_Nhansu.Ma_Nhansu = gvrex_Nhansu.GetFocusedRowCellValue("Ma_Nhansu");
                SelectedRex_Nhansu.Ten_Nhansu = gvrex_Nhansu.GetFocusedRowCellValue("Ten_Nhansu");
                SelectedRex_Nhansu.Ngay_Sinh = gvrex_Nhansu.GetFocusedRowCellValue("Ngay_Sinh");
                SelectedRex_Nhansu.Ngaysinh = gvrex_Nhansu.GetFocusedRowCellValue("Ngaysinh");
                SelectedRex_Nhansu.Noisinh = gvrex_Nhansu.GetFocusedRowCellValue("Noisinh");
                SelectedRex_Nhansu.Dienthoai = gvrex_Nhansu.GetFocusedRowCellValue("Dienthoai");
                SelectedRex_Nhansu.Id_Bophan = treeListColumn1.TreeList.FocusedNode.GetValue("Id_Bophan");
                SelectedRex_Nhansu.Hoten_Nhansu = gvrex_Nhansu.GetFocusedRowCellValue("Hoten_Nhansu");
                this.Dispose();
                this.Close();
                return SelectedRex_Nhansu;                
            }
            return base.PerformSelectOneObject();
        }
    }
}

