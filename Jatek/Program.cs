using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek
{
    
    class HibaKereso
    {
       private string a;
       private string b;
       private string c;

        List<string> lista = new List<string>();
        private List<string> elso = new List<string>() { "menj", "nézd", "vedd", "tedd", "nyisd", "húzd", "törd", "leltár", "mentés", "betöltés" };
        private List<string> masodik = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "szekrény", "ágy", "kád", "ajtó", "ablak", "doboz", "kulcs", "feszítővas" };

        private List<string> iranyok = new List<string>() { "észak", "dél", "kelet", "nyugat" };
        private List<string> targyak = new List<string>() { "szekrény", "ágy", "kád", "ajtó", "ablak", "doboz", "kulcs", "feszítővas" };
        private List<string> felveheto_targyak = new List<string>() { "doboz", "kulcs", "feszítővas" };
        private List<string> nem_nyithato = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "ágy", "kád", "ablak", "kulcs", "feszítővas" };
        private List<string> nem_torheto = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "szekrény", "ágy", "kád", "ajtó", "doboz", "kulcs", "feszítővas" };
        private List<string> elhuzhato = new List<string>() { "szekrény" };
        private List<string> nyithato = new List<string>() { "szekrény", "doboz" };
        private List<string> kulcsal_nyithato = new List<string>() { "ajtó" };
        private List<string> torheto = new List<string>() { };
        private List<string> feszitovassal_torheto = new List<string>() { "ablak" };
        private List<string> nyitoeszkoz = new List<string>() { "kulcs" };
        private List<string> toroeszkoz = new List<string>() { "feszítővas" };
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
    class Tulajdonsagok
    {

        //Tulajdonságok
        public List<string> iranyok = new List<string>() { "észak", "dél", "kelet", "nyugat" };

        public List<string> targyak = new List<string>() { "szekrény", "ágy", "kád", "ajtó", "ablak", "doboz", "kulcs", "feszítővas" };

        public List<string> felveheto_targyak = new List<string>() { "doboz", "kulcs", "feszítővas" };

        public List<string> elhuzhato = new List<string>() { "szekrény" };
        public List<string> el_van_huzva = new List<string>() { };
        public List<string> nincs_elhuzva = new List<string>() { "szekrény" };

        public List<string> kezzel_nyithato = new List<string>() { "szekrény", "doboz" };
        public List<string> kulcsal_nyithato = new List<string>() { "ajtó" };
        public List<string> nem_nyithato = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "ágy", "kád", "ablak", "kulcs", "feszítővas" };
        public List<string> nyitoeszkoz = new List<string>() { "kulcs" };
        public List<string> nyitva_van = new List<string>();
        public List<string> nincs_nyitva = new List<string>() { "ajtó", "szekrény", "doboz" };

        public List<string> kezzel_torheto = new List<string>() { };
        public List<string> feszitovassal_torheto = new List<string>() { "ablak" };
        public List<string> nem_torheto = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "szekrény", "ágy", "kád", "ajtó", "doboz", "kulcs", "feszítővas" };
        public List<string> toroeszkoz = new List<string>() { "feszítővas" };
        public List<string> torve_van = new List<string>();
        public List<string> nincs_torve = new List<string>() { "ablak" };

        public Dictionary<string, string> tarolnak_benne = new Dictionary<string, string>() { { "kád", "feszítővas" }, { "szekrény", "doboz" }, { "doboz", "kulcs" } };

        public void Nezo(string targy)
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

        public List<string> legutolso_ervenyes_irany = new List<string>() {"kelet" };

        public string Hely()
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

        //Szoba
        public Dictionary<string, string> nappali_szoba = new Dictionary<string, string>() { { "észak", "szekrény" }, { "dél", "fal" }, { "kelet", "ágy" }, { "nyugat", "ajtó" } };
        public Dictionary<string, string> furdo_szoba = new Dictionary<string, string>() { { "észak", "fal" }, { "dél", "fal" }, { "kelet", "ajtó" }, { "nyugat", "kád" } };
        //Leltár
        public List<string> leltar = new List<string>();
        public List<string> nappalibol_nem_lathato = new List<string>() { "kád", "doboz", "ablak", "kulcs", "feszítővas" };
        public List<string> nappalibol_lathato = new List<string>() { "szekrény", "ágy", "ajtó" };
        public List<string> furdobol_nem_lathato = new List<string>() { "ablak", "szekrény", "ágy", "doboz", "kulcs", "feszítővas" };
        public List<string> furdobol_lathato = new List<string>() { "kád", "ajtó" };

        public Dictionary<string, string> VanEBenneDuplaElem(Dictionary<string,string>l,string keresendo)
        {
            List<string> lista1 = new List<string>();
            List<string> lista2 = new List<string>();

            lista1.AddRange(l.Keys);
            lista2.AddRange(l.Values);
            
            
            foreach (var item in lista2)
            {
                if (lista1.Contains(item))
                {
                    l.Clear();
                }
                else
                {
                    goto v;
                } 
            }
            int n = 0;
            while (keresendo!=lista2[n])
            {
                n++;
            }
            lista1.RemoveAt(n);
            lista2.RemoveAt(n);
            for (int i = 0; i < lista1.Count; i++)
            {
                l.Add(lista1[i],lista2[i]);
            }
            v:;
            return l;
        }
    }
    class Utasitasok
    {
        Tulajdonsagok t = new Tulajdonsagok();

        private List<string> lista = new List<string>();
        public Utasitasok()
        {
          
        }
        public void Eldont(List<string> parancsok)
        {
            lista = parancsok;
            #region leltar
            if (lista[0].Equals("leltár")&&t.leltar.Count>0)
            {
                Console.WriteLine("Ezek vannak nálad: ");
                Console.WriteLine();
                foreach (var item in t.leltar)
                {
                    Console.WriteLine(item);
                }
            }
            if (lista[0].Equals("leltár") && t.leltar.Count.Equals(0))
            {
                Console.WriteLine("A leltárod üres!");
            }
            #endregion
            #region menj
            if (lista[0].Equals("menj"))
            {
                if (t.Hely().Equals("nappali") && lista[1].Equals("észak") && t.nappalibol_lathato.Contains("ablak") && t.torve_van.Contains("ablak"))
                {
                    Console.WriteLine("Gratulálok, sikeresen megszöktél! A kilépéshez nyomj meg egy gombot..");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (t.Hely().Equals("nappali") && lista[1].Equals("észak") && t.nappalibol_lathato.Contains("ablak") && t.nincs_torve.Contains("ablak"))
                {
                    Console.WriteLine("Az ablakot még nem törted be!");
                }
                if (t.Hely().Equals("nappali") && lista[1].Equals("észak")&&t.nincs_elhuzva.Contains("szekrény"))
                {
                    Console.WriteLine("A szekrényt előbb el kell húzni!");
                }
                if (t.Hely().Equals("nappali") && lista[1].Equals("kelet"))
                {
                    Console.WriteLine("Az ágy miatt arra nem tudsz továbbmenni!");
                }
                if (t.Hely().Equals("nappali") && lista[1].Equals("dél"))
                {
                    Console.WriteLine("A fal miatt arra nem tudsz továbbmenni!");
                }
                if (t.Hely().Equals("nappali") && lista[1].Equals("nyugat") && t.nincs_nyitva.Contains("ajtó"))
                {
                    Console.WriteLine("Az ajtó zárva van!");
                }
                if (t.Hely().Equals("nappali") && lista[1].Equals("nyugat") && t.nyitva_van.Contains("ajtó"))
                {
                    t.legutolso_ervenyes_irany.Add("nyugat");
                    Console.WriteLine("Odamentem!");
                }
                if (t.Hely().Equals("fürdőszoba")&&(lista[1].Equals("észak")||lista[1].Equals("dél")))
                {
                    Console.WriteLine("A fal miatt arra nem tudsz továbbmenni!");
                }
                if (t.Hely().Equals("fürdőszoba") && lista[1].Equals("nyugat"))
                {
                    Console.WriteLine("A kád miatt arra nem tudsz továbbmenni!");
                }
                if (t.Hely().Equals("fürdőszoba") && lista[1].Equals("kelet"))
                {
                    t.legutolso_ervenyes_irany.Add("kelet");
                    Console.WriteLine("Odamentem!");
                }
            }
            #endregion
            #region nezd
            if (lista.Count.Equals(1)&&lista[0].Equals("nézd"))
            {
                if (t.Hely().Equals("nappali") && lista.Count.Equals(1))
                {
                    foreach (var item in t.nappali_szoba)
                    {
                        Console.WriteLine("A(z) {0}-i irányban egy {1} látható.", item.Key, item.Value);
                        
                    }
                    
                }
                if (t.Hely().Equals("fürdőszoba") && lista.Count.Equals(1))
                {
                    foreach (var item in t.furdo_szoba)
                    {
                        Console.WriteLine("A(z) {0}-i irányban egy {1} látható.", item.Key, item.Value);
                    }
                }
            }
            
            if (lista.Count.Equals(2)&&lista[0].Equals("nézd"))
            {
                if (t.tarolnak_benne.Keys.Contains(lista[1]))
                {
                    if (t.leltar.Contains(lista[1]))
                    {
                        t.Nezo(lista[1]);
                    }
                    else
                    {
                        if (t.Hely().Equals("nappali")&&t.nappalibol_lathato.Contains(lista[1]))
                        {                       
                            t.Nezo(lista[1]);
                        }
                        if (t.Hely().Equals("nappali") && t.nappalibol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ez a tárgy még nincs se a nappaliban se nálad!");
                        }
                        if (t.Hely().Equals("fürdőszoba") && t.furdobol_lathato.Contains(lista[1]))
                        {
                            List<string> keres = (from x in t.tarolnak_benne where x.Key.Equals(lista[1]) select x.Value).ToList();
                            t.furdobol_lathato.Add(keres[0]);
                            t.furdobol_nem_lathato.Remove(keres[0]);
                            t.Nezo(lista[1]);
                        }
                        if (t.Hely().Equals("fürdőszoba") && t.furdobol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ez a tárgy még nincs se a fürdőszobában se nálad!");
                        }
                    }
                }
                else
                {
                    if (t.leltar.Contains(lista[1]))
                    {
                        t.Nezo(lista[1]);
                    }
                    else
                    {
                        if (t.Hely().Equals("nappali") && t.nappalibol_lathato.Contains(lista[1]))
                        {
                            t.Nezo(lista[1]);
                        }
                        if (t.Hely().Equals("nappali") && t.nappalibol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ez a tárgy nincs se a nappaliban se nálad!");
                        }
                        if (t.Hely().Equals("fürdőszoba") && t.furdobol_lathato.Contains(lista[1]))
                        {
                            t.Nezo(lista[1]);
                        }
                        if (t.Hely().Equals("fürdőszoba") && t.furdobol_nem_lathato.Contains(lista[1]))
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
                
                if (t.Hely().Equals("nappali")&&t.nappalibol_lathato.Contains(lista[2]))
                {
                    string asdw = lista[2].ToString();
                    //t.tarolnak_benne.Remove(asdw);

                    t.tarolnak_benne=t.VanEBenneDuplaElem(t.tarolnak_benne,asdw);
                    t.leltar.Add(lista[2]);
                    t.nappalibol_lathato.Remove(lista[2]);
                    t.nappalibol_nem_lathato.Add(lista[2]);
                    Console.WriteLine("Felvettem!");
                }
                else if (t.Hely().Equals("nappali") && t.nappalibol_nem_lathato.Contains(lista[2]))
                {
                    hiba = true;
                    Console.WriteLine("Itt nincs ilyen tárgy!");
                }           
                if (t.Hely().Equals("fürdőszoba") && t.furdobol_lathato.Contains(lista[2]))
                {
                    string asdw = lista[2].ToString();
                    t.tarolnak_benne.Remove(asdw);
                    t.leltar.Add(lista[2]);
                    t.furdobol_lathato.Remove(lista[2]);
                    t.furdobol_nem_lathato.Add(lista[2]);
                    Console.WriteLine("Felvettem!");
                }
                else if (t.Hely().Equals("fürdőszoba") && t.furdobol_nem_lathato.Contains(lista[2]) && hiba.Equals(false))
                {
                    Console.WriteLine("Itt nincs ilyen tárgy!");
                }
            }
            #endregion
            #region teddle
            if (lista[0].Equals("tedd") && lista[1].Equals("le"))
            {
                if (t.leltar.Contains(lista[2]))
                {
                    if (t.Hely().Equals("nappali"))
                    {
                        t.leltar.Remove(lista[2]);
                        t.nappalibol_lathato.Add(lista[2]);
                        t.nappalibol_nem_lathato.Remove(lista[2]);
                        Console.WriteLine("Letettem!");
                    }
                    if (t.Hely().Equals("fürdőszoba"))
                    {
                        t.leltar.Remove(lista[2]);
                        t.furdobol_lathato.Add(lista[2]);
                        t.furdobol_nem_lathato.Add(lista[2]);
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
                if (t.Hely().Equals("nappali"))
                {
                    if (t.elhuzhato.Contains(lista[1]))
                    {
                        t.el_van_huzva.Add(lista[1]);
                        t.nincs_elhuzva.Remove(lista[1]);
                        t.nappalibol_lathato.Add("ablak");
                        t.nappalibol_nem_lathato.Remove("ablak");
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
                if (t.kezzel_nyithato.Contains(lista[1]))
                {
                    if (t.Hely().Equals("nappali")&&(t.nappalibol_lathato.Contains(lista[1])||t.leltar.Contains(lista[1])))
                    {
                        t.nyitva_van.Add(lista[1]);
                        t.nincs_nyitva.Remove(lista[1]);
                        Console.WriteLine("Kinyitottam!");
                        if (t.tarolnak_benne.Keys.Contains(lista[1]))
                        {
                            List<string> keres = (from x in t.tarolnak_benne where x.Key.Equals(lista[1]) select x.Value).ToList();
                            t.nappalibol_lathato.Add(keres[0]);
                            t.nappalibol_nem_lathato.Remove(keres[0]);
                        }
                    }
                    else if (t.Hely().Equals("nappali") && t.nappalibol_nem_lathato.Contains(lista[1]))
                    {
                        Console.WriteLine("Ebben a szobában nincs ilyen!");
                    }
                    if (t.Hely().Equals("fürdőszoba")&&(t.furdobol_lathato.Contains(lista[1])||t.leltar.Contains(lista[1])))
                    {
                        t.nyitva_van.Add(lista[1]);
                        t.nincs_nyitva.Remove(lista[1]);
                        Console.WriteLine("Kinyitottam!");
                        if (t.tarolnak_benne.Keys.Contains(lista[1]))
                        {
                            List<string> keres = (from x in t.tarolnak_benne where x.Key.Equals(lista[1]) select x.Value).ToList();
                            t.nappalibol_lathato.Add(keres[0]);
                            t.nappalibol_nem_lathato.Remove(keres[0]);
                        }
                    }
                    else if (t.Hely().Equals("fürdőszoba") && t.furdobol_nem_lathato.Contains(lista[1]))
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
                if (t.kulcsal_nyithato.Contains(lista[1]))
                {
                    if (t.leltar.Contains(lista[2])&&t.nyitoeszkoz.Contains(lista[2]))
                    {
                        if (t.Hely().Equals("nappali")&&t.nappalibol_lathato.Contains(lista[1]))
                        {
                            t.nyitva_van.Add(lista[1]);
                            t.nincs_nyitva.Remove(lista[1]);
                            Console.WriteLine("Kinyitottam!");
                        }
                        else if (t.Hely().Equals("nappali") && t.nappalibol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ebben a szobában nincs olyan tárgy amit ezzel a kulcsal ki tudnál nyitni!");
                        }
                        if (t.Hely().Equals("fürdőszoba") && t.furdobol_lathato.Contains(lista[1]))
                        {
                            t.nyitva_van.Add(lista[1]);
                            t.nincs_nyitva.Remove(lista[1]);
                            Console.WriteLine("Kinyitottam!");
                        }
                        else if (t.Hely().Equals("fürdőszoba") && t.furdobol_nem_lathato.Contains(lista[1]))
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
                if (t.kezzel_torheto.Contains(lista[1]))
                {
                    if (t.Hely().Equals("nappali") && (t.nappalibol_lathato.Contains(lista[1]) || t.leltar.Contains(lista[1])))
                    {
                        t.torve_van.Add(lista[1]);
                        t.nincs_torve.Remove(lista[1]);
                        Console.WriteLine("Összetörtem!");     
                    }
                    else if (t.Hely().Equals("nappali") && t.nappalibol_nem_lathato.Contains(lista[1]))
                    {
                        Console.WriteLine("Ebben a szobában nincs ilyen!");
                    }
                    if (t.Hely().Equals("fürdőszoba") && (t.furdobol_lathato.Contains(lista[1]) || t.leltar.Contains(lista[1])))
                    {
                        t.torve_van.Add(lista[1]);
                        t.nincs_torve.Remove(lista[1]);
                        Console.WriteLine("Összetörtem!");                   
                    }
                    else if (t.Hely().Equals("fürdőszoba") && t.furdobol_nem_lathato.Contains(lista[1]))
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
                if (t.feszitovassal_torheto.Contains(lista[1]))
                {
                    if (t.leltar.Contains(lista[2]) && t.toroeszkoz.Contains(lista[2]))
                    {
                        if (t.Hely().Equals("nappali") && t.nappalibol_lathato.Contains(lista[1]))
                        {
                            t.torve_van.Add(lista[1]);
                            t.nincs_torve.Remove(lista[1]);
                            Console.WriteLine("Összetörtem!");
                        }
                        else if (t.Hely().Equals("nappali") && t.nappalibol_nem_lathato.Contains(lista[1]))
                        {
                            Console.WriteLine("Ebben a szobában nincs olyan tárgy amit ezzel a feszítővassal össze tudnál törni!");
                        }
                        if (t.Hely().Equals("fürdőszoba") && t.furdobol_lathato.Contains(lista[1]))
                        {
                            t.torve_van.Add(lista[1]);
                            t.nincs_torve.Remove(lista[1]);
                            Console.WriteLine("Összetörtem!");
                        }
                        else if (t.Hely().Equals("fürdőszoba") && t.furdobol_nem_lathato.Contains(lista[1]))
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
