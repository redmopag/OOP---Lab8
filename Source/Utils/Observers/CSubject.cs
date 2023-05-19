using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Utils.AbstractFactory
{
    internal class CSubject
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void addObserver(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void notify()
        {
            foreach (IObserver observer in _observers)
            {
                observer.subjectChange(this);
            }
        }
    }
}
