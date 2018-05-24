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
            

            public pole[][] plansza;

            //********pionki graczy***
            private Pionek[][] pionki;
        
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
                for(int j=0;j<2;j++)
                for (int i = 0; i <= 11; i++)
                {
                if (pionki[j][i].aktywny)
                {    plansza[pionki[j][i].w][pionki[j][i].r].zajete = true;
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
                
            }

        void PrzKolej()
        {
            if (kolej == 0) { kolej = 1; }
            else kolej = 0;
        
        
        }
        bool Wolny(Pionek p) //czy nie musi niczego bić
        {
            if((p.w >= 2) && (p.r >= 2))
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


        
            return true;
        }
        bool Bij(int w,int r)
        {
            for(int j=0;j<=1;j++)
            for (int i = 0; i <= 11; i++)
                if ((pionki[j][i].aktywny) &&(pionki[j][i].w == w) && (pionki[j][i].r == r))
                {
                    pionki[j][i].Zabij();
                    return true;
                }
          
            return false;
        }
        bool Moze(Pionek w,Pionek c)
        {
            if (Math.Abs(w.w - c.w) == 1)
                if (Math.Abs(w.r - c.r) == 1)
                    return true;
            if (Math.Abs(w.w - c.w) == 2)
                if (Math.Abs(w.r - c.r) == 2)
                    if (plansza[(w.w + c.w) / 2][(w.r + c.r) / 2].gracz != kolej)//sprawdza czy zjadzie bicie
                    {
                        Bij((w.w + c.w) / 2, (w.r + c.r) / 2);

                        return true;
                    }
            return false;
        }
        bool DoPrzodu(Pionek w,Pionek c)
        {
            if (w.god) return true;
            if (w.gracz == 0) if (c.w > w.w) return true;
            if (w.gracz == 1) if (c.w < w.w) return true;

            return false;
        }
        public bool Ruch(Pionek wybor,Pionek cel)
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
                            if(DoPrzodu(wybor,cel))
                            if (Przesun(wybor, cel))
                            {
                                PrzKolej(); //koniec ruchu jezeli nie ma mozliwosci bicia
                                return true;
                            }
                        }
                        else
                        {
                            if (plansza[(wybor.w + cel.w) / 2][(wybor.r + cel.r) / 2].zajete==true)
                            if (plansza[(wybor.w + cel.w) / 2][(wybor.r + cel.r) / 2].gracz!=wybor.gracz)
                                if (Przesun(wybor, cel))
                            {
                                if (Wolny(cel)) PrzKolej(); //koniec ruchu jezeli nie ma mozliwosci bicia
                                return true;
                            }
                        }
                    
                    
                }
            } 
            return false;
        }
        bool ZnajdzPionek(Pionek wybor,Pionek[] pionki)
        {
            for(int i = 0; i <= 11; i++)
            {
                if ((pionki[i].aktywny) && (wybor.r == pionki[i].r) && (wybor.w == pionki[i].w))
                    return true;
            }
            return false;
        }
        bool Przesun(Pionek wybor, Pionek cel)
        {
           

            for (int i = 0; i <= 11; i++)
            {
                if ((pionki[wybor.gracz][i].aktywny) && (wybor.r == pionki[wybor.gracz][i].r) && (wybor.w == pionki[wybor.gracz][i].w))
                {
                    pionki[wybor.gracz][i].UstPoz(cel.w, cel.r);
                    Awans(pionki[wybor.gracz][i]);
                    WczytajPlansze();
                    return true;
                }
            }

            return false;
        }
        bool Awans(Pionek p)
        {
            if (!p.god)
                if (Wolny(p))
                    if (p.gracz == 0) { if (p.w == 7) p.god = true;
                    }
                    else if (p.gracz == 1) if (p.w == 0) p.god = true;
            return false;
        }
        }
    }

