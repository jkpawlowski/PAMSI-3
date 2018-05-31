using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class SI
    {
        Graf G;

       public SI(Gra g,int gracz)
        {
            G = new Graf(g,gracz);

        }
        public Pionek Wybor()
        {   if (G.wynik != null)
                return G.wynik.p1;
            else return null;
        }
        public Pionek Cel()
        {
            return G.wynik.p2;
        }

    }
}
