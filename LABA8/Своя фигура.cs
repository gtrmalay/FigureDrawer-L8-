using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA8
{
    public class MyFigure : Figure
    {
        bool IsDraw = false;
        int x;
        int y;
        int w;
        int h;
        Point[] triangle;

        public MyFigure(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public override void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
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
                Point[] triangle = { new Point(x, y + h / 4), new Point(x + w / 2, y), new Point(x + w, y + h / 4) };
                g.DrawPolygon(Init.pen, triangle);
                g.DrawRectangle(Init.pen, this.x, this.y + h / 4, this.w, this.h / 2 + h / 4);
                g.DrawEllipse(Init.pen, this.x, this.y + h / 4, this.w, this.h / 2 + h / 4);
                Init.pictureBox.Image = Init.bitmap;
                IsDraw = true;
            }
            else
            {
                MessageBox.Show("Фигура выходит за границу!");
                IsDraw = false;
            }
        }

        public virtual void AddContainer(ComboBox combobox)
        {
            if (IsDraw)
            {
                ShapeContainer.AddFigure(this, combobox);
            }
            else
            {
                combobox.Items.Remove(this);
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
            else
            {
                
            }
        }
    }
}
