using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(click);


        }
        bool go = true;
        int counter = 0;

        
        private void click(object sender, KeyEventArgs e)
        {
            string a = e.KeyCode.ToString();

            if (go)
            {
                switch (a)
                {
                    case "Up":
                        player.Location = new Point(player.Location.X, player.Location.Y - 12);

                        break;
                    case "Down":
                        player.Location = new Point(player.Location.X, player.Location.Y + 12);

                        break;
                    case "Right":

                        player.Location = new Point(player.Location.X + 12, player.Location.Y);

                        break;
                    case "Left":
                        player.Location = new Point(player.Location.X - 12, player.Location.Y);
                        break;
                }

            }


            foreach (Control x in this.Controls)
            {
                if (x is Label && (string)x.Tag == "stena")
                {
                    
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer2.Start();
                        timer2.Interval = 1000;
                        game_over();
                       
                        
                    }
                }
                if (x is PictureBox && (string)x.Tag == "almaz") 
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                                x.Visible = false;
                                Controls.Remove(x);
                                counter++;

                        string name = counter.ToString() + "/5";
                        label1.Text = name;
                    }
                }
                if(x is Label && (string)x.Tag == "finish")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        win();
                    }
                }
                if(x is PictureBox && (string)x.Tag == "bomba")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        (x as PictureBox).Image = Project2.Properties.Resources.bomba2;
                        x.BackColor = Color.Transparent;
                        


                        player.Visible = false;
                        timer2.Start();
                        timer2.Interval = 1000;
                        

                    }
                }
            }

            
        }
      private void win()
        {
            player.Visible = false;
           
            
            Visible = false;
            Winner a = new Winner();
            a.label1.Text = "Ваш счёт: " + counter.ToString() + "/5";
            a.ShowDialog();
            
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 15;
            timer1.Start();
            
            

        }
        private void game_over()
        {
            timer2.Stop();
            go = false;
            player.Visible = false;
            timer1.Stop();
            
           
           
            Visible = false;
            GameOver g = new GameOver();
            g.label1.Text = "Ваш счёт: " + counter.ToString() + "/5";

            g.ShowDialog();
            
            Application.Exit();
            
        }

        int x1 = 485, y1 = 80, x2 = 430, y2 = 338, x3 = 205, y3 = 10, x4 = 8, y4 = 170, x5 = 310, y5 = 205, x6 = 586, y6 = 217, x7 = 96, y7 = 422;

        private void timer2_Tick(object sender, EventArgs e)
        {
            game_over();
        }

      

        bool right1 = true, top2 = true, right3 = true, right4 = true, top5 = true, right6 = true, top7 = false;
        
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (x1 <= 660 && right1)
            {
                x1++;
                pictureBox1.Location = new Point(x1, y1);
                right1 = true;
                if (x1 == 660) right1 = false;
            }
            else if(x1 >= 485 && !right1)
            {
                x1--;
                pictureBox1.Location = new Point(x1, y1);
                right1 = false;
                if (x1 == 485) right1 = true;
            }

        if(top2 && y2 <= 338)
            {
                y2--;
                pictureBox2.Location = new Point(x2, y2);
                if (y2 == 210) top2 = false;
            } else if(y2 <= 338 && !top2)
            {
                y2++;
                pictureBox2.Location = new Point(x2, y2);
                if (y2 == 338) top2 = true;
            }
        if(right3 && x3 <= 505)
            {
                x3++;
                pictureBox3.Location = new Point(x3, y3);
                if (x3 == 505) right3 = false;
            } else if(!right3 && x3 <= 505)
            {
                x3--;
                pictureBox3.Location = new Point(x3, y3);
                if (x3 == 205) right3 = true;
            }
        if(x4 <= 230 && right4)
            {
                x4++;
                pictureBox4.Location = new Point(x4, y4);
                if (x4 == 230) right4 = false;
            } else if(!right4 && x4 <= 230)
            {
                x4--;
                pictureBox4.Location = new Point(x4, y4);
                if (x4 == 8) right4 = true;
            }
            if (top5 && y5 <= 420)
            {
                y5++;
                pictureBox5.Location = new Point(x5, y5);
                if (y5 == 420) top5 = false;
            } else if(!top5 && y5 <= 420)
            {
                y5--;
                pictureBox5.Location = new Point(x5, y5);
                if (y5 == 207) top5 = true;
            }
            if (right6 && x6 <= 744)
            {
                x6++;
                pictureBox8.Location = new Point(x6, y6);
                if (x6 == 744) right6 = false;
            }
            else
            {
                x6--;
                pictureBox8.Location = new Point(x6, y6);
                if (x6 == 586) right6 = true;
            }
            if (top7 && y7 <= 422)
            {
                y7++;
                pictureBox7.Location = new Point(x7, y7);
                if (y7 == 422) top7 = false;
            } else if(!top7 && y7 <= 422)
            {
                y7--;
                pictureBox7.Location = new Point(x7, y7);
                if (y7 == 308) top7 = true;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "bomba")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        (x as PictureBox).Image = Project2.Properties.Resources.bomba2;
                        x.BackColor = Color.Transparent;
                        player.Visible = false;
                        timer2.Start();
                        timer2.Interval = 1000;

                    }
                }
            }
        }
    }
}
