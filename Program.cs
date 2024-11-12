using Varosok;

List<Varos> varosok = new(); 
using StreamReader sr = new(
    path: @"../../../src/varosok.csv",
    encoding: System.Text.Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream) varosok.Add(new(sr.ReadLine()));
//foreach (var varos in varosok) Console.WriteLine(varos);

var f1 = varosok
    .Where(v => v.OrszagNev.Equals("Kína"))
    .Sum(v => v.Nepesseg);
Console.WriteLine($"1. feladat - A kínai városok népessége: {f1} millió fő");

var f2 = varosok
    .Where(v => v.OrszagNev.Equals("India"))
    .Average(v => v.Nepesseg);
Console.WriteLine($"\n2. feladat - Az indiai városok átlag népessége: {f2} millió fő");

var f3 = varosok.MaxBy(v => v.Nepesseg);
Console.WriteLine($"\n3. feladat - A legnépesebb nagyváros: {f3.VarosNev}");

var f4 = varosok.
    Where(v => v.Nepesseg > 20)
    .OrderByDescending(v => v.Nepesseg);
Console.WriteLine("\n4. feladat - A 20 millió főnél több lakost számláló városok:");
foreach (var v in f4) Console.WriteLine($"\t{v.ToString()}");

var f5 = varosok
    .GroupBy(v => v.OrszagNev)
    .OrderBy(v => v.Key)
    .Where(v => v.Count() >= 2)
    .Count();
Console.WriteLine($"\n5. feladat - {f5} darab olyan ország van, ami több várossal is képiseli magát a listán");

var f6 = varosok
    .GroupBy(v => v.VarosNev[0])
    .OrderBy(v => v.Key)
    .OrderByDescending(v => v.Count())
    .First().Key;
Console.WriteLine($"\n6. feladat - A leggyakoribb városnév kezdő betű: {f6}");