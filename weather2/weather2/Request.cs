using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace weather2
{
    class Request
    {
        public static string Name;
        public static float Temp;
        public void Main(object city)
        {

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=4f592b2566721ec99b69bb95df24da9a";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            Console.WriteLine($"{weatherResponse.Main.Temp}, {weatherResponse.Name}");
            Temp = weatherResponse.Main.Temp;
            Name = weatherResponse.Name;

        }
    }
}
