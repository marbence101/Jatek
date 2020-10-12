using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jatek
{
    class Utasitasok : Tulajdonsagok
    {
        private List<string> lista = new List<string>();
        public void Eldont(List<string> parancsok)
        {

            lista = parancsok;

            #region mentes/betoltes
            List<List<string>> nevek = new List<List<string>>() { iranyok, targyak, felveheto_targyak, elhuzhato, el_van_huzva, nincs_elhuzva, kezzel_nyithato, kulcsal_nyithato, nem_nyithato, nyitoeszkoz, nyitva_van, nincs_nyitva, kezzel_torheto, feszitovassal_torheto, nem_torheto, toroeszkoz, torve_van, nincs_torve, legutolso_ervenyes_irany, leltar, nappalibol_nem_lathato, nappalibol_lathato, furdobol_nem_lathato, furdobol_lathato, nezes_utan_lathato };
            List<Dictionary<string, string>> nevek2 = new List<Dictionary<string, string>>() { tarolnak_benne, nappali_szoba, furdo_szoba };

            if (lista[0].Equals("mentés"))
            {
                StreamWriter sw = new StreamWriter("mentes.txt");
                for (int i = 0; i < nevek.Count; i++)
                {
                    for (int j = 0; j < nevek[i].Count; j++)
                    {
                        sw.Write(nevek[i][j] + " ");
                        if (j.Equals(nevek[i].Count - 1))
                        {
                            sw.WriteLine();
                        }
                    }
                }
                for (int i = 0; i < nevek2.Count; i++)
                {
                    List<string> l = new List<string>();
                    List<string> ll = new List<string>();
                    l.AddRange(nevek2[i].Keys);
                    ll.AddRange(nevek2[i].Values);
                    for (int j = 0; j < nevek2[i].Count; j++)
                    {
                        sw.Write(l[j] + " " + ll[j] + " ");
                        if (j.Equals(nevek2[i].Count - 1))
                        {
                            sw.WriteLine();
                        }
                    }
                }
                sw.Close();
                Console.WriteLine("Elmentve..");
            }
            if (lista[0].Equals("betöltés") && File.Exists("mentes.txt").Equals(true))
            {
                StreamReader sr = new StreamReader("mentes.txt");
                for (int i = 0; i < nevek.Count; i++)
                {
                    nevek[i].Clear();
                }
                for (int i = 0; i < nevek2.Count; i++)
                {
                    nevek2[i].Clear();
                }

                for (int i = 0; i < nevek.Count; i++)
                {
                    List<string> l = new List<string>();
                    l.AddRange(sr.ReadLine().Split(' '));
                    nevek[i].AddRange(l);
                }

                for (int i = 0; i < nevek2.Count; i++)
                {
                    List<string> l = new List<string>();
                    l.AddRange(sr.ReadLine().Split(' '));
                    for (int j = 0; j < (l.Count - 1); j = j + 2)
                    {
                        nevek2[i].Add(l[j], l[j + 1]);
                    }

                }

                sr.Close();
                Console.WriteLine("Betöltve..");
            }
            if (lista[0].Equals("betöltés") && File.Exists("mentes.txt").Equals(false))
            {
                Console.WriteLine("Előbb ments!");
            }
            #endregion
            #region leltar
            if (lista[0].Equals("leltár") && leltar.Last().Equals(""))
            {
                Console.WriteLine("A leltárod üres!");
            }
            else if (lista[0].Equals("leltár") && leltar.Count > 0)
            {
                Console.WriteLine("Ezek vannak nálad: ");
                Console.WriteLine();
                foreach (var item in leltar)
                {
                    Console.WriteLine(item);
                }
            }

            #endregion
            #region menj
            if (lista[0].Equals("menj"))
            {
                if (Hely().Equals("nappali") && lista[1].Equals("észak") && nappalibol_lathato.Contains("ablak") && torve_van.Contains("ablak"))
                {
                    Console.WriteLine("Gratulálok, sikeresen megszöktél! A kilépéshez nyomj meg egy gombot..");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (Hely().Equals("nappali") && lista[1].Equals("észak") && nappalibol_lathato.Contains("ablak") && nincs_torve.Contains("ablak"))
                {
                    Console.WriteLine("Az ablakot még nem törted be!");
                }
                if (Hely().Equals("nappali") && lista[1].Equals("észak") && nincs_elhuzva.Contains("szekrény"))
                {
                    Console.WriteLine("A szekrényt előbb el kell húzni!");
                }
                if (Hely().Equals("nappali") && lista[1].Equals("kelet"))
                {
                    Console.WriteLine("Az ágy miatt arra nem tudsz továbbmenni!");
                }
                if (Hely().Equals("nappali") && lista[1].Equals("dél"))
                {
                    Console.WriteLine("A fal miatt arra nem tudsz továbbmenni!");
                }
                if (Hely().Equals("nappali") && lista[1].Equals("nyugat") && nincs_nyitva.Contains("ajtó"))
                {
                    Console.WriteLine("Az ajtó zárva van!");
                }
                if (Hely().Equals("nappali") && lista[1].Equals("nyugat") && nyitva_van.Contains("ajtó"))
                {
                    legutolso_ervenyes_irany.Add("nyugat");
                    Console.WriteLine("Odamentem!");
                }
                else if (Hely().Equals("fürdőszoba") && lista[1].Equals("nyugat"))
                {
                    Console.WriteLine("A kád miatt arra nem tudsz továbbmenni!");
                }
                if (Hely().Equals("fürdőszoba") && (lista[1].Equals("észak") || lista[1].Equals("dél")))
                {
                    Console.WriteLine("A fal miatt arra nem tudsz továbbmenni!");
                }

                if (Hely().Equals("fürdőszoba") && lista[1].Equals("kelet"))
                {
                    legutolso_ervenyes_irany.Add("kelet");
                    Console.WriteLine("Odamentem!");
                }
            }
            #endregion
            #region nezd
            if (lista.Count.Equals(1) && lista[0].Equals("nézd"))
            {
                if (Hely().Equals("nappali") && lista.Count.Equals(1))
                {
                    foreach (var item in nappali_szoba)
                    {
                        Console.WriteLine("A(z) {0}-i irányban egy {1} látható.", item.Key, item.Value);

                    }

                }
                if (Hely().Equals("fürdőszoba") && lista.Count.Equals(1))
                {
                    foreach (var item in furdo_szoba)
                    {
                        Console.WriteLine("A(z) {0}-i irányban egy {1} látható.", item.Key, item.Value);
                    }
                }
            }

            if (lista.Count.Equals(2) && lista[0].Equals("nézd"))
            {
                if (tarolnak_benne.Keys.Contains(lista[1]))
                {
                    if (leltar.Contains(lista[1]))
                    {
                        Nezo(lista[1]);
                    }
                    else
                    {
                        if (Hely().Equals("nappali") && nappalibol_lathato.Contains(lista[1]))
                        {
                            Nezo(lista[1]);
                        }
                        if (Hely().Equals("nappali") && nappalibol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ez a tárgy még nincs se a nappaliban se nálad!");
                        }
                        if (Hely().Equals("fürdőszoba") && furdobol_lathato.Contains(lista[1]))
                        {
                            List<string> keres = (from x in tarolnak_benne where x.Key.Equals(lista[1]) select x.Value).ToList();
                            furdobol_lathato.Add(keres[0]);
                            furdobol_nem_lathato.Remove(keres[0]);
                            Nezo(lista[1]);
                        }
                        if (Hely().Equals("fürdőszoba") && furdobol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ez a tárgy még nincs se a fürdőszobában se nálad!");
                        }
                    }
                }
                else
                {
                    if (leltar.Contains(lista[1]))
                    {
                        Nezo(lista[1]);
                    }
                    else
                    {
                        if (Hely().Equals("nappali") && nappalibol_lathato.Contains(lista[1]))
                        {
                            Nezo(lista[1]);
                        }
                        if (Hely().Equals("nappali") && nappalibol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ez a tárgy nincs se a nappaliban se nálad!");
                        }
                        if (Hely().Equals("fürdőszoba") && furdobol_lathato.Contains(lista[1]))
                        {
                            Nezo(lista[1]);
                        }
                        if (Hely().Equals("fürdőszoba") && furdobol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ez a tárgy nincs se a fürdőszobában se nálad!");
                        }
                    }
                }

            }
            #endregion
            #region veddfel
            if (lista[0].Equals("vedd") && lista[1].Equals("fel"))
            {
                bool hiba = false;

                if (Hely().Equals("nappali") && nappalibol_lathato.Contains(lista[2]))
                {
                    foreach (var item in tarolnak_benne.Where(x => x.Value == lista[2]).ToList())
                    {
                        tarolnak_benne.Remove(item.Key);
                    }
                    leltar.Add(lista[2]);
                    nappalibol_lathato.Remove(lista[2]);
                    nappalibol_nem_lathato.Add(lista[2]);
                    Console.WriteLine("Felvettem!");

                }
                else if (Hely().Equals("nappali") && nappalibol_nem_lathato.Contains(lista[2]))
                {
                    hiba = true;
                    Console.WriteLine("Itt nincs ilyen tárgy!");
                }
                if (Hely().Equals("fürdőszoba") && furdobol_lathato.Contains(lista[2]))
                {
                    foreach (var item in tarolnak_benne.Where(x => x.Value == lista[2]).ToList())
                    {
                        tarolnak_benne.Remove(item.Key);
                    }
                    leltar.Add(lista[2]);
                    furdobol_lathato.Remove(lista[2]);
                    furdobol_nem_lathato.Add(lista[2]);
                    Console.WriteLine("Felvettem!");
                }
                else if (Hely().Equals("fürdőszoba") && furdobol_nem_lathato.Contains(lista[2]) && hiba.Equals(false))
                {
                    Console.WriteLine("Itt nincs ilyen tárgy!");
                }
            }
            #endregion
            #region teddle
            if (lista[0].Equals("tedd") && lista[1].Equals("le"))
            {
                if (leltar.Contains(lista[2]))
                {
                    if (Hely().Equals("nappali"))
                    {
                        leltar.Remove(lista[2]);
                        nappalibol_lathato.Add(lista[2]);
                        nappalibol_nem_lathato.Remove(lista[2]);
                        Console.WriteLine("Letettem!");
                    }
                    if (Hely().Equals("fürdőszoba"))
                    {
                        leltar.Remove(lista[2]);
                        furdobol_lathato.Add(lista[2]);
                        furdobol_nem_lathato.Add(lista[2]);
                        Console.WriteLine("Letettem!");
                    }
                }
                else
                {
                    Console.WriteLine("Nincs is nálad ilyen tárgy!");
                }

            }
            #endregion
            #region huzd
            if (lista[0].Equals("húzd"))
            {
                if (Hely().Equals("nappali"))
                {
                    if (elhuzhato.Contains(lista[1]))
                    {
                        el_van_huzva.Add(lista[1]);
                        nincs_elhuzva.Remove(lista[1]);
                        nappalibol_lathato.Add("ablak");
                        nappalibol_nem_lathato.Remove("ablak");
                        nappali_szoba.Remove("észak");
                        nappali_szoba.Add("észak", "szekrény és egy ablak");
                        Console.WriteLine("Elhúztam!");
                    }
                    else
                    {
                        Console.WriteLine("Ez a tárgy nem húzható el!");
                    }
                }
                else
                {
                    Console.WriteLine("Ebben a szobában nincs ilyen tárgy!");
                }
            }
            #endregion
            #region nyisd
            if (lista[0].Equals("nyisd") && lista.Count.Equals(2))
            {
                if (kezzel_nyithato.Contains(lista[1]))
                {
                    if (Hely().Equals("nappali") && (nappalibol_lathato.Contains(lista[1]) || leltar.Contains(lista[1])))
                    {
                        nyitva_van.Add(lista[1]);
                        nincs_nyitva.Remove(lista[1]);
                        Console.WriteLine("Kinyitottam!");
                        if (tarolnak_benne.Keys.Contains(lista[1]))
                        {
                            List<string> keres = (from x in tarolnak_benne where x.Key.Equals(lista[1]) select x.Value).ToList();
                            nappalibol_lathato.Add(keres[0]);
                            nappalibol_nem_lathato.Remove(keres[0]);
                        }
                    }
                    else if (Hely().Equals("nappali") && nappalibol_nem_lathato.Contains(lista[1]))
                    {
                        Console.WriteLine("Ebben a szobában nincs ilyen!");
                    }
                    if (Hely().Equals("fürdőszoba") && (furdobol_lathato.Contains(lista[1]) || leltar.Contains(lista[1])))
                    {
                        nyitva_van.Add(lista[1]);
                        nincs_nyitva.Remove(lista[1]);
                        Console.WriteLine("Kinyitottam!");
                        if (tarolnak_benne.Keys.Contains(lista[1]))
                        {
                            List<string> keres = (from x in tarolnak_benne where x.Key.Equals(lista[1]) select x.Value).ToList();
                            nappalibol_lathato.Add(keres[0]);
                            nappalibol_nem_lathato.Remove(keres[0]);
                        }
                    }
                    else if (Hely().Equals("fürdőszoba") && furdobol_nem_lathato.Contains(lista[1]))
                    {
                        Console.WriteLine("Ebben a szobában nincs ilyen!");
                    }

                }
                else
                {
                    Console.WriteLine("Ez a tárgy nem nyitható!");
                }
            }
            if (lista[0].Equals("nyisd") && lista.Count.Equals(3))
            {
                if (kulcsal_nyithato.Contains(lista[1]))
                {
                    if (leltar.Contains(lista[2]) && nyitoeszkoz.Contains(lista[2]))
                    {
                        if (Hely().Equals("nappali") && nappalibol_lathato.Contains(lista[1]))
                        {
                            nyitva_van.Add(lista[1]);
                            nincs_nyitva.Remove(lista[1]);
                            Console.WriteLine("Kinyitottam!");
                        }
                        else if (Hely().Equals("nappali") && nappalibol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ebben a szobában nincs olyan tárgy amit ezzel a kulcsal ki tudnál nyitni!");
                        }
                        if (Hely().Equals("fürdőszoba") && furdobol_lathato.Contains(lista[1]))
                        {
                            nyitva_van.Add(lista[1]);
                            nincs_nyitva.Remove(lista[1]);
                            Console.WriteLine("Kinyitottam!");
                        }
                        else if (Hely().Equals("fürdőszoba") && furdobol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ebben a szobában nincs olyan tárgy amit ezzel a kulcsal ki tudnál nyitni!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Nincs is nálad kulcs!");
                    }

                }
                else
                {
                    Console.WriteLine("Ennek a nyitásához nem kell kulcs!");
                }
            }
            #endregion
            #region törd
            if (lista[0].Equals("törd") && lista.Count.Equals(2))
            {
                if (kezzel_torheto.Contains(lista[1]))
                {
                    if (Hely().Equals("nappali") && (nappalibol_lathato.Contains(lista[1]) || leltar.Contains(lista[1])))
                    {
                        torve_van.Add(lista[1]);
                        nincs_torve.Remove(lista[1]);
                        Console.WriteLine("Összetörtem!");
                    }
                    else if (Hely().Equals("nappali") && nappalibol_nem_lathato.Contains(lista[1]))
                    {
                        Console.WriteLine("Ebben a szobában nincs ilyen!");
                    }
                    if (Hely().Equals("fürdőszoba") && (furdobol_lathato.Contains(lista[1]) || leltar.Contains(lista[1])))
                    {
                        torve_van.Add(lista[1]);
                        nincs_torve.Remove(lista[1]);
                        Console.WriteLine("Összetörtem!");
                    }
                    else if (Hely().Equals("fürdőszoba") && furdobol_nem_lathato.Contains(lista[1]))
                    {
                        Console.WriteLine("Ebben a szobában nincs ilyen!");
                    }

                }
                else
                {
                    Console.WriteLine("Ez a tárgy nem törhető!");
                }
            }
            if (lista[0].Equals("törd") && lista.Count.Equals(3))
            {
                if (feszitovassal_torheto.Contains(lista[1]))
                {
                    if (leltar.Contains(lista[2]) && toroeszkoz.Contains(lista[2]))
                    {
                        if (Hely().Equals("nappali") && nappalibol_lathato.Contains(lista[1]))
                        {
                            torve_van.Add(lista[1]);
                            nincs_torve.Remove(lista[1]);
                            Console.WriteLine("Összetörtem!");
                        }
                        else if (Hely().Equals("nappali") && nappalibol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ebben a szobában nincs olyan tárgy amit ezzel a feszítővassal össze tudnál törni!");
                        }
                        if (Hely().Equals("fürdőszoba") && furdobol_lathato.Contains(lista[1]))
                        {
                            torve_van.Add(lista[1]);
                            nincs_torve.Remove(lista[1]);
                            Console.WriteLine("Összetörtem!");
                        }
                        else if (Hely().Equals("fürdőszoba") && furdobol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ebben a szobában nincs olyan tárgy amit ezzel a feszítővassal össze tudnál törni!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Nincs is nálad feszítővas!");
                    }

                }
                else
                {
                    Console.WriteLine("Ennek az összetöréséhez nem kell feszítővas!");
                }
            }
            #endregion        
        }
    }
}
