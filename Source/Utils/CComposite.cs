using Project.Source.Shapes;
using Project.Source.Utils.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Project.Source.Utils
{
    internal class CComposite : BaseShape
    {
        private List<BaseShape> _compShapes = new List<BaseShape>();
        private bool isMoved = false;
        public int Count { get => _compShapes.Count; }

        // Добавление элемента в группу
        public void addShape(BaseShape baseShape)
        {
            _compShapes.Add(baseShape);
        }
        //--------------------------------------------------------------
        // Бизнес-логика движения группы
        public override bool canMoveX(int num, int start, int end)
        {
            foreach (BaseShape baseShape in _compShapes)
                if (!baseShape.canMoveX(num, start, end))
                    return false;
            return true;
        }
        public override void moveX(int num, int start, int end)
        {
            if (isMoved) return;
            if (canMoveX(num, start, end))
            {
                foreach (BaseShape baseShape in _compShapes)
                    baseShape.moveX(num, start, end);
                notifyMoveX(num, start, end);
            }
            isMoved = true;
        }
        public override bool canMoveY(int num, int start, int end)
        {
            foreach (BaseShape baseShape in _compShapes)
                if (!baseShape.canMoveY(num, start, end))
                    return false;
            return true;
        }
        public override void moveY(int num, int start, int end)
        {
            if (isMoved) return;
            if (canMoveY(num, start, end))
            {
                foreach (BaseShape baseShape in _compShapes)
                    baseShape.moveY(num, start, end);
                notifyMoveY(num, start, end);
            }
            isMoved = true;
        }
        //--------------------------------------------------------------

        public override void changeSize(int num)
        {
            foreach (BaseShape baseShape in _compShapes)
                baseShape.changeSize(num);
        }
        public override void setColor(Color color)
        {
            foreach (BaseShape baseShape in _compShapes)
                baseShape.setColor(color);
        }
        public override void draw(Graphics gr)
        {
            foreach (BaseShape baseShape in _compShapes)
                baseShape.draw(gr);
        }
        public void setSelectionColor(Color color)
        {
            foreach (BaseShape baseShape in _compShapes)
                if (baseShape is CDecorator decorator)
                    decorator.setSelectionColor(color);
        }
        public void Remove()
        {
            _compShapes.RemoveAt(0);
        }
        public BaseShape getShape()
        {
            return _compShapes[0];
        }
        public BaseShape getShape(int index)
        {
            return _compShapes[index];
        }
        public override bool inShape(int x, int y)
        {
            foreach (BaseShape baseShape in _compShapes)
                if (baseShape.inShape(x, y))
                    return true;
            return false;
        }
        public override void save(StreamWriter stream)
        {
            stream.WriteLine("Group");
            stream.WriteLine("Amount = " + _compShapes.Count);
            foreach (BaseShape baseShape in _compShapes)
                baseShape.save(stream);
        }
        public override string className() { return "Group"; }
        public override int getX()
        {
            return _compShapes[0].getX();
        }
        public override int getY()
        {
            return _compShapes[0].getY();
        }
        public override void shapeMoved()
        {
            foreach (BaseShape baseShape in _compShapes)
                baseShape.shapeMoved();
            isMoved = false;
        }
    }
}
