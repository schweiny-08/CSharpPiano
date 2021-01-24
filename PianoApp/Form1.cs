using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace PianoApp
{
    public partial class Form1 : Form
    {
        public static int staffPBPadding = 35;
        private double count = 0;
        public static int xLoc = 0;
        private string note = "";

        private SoundPlayer sp = new SoundPlayer();
        private ComboBox cb;
        private PictureBox staffPB;
        private List<MusicNote> Notes = new List<MusicNote>();
        private MusicNote mn;
        private MusicStaff ms;
        private Stopwatch stopwatch;

        private int[] whitePitch = { 1, 3, 5, 6, 8, 10, 12, 13, 15, 17, 18, 20, 22, 24, 25 };
        private int[] blackPitch = { 2, 4, 7, 9, 11, 14, 16, 19, 21, 23 };
        private int[] xPos = { 10, 30, 70, 90, 110, 150, 170, 210, 230, 250 };

        public Form1()
        {
            InitializeComponent();
            cb = TempoMenu;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MusKey mk;
            BlackMusKey bmk;
            staffPB = new PictureBox();
            Notes = new List<MusicNote>();
            ms = new MusicStaff();
            loadComboBox();

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
            staffPB.Height = staff.Height + staffPBPadding;
            staffPB.BackColor = Color.White;
            staffPB.BorderStyle = BorderStyle.FixedSingle;
            staffPB.Image = staff;
            staffPB.Padding = new Padding(0, 40, 0, 0);
            
            //Tempo menu
            TempoMenu.Text = "Select Tempo";
            TempoMenu.SelectedIndex = 0;
        }

        private ComboBox loadComboBox()
        {
            //Controls load drop down menu
            string path = Environment.CurrentDirectory + "\\" + "Melodies/";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            string[] files = Directory.GetFiles(path);

            comboBox1.Items.Clear();
            comboBox1.Text = "";

            foreach (string file in files)
            {
                comboBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
            }

            return comboBox1;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            //Detects left mouse button down on piano key
            if (!ms.IsThreadAlive())
            {
                foreach (MusKey mk in this.panel1.Controls)
                    if (sender == mk)
                        if (e.Button == MouseButtons.Left)
                        {
                            count = 0;
                            stopwatch = Stopwatch.StartNew();

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
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            //Detects left mouse button up on piano key
            if (!ms.IsThreadAlive())
            {
                foreach (MusKey mk in this.panel1.Controls)
                {
                    if (sender == mk)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            count = stopwatch.Elapsed.TotalMilliseconds / 64;
                            
                            stopwatch.Stop();
                            sp.Stop();
                            string bNoteShape = null;
                            if (count > 16)
                            {
                                bNoteShape = "SemiBreve";                               
                            }
                            else if ((count > 10) && (count <= 16))
                            {
                                bNoteShape = "DotMinim";
                            }
                            else if ((count > 6) && (count <= 10))
                            {
                                bNoteShape = "minim";
                            }
                            else if ((count > 2) && (count <= 6))
                            {
                                bNoteShape = "Crotchet";
                            }
                            else if ((count > 1) && (count <= 2))
                            {
                                bNoteShape = "Quaver";
                            }
                            else if (count <= 1)
                            {
                                bNoteShape = "SemiQuaver";
                            }

                            this.CreateMusicNote(mk, bNoteShape);
                        }
                    }
                }
            }
        }

        public void CreateMusicNote(MusKey mk, String noteShape)
        {
            //Adding music note to staff 
            mn = new MusicNote(mk.notePitch, count, noteShape);
            staffPB.Controls.Add(mn);
            this.panel2.Controls[this.panel2.Controls.Count - 1].BringToFront();

            Notes.Add(mn);
            xLoc += mn.Width;
            Console.WriteLine("BUTTON PRESSED:" + mk.notePitch + "NOTES SIZE:" + Notes.Count + "XLOCATION:" + xLoc + "TIMERCOUNT:" + count);
        }


        private void load_Click(object sender, EventArgs e)
        {
            //Load selected saved file
            if (!ms.IsThreadAlive())
            {
                Notes.Clear();
                staffPB.Controls.Clear();
                xLoc = 0;

                if (comboBox1.SelectedItem != null)
                {
                    string melody = comboBox1.SelectedItem.ToString();
                    Notes = ms.load(notificationMessage, panel2, staffPB, melody);
                }
                else
                {
                    notificationMessage.Text = "Please select a melody to load from the drop down list.";
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            //Save current melody
            if (!ms.IsThreadAlive())
            {
                if (textBox1.Text != "")
                {
                    ms.save(notificationMessage, Notes, textBox1.Text);
                    loadComboBox();
                    comboBox1.SelectedItem = textBox1.Text;
                }
                else
                    notificationMessage.Text = "Please enter a name for the new melody.";
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //Delete current melody
            if (!ms.IsThreadAlive())
            {
                if (comboBox1.SelectedItem != null)
                {
                    string melody = comboBox1.SelectedItem.ToString();
                    ms.delete(notificationMessage, melody);
                    loadComboBox();
                    comboBox1.SelectedItem = null;
                    comboBox1.Text = null;
                    textBox1.Text = null;
                }
                else
                    notificationMessage.Text = "Please select a melody to be deleted from the drop down list.";
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            //Clear current melody
            if (!ms.IsThreadAlive())
            {
                xLoc = 0;
                Notes.Clear();
                textBox1.Clear();
                comboBox1.SelectedItem = null;
                notificationMessage.Text = null;

                staffPB.Controls.Clear();
                if (Notes != null)
                {
                    Notes.Clear();
                }
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            //Play current melody
            if (!ms.IsThreadAlive())
            { 
                Button temp = (Button)sender;
                
                ms.AdjustTempo(cb.Items.Count , cb.SelectedIndex);
                ms.PlayMelody(Notes);

                notificationMessage.Text = "Playing";
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            //Stop playing melody
            if (ms.IsThreadAlive())
            {
                ms.PauseMelody();

                notificationMessage.Text = "";
            }
        }
    }
}
