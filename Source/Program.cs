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

            Console.Clear();
            char[,] obrazek = ZiskatObrazek();
            PoziceKurzoru poziceMax = new PoziceKurzoru() { X = obrazek.GetLength(0) - 1, Y = obrazek.GetLength(1) - 1 };
            PoziceKurzoru kurzor = new PoziceKurzoru() { X = 0, Y = 0 };
            char[] Whitelist = { (char)32, '!', '\"', '#', '$', '%', '&', '\'', '(', ')', '*', ',', '+', '-', '.', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@', 'A', 'B', 'C', 'D', 'E', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '[', '\\', ']', '^', '_', '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '|', '}', '~' };

            bool konec = false;
            do
            {
                Vykresleni(kurzor, obrazek);

                ConsoleKeyInfo novaKlavesa = Console.ReadKey();

                kurzor = VlivOvladaniNaObrazek(novaKlavesa, obrazek, Whitelist, kurzor, poziceMax);
                kurzor = VlivOvladaniNaKurzor(novaKlavesa, kurzor, poziceMax);
                konec = ZnaciKonec(novaKlavesa);
                Console.WriteLine();
            } while (!konec);

            UlozeniObrazku(obrazek);
            Rozlouceni();
        }

        static void UlozeniObrazku(char[,] obrazek)
        {
            string[] radky = new string[obrazek.GetLength(0)];

            for(int y = 0; y < obrazek.GetLength(0); y++)
            {
                string aktualniRadek = ""; 
                for (int x = 0; x < obrazek.GetLength(1); x++)
                {
                    aktualniRadek = aktualniRadek + obrazek[y, x]; 
                }
                radky[y] = aktualniRadek;
                Console.WriteLine(radky);
            }

            Console.Write("Zapište název obrázku: ");
            string jmenoObrazku = Console.ReadLine();
            string priponaObrazku = ".txt";
            string celeJmenoObrazku = jmenoObrazku + priponaObrazku;
            Console.WriteLine(celeJmenoObrazku);
            File.WriteAllLines("obrazky\\" + celeJmenoObrazku, radky);
            
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

            for (int y = 0; y < radkySouboru.Length; y++)
            {
                char[] obsahVeStringu = radkySouboru[y].ToCharArray();

                for (int x = 0; x < radkySouboru[0].Length; x++)
                {

                    obrazek[y, x] = obsahVeStringu[x];
                }
            }

            return obrazek;

        }

        static bool ZnaciKonec(ConsoleKeyInfo novaKlavesa) {
            return novaKlavesa.Key == ConsoleKey.Escape;
        }

        static PoziceKurzoru VlivOvladaniNaObrazek(ConsoleKeyInfo novaKlavesa, char[,] obrazek, char[] whitelist, PoziceKurzoru kurzor, PoziceKurzoru max)
        {
            if (whitelist.Contains(novaKlavesa.KeyChar))
            {
                obrazek[kurzor.X, kurzor.Y] = novaKlavesa.KeyChar;
                kurzor = VlivOvladaniNaKurzor(new ConsoleKeyInfo((char)13, ConsoleKey.Enter, false, false, false), kurzor, max);

            }
            Console.WriteLine();
            return kurzor;
        }

        static PoziceKurzoru VlivOvladaniNaKurzor(ConsoleKeyInfo novaKlavesa, PoziceKurzoru kurzor, PoziceKurzoru max)
        {
            if (novaKlavesa.Key == ConsoleKey.RightArrow && kurzor.X < max.X)
            {
                kurzor.X = kurzor.X + 1;
            }
            else if (novaKlavesa.Key == ConsoleKey.LeftArrow && kurzor.X > 0)
            {
                kurzor.X = kurzor.X - 1;
            }
            else if (novaKlavesa.Key == ConsoleKey.UpArrow && kurzor.Y > 0)
            {
                kurzor.Y = kurzor.Y - 1;
            }
            else if (novaKlavesa.Key == ConsoleKey.DownArrow && kurzor.Y > max.Y)
            {
                kurzor.Y = kurzor.Y + 1;
            }
            else if (novaKlavesa.Key == ConsoleKey.Enter)
            {
                if (kurzor.X == max.X && kurzor.Y != max.Y)
                {
                    kurzor.X = 0;
                    kurzor.Y = kurzor.Y + 1;
                }
                else if (kurzor.X != max.X) kurzor.X = kurzor.X + 1;
            }
            return kurzor;
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

                        if (obrazek.GetLength(1) >= maxOknoX - 1)
                            Console.SetCursorPosition(0, y);
                        else if (obrazek.GetLength(1) == maxOknoX - 2)
                            Console.SetCursorPosition(1, y);
                        else
                            Console.SetCursorPosition(2, y);
                    }


                    if (kurzor.Y == y && kurzor.X == x)
                    {
                        if (obrazek.GetLength(0) >= maxOknoY - 1)
                            Console.SetCursorPosition(0, 0);
                        else if (obrazek.GetLength(0) == maxOknoY - 2)
                            Console.SetCursorPosition(0, 1);
                        else
                            Console.SetCursorPosition(0, 2);

                        if (obrazek.GetLength(1) >= maxOknoX - 1)
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                        else if (obrazek.GetLength(1) == maxOknoX - 2)
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
            if (obrazek.GetLength(1) == maxOknoX - 1)
            {
                OhraniceniVertikalni(1, 0, obrazek);
                stranaMod = 1;
            }
            else if (obrazek.GetLength(1) == maxOknoX - 2)
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
            else if (obrazek.GetLength(1) == maxOknoX - 3)
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
            else if (obrazek.GetLength(1) < maxOknoX - 3)
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
            if (obrazek.GetLength(0) == maxOknoY - 1)
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


        static void VykresleniMenu()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("########################################################################################################################");
            Console.WriteLine("########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                  ASCII  MALOVÁNÍ                                                 ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                             * Vytvořit nový obrázek *                                            ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                          * Otevřít existující obrázek *                                          ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                               * Ukončit aplikaci *                                               ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                                                                Projekt 2.EP sk.2 ###");
            Console.WriteLine("########################################################################################################################");
            Console.Write("########################################################################################################################");
        }

        static char[,] ZiskatObrazek()
        {
            VykresleniMenu();

            int selectedOption = 1;
            bool keySwitch = false;
            bool selectionConfirmed = false;

            Console.SetCursorPosition(0, 12);
            Console.Write("###                                             ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> Vytvořit nový obrázek <");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                                            ###");

            while (selectionConfirmed == false)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                Console.SetCursorPosition(0, 0);
                VykresleniMenu();

                if (key == ConsoleKey.DownArrow && keySwitch == false)
                {
                    selectedOption++;
                    keySwitch = true;
                }

                if (key == ConsoleKey.UpArrow && keySwitch == false)
                {
                    selectedOption--;
                    keySwitch = true;
                }

                keySwitch = false;

                if (key == ConsoleKey.Enter)
                    selectionConfirmed = true;

                if (selectedOption < 1)
                {
                    selectedOption = 1;
                }

                if (selectedOption > 3)
                {
                    selectedOption = 3;
                }

                if (selectedOption == 1)
                {
                    Console.SetCursorPosition(0, 12);
                    Console.Write("###                                             ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> Vytvořit nový obrázek <");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                                            ###");
                }

                if (selectedOption == 2)
                {
                    Console.SetCursorPosition(0, 14);
                    Console.Write("###                                          ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> Otevřít existující obrázek <");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                                          ###");

                }

                if (selectedOption == 3)
                {
                    Console.SetCursorPosition(0, 16);
                    Console.Write("###                                               ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> Ukončit aplikaci <");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("                                               ###");
                }
            }

            Console.Clear();
            Console.SetCursorPosition(0, 0);

            if (selectedOption == 1)
            {
                // Defaultni rozmery console 120 x 30 znaku
                Console.WriteLine("Maximální šířka obrázku je 120");
                Console.WriteLine("Zde zadejte šířku obrázku: ");
                // získání šířky
                string input_width = Console.ReadLine();
                int width = Convert.ToInt32(input_width);
                if (width > 120)
                {
                    Console.WriteLine("Zadaná šířka je větší než maximální");
                    Console.WriteLine("Šířka bude 120");
                    width = 120;
                }
                Console.WriteLine();
                Console.WriteLine("Maximální výška obrázku je 30");
                Console.WriteLine("Zde zadejte výšku obrázku: ");
                // získání výšky
                string input_length = Console.ReadLine();
                int length = Convert.ToInt32(input_length);
                if (length > 30)
                {
                    Console.WriteLine("Zadaná výška je větší než maximální");
                    Console.WriteLine("výška bude 30");
                    length = 30;
                }

                char[,] obrazek;
                obrazek = new char[length, width];

                for (int x = 0; x < obrazek.GetLength(1); x++)
                {
                    for (int y = 0; y < obrazek.GetLength(0); y++)
                    {
                        obrazek[y, x] = ' ';
                    }
                }

                return obrazek;
            }

            if (selectedOption == 2)

            {
                char[,] obrazek;
                obrazek = NacteniObrazku();
                return obrazek;
            }

            if (selectedOption == 3)
            {
                System.Environment.Exit(0);
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
