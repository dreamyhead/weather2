using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace weather2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            string city = entry1.Text.Trim(' ');
            
            Request(city);
        }

        public async void Request(string city)
        {
            await Task.Run(() =>
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


                Device.BeginInvokeOnMainThread(() =>
                {
                    if (weatherResponse.Main.Temp >= 0)
                        labelDegree.Text = $"+{Math.Round(weatherResponse.Main.Temp, 1)}°C";
                    else
                        labelDegree.Text = $"{Math.Round(weatherResponse.Main.Temp, 1)}°C";

                    labelCity.Text = $"{weatherResponse.Name}";
                    labelPressure.Text = $"Pressure: {weatherResponse.Main.Pressure} mbar";
                    labelVisibility.Text = $"Visibility: {Math.Round(weatherResponse.Visibility / 1000, 1)} km";
                    labelHumidity.Text = $"Humidity: {weatherResponse.Main.Humidity}%";
                });
            });
        }
    }
}
