using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldireData.Models
{
    class Soldire
    {
        public string soldireNo;
        public string soldireName;
        public double scoreOne;
        public double scoreTwo;
        public double scoreThree;
        public double scoreFour;

        public double averageScore;
        public double totalScore;

        public void CalculateResult()
        {
            averageScore = (scoreOne + scoreTwo + scoreThree + scoreFour) / 4;
            totalScore = (scoreOne + scoreTwo + scoreThree + scoreFour);
        }

    }
}
