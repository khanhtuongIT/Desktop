using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Rex.Forms
{
    public partial class FrmRptRex_Nghiphep : GoobizFrame.Windows.Forms.FormXReport
    {
      
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.RexService objRexServices = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        public FrmRptRex_Nghiphep()
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

            lookUpEdit_Bophan.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            DisplayInfo();

        }
       

        void DisplayInfo()
        {
            DataSet dsDm_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
            lookUpEdit_Bophan.Properties.DataSource = dsDm_Bophan.Tables[0];
        }

        /// <summary>
        /// tinh so ngay
        /// </summary>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        /// <returns></returns>
        private int GetSongay(DateTime tungay, DateTime denngay)
        {
            int songay = 0;
            for (int i = 0; i < 50000; i++)
            {
                if (denngay >= tungay.AddDays(i))
                {
                    songay++;
                }
                else
                {
                    i = 50000;
                }
            }
            return songay;
        }

        public override bool PerformQuery()
        {
           

            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(dtNgay_Batdau, lbl_Ngaybatdau.Text);
            hashtableControls.Add(dtNgay_Ketthuc, lbl_Ngayketthuc.Text);
            hashtableControls.Add(lookUpEdit_Bophan, lblBophan.Text);

            // check null value
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                return false;

            // set report
            Reports.rptRex_Nghiphep rptRex_Nghiphep = new Ecm.Rex.Reports.rptRex_Nghiphep();
            this.Report = rptRex_Nghiphep;

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

                rptRex_Nghiphep.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptRex_Nghiphep.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                //rptPhieu_Chi.xrPic_Logo.DataBindings.Add(
                //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }

            #endregion


            // fill data to dataset
            DataSet ds_Collection = objRexServices.Search_Rex_Nghiphep_ByBophan(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime, lookUpEdit_Bophan.EditValue).ToDataSet();

            Datasets.DsRex_Nghiphep ds_Nghiphep = new Ecm.Rex.Datasets.DsRex_Nghiphep();
            Datasets.DsRex_Nghiphep ds_Temp = new Datasets.DsRex_Nghiphep();

            int i= 0;
            foreach (DataRow dt in ds_Collection.Tables[0].Rows)
            {

                ds_Temp.Tables[0].ImportRow(dt);
                ds_Temp.Tables[0].Rows[i]["Stt"] = (i + 1).ToString();

                // thoi gian bat dau nghi truoc thoi gian search
                if (dt["Nghitruoc"].ToString().Equals("1"))
                {
                    if (DateTime.Parse(dt["Ngay_Ketthuc"].ToString()).CompareTo(dtNgay_Ketthuc.DateTime) > 0)
                    {
                        ds_Temp.Tables[0].Rows[i]["so_ngaynghi"] = GetSongay(dtNgay_Batdau.DateTime, dtNgay_Ketthuc.DateTime);
                    }
                    else
                    {
                        ds_Temp.Tables[0].Rows[i]["so_ngaynghi"] = GetSongay(dtNgay_Batdau.DateTime, DateTime.Parse(dt["Ngay_Ketthuc"].ToString()));
                    }
                }
                // thoi gian bat dau nghi sau thoi gian search
                else 
                {
                    if (DateTime.Parse(dt["Ngay_Ketthuc"].ToString()).CompareTo(dtNgay_Ketthuc.DateTime) > 0)
                    {
                        ds_Temp.Tables[0].Rows[i]["so_ngaynghi"] = GetSongay(DateTime.Parse(dt["Ngay_Batdau"].ToString()), dtNgay_Ketthuc.DateTime);
                    }
                    else
                    {
                        ds_Temp.Tables[0].Rows[i]["so_ngaynghi"] = GetSongay(DateTime.Parse(dt["Ngay_Batdau"].ToString()), DateTime.Parse(dt["Ngay_Ketthuc"].ToString()));
                    }
                }
                i++;
            }

            if (ds_Temp.Tables[0].Rows.Count > 0)
            {
                ds_Nghiphep.Tables[0].ImportRow(ds_Temp.Tables[0].Rows[0]);
                int stt = 1;

                for (i = 1; i < ds_Temp.Tables[0].Rows.Count; i++)
                {
                    bool kt = false;
                    int index = 0;
                    for (int j = 0; j < ds_Nghiphep.Tables[0].Rows.Count; j++)
                    {
                        if (ds_Nghiphep.Tables[0].Rows[j]["id_nhansu"].ToString().Equals(
                            ds_Temp.Tables[0].Rows[i]["id_nhansu"].ToString()))
                        {
                            kt = true;
                            index = j;
                            j = ds_Nghiphep.Tables[0].Rows.Count;
                        }
                    }

                    if (!kt)
                    {
                        ds_Nghiphep.Tables[0].ImportRow(ds_Temp.Tables[0].Rows[i]);
                        ds_Nghiphep.Tables[0].Rows[stt]["Stt"] = stt + 1;
                        stt++;
                    }

                    else
                    {
                        ds_Nghiphep.Tables[0].Rows[index]["so_ngaynghi"] = int.Parse(
                            string.IsNullOrEmpty(ds_Nghiphep.Tables[0].Rows[index]["so_ngaynghi"].ToString())
                                ? "0"
                                : ds_Nghiphep.Tables[0].Rows[index]["so_ngaynghi"].ToString()) +
                                                                           int.Parse(
                                                                               ds_Temp.Tables[0].Rows[i]["so_ngaynghi"].
                                                                                   ToString());

                        ds_Nghiphep.Tables[0].Rows[index]["Sogio_Nghiphep"] = int.Parse(
                            string.IsNullOrEmpty(ds_Nghiphep.Tables[0].Rows[index]["Sogio_Nghiphep"].ToString())
                                ? "0"
                                : ds_Nghiphep.Tables[0].Rows[index]["Sogio_Nghiphep"].ToString()) +
                                                                              int.Parse(
                                                                                  ds_Temp.Tables[0].Rows[i][
                                                                                      "Sogio_Nghiphep"
                                                                                      ].ToString());

                    }
                }
            }

            rptRex_Nghiphep.DataSource = ds_Nghiphep;

            rptRex_Nghiphep.xrTable_BoPhan.Text = lookUpEdit_Bophan.Text;
            rptRex_Nghiphep.xrTable_Tungay.Text = dtNgay_Batdau.Text;
            rptRex_Nghiphep.xrTable_Denngay.Text = dtNgay_Ketthuc.Text;

            rptRex_Nghiphep.xrTable_ngay.Text = DateTime.Now.Day.ToString();
            rptRex_Nghiphep.xrTable_thang.Text = DateTime.Now.Month.ToString();
            rptRex_Nghiphep.xrTable_nam.Text = DateTime.Now.Year.ToString();


            rptRex_Nghiphep.CreateDocument();
            
            this.printControl1.PrintingSystem = rptRex_Nghiphep.PrintingSystem;

            return base.PerformQuery();


        }

    }
}