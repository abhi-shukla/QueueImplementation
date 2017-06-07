using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplementation
{
    public class MyLLQueue<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();

        public int Count => _list.Count;

        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        public T Dequeue()
        {
            var temp = _list.First.Value;
            _list.RemoveFirst();

            return temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
