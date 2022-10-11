namespace Malovani
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("ASCII Malování");
            Console.WriteLine("--------------");
            Console.WriteLine();

            Console.WriteLine("Pro ukončení stiskni libovolnou klávesu...");
            Console.CursorVisible = false;
            Console.ReadKey();
        }
    }
}
