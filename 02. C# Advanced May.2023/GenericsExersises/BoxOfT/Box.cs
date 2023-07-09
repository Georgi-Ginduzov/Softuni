using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;
        public Box()
        {
            list = new List<T>();
        }
        public int Count => this.list.Count;
        public void Add(T item)
        {
            this.list.Add(item);
        }
        public T Remove()
        {
            var lastElement = this.list.Last();
            this.list.Remove(lastElement);
            return lastElement;
        }
    }
}
