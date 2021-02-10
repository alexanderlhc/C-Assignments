

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
        public bool AddElement(int k, int e)
        {
            throw new System.NotImplementedException();
        }

        public int GetElement(int k)
        {
            throw new System.NotImplementedException();
        }

        public int Size()
        {
            throw new System.NotImplementedException();
        }
    }

}
