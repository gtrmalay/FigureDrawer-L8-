using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA8
{
    public class Polygon : Figure
    {
        protected int[][] points;
        bool IsDraw = false;
        public Polygon(int[][] points)
        {
            this.points = points;
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

                Point[] pointsArray = new Point[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    pointsArray[i] = new Point(points[i][0], points[i][1]);
                }
                Graphics g = Graphics.FromImage(Init.bitmap);
                g.DrawPolygon(Init.pen, pointsArray);
                Init.pictureBox.Image = Init.bitmap;
                    IsDraw = true;

                }
                else
                {
                    MessageBox.Show("Фигура выходит за границы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
            }
        }
        public override void MoveTo(int newX, int newY)
        {

            int deltaX = newX;
            int deltaY = newY;
            
            for (int i = 0; i < points.Length; i++)
            {
                points[i][0] += deltaX;
                points[i][1] += deltaY;
            }
            this.x = newX;
            this.y = newY;

            this.Clear();
            // перерисовываем фигуру
            this.Draw();
        }

        public override void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }

    }
}
