using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
//using System.Threading;
//using NAudio.Wave.SampleProviders;

namespace PianoApp
{
    public partial class TestForm : Form
    {
        private SoundPlayer player = new SoundPlayer(Properties.Resources.a0);
        //private var soundFile = new AudioFileReader(Properties.Resources.a0);
        //private var trimmed = new OffserSampleProvider();

        public TestForm()
        {
            InitializeComponent();
        }
        

        private void TestForm_Load(object sender, EventArgs e)
        {
            
            player.Load();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //player.Play();
            //Console.WriteLine(e.ToString());
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            player.Play();
            //player.PlayLooping();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            player.Stop();
            //Console.WriteLine("Up");
        }
    }
}
