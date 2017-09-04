using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SunLine.SystemControl.Policy.Forms
{
    public partial class Frmpol_Dm_Action_Find : DevExpress.XtraEditors.XtraForm
    {
        SunLine.WebReferences.Classes.PolicyService objPolicy = new SunLine.WebReferences.Classes.PolicyService();
        DataSet dsAction;
        private long[] id_action_selected;

        public Frmpol_Dm_Action_Find()
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
            GoobizFrame.Windows.CultureInfo.CultureInfoHelper.SetupFormCultureInfo(this, controls);
        }

        private void Frmpol_Dm_Action_Find_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        public void DisplayInfo()
        {
            dsAction = objPolicy.Get_Pol_Dm_Action_Collection3();
            this.dgpol_Dm_Action.DataSource = dsAction.Tables[0];
            dsAction.Tables[0].Columns.Add("Checked", typeof(bool));
        }

        public long[] Id_Action_Selected
        {
            get { return id_action_selected; }
        }

        public long[] SelectedAction()
        {
            //int[] selects = gridView1.GetSelectedRows();
            DataRow[] selectedRows = dsAction.Tables[0].Select("Checked=true");
            long[] Id_Action_Array = new long[selectedRows.Length];
            for (int i = 0; i < selectedRows.Length; i++)
            {
                Id_Action_Array[i] = Convert.ToInt64(selectedRows[i]["Id_Action"]);//Convert.ToInt64(this.gridView1.GetRowCellValue(selects[i], "Id_Action"));
            }
            return Id_Action_Array;
        }

        private void btbCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btbSelect_Click(object sender, EventArgs e)
        {
            this.id_action_selected = SelectedAction();
            this.Dispose();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dsAction.Tables[0].Rows)
                dr["Checked"] = chkAll.EditValue;
        }
    }
}