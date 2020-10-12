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
}
