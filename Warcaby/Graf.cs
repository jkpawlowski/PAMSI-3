using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{

    public static class Warstw { public static int warstw = 4; }

    class Wierz
    {
        public Gra gra; //obiekt wytuacji gry

       
        public int waga; //wartosc heurystyczna

        public bool rozwiniety;//czy ma juz ppotomkow

        

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
        int Waga(Gra g,int gracz)//oblicza wartosc funkcji heurystycznej
        {
            int przeciwnik=0;
            if (gracz == 0)  przeciwnik = 1;
            

            return g.lp[gracz] - g.lp[przeciwnik]+ g.lk[gracz]*10 - g.lk[przeciwnik] * 10;
        }

        public bool Zagraj(Pionek wybor,Pionek cel)//wykonuje ruch w grze
        {
            return gra.Ruch(new Pionek(wybor),new Pionek( cel));
        }

        public bool Czy_Rozne(Wierz w)//wykrywa czy nie sa takie same wierzchloki
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

        public ulong Kod() //kodowanie do tablicy
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


        

        public Kraw(Wierz father,Wierz son)
        {
            p = father;
            k = son;
        }

        

    }

    
   class Graf
    {
       // public int warstw=4;//glebokosc przeszukiwania

        List<Wierz> W;  //lista wierzcholkow
        List<Kraw>  K;  //lista krawedzi

        List<Wierz> liscie; //ostatnia powstala warstwa wierzcholkow

      

       const int BETA_MAX = 120;
       const int ALFA_MIN = -120;

        public Kraw wynik; //ostateczne rozwiazanie

        int gracz, wrog;   //kto jest kim
        

        public  Graf(Gra stan,int g)
        {
            W = new List<Wierz>();
            K = new List<Kraw>();
            liscie = new List<Wierz>();
        

            gracz = g;
            if (gracz == 0)
                wrog = 1;
            else
                wrog = 0;

            Wierz w = new Wierz();
            w.gra = stan;
            Wierz ww = new Wierz(w,gracz);

            W.Add(ww);


            

            BudujGraf(Warstw.warstw);

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
    


    
}
