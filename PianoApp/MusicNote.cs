using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;

namespace PianoApp
{
    enum Accid
    {
        Flat,
        Sharp,
        Sole
    };

    enum MusicNoteShape
    {
        SemiBreve,
        DotMinim,
        Minim,
        Crotchet,
        Quaver,
        SemiQuaver
    };

    class MusicNote : PictureBox
    {
        //public Point Location { get; internal set; }

        SoundPlayer sp = new SoundPlayer();
        private MusicNoteShape mns;
        private ResourceManager rm = Properties.Resources.ResourceManager;
        private Stopwatch stopwatch;// = new Stopwatch();

        private int pitch, startingY = 69;
        private String noteShape;
        private bool isDragging = false;
        private Point point;
        private double noteDuration;

        //Point point;

        //private Accid _accid;

        public MusicNote(int p, double duration, String nShape, int x, int paddingCompensation) : base()
        {
            pitch = p;
            noteDuration = duration;
            noteShape = nShape;

            Location = new Point(x, this.NoteYPos(p));//-20 + paddingCompensation);

            Bitmap bmp = (Bitmap)rm.GetObject(noteShape);
            bmp = new Bitmap(bmp, new Size(30, 30));
            bmp.MakeTransparent(Color.White);
            Image = bmp;

            Size = new Size(Image.Width, Image.Height);

            BackColor = Color.Transparent;

            this.MouseDown += new MouseEventHandler(startDrag);
            this.MouseMove += new MouseEventHandler(noteDrag);
            this.MouseUp += new MouseEventHandler(stopDrag);
            this.MouseDown += new MouseEventHandler(rbStart);
            this.MouseUp += new MouseEventHandler(rbStop);
        }

        private void rbStart(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                sp.Stream = (System.IO.Stream)rm.GetObject("_" + pitch.ToString());
                stopwatch = Stopwatch.StartNew();
                sp.Play();
            }
        }

        private void rbStop(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                stopwatch.Stop();
                this.noteDuration = stopwatch.Elapsed.TotalMilliseconds / 64;
                sp.Stop();
                if (this.noteDuration > 16)
                {
                    this.noteShape = "SemiBreve";
                }
                else if ((this.noteDuration > 10) && (this.noteDuration <= 16))
                {
                    this.noteShape = "DotMinim";
                }
                else if ((this.noteDuration > 6) && (this.noteDuration <= 10))
                {
                    this.noteShape = "minim";
                }
                else if ((this.noteDuration > 2) && (this.noteDuration <= 6))
                {
                    this.noteShape = "Crotchet";
                }
                else if ((this.noteDuration > 1) && (this.noteDuration <= 2))
                {
                    this.noteShape = "Quaver";
                }
                else if (this.noteDuration <= 1)
                {
                    this.noteShape = "SemiQuaver";
                }

                Bitmap bmp = (Bitmap)rm.GetObject(noteShape);
                bmp = new Bitmap(bmp, new Size(30, 30));
                bmp.MakeTransparent(Color.White);
                Image = bmp;

                Size = new Size(Image.Width, Image.Height);

                BackColor = Color.Transparent;
            }
        }

        private void startDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                point = e.Location;
                this.Location = new Point(this.Location.X, e.Y);
            }
        }

        private void stopDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                if (this.Bottom > 99)
                    this.Top = 69;
                else if (this.Top < -3)
                    this.Top = -3;
                pitch = getPitch(this.Top);
            }
        }

        private void noteDrag(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                if (this.Top <= 69 && this.Top >= -3)
                {
                    this.Top = roundToNearest3(this.Top) + roundToNearest3(e.Y - point.Y);
                    //pitch = getPitch(this.Top);
                }
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public int roundToUpper3(double i)
        {
            return ((int)Math.Ceiling(i / 3)) * 3;
        }

        public int roundToNearest3(double i)
        {
            return ((int)Math.Round(i / 3)) * 3;
        }

        public int getPitch(int p)
        {
            int pitch = 0;

            pitch = roundToUpper3(p);

            if (p <= 69 && p > 66) //23
            {
                pitch = 1;
            }
            else if (p <= 66 && p > 63) //22
            {
                pitch = 2;
            }
            else if (p <= 63 && p > 60) //21
            {
                pitch = 3;
            }
            else if (p <= 60 && p > 57) //20
            {
                pitch = 4;
            }
            else if (p <= 57 && p > 54)
            {
                pitch = 5;
            }
            else if (p <= 54 && p > 51)
            {
                pitch = 6;
            }
            else if (p <= 51 && p > 48)
            {
                pitch = 7;
            }
            else if (p <= 48 && p > 45)
            {
                pitch = 8;
            }
            else if (p <= 45 && p > 42)
            {
                pitch = 9;
            }
            else if (p <= 42 && p > 39)
            {
                pitch = 10;
            }
            else if (p <= 39 && p > 36)
            {
                pitch = 11;
            }
            else if (p <= 36 && p > 33)
            {
                pitch = 12;
            }
            else if (p <= 33 && p > 30)
            {
                pitch = 13;
            }
            else if (p <= 30 && p > 27)
            {
                pitch = 14;
            }
            else if (p <= 27 && p > 24)
            {
                pitch = 15;
            }
            else if (p <= 24 && p > 21)
            {
                pitch = 16;
            }
            else if (p <= 21 && p > 18)
            {
                pitch = 17;
            }
            else if (p <= 18 && p > 15)
            {
                pitch = 18;
            }
            else if (p <= 15 && p > 12)
            {
                pitch = 19;
            }
            else if (p <= 12 && p > 9)
            {
                pitch = 20;
            }
            else if (p <= 9 && p > 6)
            {
                pitch = 21;
            }
            else if (p <= 6 && p > 3)
            {
                pitch = 22;
            }
            else if (p <= 3 && p > 0)
            {
                pitch = 23;
            }
            else if (p <= 0 && p > -3)
            {
                pitch = 24;
            }
            else if (p <= -3 && p > -6)
            {
                pitch = 25;
            }
            return pitch;
        }

        public void OnClickPlay()
        {
            //Play sound file for noteDuration milliseconds
            double passed = 0;
            
            bool isPlaying = false;

            sp.Stream = (System.IO.Stream)rm.GetObject("_" + pitch.ToString());
            //sp.Stop();
            stopwatch = Stopwatch.StartNew();
            sp.Play();
            isPlaying = true;

            while (isPlaying)
            {
                passed = stopwatch.Elapsed.TotalMilliseconds / 64;
                if (noteDuration <= passed)
                {
                    Console.WriteLine("IN IF");
                    Console.WriteLine(passed + " " + noteDuration);

                    sp.Stop();
                    stopwatch.Stop();
                    isPlaying = false;
                    //sp.
                }
            }

        }

        public int NoteYPos(int p)
        {
            int yPos = 0;

            yPos = startingY - ((p - 1) * 3);

            return yPos;
        }
    }
}