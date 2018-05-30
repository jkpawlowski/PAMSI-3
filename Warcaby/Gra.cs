using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Warcaby
{
    class pole
    {
        public bool zajete;
        public int gracz;
        public bool krolowa;
       public pole() { zajete = false; krolowa = false; }
    }
    class Gra
    {
        public int kolej;//nr gracza ktory ma wykonac ruch
        public bool seria;
        public int[] lp; //liczba pionkow
        public int[] lk; //liczba krolow
        public int wygrany;
        public bool koniec;

        public pole[][] plansza;

        //********pionki graczy***
         public  Pionek[][] pionki;

        //************************
        void WczytajPlansze()
        { ///////pusta  plansza//////////
            plansza = new pole[8][];

            for (int i = 0; i <= 7; i++)
            {
                plansza[i] = new pole[8];
                for (int j = 0; j <= 7; j++)
                    plansza[i][j] = new pole();
            }
            ////////////////////////
            for (int j = 0; j < 2; j++)
                for (int i = 0; i <= 11; i++)
                {
                    if (pionki[j][i].aktywny)
                    { plansza[pionki[j][i].w][pionki[j][i].r].zajete = true;
                        plansza[pionki[j][i].w][pionki[j][i].r].gracz = pionki[j][i].gracz;
                        plansza[pionki[j][i].w][pionki[j][i].r].krolowa = pionki[j][i].god;
                    }

                }




        }
        void UstawPionki()
        {
            pionki = new Pionek[2][];

            pionki[0] = new Pionek[12];
            pionki[1] = new Pionek[12];
            for (int j = 0; j <= 11; j++)
            {
                pionki[0][j] = new Pionek(0);
                pionki[1][j] = new Pionek(1);
            }
            int i = 0;
            pionki[i][0].UstPoz(0, 0);
            pionki[i][1].UstPoz(0, 2);
            pionki[i][2].UstPoz(0, 4);
            pionki[i][3].UstPoz(0, 6);
            pionki[i][4].UstPoz(1, 1);
            pionki[i][5].UstPoz(1, 3);
            pionki[i][6].UstPoz(1, 5);
            pionki[i][7].UstPoz(1, 7);
            pionki[i][8].UstPoz(2, 0);
            pionki[i][9].UstPoz(2, 2);
            pionki[i][10].UstPoz(2, 4);
            pionki[i][11].UstPoz(2, 6);

            i = 1;
            pionki[i][0].UstPoz(5, 1);
            pionki[i][1].UstPoz(5, 3);
            pionki[i][2].UstPoz(5, 5);
            pionki[i][3].UstPoz(5, 7);
            pionki[i][4].UstPoz(6, 0);
            pionki[i][5].UstPoz(6, 2);
            pionki[i][6].UstPoz(6, 4);
            pionki[i][7].UstPoz(6, 6);
            pionki[i][8].UstPoz(7, 1);
            pionki[i][9].UstPoz(7, 3);
            pionki[i][10].UstPoz(7, 5);
            pionki[i][11].UstPoz(7, 7);


        }
        public Gra()
        {
            UstawPionki();
            WczytajPlansze();

            kolej = 0;
            seria = false;
            koniec = false;
            lp = new int[2];
            lp[0] = 12;
            lp[1] = 12;
            lk = new int[2];
            lk[0] = 0;
            lk[1] = 0;

        }
        public Gra(Gra g)
        {

            lp = new int[2];
            lp[0] = 12;
            lp[1] = 12;
            lk = new int[2];
            lk[0] = 0;
            lk[1] = 0;
            Kopia(g);


            WczytajPlansze();

        }
        void Wynik()
        {
            if (lp[0] == 0) { koniec = true; wygrany = 1; }
            if (lp[1] == 0) { koniec = true; wygrany = 0; }
        }
        void PrzKolej()
        {
            if (kolej == 0) { kolej = 1; }
            else kolej = 0;


        }
        public bool Wolny(Pionek p) //czy nie musi niczego bić
        {

            bool opt1, opt2, opt3, opt4;
            opt1 = true;
            opt2 = true;
            opt3 = true;
            opt4 = true;

            if (!p.god)
            {
                if ((p.w >= 2) && (p.r >= 2))
                    if (plansza[p.w - 1][p.r - 1].zajete)
                        if (plansza[p.w - 1][p.r - 1].gracz != p.gracz)
                            if (!plansza[p.w - 2][p.r - 2].zajete)
                                return false;

                if ((p.w >= 2) && (p.r <= 5))
                    if (plansza[p.w - 1][p.r + 1].zajete)
                        if (plansza[p.w - 1][p.r + 1].gracz != p.gracz)
                            if (!plansza[p.w - 2][p.r + 2].zajete)
                                return false;

                if ((p.w <= 5) && (p.r >= 2))
                    if (plansza[p.w + 1][p.r - 1].zajete)
                        if (plansza[p.w + 1][p.r - 1].gracz != p.gracz)
                            if (!plansza[p.w + 2][p.r - 2].zajete)
                                return false;

                if ((p.w <= 5) && (p.r <= 5))
                    if (plansza[p.w + 1][p.r + 1].zajete)
                        if (plansza[p.w + 1][p.r + 1].gracz != p.gracz)
                            if (!plansza[p.w + 2][p.r + 2].zajete)
                                return false;
            }
            if (p.god)
                for (int i = 0; i <= 7; i++)
                {

                    if ((p.w - i >= 2) && (p.r - i >= 2) && opt1)
                        if ((!plansza[p.w - i][p.r - i].zajete) || (plansza[p.w - i][p.r - i].gracz == p.gracz))
                            if (plansza[p.w - i - 1][p.r - i - 1].zajete)
                                if (plansza[p.w - i - 1][p.r - i - 1].gracz != p.gracz)
                                {
                                    if (!plansza[p.w - i - 2][p.r - i - 2].zajete)
                                        return false;
                                }
                                else opt1 = false;

                    if ((p.w - i >= 2) && (p.r + i <= 5) && opt2)
                        if ((!plansza[p.w - i][p.r + i].zajete) || (plansza[p.w - i][p.r + i].gracz == p.gracz))
                            if (plansza[p.w - i - 1][p.r + i + 1].zajete)
                                if (plansza[p.w - i - 1][p.r + i + 1].gracz != p.gracz)
                                {
                                    if (!plansza[p.w - i - 2][p.r + i + 2].zajete)
                                        return false;
                                }
                                else opt2 = false;


                    if ((p.w + i <= 5) && (p.r - i >= 2) && opt3)
                        if ((!plansza[p.w + i][p.r - i].zajete) || (plansza[p.w + i][p.r - i].gracz == p.gracz))
                            if (plansza[p.w + i + 1][p.r - i - 1].zajete)
                                if (plansza[p.w + i + 1][p.r - i - 1].gracz != p.gracz)
                                {
                                    if (!plansza[p.w + i + 2][p.r - i - 2].zajete)
                                        return false;
                                }
                                else opt3 = false;

                    if ((p.w + i <= 5) && (p.r + i <= 5) && opt4)
                        if ((!plansza[p.w + i][p.r + i].zajete) || (plansza[p.w + i][p.r + i].gracz == p.gracz))
                            if (plansza[p.w + i + 1][p.r + i + 1].zajete)
                                if (plansza[p.w + i + 1][p.r + i + 1].gracz != p.gracz)
                                {
                                    if (!plansza[p.w + i + 2][p.r + i + 2].zajete)
                                        return false;
                                }
                                else opt4 = false;

                }


            return true;
        }
        bool Bij(int w, int r)
        {
            for (int j = 0; j <= 1; j++)
                for (int i = 0; i <= 11; i++)
                    if ((pionki[j][i].aktywny) && (pionki[j][i].w == w) && (pionki[j][i].r == r))
                    {
                        pionki[j][i].Zabij();
                        lp[j]--;
                        if (pionki[j][i].god) lk[j]--;

                        return true;
                    }

            return false;
        }
        bool Moze(Pionek w, Pionek c)
        {
            if (Math.Abs(w.w - c.w) == 1)
                if (Math.Abs(w.r - c.r) == 1)
                    return true;
            if (Math.Abs(w.w - c.w) == 2)
                if (Math.Abs(w.r - c.r) == 2)
                    if (plansza[(w.w + c.w) / 2][(w.r + c.r) / 2].zajete)
                        if (plansza[(w.w + c.w) / 2][(w.r + c.r) / 2].gracz != kolej)//sprawdza czy zjadzie bicie         
                        {

                            Bij((w.w + c.w) / 2, (w.r + c.r) / 2);
                            return true;
                        }
            if (w.god)
            {

                //ukos
                int opt = 0;
                int bicie = 0;

                //znajduje rodzaj ukosu
                for (int i = 1; i <= Math.Abs(w.w - c.w); i++) {
                    if ((w.w + i == c.w) && (w.r + i == c.r)) opt = 1;
                    if ((w.w + i == c.w) && (w.r - i == c.r)) opt = 2;
                    if ((w.w - i == c.w) && (w.r + i == c.r)) opt = 3;
                    if ((w.w - i == c.w) && (w.r - i == c.r)) opt = 4;
                }
                if (opt == 0) return false;

                //czy nie ma swojego pionka na trasie i jedno bicie
                for (int i = 1; i <= Math.Abs(w.w - c.w); i++) {
                    if (opt == 1) if (plansza[w.w + i][w.r + i].zajete)
                            if (plansza[w.w + i][w.r + i].gracz != w.gracz) { bicie++; if (bicie > 1) return false; }
                            else return false;
                    if (opt == 2) if (plansza[w.w + i][w.r - i].zajete)
                            if (plansza[w.w + i][w.r - i].gracz != w.gracz) { bicie++; if (bicie > 1) return false; }
                            else return false;
                    if (opt == 3) if (plansza[w.w - i][w.r + i].zajete)
                            if (plansza[w.w - i][w.r + i].gracz != w.gracz) { bicie++; if (bicie > 1) return false; }
                            else return false;
                    if (opt == 4) if (plansza[w.w - i][w.r - i].zajete)
                            if (plansza[w.w - i][w.r - i].gracz != w.gracz) { bicie++; if (bicie > 1) return false; }
                            else return false;

                }

                return true;
            }
            return false;
        }
        bool DoPrzodu(Pionek w, Pionek c)
        {
            if (w.god) return true;
            if (w.gracz == 0) if (c.w > w.w) return true;
            if (w.gracz == 1) if (c.w < w.w) return true;

            return false;
        }
        public bool Ruch(Pionek wybor, Pionek cel)
        {

            ///////////////////////////////////////////////////////////
            if (plansza[cel.w][cel.r].zajete)//pole cel juz jest zajete
                return false;
            ////////////////////////////////////////////////
            if (plansza[wybor.w][wybor.r].zajete)//wybrano jakis pionek
            {
                if (plansza[wybor.w][wybor.r].gracz == kolej) //sprawdzenie czy moze wykonac ruch
                {

                    if (Moze(wybor, cel))
                        if (Wolny(wybor))
                        {
                            if (DoPrzodu(wybor, cel))
                                if (Przesun(wybor, cel))
                                {
                                    PrzKolej(); //koniec ruchu jezeli nie ma mozliwosci bicia
                                    seria = false;
                                    Wynik();
                                    return true;
                                }
                        }
                        else
                        {
                            if (!wybor.god)
                            {
                                if (plansza[(wybor.w + cel.w) / 2][(wybor.r + cel.r) / 2].zajete == true)
                                    if (plansza[(wybor.w + cel.w) / 2][(wybor.r + cel.r) / 2].gracz != wybor.gracz)
                                        if (Przesun(wybor, cel))
                                        {
                                            wybor.w = cel.w;
                                            wybor.r = cel.r;
                                            if (Wolny(wybor))
                                            {
                                                PrzKolej(); //koniec ruchu jezeli nie ma mozliwosci bicia
                                                seria = false;
                                            }
                                            else
                                                seria = true;

                                            Wynik();
                                            return true;
                                        }
                            }
                            else

                            if (Przesun(wybor, cel))
                            {
                                wybor.w = cel.w;
                                wybor.r = cel.r;
                                if (Wolny(wybor))
                                {
                                    PrzKolej(); //koniec ruchu jezeli nie ma mozliwosci bicia
                                    seria = false;
                                }
                                else
                                    seria = true;
                                Wynik();
                                return true;
                            }


                        }


                }
            }
            return false;
        }
        bool ZnajdzPionek(Pionek wybor, Pionek[] pionki)
        {
            for (int i = 0; i <= 11; i++)
            {
                if ((pionki[i].aktywny) && (wybor.r == pionki[i].r) && (wybor.w == pionki[i].w))
                    return true;
            }
            return false;
        }
        bool Przesun(Pionek wybor, Pionek cel)
        {


            for (int j = 0; j <= 11; j++)
            {
                if ((pionki[wybor.gracz][j].aktywny) && (wybor.r == pionki[wybor.gracz][j].r) && (wybor.w == pionki[wybor.gracz][j].w))
                {

                    if (wybor.god)
                    {
                        Pionek w = wybor;
                        Pionek c = cel;
                        Pionek bicie;


                        bicie = new Pionek(1);


                        if (!((w.r == c.r) || (w.w == c.w)))

                        {

                            int opt = 0;
                            //znajduje rodzaj ukosu
                            for (int i = 1; i <= 7; i++)
                            {
                                if ((w.w + i == c.w) && (w.r + i == c.r)) opt = 1;
                                if ((w.w + i == c.w) && (w.r - i == c.r)) opt = 2;
                                if ((w.w - i == c.w) && (w.r + i == c.r)) opt = 3;
                                if ((w.w - i == c.w) && (w.r - i == c.r)) opt = 4;
                            }
                            if (opt == 0) return false;

                            //czy nie ma swojego pionka na trasie i jedno bicie
                            int bic = 0;
                            for (int i = 1; i <= Math.Abs(w.w - c.w); i++)
                            {
                                if (opt == 1) if (plansza[w.w + i][w.r + i].zajete)
                                        if (plansza[w.w + i][w.r + i].gracz != w.gracz)
                                            if (bic < 1)
                                            {
                                                bicie.UstPoz(w.w + i, w.r + i);
                                                bic++;
                                            }

                                if (opt == 2) if (plansza[w.w + i][w.r - i].zajete)
                                        if (plansza[w.w + i][w.r - i].gracz != w.gracz)
                                            if (bic < 1)
                                            {
                                                bicie.UstPoz(w.w + i, w.r - i);
                                                bic++;
                                            }

                                if (opt == 3) if (plansza[w.w - i][w.r + i].zajete)
                                        if (plansza[w.w - i][w.r + i].gracz != w.gracz)
                                            if (bic < 1)
                                            {
                                                bicie.UstPoz(w.w - i, w.r + i);
                                                bic++;
                                            }
                                if (opt == 4) if (plansza[w.w - i][w.r - i].zajete)
                                        if (plansza[w.w - i][w.r - i].gracz != w.gracz)
                                            if (bic < 1)
                                            {
                                                bicie.UstPoz(w.w - i, w.r - i);
                                                bic++;
                                            }

                            }
                            if (!Wolny(w)) if (bic != 1) return false;
                            if (Wolny(w)) if (bic != 0) return false;
                            Bij(bicie.w, bicie.r);
                        }
                        else if (!Wolny(wybor)) return false;
                    }

                    pionki[wybor.gracz][j].UstPoz(cel.w, cel.r);
                    Awans(pionki[wybor.gracz][j]);

                    WczytajPlansze();
                    return true;
                }
            }

            return false;
        }
        bool Awans(Pionek p)
        {
            if (!p.god)
                if (!seria)
                    if (p.gracz == 0)
                    {
                        if (p.w == 7)
                        {
                            p.god = true;
                            lk[0]++;
                        }
                    }

                    else if (p.w == 0)
                    {
                        p.god = true;
                        lk[1]++;
                    }
            return false;
        }

      public  void Kopia(Gra g)
        {
            kolej = g.kolej;//nr gracza ktory ma wykonac ruch
            seria = g.seria;
            wygrany = g.wygrany;
            koniec = g.koniec;
            lp[0] = g.lp[0];
            lp[1] = g.lp[1];

            pionki = new Pionek[2][];

            pionki[0] = new Pionek[12];
            pionki[1] = new Pionek[12];

            for (int j = 0; j <= 1; j++)
            {       
                for (int i = 0; i <= 11; i++)
                    pionki[j][i]=new Pionek (g.pionki[j][i]);
            }
                           
    
        }


    }


}
    

