using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jatek
{
    class HibaKereso : HibaKeresoLista
    {
        private string a;
        private string b;
        private string c;

        private List<string> lista = new List<string>();
        public HibaKereso(List<string> parancsok)
        {
            lista.AddRange(parancsok);
        }
        public bool HibaKeresoMetodus()
        {
            if ((lista.Count.Equals(1) && elso.Contains(lista[0])) || (lista.Count.Equals(2) && elso.Contains(lista[0]) && masodik.Contains(lista[1])) || (lista.Count.Equals(3) && elso.Contains(lista[0]) && masodik.Contains(lista[1]) && masodik.Contains(lista[2])))
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
}
