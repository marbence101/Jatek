using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek
{
    class Valasz
    { 
        public void Odamentem()
        {
            Console.WriteLine("Odamentem.");
        }
        public void EbbenASzobabanNincsIlyen()
        {
            Console.WriteLine("Ebben a szobában nincs ilyen.");
        }
        public void Nyertel()
        {
            Console.WriteLine("Gratulálok! Megszöktél. A kilépéshez nyomj meg egy gombot...");
            Console.ReadLine();
            Environment.Exit(0);
        }
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
            if ((a.Equals("menj")&&(b!="észak"))|| (a.Equals("menj") && (b != "dél"))|| (a.Equals("menj") && (b != "kelet"))||( a.Equals("menj") && (b != "nyugat")))
            {
                Console.WriteLine("Hibás parancs!");           
            }
            
            
        }
    }
    
    class Hiba
    {
        public string a;
        public string b;
        public string c;

        private List<string> elso = new List<string>() {"menj","nézd","vedd fel","tedd le","nyisd","húzd","törd","leltár","mentés","betöltés" };
        private List<string> masodik = new List<string>() {"észak","dél","kelet","nyugat","szekrény","ágy","kád","ajtó","ablak","doboz","kulcs","feszítővas" };

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
                Console.WriteLine("Hibás parancsot adtál meg! A kilépéshez nyomj meg egy gombot...");
                Console.ReadLine();
                Environment.Exit(0);
            }
            
            
        }
        
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
