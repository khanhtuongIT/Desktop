using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.SystemControl.SystemInfo
{
    public partial class UCSetMachineLocation : UserControl,  GoobizFrame.Windows.Forms.IFormUserActions
    {
        #region user rights
        private bool enableAdd = true;
        private bool enableEdit = true;
        private bool enableDelete = false;
        private bool enableQuery = true;
        private bool enablePrintPreview = true;
        private bool denied = false;
        private bool enabletest = false;
        private bool enableverify = false;
        private  GoobizFrame.Windows.PlugIn.Authorization.Actions _UserActions;
        /// <summary>
        /// cho phép thêm mới
        /// </summary>
        [Category("IFormUserActions")]
        [DefaultValue(true)]
        public bool EnableAdd
        {
            get { return enableAdd; }
            set
            {
                enableAdd = value;
            }
        }
        /// <summary>
        /// cho phép cập nhật
        /// </summary>
        [Category("IFormUserActions")]
        [DefaultValue(true)]
        public bool EnableEdit
        {
            get { return enableEdit; }
            set
            {
                enableEdit = value;
                btn_eLocation.Enabled = enableEdit;
            }
        }
        /// <summary>
        /// cho phép xóa
        /// </summary>
        [Category("IFormUserActions")]
        [DefaultValue(true)]
        public bool EnableDelete
        {
            get { return enableDelete; }
            set
            {
                enableDelete = value;
            }
        }
        /// <summary>
        /// cho phép lập báo cáo
        /// </summary>
        [Category("IFormUserActions")]
        [DefaultValue(true)]
        public bool EnableQuery
        {
            get { return enableQuery; }
            set
            {
                enableQuery = value;
            }
        }
        /// <summary>
        /// cho phép in
        /// </summary>
        [Category("IFormUserActions")]
        [DefaultValue(true)]
        public bool EnablePrintPreview
        {
            get { return enablePrintPreview; }
            set
            {
                enablePrintPreview = value;
            }
        }

        [Category("IFormUserActions")]
        [DefaultValue(true)]
        public bool EnableTest
        {
            get { return enabletest; }
            set
            {
                enabletest = value;
            }
        }

        [Category("IFormUserActions")]
        [DefaultValue(true)]
        public bool EnableVerify
        {
            get { return enableverify; }
            set
            {
                enableverify = value;
            }
        }

        [Category("IFormUserActions")]
        [DefaultValue(true)]
        public bool Denied
        {
            get { return denied; }
            set
            {
                denied = value;
            }
        }

        /// <summary>
        /// danh sach tat ca thao tac duoc phep thuc hien
        /// </summary>
        [Category("IFormUserActions")]
        public  GoobizFrame.Windows.PlugIn.Authorization.Actions UserActions
        {
            get { return _UserActions; }
            set { _UserActions = value; }
        }
        #endregion

        bool _CancelClosed = false;
        public bool CancelClosed { get { return _CancelClosed; } set { _CancelClosed = value; } }

        DataSet dsWare_Dm_Kho_Hanghoa;

        public UCSetMachineLocation()
        {
            InitializeComponent();

            DisplayInfo();
        }

        void ChangeStatus(bool editable)
        {
            gridView1.OptionsBehavior.Editable = editable;

            btn_cLocation.Enabled = editable;
            btn_sLocation.Enabled = editable;
            btn_eLocation.Enabled = !editable;
        }


        void DisplayInfo()
        {
            //GoobizFrame.Profile.Config config = GoobizFrame.Windows.Public.HostConfiguration.Instance;
            //config.GroupName = "WebReferences";
            string customURL = "" + GoobizFrame.Windows.MdiUtils.ThemeSettings.GetWebReferenceUrl("MasterService");

            dsWare_Dm_Kho_Hanghoa =  GoobizFrame.Windows.Public.WsProxy.CallWebService(
                  customURL        //webServiceAsmxUrl
                , "MasterService"        //serviceName
                , "Get_All_Ware_Dm_Cuahang_Ban"        //methodName
                , new object[] { } //args
            ).ToString().ToDataSet();// as DataSet;

           dsWare_Dm_Kho_Hanghoa.Tables[0].Columns.Add("CurrentLocation", typeof(bool));

           dgware_Dm_Cuahang_Ban.DataSource = dsWare_Dm_Kho_Hanghoa.Tables[0];
           gridView1.BestFitColumns();

           ChangeStatus(false);
           LoadCurrentLocation();
        }

        void LoadCurrentLocation()
        {
             GoobizFrame.Profile.Config config =GoobizFrame.Windows.Public.HostConfiguration.Instance;
            config.GroupName = "HostConfiguration";
            string Id_Cuahang_Ban = ""+config.GetValue("Location", "Id_Cuahang_Ban");
            if (Id_Cuahang_Ban != "")
            {
                DataRow[] sdr = dsWare_Dm_Kho_Hanghoa.Tables[0].Select("Id_Cuahang_Ban = " + Id_Cuahang_Ban);
                if (sdr.Length > 0)
                    sdr[0]["CurrentLocation"] = true;
            }

            //DisplayInfo();
        }

        private void btn_eLocation_Click(object sender, EventArgs e)
        {
            ChangeStatus(true);
        }

        private void btn_sLocation_Click(object sender, EventArgs e)
        {
            try
            {
                 GoobizFrame.Profile.Config config = GoobizFrame.Windows.Public.HostConfiguration.Instance;
                config.GroupName = "HostConfiguration";
                DataRow[] sdr = dsWare_Dm_Kho_Hanghoa.Tables[0].Select("CurrentLocation = true");
                config.SetValue("Location", "Id_Cuahang_Ban", sdr[0]["Id_Cuahang_Ban"]);

                DisplayInfo();

                if (System.IO.Directory.Exists(@"Resources\localdata"))
                    System.IO.Directory.Delete(@"Resources\localdata", true);

                foreach (System.Windows.Forms.Form child in this.FindForm().ParentForm.MdiChildren)
                {
                    if (child != this.FindForm()) 
                            child.Close();
                }
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), this.GetType().Name);
            }
        }

        private void dgware_Dm_Cuahang_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "CurrentLocation")
            {
                if (Convert.ToBoolean(e.Value))
                {
                    DataRow[] sdr = dsWare_Dm_Kho_Hanghoa.Tables[0].Select("Id_Cuahang_Ban <> " + gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban"));
                    foreach (DataRow dr in sdr)
                        dr["CurrentLocation"] = false;
                }
                else
                    dsWare_Dm_Kho_Hanghoa.Tables[0].Rows[0]["CurrentLocation"] = true;
            }
        }

        private void btn_cLocation_Click(object sender, EventArgs e)
        {
            DisplayInfo();
        }
    }
}
