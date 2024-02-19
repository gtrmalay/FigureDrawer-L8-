using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA8
{
    abstract public class Figure
    {
        public int x;
        public int y;
        public int w;
        public int h;

        public int point1;
        public int point2;
        public int point3;
        abstract public void Draw();
        abstract public void MoveTo(int x, int y);

        abstract public void Clear();


    }
}
