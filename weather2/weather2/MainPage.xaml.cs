using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

            Request request = new Request();
            WeatherResponse weatherResponse = new WeatherResponse();
            string city = entry1.Text;

            Thread myThread = new Thread(new ParameterizedThreadStart(request.Main));
            myThread.Start(city);
            Thread t = Thread.CurrentThread;
            myThread.Join(500);

            label1.Text = $"{Math.Round(Request.Temp, 1)}°C";
            label2.Text = $"{Request.Name}";
        }
    }
}
