using System;
using System.Linq;


namespace _03.GenericList
{
    [Version(2, 11)]
    public class GenericList<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 16;
        private int currentIndex;
        private T[] elements;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }


        public void Add(T element)
        {
            if (currentIndex == this.elements.Length)
            {
                Resize();
            }

            this.elements[currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove(T item)
        {
            var index = this.IndexOf(item);

            if (index == -1)
            {
                throw new ArgumentException("The item does not exists.");
            }

            for (int i = index; i < currentIndex - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            this.currentIndex--;
        }
        public void RemoveAt(int index)
        {
            if (index > currentIndex)
            {
                throw new ArgumentOutOfRangeException("The index is out of array range.");
            }

            for (int i = index; i < currentIndex - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            
            this.currentIndex--;
        }

        public T Insert(int index, T item)
        {
            if (index + 1 > currentIndex)
            {
                throw new ArgumentOutOfRangeException("The index is out of array range.");
            }
            return this.elements[index] = item;
        }

        public void Clear()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                this.elements[i] = default(T);
            }
            this.currentIndex = 0;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (this.elements[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (match(this.elements[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (this.elements[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public T Min()
        {
            var min = this.elements[0];

            for (int i = 1; i < this.currentIndex; i++)
            {
                var r = this.elements[i].CompareTo(min);
                if (min.CompareTo(this.elements[i]) > 0)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }

        public T Max()
        {
            var max = this.elements[0];

            for (int i = 1; i < currentIndex; i++)
            {
                var r = this.elements[i].CompareTo(max);
                if (max.CompareTo(this.elements[i]) < 0)
                {
                    max = this.elements[i];
                }
            }

            return max;
        }

        private void Resize()
        {
            var newElements = new T[this.elements.Length * 2];
            for (int i = 0; i < currentIndex; i++)
            {
                newElements[i] = this.elements[i];
            }
            this.elements = newElements;
        }

        public void Print()
        {
            Console.WriteLine($"{{ {string.Join(", ", this.elements.Take(this.currentIndex))} }}") ;
        }

        public override string ToString()
        {
            return $"{{ {string.Join(", ", this.elements.Take(this.currentIndex))} }}";
        }
    }
}