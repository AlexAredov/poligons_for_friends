using System;

namespace Практика6
{
    
    class Program
    {
        delegate void hello();
        static void Main(string[] args)
        {
            hello hel;
            hel = Hello.Hello_English;
            hel();
            hel = Hello.Hello_French;
            hel();
            hel = Hello.Hello_German;
            hel();
            hel = Hello.Hello_Italian;
            hel();
            hel = Hello.Hello_Russian;
            hel();
        }
    }

    static class Hello
    {
        public static void Hello_Russian()
        {
            Console.WriteLine("Привет!");
        }
        public static void Hello_English()
        {
            Console.WriteLine("Hello!");
        }
        public static void Hello_German()
        {
            Console.WriteLine("Hallo!");
        }
        public static void Hello_Italian()
        {
            Console.WriteLine("Ciao!");
        }
        public static void Hello_French()
        {
            Console.WriteLine("Bonjour!");
        }
    }
}
