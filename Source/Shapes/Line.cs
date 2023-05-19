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
        private Pen _pen = new Pen(Color.Black, 1.0f);
        private MyArray<BaseShape> shapes = new MyArray<BaseShape>(2);

        public void draw(Graphics gr)
        {
            if(shapes.Count == 2)
            {
                
            }
            gr.DrawLine(_pen, start, end);
        }
        public void addShape(BaseShape shape)
        {
            if (shapes.Count < 2)
                shapes.Add(shape);
        }
    }
}
