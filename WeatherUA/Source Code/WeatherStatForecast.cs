/*
 * Application:    WeatherUA
 * Solution:       WeatherUA
 * Copyright:      Nk185
 * Code copyright: Nk185
 * File version:   1.4.4.0
 * Used external packages: 
 *      Galasoft - MVVM;
 *      Newtonsoft - JSON;
 */

namespace WeatherUA.Source_Code
{
    public class WeatherStatForecast
    {
        private string _skyStat = "N/A";
        private string _windDirection = "N/A";

        /// <summary>
        /// Gets or sets sky status. E.g. Clear, Raing, Chace of a thunderstorm, etc.
        /// </summary>
        public string SkyStat
        {
            get
            {
                return _skyStat;
            }
            set
            {
                _skyStat = value;

                if (value.Contains("Rain"))
                    BackGroundImg = "Assets/Rain.png";
                else if (value.Contains("Snow") || value.Contains("Ice") || value.Contains("Hail"))
                    BackGroundImg = "Assets/Snow.png";
                else if (value.Contains("Mist") || value.Contains("Fog") || value.Contains("Smoke"))
                    BackGroundImg = "Assets/Cloud.png";
                else if (value.Contains("Ash") || value.Contains("Dust") || value.Contains("Sand") ||
                         value.Contains("Haze") || value.Contains("Spray") || value.Contains("Sandstorm"))
                    BackGroundImg = "Assets/Cloud.png";
                else if (value.Contains("Rain") && !value.Contains("Thunderstorm"))
                    BackGroundImg = "Assets/Rain.png";
                else if (value.Contains("Thunderstorm"))
                    BackGroundImg = "Assets/thunderstorm.png";
                else if (value.Contains("Overcast") || value.Contains("Cloudy") || value.Contains("Cloud") || value.Contains("Squalls"))
                    BackGroundImg = "Assets/Cloud.png";
                else if (value.Contains("Clear") || value.Contains("Partly Cloudy"))
                    BackGroundImg = "Assets/Clear.png";
                else // if N/A, Unknown or error
                    BackGroundImg = "Assets/NoInfo.png";
            }
        }
        /// <summary>
        /// Gets wind direction according to pattern: "Wind direction: [value]". Or sets wind direction as single word, e.g. WNW, N, NNE, etc.
        /// </summary>
        public string WindDirection { get { return "Wind direction: " + _windDirection; } set { _windDirection = value; } }
        /// <summary>
        /// Gets or sets number of the day. E.g. 1, 2, 3, 4, etc.
        /// </summary>
        public uint Day { get; set; }

        /// <summary>
        /// Gets or sets short form of this weekday. E.g. "Mo", "Tu", "We", etc.
        /// </summary>
        public string WeekdayShrt { get; set; }

        /// <summary>
        /// Gets or sets text forecast for this day's day.
        /// </summary>
        public string DayForecHint { get; set; }
        /// <summary>
        /// Gets or sets text forecast for this day's night.
        /// </summary>
        public string NightForecHint { get; set; }

        /// <summary>
        /// Gets or sets text forecast for this day's day in metric format.
        /// </summary>
        public string DayForecHintMetric { get; set; }
        /// <summary>
        /// Gets or sets text forecast for this day's night in metric format.
        /// </summary>
        public string NightForecHintMetric { get; set; }

        /// <summary>
        /// Gets highest temperature info according to pattern: "High: [value 1]°C / [value 2]°F"
        /// </summary>
        public string TemperatureH
        {
            get
            {
                return "High: " + TemperatureCH.ToString() + "°C / "
                       + TemperatureFH.ToString() + "°F";
            }
        }

        /// <summary>
        /// Gets lowest temperature info according to pattern: "Low: [value 1]°C / [value 2]°F"
        /// </summary>
        public string TemperatureL
        {
            get
            {
                return "Low: " + TemperatureCL.ToString() + "°C / "
                       + TemperatureFL.ToString() + "°F";
            }
        }

        /// <summary>
        /// Gets wind info according to pattern: "Wind speed: [value 1] km/h | [value 2] mph"
        /// </summary>
        public string Wind
        {
            get
            {
                return "Wind speed: " + WindSpeedKph.ToString() + " km/h | "
                       + WindSpeedMph.ToString() + " mph";
            }
        }
        
        /// <summary>
        /// Sets highest temperature this day in Celsius degrees.
        /// </summary>
        public int TemperatureCH { private get; set; }

        /// <summary>
        /// Sets highest temperature this day in Fahrenheit degrees.
        /// </summary>
        public int TemperatureFH { private get; set; }

        /// <summary>
        /// Sets lowest temperature this day in Celsius degrees.
        /// </summary>
        public int TemperatureCL { private get; set; }

        /// <summary>
        /// Sets lowest temperature this day in Fahrenheit degrees.
        /// </summary>
        public int TemperatureFL { private get; set; }

        /// <summary>
        /// Sets average wind speed this day in kilometers per hour.
        /// </summary>
        public uint WindSpeedKph { private get; set; }

        /// <summary>
        /// Sets average wind speed this day in miles per hour.
        /// </summary>
        public uint WindSpeedMph { private get; set; }

        /// <summary>
        /// Gets path to the icon of sky status
        /// </summary>
        public string BackGroundImg { get; private set; }

        public WeatherStatForecast()
        {
            Day = 0;
            WindSpeedMph  = 0;
            WindSpeedKph  = 0;
            TemperatureFL = 0;
            TemperatureCL = 0;
            TemperatureFH = 0;
            TemperatureCH = 0;

            WeekdayShrt = "N/A";
            DayForecHint = "N/A";
            NightForecHint = "N/A";
            DayForecHintMetric = "N/A";
            NightForecHintMetric = "N/A";
        }
    }
}