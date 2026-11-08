using System;
using System.Text;

namespace ArrayAlgosProject
{
    public static class ArrayAlgos
    {
        public static bool IsSorted(int[] a)
        {
            if (a == null || a.Length < 2) return true;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i - 1] > a[i]) return false;
            }
            return true;
        }

        public static int BubbleSort(int[] a)
        {
            if (a == null || a.Length < 2) return 0;
            int comps = 0;

            for (int pass = 0; pass < a.Length - 1; pass++)
            {
                bool changed = false;
                for (int j = 0; j < a.Length - 1 - pass; j++)
                {
                    comps++;
                    if (a[j] > a[j + 1])
                    {
                        (a[j], a[j + 1]) = (a[j + 1], a[j]);
                        changed = true;
                    }
                }
                if (!changed) break;
            }
            return comps;
        }

        public static int CountOccurrences(int[] sortedA, int x)
        {
            if (sortedA == null || sortedA.Length == 0) return 0;
            return FirstGreater(sortedA, x) - FirstGreaterOrEqual(sortedA, x);
        }

        private static int FirstGreaterOrEqual(int[] a, int x)
        {
            int l = 0, r = a.Length;
            while (l < r)
            {
                int m = l + (r - l) / 2;
                if (a[m] >= x) r = m;
                else l = m + 1;
            }
            return l;
        }

        private static int FirstGreater(int[] a, int x)
        {
            int l = 0, r = a.Length;
            while (l < r)
            {
                int m = l + (r - l) / 2;
                if (a[m] > x) r = m;
                else l = m + 1;
            }
            return l;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Выполнил: Давлетьяров Тимур\n");

            Console.WriteLine("--- Проверка BubbleSort ---");
            RunBubble(new int[] { });
            RunBubble(new int[] { 5 });
            RunBubble(new int[] { 1, 2, 3, 4, 5 });
            RunBubble(new int[] { 5, 4, 3, 2, 1 });
            RunBubble(new int[] { 3, 1, 3, 2, 3 });

            int[] big = new int[1000];
            for (int i = 0; i < 1000; i++) big[i] = i;
            int bigComps = ArrayAlgos.BubbleSort(big);
            Console.WriteLine($"1000 элементов (отсортирован): IsSorted={ArrayAlgos.IsSorted(big)}, Сравнений={bigComps} (ожидалось 999) | {(bigComps == 999 ? "OK" : "FAIL")}");

            Console.WriteLine("\n--- Проверка CountOccurrences ---");
            int[] sample = { 1, 2, 2, 2, 5, 7 };
            RunCount(sample, 2, 3);
            RunCount(sample, 1, 1);
            RunCount(sample, 7, 1);
            RunCount(sample, 3, 0);
            RunCount(sample, 9, 0);
        }

        static void RunBubble(int[] arr)
        {
            string sBefore = ToStr(arr);
            int c = ArrayAlgos.BubbleSort(arr);
            string sAfter = ToStr(arr);
            bool sorted = ArrayAlgos.IsSorted(arr);
            Console.WriteLine($"До: {sBefore} -> После: {sAfter} | IsSorted: {sorted} | Сравнений: {c} | {(sorted ? "OK" : "FAIL")}");
        }

        static void RunCount(int[] arr, int x, int exp)
        {
            int act = ArrayAlgos.CountOccurrences(arr, x);
            Console.WriteLine($"Ищем x={x}: Ожидалось={exp}, Факт={act} | {(act == exp ? "OK" : "FAIL")}");
        }

        static string ToStr(int[] a)
        {
            if (a.Length == 0) return "{}";
            return "{" + string.Join(", ", a) + "}";
        }
    }
}
