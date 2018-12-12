﻿using System; using System.Net; using System.IO; using Newtonsoft.Json; using Yodaz.Model; using System.Collections.Generic; using System.Threading.Tasks; using System.Net.Http;  namespace Yodaz.Services {     public class HTTPWebRequest     {
        public static List<Trivia> Trivias = new List<Trivia>();          private static string GetUrl(int number)         {             return "https://opentdb.com/api.php?amount=" + number.ToString() + "&type=boolean";         }          public static void GetTrivia(int number)         {             HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(GetUrl(number)));             WebReq.Method = "GET";             HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();              Console.WriteLine(WebResp.StatusCode);             Console.WriteLine(WebResp.Server);              string jsonString;             using (Stream stream = WebResp.GetResponseStream())             {                 StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);                 jsonString = reader.ReadToEnd();             }             string trimStartString = jsonString.TrimStart('{', '"', 'r', 'e', 's', 'p', 'o', 'n', 's', 'e', '_', 'c', 'o', 'd', 'e', ':', '0', ',', 'u', 'l', 't', 's');             string trimEndString = trimStartString.TrimEnd('}');              try             {                 Trivias = JsonConvert.DeserializeObject<List<Trivia>>(trimEndString);             }             catch (Exception e)             {                 Console.WriteLine("\n");                 Console.WriteLine("ISSUE: " + e);             }         }

        //public static async Task GetQuestions(int number)
        //{
        //    HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(GetUrl(number)));
        //    WebReq.Method = "GET";
        //    HttpWebResponse WebResp = await Task.Run(() => (HttpWebResponse)WebReq.GetResponse());

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
        //        Trivias = await Task.Run(() => JsonConvert.DeserializeObject<List<Trivia>>(trimEndString));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("\n");
        //        Console.WriteLine("ISSUE: " + e);
        //    }
        //}
    } }