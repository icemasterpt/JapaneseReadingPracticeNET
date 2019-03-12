using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace JapaneseReadingPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
  
    public partial class MainWindow : Window
    {

        public Timer t1 = new Timer();
        public hiraControl hiraganaC;
        public String result = "";
        public String resultRomanji = "";
        public int currentTime = 0;

        //Controller Vars
        public int LastTime = 0;
        public float totalTime = 0.00001f;
        public int TotalTries = 0;
        public int NumCorrect = 0;
        private bool inGame = false;

        public MainWindow()
        {
            InitializeComponent();
            hiraganaC = new hiraControl();
            if (TotalTries > 0)
                lbScreen_Copy.Content = "Stats: Answer Correct :" + NumCorrect.ToString() + " Success Rate: " + (NumCorrect / TotalTries).ToString() + " average time: " + (totalTime / TotalTries).ToString();
            else
                lbScreen_Copy.Content = "Stats: Answer Correct :" + NumCorrect.ToString() + " : Not enough data to create a statistic!";

            t1.Tick += T1_Tick;
            t1.Interval = 1000;
        }

        public bool performTest(String a, String b)
        {
            if (a == b)
            {
                return true;
            }
            else
                return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (inGame)
            {
                //do nothing lol
            }
            else
            {
                //make it ingame
                inGame = true;
                //start the timer!
                lbScreen.FontSize = 50;

                t1.Start();

                List<String> listOfStrings = hiraganaC.generateString(4);
                lbScreen.Content = hiraganaC.fromHiraganaStringFromSyllabs(listOfStrings);
                resultRomanji = hiraganaC.formStringFromSyllabs(listOfStrings);
                result = hiraganaC.formStringFromSyllabs(listOfStrings);
            }
        }

        private void T1_Tick(object sender, EventArgs e)
        {
            currentTime++;
            lbStat.Content = currentTime.ToString();
        }

   

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            String resposta = InPutBox.Text.ToString();
            

            if (resposta.Equals(resultRomanji) && inGame)
            {
                t1.Stop();
                lbStat.Content = "STOP!";
                TotalTries++;
                lbScreen.Content ="SUCCESS!! you took " + currentTime.ToString() + " seconds!";
                totalTime += currentTime;
                currentTime = 0;
                lbStat.Content = currentTime.ToString();
                InPutBox.Clear();
                NumCorrect++;
                inGame = false;
            }
            else if (inGame)
            {
                t1.Stop();
               
                lbStat.Content = "STOP!";
                TotalTries++;
                lbScreen.FontSize = 30;
                lbScreen.Content="wrong " + currentTime.ToString() + " seconds!\n answer: "+ resultRomanji+"\n you said: "+resposta;
                totalTime += currentTime;
                currentTime = 0;
                lbStat.Content = currentTime.ToString();
                InPutBox.Clear();
                inGame = false;
            }
            else if(!inGame)
            {
                MessageBox.Show("You must generate a question first!");
            }
            if (TotalTries > 0)
                lbScreen_Copy.Content = "Stats: Answer Correct :" + NumCorrect.ToString() + " Success Rate: " + Convert.ToDouble((NumCorrect/TotalTries)*100).ToString("0.00") + " average time: " + Convert.ToInt16(totalTime / TotalTries).ToString("0.0");
        }
    }
}
