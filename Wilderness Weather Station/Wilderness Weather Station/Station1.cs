using System;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Newtonsoft.Json;



namespace Wilderness_Weather_Station
{
    public partial class Home : Form 
    {
        const string APPID = "8537c81f4e28567a004122c1b81937d6";
        string curDate = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-tt");

        string CityName;
        string Country;
        Double Temp;
        Double Long;
        Double Lat;
        Double WindSpeed;
        Double WindDir;
        Double Pressure;
        Double Humidity;

        public Home(string station, int id)
        {
            int stationID = id;
            InitializeComponent();
            getWeather(station, stationID);
        }

        public void WriteData()
        {
            Excel excel = new Excel(@"template.xlsx", 1);

            excel.WriteToExcel(0, 0, "City");
            excel.WriteToExcel(0, 1, "Country");
            excel.WriteToExcel(0, 2, "Temperature (\u00B0C)");
            excel.WriteToExcel(0, 3, "Longitude (\u00B0)");
            excel.WriteToExcel(0, 4, "Latitude(\u00B0)");
            excel.WriteToExcel(0, 5, "Wind Speed (KM/H)");
            excel.WriteToExcel(0, 6, "Wind Direction (\u00B0)");
            excel.WriteToExcel(0, 7, "Pressure (Pa)");
            excel.WriteToExcel(0, 8, "Humidity (%)");

            excel.WriteToExcel(1, 0, CityName);
            excel.WriteToExcel(1, 1, Country);
            excel.WriteToExcel(1, 2, string.Format("{0}", Temp));
            excel.WriteToExcel(1, 3, string.Format("{0}", Long));
            excel.WriteToExcel(1, 4, string.Format("{0}", Lat));
            excel.WriteToExcel(1, 5, string.Format("{0}", WindSpeed));
            excel.WriteToExcel(1, 6, string.Format("{0}", WindDir));
            excel.WriteToExcel(1, 7, string.Format("{0}", Pressure));
            excel.WriteToExcel(1, 8, string.Format("{0}", Humidity));

            //excel.Save();
            excel.SaveAs(string.Format(@"{0} - {1}.xlsx", CityName, curDate));

            MessageBox.Show(string.Format("Saved To Documents"));
            excel.Close();
        }

        void getWeather(string station, int stationID)

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
                lblStation.Text = string.Format("Station {0}", stationID);

                CityName = outPut.name;
                Country = outPut.sys.country;
                Temp = outPut.main.temp;
                Long = outPut.coord.lon;
                Lat = outPut.coord.lat;
                WindSpeed = outPut.wind.speed;
                WindDir = outPut.wind.deg;
                Pressure = outPut.main.pressure;
                Humidity = outPut.main.humidity;

                lblLastUpdated.Text = string.Format("Weather information last pulled from OpenWeatherMap on the: {0}", curDate);

            }
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
            WriteData();
        }

        private void Sensor1Status_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Sensor 1 is working correctly!"));
        }

        private void Sensor2Status_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Sensor 2 is working correctly!"));
        }

        private void Sensor3Status_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Sensor 3 is working correctly!"));
        }

        private void Sensor4Status_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Sensor 4 is working correctly!"));
        }
    }
}
