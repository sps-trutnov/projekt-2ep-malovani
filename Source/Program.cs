using System.ComponentModel;
using System.Security.Cryptography;
using System.Transactions;

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

            char[,] obrazek;// = ZiskatObrazek();
            PoziceKurzoru kurzor = new PoziceKurzoru() { X = 0, Y = 0 };
            char[] Blacklist; //seznam nefunkčních kláves
            Blacklist = new char[2] { 'f', (char)14};//nebere to \n (14 není \n)

            //dočasné rešení
            obrazek = new char[,] { {'o','o'}, {'o','o'} };

            bool konec = false;
            do
            {
                //VykresleniObrazku(obrazek);
                //VykresleniKurzoru(kurzor); aby to běželo

                ConsoleKeyInfo novaKlavesa = Console.ReadKey();

                VlivOvladaniNaObrazek(novaKlavesa, obrazek, Blacklist, kurzor);
                //kurzor = VlivOvladaniNaKurzor(novaKlavesa);
                //konec = ZnaciKonec(novaKlavesa); rovněž aby ro  to běžlo
                for (int x = 0; x < obrazek.GetLength(0); x++)
                {
                    for(int y = 0; y < obrazek.GetLength(1); y++)
                    {
                        Console.Write(obrazek[x,y]);// je to nehezké => nejdřív x, pak y
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
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

        static void VlivOvladaniNaObrazek(ConsoleKeyInfo novaKlavesa, char[,] obrazek, char[] Blacklist, PoziceKurzoru kurzor)
        {
            if (!Blacklist.Contains(novaKlavesa.KeyChar))
            {
                Console.Write("something");
                switch (novaKlavesa.KeyChar)
                {
                    case (char)13:
                        Console.Write(" -- enter -- ");
                        break;
                    default:
                        obrazek[kurzor.X, kurzor.Y] = novaKlavesa.KeyChar;
                        break;
                }
            }
            Console.WriteLine(" -- "+novaKlavesa.KeyChar);
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
