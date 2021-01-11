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
            //sp.SoundLocation = @"C:\Users\schem\OneDrive\Desktop\Desktop\Software Development\Year 2 Semester 1\CIS2201 - OOP (Java and C# for .NET)\Assignment\Piano\Piano\Resources";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MusKey mk;
            BlackMusKey bmk;
            for (int k = 0; k <= 14; k++)
            {
                int pitch = whitePitch[k];
                int xPos = k * 20;
                mk = new MusKey(pitch, xPos, 50);
                mk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
                mk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(mk);
            }

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
                        //sp.SoundLocation = mk.notePitch.ToString() + ".wav";
                        //sp.SoundLocation = @"C:\Users\schem\OneDrive\Desktop\Desktop\Software Development\Year 2 Semester 1\CIS2201 - OOP (Java and C# for .NET)\Assignment\Piano\Piano\Resources\" + mk.notePitch.ToString() + ".wav";
                        //sp.SoundLocation = Properties.Resources.mk.notePitch;
                        //sp.SoundLocation = @"Properties\Resources.resx\" + mk.notePitch.ToString() + ".wav";
                        note = mk.notePitch.ToString() + ".wav";
                        //string location = Properties.Resources.ResourceManager.GetString(note);
                        //sp.SoundLocation = location;
                        //var location = Properties.Resources.ResourceManager.GetString(note);
                        sp.SoundLocation = Properties.Resources.ResourceManager.GetString(note);
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
                            bNoteShape = "SemiBrave";
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


                        MusicNote mn = new MusicNote(mk.notePitch, duration, bNoteShape);
                        mn.Location = new Point(xLoc, yLoc);
                        //this.panel2.Controls.Add(this.mn);
                        xLoc = xLoc + 15;
                    }
                }
            }
        }
    }
}
