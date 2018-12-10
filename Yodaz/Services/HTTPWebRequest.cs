using System;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace Yodaz.Services
{
    public class HTTPWebRequest
    {
        private string url;

        public HTTPWebRequest()
        {
            CreateURL();
        }

        private void CreateURL() 
        {
            url = "https://opentdb.com/api.php?amount=10";
        }

        public string SendRequest() 
        {
            var request = WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                Console.WriteLine(response);
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Console.WriteLine("Response contained empty body...");
                        
                    }
                    else
                    {
                       // Console.WriteLine("Response Body: \r\n {0}", content);

                    }

                    return content;
                    //Aspect.NotNull(content);
                }
            }
        }

        // Ansvarar för att komponera upp sök-url:n via userInput, 
        // Och sen skicka en request.



    }
}
