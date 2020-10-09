using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek
{
   
    static class Valasz
    {
        public static void csakFeszitovassalTorheto() { Console.WriteLine("Ez a tárgy csak feszítővassal törhető!"); }
        public static void eztNemLehetOsszetroni() { Console.WriteLine("Ezt a tárgyat nem lehet összetörni!"); }
        public static void nemAdtadMegMitTorjek() { Console.WriteLine("Nem adtad meg hogy mit törjek össze!"); }
        public static void csakKulccsal() { Console.WriteLine("Ezt a tárgyat csak kulccsal lehet kinyitni!"); }
        public static void nemLehetKinyitni() { Console.WriteLine("Ezt a tárgyat nem lehet kinyitni!"); }
        public static void mitNyissakKi() { Console.WriteLine("Nem adtad meg hogy mit nyissak ki!"); }
        public static void nemaAdtaMegMitHuzzak() { Console.WriteLine("Nem adtad meg mit húzzak el!"); }
        public static void eztNemTudomMegnezni() { Console.WriteLine("Ezt nem tudom megnézni."); }
        public static void melyikIrany(){Console.WriteLine("Nem adtál meg irányt!");}
        public static void rosszIrany(){Console.WriteLine("Ebbe az irányba nem tudok menni.");}
        public static void elhuz(){Console.WriteLine("Ezt a tárgyat nem tudod elhúzni!");}
        static public void le(){Console.WriteLine("Ezt a tárgyat nem tudod letenni, mert nincs is nálad!");}
        static public void teddle(){Console.WriteLine("A \"tedd\" kulcsszó után csak a \"le\" kulcsszót használható.");}
        static public void fel(){Console.WriteLine("Ezt a tárgyat nem tudod felvenni.");}
        static public void veddfel(){Console.WriteLine("A \"vedd\" kulcsszó után csak a \"fel\" kulcsszót használható.");}
        static public void NincsHarom() { Console.WriteLine("Ennek a parancsnak nincs harmadik paramétere."); }
        static public void EbbenASzobabanNincsIlyen() { Console.WriteLine("Ebben a szobában nincs ilyen."); }
        static public void HibasParancs() { Console.WriteLine("Hibás parancsot adtál meg!"); }
    }
    class AlapTulajdonsagok
    {
        public List<string> szekreny = new List<string>() { "elhuzhato", "tarolnak_benne", "lathato", "kezzel_nyithato" };
        public List<string> agy = new List<string>() { "lathato" };
        public List<string> kad = new List<string>() { "tarolnak_benne", "lathato" };
        public List<string> ajto = new List<string>() { "kulcsal_nyithato", "lathato" };
        public List<string> ablak = new List<string>() { "feszitovassal_torheto" };
        public List<string> doboz = new List<string>() { "kezzel_nyithato", "elviheto", "tarolnak_benne" };
        public List<string> kulcs = new List<string>() { "elviheto", "nyithatsz_vele" };
        public List<string> feszitovas = new List<string>() { "elviheto", "torhetsz_vele" };

        public string lathato = "lathato";
        public string nyitva_van = "nyitva_van";
        public string osszetorve = "osszetorve";
        

    }

    
    class Eldont
    {
        private List<string> iranyok = new List<string>() { "észak", "dél", "kelet", "nyugat" };
        private List<string> targyak = new List<string>() { "szekrény", "ágy", "kád", "ajtó", "ablak", "doboz", "kulcs", "feszítővas" };
        private List<string> felveheto_targyak = new List<string>() {"doboz","kulcs","feszitővas"};
        private List<string> nem_nyithato = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "ágy", "kád", "ablak", "kulcs", "feszítővas" };
        private List<string> nem_torheto = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "szekrény", "ágy", "kád", "ajtó", "doboz", "kulcs", "feszítővas" };
        private List<string> elhuzhato = new List<string>() {"szekrény"};
        private List<string> nyithato = new List<string>() {"szekrény","doboz"};
        private List<string> kulcsal_nyithato = new List<string>() {"ajtó"};
        private List<string> torheto = new List<string>() {};
        private List<string> feszitovassal_torheto = new List<string>() {"ablak"};
        private List<string> nyitoeszkoz = new List<string>() {"kulcs"};
        private List<string> toroeszkoz = new List<string>() {"feszítővas"};


        public string a;
        public string b;
        public string c;
        public Eldont(string a, string b, string c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        
        public void Megnez()
        {
            bool dupla = false;
            bool ures_b = String.IsNullOrEmpty(b);
            bool ures_c = String.IsNullOrEmpty(c);
            #region menj parancs hibakeresése
            if ((a.Equals("menj")))
            {
                if (ures_b.Equals(true))
                {
                    Valasz.melyikIrany();
                }
                if (iranyok.Contains(b).Equals(false)&&ures_b.Equals(false))
                {
                    Valasz.rosszIrany();
                }
                if (ures_c.Equals(false))
                {
                    Valasz.NincsHarom();
                }
            }
#endregion
            #region nézd parancs hibakeresése
            if (a.Equals("nézd")&&ures_b.Equals(false))
            {
                if (ures_c.Equals(false))
                {
                    Valasz.NincsHarom();
                }
                if (targyak.Contains(b).Equals(false))
                {
                    Valasz.eztNemTudomMegnezni();
                }
            }
#endregion
            #region vedd fel parancs hibakeresése
            if (a.Equals("vedd")&&b!="fel")
            {
                Valasz.veddfel();
            }
            if (ures_b.Equals(false)&&(a.Equals("vedd")&&b.Equals("fel")))
            {
                if (felveheto_targyak.Contains(c).Equals(false))
                {
                    Valasz.fel();
                }
            }
#endregion
            #region tedd le parancs hibakeresése
            if (a.Equals("tedd")&&b!="le")
            {
                Valasz.teddle();
            }
            if (ures_b.Equals(false) && (a.Equals("tedd") && b.Equals("le")))
            {
                if (felveheto_targyak.Contains(c).Equals(false))
                {
                    Valasz.le();
                }
            }
#endregion
            #region húzd parancs hibakeresése
            if (a.Equals("húzd"))
            {
                if (ures_b.Equals(true))
                {
                    Valasz.nemaAdtaMegMitHuzzak();
                }
                if (ures_c.Equals(false))
                {
                    Valasz.NincsHarom();
                }
                if (elhuzhato.Contains(b).Equals(false) && ures_b.Equals(false))
                {
                    Valasz.elhuz();
                }
            }
            #endregion
            #region nyisd parancs hibakeresése
            if (a.Equals("nyisd")&&ures_b.Equals(true))
            {
                Valasz.mitNyissakKi();
            }
            if (a.Equals("nyisd") && nyithato.Contains(b).Equals(false)&&ures_b.Equals(false)&&kulcsal_nyithato.Contains(b).Equals(false))
            {
                Valasz.nemLehetKinyitni();
                dupla = true;
            }
            if (a.Equals("nyisd") && kulcsal_nyithato.Contains(b).Equals(true) && ures_b.Equals(true))
            {
                Valasz.csakKulccsal();
            }
            if (a.Equals("nyisd")&&nyithato.Contains(b).Equals(true)&&ures_c.Equals(false))
            {
                Valasz.NincsHarom();
            }
            if (a.Equals("nyisd")&&kulcsal_nyithato.Contains(b).Equals(true)&&nyitoeszkoz.Contains(c).Equals(false))
            {
                Valasz.csakKulccsal();
            }
            if (a.Equals("nyisd")&&nem_nyithato.Contains(b).Equals(true)&&ures_c.Equals(false))
            {
                if (dupla.Equals(false))
                {
                    Valasz.nemLehetKinyitni();
                }
                
            }
            dupla = false;
            #endregion
            #region törd parancs hibakeresése
            if (a.Equals("törd") && ures_b.Equals(true))
            {
                Valasz.nemAdtadMegMitTorjek();
            }
            if (a.Equals("törd") && torheto.Contains(b).Equals(false) && ures_b.Equals(false) && feszitovassal_torheto.Contains(b).Equals(false))
            {
                Valasz.eztNemLehetOsszetroni();
                dupla = true;
            }
            if (a.Equals("törd") && feszitovassal_torheto.Contains(b).Equals(true) && ures_b.Equals(true))
            {
                Valasz.csakFeszitovassalTorheto();
            }
            if (a.Equals("törd") && torheto.Contains(b).Equals(true) && ures_c.Equals(false))
            {
                Valasz.NincsHarom();
            }
            if (a.Equals("törd") && feszitovassal_torheto.Contains(b).Equals(true) && toroeszkoz.Contains(c).Equals(false))
            {
                Valasz.csakFeszitovassalTorheto();
            }
            if (a.Equals("törd") && nem_torheto.Contains(b).Equals(true) && ures_c.Equals(false))
            {
                if (dupla.Equals(false))
                {
                    Valasz.eztNemLehetOsszetroni();
                }

            }
            #endregion



        }
    }
    
    class Hiba
    {
        public string a;
        public string b;
        public string c;

        private List<string> elso = new List<string>() {"menj","nézd","vedd","tedd","nyisd","húzd","törd","leltár","mentés","betöltés" };
        private List<string> masodik = new List<string>() {"le","fel","észak","dél","kelet","nyugat","szekrény","ágy","kád","ajtó","ablak","doboz","kulcs","feszítővas" };

        public Hiba(List<string> lista)
        {
            if ((lista.Count.Equals(1) && elso.Contains(lista[0]))||
                (lista.Count.Equals(2) && elso.Contains(lista[0]) && masodik.Contains(lista[1]))||
                (lista.Count.Equals(3) && elso.Contains(lista[0]) && masodik.Contains(lista[1]) && masodik.Contains(lista[2])))
            {
                if (lista.Count.Equals(1))
                {
                    a = lista[0];
                }
                if (lista.Count.Equals(2))
                {
                    a = lista[0];
                    b = lista[1];
                }
                if (lista.Count.Equals(3))
                {
                    a = lista[0];
                    b = lista[1];
                    c = lista[2];
                }
            }
            else
            {
                Valasz.HibasParancs();
            }
            
            
        }
        
    }
    class Metodusok 
    {
        public string a;
        public string b;
        public string c;
        public Metodusok(string a, string b, string c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
       
    }
    class Parancs 
    {
        

        public string a;
        public string b;
        public string c;
        public Parancs(string a, string b, string c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

    }
    class Szoba 
    {
        public static Dictionary<string, string> szoba = new Dictionary<string, string>();
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            string parancs = Console.ReadLine();
            List<string> lista = new List<string>();
            lista.AddRange(parancs.Split(' '));
            Hiba h = new Hiba(lista);
            Eldont e = new Eldont(h.a,h.b,h.c);
            e.Megnez();

            

            Console.ReadKey();
        }
    }
}
