
using System;

namespace Практика6_2
{
    class Program
    {
        public delegate int Op(int x, int y);
        static void Main(string[] args)
        {
            Op sum = (int x, int y) => x + y;
            Op mul = (int x, int y) => x * y;
            Op div = (int x, int y) => x / y;
            int x = int.Parse(Console.ReadLine()), y = int.Parse(Console.ReadLine());
            int s = sum(x, y);
            int m = mul(x, y);
            int d = div(x, y);
            Console.WriteLine($"Сумма: {s}, Произведение: {m}, Частное {d}");
        }
    }
}
