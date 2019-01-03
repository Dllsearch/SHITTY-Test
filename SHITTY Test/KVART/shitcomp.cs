using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHITTYTEST
{
    [Serializable]
    public class shitcomp
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public int questionsAmount;
        public question[] questions;
        public string pathoftest = "";
        public int tamedCounter = 0;
        public int[] tamedCounterArray;
        public bool isInitialised = false;
        public int[] questionsPoints;

        public void afterInit(int qAmnt)
        {
            questionsAmount = qAmnt;
            questions = new question[qAmnt];
            questionsPoints = new int[qAmnt];
            for (int n=0; n<qAmnt;n++)
            {
                questionsPoints[n] = 1;
            }
        }
    }
}
