using System;
using System.Collections;
using System.Collections.Generic;

namespace Targem.MyList
{
    public class MyList<T> : IList<T>
    {
        private MyListItem<T> FirstItem;
        private MyListItem<T> LastItem;
        private int _Count;

        public MyList()
        {
            _Count = 0;
            FirstItem = null;
            LastItem = null;
        }

        public T this[int index] {
            get => GetItem(index).value;
            set => GetItem(index).value = value;
        }

        public bool IsReadOnly => false;

        public int Count => _Count;

        public void Add(T value)
        {
            MyListItem <T> item = new MyListItem<T>(value);

            if (FirstItem == null)
            {
                FirstItem = item;
            }

            if (LastItem != null)
            {
                LastItem.next = item;
            }

            LastItem = item;
            _Count++;
        }

        public void Clear()
        {
            _Count = 0;
            FirstItem = null;
            LastItem = null;
        }

        public bool Contains(T value)
        {
            return GetItem(value) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            MyListItem<T> currentItem = FirstItem;

            while (currentItem != null)
            {
                array.SetValue(currentItem.value, arrayIndex++);

                currentItem = currentItem.next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }

        public int IndexOf(T value)
        {
            return GetItemIndex(value);
        }

        public void Insert(int index, T value)
        {
            CheckIndexRange(index);

            MyListItem<T> newItem = new MyListItem<T>(value);

            if (index == 0)
            {
                newItem.next = FirstItem;
                FirstItem = newItem;
            }
            else
            {
                MyListItem<T> prevItem = GetItem(index - 1);
                newItem.next = prevItem.next;
                prevItem.next = newItem;
            }
        }

        public bool Remove(T value)
        {
            MyListItem<T> currentItem = FirstItem;
            MyListItem<T> prevItem = null;

            while (currentItem != null && !currentItem.value.Equals(value))
            {
                prevItem = currentItem;
                currentItem = currentItem.next;
            }

            if (currentItem == null)
            {
                return false;
            }

            ReplaceNext(prevItem, currentItem);

            return true;
        }

        public void RemoveAt(int index)
        {
            CheckIndexRange(index);

            MyListItem<T> prevItem = index == 0 ? null : GetItem(index - 1);
            MyListItem<T> currentItem = prevItem == null ? FirstItem.next : prevItem.next;

            ReplaceNext(prevItem, currentItem);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }

        internal MyListItem<T> GetItem(int index)
        {
            CheckIndexRange(index);

            int currentIndex = 0;
            MyListItem<T> currentItem = FirstItem;

            while (currentIndex < index)
            {
                currentIndex += 1;
                currentItem = currentItem.next;
            }

            return currentItem;
        }

        private void CheckIndexRange(int index)
        {
            if (index > _Count - 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private MyListItem<T> GetItem(T value)
        {
            MyListItem<T> currentItem = FirstItem;

            while (currentItem != null && !currentItem.value.Equals(value))
            {
                currentItem = currentItem.next;
            }

            return currentItem;
        }

        private int GetItemIndex(T value)
        {
            MyListItem<T> currentItem = FirstItem;
            int index = 0;

            while (currentItem != null && !currentItem.value.Equals(value))
            {
                currentItem = currentItem.next;
                index++;
            }

            return currentItem != null ? index : -1;
        }

        private void ReplaceFirst(MyListItem<T> item)
        {
            FirstItem = item.next;

            if (FirstItem == null)
            {
                LastItem = null;
            }
        }

        private void ReplaceNext(MyListItem<T> prevItem, MyListItem<T> item)
        {
            if (prevItem == null)
            {
                ReplaceFirst(item);
            }
            else
            {
                prevItem.next = item.next;

                if (prevItem.next == null)
                {
                    LastItem = prevItem;
                }
            }

            _Count--;
        }
    }
}
