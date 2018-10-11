using System;

namespace DynamicConnectivity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class QuickUnionUF
        {
            private int[] id;
            private int[] sz;

            //constructor that creates an array the size of input and assigns index number as its values
            public QuickUnionUF(int N)
            {
                id = new int[N];
                sz = new int[N];
                for (int i = 0; i < N; i++)
                {
                    id[i] = i;
                    sz[i] = 1;
                }
            }

            //Finds the root of the given index
            private int Root(int i)
            {
                //The .Next in an array form
                while (i != id[i])
                {
                    id[i] = id[id[i]]; //Path Compression
                    i = id[i];
                }
                return i;
            }

            //returns bool if the two given obj is connected
            public Boolean Connected(int x, int y)
            {
                if (Root(x) == Root(y))
                {
                    return true;
                }
                return false;
            }

            //Weighted Connecting of two nodes. With proper size manipulation only on the root
            public void Union(int x, int y)
            {
                int i = Root(x);
                int j = Root(y);
                //If the root is the same, nothing needs to be done.
                if (i == j){ return; }
                //If j is a bigger tree then...
                if (sz[i] < sz[j])
                {
                    //i is going to point to j
                    id[i] = j;
                    //size of j is gonna increase by the size of i
                    sz[j] += sz[i];
                }
                else
                {
                    id[j] = i;
                    sz[i] += sz[j];
                }
            }
        }
    }
}
