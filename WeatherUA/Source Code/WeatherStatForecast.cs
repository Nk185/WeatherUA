/*
 * Application:    WeatherUA
 * Solution:       WeatherUA
 * Copyright:      Nk185
 * Code copyright: Nk185
 * File version:   1.4.3.0
 * Used external packages: 
 *      Galasoft - MVVM;
 *      Newtonsoft - JSON;
 */

using System;

namespace WeatherUA.Source_Code
{
    public class WeatherStatForecast
    {
        private string _skyStat = "N/A";
        private string _windDirection = "N/A";
        private string _weekdayShrt = "N/A";
        private int _temperatureCH = 0;
        private int _temperatureFH = 0;
        private int _temperatureCL = 0;
        private int _temperatureFL = 0;
        private uint _windSpeedKph = 0;
        private uint _windSpeedMph = 0;
        private uint _day = 0;

        public string SkyStat { get { return _skyStat; } set { _skyStat = value; } }
        public string WindDirection { get { return "Wind direction: " + _windDirection; } set { _windDirection = value; } }
        public uint Day { get { return _day; } set { _day = value; } }
        public string WeekdayShrt { get { return _weekdayShrt; } set { _weekdayShrt = value; } }

        public string TemperatureH
        {
            get
            {
                return "High: " + _temperatureCH.ToString() + "°C / "
                       + _temperatureFH.ToString() + "°F";
            }
        }
        public string TemperatureL
        {
            get
            {
                return "Low: " + _temperatureCL.ToString() + "°C / "
                       + _temperatureFL.ToString() + "°F";
            }
        }
        public string Wind
        {
            get
            {
                return "Wind speed: " + _windSpeedKph.ToString() + " km/h | "
                       + _windSpeedMph.ToString() + " mph";
            }
        }

        public int TemperatureCH { set { _temperatureCH = value; } }
        public int TemperatureFH { set { _temperatureFH = value; } }
        public int TemperatureCL { set { _temperatureCL = value; } }
        public int TemperatureFL { set { _temperatureFL = value; } }


        public uint WindSpeedKph { set { _windSpeedKph = value; } }
        public uint WindSpeedMph { set { _windSpeedMph = value; } }

        public String BackGroundImg
        {
            get
            {
                String stat = SkyStat;
                String res = "Assets/";

                if (stat.Contains("Rain"))
                    res += "Rain.png";
                else if (stat.Contains("Snow") || stat.Contains("Ice") || stat.Contains("Hail"))
                    res += "Snow.png";
                else if (stat.Contains("Mist") || stat.Contains("Fog") || stat.Contains("Smoke"))
                    res += "Cloud.png";
                else if (stat.Contains("Ash") || stat.Contains("Dust") || stat.Contains("Sand") ||
                         stat.Contains("Haze") || stat.Contains("Spray") || stat.Contains("Sandstorm"))
                    res += "Cloud.png";
                else if (stat.Contains("Rain") && !stat.Contains("Thunderstorm"))
                    res += "Rain.png";
                else if (stat.Contains("Thunderstorm"))
                    res += "thunderstorm.png";
                else if (stat.Contains("Overcast") || stat.Contains("Cloudy") || stat.Contains("Cloud") || stat.Contains("Squalls"))
                    res += "Cloud.png";
                else if (stat.Contains("Clear") || stat.Contains("Partly Cloudy"))
                    res += "Clear.png";
                else // if N/A, Unknown or error
                    res += "NoInfo.png";

                return res;
            }
        }
    }
}