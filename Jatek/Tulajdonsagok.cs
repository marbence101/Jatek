using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jatek
{
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
            if (tarolnak_benne.Keys.Contains(targy) && (nyitva_van.Contains(targy) || nezes_utan_lathato.Contains(targy)))
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
}
