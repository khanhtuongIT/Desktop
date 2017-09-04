using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using System.Net;
using System.Net.Mail;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;


namespace Ecm.SystemControl.Forms
{
    public partial class Frmpol_Dm_User_Find : DevExpress.XtraEditors.XtraForm
    {
        public Ecm.WebReferences.Classes.PolicyService objPolicy = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.PolicyService>();
        DataSet dsUser;
        private long[] id_user_selected;

        public Frmpol_Dm_User_Find()
        {
            InitializeComponent();
            //update GUI with current CultureInfo
            System.Collections.ArrayList controls = new System.Collections.ArrayList();
            controls.Add(this.lblLocation);
            controls.Add(this.btbBrowse);
            controls.Add(this.gridColumn1);
            controls.Add(this.gridColumn2);
            controls.Add(this.gridColumn3);
            controls.Add(this.btbSelect);
            controls.Add(this.btbCancel);
            controls.Add(this);
            //GoobizFrame.Windows.CultureInfo.CultureInfoHelper.SetupFormCultureInfo(this, controls);
        }

        private void Frmpol_Dm_User_Find_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        public long[] Id_User_Selected
        {
            get { return id_user_selected; }
        }

        public void DisplayInfo()
        {
            gridLookUpEdit_Nhansu.DataSource = objPolicy.Get_All_Rex_Nhansu_Collection3().ToDataSet();

            this.dsUser = objPolicy.Get_Pol_Dm_User_Collection3().ToDataSet();
            this.dgPol_Dm_User.DataSource = dsUser.Tables[0];
            dsUser.Tables[0].Columns.Add("Checked", typeof(bool));
        }

        public long[] SelectedUser()
        {
            //int[] selects = gridView1.GetSelectedRows();
            DataRow[] selectedRows = dsUser.Tables[0].Select("Checked=true");
            long[] Id_User_Array = new long[selectedRows.Length];
            for (int i = 0; i < selectedRows.Length; i++)
            {
                Id_User_Array[i] = Convert.ToInt64(selectedRows[i]["Id_User"]); // Convert.ToInt64(this.gridView1.GetRowCellValue(selects[i], "Id_User"));
            }
            return Id_User_Array;
        }

        private void btbSelect_Click(object sender, EventArgs e)
        {
            this.id_user_selected = this.SelectedUser();
            this.Dispose();
        }

        private void btbCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dsUser.Tables[0].Rows)
                dr["Checked"] = chkAll.EditValue;
        }
    }
}