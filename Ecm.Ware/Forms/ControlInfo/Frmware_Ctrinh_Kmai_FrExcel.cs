using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using Ecm.WebReferences.MasterService;
using  GoobizFrame.Windows.MdiUtils;
using DevExpress.XtraGrid.Columns;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Ctrinh_Kmai_FrExcel :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public DataSet ds_Collection = new DataSet();
        DataSet dsMaps = new DataSet();
        public Ware_Dm_Hanghoa_Mua SelectedWare_Dm_Hanghoa_Mua;
         GoobizFrame.Windows.Tools.FrmImportFromExcel frmImportFromExcel;

        public Frmware_Ctrinh_Kmai_FrExcel()
        {
            InitializeComponent();
            this.BarSystem.Visible = false;
            DisplayInfo();
        }

        void showTabPages(DevExpress.XtraTab.XtraTabPage tabpage)
        {
            while (xtraTabControl1.TabPages.Count > 0)
                xtraTabControl1.TabPages.RemoveAt(0);
            xtraTabControl1.TabPages.Add(tabpage);
        }

        public override void  DisplayInfo()
        {
            //gridLookUpEdit_ColumnsMap
            DataSet dsFieldNames = new DataSet();
            dsFieldNames.Tables.Add("ColumnsMap");
            dsFieldNames.Tables[0].Columns.Add("FieldName");
            dsFieldNames.Tables[0].Columns.Add("Caption");
            foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView1.Columns)
            {
                DataRow ndr = dsFieldNames.Tables[0].NewRow();
                ndr["FieldName"] = gridColumn.FieldName;
                ndr["Caption"] = gridColumn.Caption;
                dsFieldNames.Tables[0].Rows.Add(ndr);
            }
            dsFieldNames.AcceptChanges();
            gridLookUpEdit_ColumnsMap.DataSource = dsFieldNames.Tables[0];
            //click delete --> delete selected value
            gridLookUpEdit_ColumnsMap.ProcessNewValue += Validator.LookUpEdit_Properties_ProcessNewValue;
            showTabPages(tabDulieu);
            if (gridView3.RowCount > 0)
                btn_Continue1.Visible = true;
            else
                btn_Continue1.Visible = false;
        }

        #region  Even

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            frmImportFromExcel = new  GoobizFrame.Windows.Tools.FrmImportFromExcel();
            frmImportFromExcel.ShowDialog();
            if (frmImportFromExcel.DsImportData != null && frmImportFromExcel.DsImportData.Tables.Count > 0)
            {
                dsMaps = new DataSet();
                dsMaps.Tables.Add();
                dsMaps.Tables[0].Columns.Add("Excel_Col");
                dsMaps.Tables[0].Columns.Add("FieldName");
                foreach (DataColumn col in frmImportFromExcel.DsImportData.Tables[0].Columns)
                {
                    DataRow ndr = dsMaps.Tables[0].NewRow();
                    ndr["Excel_Col"] = col.ColumnName;
                    dsMaps.Tables[0].Rows.Add(ndr);
                }
                dsMaps.AcceptChanges();
                dgColumnsMap.DataSource = dsMaps;
                dgColumnsMap.DataMember = dsMaps.Tables[0].TableName;
                //show selected data
                gridView3.Columns.Clear();
                int visibleIndex = 0;
                foreach (DataColumn col in frmImportFromExcel.DsImportData.Tables[0].Columns)
                {
                    try
                    {
                        GridColumn gridColumn = new GridColumn();
                        gridColumn.FieldName = col.ColumnName;
                        gridColumn.Caption = col.ColumnName;
                        gridColumn.VisibleIndex = visibleIndex++;
                        gridColumn.Visible = true;
                        gridView3.Columns.Add(gridColumn);
                    }
                    catch (Exception ex) { continue; }
                }
                dgDataImport.DataSource = frmImportFromExcel.DsImportData;
                dgDataImport.DataMember = frmImportFromExcel.DsImportData.Tables[0].TableName;
                gridView3.BestFitColumns();
                showTabPages(tabChoncot);
            }
        }

        private void btnShowMappedData_Click(object sender, EventArgs e)
        {
            if (frmImportFromExcel == null || frmImportFromExcel.DsImportData == null)
                return;
            dgware_Ctrinh_Kmai_Chitiet.DataSource = null;
            DataSet dsAll_Hanghoa = objMasterService.Get_All_Ware_Dm_Hanghoa_Tree(true, null, null).ToDataSet();
            this.DoClickEndEdit(dgColumnsMap); 
            this.ds_Collection = objWareService.Get_All_Ware_Ctrinh_Kmai_Chitiet_By_Ctrinh_Kmai(0).ToDataSet();

            foreach (DataRow imp_row in frmImportFromExcel.DsImportData.Tables[0].Rows)
            {
                try
                {
                    DataRow ndr = ds_Collection.Tables[0].NewRow();
                    foreach (DataRow map_row in dsMaps.Tables[0].Rows)
                    {
                        try
                        {
                            if ("" + map_row["FieldName"] != "")
                            {
                                ndr["" + map_row["FieldName"]] = imp_row["" + map_row["Excel_Col"]];
                            }
                        }
                        catch (Exception ex) { continue; }
                    }
                    ds_Collection.Tables[0].Rows.Add(ndr);
                }
                catch (Exception ex) { continue; }
            }

            foreach (DataRow dr in ds_Collection.Tables[0].Rows)
            {
                try
                {
                    DataRow drDm_Hanghoa = dsAll_Hanghoa.Tables[0].Select("Ma_Hanghoa='" + dr["Barcode_Txt"] + "'")[0];
                    dr["Id_Hanghoa_Mua"] = drDm_Hanghoa["Id_Hanghoa_Mua"];
                    dr["Id_Hanghoa_Ban"] = drDm_Hanghoa["Id_Hanghoa_Ban"];
                    dr["Ma_Hanghoa"] = drDm_Hanghoa["Ma_Ql"].ToString().Replace("Pro", "");
                }
                catch (Exception ex) { continue; }
            }
            ds_Collection.AcceptChanges();
            dgware_Ctrinh_Kmai_Chitiet.DataSource = ds_Collection.Tables[0];
            gridView1.BestFitColumns();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ds_Collection = null;
            this.Close();
        }
        #endregion

        private void btn_Continue1_Click(object sender, EventArgs e)
        {
            showTabPages(tabChoncot);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            showTabPages(tabKetchuyen);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            showTabPages(tabDulieu);            
            if (gridView3.RowCount > 0)
                btn_Continue1.Visible = true;
            else
                btn_Continue1.Visible = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            showTabPages(tabChoncot);
        }

        private void btnShowMappedData_Click_1(object sender, EventArgs e)
        {
            if (frmImportFromExcel == null || frmImportFromExcel.DsImportData == null)
                return;
            dgware_Ctrinh_Kmai_Chitiet.DataSource = null;
            DataSet dsAll_Hanghoa = objMasterService.Get_All_Ware_Dm_Hanghoa_Tree(true, null, null).ToDataSet();
            this.DoClickEndEdit(dgColumnsMap);
            this.ds_Collection = objWareService.Get_All_Ware_Ctrinh_Kmai_Chitiet_By_Ctrinh_Kmai(0).ToDataSet();
            foreach (DataRow imp_row in frmImportFromExcel.DsImportData.Tables[0].Rows)
            {
                try
                {
                    DataRow ndr = ds_Collection.Tables[0].NewRow();
                    foreach (DataRow map_row in dsMaps.Tables[0].Rows)
                    {
                        try
                        {
                            if ("" + map_row["FieldName"] != "")
                            {
                                ndr["" + map_row["FieldName"]] = imp_row["" + map_row["Excel_Col"]];
                            }
                        }
                        catch (Exception ex) { continue; }
                    }
                    ds_Collection.Tables[0].Rows.Add(ndr);
                }
                catch (Exception ex) { continue; }
            }
            foreach (DataRow dr in ds_Collection.Tables[0].Rows)
            {
                try
                {
                    DataRow drDm_Hanghoa = dsAll_Hanghoa.Tables[0].Select("Ma_Hanghoa='" + dr["Ma_Hanghoa"] + "'")[0];
                    dr["Ma_Hanghoa"] = drDm_Hanghoa["Ma_Hanghoa"];
                    //dr["Id_Hanghoa_Mua"] = drDm_Hanghoa["Id_Hanghoa_Mua"];
                    dr["Id_Hanghoa_Ban"] = drDm_Hanghoa["Id_Hanghoa_Ban"];
                    dr["Ten_Hanghoa_Ban"] = drDm_Hanghoa["Ten_Hanghoa"];
                    dr["Ma_Hanghoa"] = drDm_Hanghoa["Ma_Ql"].ToString().Replace("Pro", "");
                }
                catch (Exception ex) { continue; }
            }
            ds_Collection.AcceptChanges();
            dgware_Ctrinh_Kmai_Chitiet.DataSource = ds_Collection.Tables[0];
            gridView1.BestFitColumns();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}