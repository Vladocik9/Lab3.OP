using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_OP
{
    internal class Program
    {

        static double Сalculations(double a, double b)
        {
            double up = Math.Log(b, 5);
            double down = Math.Sqrt(Math.Cos(2 * a));
            double res = (Math.Sin(up / down) * Math.Sin(up / down));
            return Math.Round(res, 2);
        }
        static double GetToDouble(string title, double min, double max)
        {
            Double numberParsed;
            while (!(double.TryParse(title, out numberParsed)) || (numberParsed < min || numberParsed > max))
            {
                Console.WriteLine("Некорректный ввод, попробуйте снова!");
                title = Console.ReadLine();
            }
            return numberParsed;
        }
        static int GetToInt(string title, int min, int max)
        {
            int numberParsed;
            while (!(int.TryParse(title, out numberParsed)) || (numberParsed < min || numberParsed > max))
            {
                Console.WriteLine("Некорректный ввод, попробуйте снова!");
                title = Console.ReadLine();
            }
            return numberParsed;
        }
        static bool GuessTheAnswer(double rightAnswer)
        {
            int countAttempts = 3;
            while (countAttempts <= 3 && countAttempts > 0)
            {
                Console.WriteLine("Введите ответ(Осталось попыток {0}):", countAttempts);
                string strAnswer = Console.ReadLine();
                double answer = GetToDouble(strAnswer, -100, 100);
                if (answer == rightAnswer)
                {
                    Console.WriteLine("Ответ верный!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Ответ неверный");
                    Console.WriteLine();
                    countAttempts--;
                }
            }
            return false;
        }
        static int LenghtArray()
        {
            Console.WriteLine("Введите размер массива:");
            string strn = Console.ReadLine();
            int n = GetToInt(strn, 1, 10);
            return n;
        }
        static void OutputArray(int[] a)
        {
            foreach (int i in a)
                Console.Write("{0} ", i);
        }
        static int[] CreatingArray(int N)
        {
            int[] a = new int[N];
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                a[i] = rnd.Next(-10, 10);
            }
            return a;
        }
        static int GnomeSort(int a)
        {

            return 0;
        }
        static void FirstCase()
        {
            Console.WriteLine();
            Console.Write("Введите a:");
            string strA = Console.ReadLine();
            double a = GetToDouble(strA, -100, 100);
            Console.Write("Введите b:");
            string strB = Console.ReadLine();
            double b = GetToDouble(strB, -100, 100);
            double res = Сalculations(a, b);
            bool isGuessed = GuessTheAnswer(res);
            if (isGuessed == false)
            {
                Console.WriteLine("Попытки кончились!");
                Console.WriteLine("Правильный ответ:{0}", res);
            }
        }
        static void SecondCase()
        {
            Console.WriteLine();
            Console.WriteLine("Новичков Владислав Николаевич (6103-090301D)");
        }
        static void ThirdCase()
        {
            int[] a =CreatingArray(LenghtArray());
            OutputArray(a);
        }
        static bool FourthCase()
        {
            Console.WriteLine("Действительно выйти из программы?(да/нет)");
            while (true)
            {
                string confirm = Console.ReadLine();
                switch (confirm)
                {
                    case "да":
                        Console.WriteLine("Выход...");
                        return false;
                    case "нет":
                        Console.WriteLine("Не выход");
                        return true;
                    default:
                        Console.Write("Неверный ввод, попробуйте ещё раз: ");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            bool isWork = true;
            string input;
            while (isWork)
            {
                Console.WriteLine();
                Console.WriteLine("1. Отгадай ответ");
                Console.WriteLine("2. Об авторе");
                Console.WriteLine("3. Сортировка массивов");
                Console.WriteLine("4. Выход");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        FirstCase();
                        break;
                    case "2":
                        SecondCase();
                        break;
                    case "3":
                        ThirdCase();
                        break;
                    case "4":
                        isWork = FourthCase();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
    }
}