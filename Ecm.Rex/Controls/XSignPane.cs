using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;

namespace Ecm.Rex.Controls
{
    public partial class XSignPane : DevExpress.XtraEditors.XtraUserControl
    {   
        //GraphicsPath
        private GraphicsPath _gPath = new GraphicsPath();
        //variables to store current location
        private int _x = 0;
        private int _y = 0;
        //is-left-mouse-buttons--pressed
        private bool _tracking = false;

         //create a bitmap, draw the path to it
        Bitmap bmp;
         public Bitmap Bitmap
         {
             get
             {
                 bmp = new Bitmap(panelSign.Width, panelSign.Height);
                 using (Graphics g = Graphics.FromImage(bmp))
                 {
                     g.SmoothingMode = SmoothingMode.AntiAlias;
                     using (Pen pen = new Pen(this.colorEdit1.Color, (float)this.spinEdit1.Value))
                         g.DrawPath(pen, _gPath);
                 }
                 return  bmp;
             }

             set 
             {
                 bmp = value;
                 panelSign.ContentImage = (Image)value;
             }
         }

        public XSignPane()
        {
            InitializeComponent();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            //check if path is instanciated
            if (_gPath != null)
            {
                //set a better SmoothingMode
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                //draw the path with a pen created of our-Forms/Controls values
                using (Pen pen = new Pen(colorEdit1.Color, (float)spinEdit1.Value))
                    e.Graphics.DrawPath(pen, _gPath);
            }
        }

        private void panelControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //set the start-point
                _x = e.X;
                _y = e.Y;

                //ensure that the GraphicsPath is instanciated
                if (_gPath == null)
                {
                    _gPath = new GraphicsPath();
                }

                //set our indicator
                _tracking = true;
            }
        }

        private void panelControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_tracking)
            {
                //add a line to the path from the previous point to the current point
                _gPath.AddLine(new Point(_x, _y), new Point(e.X, e.Y));
                //set the current point to the new values
                _x = e.X;
                _y = e.Y;

                //call the draw-method
                panelSign.Invalidate();
            }
        }

        private void panelControl1_MouseUp(object sender, MouseEventArgs e)
        {
            //start a new figure for next drawing-part
            if (_tracking)
                _gPath.StartFigure();

            //mousebutton is now up
            _tracking = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            panelSign.ContentImage = null;
            //reset the path and repaint
            if (_gPath != null)
                _gPath.Reset();

            panelSign.Invalidate();

        }
    }
}
