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


        
        
        public int waga; //h+g

        public bool rozwiniety;

        int index;

       public Wierz()
        {
            gra = new Gra();
            rozwiniety = false;
           // waga = Waga(gra,);
        }

        public Wierz(Wierz f,int g)
        {
            gra = new Gra(f.gra);
            rozwiniety = false;
            waga = Waga(gra,g);
           
        }
        int Waga(Gra g,int gracz)
        {
            int przeciwnik=0;
            if (gracz == 0)  przeciwnik = 1;
            

            return g.lp[gracz] - g.lp[przeciwnik]+ g.lk[gracz]*10 - g.lk[przeciwnik] * 10;
        }

        public bool Zagraj(Pionek wybor,Pionek cel)
        {
            return gra.Ruch(new Pionek(wybor),new Pionek( cel));
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
            ulong kod = 1;

            
            foreach (Pionek p in gra.pionki[0])
            {
                if (p.aktywny)
                    kod *= Convert.ToUInt64(p.w * 8 + p.r);
                
            }

            foreach (Pionek p in gra.pionki[1])
            {
                if (p.aktywny)
                    kod *=1000* Convert.ToUInt64(p.w * 8 + p.r);

            }
            return kod;

        }
    }
    class Kraw
    {
        //element //detale ruchu
        public Pionek p1, p2;

        //poczatek i koniec//
        public Wierz p, k;


        int index;

        public Kraw(Wierz father,Wierz son)
        {
            p = father;
            k = son;
        }

        

    }

    
   class Graf
    {
        const int warstw=4;

        List<Wierz> W;
        List<Kraw>  K;

        List<Wierz> liscie;

      //  TabHash tab;

       const int BETA_MAX = 120;
       const int ALFA_MIN = -120;

        public Kraw wynik;

        int gracz, wrog;
        

        public  Graf(Gra stan,int g)
        {
            W = new List<Wierz>();
            K = new List<Kraw>();
            liscie = new List<Wierz>();
          //  tab = new TabHash();

            gracz = g;
            if (gracz == 0)
                wrog = 1;
            else
                wrog = 0;

            Wierz w = new Wierz();
            w.gra = stan;
            Wierz ww = new Wierz(w,gracz);

            W.Add(ww);


            

            BudujGraf(warstw);

            Wierz najlepsze;
            bool over = false;
            for(int prog = BETA_MAX; prog != ALFA_MIN-1 ; prog--) if (!over)
                {
                foreach (Wierz wyn in liscie)if(!over)
                {
                    if (prog == wyn.waga)
                    {
                        najlepsze = wyn;

                        foreach (Kraw ruch in K)
                        {
                            if (ruch.k == najlepsze&&ruch.p==ww)
                            {
                                wynik = ruch;
                                over = true;
                                break;
                            }
                        }
                        
                    }
                 
                }
                
            
            }
            
            



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

       List<Wierz> RozwinWierz(Wierz w)//robi dla w :-dzieci(zruchem) -dodaje do list
        {
            List<Wierz> lw  =new List<Wierz>();//nowe wierzcholki od ojca
           
            Pionek      p   =new Pionek(0);

            Wierz nowy_wierz = new Wierz(w,gracz);


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
                                nowa_kraw.p1 = new Pionek(t);
                                nowa_kraw.p2 = new Pionek(p);
                                //if (tab.Dolacz(nowy_wierz.Kod(),nowy_wierz, nowa_kraw))
                                {
                                    lw.Add(nowy_wierz);
                                    W.Add(nowy_wierz);
                                    K.Add(nowa_kraw);
                                }
                                nowy_wierz = new Wierz(w,gracz);
                            }
                            
                        }
                    

            }

            w.rozwiniety = true;

           
           
            //dodaje do lisci//czyli swierza nowa warstwa
            return lw;

        }
       List<Wierz> RozwinWarstwe(List<Wierz> warstwa)
        {
            List<Wierz> nowe_liscie = new List<Wierz>();

            foreach (Wierz tmp in warstwa)
            {
                nowe_liscie.AddRange(RozwinWierz(tmp));
            }
            return nowe_liscie;
            
        }
        
       public void  BudujGraf(int glebokosc)
        {
            foreach (Wierz w in W)
            {
                liscie.Add(w);
            }
            liscie = RozwinWarstwe(liscie);

            foreach (Wierz w in liscie)
            {
                Wierz ruch = w;
                ruch.waga=MinMax(ruch, glebokosc-1);
            }


           
        }

      

       int MinMax(Wierz w,int  glebokosc)
        {
           return AlfaBeta(w, glebokosc, ALFA_MIN, BETA_MAX);
        }
       int AlfaBeta(Wierz w, int glebokosc,int alfa,int beta)
        {
            if ((w.gra.koniec) || (glebokosc == 0))
                return w.waga;

            if (w.gra.kolej == wrog)
            {
                List<Wierz> potomki = RozwinWierz(w);
                foreach (Wierz potomek in potomki) {
                    beta = Math.Min(beta, AlfaBeta(potomek, glebokosc - 1, alfa, beta));
                    if (alfa >= beta)
                    {
                        //odcinamy galaz alfa
                        break;
                    }
                }
                return beta;
            }
            else
            {
                List<Wierz> potomki = RozwinWierz(w);
                foreach (Wierz potomek in potomki)
                {
                    alfa = Math.Max(alfa, AlfaBeta(potomek, glebokosc - 1, alfa, beta));
                    if (alfa >= beta)
                    {
                        //odcinamy galaz beta
                        break;
                    }
                }
                return alfa;
            }
         

        }

    }
    class TabHash
    {


        TabHash[] hash;
        List<Wierz> lw;
        List<Kraw> lk;



        const uint ST = 40;

        public TabHash()
        {

        }

        int Index(ulong kod, uint st)
        {
            return Convert.ToInt32(kod % st);
        }
        public bool Dolacz(ulong kod, Wierz w, Kraw k, uint st = ST)
        {
            int ind = Index(kod, st);
            if (st > 10)
            {

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
}
