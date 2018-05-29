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

        public bool rozwiniety;

        Int32 index;

       public Wierz()
        {
            gra = new Gra();
            rozwiniety = false;
        }

        public Wierz(Wierz f)
        {
            gra = new Gra(f.gra);
            rozwiniety = false;
           
        }

        public bool Zagraj(Pionek wybor,Pionek cel)
        {
            return gra.Ruch(wybor, cel);
        }

        public bool Czy_Rozne(Wierz w)
        {
            for (int g = 0; g < 2; g++)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (gra.pionki[g][i].aktywny == w.gra.pionki[g][i].aktywny)
                    {
                        if (gra.pionki[g][i].god != w.gra.pionki[g][i].god)
                            return true;
                        if ((gra.pionki[g][i].w != w.gra.pionki[g][i].w) || (gra.pionki[g][i].r != w.gra.pionki[g][i].r))
                            return true;
                    }
                    else return true;


                }
            }       
            return false;
        }

        public ulong Kod()
        {
              long kod =0b000000000000000000000000000000000000000000000000000000000000000;

            
            foreach (Pionek p in gra.pionki[0])
            {
                if (p.aktywny)
                    kod |=   (1<<( p.w*8+p.r));
                
            }

            foreach (Pionek p in gra.pionki[1])
            {
                if (p.aktywny)
                    kod |= (1 << (p.w * 8 + p.r));

            }
            if (kod > 0)
                return Convert.ToUInt64(kod) + 9223372036854775807;
            else
                return Convert.ToUInt64(Math.Abs(kod));

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

    class TabHash
    {
        

        TabHash[] hash;
        List<Wierz> lw;
        List<Kraw>  lk;

        

       const uint ST=40;

        public TabHash()
        {
           
        }

       int Index(ulong kod,uint st)
        {
            return Convert.ToInt32(kod % st);
        }
       public bool Dolacz( ulong kod, Wierz w, Kraw k, uint st= ST)
        {
            int ind = Index(kod, st);
            if (st > 10) {

                if (hash == null)
                    hash = new TabHash[st];

                if (hash[ind] == null)
                    hash[ind] = new TabHash();

                return hash[ind].Dolacz(kod, w, k, st - 1);
            }
            if (st == 10)
            {
               
                if (lk == null)
                    lk = new List<Kraw>();
                if (lw == null)
                    lw = new List<Wierz>();
                else
                foreach (Wierz w_w in lw)
                {
                    if (!w_w.Czy_Rozne(w))

                        return false;

                }

            }
            lw.Add(w);
            lk.Add(k);

            return true;

        }
    

    }
   class Graf
    {
        List<Wierz> W;
        List<Kraw>  K;

        List<Wierz> liscie;

        TabHash tab;

        int gracz, wrog;
        int l;

        public  Graf(int g)
        {
            W = new List<Wierz>();
            K = new List<Kraw>();
            liscie = new List<Wierz>();
            tab = new TabHash();

            gracz = g;
            if (gracz == 0)
                wrog = 1;
            else
                wrog = 0;

            W.Add(new Wierz());
            l = 0;
            BudujGraf(7);


        }

        bool Dolacz(Wierz w,Kraw k)
        {

            foreach (Wierz w_w in W)
            {
                if (!w_w.Czy_Rozne(w))

                    return false;

            }
            
                    W.Add(w);
                    K.Add(k);

            return true;
            
           


        }

       List<Wierz> RozwinWierz(Wierz w,int gracz)//robi dla w :-dzieci(zruchem) -dodaje do list
        {
            List<Wierz> lw  =new List<Wierz>();//nowe wierzcholki od ojca
           
            Pionek      p   =new Pionek(0);

            Wierz nowy_wierz = new Wierz(w);


            void p_cel(int y, int x)
            {
                p.w = y;
                p.r = x;
            }
            
            foreach(Pionek t in w.gra.pionki[w.gra.kolej] )
            {
                if (t.aktywny)
                    for(int y=0;y<8;y++)
                        for(int x=0;x<8;x++)
                        {
                            p_cel(y,x);
                            
                            if (nowy_wierz.Zagraj(t, p))
                            {
                                
                                Kraw nowa_kraw = new Kraw(w, nowy_wierz);
                                if (tab.Dolacz(nowy_wierz.Kod(),nowy_wierz, nowa_kraw))
                                {
                                    lw.Add(nowy_wierz);
                                    W.Add(nowy_wierz);
                                    K.Add(nowa_kraw);
                                }
                                nowy_wierz = new Wierz(w);
                            }
                            
                        }
                    

            }

            w.rozwiniety = true;

           
           
            //dodaje do lisci//czyli swierza nowa warstwa
            return lw;

        }
       List<Wierz> RozwinWarstwe(List<Wierz> warstwa, int gracz)
        {
            List<Wierz> nowe_liscie = new List<Wierz>();

            foreach (Wierz tmp in warstwa)
            {
                nowe_liscie.AddRange(RozwinWierz(tmp, gracz));
            }
            return nowe_liscie;
            
        }
        
     public void  BudujGraf(int r)
        {
            liscie.AddRange(W);

            for (; r > 0; r--)
            {
                // ruch
                List<Wierz> warstwa = new List<Wierz>();
                warstwa.AddRange(liscie);
                liscie = RozwinWarstwe(warstwa,gracz);
                /////////////////////
              

            }
        }

    

    }
}
