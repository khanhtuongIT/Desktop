using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;
using Ecm.WebReferences.Classes;

namespace Ecm.Rex.Forms
{
    public partial class FrmRptRex_Tamhoan_Hopdong : GoobizFrame.Windows.Forms.FormXReport
    {
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Rex.Datasets.dsRex_Tamhoan dsReport = new Ecm.Rex.Datasets.dsRex_Tamhoan();

        public FrmRptRex_Tamhoan_Hopdong()
        {
            InitializeComponent();

            dtNgay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Batdau.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            dtNgay_Ketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Ketthuc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            dtNgay_Batdau.Properties.MinValue = new DateTime(1950, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(1950, 01, 01);


            dtNgay_Batdau.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtNgay_Ketthuc.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            lookUpEdit_Bophan.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet().Tables[0];
        }

        public override bool PerformQuery()
        {
            dsReport.Clear();
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lbl_Ngaybatdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lbl_Ngayketthuc.Text);
            hashtableControls.Add(lookUpEdit_Bophan, lblBophan.Text);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return false;

            Rex.Reports.rptRex_Tamhoan_Hopdong _rptRex_Tamhoan_Hopdong = new Ecm.Rex.Reports.rptRex_Tamhoan_Hopdong();
            this.Report = _rptRex_Tamhoan_Hopdong;


            #region Set he so ctrinh - logo, ten cty

            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                _rptRex_Tamhoan_Hopdong.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _rptRex_Tamhoan_Hopdong.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                //rptPhieu_Chi.xrPic_Logo.DataBindings.Add(
                //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }

            #endregion



            _rptRex_Tamhoan_Hopdong.lblBophan.Text = lookUpEdit_Bophan.Text;
            _rptRex_Tamhoan_Hopdong.lblNgay_Batdau.Text = dtNgay_Batdau.Text;
            _rptRex_Tamhoan_Hopdong.lblNgay_Ketthuc.Text = dtNgay_Ketthuc.Text;
            _rptRex_Tamhoan_Hopdong.lblNgay.Text = DateTime.Today.ToString("dd");
            _rptRex_Tamhoan_Hopdong.lblThang.Text = DateTime.Today.ToString("MM");
            _rptRex_Tamhoan_Hopdong.lblNam.Text = DateTime.Today.ToString("yyyy");

            DataSet dsCollection = objRexService.Get_Rex_Tamhoan_Report(lookUpEdit_Bophan.EditValue, dtNgay_Batdau.EditValue, dtNgay_Ketthuc.EditValue).ToDataSet();
            dsCollection.Tables[0].Columns.Add("Giahan_Denngay");
            try
            {
                foreach (DataRow row in dsCollection.Tables[0].Rows)
                {
                    DataSet dsphuluc = objRexService.Get_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Nhansu_Nld(row["id_nhansu"]).ToDataSet();

                    if (dsphuluc.Tables[0].Rows.Count > 0)
                    {
                        row["Giahan_Denngay"] = dsphuluc.Tables[0].Rows[0]["Thoigian_Thuchien_Den"];
                    }
                    dsReport.Tables[0].ImportRow(row);
                   
                }

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
           
            _rptRex_Tamhoan_Hopdong.DataSource = dsReport;

            _rptRex_Tamhoan_Hopdong.CreateDocument();

            this.printControl1.PrintingSystem = _rptRex_Tamhoan_Hopdong.PrintingSystem;

            return base.PerformQuery();
        }

    }
}