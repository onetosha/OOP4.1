using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4._1.Observer
{
    public interface ICObserver
    {
        void OnSubjectChanged(CObject who);
        void OnSubjectSelect(CObject who);
        void OnSubjectMove(int x, int y);
    }
}
