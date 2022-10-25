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

            //char[,] obrazek = ZiskatObrazek();
            //PoziceKurzoru kurzor = new PoziceKurzoru() { X = 0, Y = 0};

            //bool konec;
            //do
            //{
                //VykresleniObrazku(obrazek);
                //VykresleniKurzoru(kurzor);

                //ConsoleKeyInfo novaKlavesa = Console.ReadKey();

                //VlivOvladaniNaObrazek(novaKlavesa, obrazek);
                //kurzor = VlivOvladaniNaKurzor(novaKlavesa);
                //konec = ZnaciKonec(novaKlavesa);
            //} while (!konec);

            
            UlozeniObrazku();
            NacteniObrazku();
            Rozlouceni();
        }

        static void UlozeniObrazku()
        {
            string[] obsahSouboru = new string[2] {
                "slovooo",
                "slovo  ",
            }; 
            Console.Write("Zapište název obrázku: ");
            string jmenoObrazku = Console.ReadLine();
            string priponaObrazku = ".txt";
            string celeJmenoObrazku = jmenoObrazku + priponaObrazku;
            Console.WriteLine(celeJmenoObrazku);
            File.WriteAllLines("obrazky\\" + celeJmenoObrazku, obsahSouboru);
        }

        static char[,] NacteniObrazku()
        {
            char[,] obrazek;

            Console.Write("Zadejte jméno obrázku: ");
            string jmenoObrazku = Console.ReadLine();

            string priponaObrazku = ".txt";
            string celeJmenoObrazku = jmenoObrazku + priponaObrazku;
            string[] radkySouboru = File.ReadAllLines("obrazky\\" + celeJmenoObrazku);

            int sirkaObrazku = radkySouboru[0].Length;
            int vyskaObrazku = radkySouboru.Length;

            obrazek = new char[vyskaObrazku, sirkaObrazku];

            for(int y = 0; y < radkySouboru.GetLength(0); y++)
            {
                char[] obsahVeStringu = radkySouboru[y].ToCharArray();

                for (int x = 0; x < radkySouboru.GetLength(1); x++)
                {

                    obrazek[y, x] = obsahVeStringu[x];
                }
                
            }


            /*foreach (string text in obsahSouboru)
            {
                Console.WriteLine(text);
            }*/

            return obrazek;
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
