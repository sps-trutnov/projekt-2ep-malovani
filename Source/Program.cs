namespace Malovani {
    internal class Program {
        struct PoziceKurzoru {
            public int X;
            public int Y;
        }

        static void Main(string[] args) {
            NastaveniBarev();
            Uvod();

            char[,] obrazek = ZiskatObrazek();
            PoziceKurzoru poziceMax = new PoziceKurzoru() { X = obrazek.GetLength(0), Y = obrazek.GetLength(1)};
            PoziceKurzoru kurzor = new PoziceKurzoru() { X = 0, Y = 0 };

            bool konec;
            do {
                VykresleniObrazku(obrazek);
                VykresleniKurzoru(kurzor);

                ConsoleKeyInfo novaKlavesa = Console.ReadKey();

                VlivOvladaniNaObrazek(novaKlavesa, obrazek);
                kurzor = VlivOvladaniNaKurzor(novaKlavesa, kurzor, poziceMax);
                konec = ZnaciKonec(novaKlavesa);
            } while (!konec);

            UlozeniObrazku(obrazek);
            Rozlouceni();
        }

        static void UlozeniObrazku(char[,] obrazek) {
            throw new NotImplementedException();
        }

        static bool ZnaciKonec(ConsoleKeyInfo novaKlavesa) {
            throw new NotImplementedException();
        }

        static void VlivOvladaniNaObrazek(ConsoleKeyInfo novaKlavesa, char[,] obrazek) {
            throw new NotImplementedException();
        }

        static PoziceKurzoru VlivOvladaniNaKurzor(ConsoleKeyInfo novaKlavesa, PoziceKurzoru kurzor, PoziceKurzoru max) {
            if ((novaKlavesa.Key == ConsoleKey.LeftArrow) && kurzor.X < max.X) {
                kurzor.X = kurzor.X + 1;
            } else if ((novaKlavesa.Key == ConsoleKey.RightArrow) && kurzor.X > 0) {
                kurzor.X = kurzor.X - 1;
            } else if ((novaKlavesa.Key == ConsoleKey.UpArrow) && kurzor.Y > 0) {
                kurzor.Y = kurzor.Y - 1;
            } else if ((novaKlavesa.Key == ConsoleKey.DownArrow) && kurzor.Y > max.Y) {
                kurzor.Y = kurzor.Y + 1;
            } return kurzor;
        }

        static void VykresleniKurzoru(PoziceKurzoru kurzor) {
            throw new NotImplementedException();
        }

        static void VykresleniObrazku(char[,] obrazek) {
            throw new NotImplementedException();
        }

        static char[,] ZiskatObrazek() {
            throw new NotImplementedException();
        }

        static void NastaveniBarev() {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }

        static void Uvod() {
            Console.Clear();
            Console.WriteLine("ASCII Malování");
            Console.WriteLine("--------------");
            Console.WriteLine();

            Console.WriteLine("Pro spuštění stiskněte libovolnou klávesu...");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.Clear();
        }

        static void Rozlouceni() {
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
