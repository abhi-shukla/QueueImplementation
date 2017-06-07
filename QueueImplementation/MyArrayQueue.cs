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
            if (_size == _list.Length)
            {
                var newArrayLength = _size == 0 ? 4 : _size * 2;
                T[] newArray = new T[_size * 2];

                if (_size > 0)
                {
                    var newArrayIndex = 0;

                    if (_tail < _head)
                    {
                        // Copy elements form head to end
                        for (int i = _head; i < _list.Length; i++)
                        {
                            newArray[newArrayIndex] = _list[i];
                            newArrayIndex++;
                        }

                        // Copy elements from start until tail
                        for (int i = 0; i <= _tail; i++)
                        {
                            newArray[newArrayIndex] = _list[i];
                            newArrayIndex++;
                        }
                    }
                    else
                    {
                        for(int i = _head; i <= _tail; i++)
                        {
                            newArray[newArrayIndex] = _list[i];
                            newArrayIndex++;
                        }
                    }

                    _head = 0;
                    _tail = newArrayIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }

                _list = newArray;
            }

            if(_tail == _list.Length -1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            _list[_tail] = item;
            _size++;
        }

        public T Dequeue()
        {
            if(_size == 0)
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }

            _size--;
            return _list[_head++ % _list.Length];
        }

        public T Peek()
        {
            if(_size == 0)
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }

            return _list[_head % _list.Length];
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                if(_tail < _head)
                {
                    for(int i = _head; i < _list.Length; i++)
                    {
                        yield return _list[i];
                    }
                    for(int i = 0; i<_tail; i++)
                    {
                        yield return _list[i];
                    }
                }
                else
                {
                    for(int i = _head; i <= _tail; i++)
                    {
                        yield return _list[i];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
