using System;
using System.Collections;
using System.Collections.Generic;

namespace Domaca_zadaca1
{
    public class IntgerList : IIntegerList
    {
        private int[] InternalList;
        
        public int Count { get; private set; }

        public void Add(int x)
        {
            if (Count == InternalList.Length)
            {
                int[] newarray = new int[InternalList.Length*2];
                for (int i = 0; i < InternalList.Length; i++)
                {
                    newarray[i] = InternalList[i];
                }
                newarray[Count] = x;
                InternalList = newarray;
                Count++;
                return;
            }
            
            InternalList[Count] = x;
            Count++;

            
        }

        public bool Remove(int item)
        {
            for (int i = 0; i < Count; i++) 
            {
                if (InternalList[i] == item)
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        InternalList[j] = InternalList[j + 1];
                    }
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count)
            {
               
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Count - 1; i++)
            {
                InternalList[i] = InternalList[i + 1];
            }
            Count--;
            return true;
        }

        public int GetElement(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            return InternalList[index];
        }

        public int IndexOf(int x)
        {
            for (int i = 0; i < Count; i++)
            {
                if (x == InternalList[i])
                {
                    return i;
                }
            }
            return -1;

        }

        public void Clear()
        {
            Count = 0;
            InternalList = new int[4];
        }

        public bool Contains(int x)
        {
            for (int i = 0; i < Count; i++)
            {
                if (x == InternalList[i])
                {
                    return true;
                }
            }
            return false;
        }

        public IntgerList()
        {
            InternalList = new int[4];
        }

        public IntgerList(int initalsize)
        {
            InternalList = new int[initalsize];
        }

    }

    public class GenericList<E> : IGenericList<E> 
    {
        private E[] genericlist;
        public int Count { get; private set; }

        public void Add(E x)
        {
            if (Count == genericlist.Length)
            {
                E[] newarray = new E[genericlist.Length * 2];
                for (int i = 0; i < genericlist.Length; i++)
                {
                    newarray[i] = genericlist[i];
                }
                newarray[Count] = x;
                genericlist = newarray;
                Count++;
                return;
            }

            genericlist[Count] = x;
            Count++;

        }

        public bool Remove(E item)
        {
            for(int i = 0; i < Count; i++) 
            {
                if (genericlist[i].Equals(item))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        genericlist[j] = genericlist[j + 1];
                    }
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count)
            {

                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Count - 1; i++)
            {
                genericlist[i] = genericlist[i + 1];
            }
            Count--;
            return true;
        }

        public E GetElement(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return genericlist[index];
            }
        }

        public int IndexOf(E x)
        {
            for (int i = 0; i < Count; i++)
            {
                if (x.Equals(genericlist[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            Count = 0;
            genericlist = new E[4];
        }

        public bool Contains(E item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(genericlist[i]))
                {
                    return true;
                }
            }
            return false; ;
        }

        public GenericList()
        {
            genericlist = new E[4];
        }


        public GenericList(int initalsize)
        {
            genericlist = new E[initalsize];
        }

        public IEnumerator<E> GetEnumerator()
        {
            if(typeof(E).IsValueType )
                foreach (E e in genericlist)
                {
                    if (e.Equals(0))
                    {
                        break;
                    }
                    yield return e;
                }
            else
            {
                foreach (E e in genericlist)
                {
                    if (e == null)
                    {
                        break;
                    }
                    yield return e;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
