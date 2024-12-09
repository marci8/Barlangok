using Barlangok;

List<Barlang> list = new List<Barlang>();

FileStream fs = new FileStream("..\\..\\..\\src\\barlangok.txt", FileMode.Open);
StreamReader sr = new StreamReader(fs);
sr.ReadLine();
while (!sr.EndOfStream)
{
    Barlang e = new Barlang(sr.ReadLine());
    list.Add(e);
}
sr.Close();
fs.Close();

Console.Write("4. feladat: Barlangok száma: ");
Console.WriteLine(list.Count);

double f5 = 0;
for (int i = 0; i < list.Count; i++)
{
    if (list[i].Telepules.Contains("Miskolc"))
    {
        f5 += list[i].Melyseg;
    }
}
Console.WriteLine($"5. feladat: Az átlagos mélység: {f5 / list.Count:0.000} m");

Console.Write("6. feladat: Kérem a védettségi szintet: ");
var f6 = Console.ReadLine();
int max = 0;
bool t = false;
int j = 0;
while (t != true)
{
    for (int i = 0; i < list.Count; i++)
    {
        if (list[i].Hossz > max && list[i].Vedettseg == f6)
        {
            max = list[i].Hossz;
            j = i;
            t = true;
        }
    }
}
if (t == true)
{
    Console.WriteLine($"\tAzon: {list[j].Azon}\n\tNév: {list[j].Nev}\n\tHossz: {list[j].Hossz}" +
        $"\n\tMélység: {list[j].Melyseg}\n\tTelepülés: {list[j].Telepules}");
}
else
{
    Console.WriteLine($"\tNincs ilyen védettségi szinttel barlang az adatok között!");
}

var f7 = list.GroupBy(l => l.Vedettseg);
Console.WriteLine("7. Feladat: Statisztika");
foreach (var h in f7)
{
    Console.WriteLine($"\t{h.Key}:----> {h.Count()} db");
}
