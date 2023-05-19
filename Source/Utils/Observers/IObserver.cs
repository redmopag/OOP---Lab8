using Project.Source.Utils.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Utils
{
    internal interface IObserver
    {
        void subjectChange(CSubject subject);
    }
}
