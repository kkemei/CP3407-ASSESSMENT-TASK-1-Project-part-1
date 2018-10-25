using System;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;



namespace Wilderness_Weather_Station
{
    public partial class Home : Form
    {
        const string APPID = "8537c81f4e28567a004122c1b81937d6";
        string cityName = "Brisbane";


        public Home()
        {
            InitializeComponent();
            getWeather(cityName);
        }

        void getWeather(string city)
        {
            using(WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=6",cityName, APPID);

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<weatherInfo.root>(json);

                weatherInfo.root outPut = result;
                
                lblCityName.Text = string.Format("{0}", outPut.name);
                lblCountry.Text = string.Format("{0}", outPut.sys.country);
                lblTemp.Text = string.Format("{0}", outPut.main.temp);

            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.ShowDialog();
            this.Close();
        }
    }
}
