using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        public async void updateWeather()
        {
            try
            {
                string apiUrl = "https://api.openweathermap.org/data/2.5/weather?q=Ho%20Chi%20Minh,VN&appid=fb49c80acdd04a605e233baf6576bb4d&units=metric";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic data = JObject.Parse(json);

                        // Extract weather information from 'data' here
                        string temperature = data.main.temp;
                        string weatherDescription = data.weather[0].description;
                        string weather = data.weather[0].main;

                        // Update your form controls with the weather information
                        lbThoiTiet.Text = $"{weather}";
                        lbNhietDo.Text = $"{temperature}°C";
                        lbMoTa.Text = $"{weatherDescription}";
                    }
                    else
                    {
                        MessageBox.Show("Failed to fetch weather data.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            updateWeather();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateWeather();
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
