using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using GoobizFrame.Profile;
using DevExpress.XtraGrid.Views.Card;

namespace Ecm.Bar.Forms.Rent
{
    public partial class Frmbar_Rent_Reserve_RoomLookup : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();

        private object _Current_Id_Table;
        public object Current_Id_Table
        {
            get { return _Current_Id_Table; }
            set { _Current_Id_Table = value; }
        }
        DataSet dsBar_Dm_Class;

        private DataRow sdr;
        public DataRow SelectedRow
        {
            get { return sdr; }
        }

        private object id_cuahang_ban;
        public object Current_Id_Cuahang_Ban
        {
            get
            {
                id_cuahang_ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                return id_cuahang_ban;
            }
        }

        public DateTime Ngay_Batdau
        {
            get { return dtNgay_Batdau.DateTime; }
            set { dtNgay_Batdau.DateTime = value; }
        }

        public DateTime Ngay_Ketthuc
        {
            get { return dtNgay_Ketthuc.DateTime; }
            set { dtNgay_Ketthuc.DateTime = value; }
        }
     
        public Frmbar_Rent_Reserve_RoomLookup()
        {
            InitializeComponent();
            this.barSystem.Visible = false;
            dgBar_Dm_Class.MainView = cvBar_Dm_Class;
            cvBar_Dm_Table.FormatConditions.Clear();
            dtNgay_Batdau.DateTime = DateTime.Now;
            dtNgay_Ketthuc.DateTime = DateTime.Now;            
            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                sdr = null;
                var dsDm_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet();
                dgDm_Cuahang_Ban.DataSource = dsDm_Cuahang_Ban.Tables[0];

                if (cvDm_Cuahang_Ban.RowCount > 0)
                {
                    cvDm_Cuahang_Ban.FocusedRowHandle = 0;
                    cvDm_Cuahang_Ban.Focus();
                    //highlight
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvDm_Cuahang_Ban, "Id_Cuahang_Ban", cvDm_Cuahang_Ban.GetFocusedRowCellValue("Id_Cuahang_Ban"));
                }
                Search();
                DisplayInfo_Class();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        void DisplayInfo_Class()
        {
            try
            {
                dsBar_Dm_Class = objMasterService.Get_All_Bar_Dm_Class().ToDataSet();
                dgBar_Dm_Class.DataSource = dsBar_Dm_Class.Tables[0];
                Format_Cardview();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        void Format_Cardview()
        {
            //dgBar_Dm_Class
            if (dsBar_Dm_Class.Tables[0].Rows.Count > 0)
            {
                int i = Convert.ToInt32("0" + dsBar_Dm_Class.Tables[0].Rows[0]["Id_Class"]);
                foreach (DataRow drClass in dsBar_Dm_Class.Tables[0].Rows)
                {
                    DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                    styleFormatCondition.Appearance.BackColor = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetColor(Convert.ToInt32(drClass["Id_Class"]));
                    styleFormatCondition.Appearance.Options.UseBackColor = true;
                    styleFormatCondition.ApplyToRow = true;
                    styleFormatCondition.Column = this.cvBar_Dm_Class.Columns.ColumnByFieldName("Id_Class");
                    styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                    styleFormatCondition.Value1 = Convert.ToInt32(drClass["Id_Class"]);

                    this.cvBar_Dm_Table.FormatConditions.Add(styleFormatCondition);
                    this.cvBar_Dm_Class.FormatConditions.Add(styleFormatCondition);
                }
            }
        }

        public override object PerformSelectOneObject()
        {
            return sdr;
        }

        private void cvBar_Dm_Table_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Dm_Table.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvBar_Dm_Table.FocusedRowHandle = cardHit.RowHandle;
                Current_Id_Table = cvBar_Dm_Table.GetRowCellValue(cardHit.RowHandle,"Id_Table");
                sdr = cvBar_Dm_Table.GetDataRow(cardHit.RowHandle);
                //highlight
                //GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvBar_Dm_Table, "Id_Table", 1);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        void Search()
        {
            try
            {
                sdr = null;
                var dsBar_Dm_Table = objBarService.Get_Bar_Rent_Reserve_Table_Lookup(cvDm_Cuahang_Ban.GetFocusedRowCellValue("Id_Cuahang_Ban"),
                                                                                    dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime).ToDataSet();
                dgBar_Dm_Table.DataSource = dsBar_Dm_Table.Tables[0];
                if (cvBar_Dm_Table.RowCount > 0)
                {
                    cvBar_Dm_Table.Focus();
                    Current_Id_Table = cvBar_Dm_Table.GetFocusedRowCellValue("Id_Table");
                    //highlight
                    //GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvBar_Dm_Table, "Id_Table", Current_Id_Table);
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void cvDm_Cuahang_Ban_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvDm_Cuahang_Ban.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvDm_Cuahang_Ban.FocusedRowHandle = cardHit.RowHandle;
                //highlight
                GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvDm_Cuahang_Ban, "Id_Cuahang_Ban", cvDm_Cuahang_Ban.GetFocusedRowCellValue("Id_Cuahang_Ban"));
                Search();
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            sdr = null;
            this.Close();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.PerformSelectOneObject();
            this.Close();
        }

        private void btnPre_Cuahang_Ban_Click(object sender, EventArgs e)
        {
            cvDm_Cuahang_Ban.MovePrevPage();
        }

        private void btnNext_Cuahang_Ban_Click(object sender, EventArgs e)
        {
            cvDm_Cuahang_Ban.MoveNextPage();
        }   

        private void btnPre_Table_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Table.MovePrevPage();
        }

        private void btnNext_Table_Click(object sender, EventArgs e)
        {
            cvBar_Dm_Table.MoveNextPage();
        }

        private void cvBar_Dm_Class_MouseDown(object sender, MouseEventArgs e)
        {            
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Dm_Class.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                try
                {
                    object Ma_Class = cvBar_Dm_Class.GetRowCellValue(cardHit.RowHandle, cvBar_Dm_Class.Columns["Ma_Class"]);                    
                    cvBar_Dm_Class.FocusedRowHandle = cardHit.RowHandle;
                    cvBar_Dm_Table.Columns["Ma_Class"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                    cvBar_Dm_Table.Columns["Ma_Class"], Ma_Class);
                    //cvBar_Dm_Table.ApplyColumnsFilter();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }   

    }
}
