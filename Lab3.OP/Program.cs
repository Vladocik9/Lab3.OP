using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
		static double GetToDouble(double min, double max)
		{
            string title = Console.ReadLine();
            Double numberParsed;
			while (!(double.TryParse(title, out numberParsed)) || (numberParsed < min || numberParsed > max))
			{
				Console.WriteLine("Некорректный ввод, попробуйте снова!");
				title = Console.ReadLine();
			}
			return numberParsed;
		}
		static int GetToInt(int min, int max)
		{
			string title = Console.ReadLine();
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
				double answer = GetToDouble( -100, 100);
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
			int n = GetToInt(1, 1000000000);
			return n;
		}
		static void OutputArray(int[] a)
		{
			if (a.Length <= 10)
			{
				Console.WriteLine("Массив");
				foreach (int i in a)
					Console.Write("{0} ", i);
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Нельзя вывести, так как длина массива больше 10.");
			}
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
		static int[] CloneArray(int[] a)
		{
			int[] b = new int[a.Length];
			for (int i = 0;i < a.Length; i++)
			{
				b[i] = a[i];
			}
			return b;
		}
		static void InsertsSort(int[] a)
		{
			int index;
			int curNumber;
			for (int i = 0;i < a.Length; i++)
			{
				index = i;
				curNumber = a[i];
				while (index > 0 && curNumber < a[index - 1])
				{
					a[index] = a[index - 1];
					index--;
				}
				a[index] = curNumber;
			}
		}
		static void GnomeSort(int[] a)
		{
			int index = 1;
			int lastIndex = index + 1;
			int swap;
			while (index < a.Length)
			{
				if (a[index - 1] < a[index])
				{
					index = lastIndex;
					lastIndex++;
				}
				else
				{
					swap = a[index - 1];
					a[index - 1] = a[index];
					a[index] = swap;
					index--;
					if (index == 0)
					{
						index = lastIndex;
						lastIndex++;
					}
				}
			}
		}
		static void FirstCase()
		{
			Console.WriteLine();
			Console.Write("Введите a:");
			double a = GetToDouble(-100, 100);
			Console.Write("Введите b:");
			double b = GetToDouble(-100, 100);
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
			int[] a = CreatingArray(LenghtArray());
			int[] b = CloneArray(a);
			Console.WriteLine("Исходный массив");
			OutputArray(a);
			Console.WriteLine("Гномья сортировка:");
			Stopwatch stopwatch = Stopwatch.StartNew();
			GnomeSort(a);
			Console.WriteLine(stopwatch.Elapsed.ToString());
			OutputArray(a);
			Console.WriteLine("Сортировка вставками");
			Stopwatch stopwatch2 = Stopwatch.StartNew();
			InsertsSort(b);
			Console.WriteLine(stopwatch2.Elapsed.ToString());
			OutputArray(b);
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
				Console.WriteLine("\n1. Отгадай ответ");
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
						Console.WriteLine("Неправильный ввод");
						break;
				}
			}
		}
	}
}