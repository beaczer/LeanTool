using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Excercise
{
    [ServiceContract (Namespace ="http://MyCompany.com")]
    public interface IEightBall
    {
        [OperationContract]
        // Missing XML comment for publicly visible type or member
        string ObtainAnswerToQuestion(string userQuestion);

    }

    public class MagicEightBallService : IEightBall
    {
        //tylko okno hosta
        public MagicEightBallService()
        {
            Console.WriteLine("The 8 Ball awaits your question");
        }
        public string ObtainAnswerToQuestion(string userQuestion)
        {
            string[] answers = { "Future Uncertain", "Yes", "No", "Hazy", "Ask again later", "Definitly" };
            //zmienna losowa
            Random r = new Random();
            return answers[r.Next(answers.Length)];
        }
    }
}
