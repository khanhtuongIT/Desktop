using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Dm_Cuahang_Ban_Dialog : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        object id_dieuxe;
        public DataRow[] _selectedRows;
         DataSet ds_Collection = new DataSet();
        DataSet dsDieuxe_Cuahang;

        public Frmware_Dm_Cuahang_Ban_Dialog(object Id_Dieuxe)
        {
            InitializeComponent();
            id_dieuxe = Id_Dieuxe;
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                ds_Collection = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet();
                ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));
                dgware_Dm_Cuahang_Ban.DataSource = ds_Collection;
                dgware_Dm_Cuahang_Ban.DataMember = ds_Collection.Tables[0].TableName;
                this.gvCuahang_Ban.BestFitColumns();

                dsDieuxe_Cuahang = objWareService.Ware_Dieuxe_Cuahang_Ban_SelectBy_Id_Dieuxe(id_dieuxe).ToDataSet();
                foreach (DataRow dtr in ds_Collection.Tables[0].Rows)
                {
                    if (dsDieuxe_Cuahang.Tables[0].Select("Id_Cuahang_Ban = " + dtr["Id_Cuahang_Ban"]).Length > 0)
                        dtr["Chon"] = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Event Override

        public override object PerformSelectOneObject()
        {
            try
            {
                if (ds_Collection == null || ds_Collection.Tables.Count == 0)
                    return false;

                _selectedRows = ds_Collection.Tables[0].Select("Chon=true");
                if (_selectedRows == null || _selectedRows.Length == 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "Khu vực" });
                    return false;
                }

                foreach(DataRow row in dsDieuxe_Cuahang.Tables[0].Rows)
                {
                    row.Delete();
                }
                
                foreach (DataRow row in _selectedRows)
                {
                    DataRow new_row = dsDieuxe_Cuahang.Tables[0].NewRow();
                    new_row["Id_Dieuxe"] = id_dieuxe;
                    new_row["Id_Cuahang_Ban"] = row["Id_Cuahang_Ban"];
                    dsDieuxe_Cuahang.Tables[0].Rows.Add(new_row);
                }
                objWareService.Update_Ware_Dieuxe_Cuahang_Ban_Collection(dsDieuxe_Cuahang);

                Dispose();
                return _selectedRows;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        #endregion

    }
}

