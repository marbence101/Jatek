using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jatek
{
    class TulajdonsagokLista
    {
        protected List<string> iranyok = new List<string>() { "észak", "dél", "kelet", "nyugat" };

        protected List<string> targyak = new List<string>() { "szekrény", "ágy", "kád", "ajtó", "ablak", "doboz", "kulcs", "feszítővas" };

        protected List<string> felveheto_targyak = new List<string>() { "doboz", "kulcs", "feszítővas" };

        protected List<string> elhuzhato = new List<string>() { "szekrény" };
        protected List<string> el_van_huzva = new List<string>() { "" };
        protected List<string> nincs_elhuzva = new List<string>() { "szekrény" };

        protected List<string> kezzel_nyithato = new List<string>() { "szekrény", "doboz" };
        protected List<string> kulcsal_nyithato = new List<string>() { "ajtó" };
        protected List<string> nem_nyithato = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "ágy", "kád", "ablak", "kulcs", "feszítővas" };
        protected List<string> nyitoeszkoz = new List<string>() { "kulcs" };
        protected List<string> nyitva_van = new List<string>() { "" };
        protected List<string> nincs_nyitva = new List<string>() { "ajtó", "szekrény", "doboz" };

        protected List<string> kezzel_torheto = new List<string>() { "" };
        protected List<string> feszitovassal_torheto = new List<string>() { "ablak" };
        protected List<string> nem_torheto = new List<string>() { "le", "fel", "észak", "dél", "kelet", "nyugat", "szekrény", "ágy", "kád", "ajtó", "doboz", "kulcs", "feszítővas" };
        protected List<string> toroeszkoz = new List<string>() { "feszítővas" };
        protected List<string> torve_van = new List<string>() { "" };
        protected List<string> nincs_torve = new List<string>() { "ablak" };

        protected List<string> legutolso_ervenyes_irany = new List<string>() { "kelet" };

        protected List<string> leltar = new List<string>() { "" };
        protected List<string> nappalibol_nem_lathato = new List<string>() { "kád", "doboz", "ablak", "kulcs", "feszítővas" };
        protected List<string> nappalibol_lathato = new List<string>() { "szekrény", "ágy", "ajtó" };
        protected List<string> furdobol_nem_lathato = new List<string>() { "ablak", "szekrény", "ágy", "doboz", "kulcs", "feszítővas" };
        protected List<string> furdobol_lathato = new List<string>() { "kád", "ajtó" };

        protected List<string> nezes_utan_lathato = new List<string>() { "kád" };

        protected Dictionary<string, string> tarolnak_benne = new Dictionary<string, string>() { { "kád", "feszítővas" }, { "szekrény", "doboz" }, { "doboz", "kulcs" } };
        protected Dictionary<string, string> nappali_szoba = new Dictionary<string, string>() { { "észak", "szekrény" }, { "dél", "fal" }, { "kelet", "ágy" }, { "nyugat", "ajtó" } };
        protected Dictionary<string, string> furdo_szoba = new Dictionary<string, string>() { { "észak", "fal" }, { "dél", "fal" }, { "kelet", "ajtó" }, { "nyugat", "kád" } };
    }
}
