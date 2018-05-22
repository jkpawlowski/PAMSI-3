using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class Pionek
    {
     public   bool aktywny;
        public  int w;
       public int r;
        public Pionek() { aktywny = true; }
     public void  UstPoz(int X,int Y) { w = X;r = Y; }
     public void Zabij() { aktywny = false; }
    }
}
