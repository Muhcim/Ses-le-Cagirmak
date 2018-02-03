using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
namespace Ses_İle_Çağırmak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SpeechRecognitionEngine recoEngine = new SpeechRecognitionEngine();

        SpeechSynthesizer speechSymn = new SpeechSynthesizer();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             pictureBox1.Visible = false;
            sestanıma_ayarları();
           
            recoEngine.RecognizeAsync();
        }
        void sestanıma_ayarları()
        {
            string[] ihtimaller = { "Merhaba ", "Hello", "Tolga", "Muzik", "Pop" };
            Choices seçenekler = new Choices(ihtimaller);
            Grammar grammer = new Grammar(new GrammarBuilder(seçenekler));
            recoEngine.LoadGrammar(grammer);
            recoEngine.SetInputToDefaultAudioDevice();
            recoEngine.SpeechRecognized += ses_tanıdığında;         
        
        }

        void ses_tanıdığında(object sender, SpeechRecognizedEventArgs e)
        {
            pictureBox1.Visible = true;

            MessageBox.Show(e.Result.Text);
        }
    }
}
//Baslaman once bilgisayarimizi ingilizce olarak baslatiyoruz 