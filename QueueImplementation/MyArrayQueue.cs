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
        int _head = -1;
        int _tail = -1;

        public int Count => _size;

        public void Enqueue(T item)
        {
            if(_size == 0)
            {
                _list = new T[4];
            }
            else if(_size == _list.Length)
            {                
                var newArray = new T[_size*2];
                _list.CopyTo(newArray, 0);
                _list = newArray;
            }

            if(_head == -1 && _tail == -1)
            {
                _list[++_head] = item;
                _tail++;
                _size++;
            }
            else
            {
                _list[++_tail % _list.Length] = item;
                _size++;
            }
        }

        public T Dequeue()
        {
            if(_head == -1)
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }

            _size--;
            return _list[_head++ % _list.Length];
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
