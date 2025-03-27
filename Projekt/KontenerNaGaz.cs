namespace Projekt;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    private double Cisnienie; // W atmosferach
    public KontenerNaGaz(double cisnienie, int wysokosc, double masaWlasna, int glebokosc, double maksymalnaLadownosc) 
        : base("G", wysokosc, masaWlasna, glebokosc, maksymalnaLadownosc)
    {
        this.Cisnienie = cisnienie;
        NumerSeryjny = $"KON-G-{CyfraSeryjna}"; 
    }

    public override void OproznienieLadunku()
    {
        MasaLadunku *= 0.05;
        Console.WriteLine("Oprozniono gaz, zostawiono 5% pojemnosci!!");
    }
    
    public override void ZaladowanieLadunku(double masaLadunku)
    {
        if (MasaLadunku + masaLadunku > MaksymalnaLadownosc)
        {
            throw new OverfillException($"Przekroczono pojemnosc kontenera: {NumerSeryjny}");
        }
        MasaLadunku += masaLadunku;
        Console.WriteLine("Zaladowano gaz!!");
    }
    
    public override void WyswietlInformacje()
    {
        Console.WriteLine($"Numer seryjny: {NumerSeryjny} \n" +
                          $"Cisnienie: {Cisnienie} \n" +
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