using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.SystemControl.Policy.Auth
{
    public class Actions : System.Collections.CollectionBase
    {
        public string this[int index]
        {
            get { return (string)List[index]; }
            set { List[index] = value; }
        }

        public int Add(string value)
        {
            return List.Add(value);
        }

        public bool Contains(string value)
        {
            return List.Contains(value);
        }

        public void CopyTo(string[] array, int index)
        {
            List.CopyTo(array, index);
        }

        public int IndexOf(string value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, string value)
        {
            List.Insert(index, value);
        }

        public void Remove(string value)
        {
            List.Remove(value);
        }
    }
}
