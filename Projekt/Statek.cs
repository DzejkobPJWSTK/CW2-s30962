using System.Collections;

namespace Projekt;

public class Statek
{
    private List<Kontener> ZaladowaneKontenery;
    private double MaksymalnaPredkosc; // W węzłach
    private int MaksymalnaIloscKontenerow; // Liczba
    private double MaksymalnaWagaPrzewozonychKontenerow; // W tonach

    public Statek(double maksymalnaPredkosc, int maksymalnaIloscKontenerow, double maksymalnaWagaPrzewozonychKontenerow)
    {
        ZaladowaneKontenery = new List<Kontener>();
        MaksymalnaPredkosc = maksymalnaPredkosc;
        MaksymalnaIloscKontenerow = maksymalnaIloscKontenerow;
        MaksymalnaWagaPrzewozonychKontenerow = maksymalnaWagaPrzewozonychKontenerow * 1000; // Obliczone w kilogramach
    }

    public void DodanieKontenera(Kontener kontener)
    {
        ZaladowaneKontenery.Add(kontener);
        SprawdzenieWagiOrazIlosci();
        Console.WriteLine($"Dodano {kontener.GetNumerSeryjny()} do statku");
    }

    public void DodanieKontenera(List<Kontener> listaKontenerow)
    {
        foreach (var kontener in listaKontenerow)
        {
            ZaladowaneKontenery.Add(kontener);
        }

        SprawdzenieWagiOrazIlosci();
        Console.WriteLine("Dodano liste kontenerow do statku");
    }

    public void UsuniecieKontenera(string numerSeryjny)
    {
        Kontener doUsuniecia = null;
        foreach (var kontener in ZaladowaneKontenery)
        {
            if (kontener.GetNumerSeryjny() == numerSeryjny)
            {
                doUsuniecia = kontener;
            }
        }
        
        ZaladowaneKontenery.Remove(doUsuniecia);
        Console.WriteLine($"Usunieto kontener {numerSeryjny} ze statku");
    }

    public void ZastapienieKontenera(string numerSeryjny, Kontener kontenerNowy)
    {
        Kontener doZmiany = null;
        foreach (var kontener in ZaladowaneKontenery)
        {
            if (kontener.GetNumerSeryjny() == numerSeryjny)
            {
                doZmiany = kontener;
            }
        }
        ZaladowaneKontenery[ZaladowaneKontenery.IndexOf(doZmiany)] = kontenerNowy;
        SprawdzenieWagiOrazIlosci();
        Console.WriteLine($"Zastapiono kontener {numerSeryjny}, innym kontenerem {kontenerNowy.GetNumerSeryjny()}");
    }

    public void PrzeniesienieKonteneraNaInnyStatek(string numerSeryjny, Statek statekNowy)
    {
        Kontener doPrzeniesienia = null;
        foreach (var kontener in ZaladowaneKontenery)
        {
            if (kontener.GetNumerSeryjny() == numerSeryjny)
            {
                doPrzeniesienia = kontener;
            }
        }
        this.UsuniecieKontenera(doPrzeniesienia.GetNumerSeryjny());
        statekNowy.DodanieKontenera(doPrzeniesienia);
        statekNowy.SprawdzenieWagiOrazIlosci();
        Console.WriteLine($"Przeniesiono kontener {numerSeryjny} ze statku, na statek {nameof(statekNowy)}");
    }

    public void SprawdzenieWagiOrazIlosci()
    {
        if (ZaladowaneKontenery.Count > MaksymalnaIloscKontenerow)
        {
            throw new Exception($"Za duzo kontenerow na statku");
        }

        double MasaCalkowitaKontenerow = 0;
        foreach (var kontener in ZaladowaneKontenery)
        {
            MasaCalkowitaKontenerow += kontener.GetMasaWlasna() + kontener.GetMasaLadunku();
        }

        if (MasaCalkowitaKontenerow > MaksymalnaWagaPrzewozonychKontenerow)
        {
            throw new Exception($"Waga kontenerow na statku jest za duza");
        }
    }
    
    public void WyswietlInformacje()
    {
        Console.WriteLine($"Maksymalna predkosc {MaksymalnaPredkosc}\n" +
                          $"Maksymalna ilosc kontenerow: {MaksymalnaIloscKontenerow} \n" +
                          $"Maksymalna waga kontenerow: {MaksymalnaWagaPrzewozonychKontenerow}KG \n" +
                          $"Kontenery na pokladzie:");
        foreach (var kontener in ZaladowaneKontenery)
        {   
            Console.WriteLine(kontener.GetNumerSeryjny());
        }
    }
}