using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ConsoleApp2
{
    class Adat
    {
        public List<string> nevek { get; set; }
        public List<int> korok { get; set; }
    }

    class Diakok
    {
        public string nev { get; set; }
        public List<int> jegyek { get; set; }
    }

    public class Munkavallalo
    {
        public string nev { get; set; }
        public int fizetes { get; set; }
        public bool jogositvany { get; set; }
        public string munkarend { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string adatJson = File.ReadAllText("adatok.json", System.Text.Encoding.Latin1);
            Adat adat = JsonSerializer.Deserialize<Adat>(adatJson);
            foreach (var n in adat.nevek) Console.WriteLine(n);
            Console.WriteLine($"{adat.nevek[0]} kora: {adat.korok[0]}");

            string diakJson = File.ReadAllText("diakok.json", System.Text.Encoding.Latin1);
            List<Diakok> diakok = JsonSerializer.Deserialize<List<Diakok>>(diakJson);
            Console.Write("Keresett diák: ");
            string keresett = Console.ReadLine();
            bool van = false;
            foreach (var d in diakok)
            {
                if (d.nev == keresett)
                {
                    Console.WriteLine("Átlag: " + d.jegyek.Average());
                    van = true;
                }
            }
            if (!van) Console.WriteLine("Nincs ilyen diák!");

            string mFajl = ("munkavallalok.json");
            string mJson = File.ReadAllText(mFajl);
            List<Munkavallalo> munkavallalok = JsonSerializer.Deserialize<List<Munkavallalo>>(mJson);

            munkavallalok.Add(new Munkavallalo
            {
                nev = "Szabó Júlia",
                fizetes = 380000,
                jogositvany = false,
                munkarend = "10:00-18:00"
            });

            Console.WriteLine("Jogosítvánnyal rendelkezők:");
            foreach (var m in munkavallalok)
            {
                if (m.jogositvany) Console.WriteLine("- " + m.nev);
            }

            var opciok = new JsonSerializerOptions { WriteIndented = true };
            string mentendo = JsonSerializer.Serialize(munkavallalok, opciok);
            File.WriteAllText(mFajl, mentendo);

            Console.WriteLine("Kész.");
        }
    }
}