namespace ConsoleApp2
{
    public class  adatok
    {
        public string nevek { get; set; }
        public int korok { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            String fajl = File.ReadAllText("adatok.json", System.Text.Encoding.Latin1);
            Console.WriteLine(fajl);

        }
    }
}
