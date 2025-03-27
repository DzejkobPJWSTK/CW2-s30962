using Projekt;

Statek statek1 = new Statek(100,3,10000);
Statek statek2 = new Statek(10,2,1500);

KontenerNaPlyn kontenerNaPlyn1 = new KontenerNaPlyn(true, 100,1000,1313,600);
KontenerNaPlyn kontenerNaPlyn2 = new KontenerNaPlyn(false, 20,2000,123,800);

KontenerNaGaz kontenerNaGaz1 = new KontenerNaGaz(100,1312,100.5,13122,1500);
KontenerNaGaz kontenerNaGaz2 = new KontenerNaGaz(600,232,1600,400,4000);

KontenerChlodniczy kontenerChlodniczy1 = new KontenerChlodniczy("banany",20,12313,500,1444,1000);
KontenerChlodniczy kontenerChlodniczy2 = new KontenerChlodniczy("mieso", 10, 123,1414,222,500);

Console.WriteLine("\nKontenery z plynem:");
kontenerNaPlyn1.WyswietlInformacje();
kontenerNaPlyn2.WyswietlInformacje();

Console.WriteLine("\nKontenery z gazem:");
kontenerNaGaz1.WyswietlInformacje();
kontenerNaGaz2.WyswietlInformacje();

Console.WriteLine("\nKontenery chlodnicze:");
kontenerChlodniczy1.WyswietlInformacje();
kontenerChlodniczy2.WyswietlInformacje();

Console.WriteLine("\nLadowanie ladunkow do kontenerow:");
kontenerNaPlyn1.ZaladowanieLadunku(100);
kontenerNaGaz1.ZaladowanieLadunku(1200);
kontenerChlodniczy1.ZaladowanieProduktu(100,"banany");

Console.WriteLine("\nUsuwanie ladunku z konteneru:");
kontenerNaPlyn2.OproznienieLadunku();
kontenerNaGaz1.OproznienieLadunku();
kontenerChlodniczy1.OproznienieLadunku();

Console.WriteLine("Załadowanie listy kontenerow na statek1:");
statek1.DodanieKontenera([kontenerNaPlyn1, kontenerChlodniczy1]);
statek1.WyswietlInformacje();

Console.WriteLine("\n\nUsuniecie kontenera ze statku1: ");
statek1.UsuniecieKontenera("KON-L-1");
statek1.WyswietlInformacje();

Console.WriteLine("\nPrzeniesienie kontenera miedzy statkami: ");
statek2.DodanieKontenera(kontenerNaGaz2);

Console.WriteLine("\nStatek 1");
statek1.WyswietlInformacje();
Console.WriteLine("\nStatek 2");
statek2.WyswietlInformacje();
Console.WriteLine("");
statek1.PrzeniesienieKonteneraNaInnyStatek("KON-C-5", statek2);

Console.WriteLine("\nStatek 1");
statek1.WyswietlInformacje();
Console.WriteLine("\nStatek 2");
statek2.WyswietlInformacje();

Console.WriteLine("\n\nZastapienie kontenera innym:");
Console.WriteLine("Statek 2 przed");
statek2.WyswietlInformacje();
Console.WriteLine("Numer seryjny kontenera na gaz: " + kontenerNaGaz1.GetNumerSeryjny());
statek2.ZastapienieKontenera("KON-G-4", kontenerNaGaz1);
Console.WriteLine("Statek 2 po");
statek2.WyswietlInformacje();

kontenerChlodniczy2.OproznienieLadunku();