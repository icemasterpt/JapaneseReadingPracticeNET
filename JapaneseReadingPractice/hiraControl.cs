using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//controlo para ser usado apenas para Hiragana
namespace JapaneseReadingPractice
{
    public class hiraControl
    {
        private Dictionary<String, String> hiraDict,hiraDictvowelsOnly, hiraDictAccents;
        private List<String> ListOfSyllabs;
        private Random random;

        private List<String> generatedString;
        public hiraControl()
        {
            random = new Random();
            this.hiraDict = new Dictionary<String, String>();
        
            this.hiraDict.Add("a", "あ");
            this.hiraDict.Add("e", "え");
            this.hiraDict.Add("i", "い");
            this.hiraDict.Add("o", "お");
            this.hiraDict.Add("u", "う");
            this.hiraDict.Add("ka", "か");
            this.hiraDict.Add("ke", "け");
            this.hiraDict.Add("ki", "き");
            this.hiraDict.Add("ko", "こ");
            this.hiraDict.Add("ku", "く");
            this.hiraDict.Add("na", "な");
            this.hiraDict.Add("ne", "ね");
            this.hiraDict.Add("ni", "に");
            this.hiraDict.Add("no", "の");
            this.hiraDict.Add("nu", "ぬ");
            this.hiraDict.Add("ma", "ま");
            this.hiraDict.Add("me", "め");
            this.hiraDict.Add("mi", "み");
            this.hiraDict.Add("mo", "も");
            this.hiraDict.Add("mu", "む");
            this.hiraDict.Add("wa", "わ");
            this.hiraDict.Add("wo", "を");
            this.hiraDict.Add("sa", "さ");
            this.hiraDict.Add("se", "せ");
            this.hiraDict.Add("shi", "し");
            this.hiraDict.Add("so", "そ");
            this.hiraDict.Add("su", "す");
            this.hiraDict.Add("ha", "は");
            this.hiraDict.Add("he", "へ");
            this.hiraDict.Add("hi", "ひ");
            this.hiraDict.Add("ho", "ほ");
            this.hiraDict.Add("hu", "ふ");
            this.hiraDict.Add("ra", "ら");
            this.hiraDict.Add("re", "れ");
            this.hiraDict.Add("ri", "り");
            this.hiraDict.Add("ro", "ろ");
            this.hiraDict.Add("ru", "る");
            this.hiraDict.Add("chi", "ち");

            //sillabs

            ListOfSyllabs = new List<string>();


            ListOfSyllabs.Add("a");
            ListOfSyllabs.Add("e" );
            ListOfSyllabs.Add("i" );
            ListOfSyllabs.Add("o" );
            ListOfSyllabs.Add("u" );
            ListOfSyllabs.Add("ka");
            ListOfSyllabs.Add("ke");
            ListOfSyllabs.Add("ki");
            ListOfSyllabs.Add("ko");
            ListOfSyllabs.Add("ku");
            ListOfSyllabs.Add("wa");
            ListOfSyllabs.Add("wo");
            ListOfSyllabs.Add("ha");
            ListOfSyllabs.Add("he");
            ListOfSyllabs.Add("hi");
            ListOfSyllabs.Add("ho");
            ListOfSyllabs.Add("shi");
            ListOfSyllabs.Add("chi");
            ListOfSyllabs.Add("na");
            ListOfSyllabs.Add("ne");
            ListOfSyllabs.Add("ni");
            ListOfSyllabs.Add("no");
            ListOfSyllabs.Add("nu");
            ListOfSyllabs.Add("ra");
            ListOfSyllabs.Add("re");
            ListOfSyllabs.Add("ri");
            ListOfSyllabs.Add("ro");
            ListOfSyllabs.Add("ru");

            //setup new list of strings to be compared later during the main program
            this.generatedString = new List<string>();


        }

        /*Generates a random string that will be used*/
        private string getRandomSyllab()
        {
           
            int ammountOfSyllabs = this.ListOfSyllabs.Count;
            int index = random.Next(0, ammountOfSyllabs);
            string syllab = this.ListOfSyllabs[index];



            return syllab;
        }

        public List<String> generateString(int size)
        {
            //primeiro, apaga-se tudo o que se encontra na lista
            this.generatedString.Clear();
            List<String> strings = new List<string>();

            for (int i = 0; i<=size; i++)
            {
                String k = getRandomSyllab();
                strings.Add(k);

            }
            return strings;

        }

        public string formStringFromSyllabs(List<String> syllabs)
        {
            String FinalString = "";
            foreach (String k in syllabs)
            {
                FinalString += k;
            }
            return FinalString;
        }

        public string fromHiraganaStringFromSyllabs(List<String> syllabs)
        {
            String FinalString = "";
            foreach (String k in syllabs)
            {
                FinalString += hiraDict[k];
            }
            return FinalString;
        }



    }
}



