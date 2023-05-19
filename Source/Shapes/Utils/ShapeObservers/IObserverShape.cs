using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes.Utils
{
    internal interface IObserverShape
    {
        void subjectMoveX(int num, int start, int end);
        void subjectMoveY(int num, int start, int end);
    }
}
