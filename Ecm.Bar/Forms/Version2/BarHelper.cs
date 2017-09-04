using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SunLine.Bar.Forms.Version2
{
    public class BarHelper
    {
        public static Color GetColor(int index)
        {
            Color color = Color.BlueViolet;
            switch (index % 10)
            {
                case 0:
                    color = Color.Orange;
                    break;
                case 1:
                    color = Color.LawnGreen;
                    break;
                case 2:
                    color = Color.Aquamarine;
                    break;
                case 3:
                    color = Color.LightCyan;
                    break;
                case 4:
                    color = Color.LavenderBlush;
                    break;
                case 5:
                    color = Color.LightBlue;
                    break;
                case 6:
                    color = Color.Bisque;
                    break;
                case 7:
                    color = Color.Tomato;
                    break;
                case 8:
                    color = Color.LightGreen;
                    break;
                case 9:
                    color = Color.SteelBlue;
                    break;
            }
            return color;
        }
    }
}
