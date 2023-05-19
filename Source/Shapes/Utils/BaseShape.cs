using Project.Source.Shapes.Utils;
using Project.Source.Utils;
using Project.Source.Utils.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes
{
    abstract class BaseShape : CSubjectShape, IObserverShape
    {
        public abstract void moveX(int num, int start, int end);
        public abstract void moveY(int num, int start, int end);
        public abstract void changeSize(int num);
        public abstract void setColor(Color color);
        public abstract bool canMoveX(int num, int start, int end);
        public abstract bool canMoveY(int num, int start, int end);
        public abstract void draw(Graphics gr); // Рисование фигуры
        public abstract bool inShape(int x, int y);
        public abstract void save(StreamWriter stream);
        public abstract string className();
        public abstract int getX();
        public abstract int getY();
        public abstract void shapeMoved();

        public void subjectMoveX(int num, int start, int end)
        {
            if(!(this is CDecorator))
                moveX(num, start, end);
        }
        public void subjectMoveY(int num, int start, int end)
        {
            if (!(this is CDecorator))
                moveY(num, start, end); 
        }
    }
}
