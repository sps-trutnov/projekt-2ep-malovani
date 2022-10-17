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

            char[,] obrazek = new char[2, 2] { { 'A', 'H' }, { 'O', ' ' } };
            PoziceKurzoru kurzor = new PoziceKurzoru() { X = 1, Y = 1 };

            VykresleniKurzoru(kurzor, obrazek);
            //char[,] obrazek = ZiskatObrazek();


            bool konec;
            do
            {
                VykresleniObrazku(obrazek);
                //VykresleniKurzoru(kurzor);

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

        static void VykresleniKurzoru(PoziceKurzoru kurzor, char[,] obrazek)
        {
            for(int x = 0; x < obrazek.GetLength(0); x++) // souřadnice Y
            {
                for (int y = 0; y < obrazek.GetLength(1); y++) // souřadnice X
                {

                    if (kurzor.X == x && kurzor.Y == y)
                    {
                        Console.SetCursorPosition(kurzor.Y, kurzor.X);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(obrazek[x, y]);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
            }
        }

        static void VykresleniObrazku(char[,] obrazek)
        {
            throw new NotImplementedException();
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
