// 1

using System.Collections;

namespace Lab005
{
    class MyMatrix
    {
        private int n;
        private int m;
        readonly double[,] matrix;
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }
        public int M
        {
            get { return m; }
            set { if (value > 0) m = value; }
        }
        public MyMatrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            matrix = new double[this.m, this.n];
        }
        public MyMatrix(int m, int n, int a, int b)
        {
            this.m = m;
            this.n = n;
            matrix = new double[this.m, this.n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Random r = new();
                    matrix[i, j] = r.Next(a, b + 1);
                }
            }
        }
        public MyMatrix Fill(int a, int b)
        {
            return new MyMatrix(m, n, a, b);
        }
        public MyMatrix ChangeSize(int m0, int n0, int a, int b)
        {
            MyMatrix matr = new(m0, n0);
            for (int i = 0; i < m0; i++)
            {
                if (i < m)
                    for (int j = 0; j < n0; j++)
                    {
                        if (j < n)
                            matr.matrix[i, j] = this.matrix[i, j];
                        else
                        {
                            Random r = new();
                            matr[i, j] = r.Next(a, b + 1);
                        }
                    }
                else
                    for (int j = 0; j < n0; j++)
                    {
                        Random r = new();
                        matr[i, j] = r.Next(a, b + 1);
                    }
            }
            return matr;
        }
        public void ShowPartialy(int begM, int begN, int endM, int endN)
        {
            for (int i = begM; i < endM; i++)
            {
                for (int j = begN; j < endN; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void Show()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public double this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                matrix[i, j] = value;
            }
        }
    }

    // 2

    class MyList<T>
    {
        T[] items;
        int size;
        public MyList(T[] items)
        {
            this.items = items;
            size = items.Length;
        }
        public void Add(T item)
        {
            T[] array = items;
            int length = size;
            if ((uint)length >= (uint)array.Length)
            {
                size = length + 1;
                Array.Resize(ref items, size);
            }
            items[size - 1] = item;
        }
        public T this[int i]
        {
            get
            {
                return items[i];
            }
            set
            {
                items[i] = value;
            }
        }
        public int Size
        {
            get { return items.Length; }
        }
        public void Show()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine("list[" + i + "] = " + items[i]);
            }
        }
    }

    // 3

    public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private TKey[] keys;
        private TValue[] values;
        public MyDictionary(KeyValuePair<TKey, TValue>[] pairs)
        {
            Array.Resize(ref keys, pairs.Length);
            for (int i = 0; i < pairs.Length; i++)
                keys[i] = pairs[i].Key;
            Array.Resize(ref values, pairs.Length);
            for (int i = 0; i < pairs.Length; i++)
                values[i] = pairs[i].Value;
        }
        public void Add(TKey key, TValue value)
        {
            Array.Resize(ref keys, keys.Length + 1);
            keys[^1] = key;
            Array.Resize(ref values, values.Length + 1);
            values[^1] = value;
        }
        public TValue this[TKey key]
        {
            get
            {
                int ind = 0;
                for (int i = 0; i < keys.Length; i++)
                {
                    if (key != null)
                        if (key.Equals(keys[i]))
                            ind = i;
                }
                return values[ind];
            }
        }
        public int Size
        {
            get
            {
                return values.Length;
            }
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < keys.Length; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    class Program
    {
        static void Main()
        {
            // 1

            Console.WriteLine("Task 1");

            Console.WriteLine("Введите левую границу диапазона значений элементов матриц");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите правую границу диапазона значений элементов матриц");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите m");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите n");
            int n = Convert.ToInt32(Console.ReadLine());

            MyMatrix matr1 = new(m, n, a, b);
            Console.WriteLine("matr1:");
            matr1.Show();

            MyMatrix matr2 = matr1.Fill(a, b);
            Console.WriteLine("matr2 = matr1.Fill():");
            matr2.Show();

            Console.WriteLine("Введите с какой строки начинать выводить");
            int begM = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите до какой строки выводить");
            int endM = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите с какого столбца начинать выводить");
            int begN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите до какого столбца выводить");
            int endN = Convert.ToInt32(Console.ReadLine());

            matr2.ShowPartialy(begM, begN, endM, endN);

            Console.WriteLine("Введите новое количество строк:");
            int begin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новое количество столбов:");
            int end = Convert.ToInt32(Console.ReadLine());

            MyMatrix matr3 = matr2.ChangeSize(begin, end, a, b);
            matr3.Show();

            // 2

            Console.WriteLine("\nTask 2");

            string s1 = "1.1";
            string s2 = "1.2";
            string s3 = "1.3";
            string[] items = { s1, s2, s3 };
            MyList<string> list = new(items);
            list.Show();
            Console.WriteLine();
            list.Add("2.1");
            list.Show();
            Console.WriteLine("\nlist[2] = " + list[2]);
            Console.WriteLine("\nlist.Size = " + list.Size);


            // 3

            Console.WriteLine("\nTask 3");
            KeyValuePair<int, string>[] pairs = new KeyValuePair<int, string>[1];
            pairs[0] = new KeyValuePair<int, string>(100, "James");
            MyDictionary<int, string> people = new(pairs)
        {
            { 3, "Tom" },
            { 7, "Mary" },
            { 2, "Sam" }
        };
            foreach (var person in people)
            {
                Console.WriteLine("key = " + person.Key + " value = " + person.Value);
            }
            people.Add(10, "Ann");
            Console.WriteLine("\nkey = 10 value = " + people[10]);
            Console.WriteLine("\npeople.Size = " + people.Size);
            foreach (var person in people)
            {
                Console.WriteLine("key = " + person.Key + " value = " + person.Value);
            }
        }
    }
}