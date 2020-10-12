using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jatek
{ 
    class HibaKeresoLista
    {
        protected List<string> elso = new List<string>() { "menj", "nézd", "vedd", "tedd", "nyisd", "húzd", "törd", "leltár", "mentés", "betöltés" };
        protected List<string> masodik = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "szekrény", "ágy", "kád", "ajtó", "ablak", "doboz", "kulcs", "feszítővas" };

        protected List<string> iranyok = new List<string>() { "észak", "dél", "kelet", "nyugat" };
        protected List<string> targyak = new List<string>() { "szekrény", "ágy", "kád", "ajtó", "ablak", "doboz", "kulcs", "feszítővas" };
        protected List<string> felveheto_targyak = new List<string>() { "doboz", "kulcs", "feszítővas" };
        protected List<string> nem_nyithato = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "ágy", "kád", "ablak", "kulcs", "feszítővas" };
        protected List<string> nem_torheto = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "szekrény", "ágy", "kád", "ajtó", "doboz", "kulcs", "feszítővas" };
        protected List<string> elhuzhato = new List<string>() { "szekrény" };
        protected List<string> nyithato = new List<string>() { "szekrény", "doboz" };
        protected List<string> kulcsal_nyithato = new List<string>() { "ajtó" };
        protected List<string> torheto = new List<string>() { };
        protected List<string> feszitovassal_torheto = new List<string>() { "ablak" };
        protected List<string> nyitoeszkoz = new List<string>() { "kulcs" };
        protected List<string> toroeszkoz = new List<string>() { "feszítővas" };
    }
    class HibaKereso : HibaKeresoLista
    {
        private string a;
        private string b;
        private string c;

        private List<string> lista = new List<string>();
        public HibaKereso(List<string>parancsok)
        {      
            lista.AddRange(parancsok);
        }     
        public bool HibaKeresoMetodus()
        {
            if ((lista.Count.Equals(1) && elso.Contains(lista[0])) ||(lista.Count.Equals(2) && elso.Contains(lista[0]) && masodik.Contains(lista[1])) ||(lista.Count.Equals(3) && elso.Contains(lista[0]) && masodik.Contains(lista[1]) && masodik.Contains(lista[2])))
            {
                if (lista.Count.Equals(1))
                {
                    a = lista[0];
                    return true;
                }
                if (lista.Count.Equals(2))
                {
                    a = lista[0];
                    b = lista[1];
                    return true;
                }
                if (lista.Count.Equals(3))
                {
                    a = lista[0];
                    b = lista[1];
                    c = lista[2];
                    return true;
                }
                else
                {
                    Console.WriteLine("Hibás formátumú parancs!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Hibás formátumú parancs!");
                return false;
            }
        }
        public bool Vizsgal()
        {
            bool ures_b = String.IsNullOrEmpty(b);
            bool ures_c = String.IsNullOrEmpty(c);
            
            #region menj parancs hibakeresése
            if ((a.Equals("menj")))
            {
                if (ures_b.Equals(true))
                {
                    Console.WriteLine("Nem adtad meg hogy melyik irányba!");
                    return false;
                }
                if (iranyok.Contains(b).Equals(false) && ures_b.Equals(false))
                {
                    Console.WriteLine("Ilyen irányba nem tudok menni!");
                    return false;
                }
                if (ures_c.Equals(false))
                {
                    Console.WriteLine("Ennek a parancsnak nem adhatsz meg harmadik paramétert!");
                    return false;
                }
            }
            #endregion
            #region nézd parancs hibakeresése
            if (a.Equals("nézd") && ures_b.Equals(false))
            {
                if (ures_c.Equals(false))
                {
                    Console.WriteLine("Ennek a parancsnak nem adhatsz meg harmadik paramétert!");
                    return false;
                }
                if (targyak.Contains(b).Equals(false))
                {
                    Console.WriteLine("Ezt nem tudom megnézni!");
                    return false;
                }
            }
            #endregion
            #region vedd fel parancs hibakeresése
            if (a.Equals("vedd") && b != "fel")
            {
                Console.WriteLine("A \"vedd\" kulcsszó után csak a \"fel\" kulcsszó használható.");
                return false;
            }
            if (ures_b.Equals(false) && (a.Equals("vedd") && b.Equals("fel")))
            {
                if (felveheto_targyak.Contains(c).Equals(false))
                {
                    Console.WriteLine("Ezt a tárgyat nem tudod felvenni.");
                    return false;
                }
            }
            #endregion
            #region tedd le parancs hibakeresése
            if (a.Equals("tedd") && b != "le")
            {
                Console.WriteLine("A \"tedd\" kulcsszó után csak a \"le\" kulcsszó használható.");
                return false;
            }
            if (ures_b.Equals(false) && (a.Equals("tedd") && b.Equals("le")))
            {
                if (felveheto_targyak.Contains(c).Equals(false))
                {
                    Console.WriteLine("Ezt a tárgyat nem tudod letenni, mert nincs is nálad!");
                    return false;
                }
            }
            #endregion
            #region húzd parancs hibakeresése
            if (a.Equals("húzd"))
            {
                if (ures_b.Equals(true))
                {
                    Console.WriteLine("Nem adtad meg mit húzzak el!");
                    return false;
                }
                if (ures_c.Equals(false))
                {
                    Console.WriteLine("Ennek a parancsnak nem adhatsz meg harmadik paramétert!");
                    return false;
                }
                if (elhuzhato.Contains(b).Equals(false) && ures_b.Equals(false))
                {
                    Console.WriteLine("Ezt a tárgyat nem tudod elhúzni!");
                    return false;
                }
            }
            #endregion
            #region nyisd parancs hibakeresése
            if (a.Equals("nyisd") && ures_b.Equals(true))
            {
                Console.WriteLine("Nem adtad meg hogy mit nyissak ki!");
                return false;
            }
            if (a.Equals("nyisd") && nyithato.Contains(b).Equals(false) && ures_b.Equals(false) && kulcsal_nyithato.Contains(b).Equals(false))
            {
                Console.WriteLine("Ezt a tárgyat nem lehet kinyitni!");
                return false;
            }
            if (a.Equals("nyisd") && kulcsal_nyithato.Contains(b).Equals(true) && ures_b.Equals(true))
            {
                Console.WriteLine("Ezt a tárgyat csak kulccsal lehet kinyitni!");
                return false;
            }
            if (a.Equals("nyisd") && nyithato.Contains(b).Equals(true) && ures_c.Equals(false))
            {
                Console.WriteLine("Ennek a parancsnak nem adhatsz meg harmadik paramétert!");
                return false;
            }
            if (a.Equals("nyisd") && kulcsal_nyithato.Contains(b).Equals(true) && nyitoeszkoz.Contains(c).Equals(false))
            {
                Console.WriteLine("Ezt a tárgyat csak kulccsal lehet kinyitni!");
                return false;
            }
            if (a.Equals("nyisd") && nem_nyithato.Contains(b).Equals(true) && ures_c.Equals(false))
            {
                Console.WriteLine("Ezt a tárgyat nem lehet kinyitni!");
                return false;
            }
            #endregion
            #region törd parancs hibakeresése
            if (a.Equals("törd") && ures_b.Equals(true))
            {
                Console.WriteLine("Nem adtad meg hogy mit törjek össze!");
                return false;
            }
            if (a.Equals("törd") && torheto.Contains(b).Equals(false) && ures_b.Equals(false) && feszitovassal_torheto.Contains(b).Equals(false))
            {
                Console.WriteLine("Ezt a tárgyat nem lehet összetörni!");
                return false;
            }
            if (a.Equals("törd") && feszitovassal_torheto.Contains(b).Equals(true) && ures_b.Equals(true))
            {
                Console.WriteLine("Ez a tárgy csak feszítővassal törhető!");
                return false;
            }
            if (a.Equals("törd") && torheto.Contains(b).Equals(true) && ures_c.Equals(false))
            {
                Console.WriteLine("Ennek a parancsnak nem adhatsz meg harmadik paramétert!");
                return false;
            }
            if (a.Equals("törd") && feszitovassal_torheto.Contains(b).Equals(true) && toroeszkoz.Contains(c).Equals(false))
            {
                Console.WriteLine("Ez a tárgy csak feszítővassal törhető!");
                return false;
            }
            if (a.Equals("törd") && nem_torheto.Contains(b).Equals(true) && ures_c.Equals(false))
            {
                Console.WriteLine("Ezt a tárgyat nem lehet összetörni!");
                return false;
            }
            #endregion
            else
            {
                return true;
            }
        }

    }
    class TulajdonsagokLista
    {
        protected List<string> iranyok = new List<string>() { "észak", "dél", "kelet", "nyugat" };

        protected List<string> targyak = new List<string>() { "szekrény", "ágy", "kád", "ajtó", "ablak", "doboz", "kulcs", "feszítővas" };

        protected List<string> felveheto_targyak = new List<string>() { "doboz", "kulcs", "feszítővas" };

        protected List<string> elhuzhato = new List<string>() { "szekrény" };
        protected List<string> el_van_huzva = new List<string>() {""};
        protected List<string> nincs_elhuzva = new List<string>() { "szekrény" };

        protected List<string> kezzel_nyithato = new List<string>() { "szekrény", "doboz" };
        protected List<string> kulcsal_nyithato = new List<string>() { "ajtó" };
        protected List<string> nem_nyithato = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "ágy", "kád", "ablak", "kulcs", "feszítővas" };
        protected List<string> nyitoeszkoz = new List<string>() { "kulcs" };
        protected List<string> nyitva_van = new List<string>() {""};
        protected List<string> nincs_nyitva = new List<string>() { "ajtó", "szekrény", "doboz" };

        protected List<string> kezzel_torheto = new List<string>() {""};
        protected List<string> feszitovassal_torheto = new List<string>() { "ablak" };
        protected List<string> nem_torheto = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "szekrény", "ágy", "kád", "ajtó", "doboz", "kulcs", "feszítővas" };
        protected List<string> toroeszkoz = new List<string>() { "feszítővas" };
        protected List<string> torve_van = new List<string>() {""};
        protected List<string> nincs_torve = new List<string>() { "ablak" };

        protected List<string> legutolso_ervenyes_irany = new List<string>() { "kelet" };

        protected List<string> leltar = new List<string>() {""};
        protected List<string> nappalibol_nem_lathato = new List<string>() { "kád", "doboz", "ablak", "kulcs", "feszítővas" };
        protected List<string> nappalibol_lathato = new List<string>() { "szekrény", "ágy", "ajtó" };
        protected List<string> furdobol_nem_lathato = new List<string>() { "ablak", "szekrény", "ágy", "doboz", "kulcs", "feszítővas" };
        protected List<string> furdobol_lathato = new List<string>() { "kád", "ajtó" };
        
        protected Dictionary<string, string> tarolnak_benne = new Dictionary<string, string>() { { "kád", "feszítővas" }, { "szekrény", "doboz" }, { "doboz", "kulcs" } };
        protected Dictionary<string, string> nappali_szoba = new Dictionary<string, string>() { { "észak", "szekrény" }, { "dél", "fal" }, { "kelet", "ágy" }, { "nyugat", "ajtó" } };
        protected Dictionary<string, string> furdo_szoba = new Dictionary<string, string>() { { "észak", "fal" }, { "dél", "fal" }, { "kelet", "ajtó" }, { "nyugat", "kád" } };
    }
    class Tulajdonsagok : TulajdonsagokLista
    {  
        protected void Nezo(string targy)
        {
            bool hamis = false;
            Console.WriteLine("Tulajdonságai a(z) {0}-nak/nek.", targy);
            Console.WriteLine();
            if (el_van_huzva.Contains(targy))
            {
                Console.WriteLine("-el lett húzva");
                hamis = true;
            }
            if (nincs_elhuzva.Contains(targy))
            {
                Console.WriteLine("-még nincs elhúzva");
                hamis = true;
            }
            if (kezzel_nyithato.Contains(targy))
            {
                Console.WriteLine("-nyitható");
                hamis = true;
            }
            if (kulcsal_nyithato.Contains(targy))
            {
                Console.WriteLine("-csak kulcsal nyitható");
                hamis = true;
            }
            if (nyitva_van.Contains(targy))
            {
                Console.WriteLine("-nyitva van");
                hamis = true;
            }
            if (nincs_nyitva.Contains(targy))
            {
                Console.WriteLine("-zárva van");
                hamis = true;
            }
            if (feszitovassal_torheto.Contains(targy))
            {
                Console.WriteLine("-csak feszítővassal törhető össze");
                hamis = true;
            }
            if (torve_van.Contains(targy))
            {
                Console.WriteLine("-össze van törve");
                hamis = true;
            }
            if (nincs_torve.Contains(targy))
            {
                Console.WriteLine("-még nincs összetörve");
                hamis = true;
            }
            List<string> keres = (from x in tarolnak_benne where x.Key.Equals(targy) select x.Value).ToList();
            if (tarolnak_benne.Keys.Contains(targy))
            {
                Console.WriteLine("-van benne egy {0}", keres[0]);
                hamis = true;
            }
            if (hamis.Equals(false))
            {
                Console.WriteLine("Ennek a tárgynak nincs semmi különleges tulajdonsága!");
            }
        }
        protected string Hely()
        {
            if (nyitva_van.Contains("ajtó") && legutolso_ervenyes_irany.Last().Equals("nyugat"))
            {
                return "fürdőszoba";
            }
            else
            {
                return "nappali";
            }

        }
    }
    class Utasitasok : Tulajdonsagok
    {
        private List<string> lista = new List<string>();
        public void Eldont(List<string> parancsok)
        {

            lista = parancsok;

            #region mentes/betoltes
            List<List<string>> nevek = new List<List<string>>() {iranyok,targyak,felveheto_targyak,elhuzhato,el_van_huzva,nincs_elhuzva,kezzel_nyithato,kulcsal_nyithato,nem_nyithato,nyitoeszkoz,nyitva_van,nincs_nyitva,kezzel_torheto,feszitovassal_torheto, nem_torheto, toroeszkoz, torve_van, nincs_torve, legutolso_ervenyes_irany, leltar, nappalibol_nem_lathato, nappalibol_lathato,furdobol_nem_lathato,furdobol_lathato};
            List<Dictionary<string, string>> nevek2 = new List<Dictionary<string, string>>() {tarolnak_benne,nappali_szoba,furdo_szoba};
            
            if (lista[0].Equals("mentés"))
            {
                StreamWriter sw = new StreamWriter("mentes.txt");
                for (int i = 0; i < nevek.Count; i++)
                {   
                    for (int j = 0; j < nevek[i].Count; j++)
                    {
                        sw.Write(nevek[i][j] + " ");
                        if (j.Equals(nevek[i].Count-1))
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
            if (lista[0].Equals("betöltés")&&File.Exists("mentes.txt").Equals(true))
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
                    for (int j = 0; j < (l.Count-1); j=j+2)
                    {
                        nevek2[i].Add(l[j], l[j+1]);
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
            else if (lista[0].Equals("leltár")&&leltar.Count>0)
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
                if (Hely().Equals("nappali") && lista[1].Equals("észak")&&nincs_elhuzva.Contains("szekrény"))
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
                if (Hely().Equals("fürdőszoba")&&(lista[1].Equals("észak")||lista[1].Equals("dél")))
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
            if (lista.Count.Equals(1)&&lista[0].Equals("nézd"))
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
            
            if (lista.Count.Equals(2)&&lista[0].Equals("nézd"))
            {
                if (tarolnak_benne.Keys.Contains(lista[1]))
                {
                    if (leltar.Contains(lista[1]))
                    {
                        Nezo(lista[1]);
                    }
                    else
                    {
                        if (Hely().Equals("nappali")&&nappalibol_lathato.Contains(lista[1]))
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
            if (lista[0].Equals("vedd")&&lista[1].Equals("fel"))
            {
                bool hiba = false;
                
                if (Hely().Equals("nappali")&&nappalibol_lathato.Contains(lista[2]))
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
            if (lista[0].Equals("nyisd")&&lista.Count.Equals(2))
            {
                if (kezzel_nyithato.Contains(lista[1]))
                {
                    if (Hely().Equals("nappali")&&(nappalibol_lathato.Contains(lista[1])||leltar.Contains(lista[1])))
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
                    if (Hely().Equals("fürdőszoba")&&(furdobol_lathato.Contains(lista[1])||leltar.Contains(lista[1])))
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
            if (lista[0].Equals("nyisd")&&lista.Count.Equals(3))
            {
                if (kulcsal_nyithato.Contains(lista[1]))
                {
                    if (leltar.Contains(lista[2])&&nyitoeszkoz.Contains(lista[2]))
                    {
                        if (Hely().Equals("nappali")&&nappalibol_lathato.Contains(lista[1]))
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
    class Program
    {
        static void Main(string[] args)
        {
            Utasitasok u = new Utasitasok();
            Console.WriteLine("Mit csináljak?");
            while (true)
            {
                cimke:;
                string parancs = Console.ReadLine();
                List<string> parancsok = new List<string>();
                parancsok.AddRange(parancs.Split(' '));
                HibaKereso hk = new HibaKereso(parancsok);
                if (hk.HibaKeresoMetodus().Equals(false) || hk.Vizsgal().Equals(false))
                {
                    Console.WriteLine();
                    goto cimke;
                }
                u.Eldont(parancsok);
            }
        }
    }
}
