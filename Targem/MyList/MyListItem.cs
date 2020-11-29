using System;
namespace Targem.MyList
{
    internal class MyListItem<T>
    {
        public MyListItem<T> next;
        public T value;

        public MyListItem(T value)
        {
            this.value = value;
            next = null;
        }
    }
}
