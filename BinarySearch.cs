using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = 2;

            int m = 4;
            int n = 5;
            int[] res = new int[2];
            //string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = { 1, 4, 5, 3, 2 };
            int [] b = Merge(a, 0, n - 1);
            for (int i = 0; i <= m; i++) {
                int ser = m - i;
                int r = BinarySearch(i, m, b, ser);
                if (r != 0) {
                    res[0] = i;
                    res[1] = r;
                    Console.WriteLine(res[0]);
                    Console.WriteLine(res[1]);
                    Console.ReadLine();
                    break;
                }  
            }
        }
        public static int[] Merge(int[] array, int start, int end)
        {
            if (start == end)
            {
                return null;
            }
            int mid = (start + end) / 2;
            Merge(array, start, mid);
            Merge(array, mid + 1, end);
            Sort(array, start, end);
            return Sort(array, start, end); 
        }
        public static int[] Sort(int[] array, int start, int end)
        {
            long count = 0;
            int mid = (start + end) / 2;
            int[] newArray = new int[end - start + 1];
            int i = start;
            int j = mid + 1;
            int marker = 0;
            while (i <= mid && j <= end)
            {
                if (array[i] > array[j])
                {
                    newArray[marker++] = array[j++];
                    count += mid - i + 1;
                }
                else
                {
                    newArray[marker++] = array[i++];
                }
            }
            while (i <= mid)
            {
                newArray[marker++] = array[i++];
            }

            while (j <= end)
            {
                newArray[marker++] = array[j++];
            }
            System.Array.Copy(newArray, 0, array, start, end - start + 1);
            return newArray;
        }
        public static int BinarySearch(int first, int last, int[] array, int searchElem)
        {
            if (first >= last)
                return first;
            int mid = first + (last - first) / 2;
            if (mid == searchElem)
                return mid;
            else if (mid < searchElem)
                return BinarySearch(mid + 1, last, array, searchElem);
            else return BinarySearch(first, mid - 1, array, searchElem);
    }
    }
}
