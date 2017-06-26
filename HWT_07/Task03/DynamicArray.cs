namespace Task03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>
    {
        private const int DefaultCapacity = 8;
        private int currentIndex;
        private T[] elements;

        public DynamicArray()
        {
            this.Capacity = DefaultCapacity;
            this.elements = new T[this.Capacity];
        }

        public DynamicArray(int count)
        {
            this.Capacity = count;
            this.elements = new T[this.Capacity];
        }

        public DynamicArray(ICollection<T> collection)
        {
            this.Length = this.Capacity = collection.Count;
            this.elements = new T[collection.Count];
            collection.CopyTo(this.elements, 0);
        }

        public int Length { get; private set; }

        public int Capacity { get; private set; }

        public T Current
        {
            get
            {
                if (this.currentIndex < 0 || this.currentIndex >= this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.elements[this.currentIndex];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.elements[index];
            }

            set
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.elements[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Length == this.Capacity)
            {
                this.Capacity *= 2; //todo не очень хорошее решение с т.з. производительности. Представь, что у тебя в массиве 1млн элементов, а добавить нужно штук 100. Для чего выделять дополнительно ещё 1млн пустых записей? Лучше задать константой какое-то значение, на которое ты увеличиваешь массив при переполнении.
				this.BoostArray();
            }

            this.elements[++this.Length - 1] = element;
        }

        public void AddRange(ICollection<T> collection)
        {
            int length = collection.Count + this.Length;
            if (this.Capacity < length)
            {
                this.Capacity = 1 >> (int)Math.Floor(length / Math.Log(this.Capacity));
                this.BoostArray();
            }

            collection.CopyTo(this.elements, this.Length);
            this.Length = length;
        }

        public bool Remove(int index)
        {
            if (index >= this.Length)
            {
                return false;
            }

            if (index == this.Length - 1)
            {
                this.Length--;
                return true;
            }

            for (int i = index; i < this.Length - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            return true;
        }

        public bool Insert(T element, int index)
        {
            if (this.Length >= this.Capacity)
            {
                return false;
            }

            for (int i = index; i < this.Length; i++)
            {
                this.elements[i + 1] = this.elements[i];
            }

            this.elements[index] = element;
            return true;
        }

        public bool MoveNext()
        {
            if (this.currentIndex == this.Length)
            {
                return false;
            }

            this.currentIndex++;
            return true;
        }

        public void Reset()
        {
            this.currentIndex = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public void Dispose()
        {
        }

        private void BoostArray()
        {
            var buf = new T[this.Capacity];
            this.elements.CopyTo(buf, 0);
            this.elements = buf;
        }
    }
}
