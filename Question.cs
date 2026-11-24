using System;
using System.Collections.Generic;
using System.Text;

namespace CSToolsFinal
{
    public class Question
    {
        String text;
        String answer;
        String choice1;
        String choice2;
        String choice3;
        String choice4;

        public Question()
        {
            this.text = "";
            this.answer = "";
            this.choice1 = "";
            this.choice2 = "";
            this.choice3 = "";
            this.choice4 = "";
        }

        public Question(String text, String answer, String c1, String c2, String c3, String c4)
        {
            this.text = text;
            this.answer = answer;
            this.choice1 = c1;
            this.choice2 = c2;
            this.choice3 = c3;
            this.choice4 = c4;
        }
    }
}
