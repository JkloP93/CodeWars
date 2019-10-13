using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.Add(1)(3));
        }
    }

    static class Kata
    {
        static public int K { get; set; }

        public static Func<double, double> Add(double n) => x => n + x;
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(4, Kata.Add(1)(3));
        }
    }
    
    #region Старые

    public class TheClockwiseSpiral
    {
        private static int direction;
        public static int Direction
        {
            get => direction;
            set => direction = value % 4;
        }

        public static int[,] CreateSpiral(int N)
        {
            if (N < 1) return new int[0, 0];

            int[,] arr = new int[N, N];
            if (N == 1) { arr[0, 0] = 1; return arr; }

            int arrvalue = 1;
            int round = 0;
            int maxround = N % 2 == 0 ? maxround = N * 2 : maxround = N * 2 - 1;
            Direction = 0;
            int i = 0;
            int j = 0;
            int max = N - 1;

            while (round < maxround)
            {
                for (int cycle = 0; cycle < max && (Direction == 0 || Direction == 2);
                    j = Direction == 0 ? j + 1 : Direction == 2 ? j - 1 : j, cycle++)
                    arr[i, j] = arrvalue++;

                for (int cycle = 0; cycle < max && (Direction == 1 || Direction == 3);
                    i = Direction == 1 ? i + 1 : Direction == 3 ? i - 1 : i, cycle++)
                    arr[i, j] = arrvalue++;

                Direction++;
                round++;
                if (round % 4 == 0) { max -= 2; i += 1; j += 1; }
                if (max == 0) max = 1;
            }

            return arr;
        }
    }

    public class TheClockwiseSpiralTest
    {
        [Test]
        public void Test1()
        {
            var expected = new int[,] { { 1 } };
            Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(1));
        }
        [Test]
        public void Test2()
        {
            var expected = new int[,]
            {
            {1, 2},
            {4, 3},
            };
            Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(2));
        }
        [Test]
        public void Test3()
        {
            var expected = new int[,]
            {
            {1, 2, 3},
            {8, 9, 4},
            {7, 6, 5}
            };
            Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(3));
        }
    }

    public class Kata1
    {
        public int AvoidObstacles(int[] arr)
        {
            int k = 1;
            while (arr.Any(x => x % k == 0)) k++;
            return k;
            //int result;
            //int max = arr.Max(x => x);
            //for (int i = 1; i <= 100; i++)
            //{
            //    result = i;
            //    for (int j = 1; j <= max; j++)
            //    {
            //        if (arr.Contains(i * j)) break;
            //        if (j == max) return i;
            //    }
            //}
            //return 0;
        }

        public static string FormatWords(string[] words)
        {
            if (words == null) return string.Empty;
            var query = words.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return string.Concat(query.Select((x, i) => i == query.Length - 1 ? x : i < query.Length - 2 ? x + ", " : x + " and "));
        }
    }

    [TestFixture]
    public class myjinxin
    {

        [Test]
        public static void BasicTests()
        {
            var kata = new Kata1();

            Assert.AreEqual(4, kata.AvoidObstacles(new int[] { 5, 3, 6, 7, 9 }));

            Assert.AreEqual(4, kata.AvoidObstacles(new int[] { 2, 3 }));

            Assert.AreEqual(7, kata.AvoidObstacles(new int[] { 1, 4, 10, 6, 2 }));


        }

    }

    public class Persist
    {
        public static int Persistence(long n)
        {
            long m = 1;
            if (n < 10) return 0;
            while (n >= 10)
            {
                m *= n % 10;
                n /= 10;
            }
            return Persistence(n * m) + 1;
        }

    }

    [TestFixture]
    public class PersistTests
    {

        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests");
            Console.WriteLine(Equals(3, Persist.Persistence(39)));
            Console.WriteLine(Equals(0, Persist.Persistence(4)));
            Console.WriteLine(Equals(2, Persist.Persistence(25)));
            Console.WriteLine(Equals(4, Persist.Persistence(999)));
        }
    }

    public class JosephusSurvivor
    {
        public static int JosSurvivor(int n, int k)
        {
            //List<int> items = Enumerable.Range(1, n).ToList();
            //int i = 0;

            //while (items.Count > 1)
            //{
            //    i = (i + k - 1) % items.Count;
            //    items.RemoveAt(i);
            //}

            //return items[0];
            if (n == 1)
                return 1;
            else
                return (JosSurvivor(n - 1, k) + k - 1) % n + 1;
        }
    }

    public class Josephus
    {
        public static List<object> JosephusPermutation(List<object> items, int k)
        {
            List<object> temp = items.ToList();
            List<object> result = new List<object>(items.Capacity);
            int i = 0;

            while (temp.Count != 0)
            {
                int difference = temp.Count - i;
                if (difference < k) i = k - 1 - difference;
                else i += k - 1;
                //if (k > temp.Count) i = difference % temp.Count;
                if (k - difference - 1 >= temp.Count) i = (k - 1 - difference) % temp.Count;
                result.Add(temp[i]);
                temp.RemoveAt(i);
            }

            return result;
        }
    }

    [TestFixture]
    public static class JosephusSurvivorTests
    {

        private static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests JosSurvivor");
            testing(JosephusSurvivor.JosSurvivor(7, 3), 4);
            testing(JosephusSurvivor.JosSurvivor(11, 19), 10);
            testing(JosephusSurvivor.JosSurvivor(40, 3), 28);
            testing(JosephusSurvivor.JosSurvivor(14, 2), 13);
            testing(JosephusSurvivor.JosSurvivor(100, 1), 100);
            testing(JosephusSurvivor.JosSurvivor(1, 300), 1);
            testing(JosephusSurvivor.JosSurvivor(2, 300), 1);
            testing(JosephusSurvivor.JosSurvivor(5, 300), 1);
            testing(JosephusSurvivor.JosSurvivor(7, 300), 7);
            testing(JosephusSurvivor.JosSurvivor(300, 300), 265);
        }
    }

    public class JosephusTestSample
    {

        [Test]
        public void Test1()
        {
            JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [Test]
        public void Test2()
        {
            JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, new object[] { 2, 4, 6, 8, 10, 3, 7, 1, 9, 5 });
        }

        [Test]
        public void Test3()
        {
            JosephusTest(new object[] { "C", "o", "d", "e", "W", "a", "r", "s" }, 4, new object[] { "e", "s", "W", "o", "C", "d", "r", "a" });
        }

        [Test]
        public void Test4()
        {
            JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new object[] { 3, 6, 2, 7, 5, 1, 4 });
        }

        [Test]
        public void Test5()
        {
            JosephusTest(new object[] { }, 3, new object[] { });
        }

        public static void JosephusTest(object[] items, int k, object[] result)
        {
            Assert.AreEqual(new List<object>(result), Josephus.JosephusPermutation(new List<object>(items), k));
        }
    }
    #endregion
}
