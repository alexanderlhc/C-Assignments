

using System.Collections.Generic;

namespace _20210208_L03_Generic
{
    interface ICollectionBogu<Key, Element>
    {

      bool AddElement(Key k, Element e);
      Element GetElement(Key k);
      int Size();
    }

    public class BoguCollection : ICollectionBogu<int, int>
    {
        private Dictionary<int, int> data;

        public BoguCollection()
        {
          data = new Dictionary<int,int>();
        }

        public bool AddElement(int k, int e)
        {
          return data.TryAdd(k, e);
        }

        public int GetElement(int k)
        {
          return data[k];
        }

        public int Size()
        {
          return data.Count;
        }
    }

}
