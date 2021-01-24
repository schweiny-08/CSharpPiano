using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Threading;

namespace PianoApp
{
    class MusicStaff : Panel
    {
        private int tempo;
        private string shape;
        private int pitch;
        private double duration;
        
        private MusicNote mn;
        private Form1 form1;
        private List<MusicNote> Notes = new List<MusicNote>();
        private SoundPlayer sp = new SoundPlayer();
        private MusicNote currentNotePlaying;

        private Thread t;

        public MusicStaff()
        {
            tempo = 0;
            t = new Thread(PlayThread);
            form1 = new Form1();
        }

        public void setList(List<MusicNote> msl)
        {
            //Sets list when loaded
            Notes = msl;
        }

        public void PlayMelody(List<MusicNote> notes) {
            //Play all notes on music staff
            Notes = notes;

            if (!t.IsAlive) {
                t = new Thread(PlayThread);
            }
            t.Start();
        }

        private void PlayThread() {
            //Thread to play melody
            foreach (MusicNote mn in Notes)
            {
                mn.PlayNote();
                currentNotePlaying = mn;
                Thread.Sleep(tempo);
            }
            t.Abort();
        }

        public void PauseMelody() {
            //Stops playing melody thread
            t.Abort();
            currentNotePlaying.StopPlaying();

        }

        public bool IsThreadAlive() {
            //Returns if thread is active
            return t.IsAlive;
        }

        public void AdjustTempo(int tempoSize, int tempoIndex) {
            //Adjusts tempo (Grave/Largo/Lento/Adagio/Andante/Moderato/Allegro/Presto)
            int bpm = 0;
            switch(tempoIndex){
                case 0:
                    bpm = 30;
                    break;
                case 1:
                    bpm = 50;
                    break;
                case 2:
                    bpm = 60;
                    break;
                case 3:
                    bpm = 70;
                    break;
                case 4:
                    bpm = 90;
                    break;
                case 5:
                    bpm = 110;
                    break;
                case 6:
                    bpm = 120;
                    break;
                case 7:
                    bpm = 200;
                    break;
            }

            tempo = 60000 / bpm;
        }     

        public void save(Label notificationMessage, List<MusicNote> iNotes, string fileName)
        {
            //Saved melody currently on staff
            notificationMessage.Text = "";
            string path = Environment.CurrentDirectory + "\\Melodies/" + fileName + ".txt";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            if(iNotes.Count != 0)
            {
                FileStream Out = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(Out))
                {
                    Out.SetLength(0);
                    for (int i = 0; i <= iNotes.Count - 1; i++)
                    {
                        sw.WriteLine(iNotes[i].noteShape);
                        sw.WriteLine(iNotes[i].noteDuration);
                        sw.WriteLine(iNotes[i].pitch);
                    }
                    sw.Close();
                }
                notificationMessage.Text = "Melody \"" + fileName + "\" saved!";
            }
            else
            {
                notificationMessage.Text = "No melody to save. Load a melody or create a new one using the piano.";
            }
        }

        public List<MusicNote> load(Label notificationMessage, Panel panel2, PictureBox staffPB, string fileName)
        {
            //Loads selected melody on staff
            Notes.Clear();
            notificationMessage.Text = "";
            string path = Environment.CurrentDirectory + "\\Melodies/" + fileName + ".txt";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            FileStream In = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader sr = new StreamReader(In))
            {
                
                while ((shape = sr.ReadLine()) != null)
                {
                    duration = double.Parse(sr.ReadLine());
                    pitch = int.Parse(sr.ReadLine());

                    mn = new MusicNote(pitch, duration, shape);
                    Notes.Add(mn);

                    
                    staffPB.Controls.Add(mn);
                    panel2.Controls[panel2.Controls.Count - 1].BringToFront();
                    Form1.xLoc += 35;
                }
                sr.Close();
            }

            if(Notes.Count != 0)
            {
                notificationMessage.Text = "Melody \"" + fileName + "\" loaded!";
                return Notes;
            }
            else
            {
                notificationMessage.Text = "No melody to load. Create a new melody using the piano.";
                return null;
            }
        }

        public void delete(Label notificationMessage, string fileName)
        {
            //Deletes current saved melody
            notificationMessage.Text = "";
            string path = Environment.CurrentDirectory + "\\Melodies\\";
            string filePath = Environment.CurrentDirectory + "\\Melodies\\" + fileName + ".txt";

            File.Delete(filePath);
            notificationMessage.Text = "Melody \"" + fileName + "\" deleted!";
        }
    }
}
