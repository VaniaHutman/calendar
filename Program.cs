using System;

namespace calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 8;
            int y = 2020;
            DateTime your_month = new DateTime(y, m, 1);
            
            Outputting(your_month);

            Console.ReadKey();
        }

        public static void Outputting (DateTime your_month)
        {
            Console.WriteLine("Calendar");
            Console.WriteLine("{0:Y}", your_month);
            String[,] monthArr = new string[7, 7];
            monthArr[0, 0] = "Su";
            monthArr[0, 1] = "Mo";
            monthArr[0, 2] = "Tu";
            monthArr[0, 3] = "We";
            monthArr[0, 4] = "Th";
            monthArr[0, 5] = "Fr";
            monthArr[0, 6] = "Sa";

            for (int i = 1; i < monthArr.GetLength(0); i++)
            {
                for (int j = 0; j < monthArr.GetLength(1); j++)
                {
                    if (Convert.ToInt32(your_month.DayOfWeek) == j)
                    {
                        monthArr[i, j] = Convert.ToString(your_month.Day);
                        your_month = your_month.AddDays(1);
                        if (your_month.Day == 1)
                        {
                            break;
                        }
                    }
                }
                if (your_month.Day == 1)
                {
                    break;
                }
            }

            DateTime now = DateTime.Now;
            string curr = Convert.ToString(now.Day);

            for (int i = 0; i < monthArr.GetLength(0); i++)
            {
                for (int j = 0; j < monthArr.GetLength(1); j++)
                {
                    if (monthArr[i, j] == curr)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0,3}", monthArr[i, j]);
                    }
                    else if (j == 6 || j == 0)
                    {   
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0,3}", monthArr[i, j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0,3}", monthArr[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
