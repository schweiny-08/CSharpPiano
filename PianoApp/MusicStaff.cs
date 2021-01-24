using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Reflection;

using System.Media;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PianoApp
{
    class MusicStaff : Panel
    {

        List<MusicNote> lNote; //, Notes;
        MusicNote mn;
        Form1 form1;

        public Button playButton;// = new Button();

        //ComboBox tempo = new ComboBox();
        int tempo;
        string shape;
        public int pitch;
        double duration;
        string path;
        Button saveButton;// = new Button();
        Button loadButton;// = new Button();

        private List<MusicNote> Notes = new List<MusicNote>();
        private SoundPlayer sp = new SoundPlayer();
        private MusicNote currentNotePlaying;

        private Thread t;


        public MusicStaff()
        {
            lNote = new List<MusicNote>();
            tempo = 0;
            t = new Thread(PlayThread);

            form1 = new Form1();
            //mn = new MusicNote(pitch, duration, shape);
        }

        //public void PlayOneNote() {

            //Play music note on mouse left click
        //}

       /* public MusicStaff() {
            tempo = 0;
            t = new Thread(PlayThread);
        }
*/
        public void PlayMelody(List<MusicNote> notes) {
            //Play all notes on music staff
            Notes = notes;

            if (!t.IsAlive) {
                t = new Thread(PlayThread);
            }

            t.Start();

        }

        private void PlayThread() {
            foreach (MusicNote mn in Notes)
            {
                mn.OnClickPlay();
                currentNotePlaying = mn;
                Thread.Sleep(tempo);
            }
            t.Abort();
            //PauseMelody();
            //playButton.Text = "Play";
        }

        public void PauseMelody() {
            t.Abort();
            currentNotePlaying.StopPlaying();

        }

        public bool IsThreadAlive() {
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


        public void setList(List<MusicNote> msl)
        {
            Notes = msl;
        }

        public void save(Label notificationMessage, List<MusicNote> iNotes, string fileName)
        {
            notificationMessage.Text = "";
            string path = Environment.CurrentDirectory + "\\Melodies/" + fileName + ".txt";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            if(iNotes.Count != 0)
            {
                FileStream Out = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(Out))
                {
                    lNote.Clear();
                    Out.SetLength(0);
                    for (int i = 0; i <= iNotes.Count - 1; i++)
                    //for (int i = iNotes.Count - 1; i >= 0; i--)
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
            notificationMessage.Text = "";
            string path = Environment.CurrentDirectory + "\\Melodies/" + fileName + ".txt";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            FileStream In = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader sr = new StreamReader(In))
            {
                //int i = lNote.Count();
                while ((shape = sr.ReadLine()) != null)
                {
                    duration = double.Parse(sr.ReadLine());
                    pitch = int.Parse(sr.ReadLine());
                    lNote.Add(new MusicNote(pitch, duration, shape));

                    mn = new MusicNote(pitch, duration, shape);
                    staffPB.Controls.Add(mn);
                    panel2.Controls[panel2.Controls.Count - 1].BringToFront();
                    Form1.xLoc += 35;
                }
                sr.Close();
            }

            if(lNote.Count != 0)
            {
                notificationMessage.Text = "Melody \"" + fileName + "\" loaded!";
                return lNote;
            }
            else
            {
                notificationMessage.Text = "No melody to load. Create a new melody using the piano.";
                return null;
            }
        }

        public void delete(Label notificationMessage, string fileName)
        {
            notificationMessage.Text = "";
            string path = Environment.CurrentDirectory + "\\Melodies\\";
            string filePath = Environment.CurrentDirectory + "\\Melodies\\" + fileName + ".txt";

            File.Delete(filePath);
            notificationMessage.Text = "Melody \"" + fileName + "\" deleted!";
        }

    }
}
