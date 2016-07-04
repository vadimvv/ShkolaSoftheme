using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            var lookup = new Dictionary<int, string>();

            while (true)
            {
                var s = RandomString();
                var h = s.GetHashCode();
                string s2;
                if (lookup.TryGetValue(h, out s2) && s2 != s)
                {
                    Console.WriteLine("Result:\n{0} and {1} hash code {2}",lookup[h],s,h);
                    break;
                }
                lookup[h] = s;
            }


            Console.ReadLine();
        }

        static Random r = new Random();
        static string RandomString()
        {

            var s = ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString() +
                    ((char)r.Next((int)'a', ((int)'z') + 1)).ToString();

            return s;
        }
    }
}
