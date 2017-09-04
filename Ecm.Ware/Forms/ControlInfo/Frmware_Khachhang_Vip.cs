using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Khachhang_Vip :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Collection = new DataSet();
        
        #region Properties

        object id_khachhang;
        public object Id_Khachhang
        {
            get { return id_khachhang; }
            set
            {
                id_khachhang = value;
                DisplayInfo();
            }
        }
        #endregion

        public Frmware_Khachhang_Vip()
        {
            InitializeComponent();
            this.DisplayInfo();
        }

    
        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                DataSet dsKhachhang  = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                gridLookUpEdit_Khachhang.DataSource = dsKhachhang.Tables[0];

                //Get data Ware_Dm_Hanghoa
                gridLookUpEdit_Kho_Hanghoa.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa().ToDataSet().Tables[0];

                ds_Collection = objWareService.Get_All_Ware_Khachhang_Vip_Detail_By_Khachhang(""+id_khachhang).ToDataSet();
                dgware_Khachhang_Vip.DataSource = ds_Collection;
                dgware_Khachhang_Vip.DataMember = ds_Collection.Tables[0].TableName;

                this.Data = ds_Collection;
                this.GridControl = dgware_Khachhang_Vip;


                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

               }

        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Id_Khachhang"], "");
            hashtableControls.Add(gridView1.Columns["Ma_Kho_Hanghoa"], "");
            hashtableControls.Add(gridView1.Columns["Per_Hoadon"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                this.DoClickEndEdit(dgware_Khachhang_Vip); 
                objWareService.Update_Ware_Khachhang_Vip_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            this.DisplayInfo();
            return true;
        }
       
        #endregion

        #region Even

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Ma_Kho_Hanghoa")
            {
                DataRow focus_row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                focus_row["Id_Cuahang_Ban"] = ((System.Data.DataRowView)gridLookUpEdit_Kho_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Id_Cuahang_Ban"];
                focus_row["Id_Kho_Hanghoa_Mua"] = ((System.Data.DataRowView)gridLookUpEdit_Kho_Hanghoa.GetDataSourceRowByKeyValue(e.Value))["Id_Kho_Hanghoa_Mua"];
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["Id_Khachhang"], id_khachhang);
        }

        #endregion

    }
}

