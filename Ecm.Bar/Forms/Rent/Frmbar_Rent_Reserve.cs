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

namespace Ecm.Bar.Forms.Rent
{
    public partial class Frmbar_Rent_Reserve : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet dsbar_Rent_Reserve;
        private object id_reserve;
        public object Current_Id_Reserve { get { return id_reserve; } set { id_reserve = value; } }        
        private object id_cuahang_ban;
        public object Current_Id_Cuahang_Ban 
        { 
            get
            {
                id_cuahang_ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
                return id_cuahang_ban; 
            }
        }        

        Frmbar_Rent_Reserve_Info _Frmbar_Rent_Reserve_Info = null;
        Frmbar_Rent_Reserve_RoomLookup _Frmbar_Rent_Reserve_RoomLookup = null;

        public Frmbar_Rent_Reserve()
        {
            InitializeComponent();
            this.barSystem.Visible = false;
            this.AfterCheckUserRightAction += new EventHandler(Frmbar_Rent_Reserve_AfterCheckUserRightAction);

            buttonEdit_Nam.EditValue = DateTime.Now.Year;
            buttonEdit_Thang.EditValue = DateTime.Now.Month;
            DisplayInfo();
        }

        void Frmbar_Rent_Reserve_AfterCheckUserRightAction(object sender, EventArgs e)
        {
            this.btnAdd.Enabled = this.EnableAdd;
            this.btnEdit.Enabled = this.EnableEdit;
            this.btnDelete.Enabled = this.EnableDelete;
        }

        public override void ClearDataBindings()
        {
            lookUpEdit_Khachhang.DataBindings.Clear();
            dtNgay_Batdau.DataBindings.Clear();
            dtNgay_Ketthuc.DataBindings.Clear();
            lookUpEdit_Class.DataBindings.Clear();
            txtSoluong_Phong.DataBindings.Clear();
            txtSoluong_Khach.DataBindings.Clear();
            txtReserver_Hoten.DataBindings.Clear();
            txtReserver_Cmnd.DataBindings.Clear();
            txtReserver_Tel.DataBindings.Clear();
            txtChietkhau_Tyle.DataBindings.Clear();
            txtChietkhau_Tienmat.DataBindings.Clear();
            txtReserver_Email.DataBindings.Clear();
            chkThanhtoantruoc.DataBindings.Clear();
            dtNgay_Chungtu.DataBindings.Clear();
            txtSo_Chungtu.DataBindings.Clear();
            lookUpEdit_Nhansu_Ctu.DataBindings.Clear();
            memGhichu.DataBindings.Clear();            
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                lookUpEdit_Khachhang.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Id_Khachhang");
                dtNgay_Batdau.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Ngay_Batdau");
                dtNgay_Ketthuc.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Ngay_Ketthuc");
                lookUpEdit_Class.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Id_Class");
                txtSoluong_Phong.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Soluong_Phong");
                txtSoluong_Khach.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Soluong_Khach");
                txtReserver_Hoten.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Reserver_Hoten");
                txtReserver_Cmnd.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Reserver_Cmnd");
                txtReserver_Tel.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Reserver_Tel");
                txtChietkhau_Tyle.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Chietkhau_Tyle");
                txtChietkhau_Tienmat.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Chietkhau_Tienmat");
                txtReserver_Email.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Reserver_Email");
                chkThanhtoantruoc.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Thanhtoantruoc");
                dtNgay_Chungtu.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Ngay_Chungtu");
                txtSo_Chungtu.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".So_Chungtu");
                lookUpEdit_Nhansu_Ctu.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Id_Nhansu_Ctu");
                memGhichu.DataBindings.Add("EditValue", dsbar_Rent_Reserve, dsbar_Rent_Reserve.Tables[0].TableName + ".Ghichu");

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ResetText()
        {
            lookUpEdit_Khachhang.EditValue = null;
            dtNgay_Batdau.EditValue = null;
            dtNgay_Ketthuc.EditValue = null;
            lookUpEdit_Class.EditValue = null;
            txtSoluong_Phong.EditValue = null;
            txtSoluong_Khach.EditValue = null;
            txtReserver_Hoten.EditValue = null;
            txtReserver_Cmnd.EditValue = null;
            txtReserver_Tel.EditValue = null;
            txtChietkhau_Tyle.EditValue = null;
            txtChietkhau_Tienmat.EditValue = null;
            txtReserver_Email.EditValue = null;
            chkThanhtoantruoc.EditValue = null;
            dtNgay_Chungtu.EditValue = DateTime.Now;
            txtSo_Chungtu.EditValue = null;
            lookUpEdit_Nhansu_Ctu.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu()); ;
            memGhichu.EditValue = null;
        }

        public override void DisplayInfo()
        {
            try
            {
                var dsDm_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                gridLookUpEdit_Khachhang.DataSource = dsDm_Khachhang.Tables[0];
                lookUpEdit_Khachhang.Properties.DataSource = dsDm_Khachhang.Tables[0];
                lookUpEdit_Class.Properties.DataSource = objMasterService.Get_All_Bar_Dm_Class().ToDataSet().Tables[0];
                lookUpEdit_Nhansu_Ctu.Properties.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];

                if ("" + buttonEdit_Nam.EditValue != "" && "" + buttonEdit_Thang.EditValue != "")
                {
                    int nam = 2013;
                    int.TryParse("" + buttonEdit_Nam.EditValue, out nam);
                    if (nam / 1900 >= 1)
                    {
                        dsbar_Rent_Reserve = objBarService.Get_All_Bar_Rent_Reserve(
                            new DateTime(int.Parse("" + buttonEdit_Nam.EditValue), int.Parse("" + buttonEdit_Thang.EditValue), 1),
                            Current_Id_Cuahang_Ban).ToDataSet();
                        dgBar_Rent_Reserve.DataSource = dsbar_Rent_Reserve;
                        dgBar_Rent_Reserve.DataMember = dsbar_Rent_Reserve.Tables[0].TableName;
                        DataBindingControl();
                        if (cvBar_Rent_Reserve.RowCount == 0)
                            ResetText();
                    }
                }
                ChangeStatus(false);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        public override object PerformSelectOneObject()
        {
            return Current_Id_Reserve;            
        }

        public override void ChangeStatus(bool editTable)
        {
            lookUpEdit_Khachhang.Properties.ReadOnly = !editTable;
            dtNgay_Batdau.Properties.ReadOnly = !editTable;
            dtNgay_Ketthuc.Properties.ReadOnly = !editTable;
            lookUpEdit_Class.Properties.ReadOnly = !editTable;
            txtSoluong_Phong.Properties.ReadOnly = !editTable;
            txtSoluong_Khach.Properties.ReadOnly = !editTable;
            txtReserver_Hoten.Properties.ReadOnly = !editTable;
            txtReserver_Cmnd.Properties.ReadOnly = !editTable;
            txtReserver_Tel.Properties.ReadOnly = !editTable;
            txtChietkhau_Tyle.Properties.ReadOnly = !editTable;
            txtChietkhau_Tienmat.Properties.ReadOnly = !editTable;
            txtReserver_Email.Properties.ReadOnly = !editTable;
            chkThanhtoantruoc.Properties.ReadOnly = !editTable;
            dtNgay_Chungtu.Properties.ReadOnly = true;
            txtSo_Chungtu.Properties.ReadOnly = true;
            lookUpEdit_Nhansu_Ctu.Properties.ReadOnly = true;
            memGhichu.Properties.ReadOnly = !editTable;

            cvBar_Rent_Reserve.OptionsBehavior.Editable = false;
        }

        private void gNumboard1_UserKeyPressed(object sender, GoobizFrame.Windows.Controls.TouchscreenKeyboard.KeyboardEventArgs e)
        {
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void cvBar_Rent_Reserve_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Rent_Reserve.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvBar_Rent_Reserve.FocusedRowHandle = cardHit.RowHandle;
                Current_Id_Reserve = cvBar_Rent_Reserve.GetRowCellValue(cardHit.RowHandle,
                "Id_Reserve");
                //highlight
                GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvBar_Rent_Reserve, "Id_Reserve", Current_Id_Reserve);
            }
        }       

        private void buttonEdit_Thang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case DevExpress.XtraEditors.Controls.ButtonPredefines.Delete:
                    buttonEdit_Thang.EditValue = DateTime.Now.Month;
                    buttonEdit_Thang.SelectAll();
                    buttonEdit_Thang.Focus();
                    break;
                case DevExpress.XtraEditors.Controls.ButtonPredefines.Up:                
                    buttonEdit_Thang.EditValue = Convert.ToInt32(buttonEdit_Thang.EditValue) % 12 + 1;
                    buttonEdit_Thang.SelectAll();
                    buttonEdit_Thang.Focus();
                    break;
                    case DevExpress.XtraEditors.Controls.ButtonPredefines.Down:
                     buttonEdit_Thang.EditValue = System.Math.Abs( Convert.ToInt32(buttonEdit_Thang.EditValue) % 12 -1);
                    buttonEdit_Thang.SelectAll();
                    buttonEdit_Thang.Focus();
                    break;
            }
        }

        private void buttonEdit_Nam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            buttonEdit_Nam.EditValue = DateTime.Now.Year;
            buttonEdit_Nam.SelectAll();
            buttonEdit_Nam.Focus();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            cvBar_Rent_Reserve.MovePrevPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cvBar_Rent_Reserve.MoveNextPage();
        }

        private void checkEdit_Ngay_Batdau_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkEdit_Ngay_Batdau.Checked)
                DisplayInfo();
            else
            {
                dsbar_Rent_Reserve = objBarService.Get_All_Bar_Rent_Reserve_ByArrivalDate(
                    new DateTime(int.Parse("" + buttonEdit_Nam.EditValue), int.Parse("" + buttonEdit_Thang.EditValue), 1)
                    ,Current_Id_Cuahang_Ban).ToDataSet(); 
                dgBar_Rent_Reserve.DataSource = dsbar_Rent_Reserve.Tables[0];
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Current_Id_Reserve = null;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // xóa file tmp trong folder Default\AppForms để update label khi Loadform
            string path_file = @"Resources\Default\AppForms\Ecm.Bar.Frmbar_Rent_Reserve_Info";
            if (System.IO.File.Exists(path_file))
                System.IO.File.Delete(path_file);
            _Frmbar_Rent_Reserve_Info = new Frmbar_Rent_Reserve_Info();
            _Frmbar_Rent_Reserve_Info.barSystem.Visible = false;
            _Frmbar_Rent_Reserve_Info.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
            _Frmbar_Rent_Reserve_Info.WindowState = System.Windows.Forms.FormWindowState.Normal;

            _Frmbar_Rent_Reserve_Info.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            _Frmbar_Rent_Reserve_Info.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            _Frmbar_Rent_Reserve_Info.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            _Frmbar_Rent_Reserve_Info.PerformAdd();
            _Frmbar_Rent_Reserve_Info.ShowDialog();
            DisplayInfo();
        }

        private void btnRoomLookup_Click(object sender, EventArgs e)
        {
            _Frmbar_Rent_Reserve_RoomLookup = new  Frmbar_Rent_Reserve_RoomLookup();
            _Frmbar_Rent_Reserve_RoomLookup.barSystem.Visible = false;
            _Frmbar_Rent_Reserve_RoomLookup.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
            _Frmbar_Rent_Reserve_RoomLookup.WindowState = System.Windows.Forms.FormWindowState.Normal;
            _Frmbar_Rent_Reserve_RoomLookup.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            _Frmbar_Rent_Reserve_RoomLookup.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            _Frmbar_Rent_Reserve_RoomLookup.Ngay_Batdau = DateTime.Now;
            _Frmbar_Rent_Reserve_RoomLookup.Ngay_Ketthuc = DateTime.Now;
            _Frmbar_Rent_Reserve_RoomLookup.ShowDialog();
        }

        private void cvBar_Rent_Reserve_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Current_Id_Reserve = cvBar_Rent_Reserve.GetFocusedRowCellValue("Id_Reserve");
            GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvBar_Rent_Reserve, "Id_Reserve", Current_Id_Reserve);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cvBar_Rent_Reserve.GetFocusedRowCellValue("Id_Reserve") == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "danh sách đặt phòng" });
                return;
            }
            // xóa file tmp trong folder Default\AppForms để update label khi Loadform
            string path_file = @"Resources\Default\AppForms\Ecm.Bar.Frmbar_Rent_Reserve_Info";
            if (System.IO.File.Exists(path_file))
                System.IO.File.Delete(path_file);
            _Frmbar_Rent_Reserve_Info = new Frmbar_Rent_Reserve_Info();
            _Frmbar_Rent_Reserve_Info.barSystem.Visible = false;
            _Frmbar_Rent_Reserve_Info.Icon = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetProductIcon();
            _Frmbar_Rent_Reserve_Info.WindowState = System.Windows.Forms.FormWindowState.Normal;

            _Frmbar_Rent_Reserve_Info.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            _Frmbar_Rent_Reserve_Info.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            _Frmbar_Rent_Reserve_Info.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Edit);
            _Frmbar_Rent_Reserve_Info.Current_Id_Reserve = cvBar_Rent_Reserve.GetFocusedRowCellValue("Id_Reserve");
            _Frmbar_Rent_Reserve_Info.PerformEdit();
            _Frmbar_Rent_Reserve_Info.ShowDialog();

            DisplayInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cvBar_Rent_Reserve.GetFocusedRowCellValue("Id_Reserve") == null)
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[] { "danh sách đặt phòng" });
                return;
            }
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[] { }) == DialogResult.Yes)
            {
                objBarService.Delete_Bar_Rent_Reserve(new WebReferences.BarService.Bar_Rent_Reserve() 
                {
                    Id_Reserve = cvBar_Rent_Reserve.GetFocusedRowCellValue("Id_Reserve")
                });

                DisplayInfo();
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            PerformSelectOneObject();
            this.Dispose();
        }
               
    }
}
