using HW_9.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.Classes
{
    public class MyList<T>
    {
        private T[] _array = new T[0];

        public int Length
        {
            get { return _array.Length; }
            set { return; }
        } 

        public T[] getArray
        {
            get { return this._array; }
            set { this._array = value; }
        }
       
        public void AddAnElement(T elem)
        {
            if(elem != null)
            {
                ArrayPush(ref this._array, elem);
            }
        }

        public void RemoveAnElement()
        {
            T[] arrayWithoutLastElem = new T[Length - 1];

            for (int i = 0; i < arrayWithoutLastElem.Length; i++)
            {
                arrayWithoutLastElem[i] = this.getArray[i];
            }

            this.getArray = arrayWithoutLastElem;
        }

        public void RemoveAnElemenFromThePosition(int position)
        {
            int pos = position - 1;
            T[] rightPart = new T[0];
            T[] leftPart = new T[0];

            if (pos == 1)
            {
                for (int i = 1; i < this.Length; i++)
                {
                    ArrayPush(ref rightPart, this.getArray[i]);
                }
                getArray = rightPart;
            }
            else
            {
                for (int i = pos - 1; i >= 0; i--)
                {
                    if (getArray[i] != null)
                    {
                        ArrayPush(ref leftPart, getArray[i]);
                    }
                }
                for (int i = pos + 1; i < Length; i++)
                {
                    if (getArray[i] != null)
                    {
                        ArrayPush(ref rightPart, getArray[i]);
                    }
                }
                getArray = new T[0];
                foreach (var p in leftPart)
                {
                    AddAnElement(p);
                }
                foreach (var p in rightPart)
                {
                    AddAnElement(p);
                }
            }
        }

        public T[] SortByAge()
        {
            Array.Sort(_array, new AgeComparer());
            return this.getArray;
        }

        private static void ArrayPush<T>(ref T[] table, object value)
        {
            Array.Resize(ref table, table.Length + 1); // Resizing the array for the cloned length (+-) (+1)
            table.SetValue(value, table.Length - 1); // Setting the value for the new element
        }
    }
}
