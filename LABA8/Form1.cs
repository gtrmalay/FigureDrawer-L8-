using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LABA8
{


    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;

        Pen pen = new Pen(Color.Black, 5);

        ShapeContainer shapeContainer = new ShapeContainer();




        public Form1()
        {
            InitializeComponent();

            this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            this.pen = new Pen(Color.Black, 5);
            Init.bitmap = this.bitmap;
            Init.pictureBox = pictureBox1;
            Init.pen = this.pen;


        }

        private void button1_Click(object sender, EventArgs e) //
        {
            try
            {
                if (int.Parse(TriangleX1.Text) >= 0 && int.Parse(TriangleY1.Text) >= 0 && int.Parse(TriangleX2.Text) >= 0 && int.Parse(TriangleY2.Text) >= 0 && int.Parse(TriangleX3.Text) >= 0 && int.Parse(TriangleY3.Text) >= 0)
                {

                    int[] point1 = { int.Parse(TriangleX1.Text), int.Parse(TriangleY1.Text) };
                    int[] point2 = { int.Parse(TriangleX2.Text), int.Parse(TriangleY2.Text) };
                    int[] point3 = { int.Parse(TriangleX3.Text), int.Parse(TriangleY3.Text) };

                    Triangle triangledraw = new Triangle(point1, point2, point3);
                    triangledraw.Draw();
                    triangledraw.AddContainer(comboBox1);



                }
                else
                {
                    MessageBox.Show("Координаты не могут быть отрицательными!", "Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пожалуйста, совершите корректный ввод!", "Ошибка!");
            }


        }


        private void button2_Click(object sender, EventArgs e) //кнопка для создания прямоугольника 
        {
            try
            {
                int x = int.Parse(XRetagle.Text);
                int y = int.Parse(YRetagle.Text);
                int w = int.Parse(WRetagle.Text);
                int h = int.Parse(HRetagle.Text);
                if (x >= 0 && y >= 0 && w >= 0 && h >= 0)
                {


                    Rectagle rectagledraw = new Rectagle(x, y, w, h);
                    rectagledraw.Draw();
                    rectagledraw.AddContainer(comboBox1);

                }
                else
                {
                    MessageBox.Show("Вводите положительные числа!", "Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пожалуйста, совершите корректный ввод!", "Ошибка!");
            }


        }

        private void Ellipse_Button_Click(object sender, EventArgs e) //кнопка для создания эллипса
        {
            try
            {
                int x = int.Parse(XEllipse.Text);
                int y = int.Parse(YEllipse.Text);
                int w = int.Parse(WEllipse.Text);
                int h = int.Parse(HEllipse.Text);
                if (x >= 0 && y >= 0 && w >= 0 && h >= 0)
                {


                    Ellipse ellipsedraw = new Ellipse(x, y, w, h);
                    ellipsedraw.Draw();
                    ellipsedraw.AddContainer(comboBox1);
                }
                else
                {
                    MessageBox.Show("Вводите положительные числа!", "Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пожалуйста, совершите корректный ввод!", "Ошибка!");
            }
        }


        private void Circle_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(CircleX.Text);
                int y = int.Parse(CircleY.Text);
                int w = int.Parse(CircleL.Text);
                int h = int.Parse(CircleL.Text);
                if (x >= 0 && y >= 0 && w >= 0 && h >= 0)
                {

                    Circle circledraw = new Circle(x, y, w, h);
                    circledraw.Draw();
                    circledraw.AddContainer(comboBox1);
                }
                else
                {
                    MessageBox.Show("Вводите положительные числа!", "Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пожалуйста, совершите корректный ввод!", "Ошибка!");
            }


        }

        private void Square_button_Click_1(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(SquareX.Text);
                int y = int.Parse(SquareY.Text);
                int w = int.Parse(SquareL.Text);
                int h = int.Parse(SquareL.Text);
                if (x >= 0 && y >= 0 && w >= 0 && h >= 0)
                {

                    Square squaredraw = new Square(x, y, w, h);
                    squaredraw.Draw();
                    squaredraw.AddContainer(comboBox1);



                }
                else
                {
                    MessageBox.Show("Вводите положительные числа!", "Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пожалуйста, совершите корректный ввод!", "Ошибка!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                List<int[]> points = new List<int[]>();
                int pointCount = int.Parse(textBoxPointCount.Text);
                for (int i = 1; i <= pointCount; i++)
                {
                    int x = int.Parse(Interaction.InputBox($"Введите координату X для вершины {i}:"));
                    int y = int.Parse(Interaction.InputBox($"Введите координату Y для вершины {i}:"));
                    points.Add(new int[] { x, y });
                    if (x <= 0 || y <= 0)
                    {
                        MessageBox.Show("Вводите положительные числа!", "Ошибка!");
                        break;
                    }
                }
                if (pointCount >= 0)
                {
                    // Создание объекта полигона
                    Polygon polygon = new Polygon(points.ToArray());

                    // Добавление полигона в контейнер фигур
                    ShapeContainer.AddFigure(polygon, comboBox1);

                    // Прорисовка полигона
                    polygon.Draw();
                }
                else
                {
                    MessageBox.Show("Это не может быть отрицательным!", "Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пожалуйста, совершите корректный ввод!", "Ошибка!");
            }
        }

        private void ShapeDelete_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                // Получаем выбранную фигуру
                Figure selectedShape = (Figure)comboBox1.SelectedItem;

                Graphics g = Graphics.FromImage(pictureBox1.Image);
                g.Clear(Color.White);
                // Удаляем выбранную фигуру из ShapeContainer
                ShapeContainer.RemoveShape(selectedShape, comboBox1);

                comboBox1.Items.Remove(selectedShape);

                foreach (Figure figure in ShapeContainer.figureList)
                {
                    figure.Draw();
                }



                pictureBox1.Refresh();

            }
        }

        private void MyFigure_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(MyX.Text);
                int y = int.Parse(MyY.Text);
                int w = int.Parse(MyW.Text);
                int h = int.Parse(MyH.Text);
                if (x >= 0 && y >= 0 && w >= 0 && h >= 0)
                {

                    MyFigure myfiguredraw = new MyFigure(x, y, w, h);
                    myfiguredraw.Draw();
                    ShapeContainer.AddFigure(myfiguredraw, comboBox1);
                }
                else
                {
                    MessageBox.Show("Это не может быть отрицательным!", "Ошибка!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Пожалуйста, совершите корректный ввод!", "Ошибка!");
            }
        }

        private void Move_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int newX = int.Parse(MoveX.Text);
                int newY = int.Parse(MoveY.Text);

                Figure selectedShape = (Figure)comboBox1.SelectedItem;

                selectedShape.Draw();

                selectedShape.MoveTo(newX, newY);
                //foreach (Figure figure in ShapeContainer.figureList)
                //{
                //  figure.MoveTo(newX, newY);
                //}

                // После перемещения всех фигур перерисовываем их на pictureBox
                ShapeContainer.DrawAllShapes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пожалуйста, совершите корректный ввод!", "Ошибка!");
            }


        }
    }
    public static class Init
    {
        public static Bitmap bitmap;
        public static PictureBox pictureBox;
        public static Pen pen;
    }
}








