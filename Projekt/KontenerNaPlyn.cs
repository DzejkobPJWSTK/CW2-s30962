namespace Projekt;

public class KontenerNaPlyn : Kontener, IHazardNotifier
{
    private bool CzyNiebezpieczny;
    
    public KontenerNaPlyn(bool czyNiebezpieczny, int wysokosc, double masaWlasna, int glebokosc, double maksymalnaLadownosc) 
        : base("L", wysokosc, masaWlasna, glebokosc, maksymalnaLadownosc)
    {
       CzyNiebezpieczny = czyNiebezpieczny;
    }
    
    public override void ZaladowanieLadunku(double masaLadunku)
    {
        if (CzyNiebezpieczny)
        {
            if (MasaLadunku + masaLadunku <= MaksymalnaLadownosc * 0.5)
            {
                MasaLadunku += masaLadunku;
                Console.WriteLine("Zaladowano plyn!!");
            }
            else
            {
                NotyfikacjaNiebezpiecznaSytuacja();
                throw new OverfillException($"Przekroczono pojemnosc kontenera: {NumerSeryjny}");
            }
        }
        else
        {
            if (MasaLadunku + masaLadunku <= MaksymalnaLadownosc * 0.9)
            {
                MasaLadunku += masaLadunku;
                Console.WriteLine("Zaladowano plyn!!");
            }
            else
            {
                NotyfikacjaNiebezpiecznaSytuacja();
                throw new OverfillException($"Przekroczono pojemnosc kontenera: {NumerSeryjny}");
            }
        }
    }
    
    public override void WyswietlInformacje()
    {
        Console.WriteLine($"Numer seryjny: {NumerSeryjny} \n" +
                          $"Czy niebezpieczny: {CzyNiebezpieczny} \n" +
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