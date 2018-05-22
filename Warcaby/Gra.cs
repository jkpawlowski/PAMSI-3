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
       public pole() { zajete = false; }
    }
        class Gra
        {
            public pole[][] plansza;

            //********pionki graczy***
            private Pionek[] pionki1;
            private Pionek[] pionki2;
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

                for (int i = 0; i <= 11; i++)
                {
                    plansza[pionki1[i].w][pionki1[i].r].zajete = true;
                    plansza[pionki1[i].w][pionki1[i].r].gracz = 1;

                    plansza[pionki2[i].w][pionki2[i].r].zajete = true;
                    plansza[pionki2[i].w][pionki2[i].r].gracz = 2;

                }




            }
            void UstawPionki()
            {
                pionki1 = new Pionek[12];
            for (int i = 0; i <= 11; i++)
                pionki1[i] = new Pionek();

                pionki1[0].UstPoz(0, 0);
                pionki1[1].UstPoz(0, 2);
                pionki1[2].UstPoz(0, 4);
                pionki1[3].UstPoz(0, 6);
                pionki1[4].UstPoz(1, 1);
                pionki1[5].UstPoz(1, 3);
                pionki1[6].UstPoz(1, 5);
                pionki1[7].UstPoz(1, 7);
                pionki1[8].UstPoz(2, 0);
                pionki1[9].UstPoz(2, 2);
                pionki1[10].UstPoz(2, 4);
                pionki1[11].UstPoz(2, 6);


               
            pionki2 = new Pionek[12];
            for (int i = 0; i <= 11; i++)
                pionki2[i] = new Pionek();

            pionki2[0].UstPoz(5, 1);
                pionki2[1].UstPoz(5, 3);
                pionki2[2].UstPoz(5, 5);
                pionki2[3].UstPoz(5, 7);
                pionki2[4].UstPoz(6, 0);
                pionki2[5].UstPoz(6, 2);
                pionki2[6].UstPoz(6, 4);
                pionki2[7].UstPoz(6, 6);
                pionki2[8].UstPoz(7, 1);
                pionki2[9].UstPoz(7, 3);
                pionki2[10].UstPoz(7, 5);
                pionki2[11].UstPoz(7, 7);











            }
            public Gra()
            {
            UstawPionki();
            WczytajPlansze();
                
            }
        }
    }

