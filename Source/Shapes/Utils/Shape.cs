﻿using Project.Source.Shapes.Utils;
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
    abstract class Shape : BaseShape
    {
        protected int _x, _y; // Координаты центра фигуры
        protected int _width = 30, _height = 30; // Ширина и высота фигуры
        protected Color _color; // Цвет фигуры
        protected Pen _shapePen = new Pen(Color.Black, 1.0f);
        protected bool isMoved = false;

        public abstract Shape clone(); // Создание клона
        public abstract void load(StreamReader stream);

        public override bool canMoveX(int num, int start, int end)
        {
            if (num < 0 && (_x - _width / 2 == start))
                return false;
            else if (num > 0 && (_x + _width / 2 == end))
                return false;
            else
                return true;
        }
        public override bool canMoveY(int num, int start, int end)
        {
            if (num < 0 && (_y - _height / 2 == start))
                return false;
            else if (num > 0 && (_y + _height / 2 == end))
                return false;
            else
                return true;
        }
        public override void moveX(int num, int start, int end)
        {
            if (isMoved)
                return;
            if (_x - _width / 2 + num < start)
            {
                _x = start + _width / 2;
                num = 0;
            }
            else if (_x + _width / 2 + num > end)
            {
                _x = end - _width / 2;
                num = 0;
            }
            else
                _x += num;

            isMoved = true;
            notifyMoveX(num, start, end);
        }
        public override void moveY(int num, int start, int end)
        {
            if (isMoved) return;
            if (_y - _height / 2 + num < start)
            {
                _y = start + _height / 2;
                num = 0;
            }
            else if (_y + _height / 2 + num > end)
            {
                _y = end - _height / 2;
                num = 0;
            }
            else
                _y += num;

            isMoved = true;
            notifyMoveY(num, start, end);
        }
        public override int getX() { return _x; }
        public override int getY() { return _y; }
        public void setX(int x) { _x = x; }
        public void setY(int y) { _y = y; }
        public int getWidth() { return _width; }
        public int getHeight() { return _height; }
        public override void changeSize(int num)
        {
            int tmpWidth = _width + num;
            int tmpHeight = _height + num;
            if (tmpWidth > 0 && tmpHeight > 0)
            {
                _width += num;
                _height += num;
            }
        }
        public override void setColor(Color color) 
        { 
            _color = color; 
        }
        public override void shapeMoved()
        {
            isMoved = false;
        }
    }
}
