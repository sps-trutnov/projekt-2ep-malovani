using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;

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
            char[,] obrazek = new char[28, 15];
            for (int y = 0; y < obrazek.GetLength(0); y++)
                for (int x = 0; x < obrazek.GetLength(1); x++)
                    obrazek[y, x] = (char)nahoda.Next(42, 127);

            PoziceKurzoru kurzor = new PoziceKurzoru() { X = 0, Y = 0 };



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
            int maxOknoX = 120;
            int maxOknoY = 30;

            kurzor.X = 0;
            kurzor.Y = 0;

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

                        if (obrazek.GetLength(1) >= maxOknoX-1)
                            Console.SetCursorPosition(0, y);
                        else if (obrazek.GetLength(1) == maxOknoX-2)
                            Console.SetCursorPosition(1, y);
                        else
                            Console.SetCursorPosition(2, y);
                    }
                        

                    if (kurzor.Y == y && kurzor.X == x)
                    {
                        if (obrazek.GetLength(0) >= maxOknoY-1)
                            Console.SetCursorPosition(0, 0);
                        else if (obrazek.GetLength(0) == maxOknoY-2)
                            Console.SetCursorPosition(0, 1);
                        else
                            Console.SetCursorPosition(0, 2);

                        if (obrazek.GetLength(1) >= maxOknoX-1)
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                        else if (obrazek.GetLength(1) == maxOknoX-2)
                            Console.SetCursorPosition(1, Console.GetCursorPosition().Top);
                        else
                            Console.SetCursorPosition(2, Console.GetCursorPosition().Top);
                        //Console.SetCursorPosition(kurzor.X+2, kurzor.Y+1);

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(obrazek[y, x]);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.Write(obrazek[y, x]);
                    }
                    
                }
            }

            // Rámeček levá a pravá strana
            int stranaMod = 0;
            if (obrazek.GetLength(1) == maxOknoX-1)
            {
                OhraniceniVertikalni(1, 0, obrazek);
                stranaMod = 1;
            }
            else if (obrazek.GetLength(1) == maxOknoX-2)
            {
                for (int x = 0; x < 2; x++)
                {
                    int offset = 0;
                    if (x == 1)
                        offset++;
                    OhraniceniVertikalni(x, 0, obrazek);
                }
                stranaMod = 2;
            }
            else if (obrazek.GetLength(1) == maxOknoX-3)
            {
                for (int x = 0; x < 3; x++)
                {
                    int offset = 0;
                    int doubleX = x;
                    if (doubleX == 1)
                        offset++;
                    else if (doubleX == 2)
                    {
                        doubleX = 0;
                        offset++;
                    }

                    OhraniceniVertikalni(doubleX, offset, obrazek);
                }
                stranaMod = 3;
            }
            else if (obrazek.GetLength(1) < maxOknoX-3)
            {
                for (int x = 0; x < 4; x++)
                {
                    Debug.WriteLine(x);
                    int offset = 0;
                    int doubleX = x;
                    if (doubleX == 1)
                        offset++;
                    else if (doubleX == 2)
                    {
                        doubleX = 0;
                        offset++;
                    }
                    else if (doubleX == 3)
                    {
                        doubleX = 1;
                        offset += 2;
                    }

                    OhraniceniVertikalni(doubleX, offset, obrazek);
                }
                stranaMod = 4;
            }

            // Rámeček horní a dolní strana
            if (obrazek.GetLength(0) == maxOknoY-1)
            {
                OhraniceniHorizontalni(obrazek.GetLength(0), stranaMod, obrazek);
            }
            else if (obrazek.GetLength(0) <= maxOknoY - 2)
            {
                OhraniceniHorizontalni(0, stranaMod, obrazek);
                OhraniceniHorizontalni(obrazek.GetLength(0), stranaMod, obrazek);
            }
        }

        static void OhraniceniVertikalni(int x, int offset, char[,] obrazek)
        {
            Console.SetCursorPosition((obrazek.GetLength(1) + 1) * x + offset, 0);

            Console.BackgroundColor = ConsoleColor.Gray;
            for (int y = 0; y < obrazek.GetLength(0); y++)
            {
                Console.SetCursorPosition((obrazek.GetLength(1) + 1) * x + offset, y);
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.White;
        }

        static void OhraniceniHorizontalni(int y, int stranaMod, char[,] obrazek)
        {
            Console.SetCursorPosition(0, y);

            Console.BackgroundColor = ConsoleColor.Gray;
            for (int x = 0; x < obrazek.GetLength(1) + stranaMod; x++)
            {
                if (obrazek.GetLength(1) + stranaMod == x)
                    break;
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
            }
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
