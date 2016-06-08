using System;


namespace Lottery
{
    class Numbers
    {
        public int[] numbs;
        public int Length { get; set; }

        public Numbers(int size)
        {
            numbs = new int[size];
            Length = size;
        }
        public int this[int index]
        {
            get { return numbs[index]; }
            set { numbs[index] = value; }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Numbers userNumbers;
            Numbers cpuNumbers;
            GetNumbers(out userNumbers, out cpuNumbers, 6);

            Console.Clear();
            Result(userNumbers, cpuNumbers);

            Console.ReadLine();
        }


        static void Result(Numbers userNumbers, Numbers cpuNumbers)
        {
            int result = Check(userNumbers, cpuNumbers);
            for (int i = 0; i < userNumbers.Length; i++)
            {
                Console.WriteLine("Your number: {0}   cpuNumber: {1}", userNumbers[i], cpuNumbers[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Your result: {0}", result);
        }


        //From end to beginning
        static int Check(Numbers userNumbers, Numbers cpuNumbers)
        {
            int counter = 0;
            for (int i = userNumbers.Length - 1; i > -1; i--)
            {
                if (userNumbers[i].Equals(cpuNumbers[i]))
                    counter++;
                else break;
            }

            return counter;
        }


        static void GetNumbers(out Numbers userNumbers, out Numbers cpuNumbers, int length)
        {
            Random rand = new Random();


            userNumbers = new Numbers(length);
            cpuNumbers = new Numbers(length);
            for (int i = 0; i < length; i++)
            {
                cpuNumbers[i] = rand.Next(1, 10);
            }

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Choose the {0} number: (from 1 to 9)", i + 1);
                try
                {
                    userNumbers[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\nOnly digits");
                }
            }
        }
    }
}
