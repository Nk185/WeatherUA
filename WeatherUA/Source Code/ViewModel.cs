/*
 * Application:    WeatherUA
 * Solution:       WeatherUA
 * Copyright:      Nk185
 * Code copyright: Nk185
 * File version:   1.4.2.1
 * Used external packages: 
 *      Galasoft - MVVM;
 *      Newtonsoft - JSON;
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;


namespace WeatherUA.Source_Code
{
    public class WeatherStat
    {
        public string SkyStat = "N/A";
        public string WindDirection = "N/A";
        public int TemperatureC = 0;
        public int TemperatureF = 0;
        public int FeelsLikeC = 0;
        public int FeelsLikeF = 0;
        public uint WindSpeedKPH = 0;
        public uint WindSpeedMPH = 0;
    }

    public class WeatherStatForecast
    {
        private string _skyStat = "N/A";
        private string _windDirection = "N/A";
        private string _weekdayShrt = "N/A";
        private int _temperatureC_H = 0;
        private int _temperatureF_H = 0;
        private int _temperatureC_L = 0;
        private int _temperatureF_L = 0;
        private uint _windSpeedKPH = 0;
        private uint _windSpeedMPH = 0;
        private uint _day = 0;

        public string SkyStat { get { return this._skyStat; } set { this._skyStat = value; } }
        public string WindDirection { get { return "Wind direction: " + this._windDirection; } set { this._windDirection = value; } }
        public uint Day { get { return this._day; } set { this._day = value; } }
        public string WeekdayShrt { get { return this._weekdayShrt; } set { this._weekdayShrt = value; } }

        public string TemperatureH
        {
            get
            {
                return "High: " + this._temperatureC_H.ToString() + "°C / "
                    + this._temperatureF_H.ToString() + "°F";
            }
        }
        public string TemperatureL
        {
            get
            {
                return "Low: " + this._temperatureC_L.ToString() + "°C / "
                    + this._temperatureF_L.ToString() + "°F";
            }
        }
        public string Wind
        {
            get
            {
                return "Wind speed: " + this._windSpeedKPH.ToString() + " km/h | "
                    + this._windSpeedMPH.ToString() + " mph";
            }
        }

        public int TemperatureC_H { set { this._temperatureC_H = value; } }
        public int TemperatureF_H { set { this._temperatureF_H = value; } }
        public int TemperatureC_L { set { this._temperatureC_L = value; } }
        public int TemperatureF_L { set { this._temperatureF_L = value; } }


        public uint WindSpeedKPH { set { this._windSpeedKPH = value; } }
        public uint WindSpeedMPH { set { this._windSpeedMPH = value; } }

        public String BackGroundImg
        {
            get
            {
                String _stat = this.SkyStat;
                String res = "Assets/";

                if (_stat.Contains("Rain"))
                    res += "Rain.png";
                else if (_stat.Contains("Snow") || _stat.Contains("Ice") || _stat.Contains("Hail"))
                    res += "Snow.png";
                else if (_stat.Contains("Mist") || _stat.Contains("Fog") || _stat.Contains("Smoke"))
                    res += "Cloud.png";
                else if (_stat.Contains("Ash") || _stat.Contains("Dust") || _stat.Contains("Sand") ||
                    _stat.Contains("Haze") || _stat.Contains("Spray") || _stat.Contains("Sandstorm"))
                    res += "Cloud.png";
                else if (_stat.Contains("Rain") && !_stat.Contains("Thunderstorm"))
                    res += "Rain.png";
                else if (_stat.Contains("Thunderstorm"))
                    res += "thunderstorm.png";
                else if (_stat.Contains("Overcast") || _stat.Contains("Cloudy") || _stat.Contains("Cloud") || _stat.Contains("Squalls"))
                    res += "Cloud.png";
                else if (_stat.Contains("Clear") || _stat.Contains("Partly Cloudy"))
                    res += "Clear.png";
                else // if N/A, Unknown or error
                    res += "NoInfo.png";

                return res;
            }
        }
    }

    public class ViewModel : ViewModelBase, IViewModelNotifier
    {   
        private Model _Mdl; // Model; Contains data
        private WeatherStat _currentStatus = new WeatherStat();
        private WeatherStatForecast[] Forecast = new WeatherStatForecast[10]; // Array of weather statuses for Forecast
        private City _chosenCity;

        public RelayCommand UpdateBtn { get; private set; } // When button clicked in Settings     

        public List<City> Cities { get; set; } // Collection of items for listview (cities)
        public City ChosenCity
        {
            get { return this._chosenCity; }
            set
            {
                this._chosenCity = value;
                RaisePropertyChanged(() => this.ttlWeatherFor);
                UpdateInfo();
            }
        } // Auto update title and info when another city chosen

        public bool UpdateBtnEnabled { get; private set; }
        public bool ProgressRingEnabled { get { return !this.UpdateBtnEnabled; } }

        #region Main info about current day
        public String ttlWeatherFor { get { return "WEATHER FOR: " + this.ChosenCity.Name.ToUpper() + ", UKRAINE"; } } // Title
        public String TemperatureNow
        {
            get
            {
                return this._currentStatus.TemperatureC.ToString() +
                    "°C / " + this._currentStatus.TemperatureF + "°F";
            }
        }
        public String FeelsLike
        {
            get
            {
                return "Feels like: " + this._currentStatus.FeelsLikeC.ToString() +
                    "°C / " + this._currentStatus.FeelsLikeF + "°F";
            }
        }
        public String SkyStatus
        {
            get
            {
                if (this._currentStatus.SkyStat == "" || this._currentStatus.SkyStat == " ")
                    return "Sky status: N/A";
                else
                    return "Sky status: " + this._currentStatus.SkyStat;
            }
        }
        public String WindSpeed
        {
            get
            {
                return "Wind speed: " + this._currentStatus.WindSpeedKPH + "km/h | "
                    + this._currentStatus.WindSpeedMPH + "mph";
            }
        }
        public String WindDirection { get { return "Wind direction: " + this._currentStatus.WindDirection; } }
        public String BackGroundImg
        {
            get
            {
                String _stat = this._currentStatus.SkyStat;
                String res = "Assets/";

                if (_stat.Contains("Rain"))
                    res += "Rainy.jpg";
                else if (_stat.Contains("Snow") || _stat.Contains("Ice") || _stat.Contains("Hail"))
                    res += "Snowy.jpg";
                else if (_stat.Contains("Mist") || _stat.Contains("Fog") || _stat.Contains("Smoke"))
                    res += "Mist.jpg";
                else if (_stat.Contains("Ash") || _stat.Contains("Dust") || _stat.Contains("Sand") ||
                    _stat.Contains("Haze") || _stat.Contains("Spray") || _stat.Contains("Sandstorm"))
                    res += "Dust.jpg";
                else if (_stat.Contains("Rain") && !_stat.Contains("Thunderstorms"))
                    res += "Rainy.jpg";
                else if (_stat.Contains("Thunderstorms"))
                    res += "Thunderstorm.jpg";
                else if (_stat.Contains("Overcast") || _stat.Contains("Cloudy") || _stat.Contains("Cloud") || _stat.Contains("Squalls"))
                    res += "Cloudy.jpg";
                else if (_stat.Contains("Clear") || _stat.Contains("Partly Cloudy"))
                    res += "Sunny.jpg";
                else // if N/A, Unknown or error
                    res += "SolidColor.jpg";

                return res;
            }
        }
        #endregion

        #region Forecast propertys for each day
        public WeatherStatForecast getWeatherDay1 { get { return this.Forecast[0]; } }
        public WeatherStatForecast getWeatherDay2 { get { return this.Forecast[1]; } }
        public WeatherStatForecast getWeatherDay3 { get { return this.Forecast[2]; } }
        public WeatherStatForecast getWeatherDay4 { get { return this.Forecast[3]; } }
        public WeatherStatForecast getWeatherDay5 { get { return this.Forecast[4]; } }
        public WeatherStatForecast getWeatherDay6 { get { return this.Forecast[5]; } }
        public WeatherStatForecast getWeatherDay7 { get { return this.Forecast[6]; } }
        public WeatherStatForecast getWeatherDay8 { get { return this.Forecast[7]; } }
        public WeatherStatForecast getWeatherDay9 { get { return this.Forecast[8]; } }
        public WeatherStatForecast getWeatherDay10 { get { return this.Forecast[9]; } }
        #endregion

        public ViewModel()
        {
            // Initialize model
            // Load cities
            this._Mdl = new Model(this);
            this.Cities = this._Mdl.Cities;

            // Init default city
            this._chosenCity = this.Cities[65];

            //Load weather from server
            UpdateInfo();

            // If user want to update info manualy
            this.UpdateBtn = new RelayCommand(this.Click);
        }

        /// <summary>
        /// Manul information updating
        /// </summary>
        private void Click()
        {
            UpdateInfo();
        }

        /// <summary>
        /// Load/Update forecast and current info
        /// </summary>
        private void UpdateInfo()
        {
            this.UpdateBtnEnabled = false;
            RaisePropertyChanged(() => this.UpdateBtnEnabled);
            RaisePropertyChanged(() => this.ProgressRingEnabled);

            this._Mdl.LoadWeatherData(this.ChosenCity.Content);
        }

        /// <summary>
        /// Implements IViewModelNotifier.
        /// Updates UI according to passed data
        /// </summary>
        /// <param name="NewStat">New information about current weather.</param>
        /// <param name="NewForecast">New information about forecast.</param>
        /// <param name="isStatValid">If current weather contains valid data.</param>
        /// <param name="isForecValid">If forecast conteins valid data.</param>
        public void PropertyChangedW(WeatherStat NewStat, WeatherStatForecast[] NewForecast, bool isStatValid, bool isForecValid)
        {
            if (isStatValid)
            {
                this._currentStatus = NewStat;

                RaisePropertyChanged(() => this.ttlWeatherFor);
                RaisePropertyChanged(() => this.TemperatureNow);
                RaisePropertyChanged(() => this.FeelsLike);
                RaisePropertyChanged(() => this.SkyStatus);
                RaisePropertyChanged(() => this.WindSpeed);
                RaisePropertyChanged(() => this.WindDirection);
                RaisePropertyChanged(() => this.BackGroundImg);
            }

            if (isForecValid)
            {
                for (int i = 0; i < 10; i++)
                    this.Forecast[i] = NewForecast[i];

                RaisePropertyChanged(() => this.getWeatherDay1);
                RaisePropertyChanged(() => this.getWeatherDay2);
                RaisePropertyChanged(() => this.getWeatherDay3);
                RaisePropertyChanged(() => this.getWeatherDay4);
                RaisePropertyChanged(() => this.getWeatherDay5);
                RaisePropertyChanged(() => this.getWeatherDay6);
                RaisePropertyChanged(() => this.getWeatherDay7);
                RaisePropertyChanged(() => this.getWeatherDay8);
                RaisePropertyChanged(() => this.getWeatherDay9);
                RaisePropertyChanged(() => this.getWeatherDay10);
            }

            this.UpdateBtnEnabled = true;
            RaisePropertyChanged(() => this.UpdateBtnEnabled);
            RaisePropertyChanged(() => this.ProgressRingEnabled);
        }
    }
}