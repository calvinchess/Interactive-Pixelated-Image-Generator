using System;
using System.Collections.Generic;
using System.Text;

namespace Color_Picker
{
    public  class ColorCount
    {
        public OnlineBeadColor color;
        public int count;

        public ColorCount(OnlineBeadColor color, int count)
        {
            this.color = color;
            this.count = count;
        }
    }
}
