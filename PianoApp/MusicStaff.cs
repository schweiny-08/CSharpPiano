using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoApp
{
    class MusicStaff : Panel
    {
        List<MusicNote> lNote, Notes;
        MusicNote mn;
        Form1 form1 = new Form1();
        Button playButton;// = new Button();
        //ComboBox tempo = new ComboBox();
        int tempo;
        string shape;
        public int pitch;
        double duration;
        string path;
        Button saveButton;// = new Button();
        Button loadButton;// = new Button();

        public MusicStaff()
        {
            lNote = new List<MusicNote>();
            //mn = new MusicNote(pitch, duration, shape);
        }

        public void PlayOneNote() {
            //Play music note on mouse left click
        }

        public void PlayMelody() { 
            //Play all notes on music staff
        }

        public void AdjustTempo() {
            //Adjusts tempo (Grave/Largo/Lento/Adagio/Andante/Moderato/Allegro/Presto)
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
