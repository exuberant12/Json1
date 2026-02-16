using System.Text.Json;
using System.Threading.Channels;

namespace ConsoleApp2
{
    class Adat
    {
        public List<string> nevek { get; set; }
        public List<int> korok { get; set; }
    }
    class Diakok
    {
        public String nev { get; set; }
        public List<int> jegyek { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            String fajl = File.ReadAllText("adatok.json", System.Text.Encoding.Latin1);
            Console.WriteLine(fajl);
            Adat adat = JsonSerializer.Deserialize<Adat>(fajl);
            foreach (var nev1 in adat.nevek)
            {
                Console.WriteLine(nev1);
            }
            Console.WriteLine($"{adat.nevek[0]} életkor:{adat.korok[0]}");

            fajl = File.ReadAllText("diakok.json", System.Text.Encoding.Latin1);
            Console.WriteLine(fajl);
            List<Diakok> diakok = JsonSerializer.Deserialize<List<Diakok>>(fajl);
            Console.WriteLine("Keresse: ");
            String nev = Console.ReadLine();
            bool megvan = false;
            foreach (var diak in diakok)
            {
                if (diak.nev == nev)
                {
                    Console.WriteLine("Átlaga: " + diak.jegyek.Average());
                    megvan = true;
                }

            }
            if (!megvan)
            {
                Console.WriteLine("Nincs ilyen nevű diák!");
            }
        }
    }
}
    
