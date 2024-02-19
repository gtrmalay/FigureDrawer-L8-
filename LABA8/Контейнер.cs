using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA8
{
    class ShapeContainer
    {
        public static List<Figure> figureList;
        static ShapeContainer()
        {
            figureList = new List<Figure>();
        }
        public static  void AddFigure(Figure figure, ComboBox combobox1)
        {
            figureList.Add(figure);
            combobox1.Items.Add(figure);
        }


       


        static public void RemoveShape(Figure figure, ComboBox combobox1)
        {

            figureList.Remove(figure);
            combobox1.Items.Remove(figure);

            // удаление элемента в комбобоксе
            figure.Clear();
            DrawAllShapes();

        }

        public static void DrawAllShapes()
        {
            
            Bitmap clearBitmap = new Bitmap(Init.pictureBox.ClientSize.Width, Init.pictureBox.ClientSize.Height);
            Graphics clearGraphics = Graphics.FromImage(clearBitmap);

            foreach (Figure figure in figureList)
            {
                figure.Draw(); 
            }

           
            
        }




    }
}
