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

            NacteniObrazku();
            UlozeniObrazku();
        }

        static void UlozeniObrazku()
        {
            string[] obsahSouboru = new string[2] { "slovo", "slovo" }; 
            Console.Write("Zapište název obrázku: ");
            string jmenoObrazku = Console.ReadLine();
            string priponaObrazku = ".txt";
            string celeJmenoObrazku = jmenoObrazku + priponaObrazku;
            Console.WriteLine(celeJmenoObrazku);
            File.WriteAllLines("obrazky\\" + celeJmenoObrazku, obsahSouboru);
        }

        static void NacteniObrazku()
        {
            Console.Write("Zadejte jméno obrázku: ");
            string jmenoObrazku = Console.ReadLine();
            string priponaObrazku = ".txt";
            string celeJmenoObrazku = jmenoObrazku + priponaObrazku;
            string[] obsahSouboru = File.ReadAllLines("obrazky\\" + celeJmenoObrazku);
            foreach (string text in obsahSouboru)
            {
                Console.WriteLine(text);
            }
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

        static void VykresleniKurzoru(PoziceKurzoru kurzor)
        {
            throw new NotImplementedException();
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
