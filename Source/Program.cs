using System.Diagnostics;

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
            Console.Clear();
            //char[,] obrazek = new char[2, 5] { { 'A', 'H', 'O', 'J', '!' }, { '!', 'J', 'O', 'H', 'A' } };
            Random nahoda = new Random();
            char[,] obrazek = new char[10, 10];
            for (int y = 0; y < obrazek.GetLength(0); y++)
                for (int x = 0; x < obrazek.GetLength(1); x++)
                    obrazek[y, x] = (char)nahoda.Next(42, 127);

            PoziceKurzoru kurzor = new PoziceKurzoru() { X = 2, Y = 0 };



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
            Console.SetCursorPosition(0, 0);
            int prevY = -1;

            for (int y = 0; y < obrazek.GetLength(0); y++)
            {
                for (int x = 0; x < obrazek.GetLength(1); x++)
                {
                    if (prevY != y)
                    {
                        Console.WriteLine("");
                        prevY = y;
                    }
                        

                    if (kurzor.Y == y && kurzor.X == x)
                    {
                        Ohraniceni(x, y, obrazek, true);
                        if (obrazek.GetLength(0) > 28 || obrazek.GetLength(1) > 118)
                            if (obrazek.GetLength(0) >= 28)
                                Console.SetCursorPosition(0, kurzor.Y + 1);
                            if (obrazek.GetLength(1) >= 118)
                                Console.SetCursorPosition(kurzor.X + 2, 0);
                        else if (obrazek.GetLength(0) <= 28 || obrazek.GetLength(1) <= 118)
                            if (obrazek.GetLength(0) <= 28)
                                Console.SetCursorPosition(0, kurzor.Y + 1);
                            if (obrazek.GetLength(1) <= 118)
                                Console.SetCursorPosition(kurzor.X + 2, Console.GetCursorPosition().Top);
                        //Console.SetCursorPosition(kurzor.X+2, kurzor.Y+1);

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(obrazek[y, x]);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Ohraniceni(x, y, obrazek, false);
                    }
                }
            }

            if (obrazek.GetLength(0) <= 28)
            {
                int offset;
                if (120 - obrazek.GetLength(1) <= 4 && 120 - obrazek.GetLength(1) >= 0)
                {
                    offset = 120 - obrazek.GetLength(1);
                }
                else
                    offset = 4;
                    Debug.WriteLine(offset);


                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.Gray;
                for (int x = 0; x < obrazek.GetLength(1) + offset; x++)
                {
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.White;
            }

            if (obrazek.GetLength(0) <= 29)
            {
                int offset;
                if (120 - obrazek.GetLength(1) <= 4 && 120 - obrazek.GetLength(1) >= 0)
                {
                    offset = 120 - obrazek.GetLength(1);
                }
                else
                    offset = 4;

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(0, obrazek.GetLength(0)+1);
                for (int x = 0; x < obrazek.GetLength(1) + offset; x++)
                {
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.White;
            }
        }

        static void Ohraniceni(int x, int y, char[,] obrazek, bool kurzor = false)
        {
            if (!kurzor)
            {
                if (x == 0)
                {
                    if (obrazek.GetLength(1) <= 118)
                        OhraniceniVykresleni();
                    Console.Write(obrazek[y, x]);
                }
                else if (x == obrazek.GetLength(1)-1)
                {
                    Console.Write(obrazek[y, x]);
                    if (obrazek.GetLength(1) <= 119)
                        OhraniceniVykresleni();
                }
                else
                {
                    Console.Write(obrazek[y, x]);
                }
            }
            else
            {
                if (x == 0)
                    if (obrazek.GetLength(1) <= 118)
                        OhraniceniVykresleni();
                if (x == obrazek.GetLength(1))
                    if (obrazek.GetLength(1) <= 119)
                        OhraniceniVykresleni();
            }
        }

        static void OhraniceniVykresleni()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.White;
        }

        static char[,] ZiskatObrazek()
        {
            Console.WriteLine("Napište číslo funkce, kterou chcete zvolit.");
            Console.WriteLine("1) Tvorba nového obrázku.");
            Console.WriteLine("2) Otevření existujícího obrázku.");
            Console.WriteLine("3) Ukončení aplikace.");
            Console.WriteLine("");

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.NumPad1)
            {
               // Defaultni rozmery console 120 x 30 znaku
               Console.WriteLine("Maximální šířka obrázku je 30");
               Console.WriteLine("Zde zadejte šířku obrázku: ");
               // získání šířky
               string input_width = Console.ReadLine();
               int width = Convert.ToInt32(input_width);
               if (width > 120)
               {
                    Console.WriteLine("Zadaná šířka je větší než maximální");
                    Console.WriteLine("Šířka bude 30");
                    width = 120;
               }
                Console.WriteLine();
                Console.WriteLine("Maximální výška obrázku je 120");
                Console.WriteLine("Zde zadejte výšku obrázku: ");
                // získání výšky
                string input_length = Console.ReadLine();
                int length = Convert.ToInt32(input_length);
                if (length > 30)
                {
                    Console.WriteLine("Zadaná výška je větší než maximální");
                    Console.WriteLine("výška bude 120");
                    length = 30;
                }
                //vytořeńí souboru obrázku v txt formátu
                Console.WriteLine("Zadejte jméno souboru: ");
                string filename = Console.ReadLine();
                string filepath = @"obrazky\" + filename;
                Console.WriteLine(filepath);
                File.Create(filepath);

                char[,] obrazek;
                obrazek = new char[length, width];

                for (int x = 0; x < obrazek.GetLength(0); x++)
                {
                    for (int y = 0; y < obrazek.GetLength(1); y++)
                    {
                        obrazek[y, x] = ' ';
                    }
                }
                
                return obrazek;

            }

            if (key == ConsoleKey.NumPad2)
            {
                // NacteniObrazku();
                Console.WriteLine("Zmáčkli jste 2");
            }

            if (key == ConsoleKey.NumPad3)
            {
                System.Environment.Exit(0);
            }

            if (key != ConsoleKey.NumPad1 && key !=  ConsoleKey.NumPad2 && key != ConsoleKey.NumPad3)
            {
                Console.WriteLine("Neplatná hodnota");
                Console.WriteLine("");
                ZiskatObrazek();
            }

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
