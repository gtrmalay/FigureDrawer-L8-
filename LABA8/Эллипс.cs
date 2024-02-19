using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA8
{

    public class Ellipse: Figure
    {
        bool IsDraw =  false;
        

        public Ellipse(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
        public Ellipse()
        {
            this.x = 0;
            this.y = 0;
            this.w = 0;
            this.h = 0;
        }

        public override void Draw()
        {
            if (!((this.x < 0 && this.y + y < 0) || (this.y < 0)
            || (this.x > Init.pictureBox.Width && this.y < 0)
            || (this.x + this.w > Init.pictureBox.Width)
            || (this.x > Init.pictureBox.Width && this.y > Init.pictureBox.Height)
            || (this.y + this.h + y > Init.pictureBox.Height)
            || (this.x < 0 && this.y > Init.pictureBox.Height)
            || (this.x < 0)))
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                g.DrawEllipse(Init.pen, this.x, this.y, this.w, this.h);
                Init.pictureBox.Image = Init.bitmap;
                IsDraw = true;
            }
        }

        public void AddContainer(ComboBox combobox)
        {
            if (IsDraw)
            {
                ShapeContainer.AddFigure(this, combobox);
            }
            else
            {

            }
        }
        public override void MoveTo(int x, int y)
        {
            if (!((this.x + x < 0 && this.y + y < 0) || (this.y + y < 0)
                || (this.x + x > Init.pictureBox.Width && this.y + y < 0)
                || (this.x + this.w + x > Init.pictureBox.Width)
                || (this.x + x > Init.pictureBox.Width && this.y + y > Init.pictureBox.Height)
                || (this.y + this.h + y > Init.pictureBox.Height)
                || (this.x + x < 0 && this.y + y > Init.pictureBox.Height)
                || (this.x + x < 0)))
            {
                this.x += x;
                this.y += y;
                this.Clear();
                this.Draw();
            }
        }

        public override void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }
    }
}
