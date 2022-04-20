
namespace SztfGraf
{
    class Program
    {
        static void Main(string[] args)
        {
            Graf<string> graf = new GrafSzomszedsagiLista<string>();
            
            graf.UjCsucs("Debrecen");
            graf.UjCsucs("Budapest");
            graf.UjCsucs("Pécs");
            
            graf.UjEl("Budapest", "Pécs", 180 );
            graf.UjEl("Budapest", "Debrecen", 200 );
            ;
        }
    }
}
