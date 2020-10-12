using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jatek
{ 
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
