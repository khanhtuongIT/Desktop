using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hdbanhang_Sum :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        object Id_Nhansu_Casher = null;
        object Id_Nhansu_Casherql = null;
        object Id_Cuahang_Ban = null;
        object Id_Kho_Hanghoa_Mua = null;
        object Sotien_Banhang;

        DataSet dsHdbanhang_Sum;
        DataRow ndrHdbanhang_Sum = null;

        public Frmware_Hdbanhang_Sum()
        {
            InitializeComponent();

            dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            DisplayInfo();

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }

        #region Event override
        public override void DisplayInfo()
        {
            //lookUpEdit_Nhansu_Casherql
            DataSet dsNhansu =objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            lookUpEdit_Nhansu_Casherql.Properties.DataSource = dsNhansu.Tables[0];
            lookUpEdit_Nhansu_Casher.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Nhansu.DataSource = dsNhansu.Tables[0];

            //lookUpEditMa_Kho_Hanghoa
            DataSet dsKho_Hanghoa = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa().ToDataSet();
            lookUpEditMa_Kho_Hanghoa.Properties.DataSource = dsKho_Hanghoa.Tables[0];
            gridLookUpEdit_Kho_Hanghoa.DataSource = dsKho_Hanghoa.Tables[0];

            //Id_Nhansu_Casher
            Id_Nhansu_Casher =  GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            lookUpEdit_Nhansu_Casher.EditValue = Convert.ToInt64( Id_Nhansu_Casher );

            //Id_Cuahang_Ban
            DataSet dsWare_Dm_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(Id_Nhansu_Casher).ToDataSet();
            if (dsWare_Dm_Cuahang_Ban != null && dsWare_Dm_Cuahang_Ban.Tables.Count > 0 && dsWare_Dm_Cuahang_Ban.Tables[0].Rows.Count > 0)
            {
                Id_Cuahang_Ban = dsWare_Dm_Cuahang_Ban.Tables[0].Rows[0]["Id_Cuahang_Ban"];
                if ("" + Id_Cuahang_Ban != "")
                {
                    object Ma_Kho_Hanghoa = dsKho_Hanghoa.Tables[0].Select("Id_Cuahang_Ban= " + Id_Cuahang_Ban)[0]["Ma_Kho_Hanghoa"];
                    lookUpEditMa_Kho_Hanghoa.EditValue = Ma_Kho_Hanghoa;
                }
            }

            //Id_Kho_Hanghoa_Mua
            //DataSet dsWare_Dm_Kho_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_MuaBy_Id_Nhansu(Id_Nhansu_Casher).ToDataSet();
            //if (dsWare_Dm_Kho_Hanghoa_Mua != null && dsWare_Dm_Kho_Hanghoa_Mua.Tables.Count > 0 && dsWare_Dm_Kho_Hanghoa_Mua.Tables[0].Rows.Count > 0)
            //{
            //    Id_Kho_Hanghoa_Mua = dsWare_Dm_Kho_Hanghoa_Mua.Tables[0].Rows[0]["Id_Kho_Hanghoa_Mua"];
            //    if ("" + Id_Kho_Hanghoa_Mua != "")
            //    {
            //        object Ma_Kho_Hanghoa = dsKho_Hanghoa.Tables[0].Select("Id_Kho_Hanghoa_Mua= " + Id_Kho_Hanghoa_Mua)[0]["Ma_Kho_Hanghoa"];
            //        lookUpEditMa_Kho_Hanghoa.EditValue = Ma_Kho_Hanghoa;
            //    }
            //}

            DisplayInfo2();

            base.DisplayInfo();
        }

        public override bool PerformQuery()
        {
            return base.PerformQuery();
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Sotien_Nopquy"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            try
            {
                this.DoClickEndEdit(dgware_Hdbanhang_Sum); 
                objWareService.Update_Ware_Hdbanhang_Sum_Collection(this.dsHdbanhang_Sum);
            }
            catch (Exception ex)
            {

#if DEBUG
                MessageBox.Show(ex.Message);
#endif

            }
            this.DisplayInfo();
            return true;
        }
        #endregion

        void DisplayInfo2()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Hdbanhang_Sum Ware_Hdbanhang_Sum = new Ecm.WebReferences.WareService.Ware_Hdbanhang_Sum();
                Ware_Hdbanhang_Sum.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                Ware_Hdbanhang_Sum.Id_Cuahang_Ban =
                    ("" + lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Cuahang_Ban") != "")
                    ? lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Cuahang_Ban") : -1;
                Ware_Hdbanhang_Sum.Id_Kho_Hanghoa_Mua =
                    ("" + lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua") != "")
                    ? lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua") : -1;

                Sotien_Banhang = objWareService.RptWare_Hdbanhang_Sum_Cal(Ware_Hdbanhang_Sum);

                if ("" + Sotien_Banhang != "")
                    txtSotien_Banhang.EditValue = Sotien_Banhang;

                dsHdbanhang_Sum = objWareService.Get_All_Ware_Hdbanhang_Sum(Ware_Hdbanhang_Sum).ToDataSet();
                dgware_Hdbanhang_Sum.DataSource = dsHdbanhang_Sum;
                dgware_Hdbanhang_Sum.DataMember = dsHdbanhang_Sum.Tables[0].TableName;

                this.Data = dsHdbanhang_Sum;
                this.GridControl = dgware_Hdbanhang_Sum;

                this.DoClickEndEdit(dgware_Hdbanhang_Sum); //dgware_Hdbanhang_Sum.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                txtSotien_Sum.EditValue = gridView1.Columns["Sotien_Nopquy"].SummaryItem.SummaryValue;
                txtSotien_Tonquy.EditValue = Convert.ToDouble("0" + txtSotien_Banhang.EditValue) - Convert.ToDouble("0" + txtSotien_Sum.EditValue);

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        #region Even

  
        private void txtMa_Nhansu_Casherql_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtMa_Nhansu_Casherql.Text != "")
            {
                try
                {
                    Id_Nhansu_Casherql = ((DataTable)lookUpEdit_Nhansu_Casherql.Properties.DataSource).Select("Ma_Nhansu = '" + txtMa_Nhansu_Casherql.Text + "'")[0]["Id_Nhansu"];
                    lookUpEdit_Nhansu_Casherql.EditValue = Id_Nhansu_Casherql;

                    ndrHdbanhang_Sum = dsHdbanhang_Sum.Tables[0].NewRow();
                    ndrHdbanhang_Sum["Sochungtu"] = objWareService.GetNew_Sochungtu("Ware_Hdbanhang_Sum", "Sochungtu", Id_Nhansu_Casherql);
                    ndrHdbanhang_Sum["Ngay_Chungtu"] = dtNgay_Chungtu.EditValue;
                    ndrHdbanhang_Sum["Ma_Kho_Hanghoa"] = lookUpEditMa_Kho_Hanghoa.EditValue;
                    ndrHdbanhang_Sum["Id_Cuahang_Ban"] = lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Cuahang_Ban");
                    ndrHdbanhang_Sum["Id_Kho_Hanghoa_Mua"] = lookUpEditMa_Kho_Hanghoa.GetColumnValue("Id_Kho_Hanghoa_Mua");
                    ndrHdbanhang_Sum["Id_Nhansu_Casher"] = Id_Nhansu_Casher;
                    ndrHdbanhang_Sum["Id_Nhansu_Casherql"] = Id_Nhansu_Casherql;
                    ndrHdbanhang_Sum["Sotien_Banhang"] = txtSotien_Banhang.EditValue;

                    dsHdbanhang_Sum.Tables[0].Rows.Add(ndrHdbanhang_Sum);
                }
                catch
                {
                    txtMa_Nhansu_Casherql.SelectAll();
                    txtMa_Nhansu_Casherql.Focus();
                }
            }
        }

        private void lookUpEditMa_Kho_Hanghoa_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEditMa_Kho_Hanghoa.EditValue != "")
            {
                DisplayInfo2();
            }
        }

        private void txtSotien_Nopquy_EditValueChanged(object sender, EventArgs e)
        {
            if (ndrHdbanhang_Sum != null)
            {
                ndrHdbanhang_Sum["Sotien_Nopquy"] = txtSotien_Nopquy.EditValue;

                this.DoClickEndEdit(dgware_Hdbanhang_Sum); //dgware_Hdbanhang_Sum.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                txtSotien_Sum.EditValue = gridView1.Columns["Sotien_Nopquy"].SummaryItem.SummaryValue;
                txtSotien_Tonquy.EditValue = Convert.ToDouble("0" + txtSotien_Banhang.EditValue) - Convert.ToDouble("0" + txtSotien_Sum.EditValue);

            }
        }

        private void txtMa_Nhansu_Casher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtMa_Nhansu_Casher.Text != "")
            {
                Id_Nhansu_Casher = ((DataTable)lookUpEdit_Nhansu_Casher.Properties.DataSource).Select("Ma_Nhansu = '" + txtMa_Nhansu_Casher.Text + "'")[0]["Id_Nhansu"];
                lookUpEdit_Nhansu_Casher.EditValue = Id_Nhansu_Casher;
            }
        }
        #endregion

        
    }
}

