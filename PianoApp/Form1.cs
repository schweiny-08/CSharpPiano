using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace PianoApp
{
    public partial class Form1 : Form
    {
        PictureBox staffPB = new PictureBox();
        List<MusicNote> Notes = new List<MusicNote>();

        int count = 0;
        int xLoc = 50;
        int yLoc = 30;
        string note = "";
        private SoundPlayer sp = new SoundPlayer();

        private static System.Timers.Timer timer1;
        int[] whitePitch = { 1, 3, 5, 6, 8, 10, 12, 13, 15, 17, 18, 20, 22, 24, 25 };
        int[] blackPitch = { 2, 4, 7, 9, 11, 14, 16, 19, 21, 23 };
        int[] xPos = { 10, 30, 70, 90, 110, 150, 170, 210, 230, 250 };

        public Form1()
        {
            InitializeComponent();
            timer1 = new System.Timers.Timer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MusKey mk;
            BlackMusKey bmk;

            //White Key
            for (int k = 0; k <= 14; k++)
            {
                int pitch = whitePitch[k];
                int xPos = k * 20;
                mk = new MusKey(pitch, xPos, 50);
                mk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
                mk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(mk);
            }

            //Black Key
            int xOffs = 20;
            for (int k = 0; k < 10; k++)
            {
                int pitch = blackPitch[k];
                int xPos = this.xPos[k];
                bmk = new BlackMusKey(pitch, xPos, 50);
                bmk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
                bmk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(bmk);
                this.panel1.Controls[this.panel1.Controls.Count - 1].BringToFront();
            }

            //Music Staff

            Bitmap staff = Properties.Resources.Staff2;
            Bitmap bar = Properties.Resources.Bar;

            
            panel2.Controls.Add(staffPB);
            staffPB.Width = staff.Width;
            staffPB.Height = staff.Height;
            staffPB.BorderStyle = BorderStyle.FixedSingle;
            staffPB.Image = staff;

            //staffPB.Controls.Add(bar);
        }


        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (MusKey mk in this.panel1.Controls)
                if (sender == mk)
                    if (e.Button == MouseButtons.Left)
                    {
                        timer1.Enabled = true;
                        count = 0;
                        timer1.Start();

                        note = mk.notePitch.ToString() + ".wav";

                        switch (note)
                        {
                            case "1.wav":
                                sp.Stream = Properties.Resources._1;
                                break;
                            case "2.wav":
                                sp.Stream = Properties.Resources._2;
                                break;
                            case "3.wav":
                                sp.Stream = Properties.Resources._3;
                                break;
                            case "4.wav":
                                sp.Stream = Properties.Resources._4;
                                break;
                            case "5.wav":
                                sp.Stream = Properties.Resources._5;
                                break;
                            case "6.wav":
                                sp.Stream = Properties.Resources._6;
                                break;
                            case "7.wav":
                                sp.Stream = Properties.Resources._7;
                                break;
                            case "8.wav":
                                sp.Stream = Properties.Resources._8;
                                break;
                            case "9.wav":
                                sp.Stream = Properties.Resources._9;
                                break;
                            case "10.wav":
                                sp.Stream = Properties.Resources._10;
                                break;
                            case "11.wav":
                                sp.Stream = Properties.Resources._11;
                                break;
                            case "12.wav":
                                sp.Stream = Properties.Resources._12;
                                break;
                            case "13.wav":
                                sp.Stream = Properties.Resources._13;
                                break;
                            case "14.wav":
                                sp.Stream = Properties.Resources._14;
                                break;
                            case "15.wav":
                                sp.Stream = Properties.Resources._15;
                                break;
                            case "16.wav":
                                sp.Stream = Properties.Resources._16;
                                break;
                            case "17.wav":
                                sp.Stream = Properties.Resources._17;
                                break;
                            case "18.wav":
                                sp.Stream = Properties.Resources._18;
                                break;
                            case "19.wav":
                                sp.Stream = Properties.Resources._19;
                                break;
                            case "20.wav":
                                sp.Stream = Properties.Resources._20;
                                break;
                            case "21.wav":
                                sp.Stream = Properties.Resources._21;
                                break;
                            case "22.wav":
                                sp.Stream = Properties.Resources._22;
                                break;
                            case "23.wav":
                                sp.Stream = Properties.Resources._23;
                                break;
                            case "24.wav":
                                sp.Stream = Properties.Resources._24;
                                break;
                            case "25.wav":
                                sp.Stream = Properties.Resources._25;
                                break;
                            default:
                                Console.WriteLine("Default case");
                                break;
                        }

                        sp.Play();
                    }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count = count++;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (MusKey mk in this.panel1.Controls)
            {
                if (sender == mk)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        timer1.Enabled = false;
                        sp.Stop();
                        string bNoteShape = null;
                        int duration = 0;
                        if (count >= 16)
                        {
                            bNoteShape = "SemiBreve";
                            duration = 16;
                        }
                        if ((count >= 11) && (count <= 15))
                        {
                            bNoteShape = "DotMinim";
                            duration = (11 + 15) / 2;
                        }
                        if ((count >= 6) && (count <= 10))
                        {
                            bNoteShape = "Minim";
                            duration = (6 + 10) / 2;
                        }
                        if ((count >= 3) && (count <= 5))
                        {
                            bNoteShape = "Crotchet";
                            duration = (3 + 5) / 2;
                        }
                        if (count == 2)
                        {
                            bNoteShape = "Quaver";
                            duration = 2;
                        }
                        if (count <= 1)
                        {
                            bNoteShape = "SemiQuaver";
                            duration = 1;
                        }

                        //Adding music note to staff 
                        MusicNote mn = new MusicNote(mk.notePitch, duration, bNoteShape, xLoc);
                        mn.Location = new Point(xLoc, yLoc);
                        this.panel2.Controls.Add(mn);
                        this.panel2.Controls[this.panel2.Controls.Count - 1].BringToFront();
                        Notes.Add(mn);
                        xLoc += 40;
                        Console.WriteLine("BUTTON PRESSED:" + mk.notePitch + "NOTES SIZE:" + Notes.Count + "XLOCATION:" + xLoc);
                        //mn.BackColor = Color.Transparent;
                    }
                }
            }
        }
    }
}
