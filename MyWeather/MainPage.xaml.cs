using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace MyWeather
{
    public partial class MainPage : ContentPage
    {
        const string API = "b4d4a9bf3fe7b14e4f457215474d9895";
        public MainPage()
        {
            InitializeComponent();
        }

        private async void getWeather_Clicked(object sender, EventArgs e)
        {
            string city = userInput.Text.Trim();
            if (city.Length < 2 )
            {
                await DisplayAlert("Error", "City used to be bigger", "Ok :(");
                return;
            }

            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API}&units=metric";
            string response = await client.GetStringAsync(url);

            var json = JObject.Parse(response);
            string temp = json["main"]["temp"].ToString();
            resultLabel.Text = "Температура сейчас: " + temp;
        }
    }
}
