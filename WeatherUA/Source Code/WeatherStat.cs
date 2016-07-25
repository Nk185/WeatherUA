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

using System;
using System.ComponentModel;

namespace WeatherUA.Source_Code
{
    public class WeatherStat
    {
        private string _skyStat = "N/A";
        private string _bgImg;
        
        #region Public properties
        /// <summary>
        /// Gets or sets sky status. E.g. Clear, Raing, Chace of a thunderstorm, etc.
        /// </summary>
        public string SkyStat
        {
            get { return _skyStat; }
            set
            {
                _skyStat = value;

                if (value.Contains("Rain"))
                    _bgImg = "Assets/Rainy";
                else if (value.Contains("Snow") || value.Contains("Ice") || value.Contains("Hail"))
                    _bgImg = "Assets/Snowy";
                else if (value.Contains("Mist") || value.Contains("Fog") || value.Contains("Smoke"))
                    _bgImg = "Assets/Mist";
                else if (value.Contains("Ash") || value.Contains("Dust") || _skyStat.Contains("Sand") ||
                         value.Contains("Haze") || value.Contains("Spray") || value.Contains("Sandstorm"))
                    _bgImg = "Assets/Dust";
                else if (value.Contains("Rain") && !value.Contains("Thunderstorms"))
                    _bgImg = "Assets/Rainy";
                else if (value.Contains("Thunderstorms"))
                    _bgImg = "Assets/Thunderstorm";
                else if (value.Contains("Overcast") || value.Contains("Cloudy") || value.Contains("Cloud") ||
                         value.Contains("Squalls"))
                    _bgImg = "Assets/Cloudy";
                else if (value.Contains("Clear") || value.Contains("Partly Cloudy"))
                    _bgImg = "Assets/Clear";
                else // if N/A, Unknown or error
                    _bgImg = "Assets/SolidColor";
            }
        }
        /// <summary>
        /// Gets or sets wind direction in form like: WNW, N, NNE, etc.
        /// </summary>
        public string WindDirection { get; set; }


        /// <summary>
        /// Gets or sets current temperature in Celsius degrees.
        /// </summary>
        public int TemperatureC { get; set; }
        /// <summary>
        /// Gets or sets current temperature in Fahrenheit degrees.
        /// </summary>
        public int TemperatureF { get; set; }
        /// <summary>
        /// Gets or sets "feels like" temperature in Celsius degrees.
        /// </summary>
        public int FeelsLikeC { get; set; }
        /// <summary>
        /// Gets or sets "feels like" temperature in Fahrenheit degrees.
        /// </summary>
        public int FeelsLikeF { get; set; }


        /// <summary>
        /// Gets or sets wind speed in kilometers per hour.
        /// </summary>
        public uint WindSpeedKph { get; set; }
        /// <summary>
        /// Gets or sets wind speed in miles per hour.
        /// </summary>
        public uint WindSpeedMph { get; set; }


        /// <summary>
        /// Sets hour when sun rises.
        /// </summary>
        public uint SunRise { private get; set; }
        /// <summary>
        /// Sets hour when moon rises.
        /// </summary>
        public uint MoonRise { private get; set; }
        /// <summary>
        /// Gets or sets local time in specified city.
        /// </summary>
        public uint Localtime { get; set; }


        /// <summary>
        /// Gets path to the icon of sky status.
        /// </summary>
        public string BackGroundImg
        {
            get
            {
                if (_bgImg.Contains("SolidColor") || _bgImg.Contains("Thunderstorm"))
                    return _bgImg + ".jpg";
                else
                    return _bgImg + (IsDayNow() ? "" : "Night") + ".jpg";
            }
        } 
        #endregion

        public WeatherStat()
        {
            TemperatureC  = 0;
            TemperatureF  = 0;
            FeelsLikeC    = 0;
            FeelsLikeF    = 0;
            WindSpeedKph  = 0;
            WindSpeedMph  = 0;
            WindDirection = "N/A";
            SkyStat       = "N/A";
        }

        /// <summary>
        /// Defines if day now or night.
        /// </summary>
        /// <returns>If day now. If error occured, returns true.</returns>
        private bool IsDayNow()
        {
            if (SunRise == MoonRise)
                return true;

            return Localtime < MoonRise && Localtime >= SunRise;
        }
    }
}