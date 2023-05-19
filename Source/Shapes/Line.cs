using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes
{
    internal class Line
    {
        private Point start, end;
        private Pen _pen;
        private MyArray<BaseShape> shapes;

        public Line()
        {
            start = new Point();
            end = new Point();
            shapes = new MyArray<BaseShape>();
            _pen = new Pen(Color.Black, 1.0f);
        }
        private void getPoints()
        {
            start.X = shapes[0].getX();
            start.Y = shapes[0].getY();
            end.X = shapes[1].getX();
            end.Y = shapes[1].getY();
        }
        public void draw(Graphics gr)
        {
            getPoints();
            gr.DrawLine(_pen, start, end);
        }
        public void addShape(BaseShape shape)
        {
            if (shapes.Count < 2)
                shapes.Add(shape);
        }
        public bool isFull()
        {
            if (shapes.Count == 2)
                return true;
            return false;
        }
        public BaseShape getStartShape() { return shapes[0]; }
        public BaseShape getEndShape() { return shapes[1]; }
        public Line clone() { return new Line(); }
        public Line copy()
        {
            Line line = new Line();
            line.addShape(shapes[0]);
            line.addShape(shapes[1]);
            shapes.Clear();
            return line;
        }
    }
}
