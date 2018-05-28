using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warcaby
{
    public partial class Warcaby : Form
    {
        Gra gra;
        Image pionek1, pionek2, krolowa1, krolowa2;

        bool trwa;
        bool wybrano;
        Pionek wybor;//ruszany pionek   
        Pionek w,c; //cel dla pionka
        
        void Wynik()
        {
            wynik0.Text =gra.lp[0].ToString();
            wynik1.Text = gra.lp[1].ToString();

            if (gra.koniec) { trwa = false; label1.Text = "!!!Koniec gry!!!"; }
        }
        void OdsPlansze()
        {
            void ResetObrazkow()
            {
                button1.BackgroundImage = null;
                button2.BackgroundImage = null;
                button3.BackgroundImage = null;
                button4.BackgroundImage = null;
                button5.BackgroundImage = null;
                button6.BackgroundImage = null;
                button7.BackgroundImage = null;
                button8.BackgroundImage = null;
                button9.BackgroundImage = null;
                button10.BackgroundImage = null;
                button11.BackgroundImage = null;
                button12.BackgroundImage = null;
                button13.BackgroundImage = null;
                button14.BackgroundImage = null;
                button15.BackgroundImage = null;
                button16.BackgroundImage = null;
                button17.BackgroundImage = null;
                button18.BackgroundImage = null;
                button19.BackgroundImage = null;
                button20.BackgroundImage = null;
                button21.BackgroundImage = null;
                button22.BackgroundImage = null;
                button23.BackgroundImage = null;
                button24.BackgroundImage = null;
                button25.BackgroundImage = null;
                button26.BackgroundImage = null;
                button27.BackgroundImage = null;
                button28.BackgroundImage = null;
                button29.BackgroundImage = null;
                button30.BackgroundImage = null;
                button31.BackgroundImage = null;
                button32.BackgroundImage = null;
                button33.BackgroundImage = null;
                button34.BackgroundImage = null;
                button35.BackgroundImage = null;
                button36.BackgroundImage = null;
                button37.BackgroundImage = null;
                button38.BackgroundImage = null;
                button39.BackgroundImage = null;
                button40.BackgroundImage = null;
                button41.BackgroundImage = null;
                button42.BackgroundImage = null;
                button43.BackgroundImage = null;
                button44.BackgroundImage = null;
                button45.BackgroundImage = null;
                button46.BackgroundImage = null;
                button47.BackgroundImage = null;
                button48.BackgroundImage = null;
                button49.BackgroundImage = null;
                button50.BackgroundImage = null;
                button51.BackgroundImage = null;
                button52.BackgroundImage = null;
                button53.BackgroundImage = null;
                button54.BackgroundImage = null;
                button55.BackgroundImage = null;
                button56.BackgroundImage = null;
                button57.BackgroundImage = null;
                button58.BackgroundImage = null;
                button59.BackgroundImage = null;
                button60.BackgroundImage = null;
                button61.BackgroundImage = null;
                button62.BackgroundImage = null;
                button63.BackgroundImage = null;
                button64.BackgroundImage = null;
            }
            void UstawPionki()
            {
                button1.BackgroundImage = UstawPole(7, 0);
                button2.BackgroundImage = UstawPole(7, 1);
                button3.BackgroundImage = UstawPole(7, 2);
                button4.BackgroundImage = UstawPole(7, 3);
                button5.BackgroundImage = UstawPole(7, 4);
                button6.BackgroundImage = UstawPole(7, 5);
                button7.BackgroundImage = UstawPole(7, 6);
                button8.BackgroundImage = UstawPole(7, 7);
                button9.BackgroundImage = UstawPole(6, 0);
                button10.BackgroundImage = UstawPole(6, 1);
                button11.BackgroundImage = UstawPole(6, 2);
                button12.BackgroundImage = UstawPole(6, 3);
                button13.BackgroundImage = UstawPole(6, 4);
                button14.BackgroundImage = UstawPole(6, 5);
                button15.BackgroundImage = UstawPole(6, 6);
                button16.BackgroundImage = UstawPole(6, 7);
                button17.BackgroundImage = UstawPole(5, 0);
                button18.BackgroundImage = UstawPole(5, 1);
                button19.BackgroundImage = UstawPole(5, 2);
                button20.BackgroundImage = UstawPole(5, 3);
                button21.BackgroundImage = UstawPole(5, 4);
                button22.BackgroundImage = UstawPole(5, 5);
                button23.BackgroundImage = UstawPole(5, 6);
                button24.BackgroundImage = UstawPole(5, 7);
                button25.BackgroundImage = UstawPole(4, 0);
                button26.BackgroundImage = UstawPole(4, 1);
                button27.BackgroundImage = UstawPole(4, 2);
                button28.BackgroundImage = UstawPole(4, 3);
                button29.BackgroundImage = UstawPole(4, 4);
                button30.BackgroundImage = UstawPole(4, 5);
                button31.BackgroundImage = UstawPole(4, 6);
                button32.BackgroundImage = UstawPole(4, 7);
                button33.BackgroundImage = UstawPole(0, 7);
                button34.BackgroundImage = UstawPole(0, 6);
                button35.BackgroundImage = UstawPole(0, 5);
                button36.BackgroundImage = UstawPole(0, 4);
                button37.BackgroundImage = UstawPole(0, 3);
                button38.BackgroundImage = UstawPole(0, 2);
                button39.BackgroundImage = UstawPole(0, 1);
                button40.BackgroundImage = UstawPole(0, 0);
                button41.BackgroundImage = UstawPole(1, 7);
                button42.BackgroundImage = UstawPole(1, 6);
                button43.BackgroundImage = UstawPole(1, 5);
                button44.BackgroundImage = UstawPole(1, 4);
                button45.BackgroundImage = UstawPole(1, 3);
                button46.BackgroundImage = UstawPole(1, 2);
                button47.BackgroundImage = UstawPole(1, 0);
                button48.BackgroundImage = UstawPole(1, 1);
                button49.BackgroundImage = UstawPole(2, 1);
                button50.BackgroundImage = UstawPole(2, 2);
                button51.BackgroundImage = UstawPole(2, 3);
                button52.BackgroundImage = UstawPole(2, 4);
                button53.BackgroundImage = UstawPole(2, 5);
                button54.BackgroundImage = UstawPole(2, 6);
                button55.BackgroundImage = UstawPole(2, 7);
                button56.BackgroundImage = UstawPole(2, 0);
                button57.BackgroundImage = UstawPole(3, 7);
                button58.BackgroundImage = UstawPole(3, 6);
                button59.BackgroundImage = UstawPole(3, 5);
                button60.BackgroundImage = UstawPole(3, 4);
                button61.BackgroundImage = UstawPole(3, 3);
                button62.BackgroundImage = UstawPole(3, 2);
                button63.BackgroundImage = UstawPole(3, 1);
                button64.BackgroundImage = UstawPole(3, 0);
            }
            Image UstawPole(int w, int r)
            {
                if (gra.plansza[w][r].zajete == true)
                {
                    if (gra.plansza[w][r].gracz == 0)
                        if (!gra.plansza[w][r].krolowa)
                            return pionek1;
                        else return krolowa1;
                    if (gra.plansza[w][r].gracz == 1)
                        if (!gra.plansza[w][r].krolowa)
                            return pionek2;
                        else return krolowa2;


                }
                return null;
            }

            ResetObrazkow();
            UstawPionki();
            Wynik();
        }
        void Cel()    
        {

            c.w = wybor.w;
            c.r = wybor.r;
            c.gracz = gra.plansza[wybor.w][wybor.r].gracz;
            c.god = gra.plansza[wybor.w][wybor.r].krolowa;

        }
        void Wyb()
        {
            w.w = wybor.w;
            w.r = wybor.r;
            w.gracz = gra.plansza[wybor.w][wybor.r].gracz;
            w.god = gra.plansza[wybor.w][wybor.r].krolowa;
        }
        void InfoWyb()
        {
            label4.Text = "";
            wybor.gracz = gra.plansza[wybor.w][wybor.r].gracz;
            if (gra.plansza[wybor.w][wybor.r].zajete)
                if (gra.Wolny(wybor)) label4.Text += "wolny";
                else label4.Text += "bij";
           
        }
        void ObslugaPlanszy(int opt=0)
        {
            
            if ((opt == 0)&&(trwa))
            {



                if ((gra.plansza[wybor.w][wybor.r].zajete)&& (!gra.seria))
                {   
                    wybrano = true;
                    Wyb();
                    InfoWyb();
                }
                else { 
                    InfoWyb();
                if (wybrano)
                {
                    Cel();

                    if (gra.Ruch(w, c))
                        if (gra.seria)
                        {
                            w.r = c.r;
                            w.w = c.w;
                        }


                    if (gra.seria)
                        wybrano = true;
                    else
                        wybrano = false;

                    OdsPlansze();

                    if (gra.kolej == 0)
                    {
                        label3.Text = "Twoja kolej";
                        label2.Text = "Czekaj";
                    }
                    else
                    {
                        label2.Text = "Twoja kolej";
                        label3.Text = "Czekaj";
                    }
                }}
                
            }
            if (opt == 2)//wznownienie
            {
                wybrano = false;
            }
            if (opt == 3)//zatrzymanie
            {
                trwa = true;
            }
            if (opt == 1)//przyciska start
            {
                gra = new Gra();
                
                trwa = false;
                button66.Text = "Start";
                label1.Text = "Gra wstrzymana";

                wybrano = false;
               
                OdsPlansze();
            }
        


        }
        public Warcaby()
        {
            InitializeComponent();
            pionek1=Image.FromFile("graphics/p1.png"); 
            pionek2 =Image.FromFile("graphics/p2.png");
            krolowa1 = Image.FromFile("graphics/k1.png");
            krolowa2 = Image.FromFile("graphics/k2.png");

           

            gra = new Gra();
            OdsPlansze();
            wybor = new Pionek(0);
            c = new Pionek(0);
            w = new Pionek(0);
            wybrano = false;
            label3.Text = "Twoja kolej";
            label2.Text = "Czekaj";
            label4.Text = "";
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           wybor.UstPoz(7, 0); ObslugaPlanszy();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(5, 4); ObslugaPlanszy();
        }

        private void button32_Click(object sender, EventArgs e)
        {
           
           wybor.UstPoz(4, 7); ObslugaPlanszy();
        }

        private void button33_Click(object sender, EventArgs e)
        {
           
           wybor.UstPoz(0, 7); ObslugaPlanszy();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            
           wybor.UstPoz(3, 0); ObslugaPlanszy();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
          wybor.UstPoz(7, 5); ObslugaPlanszy();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            
             wybor.UstPoz(3, 3); ObslugaPlanszy();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            
           wybor.UstPoz(2, 2); ObslugaPlanszy();
        }

        private void button40_Click(object sender, EventArgs e)
        {
           
           wybor.UstPoz(0, 0); ObslugaPlanszy();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            
            ObslugaPlanszy(1);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ObslugaPlanszy();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ObslugaPlanszy();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            if (trwa == false) {
                trwa = true;
                button66.Text = "Stop";
                label1.Text = "Trwa gra";
            }
            else  {
                trwa = false;
                button66.Text = "Start";
                label1.Text = "Gra wstrzymana";
            }
            ObslugaPlanszy(2);
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           wybor.UstPoz(7, 1); ObslugaPlanszy();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(7, 2); ObslugaPlanszy();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wybor.UstPoz(7, 3); ObslugaPlanszy();
        }

        private void button5_Click(object sender, EventArgs e)
        {
             wybor.UstPoz(7, 4); ObslugaPlanszy();
        }

        private void button7_Click(object sender, EventArgs e)
        {
             wybor.UstPoz(7, 6); ObslugaPlanszy();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           wybor.UstPoz(7, 7); ObslugaPlanszy();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            wybor.UstPoz(6, 0); ObslugaPlanszy();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           wybor.UstPoz(6, 1); ObslugaPlanszy();
        }

        private void button11_Click(object sender, EventArgs e)
        {
           wybor.UstPoz(6, 2); ObslugaPlanszy();
        }

        private void button12_Click(object sender, EventArgs e)
        {
           wybor.UstPoz(6, 3); ObslugaPlanszy();
        }

        private void button13_Click(object sender, EventArgs e)
        {
           wybor.UstPoz(6, 4); ObslugaPlanszy();
        }

        private void button14_Click(object sender, EventArgs e)
        {
          wybor.UstPoz(6, 5); ObslugaPlanszy();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            wybor.UstPoz(6, 6); ObslugaPlanszy();
        }

        private void button16_Click(object sender, EventArgs e)
        {
             wybor.UstPoz(6, 7); ObslugaPlanszy();
        }

        private void button17_Click(object sender, EventArgs e)
        {
           wybor.UstPoz(5, 0); ObslugaPlanszy();
        }

        private void button18_Click(object sender, EventArgs e)
        {
             wybor.UstPoz(5, 1); ObslugaPlanszy();
        }

        private void button19_Click(object sender, EventArgs e)
        {
             wybor.UstPoz(5, 2); ObslugaPlanszy();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            wybor.UstPoz(5, 3); ObslugaPlanszy();
        }

        private void button22_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(5, 5); ObslugaPlanszy();
        }

        private void button23_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(5, 6); ObslugaPlanszy();
        }

        private void button24_Click(object sender, EventArgs e)
        {
          
             wybor.UstPoz(5, 7); ObslugaPlanszy();
        }

        private void button25_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(4, 0); ObslugaPlanszy();
        }

        private void button26_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(4, 1); ObslugaPlanszy();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            
            wybor.UstPoz(4, 2); ObslugaPlanszy();
        }

        private void button28_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(4, 3); ObslugaPlanszy();
        }

        private void button29_Click(object sender, EventArgs e)
        {
           
             wybor.UstPoz(4, 4); ObslugaPlanszy();
        }

        private void button30_Click(object sender, EventArgs e)
        {
           
             wybor.UstPoz(4, 5); ObslugaPlanszy();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            
            wybor.UstPoz(4, 6); ObslugaPlanszy();
        }

        private void button63_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(3, 1); ObslugaPlanszy();
        }

        private void button62_Click(object sender, EventArgs e)
        {
           
           wybor.UstPoz(3, 2); ObslugaPlanszy();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            wybor.UstPoz(3, 4); ObslugaPlanszy();
        }

        private void button59_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(3, 5); ObslugaPlanszy();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            
             wybor.UstPoz(3, 7); ObslugaPlanszy();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            
            wybor.UstPoz(2, 0); ObslugaPlanszy();
        }

        private void button49_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(2, 1); ObslugaPlanszy();
        }

        private void button51_Click(object sender, EventArgs e)
        {
           
          wybor.UstPoz(2, 3); ObslugaPlanszy();
        }

        private void button52_Click(object sender, EventArgs e)
        {
           
             wybor.UstPoz(2, 4); ObslugaPlanszy();
        }

        private void button53_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(2, 5); ObslugaPlanszy();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            
           wybor.UstPoz(2, 6); ObslugaPlanszy();
        }

        private void button55_Click(object sender, EventArgs e)
        {
           
           wybor.UstPoz(2, 7); ObslugaPlanszy();
        }

        private void button47_Click(object sender, EventArgs e)
        {
           
         wybor.UstPoz(1, 0); ObslugaPlanszy();
        }

        private void button48_Click(object sender, EventArgs e)
        {
           
          wybor.UstPoz(1, 1); ObslugaPlanszy();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            
             wybor.UstPoz(1, 2); ObslugaPlanszy();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            
            wybor.UstPoz(1, 3); ObslugaPlanszy();
        }

        private void button44_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(1, 4); ObslugaPlanszy();
        }

        private void button43_Click(object sender, EventArgs e)
        {
           
             wybor.UstPoz(1, 5); ObslugaPlanszy();
        }

        private void button42_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(1, 6); ObslugaPlanszy();
        }

        private void button41_Click(object sender, EventArgs e)
        {
          
           wybor.UstPoz(1, 7); ObslugaPlanszy();
        }

        private void button39_Click(object sender, EventArgs e)
        {
           
           wybor.UstPoz(0, 1); ObslugaPlanszy();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            
           wybor.UstPoz(0, 2); ObslugaPlanszy();
        }

        private void button37_Click(object sender, EventArgs e)
        {
           
             wybor.UstPoz(0, 3); ObslugaPlanszy();
        }

        private void button36_Click(object sender, EventArgs e)
        {
          
            wybor.UstPoz(0, 4); ObslugaPlanszy();
        }

        private void button35_Click(object sender, EventArgs e)
        {
           
            wybor.UstPoz(0, 5); ObslugaPlanszy();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {
            
           wybor.UstPoz(0, 6); ObslugaPlanszy();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button58_Click(object sender, EventArgs e)
        {
           
             wybor.UstPoz(3, 6); ObslugaPlanszy();
        }
    }
}
