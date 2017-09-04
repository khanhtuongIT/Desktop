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
    public partial class Frmpol_Dm_Right_Find : DevExpress.XtraEditors.XtraForm
    {
        private long[] id_right_selected;
        DataSet dsRight;

        public Frmpol_Dm_Right_Find()
        {
            InitializeComponent();
            //update GUI with current CultureInfo
            System.Collections.ArrayList controls = new System.Collections.ArrayList();
            controls.Add(this.gridColumn1);
            controls.Add(this.gridColumn2);
            controls.Add(this.gridColumn3);
            controls.Add(this.btbSelect);
            controls.Add(this.btbCancel);
            controls.Add(this);
            //GoobizFrame.Windows.CultureInfo.CultureInfoHelper.SetupFormCultureInfo(this, controls);
        }

        private void Frmpol_Dm_Right_Find_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        public long[] Id_Right_Selected
        {
            get { return id_right_selected; }
        }

        public void DisplayInfo()
        {
            Ecm.WebReferences.Classes.PolicyService objPolicy = new Ecm.WebReferences.Classes.PolicyService();
            dsRight = objPolicy.Get_Pol_Dm_Right_Collection3().ToDataSet();
            this.dgPol_Dm_Right.DataSource = dsRight.Tables[0];
            dsRight.Tables[0].Columns.Add(new DataColumn("Checked", typeof(bool)));
        }

        private long[] SelectedRight()
        {
            //int[] selects = gridView1.GetSelectedRows();
            DataRow [] selectedRows = dsRight.Tables[0].Select("Checked = true");
            long[] Id_Right_Array = new long[selectedRows.Length];
            for (int i = 0; i < selectedRows.Length; i++)
            {
                //Id_Right_Array[i] = Convert.ToInt64(this.gridView1.GetRowCellValue(selects[i], "Id_Right"));
                Id_Right_Array[i] = Convert.ToInt64(selectedRows[i]["Id_Right"]);
            }
            return Id_Right_Array;
        }

        private void btbCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btbSelect_Click(object sender, EventArgs e)
        {
            this.id_right_selected = this.SelectedRight();
            this.Dispose();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dsRight.Tables[0].Rows)
                dr["Checked"] = chkAll.EditValue;
        }
    }
}