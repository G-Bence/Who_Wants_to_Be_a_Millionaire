using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Who_Wants_to_Be_a_Millionaire
{
    internal class Game
    {
        private string playerName; //?
        private int playerLevel;
        private All_The_Questions allTheQuestions;

        public Game(All_The_Questions questions) {
            //this.playerName = playerName;
            this.playerLevel = 0;
            this.allTheQuestions = questions;
        }

        //Generate Question, and RowQuestion(?), Hellping options and LOGIC
        public void GenerateRowQuestion()
        {
            
        }

    }
}
