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
        //string cityName = "Townsville";


        public Home(string station)
        {
            string cityName = station;
            InitializeComponent();
            getWeather(station);
        }

        void getWeather(string station)
        {
            string cityName = station;

            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=6", cityName, APPID);

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<weatherInfo.root>(json);

                weatherInfo.root outPut = result;

                lblCityName.Text = string.Format("{0}", outPut.name);
                lblCountry.Text = string.Format("{0}", outPut.sys.country);
                lblTemp.Text = string.Format("{0} \u00B0" + "C", outPut.main.temp);
                lblLong.Text = string.Format("{0}\u00B0", outPut.coord.lon);
                lblLat.Text = string.Format("{0}\u00B0", outPut.coord.lat);
                lblWindSpeed.Text = string.Format("{0} m/s", outPut.wind.speed);
                lblWindDir.Text = string.Format("{0}\u00B0", outPut.wind.deg);
                lblPressure.Text = string.Format("{0} Pa", outPut.main.pressure);
                lblHumidity.Text = string.Format("{0} %", outPut.main.humidity);
                label4.Text = string.Format("{0} Weather Station", outPut.name);
            }
        }

        private void WriteToExcel(int i, int j, string s)
        {
            i++;
            j++;
            WindowState.Cells[i, j].Vlaue2 = s;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.ShowDialog();
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            
        }
    }
}
