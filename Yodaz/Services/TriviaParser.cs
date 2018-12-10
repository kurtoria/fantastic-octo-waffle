using System;
namespace Yodaz.Services
{
    public class TriviaParser
    {
        public TriviaParser()
        {

            HTTPWebRequest hTTPWebRequest = new HTTPWebRequest();
            var result = hTTPWebRequest.SendRequest();

            Console.WriteLine(result);
        }

        // Ansvarar för att hämta responset från HTTPwebReguest 
        // Och skapa upp en lista med triva-object som returneras till QuizViewModel
    }
}
