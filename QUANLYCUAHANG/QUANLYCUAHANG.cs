using System;

namespace QUANLYCUAHANG
{
    class Program
    {
        static void Main(string[] args)
        {
            input();
        }
        public static void input()
        {
            Console.WriteLine("WELCOME");
            Console.WriteLine("Please select the function");
            bool check = true;
            int selectFuntion = 0;
            while (check)
            {
                Console.WriteLine("1. Function of Items");
                Console.WriteLine("2. Function of Type of Items");
                selectFuntion = Convert.ToInt32(Console.ReadLine());
                if (selectFuntion == 1 || selectFuntion == 2)
                {
                    check = false;
                }
                else Console.WriteLine("Please select again");
            }
            if (selectFuntion == 1)
            {
                check = true;
                while (check)
                {
                    Console.WriteLine("Please select: ");
                    Console.WriteLine("1. Add the item");
                    Console.WriteLine("2. Remove the item");
                    Console.WriteLine("3. Edit the item");
                    Console.WriteLine("4. Search the item");
                    int selectItems = Convert.ToInt32(Console.ReadLine());
                    if (selectItems > 4 || selectItems < 0)
                    {
                        check = false;
                    }
                    else Console.WriteLine("Please select again");
                }
            }
            else if (selectFuntion == 2)
            {
                check = true;
                while (check)
                {
                    Console.WriteLine("Please select: ");
                    Console.WriteLine("1. Add the type of item");
                    Console.WriteLine("2. Remove the type of item");
                    Console.WriteLine("3. Edit the type of item");
                    Console.WriteLine("4. Search the type of item");
                    int selectTypeOfItems = Convert.ToInt32(Console.ReadLine());
                    if (selectTypeOfItems > 4 || selectTypeOfItems < 0)
                    {
                        check = false;
                    }
                    else Console.WriteLine("Please select again");
                }
            }
        }
    }
}
