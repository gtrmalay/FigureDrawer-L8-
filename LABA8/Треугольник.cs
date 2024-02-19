using System;
using System.Drawing;
using System.Windows.Forms;

namespace LABA8
{
    public class Triangle : Polygon
    {
        bool IsDraw = false;
        public int[] point1;
        public int[] point2;
        public int[] point3;
        int[][] points;


        public Triangle(int[] point1, int[] point2, int[] point3) : base(new int[][] { point1, point2, point3 })
        {
            points = new int[][] { point1, point2, point3 };
            
        }

        public virtual void AddContainer(ComboBox combobox)
        {
            if (IsDraw)
            {
                ShapeContainer.AddFigure(this, combobox);
            }
            else
            {

            }
        }

        public override void Draw()
        {
            for (int j = 0; j < points.Length; j++)
            {
                if (!((points[j][0] + x < 0 && points[j][1] + y < 0) || (points[j][1] + y < 0)
                    || (points[j][0] + x > Init.pictureBox.Width && points[j][1] + y < 0)
                    || (points[j][0] + x > Init.pictureBox.Width)
                    || (points[j][0] + x > Init.pictureBox.Width && points[j][1] + y > Init.pictureBox.Height)
                    || (points[j][1] + y > Init.pictureBox.Height)
                    || (points[j][0] + x < 0 && points[j][1] + y > Init.pictureBox.Height)
                    || (points[j][0] + x < 0)))
                {

                    IsDraw = true;
                }
                else
                {
                    MessageBox.Show("Не лезь за границы!");
                    return;
                }

                Point[] pointsArray = new Point[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    pointsArray[i] = new Point(points[i][0], points[i][1]);
                }
                Graphics g = Graphics.FromImage(Init.bitmap);
                g.DrawPolygon(Init.pen, pointsArray);
                Init.pictureBox.Image = Init.bitmap;
            }
        }
        

        public override void MoveTo(int newX, int newY)
        {
            int deltaX = newX;
            int deltaY = newY;
            if (!((this.x + x < 0 && this.y + y < 0) || (this.y + y < 0)
                 || (this.x + x > Init.pictureBox.Width && this.y + y < 0)
                 || (this.x + this.w + x > Init.pictureBox.Width)
                 || (this.x + x > Init.pictureBox.Width && this.y + y > Init.pictureBox.Height)
                 || (this.y + this.h + y > Init.pictureBox.Height)
                 || (this.x + x < 0 && this.y + y > Init.pictureBox.Height)
                 || (this.x + x < 0)))
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i][0] += deltaX;
                    points[i][1] += deltaY;
                }
                this.x = newX;
                this.y = newY;
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
