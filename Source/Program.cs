namespace Malovani
{
    internal class Program
    {
        struct PoziceKurzoru
        {
            public int X;
            public int Y;
        }

        static void Main(string[] args)
        {

            NastaveniBarev();
            Uvod();

            char[,] obrazek = ZiskatObrazek();
            //char[,] obrazek = new char[2, 4] { { 'A', 'H', 'O', 'J' }, { 'J', 'O', 'H', 'A' } };
            PoziceKurzoru kurzor = new PoziceKurzoru() { X = 3, Y = 1 };



            bool konec;
            do
            {
                Vykresleni(kurzor, obrazek);

                ConsoleKeyInfo novaKlavesa = Console.ReadKey();

                VlivOvladaniNaObrazek(novaKlavesa, obrazek);
                kurzor = VlivOvladaniNaKurzor(novaKlavesa);
                konec = ZnaciKonec(novaKlavesa);
            } while (!konec);

            UlozeniObrazku(obrazek);
            Rozlouceni();
        }

        static void UlozeniObrazku(char[,] obrazek)
        {
            throw new NotImplementedException();
        }

        static bool ZnaciKonec(ConsoleKeyInfo novaKlavesa)
        {
            throw new NotImplementedException();
        }

        static void VlivOvladaniNaObrazek(ConsoleKeyInfo novaKlavesa, char[,] obrazek)
        {
            throw new NotImplementedException();
        }

        static PoziceKurzoru VlivOvladaniNaKurzor(ConsoleKeyInfo novaKlavesa)
        {
            throw new NotImplementedException();
        }

        static void Vykresleni(PoziceKurzoru kurzor, char[,] obrazek)
        {
            int prevY = 0;

            for(int y = 0; y < obrazek.GetLength(0); y++)
            {
                for (int x = 0; x < obrazek.GetLength(1); x++)
                {
                    if (prevY != y)
                        Console.WriteLine("");
                        prevY = y;

                    if (kurzor.Y == y && kurzor.X == x)
                    {
                        Console.SetCursorPosition(kurzor.X, kurzor.Y);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(obrazek[y, x]);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else Console.Write(obrazek[y, x]);
                }
            }
        }

        static char[,] ZiskatObrazek()
        {
            throw new NotImplementedException();
        }

        static void NastaveniBarev()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }

        static void Uvod()
        {
            Console.Clear();
            Console.WriteLine("ASCII Malování");
            Console.WriteLine("--------------");
            Console.WriteLine();

            Console.WriteLine("Pro spuštění stiskněte libovolnou klávesu...");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.Clear();
        }

        static void Rozlouceni()
        {
            Console.Clear();
            Console.WriteLine("Děkujeme za použití naší aplikace!");
            Console.WriteLine();

            Console.WriteLine("Pro ukončení stiskněte libovolnou klávesu...");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.Clear();
        }
    }
}
