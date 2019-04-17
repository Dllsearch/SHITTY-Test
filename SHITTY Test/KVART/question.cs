using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHITTYTEST
{
    [Serializable]
    public class question // вопросики (тест)
    {
        public bool initialised { get; set; }
        public bool pics { get; set; }
        public string questiontext { get; set; }
        public string[] answerstext { get; set; }
        public bool[] trueanswer { get; set; }
        public Image questionpic { get; set; }
        public Image[] answerspic {get; set;}
        public enum questiontypes
        {
            radio,
            check,
            text
        }
        public questiontypes qtype { get; set; }

        public question()
            {
            initialised = initialised;
            questiontext = questiontext;
            answerstext = answerstext;
            trueanswer = trueanswer;
            qtype = qtype;
            questionpic = questionpic;
            answerspic = answerspic;
            pics = pics;
            }

        public void initialDude(int dudes)
        {
            questiontext = "QUESTION TEXT";
            answerstext = new string[dudes];
            trueanswer = new bool[dudes];
            answerspic = new Bitmap[dudes];
            qtype = questiontypes.radio;
            questionpic = null;
            pics = false;
            for (int qq = 0; qq < dudes; qq++)
            {
                answerspic[qq] = null;
                answerstext[qq] = "ANSWER " + (1 + qq);
                trueanswer[qq] = false;
            }
            initialised = true;
        } 
    }
}
