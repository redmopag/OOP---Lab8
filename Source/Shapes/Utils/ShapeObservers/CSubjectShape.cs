using Project.Source.Utils.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes.Utils
{
    internal class CSubjectShape
    {
        private List<IObserverShape> _observers = new List<IObserverShape>();
        public void addObserver(IObserverShape observer) { _observers.Add(observer); }
        public void removeObserver(IObserverShape observer) { _observers.Remove(observer); }
        public void notifyMoveX(int num, int start, int end)
        {
            foreach(IObserverShape observer in _observers)
                observer.subjectMoveX(num, start, end);
        }
        public void notifyMoveY(int num, int start, int end)
        {
            foreach(IObserverShape observer in _observers)
                observer.subjectMoveY(num, start, end);
        }
    }
}
