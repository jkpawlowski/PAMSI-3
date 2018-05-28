using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class Wierz
    {
       public Gra gra;
        
        public float h; //liczba strat
        public float g; //koszt odleglosc
        public float f; //h+g

        Int32 index;

       public Wierz()
        {

        }

        public Wierz(Wierz f)
        {
            gra.Kopia(f.gra); //kopia gry od ojca
        }

        public bool Zagraj(Pionek wybor,Pionek cel)
        {
            return gra.Ruch(wybor, cel);
        }

    }
    class Kraw
    {
        //element //detale ruchu
        Pionek p1, p2;

        //poczatek i koniec//
        Wierz p, k;


        Int32 index;

        public Kraw(Wierz father,Wierz son)
        {
            p = father;
            k = son;
        }


    }
   class Graf
    {
        List<Wierz> W;
        List<Kraw>  K;

        int gracz;

      public  Graf()
        {
            W.Add(new Wierz());


        }

        void RozszerzWierz(Wierz w,int gracz)//robi dla w :-dzieci(zruchem) -dodaje do list
        {
            List<Wierz> lw  =new List<Wierz>();//nowe wierzcholki od ojca
            List<Kraw>  lk  =new List<Kraw>();  //nowe krawedzie od ojca
            Pionek      p   =new Pionek(0);
            


            void p_cel(int y, int x)
            {
                p.w = y;
                p.r = x;
            }
            
            foreach(Pionek t in w.gra.pionki[gracz] )
            {
                if (t.aktywny)
                    for(int y=0;y<8;y++)
                        for(int x=0;x<8;x++)
                        {
                            p_cel(y,x);
                            Wierz nowy_wierz = new Wierz(w);
                            if (nowy_wierz.Zagraj(t, p))
                                {
                                lw.Add(nowy_wierz);
                                Kraw nowa_kraw = new Kraw(w, nowy_wierz);
                                lk.Add(nowa_kraw);
                                }   
                        }
                    

            }

            W.AddRange(lw);
            K.AddRange(lk);

        }
       void RozWarstwy(int i)
        {
            
            while (i > 0)
            {
                





                i--;
            }
        }
    
    }
}
