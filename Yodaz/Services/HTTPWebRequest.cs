using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Yodaz.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace Yodaz.Services
{
    public class HTTPWebRequest
    {
        //public string Number { get; set; }
        public static List<Trivia> Trivias = new List<Trivia>();
        public string Url = "";

        private static string GetUrl(int nr)
        {
            return "https://opentdb.com/api.php?amount=" + nr.ToString() + "&type=boolean";
        }

        //public static void GetTrivia(int number)
        //{
        //    HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(GetUrl(number)));
        //    WebReq.Method = "GET";

        //    HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

        //    Console.WriteLine("---------------------------");
        //    Console.WriteLine(WebResp.StatusCode);
        //    Console.WriteLine(WebResp.Server);

        //    string jsonString;
        //    using (Stream stream = WebResp.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
        //        jsonString = reader.ReadToEnd();
        //    }
        //    string trimStartString = jsonString.TrimStart('{', '"', 'r', 'e', 's', 'p', 'o', 'n', 's', 'e', '_', 'c', 'o', 'd', 'e', ':', '0', ',', 'u', 'l', 't', 's');
        //    string trimEndString = trimStartString.TrimEnd('}');

        //    try
        //    {
        //        Trivias = JsonConvert.DeserializeObject<List<Trivia>>(trimEndString);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("\n");
        //        Console.WriteLine("ISSUE: " + e);
        //    }
        //}


        public static void GetTrivia(int number)
        {
            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(GetUrl(number)));
            //WebReq.Method = "GET";

            //HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            //Console.WriteLine("---------------------------");
            //Console.WriteLine(WebResp.StatusCode);
            //Console.WriteLine(WebResp.Server);

            //string jsonString;
            //using (Stream stream = WebResp.GetResponseStream())
            //{
            //    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            //    jsonString = reader.ReadToEnd();
            //}
            //string trimStartString = jsonString.TrimStart('{', '"', 'r', 'e', 's', 'p', 'o', 'n', 's', 'e', '_', 'c', 'o', 'd', 'e', ':', '0', ',', 'u', 'l', 't', 's');
            //string trimEndString = trimStartString.TrimEnd('}');

            //try
            //{
            //    Trivias = JsonConvert.DeserializeObject<List<Trivia>>(trimEndString);

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("\n");
            //    Console.WriteLine("ISSUE: " + e);
            //}

            //return Trivias;





            HttpClient client = new HttpClient();
            string json = client.GetStringAsync(GetUrl(number)).Result;
            string trimStartString = json.TrimStart('{', '"', 'r', 'e', 's', 'p', 'o', 'n', 's', 'e', '_', 'c', 'o', 'd', 'e', ':', '0', ',', 'u', 'l', 't', 's');
            string trimEndString = trimStartString.TrimEnd('}');

            Trivias = JsonConvert.DeserializeObject<List<Trivia>>(trimEndString);
        }
    }
}
