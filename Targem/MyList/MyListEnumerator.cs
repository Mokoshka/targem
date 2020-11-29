using System;
using System.Collections;
using System.Collections.Generic;
namespace Targem.MyList
{
    internal class MyListEnumerator<T> : IEnumerator<T>, IEnumerator
    {
        MyList<T> List;
        MyListItem<T> CurrentItem;
        bool IsEnd;

        public MyListEnumerator(MyList<T> list)
        {
            List = list;
            CurrentItem = null;
            IsEnd = false;
        }

        public T Current
        {
            get
            {
                if (CurrentItem == null)
                {
                    throw new InvalidOperationException();
                }

                return CurrentItem.value;
            }
        }

        object IEnumerator.Current
        {
            get => Current;
        }

        public void Dispose()
        {
            List = null;
            CurrentItem = null;

            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            if (List.Count == 0)
            {
                return false;
            }

            if (CurrentItem == null && !IsEnd)
            {
                CurrentItem = List.GetItem(0);

                return true;
            }

            if (CurrentItem != null)
            {
                CurrentItem = CurrentItem.next;
            }

            IsEnd = CurrentItem != null;

            return CurrentItem != null;
        }

        public void Reset()
        {
            IsEnd = false;
            CurrentItem = null;
        }
    }
}
