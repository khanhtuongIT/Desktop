using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Ecm.Rex.Reports
{
    public partial class rptRex_Thongke_Nhansu : DevExpress.XtraReports.UI.XtraReport
    {
        public rptRex_Thongke_Nhansu()
        {
            InitializeComponent();

        }

        public XRTable CreateXRTable(DataSet ds_collection, string value, string column)
        {
            XRTable table = new XRTable();
            table.BeginInit();

            table.Borders = DevExpress.XtraPrinting.BorderSide.All;
            table.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            table.LocationF = new PointF(30, 30);
            int tableHeight = 0;
            int tableWidth = 0;

            for (int i = -1; i < ds_collection.Tables[0].Rows.Count; i++)
            {
                XRTableRow row = new XRTableRow();
                row.Height = 40;
                tableHeight += row.Height;

                for (int j = 0; j < 2; j++)
                {
                    XRTableCell cell = new XRTableCell();
                    cell.Width = 100;
                    if (i == -1)
                    {
                        if (j == 0)
                        {
                            cell.Text = value;
                            tableWidth += cell.Width;
                            row.Cells.Add(cell);
                            cell.BackColor = Color.Gray;
                            continue;
                        }
                        else
                        {
                            cell.Text = "Số lượng";
                            tableWidth += cell.Width;
                            cell.BackColor = Color.Gray;
                            row.Cells.Add(cell);         
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                            cell.Text = ds_collection.Tables[0].Rows[i][column].ToString();
                        else
                            cell.Text = ds_collection.Tables[0].Rows[i]["Count_Result"].ToString();
                    }
                    tableWidth += cell.Width;
                    row.Cells.Add(cell);
                }
                table.Rows.Add(row);
            }
            tableWidth = 700;            
            table.Size = new Size(tableWidth, tableHeight);

            table.EndInit();

            return table;
        }

        private void xrTuoi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //this.Detail.Controls.Add(CreateXRTable());
        }

        public void setInfo(DataSet ds_collection, string value, string column)
        {
            this.Detail.Controls.Add(CreateXRTable(ds_collection,value, column));
        }

    }



}
