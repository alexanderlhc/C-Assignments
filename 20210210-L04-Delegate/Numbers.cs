using System;

namespace _20210210_L05_Delegate
{
  class Numbers
  {
    public delegate int Comparator(int i1, int i2);

    public Numbers()
    {
      int[] intArray = { 5, 67, 45, 23, 99, 44, 56, 12, 3, 44 };

      Comparator amIEvenSorting = (i1, i2) => 0;

      SortArray(intArray, amIEvenSorting);
      SortArray(intArray, (i1, i2) => i1.CompareTo(i2));
      SortArray(intArray, (i1, i2) => Reverse(i1, i2));

      System.Console.WriteLine("QuickSorting: ");
      int[] quickSorted = QuickSort(intArray,  (i1, i2) => i1.CompareTo(i2));
      foreach(int i in quickSorted)
      {
        System.Console.Write(i + " ");
      }
      System.Console.WriteLine();

    }

    public int Reverse(int i1, int i2)
    {
      return i2.CompareTo(i1);
    }

    public int[] QuickSort(int[] arr, Comparator comparator)
    {
      int[] newArr = new int[arr.Length];
      Array.Copy(arr, newArr, arr.Length);

      QuickSort(newArr, 0, newArr.Length-1);
      return newArr;
    }

    private void QuickSort(int[] arr, int lo, int hi)
    {
      if(lo < hi)
      {
        int index = Partition(arr, lo, hi);

        QuickSort(arr, lo, index-1);
        QuickSort(arr, index+1, hi);
      }
    }

    private int Partition(int[] arr, int lo, int hi)
    {
      int pivot = arr[hi];
      int i = lo-1;

      for (int j = lo; j < hi; j++)
      {
          if(arr[j] < pivot)
          {
            i++;
            Swap(arr, i, j);
          }
      }

      i++;

      Swap(arr, i, hi);

      return i;
    }

    private void Swap(int[] arr, int i1, int i2)
    {
      int tmp = arr[i1];
      arr[i1] = arr[i2];
      arr[i2] = tmp;
    }

    public void SortArray(int[] arr, Comparator comparer)
    {
      // Avoid modifying original array
      int[] newArr = new int[arr.Length];
      Array.Copy(arr, newArr, arr.Length);

      Array.Sort(newArr, (i1, i2) => comparer(i1, i2));


      System.Console.Write("Printing array: ");
      foreach(int i in newArr)
      {
        System.Console.Write(i + " ");
      }
      System.Console.WriteLine();
    }
  }
}
