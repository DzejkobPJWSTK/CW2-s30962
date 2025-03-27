namespace Projekt;

public abstract class Kontener
{
    protected double MasaLadunku;       // W kilogramach
    protected int Wysokosc;              // W centymetrach
    protected double MasaWlasna;           // W kilogramach
    protected int Glebokosc;             // W centymetrach
    protected string NumerSeryjny;
    protected double MaksymalnaLadownosc;   // W kilogramach
    protected static int CyfraSeryjna = 0;
    
    public Kontener(string oznaczenie, int wysokosc, double masaWlasna, int glebokosc, double maksymalnaLadownosc)
    {
        CyfraSeryjna++;
        MasaLadunku = 0;
        Wysokosc = wysokosc;
        MasaWlasna = masaWlasna;
        Glebokosc = glebokosc;
        NumerSeryjny = $"KON-{oznaczenie}-{CyfraSeryjna}";
        MaksymalnaLadownosc = maksymalnaLadownosc;
        
    }

    public string GetNumerSeryjny()
    {
        return NumerSeryjny;
    }
    public double GetMasaLadunku()
    {
        return MasaLadunku;
    }

    public double GetMasaWlasna()
    {
        return MasaWlasna;
    }
    
    public virtual void OproznienieLadunku()
    {
        MasaLadunku = 0;
        Console.WriteLine("Oprozniono ladunek!!");
    }

    public virtual void ZaladowanieLadunku(double masaLadunku)
    {
        if (MasaLadunku + masaLadunku > MaksymalnaLadownosc)
        {
            throw new OverfillException($"Przekroczono pojemnosc kontenera: {NumerSeryjny}");
        }
        MasaLadunku += masaLadunku;
        Console.WriteLine("Zaladowano ladunek!!");
    }
    
    public virtual void WyswietlInformacje()
    {
        Console.WriteLine($"Numer seryjny: {NumerSeryjny} \n" +
                          $"Wysokosc: {Wysokosc} \n" +
                          $"Glebokosc: {Glebokosc} \n" +
                          $"Masa wlasna: {MasaWlasna} \n" +
                          $"Maksymalna ladownosc: {MaksymalnaLadownosc}");
    }
}