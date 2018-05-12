using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Data_acquisition.Comm
{
    class ReadColor
    {
        public static Color getcolor(string str)
        {
        if(string.IsNullOrEmpty(str))return Color.Black;
        string []rgb=str.Split(',');
        int r= int.Parse( rgb[0]);
        int g = int.Parse(rgb[1]); int b = int.Parse(rgb[2]);
        return Color.FromArgb(r,g,b);
        }
    }

}
