using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        List<Image> imageList = new List<Image>();
        List<Image> imageIcons = new List<Image>();

        public CurrentScreen()
        {
            InitializeComponent();

            Image rainImage = Properties.Resources.Rainy;
            Image sunnyImage = Properties.Resources.Sunny;
            Image cloudyImage = Properties.Resources.Cloudy;
            Image snowyImage = Properties.Resources.Snowy;
            Image mistImage = Properties.Resources.Mist;
            Image thunderImage = Properties.Resources.Thunder;

            imageList.Add(rainImage);
            imageList.Add(sunnyImage);
            imageList.Add(cloudyImage);
            imageList.Add(snowyImage);
            imageList.Add(mistImage);
            imageList.Add(thunderImage);

            Image rainIcon = Properties.Resources.Rainy_Icon;
            Image sunnyIcon = Properties.Resources.Sunny_Icon;
            Image cloudyIcon = Properties.Resources.Cloudy_Icon;
            Image snowyIcon = Properties.Resources.Snowy_icon;
            Image mistIcon = Properties.Resources.Mist_Icon;
            Image thunderIcon = Properties.Resources.Thunder_Icon;

            imageIcons.Add(rainIcon);
            imageIcons.Add(sunnyIcon);
            imageIcons.Add(cloudyIcon);
            imageIcons.Add(snowyIcon);
            imageIcons.Add(mistIcon);
            imageIcons.Add(thunderIcon);

            WeatherBackground();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = Form1.days[0].location;
            tempLabel.Text = Form1.days[0].currentTemp + "°";
            weatherIcon.Text = Form1.days[0].condition;
            minOutput.Text = Form1.days[0].tempLow + "°";
            maxOutput.Text = Form1.days[0].tempHigh + "°";
            currentDate.Text = Form1.days[0].date;
        }

        public void WeatherBackground()
        {
            int conditionCode = Convert.ToInt32(Form1.days[0].condition);

            if (conditionCode >= 500 && conditionCode <= 531) //Raining
            {
                this.BackgroundImage = imageList[0];
                weatherIcon.BackgroundImage = imageIcons[0];
            }

            else if (conditionCode == 800) //Sunny
            {
                this.BackgroundImage = imageList[1];
                weatherIcon.BackgroundImage = imageIcons[1];
            }

            else if (conditionCode >= 801 && conditionCode <= 804) //Cloudy
            {
                this.BackgroundImage = imageList[2];
                weatherIcon.BackgroundImage = imageIcons[2];
            }

            else if (conditionCode >= 600 && conditionCode <= 622) //Snowy
            {
                this.BackgroundImage = imageList[3];
                weatherIcon.BackgroundImage = imageIcons[3];
            }

            else if (conditionCode >= 701 && conditionCode <= 781) //Mist
            {
                this.BackgroundImage = imageList[4];
                weatherIcon.BackgroundImage = imageIcons[4];
            }

            else if (conditionCode >= 200 && conditionCode <= 232) //Thudner
            {
                this.BackgroundImage = imageList[5];
                weatherIcon.BackgroundImage = imageIcons[5];
            }

        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
