using OOP3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4._1.Observer
{
    public class CObject
    {
        protected string Name;
        public Container<ICObserver> _observers = new Container<ICObserver>();
        public virtual string Who()
        {
            return Name;
        }
        public virtual void AddObserver(ICObserver observer)
        {
            _observers.Add(observer);
        }
        public virtual void RemoveObservers()
        {
            _observers.Clear();
        }
        public virtual void NotifyEveryone()
        {
            foreach(var observer in _observers)
            {
                observer.OnSubjectChanged(this);
            }
        }
        public virtual void NotifyEveryoneMove(int x, int y)
        {
            foreach (var observer in _observers)
            {
                observer.OnSubjectMove(x, y);
            }
        }
        public virtual void NotifyEveryoneSelect()
        {
            foreach (var observer in _observers)
            {
                observer.OnSubjectSelect(this);
            }
        }
    }
}
