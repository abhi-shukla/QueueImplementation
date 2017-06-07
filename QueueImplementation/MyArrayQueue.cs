using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplementation
{
    public class MyArrayQueue<T> : IEnumerable<T>
    {
        T[] _list = new T[0];
        int _size = 0;

        public int Count => _size;

        public void Enqueue(T item)
        {
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>) _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
