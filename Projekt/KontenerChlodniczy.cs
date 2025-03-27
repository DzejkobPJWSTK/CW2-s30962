namespace Projekt;

public class KontenerChlodniczy : Kontener, IHazardNotifier
{
    private string RodzajPrzewozonegoProduktu;
    private double Temperatura;
    private static Dictionary<string, double> ListaProduktow = new Dictionary<string, double>()
    {
        { "banany", 13.3 },
        { "czekolada", 18.0 },
        { "ryba", 2.0 },
        { "mieso", -15.0 },
        { "lody", -18.0 },
        { "pizza", -30.0 },
        { "ser", 7.2 },
        { "kielbasa", 5.0 },
        { "maslo", 20.5 },
        { "jajka", 19.0 }
    };
    
    public KontenerChlodniczy(string rodzajPrzewozonegoProduktu, double temperatura, int wysokosc, double masaWlasna, int glebokosc, double maksymalnaLadownosc) 
        : base("C", wysokosc, masaWlasna, glebokosc, maksymalnaLadownosc)
    {
        NumerSeryjny = $"KON-C-{CyfraSeryjna}";
        if (!ListaProduktow.ContainsKey(rodzajPrzewozonegoProduktu.ToLower()))
        {
            throw new Exception("Nie rozpoznano wprowadzonego produktu!!");
        }
        
        if (temperatura < ListaProduktow[rodzajPrzewozonegoProduktu.ToLower()])
        {   
            NotyfikacjaNiebezpiecznaSytuacja();
            throw new Exception("Ustawiono za niska temperature dla rodzaju produktu!!");
        }

        RodzajPrzewozonegoProduktu = rodzajPrzewozonegoProduktu;
        Temperatura = temperatura;
    }
    
    public override void OproznienieLadunku()
    {
        MasaLadunku = 0;
        Console.WriteLine("Oprozniono chlodnie!!");
    }
    
    public void ZaladowanieProduktu(double masaLadunku, string rodzajPrzewozonegoProduktu)
    {
        if (rodzajPrzewozonegoProduktu != RodzajPrzewozonegoProduktu)
        {
            NotyfikacjaNiebezpiecznaSytuacja();
            throw new Exception("Nie mozna dodac takiego rodzaju produktu!!");
        }
        if (MasaLadunku + masaLadunku > MaksymalnaLadownosc) 
        {
            NotyfikacjaNiebezpiecznaSytuacja();
            throw new OverfillException("Przeladowano kontener!!");
        }
        MasaLadunku += masaLadunku;
        Console.WriteLine("Zaladowano zywnosc!!");
    }
    
    public override void WyswietlInformacje()
    {
        Console.WriteLine($"Numer seryjny: {NumerSeryjny} \n" +
                          $"Rodzaj przewozonego produktu: {RodzajPrzewozonegoProduktu} \n" +
                          $"Temperatura przewozu: {Temperatura} \n" +
                          $"Wysokosc: {Wysokosc} \n" +
                          $"Glebokosc: {Glebokosc} \n" +
                          $"Masa wlasna: {MasaWlasna} \n" +
                          $"Maksymalna ladownosc: {MaksymalnaLadownosc}");
    }
    
    public void NotyfikacjaNiebezpiecznaSytuacja()
    {
        Console.WriteLine($"Zaszla niebezpieczna sytuacja w kontenerze: {NumerSeryjny}");
    }
}















